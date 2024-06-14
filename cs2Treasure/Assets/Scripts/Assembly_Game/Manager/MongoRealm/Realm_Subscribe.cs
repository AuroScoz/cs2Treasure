using Cysharp.Threading.Tasks;
using Gladiators.Main;
using Realms;
using Realms.Sync;
using Scoz.Func;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Service.Realms {

    public static partial class RealmManager {
        /// <summary>
        /// 訂閱Matchgame(遊戲房)資料庫
        /// </summary>
        //public static async UniTask Subscribe_Matchgame() {
        //    var dbPlayer = GamePlayer.Instance.GetDBPlayerDoc<DBPlayer>(DBPlayerCol.player);
        //    if (dbPlayer == null) return;
        //    WriteLog.LogColorFormat("訂閱Matchgame資料 ID:{0}", WriteLog.LogType.Realm, dbPlayer.InMatchgameID);
        //    var query = MyRealm.All<DBMatchgame>().Where(i => i.ID == dbPlayer.InMatchgameID);
        //    await query.SubscribeAsync(new SubscriptionOptions() { Name = "MyMatchgame" });
        //}
        //public static void Unsubscribe_Matchgame() {
        //    MyRealm.Subscriptions.Update(() => {
        //        MyRealm.Subscriptions.Remove("MyMatchgame");
        //    });
        //}
    }
}
