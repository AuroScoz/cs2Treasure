using Castle.Core.Internal;
using Cysharp.Threading.Tasks;
using cs2Treasure.Socket;
using cs2Treasure.Socket.Matchgame;
using Scoz.Func;
using Service.Realms;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace cs2Treasure.Main {
    /// <summary>
    /// 玩家目前所在遊戲房間的資料，CreateRoom後會從Matchmaker回傳取得資料
    /// </summary>
    public class AllocatedRoom {
        public static AllocatedRoom Instance { get; private set; }
        /// <summary>
        /// 創房者ID
        /// </summary>
        public string CreaterID { get; private set; }
        /// <summary>
        /// 房間內的所有PlayerID, 索引就是玩家的座位, 一進房間後就不會更動 PlayerIDs[0]就是在座位0玩家的PlayerID
        /// </summary>
        public string[] PlayerIDs { get; private set; }
        /// <summary>
        /// DB地圖ID
        /// </summary>
        public string DBMapID { get; private set; }
        /// <summary>
        /// DBMatchgame的ID(由Matchmaker產生，格視為[玩家ID]_[累加數字]_[日期時間])
        /// </summary>
        public string DBMatchgameID { get; private set; }
        /// <summary>
        ///  Matchmaker派發Matchgame的IP
        /// </summary>
        public string TcpIP { get; private set; }
        /// <summary>
        ///  Matchmaker派發Matchgame的IP
        /// </summary>
        public string UdpIP { get; private set; }

        /// <summary>
        ///  Matchmaker派發Matchgame的Port
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// Matchmaker派發Matchgame的Pod名稱
        /// </summary>
        public string PodName { get; private set; }

        public enum GameState {
            NotInGame,// 不在遊戲中
            UnAuth,//已經從Matchmaker收到配對房間但還沒從Matchgame收到Auth回傳true
            Authed,//已經從Matchgame收到Auth驗證
            GotPlayer,//已經從Matchgame收到玩家資料
            Playing,//遊玩中(加入Matchgame並收到Auth回傳true)
        }
        public GameState CurGameState { get; private set; } = GameState.NotInGame;
        public static void Init() {
            Instance = new AllocatedRoom();
        }

        /// <summary>
        /// 設定被Matchmaker分配到的房間資料，CreateRoom後會從Matchmaker回傳取得此資料
        /// </summary>
        public async UniTask SetRoom(string _createID, string[] _playerIDs, string _dbMapID, string _dbMatchgameID, string _ip, int _port, string _podName) {
            CreaterID = _createID;
            PlayerIDs = _playerIDs;
            DBMapID = _dbMapID;
            DBMatchgameID = _dbMatchgameID;
            TcpIP = _ip;
            UdpIP = _ip;
            Port = _port;
            PodName = _podName;
            WriteLog.LogColorFormat("設定被Matchmaker分配到的房間資料: {0}", WriteLog.LogType.Debug, DebugUtils.ObjToStr(Instance));

            var dbPlayer = GamePlayer.Instance.GetDBPlayerDoc<DBPlayer>();
            if (dbPlayer == null) return;
            await dbPlayer.SetInMatchgameID(DBMatchgameID);
        }
        /// <summary>
        /// 設定被Matchmaker分配到的房間資料，CreateRoom後會從Matchmaker回傳取得此資料
        /// </summary>
        public async UniTask SetRoom_TestvVer(string _createID, string[] _playerIDs, string _dbMapID, string _dbMatchgameID, string _tcpIP, string _udpIP, int _port, string _podName) {
            CreaterID = _createID;
            PlayerIDs = _playerIDs;
            DBMapID = _dbMapID;
            DBMatchgameID = _dbMatchgameID;
            TcpIP = _tcpIP;
            UdpIP = _udpIP;
            Port = _port;
            PodName = _podName;
            WriteLog.LogColorFormat("設定被Matchmaker分配到的房間資料: {0}", WriteLog.LogType.Debug, DebugUtils.ObjToStr(Instance));

            var dbPlayer = GamePlayer.Instance.GetDBPlayerDoc<DBPlayer>();
            if (dbPlayer == null) return;
            await dbPlayer.SetInMatchgameID(DBMatchgameID);
        }
        public void SetGameState(GameState _value) {
            CurGameState = _value;
            WriteLog.Log("遊戲狀態切換為:" + _value);
        }
        /// <summary>
        /// 清空配對房間(AllocatedRoom)資訊
        /// </summary>
        public void ClearRoom() {
            SetGameState(GameState.NotInGame);
            CreaterID = null;
            PlayerIDs = null;
            DBMapID = null;
            DBMatchgameID = null;
            Port = 0;
            PodName = null;
            WriteLog.LogColorFormat("清空配對房間(AllocatedRoom)資訊: {0}", WriteLog.LogType.Debug, DebugUtils.ObjToStr(Instance));

            var dbPlayer = GamePlayer.Instance.GetDBPlayerDoc<DBPlayer>();
            if (dbPlayer == null) return;
            dbPlayer.SetInMatchgameID(null).Forget();
        }
    }
}

