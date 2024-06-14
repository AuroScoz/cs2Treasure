using Cysharp.Threading.Tasks;
using Gladiators.Main;
using Gladiators.Socket.Matchgame;
using Newtonsoft.Json.Linq;
using Scoz.Func;
using Service.Realms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gladiators.Socket {
    public partial class GameConnector : MonoBehaviour {


        bool IsConnectomg = false;
        Action OnConnToMatchgame;//連線Matchgame callback
        Action OnJoinGameFail;//連線Matchgame失敗callback
        Action OnMatchgameDisconnected;//與Matchgame 斷線callback

        /// <summary>
        /// 確認DBMatchgame表被建立後會跳BattleScene並開始跑ConnToMatchgame開始連線到Matchgame
        /// </summary>
        public void ConnToMatchgame(Action _onConnected, Action _onJoinGameFail, Action _onDisconnected) {
            if (AllocatedRoom.Instance.CurGameState != AllocatedRoom.GameState.NotInGame) return;
            AllocatedRoom.Instance.SetGameState(AllocatedRoom.GameState.UnAuth);
            if (IsConnectomg) return;
            OnConnToMatchgame = _onConnected;
            OnJoinGameFail = _onJoinGameFail;
            OnMatchgameDisconnected = _onDisconnected;

            WriteLog.LogColor("DBMatchgame已建立好, 開始連線到Matchgame", WriteLog.LogType.Connection);
            UniTask.Void(async () => {
                var dbMatchgame = await GamePlayer.Instance.GetMatchGame();
                if (dbMatchgame == null) {
                    WriteLog.LogError("JoinMatchgame失敗，dbMatchgame is null");
                    OnJoinGameFail?.Invoke();
                    return;
                }
                IsConnectomg = true;
                JoinMatchgame().Forget(); //開始連線到Matchgame                                          
            });
        }
        /// <summary>
        /// 個人測試模式(不使用Agones服務, 不會透過Matchmaker分配房間再把ip回傳給client, 而是直接讓client去連資料庫matchgame的ip)
        /// </summary>
        public void ConnectToMatchgameTestVer(Action _onConnnectedAC, Action _onJoinGameFail, Action _onDisconnected) {
            // 建立房間成功
            WriteLog.LogColor("個人測試模式連線Matchgame: ", WriteLog.LogType.Connection);
            var gameState = GamePlayer.Instance.GetDBGameSettingDoc(DBGameSettingDoc.GameState);
            //設定玩家目前所在遊戲房間的資料
            UniTask.Void(async () => {
                await AllocatedRoom.Instance.SetRoom_TestvVer("System", new string[2], gameState.MatchgameTestverMapID, gameState.MatchgameTestverRoomName, gameState.MatchgameTestverTcpIP, gameState.MatchgameTestverUdpIP, gameState.MatchgameTestverPort ?? 0, "");
                ConnToMatchgame(_onConnnectedAC, _onJoinGameFail, _onDisconnected);
            });
        }
        /// <summary>
        /// 加入Matchmage
        /// </summary>
        async UniTask JoinMatchgame() {
            var realmToken = await RealmManager.GetValidAccessToken();
            if (string.IsNullOrEmpty(AllocatedRoom.Instance.TcpIP) || string.IsNullOrEmpty(AllocatedRoom.Instance.UdpIP) || AllocatedRoom.Instance.Port == 0) {
                WriteLog.LogError("JoinMatchgame失敗，AllocatedRoom的IP或Port為null");
                OnJoinGameFail?.Invoke();
                return;
            }
            Socket.JoinMatchgame(GameDisconnected, realmToken, AllocatedRoom.Instance.TcpIP, AllocatedRoom.Instance.UdpIP, AllocatedRoom.Instance.Port);
        }

        void JoinGameSuccess() {
            IsConnectomg = false;
            OnConnToMatchgame?.Invoke();
            WriteLog.LogColor("JoinMatchgame success!", WriteLog.LogType.Connection);
        }

        void JoinGameFailed(Exception ex) {
            IsConnectomg = false;
            Debug.Log("JoinMatghgame failed: " + ex);
            OnJoinGameFail?.Invoke();
        }

        void GameDisconnected() {
            IsConnectomg = false;
            OnMatchgameDisconnected?.Invoke();
        }
        /// <summary>
        /// 通知Server此玩家已經進入BattleScene
        /// </summary>
        public void SetReady() {
            var cmd = new SocketCMD<READY>(new READY());
            Socket.TCPSend(cmd);
        }
        /// <summary>
        /// 通知Server此玩家已經進入BattleScene
        /// </summary>
        public void SetPlayer(string _dbGladiatorID) {
            var cmd = new SocketCMD<SETPLAYER>(new SETPLAYER(_dbGladiatorID));
            Socket.TCPSend(cmd);
        }
        /// <summary>
        /// 通知Server此玩家已經進入BattleScene
        /// </summary>
        public void Bribe(int[] _jsonBribeIDs) {
            var cmd = new SocketCMD<BRIBE>(new BRIBE(_jsonBribeIDs));
            Socket.TCPSend(cmd);
        }
    }
}