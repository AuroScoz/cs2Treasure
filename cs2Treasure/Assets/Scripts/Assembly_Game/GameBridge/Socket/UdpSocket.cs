using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using Scoz.Func;
using Gladiators.Socket.Matchmaker;
using Gladiators.Socket.Matchgame;
using Service.Realms;

namespace Gladiators.Socket {
    public class UdpSocket : MonoBehaviour, INetworkClient {
        private const float CONNECTION_CLOSE_TIME = 5.0f; // 設定X秒沒收到封包就斷線
        public event Action<string> OnReceiveMsg;

        private UdpClient udpClient;
        private string IP;
        private int Port;
        private string udpToken;
        private Thread thread_connect;
        private Thread thread_receive;

        private event Action<bool> OnConnect;
        private event Action OnDisConnectEvent;
        private IPEndPoint RemoteIpEndPoint;
        private ConcurrentQueue<string> messageQueue = new ConcurrentQueue<string>();
        private bool isTryConnect = false;
        private float timer = 0;
        private int packetID;
        private WaitForFixedUpdate waitFixUpdate = new WaitForFixedUpdate();
        private System.Object timerLock = new System.Object();
        private void Start() {
            DontDestroyOnLoad(this);
        }

        private void OnApplicationQuit() {
            try {
                if (thread_connect != null)
                    thread_connect.Abort();
                if (thread_receive != null)
                    thread_receive.Abort();
            } catch {
            }
        }

        public void Init(string ip, int port) {
            IP = ip;
            Port = port;
            this.udpClient = new UdpClient();
            this.OnConnect = null;
            if (thread_receive != null)
                thread_receive.Abort();
            WriteLog.LogColorFormat("UDP Init", WriteLog.LogType.Connection);
        }

        public void StartConnect(string token, Action<bool> _cb) {
            if (isTryConnect) return;
            WriteLog.LogColorFormat("UDP Start connectint", WriteLog.LogType.Connection);
            this.OnConnect = _cb;
            isTryConnect = true;
            this.udpToken = token;

            thread_connect = new Thread(Thread_Connect);
            thread_connect.Start();
            StartCoroutine(HandleConnect());
        }

        public void RegistOnDisconnect(Action _cb) {
            OnDisConnectEvent += _cb;
        }

        public void Close() {
            WriteLog.LogColorFormat("Socket close", WriteLog.LogType.Connection);
            OnDisConnectEvent = null;
            try {
                if (thread_connect != null)
                    thread_connect.Abort();
                if (thread_receive != null)
                    thread_receive.Abort();
                if (!IsConnected || udpClient == null) return;
                udpClient.Close();
            } catch {
            }
            Destroy(this.gameObject);
        }

        public bool IsConnected {
            get {
                if (udpClient == null) return false;
                if (udpClient.Client == null) return false;
                return udpClient.Client.Connected;
            }
        }
        private void Thread_Connect() {
            try {
                RemoteIpEndPoint = new IPEndPoint(IPAddress.Parse(IP), Port);
                udpClient.Connect(IPAddress.Parse(IP), Port);

                WriteLog.LogColorFormat("Connect Success", WriteLog.LogType.Connection);
                thread_receive = new Thread(Thread_Receive);
                thread_receive.Start();
            } catch (Exception e) {
                WriteLog.LogErrorFormat("Socket send error: {0}", e.ToString());
                isTryConnect = false;
            }
        }

        private IEnumerator HandleConnect() {
            while (isTryConnect) {
                if (udpClient != null && udpClient.Client != null && udpClient.Client.Connected) {
                    isTryConnect = false;
                    OnConnect?.Invoke(true);
                    StartCoroutine(HandleMessageEvent());
                    StartCoroutine(CheckConnection());
                    yield break;
                }
                yield return null;
            }
            WriteLog.LogErrorFormat("Call connect error");
            OnConnect?.Invoke(false);
        }

        private void Thread_Receive() {
            string mseQueue = "";
            UDPAUTH cmdContent = new UDPAUTH();//建立封包內容
            SocketCMD<UDPAUTH> cmd = new SocketCMD<UDPAUTH>(cmdContent);//建立封包
            cmd.SetConnToken(udpToken);//設定封包ConnToken
            Send(cmd);
            while (true) {
                try {
                    //if (udpClient.Available <= 0) continue;
                    byte[] tmp = udpClient.Receive(ref RemoteIpEndPoint);
                    int length = tmp.Length;
                    if (length <= 0) break;
                    lock (timerLock) {
                        timer = 0;
                    }
                    string msg = Encoding.UTF8.GetString(tmp, 0, length);
                    //WriteLog.Log("UDP Socket Recieve " + msg + " " + length);
                    if (!string.IsNullOrEmpty(mseQueue)) {
                        msg = mseQueue + msg;
                        mseQueue = string.Empty;
                    }

                    //黏包
                    string[] packets = msg.Split('\n');
                    int packetNumber = packets.Length;
                    //分包 最後一包被截斷
                    if (msg.LastIndexOf('\n') != length - 1) {
                        mseQueue = mseQueue + packets[packets.Length - 1];
                        packetNumber--;
                    }
                    for (int i = 0; i < packetNumber; i++) {
                        if (!string.IsNullOrEmpty(packets[i]))
                            messageQueue.Enqueue(packets[i]);
                    }
                } catch (ThreadAbortException e) {
                    WriteLog.LogWarningFormat("Udp ThreadAbortException Exception " + e.ToString());
                    break;
                } catch (Exception e) {
                    WriteLog.LogErrorFormat("Udp Scoket receive error " + e.ToString());
                    break;
                }
            }
            try {
                this.Close();
            } catch {
            }
        }
        public int Send<T>(SocketCMD<T> cmd) where T : SocketContent {
            try {
                cmd.SetPackID(packetID++ % int.MaxValue);
                string msg = LitJson.JsonMapper.ToJson(cmd);
                udpClient.Send(Encoding.UTF8.GetBytes(msg), msg.Length);
                WriteLog.LogColorFormat("(UDP)送: {0}", WriteLog.LogType.Connection, msg);
                return cmd.PackID;
            } catch (Exception e) {
                WriteLog.LogErrorFormat("(UDP)Socket send error: {0}", e.ToString());
                return -1;
            }
        }

        private IEnumerator HandleMessageEvent() {
            while (udpClient != null && udpClient.Client != null && udpClient.Client.Connected) {
                while (!messageQueue.IsEmpty) {
                    if (messageQueue.TryDequeue(out string msg)) {
                        OnReceiveMsg?.Invoke(msg);
                    }
                }
                yield return null;
            }
            OnDisConnect();
        }

        private void OnDisConnect() {
            OnDisConnectEvent?.Invoke();
            Close();
        }

        private IEnumerator CheckConnection() {
            while (true) {
                lock (timerLock) {
                    timer += Time.fixedDeltaTime;
                }
                if (timer >= CONNECTION_CLOSE_TIME) {
                    //X秒都沒收到封包就斷線
                    OnDisConnect();
                    break;
                }
                yield return waitFixUpdate;
            }
        }

        public void ResetTimer() {
            lock (timerLock) {
                timer = 0;
            }
            //TCP 有訊息時檢查UDP有沒有連線
            if (!isTryConnect && !this.IsConnected && !string.IsNullOrEmpty(udpToken)) {
                isTryConnect = true;
                thread_connect = new Thread(Thread_Connect);
                thread_connect.Start();
                StartCoroutine(HandleConnect());
            }
        }

        public bool CheckTimerInTime() {
            return timer < CONNECTION_CLOSE_TIME;
        }
    }
}