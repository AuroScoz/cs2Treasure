using System;
using System.Collections.Generic;
using Realms;
using MongoDB.Bson;
using Service.Realms;
using Scoz.Func;

/// <summary>
/// DBMatchgame也是DB的Doc但是不透過RealmSync來讀寫所以不繼承IRealmObject
/// ※如果繼承IRealmObject就要保有一個空的建構式, Realm需要這個空的構造函數來創建和管理Realm物件的實例
/// 另外, 自定義的建構式是用來初始化那些不受Realm管理的欄位屬性(被標記為Ignored的屬性), 不能直接修改Realm管理的屬性(只能透過Realm的讀寫API來修改)
/// </summary>
public partial class DBMatchgame {
    public string ID { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public string DBMapID { get; private set; }
    public IList<string> PlayerIDs { get; }
    public string IP { get; private set; }
    public int? Port { get; set; }

    public DBMatchgame(BsonDocument _doc) {
        try {
            ID = _doc["_id"].AsString;
            CreatedAt = _doc["createdAt"].ToUniversalTime();
            DBMapID = _doc["dbMapID"].AsString;
            IP = _doc["ip"].AsString;
            Port = _doc["port"].AsInt32;
            PlayerIDs = ExtractPlayerIDs(_doc["playerIDs"]);
        } catch (Exception _e) {
            WriteLog.LogError("轉BsonDocument錯誤: " + _e);
        }
    }
    private static IList<string> ExtractPlayerIDs(BsonValue _bson) {
        var list = new List<string>();
        if (_bson is BsonArray bsonArray) {
            foreach (var item in bsonArray) {
                list.Add(item.AsString);
            }
        }
        return list;
    }

}