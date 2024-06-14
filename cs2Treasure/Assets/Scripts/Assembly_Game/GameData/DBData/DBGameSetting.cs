using System;
using System.Collections.Generic;
using Realms;
using MongoDB.Bson;

[MapTo("gameSetting")]
public partial class DBGameSetting : IRealmObject {
    [Required]
    [MapTo("_id")]
    [PrimaryKey]
    public string ID { get; set; }
    [MapTo("createdAt")]
    public DateTimeOffset CreatedAt { get; set; }

    #region timer(各計時器的時間設定)
    [MapTo("onlineCheckSec")]
    public int? OnlineCheckSec { get; set; }
    #endregion

    #region address(各網址設定)
    [MapTo("storeURL_Apple")]
    public string StoreURL_Apple { get; set; }
    [MapTo("storeURL_Google")]
    public string StoreURL_Google { get; set; }
    [MapTo("customerServiceURL")]
    public string CustomerServiceURL { get; set; }
    #endregion


    #region gameState(目前遊戲狀態的資料)
    [MapTo("env")]
    public string Env { get; set; }
    [MapTo("gameVersion")]
    public string GameVersion { get; set; }
    [MapTo("maintain")]
    public bool? Maintain { get; set; }
    [MapTo("maintainEndAt")]
    public DateTimeOffset? MaintainEndAt { get; set; }
    [Required]
    [MapTo("maintainExemptPlayerIDs")]
    public IList<string> MaintainExemptPlayerIDs { get; }
    [MapTo("minGameVersion")]
    public string MinGameVersion { get; set; }
    [MapTo("matchmakerEnable")]
    public bool? MatchmakerEnable { get; set; }
    [MapTo("matchmakerIP")]
    public string MatchmakerIP { get; set; }
    [MapTo("matchmakerPort")]
    public int? MatchmakerPort { get; set; }
    [MapTo("matchgame-testver-roomName")]
    public string MatchgameTestverRoomName { get; set; }
    [MapTo("matchgame-testver-mapID")]
    public string MatchgameTestverMapID { get; set; }
    [MapTo("matchgame-testver-tcp-ip")]
    public string MatchgameTestverTcpIP { get; set; }
    [MapTo("matchgame-testver-udp-ip")]
    public string MatchgameTestverUdpIP { get; set; }
    [MapTo("matchgame-testver-port")]
    public int? MatchgameTestverPort { get; set; }
    #endregion


}