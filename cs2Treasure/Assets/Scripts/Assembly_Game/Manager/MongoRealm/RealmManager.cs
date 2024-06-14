using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Realms;
using Realms.Sync;
using Scoz.Func;
using System;
using MongoDB.Bson;

namespace Service.Realms {

    /// <summary>
    /// DB玩家資料集合
    /// </summary>
    public enum DBPlayerCol {
        DBPlayer,
        DBPlayerHistory,
        DBPlayerState,
    }

    /// <summary>
    /// DB遊戲資料集合
    /// </summary>
    public enum DBGameCol {
        matchgame,
    }
    /// <summary>
    ///  DB遊戲設定DOC名稱
    /// </summary>
    public enum DBGameSettingDoc {
        Timer,
        Address,
        GameSetting,
        GameState,
        GameConfig,
    }
    public static partial class RealmManager {
        public
        //環境版本對應Realm App ID
        static Dictionary<EnvVersion, string> REALM_APPID_DIC = new Dictionary<EnvVersion, string>() {
            { EnvVersion.Dev, "gladiators-pirlo"},
            { EnvVersion.Test, "gladiators-pirlo"},
            { EnvVersion.Release, "gladiators-pirlo"},
        };
        public static string DBName { get; private set; } = "gladiators";
        public static App MyApp { get; private set; }
        public static Realm MyRealm { get; private set; }
        public static MongoClient MyClient { get; private set; }
        public static MongoClient.Database MyDB { get; private set; }


        public static void ClearApp() {
            try {
                WriteLog.LogColor("ClearApp", WriteLog.LogType.Realm);
                if (MyRealm != null) {
                    MyRealm.Dispose();
                    MyRealm = null;
                }
                if (MyApp != null) MyApp = null;
            } catch (Exception _e) {
                WriteLog.LogErrorFormat("ClearApp發生錯誤: ", _e);
            }

        }
        /// <summary>
        /// 最初Realm初始化要先New一個Ream App
        /// </summary>
        public static App NewApp() {
            try {
                ClearApp();//在NewApp前先Clear，在Unity非Runtime中登出後，Runtime中登入時不Clear會有機率報錯誤(Cannot access a disposed object)
                WriteLog.LogColorFormat("NewApp AppID:{0}", WriteLog.LogType.Realm, REALM_APPID_DIC[GameManager.CurVersion]);
                MyApp = App.Create(REALM_APPID_DIC[GameManager.CurVersion]); // 創建 Realm App
                DeviceManager.AddOnApplicationQuitAction(() => { ClearApp(); });
                return MyApp;
            } catch (Exception _e) {
                WriteLog.LogErrorFormat("ClearApp發生錯誤: ", _e);
                return null;
            }
        }
        /// <summary>
        /// 初始化DB後才能直接對DB下Query
        /// </summary>
        public static void InitDB() {
            MyClient = MyApp.CurrentUser.GetMongoClient("mongodb-atlas");
            MyDB = MyClient.GetDatabase(DBName);
        }


    }
}
