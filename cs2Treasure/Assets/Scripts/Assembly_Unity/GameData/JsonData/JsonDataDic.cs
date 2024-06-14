using UnityEngine;
using System.Collections.Generic;
using System;
using Gladiators.Main;
using System.Linq;
using System.Reflection;

namespace Scoz.Func {

    public partial class GameDictionary_UnityAssembly : MonoBehaviour {



        //字典
        public static Dictionary<string, Dictionary<int, MyJsonData_UnityAssembly>> IntKeyJsonDic = new Dictionary<string, Dictionary<int, MyJsonData_UnityAssembly>>();
        public static Dictionary<string, Dictionary<string, MyJsonData_UnityAssembly>> StrKeyJsonDic = new Dictionary<string, Dictionary<string, MyJsonData_UnityAssembly>>();


        //String
        public static Dictionary<string, StringJsonData_UnityAssembly> StringDic = new Dictionary<string, StringJsonData_UnityAssembly>();
        static LoadingProgress_UnityAssembly MyLoadingProgress;//載入JsonData進度
        public static bool IsFinishLoadAddressableJson {
            get {
                if (MyLoadingProgress == null) return false;
                return MyLoadingProgress.IsFinished;
            }
        }

        ///// <summary>
        ///// 將Json資料寫入字典裡
        ///// </summary>
        public static void LoadJsonDataToDic(Action _action) {
            //初始化讀取進度並設定讀取完要執行的程式
            MyLoadingProgress = new LoadingProgress_UnityAssembly(() => {
                _action?.Invoke();
            });

            //設定X秒會顯示尚未載入的JsonData
            CoroutineJob_UnityAssembly.Instance.StartNewAction(ShowUnLoadedJsondata, 5);

        }
        /// <summary>
        /// 將要載入的json加到進度中，等全部json都載完才會透過MyLoadingProgress回傳LoadJsonDataToDic傳入的Action
        /// </summary>
        public static void AddLoadingKey(string _key) {
            MyLoadingProgress.AddLoadingProgress(_key);
        }
        /// <summary>
        /// 開始載json後過3秒會顯示尚未載入的JsonData
        /// </summary>
        static void ShowUnLoadedJsondata() {
            List<string> notFinishedKeys = MyLoadingProgress.GetNotFinishedKeys();
            for (int i = 0; i < notFinishedKeys.Count; i++)
                WriteLog_UnityAssembly.LogErrorFormat("{0}Json尚未載入", notFinishedKeys[i]);
        }
        /// <summary>
        /// 取得T類型的JsonData Dic
        /// </summary>
        public static Dictionary<int, T> GetIntKeyJsonDic<T>() where T : MyJsonData_UnityAssembly {
            string dataName = GetDataName<T>();
            if (IntKeyJsonDic.ContainsKey(dataName)) {
                return IntKeyJsonDic[dataName].ToDictionary(a => a.Key, a => a.Value as T);
            } else {
                string log = string.Format("{0}表不存IntKeyJsonDic中", dataName);
                PopupUI_Local.ShowClickCancel(log, "",null);
                WriteLog_UnityAssembly.LogErrorFormat(log);
                return null;
            }
        }
        static string GetDataName<T>() {
            // 獲得T類型的Type對象
            Type type = typeof(T);
            // 使用反射查找名為"DataName"的靜態屬性(每個繼承自MyJsonData的類都應該有DataName這個靜態屬性
            PropertyInfo dataNameProp = type.GetProperty("DataName", BindingFlags.Public | BindingFlags.Static);
            if (dataNameProp != null) return dataNameProp.GetValue(null, null) as string;
            else {
                WriteLog_UnityAssembly.LogErrorFormat("GetJsonData傳入的T類沒有DataName這個屬性");
                return "";
            }
        }
        /// <summary>
        /// 取得T類型的JsonData Dic
        /// </summary>
        public static Dictionary<string, T> GetStrKeyJsonDic<T>() where T : MyJsonData_UnityAssembly {
            string dataName = GetDataName<T>();
            if (StrKeyJsonDic.ContainsKey(dataName)) {
                return StrKeyJsonDic[dataName].ToDictionary(a => a.Key, a => a.Value as T);
            } else {
                string log = string.Format("{0}表不存StrKeyJsonDic中", dataName);
                PopupUI_Local.ShowClickCancel(log, "", null);
                WriteLog_UnityAssembly.LogErrorFormat(log);
                return null;
            }
        }
        /// <summary>
        /// 取得T類型的JsonData
        /// </summary>
        public static T GetJsonData<T>(int _id, bool showErrorMsg = true) where T : MyJsonData_UnityAssembly {
            if (IntKeyJsonDic == null)
                return null;
            string dataName = GetDataName<T>();
            if (IntKeyJsonDic.ContainsKey(dataName) && IntKeyJsonDic[dataName] != null && IntKeyJsonDic[dataName].ContainsKey(_id))
                return IntKeyJsonDic[dataName][_id] as T;
            else {
                string log = string.Format("{0}表不存在ID:{1}的資料", dataName, _id);
                if (showErrorMsg) {
                    PopupUI_Local.ShowClickCancel(log, "", null);
                }
                WriteLog_UnityAssembly.LogErrorFormat(log);
                return null;
            }
        }
        /// <summary>
        /// 取得T類型的JsonData
        /// </summary>
        public static T GetJsonData<T>(string _id) where T : MyJsonData_UnityAssembly {
            if (StrKeyJsonDic == null)
                return null;
            string dataName = GetDataName<T>();
            if (StrKeyJsonDic.ContainsKey(dataName) && StrKeyJsonDic[dataName] != null && StrKeyJsonDic[dataName].ContainsKey(_id))
                return StrKeyJsonDic[dataName][_id] as T;
            else {
                string log = string.Format("{0}表不存在ID:{1}的資料", dataName, _id);
                PopupUI_Local.ShowClickCancel(log, "", null);
                WriteLog_UnityAssembly.LogErrorFormat(log);
                return null;
            }
        }

        /// <summary>
        /// 設定已int作為Key值得 JsonData Dictionary
        /// </summary>
        static void SetDic(string _name, Dictionary<int, MyJsonData_UnityAssembly> _dic) {

            if (_dic != null && _dic.Values.Count > 0) {
                //將JsonDataDic加到字典中
                IntKeyJsonDic[_name] = _dic;
            }
            //完成MyLoadingProgress進度，全部都載完就會回傳LoadJsonDataToDic傳入的Action
            MyLoadingProgress.FinishProgress(_name);
        }

        /// <summary>
        /// 設定已string作為Key值得 JsonData Dictionary
        /// </summary>
        static void SetDic(string _name, Dictionary<string, MyJsonData_UnityAssembly> _dic) {

            if (_dic != null && _dic.Values.Count > 0) {
                StrKeyJsonDic[_name] = _dic;
            }

            //完成MyLoadingProgress進度，全部都載完就會回傳LoadJsonDataToDic傳入的Action
            MyLoadingProgress.FinishProgress(_name);
        }

    }
}
