namespace Gladiators.Socket.Matchgame {
    public class PLAYERACTION : SocketContent {
        //class名稱就是封包的CMD名稱
        public string ActionType { get; private set; }
        public IActionContent ActionContent { get; private set; }
        public PLAYERACTION(string _actionType, IActionContent _actionContent) {
            ActionType = _actionType;
            ActionContent = _actionContent;
        }
    }
    public interface IActionContent { }
    public class PLAYERACTION_TOCLIENT : SocketContent {
        //class名稱就是封包的CMD名稱
        public string ActionType { get; private set; }
        public object ActionContent { get; private set; }
    }
    public class PackAction_Skill : IActionContent {
        public bool On { get; private set; }
        public int SkillIdx { get; private set; }
    }
    public class PackAction_BribeSkill : IActionContent {
        public bool On { get; private set; }
        public int BribeSkillIdx { get; private set; }
    }
    public class PackAction_Rush : IActionContent {
        public bool On { get; private set; }
    }
    public class PackAction_Surrender : IActionContent {
    }
}