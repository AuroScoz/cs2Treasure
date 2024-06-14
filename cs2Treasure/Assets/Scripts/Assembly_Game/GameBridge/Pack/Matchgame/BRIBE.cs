namespace Gladiators.Socket.Matchgame {
    public class BRIBE : SocketContent {
        //class名稱就是封包的CMD名稱
        public int[] JsonBribeIDs { get; private set; }
        public BRIBE(int[] _jsonBribeIDs) {
            JsonBribeIDs = _jsonBribeIDs;
        }
    }
    public class BRIBE_TOCLIENT : SocketContent {
        //class名稱就是封包的CMD名稱
        public PackPlayerBribe[] PlayerBribes { get; private set; }
    }
    public class PackPlayerBribe {
        public int[] JsonBribeIDs { get; private set; }
    }
}