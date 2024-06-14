using Cysharp.Threading.Tasks;
using Gladiators.Main;
using Gladiators.Socket.Matchmaker;
using Scoz.Func;
using Service.Realms;
using System;
using UnityEngine;

namespace Gladiators.Socket {
    public partial class GameConnector : MonoBehaviour {
        int CurRetryTimes = 0; //目前重試次數
        string TmpDBMapID;//暫時紀錄要建立或加入的DBMapID
        Action OnConnToMatchmakerFail;//連線Matchmaker失敗 callback
        Action OnCreateRoomFail;//建立Matchgame房間失敗 callback
        Action<CREATEROOM_TOCLIENT> OnMatchgameCreated;//Matchgame房間建立好後回傳


        /// <summary>
        ///  1. 從DB取ip, port, 檢查目前Server狀態後傳入此function
        ///  2. 連線進Matchmaker後會驗證token, 沒問題會回傳成功並執行OnConnectEvent
        /// </summary>
        public async UniTask ConnToMatchmaker(string _dbMapID, Action _onConnToMatchmakerFail, Action _onCreateRoomFail, Action<CREATEROOM_TOCLIENT> _onMatchmakerCreated) {
            WriteLog.LogColor("Start ConnToMatchmaker", WriteLog.LogType.Connection);
            TmpDBMapID = _dbMapID;
            CurRetryTimes = 0;
            OnConnToMatchmakerFail = _onConnToMatchmakerFail;
            OnCreateRoomFail = _onCreateRoomFail;
            OnMatchgameCreated = _onMatchmakerCreated;
            // 接Socket
            var gameSetting = GamePlayer.Instance.GetDBGameSettingDoc(DBGameSettingDoc.GameSetting);
            Socket.CreateMatchmaker(gameSetting.MatchmakerIP, gameSetting.MatchmakerPort ?? 0);
            var token = await RealmManager.GetValidAccessToken();
            Socket.LoginToMatchmaker(token);

        }

        /// <summary>
        /// 登入配對伺服器成功時執行
        /// </summary>
        void OnLoginToMatchmaker() {
            WriteLog.LogColor("登入Matchmaker成功", WriteLog.LogType.Connection);
            CreateRoom();
        }

        /// <summary>
        /// 登入配對伺服器失敗
        /// </summary>
        async UniTask OnLoginToMatchmakerError() {
            // 連線失敗時嘗試重連
            CurRetryTimes++;
            if (CurRetryTimes > MAX_RETRY_TIMES || !InternetChecker.InternetConnected) {
                WriteLog.LogColorFormat("嘗試連線{0}次都失敗，糟糕了", WriteLog.LogType.Connection, CurRetryTimes, RETRY_INTERVAL_SECS);
                OnConnToMatchmakerFail?.Invoke();
            } else {
                WriteLog.LogColorFormat("第{0}次連線失敗，{0}秒後嘗試重連: ", WriteLog.LogType.Connection, CurRetryTimes, RETRY_INTERVAL_SECS);
                //連線失敗有可能是TOKEN過期 刷Token後再連
                var token = await RealmManager.GetValidAccessToken();
                Socket.LoginToMatchmaker(token);
            }
        }

        /// <summary>
        ///  1. 送Matchmaker(配對伺服器)來建立Matchgame(遊戲房)
        ///  2. 建立後會呼叫OnCreateRoom
        /// </summary>
        void CreateRoom() {
            CurRetryTimes = 0;
            Socket.CreateMatchmakerRoom(TmpDBMapID);
        }

        /// <summary>
        /// 收到建立房間結果回傳如果有錯誤就重連
        /// </summary>
        void OnCreateRoom(CREATEROOM_TOCLIENT _reply) {
            if (_reply == null) {
                OnCreateRoomFail?.Invoke();
                WriteLog.LogError("OnCreateRoom回傳的CREATEROOM_REPLY內容為null");
                return;
            }
            // 建立房間成功
            WriteLog.LogColorFormat("建立房間成功: ", WriteLog.LogType.Connection, DebugUtils.ObjToStr(_reply));
            OnMatchgameCreated?.Invoke(_reply);
        }

        private void OnCreateRoomError(Exception _exception) {
            // 建立房間失敗
            if (_exception != null) {
                CurRetryTimes++;
                if (CurRetryTimes > MAX_RETRY_TIMES || !InternetChecker.InternetConnected) {
                    OnCreateRoomFail?.Invoke();
                } else {
                    WriteLog.LogColor("[GameConnector] 建立房間失敗 再試1次", WriteLog.LogType.Connection);
                    // 再試一次
                    DG.Tweening.DOVirtual.DelayedCall(RETRY_INTERVAL_SECS, () => {
                        Socket.CreateMatchmakerRoom(TmpDBMapID);
                    });
                }
                return;
            }
        }

    }
}