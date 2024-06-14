namespace Gladiators.Socket.Matchgame {
    public class AUTH : SocketContent {
        //class名稱就是封包的CMD名稱
        public string Token { get; private set; }

        public AUTH(string token) {
            Token = token;
        }
    }
    public class AUTH_TOCLIENT : SocketContent {
        //class名稱就是封包的CMD名稱
        public bool IsAuth { get; private set; }
        public string ConnToken { get; private set; } // Auth驗證成功後之後UDP要連Matchgame都是透過這個連線Token
        public AUTH_TOCLIENT() {
        }
    }
}