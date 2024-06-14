using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;
using System.Linq;
using UnityEngine.AddressableAssets;
using Gladiators.Main;
using System.Reflection;

namespace Scoz.Func {
    /// <summary>
    /// 這是Excel輸出的Json資料父類別，繼承自這個類的都是Excel表輸出的資料
    /// </summary>
    public abstract partial class JsonBase {

        /// <summary>
        /// 重置靜態資料，當Addressable重載json資料時需要先呼叫這個方法來重置靜態資料
        /// </summary>
        protected abstract void ResetStaticData();

        /// <summary>
        /// 依json表設定資料(Key為int)
        /// </summary>
        public static void SetData_Remote<T>(Action<string, Dictionary<int, JsonBase>> _cb) where T : JsonBase, new() {
            // 繼承自MyJsonData的類的屬性DataName都是該類名稱去掉"JsonData", 例如RoleJsonData類的DataName就是"Role"
            string dataName = typeof(T).Name.Replace("Json", "");
            GameDictionary.AddLoadingKey(dataName);
            try {
                Addressables.LoadAssetAsync<TextAsset>(string.Format("Assets/AddressableAssets/Jsons/{0}.json", dataName)).Completed += handle => {
                    string jsonStr = handle.Result.text;
                    JsonData jd = JsonMapper.ToObject(jsonStr);
                    JsonData items = jd[dataName];
                    Dictionary<int, JsonBase> dic = new Dictionary<int, JsonBase>();
                    for (int i = 0; i < items.Count; i++) {

                        // 使用反射查找T類的靜態屬性"DataName"並設定值
                        Type type = typeof(T);
                        PropertyInfo dataNameProp = type.GetProperty("DataName", BindingFlags.Public | BindingFlags.Static);
                        if (dataNameProp != null && dataNameProp.CanWrite) {
                            dataNameProp.SetValue(null, dataName);
                        } else {
                            Console.WriteLine("未找到DataName屬性或該屬性不可寫。");
                        }


                        T data = new T();
                        if (i == 0) data.ResetStaticData();//在取第一筆資料前先重置靜態資料
                        data.SetDataFromJson(items[i]);
                        int id = 0;
                        if (!int.TryParse(items[i]["ID"].ToString(), out id)) {
                            WriteLog.LogErrorFormat("Wrong ID Format DataName:{0}.json ID:{1} 也許使用SetDataStringKey_Remote而不是SetData_Remote", dataName, items[i]["ID"].ToString());
                            continue;
                        }
                        if (!dic.ContainsKey(id))
                            dic.Add(id, data);
                        else
                            WriteLog.LogError(string.Format("{0}表有重複的ID {1}", dataName, id));
                    }
                    Addressables.Release(handle);
                    if (ShowLoadTime) {
                        WriteLog.LogColorFormat("{0}.json載入完成", WriteLog.LogType.Json, dataName);
                    }
                    _cb?.Invoke(dataName, dic);
                };
            } catch {
                WriteLog.LogErrorFormat("載入{0}.json時發生錯誤", dataName);
            }
        }
        /// <summary>
        /// 依json表設定資料(Key為String)
        /// </summary>
        public static void SetDataStringKey_Remote<T>(Action<string, Dictionary<string, JsonBase>> _cb) where T : JsonBase, new() {
            // 繼承自MyJsonData的類的屬性DataName都是該類名稱去掉"JsonData", 例如RoleJsonData類的DataName就是"Role"
            string dataName = typeof(T).Name.Replace("Json", "");
            GameDictionary.AddLoadingKey(dataName);
            try {
                Addressables.LoadAssetAsync<TextAsset>(string.Format("Assets/AddressableAssets/Jsons/{0}.json", dataName)).Completed += handle => {
                    string jsonStr = handle.Result.text;
                    JsonData jd = JsonMapper.ToObject(jsonStr);
                    JsonData items = jd[dataName];
                    Dictionary<string, JsonBase> dic = new Dictionary<string, JsonBase>();
                    for (int i = 0; i < items.Count; i++) {

                        // 使用反射查找T類的靜態屬性"DataName"並設定值
                        Type type = typeof(T);
                        PropertyInfo dataNameProp = type.GetProperty("DataName", BindingFlags.Public | BindingFlags.Static);
                        if (dataNameProp != null && dataNameProp.CanWrite) {
                            dataNameProp.SetValue(null, dataName);
                        } else {
                            Console.WriteLine("未找到DataName屬性或該屬性不可寫。");
                        }

                        T data = new T();
                        if (i == 0) data.ResetStaticData();//在取第一筆資料前先重置靜態資料
                        data.SetDataFromJson(items[i]);
                        string id = items[i]["ID"].ToString();
                        if (!dic.ContainsKey(id))
                            dic.Add(id, data);
                        else
                            WriteLog.LogError(string.Format("{0}表有重複的ID {1}", dataName, id));

                    }
                    Addressables.Release(handle);
                    if (ShowLoadTime) {
                        WriteLog.LogColorFormat("{0}.json載入完成", WriteLog.LogType.Json, dataName);
                    }
                    _cb?.Invoke(dataName, dic);

                };
            } catch {
                WriteLog.LogErrorFormat("載入{0}.json時發生錯誤", dataName);
            }

        }
    }
}
