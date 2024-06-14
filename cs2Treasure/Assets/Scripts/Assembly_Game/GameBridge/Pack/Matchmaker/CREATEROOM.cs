using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace Gladiators.Socket.Matchmaker {
    public class CREATEROOM : SocketContent {
        //class名稱就是封包的CMD名稱

        public string DBMapID { get; private set; }
        public string CreaterID { get; private set; }

        public CREATEROOM(string _dbMapID, string _createrID) {
            DBMapID = _dbMapID;
            CreaterID = _createrID;
        }

    }

    public class CREATEROOM_TOCLIENT : SocketContent {
        //class名稱就是封包的CMD名稱

        public string CreaterID { get; private set; }
        public string[] PlayerIDs { get; private set; }
        public string DBMapID { get; private set; }
        /// <summary>
        /// DBMatchgame的ID(由Matchmaker產生，格視為[玩家ID]_[累加數字]_[日期時間])
        /// </summary>
        public string DBMatchgameID { get; private set; }
        /// <summary>
        /// Matchmaker派發Matchgame的IP
        /// </summary>
        public string IP { get; private set; }
        /// <summary>
        /// Matchmaker派發Matchgame的Port
        /// </summary>
        public int Port { get; private set; }
        /// <summary>
        /// Matchmaker派發Matchgame的Pod名稱
        /// </summary>
        public string PodName { get; private set; }


        public CREATEROOM_TOCLIENT() {
        }
    }
}