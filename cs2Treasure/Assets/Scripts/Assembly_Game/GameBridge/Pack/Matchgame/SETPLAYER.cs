namespace Gladiators.Socket.Matchgame {
    public class SETPLAYER : SocketContent {
        //class名稱就是封包的CMD名稱
        public string DBGladiatorID { get; private set; }

        public SETPLAYER(string _dbGladiatorID) {
            DBGladiatorID = _dbGladiatorID;
        }
    }

    public class SETPLAYER_TOCLIENT : SocketContent {
        //class名稱就是封包的CMD名稱
        public PackPlayer[] Players { get; private set; }
    }
    public class PackPlayer {
        public string DBPlayerID { get; private set; }
        public PackGladiator Gladiator { get; private set; }
    }
}