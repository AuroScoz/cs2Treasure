using System;
using System.Collections.Generic;
using Realms;
using MongoDB.Bson;
using Service.Realms;
using Cysharp.Threading.Tasks;

[MapTo("player")]
public partial class DBPlayer : IRealmObject {
    [MapTo("_id")]
    [PrimaryKey]
    [Required]
    public string ID { get; private set; }
    [MapTo("createdAt")]
    public DateTimeOffset CreatedAt { get; private set; }
    [MapTo("authType")]
    public string AuthType { get; private set; }
    [MapTo("ban")]
    public bool? Ban { get; private set; }
    [MapTo("deviceUID")]
    public string DeviceUID { get; private set; }
    [MapTo("lastSigninAt")]
    public DateTimeOffset? LastSigninAt { get; private set; }
    [MapTo("lastSignoutAt")]
    public DateTimeOffset? LastSignoutAt { get; private set; }
    [MapTo("onlineState")]
    public string OnlineState { get; private set; }
    [MapTo("gold")]
    public long? Gold { get; private set; }
    [MapTo("point")]
    public long? Point { get; private set; }
    [MapTo("inMatchgameID")]
    public string InMatchgameID { get; private set; }

    public void SetDeviceUID(string _deviceUID) {
        RealmManager.MyRealm.WriteAsync(() => {
            DeviceUID = _deviceUID;
        });
    }
    /// <summary>
    /// 呼叫時機為: 1.收到Matchmaker建立/加入房間成功後呼叫 2. 離開遊戲房時傳入(null)將玩家所在Matchgame(遊戲房)清掉
    /// 建立/加入房間時會設定所在Matchgame(遊戲房)的ID並訂閱DBMatchgame資料，若Server房間創好後會收到通知讓玩家主動scoket到Matchgame Server
    /// </summary>
    public async UniTask SetInMatchgameID(string _matchgameID) {
        await RealmManager.MyRealm.WriteAsync(() => {
            InMatchgameID = _matchgameID;
        });
    }


}