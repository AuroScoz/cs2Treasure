using Cysharp.Threading.Tasks;
using Gladiators.Main;
using Gladiators.Socket.Matchmaker;
using LitJson;
using NSubstitute;
using Scoz.Func;
using Service.Realms;
using System;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gladiators.Socket {
    public partial class GladiatorsSocket {

        TcpClient TCP_MatchmakerClient;

        readonly Subject<Unit> LogInSubject = new Subject<Unit>();
        readonly Subject<CREATEROOM_TOCLIENT> CreateRoomSubject = new Subject<CREATEROOM_TOCLIENT>();
        public IObservable<Unit> LogInObservable => LogInSubject;
        public IObservable<CREATEROOM_TOCLIENT> CreateRoomObservable => CreateRoomSubject;

        public void CreateMatchmaker(string _ip, int _port) {
            if (TCP_MatchmakerClient != null)
                TCP_MatchmakerClient.Close();
            TCP_MatchmakerClient = new GameObject("MatchmakerSocket").AddComponent<TcpClient>();
            TCP_MatchmakerClient.Init(_ip, _port);
            TCP_MatchmakerClient.OnReceiveMsg += OnRecieveMatchmakerTCPMsg;
        }
        private void OnMatchmakerDisconnect() {
            WriteLog.LogColor("OnMatchmakerDisconnect", WriteLog.LogType.Connection);
        }
        public void LoginToMatchmaker(string _realmToken) {
            WriteLog.LogColor("LoginToMatchmaker", WriteLog.LogType.Connection);
            if (TCP_MatchmakerClient == null) {
                WriteLog.LogError("TCP_MatchmakerClient is null");
                LogInSubject?.OnError(null);
                return;
            }

            CMDCallback.Clear();
            TCP_MatchmakerClient.UnRegistOnDisconnect(OnMatchmakerDisconnect);

            TCP_MatchmakerClient.StartConnect((bool isConnect) => {
                if (!isConnect) {
                    LogInSubject?.OnError(null);
                    return;
                }

                OnMatchmakerConnect(_realmToken);
            });
            TCP_MatchmakerClient.RegistOnDisconnect(OnMatchmakerDisconnect);
        }

        public void CreateMatchmakerRoom(string _dbMapID) {
            WriteLog.LogColor("CreateMatchmakerRoom", WriteLog.LogType.Connection);
            CREATEROOM cmdContent = new CREATEROOM(_dbMapID, RealmManager.MyApp.CurrentUser.Id);//建立封包內容
            SocketCMD<CREATEROOM> cmd = new SocketCMD<CREATEROOM>(cmdContent);//建立封包
            int id = TCP_MatchmakerClient.Send(cmd);//送出封包
            if (id < 0) {
                CreateRoomSubject?.OnError(new Exception("packID小於0"));
                return;
            }
            //註冊回呼
            WriteLog.LogColor("註冊回呼", WriteLog.LogType.Connection);
            RegisterMatchgameCommandCB(SocketContent.MatchmakerCMD_TCP.CREATEROOM_TOCLIENT.ToString(), id, OnCreateMatchmakerRoom_Reply);
        }
        public void OnCreateMatchmakerRoom_Reply(string _msg) {
            WriteLog.LogColor("OnCreateMatchmakerRoom_Reply", WriteLog.LogType.Connection);
            var packet = LitJson.JsonMapper.ToObject<SocketCMD<CREATEROOM_TOCLIENT>>(_msg);

            //有錯誤
            if (!string.IsNullOrEmpty(packet.ErrMsg)) {
                //WriteLog.LogError("Create MatchmakerRoom Fail : " + packet.ErrMsg);
                CreateRoomSubject?.OnError(new Exception(packet.ErrMsg));
            } else
                CreateRoomSubject?.OnNext(packet.Content);
        }

        private void OnRecieveMatchmakerTCPMsg(string _msg) {
            try {
                SocketCMD<SocketContent> data = JsonMapper.ToObject<SocketCMD<SocketContent>>(_msg);
                WriteLog.LogColorFormat("Recieve Command: {0}   PackID: {1}", WriteLog.LogType.Connection, data.CMD, data.PackID);
                Tuple<string, int> commandID = new Tuple<string, int>(data.CMD, data.PackID);
                // 已登錄至callback的訊息
                if (CMDCallback.TryGetValue(commandID, out Action<string> _cb)) {
                    CMDCallback.Remove(commandID);
                    _cb?.Invoke(_msg);
                }
                // 未登錄的訊息
                else {
                    SocketContent.MatchmakerCMD_TCP cmdType;
                    if (!MyEnum.TryParseEnum(data.CMD, out cmdType)) {
                        WriteLog.LogErrorFormat("收到錯誤的命令類型: {0}", cmdType);
                        return;
                    }
                    WriteLog.LogWarningFormat("收到未登錄的訊息: {0}", cmdType);
                }
            } catch (Exception e) {
                WriteLog.LogError("Parse收到的封包時出錯 : " + e.ToString());
                if (SceneManager.GetActiveScene().name != MyScene.BattleScene.ToString()) {
                    WriteLog.LogErrorFormat("不在{0}就釋放資源: ", MyScene.BattleScene, e.ToString());
                    Release();
                }
            }
        }

        private void OnMatchmakerConnect(string _realmToken) {

            SocketCMD<AUTH> command = new SocketCMD<AUTH>(new AUTH(_realmToken));

            int id = TCP_MatchmakerClient.Send(command);
            if (id < 0) {
                LogInSubject?.OnError(null);
                return;
            }
            RegisterMatchgameCommandCB(SocketContent.MatchmakerCMD_TCP.AUTH_TOCLIENT.ToString(), id, (string msg) => {
                SocketCMD<AUTH_TOCLIENT> packet = LitJson.JsonMapper.ToObject<SocketCMD<AUTH_TOCLIENT>>(msg);
                if (packet.Content.IsAuth)
                    LogInSubject?.OnNext(Unit.Default);
                else
                    LogInSubject?.OnError(null);
                //_callback?.Invoke(packet.Content.IsAuth);
            });
        }
    }
}
