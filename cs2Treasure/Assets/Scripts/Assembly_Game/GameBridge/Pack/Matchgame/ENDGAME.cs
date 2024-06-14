namespace Gladiators.Socket.Matchgame {
    public class ENDGAME : SocketContent {
        //class名稱就是封包的CMD名稱
    }
    public class ENDGAME_TOCLIENT : SocketContent {
        //class名稱就是封包的CMD名稱
        public string Result { get; private set; }
        public string[] WinDBPlayerID { get; private set; }
        public PackPlayerResult[] PlayerResults { get; private set; }
        public ENDGAME_TOCLIENT(string _result, string[] _winDBPlayerID, PackPlayerResult[] _playerResults) {
            Result = _result;
            WinDBPlayerID = _winDBPlayerID;
            PlayerResults = _playerResults;
        }
    }
    public class PackPlayerResult {
        public string Result { get; private set; }
        public string WinDBPlayerID { get; private set; }
        public int GainGold { get; private set; }
        public int GainEXP { get; private set; }
        public string[] JsonBattleEffectIDs { get; private set; }
        public string[] JsonPerformanceEffectIDs { get; private set; }
    }
}