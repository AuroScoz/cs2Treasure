using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Realms;
using Realms.Sync;
using Scoz.Func;
using System.Threading.Tasks;
using System.Linq;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;
using System.Text;
using Gladiators.Socket;

namespace Service.Realms {
    public static partial class RealmManager {

        /// <summary>
        /// 匿名註冊
        /// </summary>
        public static async UniTask AnonymousSignup() {
            if (MyApp == null) { WriteLog.LogError("尚未建立Realm App"); return; }
            try {
                await MyApp.LogInAsync(Credentials.Anonymous());
            } catch (Exception _e) {
                WriteLog.LogError("在AnonymousSignup時MyApp.LogInAsync發生錯誤: " + _e);
            }
            await OnSignin();
        }

        /// <summary>
        /// 信箱密碼註冊
        /// </summary>
        /// <param name="_email">信箱</param>
        /// <param name="_pw">密碼</param>
        public static async void EmailPWSignup(string _email, string _pw) {
            if (MyApp == null) { WriteLog.LogError("尚未建立Realm App"); return; }
            await MyApp.LogInAsync(
               Credentials.EmailPassword(_email, _pw));
            await OnSignin();
        }
        /// <summary>
        /// 取得AccessToken
        /// </summary>
        public static async UniTask<string> GetValidAccessToken() {
            if (MyApp == null || MyApp.CurrentUser == null) { WriteLog.LogErrorFormat("尚未建立Realm App，無法取得AccessToken"); return null; }
            await MyApp.CurrentUser.RefreshCustomDataAsync();
            WriteLog.LogColor("AccessToken:" + MyApp.CurrentUser.AccessToken, WriteLog.LogType.Realm);
            return MyApp.CurrentUser.AccessToken;
        }

        /// <summary>
        /// 取得Provider
        /// </summary>
        public static async UniTask<string> GetProvider() {
            if (MyApp == null || MyApp.CurrentUser == null) { WriteLog.LogErrorFormat("尚未建立Realm App，無法取得AccessToken"); return null; }
            await MyApp.CurrentUser.RefreshCustomDataAsync();
            var provider = MyApp.CurrentUser.Provider;
            return provider.ToString();
        }

        /// <summary>
        /// 玩家登入後都會執行這裡(不管是剛註冊後還是已註冊的玩家登入)
        /// </summary>
        public static async UniTask OnSignin() {
            WriteLog.LogColorFormat("Realm帳號登入: {0}", WriteLog.LogType.Realm, MyApp.CurrentUser);
            try {
                RealmManager.InitDB();//初始化RealmDB
                await GetServerTime();

            } catch (Exception _e) {
                WriteLog.LogError(_e);
            }
            await SetupConfig();
        }



        /// <summary>
        /// 向AtlasFunction取Server時間
        /// </summary>
        static async UniTask GetServerTime() {
            var serverTimeData = await CallAtlasFunc(AtlasFunc.GetServerTime, null);
            if (serverTimeData.TryGetValue("serverTime", out object _obj)) {
                //WriteLog.LogColor(_obj.ToString(), WriteLog.LogType.Realm);
                try {
                    DateTimeOffset utcDateTimeOffset = DateTimeOffset.Parse(_obj.ToString());
                    //DateTimeOffset localDateTimeOffset = utcDateTimeOffset.ToOffset(TimeSpan.FromHours(8));
                    GameManager.Instance.SetTime(utcDateTimeOffset);
                } catch (Exception _e) {
                    WriteLog.LogError("GetServerTime發生錯誤: " + _e);
                }
            } else {
                WriteLog.LogError("GetServerTime發生錯誤: Atlas Function回傳格式錯誤");
            }
        }

        /// <summary>
        /// 設定FlexibleSyncConfg
        /// </summary>
        static async Task SetupConfig() {
            WriteLog.LogColorFormat("開始註冊Realm設定檔...", WriteLog.LogType.Realm);

            try {
                var config = new FlexibleSyncConfiguration(MyApp.CurrentUser) {
                    PopulateInitialSubscriptions = (realm) => {
                        //※常見的取不到資料錯誤排除方向
                        //1. DB沒資料或名稱定義錯誤
                        //2. collection rule沒設定對
                        //3. collection sechma沒設定對(schema只要有一個欄位本地跟Atlas不一致就會娶不到資料)
                        //4. 查看在Atlas中查看LOG有沒有錯誤

                        //Realm對LINQ有限制，有使用到LINQ可以參考官方文件: https://www.mongodb.com/docs/realm-sdks/dotnet/latest/linqsupport.html
                        //可以使用 string-based query syntax  可以參考官方文件: https://www.mongodb.com/docs/realm/realm-query-language/#collection-operators
                        //string-based query syntax 範例 var dbMatchgames  = realm.All<DBMatchgame>().Filter("ANY PlayerIDs == $0", myUserId);

                        //註冊Map資料
                        var dbMaps = realm.All<DBMap>();
                        realm.Subscriptions.Add(dbMaps, new SubscriptionOptions() { Name = "Map" });
                        //註冊玩家自己的player資料
                        var dbPlayer = realm.All<DBPlayer>().Where(i => i.ID == MyApp.CurrentUser.Id);
                        realm.Subscriptions.Add(dbPlayer, new SubscriptionOptions() { Name = "MyPlayer" });
                        //註冊玩家自己的playerState資料
                        var dbPlayerState = realm.All<DBPlayerState>().Where(i => i.ID == MyApp.CurrentUser.Id);
                        realm.Subscriptions.Add(dbPlayerState, new SubscriptionOptions() { Name = "MyPlayerState" });
                        //註冊GameSetting資料
                        var gameSettings = realm.All<DBGameSetting>();
                        realm.Subscriptions.Add(gameSettings, new SubscriptionOptions() { Name = "GameSetting" });

                    }
                };



                try {
                    var startSyncTime = DateTime.Now;
                    MyRealm = await Realm.GetInstanceAsync(config);
                    WriteLog.LogColorFormat("Realm設定檔註冊完成, 花費:{0}秒", WriteLog.LogType.Realm, (DateTime.Now - startSyncTime).TotalSeconds);
                } catch (Exception _e) {
                    WriteLog.LogError("Realm 使用config來GetInstanceAsync時發生錯誤: " + _e);
                    WriteLog.LogError("Realm設定檔註冊失敗");
                    return;
                }

            } catch (Exception _e) {
                WriteLog.LogError("Realm設定檔錯誤: " + _e);
            }
        }

        public static async UniTask Signout() {
            await MyApp.CurrentUser.LogOutAsync();
            WriteLog.LogColorFormat("登出Realm帳戶", WriteLog.LogType.Realm);
        }


    }
}