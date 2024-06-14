namespace Gladiators.Socket.Matchgame {
    public class READY : SocketContent {
        //class名稱就是封包的CMD名稱
    }
    public class READY_TOCLIENT : SocketContent {
        //class名稱就是封包的CMD名稱
        public bool[] PlayerReadies { get; private set; }
    }
}