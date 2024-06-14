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
using Cysharp.Threading.Tasks;

namespace Gladiators.Socket {
    public class TcpClient : MonoBehaviour, INetworkClient {
        public event Action<string> OnReceiveMsg;

        private System.Net.Sockets.Socket socket;
        string IP { get; set; }
        int Port { get; set; }
        private Thread thread_connect;
        private Thread thread_receive;

        private event Action<bool> OnConnect;
        private event Action OnDisConnectEvent;
        private int packetID;
        private SynchronizationContext syncContext;
        private CancellationTokenSource cancellationSource;
        private CancellationToken cancellationToken;

        private ConcurrentQueue<string> messageQueue = new ConcurrentQueue<string>();
        private bool isTryConnect = false;
        private void Start() {
            DontDestroyOnLoad(this);
        }

        private void OnApplicationQuit() {
            try {
                if (thread_connect != null)
                    thread_connect.Abort();
                if (thread_receive != null)
                    thread_receive.Abort();
                if (cancellationSource != null)
                    cancellationSource.Dispose();
            }
            catch {

            }

        }

        public void Init(string ip, int port) {
            Init(ip, port, protocol: ProtocolType.Tcp);
        }

        public void Init(string ip, int port, AddressFamily family = AddressFamily.InterNetwork, SocketType type = SocketType.Stream, ProtocolType protocol = ProtocolType.Tcp) {
            IP = ip;
            Port = port;
            socket = new System.Net.Sockets.Socket(family, type, protocol);
            this.OnConnect = null;
            this.OnDisConnectEvent = null;
            this.OnReceiveMsg = null;

            if (thread_receive != null)
                thread_receive.Abort();
            syncContext = SynchronizationContext.Current;
            cancellationSource = new CancellationTokenSource();
            cancellationToken = cancellationSource.Token;
            WriteLog.LogColor("Tcp init", WriteLog.LogType.Connection);
        }

        public void StartConnect(Action<bool> _cb) {
            if (isTryConnect) return;
            WriteLog.LogColor("Tcp start connecting", WriteLog.LogType.Connection);
            this.OnConnect = _cb;
            isTryConnect = true;
            thread_connect = new Thread(Thread_Connect);
            thread_connect.Start();
            //StartCoroutine(HandleConnect());
        }

        public void RegistOnDisconnect(Action _cb) {
            OnDisConnectEvent += _cb;
        }

        public void UnRegistOnDisconnect(Action _cb) {
            OnDisConnectEvent -= _cb;
        }

        public void Close() {
            WriteLog.LogColor("Socket close", WriteLog.LogType.Connection);
            try {
                if (thread_connect != null)
                    thread_connect.Abort();
                if (thread_receive != null)
                    thread_receive.Abort();
                if (cancellationSource != null)
                    cancellationSource.Dispose();
                if (!IsConnected || socket == null) return;
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch {

            }
            StopAllCoroutines();
            Destroy(this.gameObject);
        }

        public bool IsConnected {
            get {
                if (socket == null) return false;
                else return socket.Connected;
            }
        }

        public int Send<T>(SocketCMD<T> command) where T : SocketContent {

            if (IsConnected) {
                try {
                    command.SetPackID(packetID++ % int.MaxValue);
                    string msg = LitJson.JsonMapper.ToJson(command);
                    socket.Send(Encoding.UTF8.GetBytes(msg));
                    WriteLog.LogColorFormat("(TCP)送: {0}", WriteLog.LogType.Connection, msg);
                    return command.PackID;
                }
                catch (Exception e) {
                    WriteLog.LogErrorFormat("Socket send error: {0}", e.ToString());
                    OnDisConnect();
                    return -1;
                }
            }
            OnDisConnect();
            return -1;
        }

        private async void Thread_Connect() {
            try {
                WriteLog.LogColor("IP=" + IP, WriteLog.LogType.Connection);
                WriteLog.LogColor("Port=" + Port, WriteLog.LogType.Connection);
                socket.Connect(IPAddress.Parse(IP), Port);

                await UniTask.WaitUntil(() => socket.Connected, cancellationToken: cancellationToken);
                syncContext.Post(state => OnConnect(true), null);

                WriteLog.LogColor("Tcp connect success", WriteLog.LogType.Connection);
                thread_receive = new Thread(Thread_Receive);
                thread_receive.Start();
            } catch (Exception e) {
                WriteLog.LogErrorFormat("(TCP)Socket send error: {0}", e.ToString());
                isTryConnect = false;

                cancellationSource.Cancel();
                syncContext.Post(state => OnConnect(false), null);
            }
        }

        //private IEnumerator HandleConnect() {
        //    while (isTryConnect) {
        //        if (socket != null && socket.Connected) {
        //            isTryConnect = false;
        //            OnConnect?.Invoke(true);
        //            StartCoroutine(HandleMessageEvent());
        //            yield break;
        //        }
        //        yield return null;
        //    }
        //    WriteLog.LogErrorFormat("Call connect error");
        //    OnConnect?.Invoke(false);
        //}

        private void Thread_Receive() {
            string mseQueue = "";
            while (IsConnected) {
                try {
                    //if (socket.Available <= 0) continue;
                    byte[] tmp = new byte[2048];
                    int length = socket.Receive(tmp);
                    if (length <= 0) {
                        //OnDisConnect();
                        break;
                    }


                    string msg = Encoding.UTF8.GetString(tmp, 0, length);
                    //WriteLog.Log("Socket Recieve " + msg + " " + length);
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
                        if (!string.IsNullOrEmpty(packets[i])) {
                            string packet = packets[i];
                            syncContext.Post(state => OnReceiveMsg?.Invoke(packet), null);
                        }
                            //messageQueue.Enqueue(packets[i]);
                    }
                }
                catch (ThreadAbortException e) {
                    //this.Close();
                    WriteLog.Log($"TcpClient Exception={e}");
                    WriteLog.LogWarning($"TcpClient Exception={e}");
                    break;
                }
                catch (Exception e) {
                    WriteLog.LogErrorFormat("Scoket receive error: {0}", e.ToString());
                    //OnDisConnect();
                    break;
                }
            }
            try {
                socket.Close();
            }
            catch {
            }

        }

        //private IEnumerator HandleMessageEvent() {
        //    while (socket.Connected) {
        //        while (!messageQueue.IsEmpty) {
        //            if (messageQueue.TryDequeue(out string msg)) {
        //                OnReceiveMsg?.Invoke(msg);
        //            }
        //        }
        //        yield return null;
        //    }
        //    OnDisConnect();
        //}

        private void OnDisConnect() {
            OnDisConnectEvent?.Invoke();
            Close();
        }
    }

}
