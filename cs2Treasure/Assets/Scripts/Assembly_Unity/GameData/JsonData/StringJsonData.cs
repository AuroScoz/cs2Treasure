using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using Gladiators.Main;

namespace Scoz.Func {
    public class StringJsonData_UnityAssembly {
        public static bool ShowLoadTime = true;
        public string ID { get; private set; }
        public Dictionary<Language, Dictionary<string, string>> StringDic = new Dictionary<Language, Dictionary<string, string>>();
        public string StringType { get; protected set; }

        public StringJsonData_UnityAssembly(JsonData _item, string _stringType) {
            try {
                JsonData item = _item;
                StringType = _stringType;
                foreach (string key in item.Keys) {
                    if (key != "ID") {
                        Language language = Language.EN;
                        switch (key.Substring(key.Length - 3)) {
                            case "_TW":
                                language = Language.TW;
                                break;
                            case "_CH":
                                language = Language.CH;
                                break;
                            case "_EN":
                                language = Language.EN;
                                break;
                            case "_JP":
                                language = Language.JP;
                                break;
                            default:
                                WriteLog_UnityAssembly.LogWarning(string.Format("{0}表有不明屬性:{1}", StringType, key));
                                break;
                        }
                        if (!StringDic.ContainsKey(language))
                            StringDic.Add(language, new Dictionary<string, string>() { { key.Substring(0, key.Length - 3), item[key].ToString() } });
                        else
                            StringDic[language].Add(key.Substring(0, key.Length - 3), item[key].ToString());
                    } else {
                        ID = item[key].ToString();
                    }
                }
            } catch (Exception ex) {
                WriteLog_UnityAssembly.LogException(ex);
            }
        }

        /// <summary>
        /// 傳入String表名稱，並依string表資料回傳字典
        /// </summary>
        public static Dictionary<string, StringJsonData_UnityAssembly> SetStringDic() {
            string dataName = "String";
            DateTime startTime = DateTime.Now;
            string jsonStr = Resources.Load<TextAsset>(string.Format("Jsons/{0}", dataName)).ToString();
            JsonData jd = JsonMapper.ToObject(jsonStr);
            JsonData items = jd[dataName];
            Dictionary<string, StringJsonData_UnityAssembly> dic = new Dictionary<string, StringJsonData_UnityAssembly>();
            for (int i = 0; i < items.Count; i++) {
                StringJsonData_UnityAssembly data = new StringJsonData_UnityAssembly(items[i], dataName);
                string name = items[i]["ID"].ToString();
                if (dic.ContainsKey(name)) {
                    WriteLog_UnityAssembly.LogError(string.Format("{0}的名稱{1}已重複", dataName, name));
                    break;
                }
                dic.Add(name, data);
            }
            DateTime endTime = DateTime.Now;
            if (ShowLoadTime) {
                TimeSpan spendTime = new TimeSpan(endTime.Ticks - startTime.Ticks);
                WriteLog_UnityAssembly.LogColorFormat("讀取本機 {0}.json  讀取時間:{1}s", WriteLog_UnityAssembly.LogType.Json, dataName, spendTime.TotalSeconds);
            }
            return dic;
        }

        public static T GetValue<T>(String value) {
            return (T)Convert.ChangeType(value, typeof(T));
        }
        public string GetString(string _column, Language _language) {
            if (!StringDic.ContainsKey(_language)) {
                WriteLog_UnityAssembly.LogError("無此語系文字:" + _language);
                return "Undifined";
            }
            return GetString(_column);
        }
        public string GetString(string _column) {
            if (StringDic.Count == 0)
                return "";
            if (!StringDic[Language.CH].ContainsKey(_column)) {
                WriteLog_UnityAssembly.LogError("無此欄位名稱:" + _column);
                return "Undifined";
            }
            return StringDic[Language.CH][_column];
        }
        public static string GetString_static(string _id, string _column) {
            if (GameDictionary_UnityAssembly.StringDic.Count == 0)
                return "";
            if (GameDictionary_UnityAssembly.StringDic.ContainsKey(_id))
                return GameDictionary_UnityAssembly.StringDic[_id].GetString(_column);
            else {
                WriteLog_UnityAssembly.LogError("不存在的文字字典索引:" + _id);
                return "Undifined";
            }
        }

        /// <summary>
        /// 傳入String表UI頁籤的key值，取得目前語系版本的文字
        /// </summary>
        public static string GetUIString(string _id) {
            _id = "UI_" + _id;
            return GetString_static(_id, Language.CH.ToString());
        }

        /// <summary>
        /// 傳入品階，取得品階文字
        /// </summary>
        public static string GetRankStr(int _rank) {
            string rankStr = GetUIString("Rank" + _rank);
            if (string.IsNullOrEmpty(rankStr))
                return "UnRanked";
            return rankStr;
        }

    }
}