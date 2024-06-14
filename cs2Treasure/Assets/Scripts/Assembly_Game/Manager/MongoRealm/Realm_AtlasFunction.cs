using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using LitJson;
using Realms;
using Scoz.Func;

namespace Service.Realms {
    public static partial class RealmManager {
        enum ReplyKey {
            Data,//回傳資料放這裡
            Error,//有Error文字會放這裡, 沒有就會是null
        }
        public enum AtlasFunc {
            InitPlayerData,//註冊玩家資料
            GetServerTime,//取Server時間
            UpdateOnlineTime,//更新在線時間
            Signin,//登入
            PlayerVerify,//測試
        }

        static Dictionary<string, object> HandleReplyData(string _replyJson) {
            try {
                var jsonObj = JsonMapper.ToObject(_replyJson.UnwrapQuotedJson());
                if (jsonObj == null) {
                    WriteLog.LogError("AtlasFunc回傳json無法轉為jsonObj: " + _replyJson);
                    return null;
                }
                var iDic = jsonObj as IDictionary;
                if (iDic == null) {
                    WriteLog.LogError("AtlasFunc回傳jsonObj無法轉為IDictionary類型: " + _replyJson);
                    return null;
                }
                if (!iDic.TryGetValue(ReplyKey.Error.ToString(), out object error)) {
                    WriteLog.LogError("AtlasFunc回傳的資料缺少欄位: " + ReplyKey.Error);
                    return null;
                }
                if (error != null) {
                    WriteLog.LogError("AtlasFunc錯誤: " + error);
                    return null;
                }
                if (!iDic.TryGetValue(ReplyKey.Data.ToString(), out object replyData)) {
                    WriteLog.LogError("AtlasFunc回傳的資料缺少欄位: " + ReplyKey.Error);
                    return null;
                }
                var dic = DicExtension.ConvertToStringKeyDic(replyData);
                return dic;
            } catch (Exception _e) {
                WriteLog.LogError("AtlasFunc回傳的資料解析發生錯誤: " + _e);
                return null;
            }
        }



        /// <summary>
        /// 呼叫MonsgoDB Atlas 傳入方法名稱與參數 
        /// </summary>
        /// <param name="_func">方法名稱</param>
        /// <param name="_params">傳入參數字典</param>
        /// <returns>回傳結果字典</returns>
        public static async Task<Dictionary<string, object>> CallAtlasFunc(AtlasFunc _func, Dictionary<string, object> _data) {
            string jsonResult = null;
            if (_data == null) jsonResult = await MyApp.CurrentUser.Functions.CallAsync<string>(_func.ToString());
            else jsonResult = await MyApp.CurrentUser.Functions.CallAsync<string>(_func.ToString(), _data);
            try {
                //WriteLog.LogColorFormat("jsonResult: {0}", WriteLog.LogType.Realm, jsonResult);
                var dataDic = HandleReplyData(jsonResult);
                //dataDic.Log();
                return dataDic;
            } catch (Exception _e) {
                WriteLog.LogError("CallAtlasFunc回傳發生錯誤: " + _e);
                return null;
            }
        }
        /// <summary>
        /// 呼叫MonsgoDB Atlas，且不在乎回傳結果，傳入方法名稱與參數 
        /// </summary>
        /// <param name="_func">方法名稱</param>
        /// <param name="_data">傳入參數字典</param>
        public static void CallAtlasFuncNoneAsync(AtlasFunc _func, Dictionary<string, object> _data) {
            UniTask.Void(async () => {
                try {
                    await CallAtlasFunc(_func, _data);
                } catch (Exception _e) {
                    WriteLog.LogError(_e);
                }
            });
        }


        /// <summary>
        /// 註冊帳戶，傳入AuthType
        /// </summary>
        public static async UniTask<Dictionary<string, object>> CallAtlasFunc_InitPlayerData(AuthType _authType) {
            try {
                var dataDic = new Dictionary<string, object> { { "AuthType", _authType.ToString() } };
                var replyData = await CallAtlasFunc(AtlasFunc.InitPlayerData, dataDic).AsUniTask();
                if (replyData == null) {
                    WriteLog.LogErrorFormat("CallAtlasFunc_InitPlayerData發生錯誤");
                    return null;
                }

                var utcs = new UniTaskCompletionSource();
                using var token = MyRealm.All<DBPlayer>().Where(i => i.ID == MyApp.CurrentUser.Id).SubscribeForNotifications((sender, e) => {
                    if (sender.Count > 0) {
                        utcs.TrySetResult();
                    }
                });

                await utcs.Task;
                return replyData;

            } catch (Exception _e) {
                WriteLog.LogErrorFormat("CallAtlasFunc_InitPlayerData發生錯誤：{0}", _e);
                return null;
            }
        }

    }
}