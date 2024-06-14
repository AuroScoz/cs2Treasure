using System;
using Cysharp.Threading.Tasks;
using MongoDB.Bson;
using Scoz.Func;

namespace Service.Realms {
    public static partial class RealmManager {
        public static async UniTask<BsonDocument> Query_GetDoc(string _dbCol, string _id) {
            var col = MyDB.GetCollection<BsonDocument>(_dbCol);
            try {
                var doc = await col.FindOneAsync(new BsonDocument { { "_id", _id } });
                return doc;
            } catch (Exception _e) {
                WriteLog.LogError("Query_GetDoc錯誤:" + _e);
                return null;
            }
        }
    }
}