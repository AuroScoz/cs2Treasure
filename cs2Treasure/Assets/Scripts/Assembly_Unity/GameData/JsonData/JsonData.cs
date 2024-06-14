using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;
using System.Linq;
using System.Reflection;


namespace Scoz.Func {
    /// <summary>
    /// 這是Excel輸出的Json資料父類別，繼承自這個類的都是Excel表輸出的資料
    /// </summary>
    public abstract partial class MyJsonData_UnityAssembly {
        public static bool ShowLoadTime = true;
        public int ID { get; set; }

        /// <summary>
        /// 依json表設定資料(Key為String)
        /// </summary>
        public static Dictionary<string, MyJsonData_UnityAssembly> SetDataStringKey<T>() where T : MyJsonData_UnityAssembly, new() {
            string dataName = typeof(T).Name.Replace("JsonData_UnityAssembly", "");
            string jsonStr = Resources.Load<TextAsset>(string.Format("Jsons/{0}", dataName)).ToString();
            JsonData jd = null;
            try {
                jd = JsonMapper.ToObject(jsonStr);
            } catch (Exception _e) {
                WriteLog_UnityAssembly.LogErrorFormat("{0}表的json格式錯誤: {1}", dataName, _e);
            }
            JsonData items = jd[dataName];
            Dictionary<string, MyJsonData_UnityAssembly> dic = new Dictionary<string, MyJsonData_UnityAssembly>();
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
                data.SetDataFromJson(items[i]);
                string id = items[i]["ID"].ToString();
                if (!dic.ContainsKey(id))
                    dic.Add(id, data);
                else
                    WriteLog_UnityAssembly.LogError(string.Format("{0}表有重複的ID {1}", dataName, id));
            }
            return dic;
        }


        /// <summary>
        /// 依json表設定資料，不建立字典
        /// </summary>
        public static void SetData<T>() where T : MyJsonData_UnityAssembly, new() {
            string dataName = typeof(T).Name.Replace("JsonData_UnityAssembly", "");
            DateTime startTime = DateTime.Now;
            string jsonStr = Resources.Load<TextAsset>(string.Format("Jsons/{0}", dataName)).ToString();
            JsonData jd = JsonMapper.ToObject(jsonStr);
            JsonData items = jd[dataName];
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
                data.SetDataFromJson(items[i]);
            }
            DateTime endTime = DateTime.Now;
            if (ShowLoadTime) {
                TimeSpan spendTime = new TimeSpan(endTime.Ticks - startTime.Ticks);
                WriteLog_UnityAssembly.LogFormat("<color=#008080>Load {0}.json:{1}s</color>", dataName, spendTime.TotalSeconds);
            }
        }

        protected abstract void SetDataFromJson(JsonData _item);
    }
}
