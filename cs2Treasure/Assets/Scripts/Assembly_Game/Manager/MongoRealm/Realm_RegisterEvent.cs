using Gladiators.Main;
using Gladiators.Socket;
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

        static Dictionary<string, IDisposable> Registers = new Dictionary<string, IDisposable>();

        /// <summary>
        /// 玩家資料已經取到後執行
        /// </summary>
        public static void OnDataLoaded() {
            try {
                GamePlayer.Instance.InitDBPlayerDocs();//初始化玩家DB資料
                GamePlayer.Instance.InitDBGameSettingDcos();//初始化遊戲設定DB資料
                RegisterRealmEvents();//註冊Realm事件    
                GameManager.Instance.AddComponent<GameTimer>().Init();//建立GameTimer
            } catch (Exception _e) {
                WriteLog.LogError(_e);
            }
        }

        /// <summary>
        /// 註冊Realm事件
        /// </summary>
        static void RegisterRealmEvents() {
            RegisterConnectionStateChanges();
            RegisterPropertyChanges();
        }
        /// <summary>
        /// 取消註冊所有Realm事件
        /// </summary>
        static void UnregisterAllRealmEvents() {
            WriteLog.LogColor("取消註冊RealmEvent", WriteLog.LogType.Realm);
            foreach (var i in Registers.Values) {
                i.Dispose();
            }
            Registers.Clear();
        }

        /// <summary>
        /// 註冊Realm連線狀態通知
        /// </summary>
        public static void RegisterConnectionStateChanges() {
            WriteLog.LogColor("註冊Realm連線狀態變化通知", WriteLog.LogType.Realm);
            try {
                var session = MyRealm.SyncSession;
                session.PropertyChanged += (sender, e) => {
                    if (e.PropertyName == nameof(Session.ConnectionState)) {
                        var session = (Session)sender;
                        var state = session.ConnectionState;
                        switch (state) {
                            case ConnectionState.Connecting://連線Realm中
                                WriteLog.LogColor("連線Realm中....", WriteLog.LogType.Realm);
                                break;
                            case ConnectionState.Connected://連上Realm
                                WriteLog.LogColor("已連上Realm", WriteLog.LogType.Realm);
                                break;
                            case ConnectionState.Disconnected://與Realm斷線
                                WriteLog.LogColor("與Realm斷線", WriteLog.LogType.Realm);
                                break;
                            default:
                                // 不應該出現其他狀態
                                WriteLog.LogColorFormat("RegisterConnectionStateChanges接收到未定義的連線狀態: {0}", WriteLog.LogType.Realm, state);
                                break;
                        }
                    }
                };
            } catch (Exception _e) {
                Console.WriteLine(_e.Message);
            }
        }
        /// <summary>
        /// 註冊Realm文件異動通知
        /// </summary>
        public static void RegisterPropertyChanges() {
            WriteLog.LogColor("註冊MongoDB異動事件", WriteLog.LogType.Realm);
            RegisterPropertyChanges_MyPlayer();
            RegisterPropertyChanges_GameSetting();
            RegisterPropertyChanges_Map();
            DeviceManager.AddOnApplicationQuitAction(UnregisterAllRealmEvents);
        }

        /// <summary>
        /// 註冊玩家文件通知
        /// </summary>
        static void RegisterPropertyChanges_MyPlayer() {
            //玩家資料
            var player = GamePlayer.Instance.GetDBPlayerDoc<DBPlayer>();
            if (player != null) {
                player.PropertyChanged += (sender, e) => {
                    var propertyName = e.PropertyName;
                    var propertyValue = player.GetType().GetProperty(propertyName).GetValue(player);
                    GameStateManager.Instance.InGameCheckCanPlayGame();
                    WriteLog.LogColorFormat("{0}表 Changed field: {0}  Value: {1}", WriteLog.LogType.Realm, "player", propertyName, propertyValue);
                };
            }

        }

        /// <summary>
        /// 註冊遊戲設定通知
        /// </summary>
        static void RegisterPropertyChanges_GameSetting() {
            var gameState = GamePlayer.Instance.GetDBGameSettingDoc(DBGameSettingDoc.GameState);
            if (gameState != null) {
                gameState.PropertyChanged += (sender, e) => {
                    var propertyName = e.PropertyName;
                    var propertyValue = gameState.GetType().GetProperty(propertyName).GetValue(gameState);
                    WriteLog.LogColorFormat("{0}表 Changed field: {0}  Value: {1}", WriteLog.LogType.Realm, "GameState", propertyName, propertyValue);
                };
            }
        }

        /// <summary>
        /// 註冊Matchgame資料異動通知
        /// </summary>
        //static void RegisterPropertyChanges_Matchgame() {
        //    var dbMatchgames = MyRealm.All<DBMatchgame>();
        //    var token_dbMatchgames = dbMatchgames.SubscribeForNotifications((sender, changes) => {
        //        //※官方提到要按刪除->插入->修改的順序處理文件避免意外的錯誤發生
        //        //第一次註冊通知事件時觸發
        //        if (changes == null) {
        //            return;
        //        }
        //        var dbPlayer = GamePlayer.Instance.GetDBPlayerDoc<DBPlayer>(DBPlayerCol.player);
        //        if (dbPlayer == null) return;

        //        //刪除
        //        foreach (var i in changes.DeletedIndices) {
        //        }
        //        //插入
        //        foreach (var i in changes.InsertedIndices) {
        //            DBMatchgame insertedDoc = dbMatchgames.ElementAt(i);
        //            WriteLog.LogError("插入doc: " + insertedDoc.ID);
        //        }

        //        //修改
        //        foreach (var i in changes.NewModifiedIndices) {
        //            DBMatchgame modifiedDoc = dbMatchgames.ElementAt(i);
        //            WriteLog.LogError("修改doc: " + modifiedDoc.ID);
        //        }

        //        //Collection清空(對Collection下Clear()指令時)
        //        if (changes.IsCleared) {
        //        }

        //    });
        //    Registers.Add("DBMatchgame", token_dbMatchgames);
        //}

        /// <summary>
        /// 註冊Map資料異動通知
        /// </summary>
        static void RegisterPropertyChanges_Map() {
            var dbMaps = MyRealm.All<DBMap>();
            var token_dbMaps = dbMaps.SubscribeForNotifications((sender, changes) => {
                //※官方提到要按刪除->插入->修改的順序處理文件避免意外的錯誤發生

                //第一次註冊通知事件時觸發
                if (changes == null) {
                    return;
                }

                //var mapUI = MapUI.GetInstance<MapUI>();
                //if (mapUI != null && mapUI.gameObject.activeInHierarchy) mapUI.SpawnItems();

            });
            Registers.Add("DBMap", token_dbMaps);
        }

    }
}
