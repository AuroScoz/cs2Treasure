using UnityEngine;
using System.Collections.Generic;
using System;
using Gladiators.Main;
using System.Linq;
using System.Reflection;

namespace Scoz.Func {

    public partial class GameDictionary : MonoBehaviour {



        //字典
        public static Dictionary<ItemType, Dictionary<int, JsonBase>> ItemJsonDic = new Dictionary<ItemType, Dictionary<int, JsonBase>>();
        public static Dictionary<string, Dictionary<int, JsonBase>> IntKeyJsonDic = new Dictionary<string, Dictionary<int, JsonBase>>();
        public static Dictionary<string, Dictionary<string, JsonBase>> StrKeyJsonDic = new Dictionary<string, Dictionary<string, JsonBase>>();


        //String
        public static Dictionary<string, JsonString> StringDic = new Dictionary<string, JsonString>();
        static LoadingProgress MyLoadingProgress;//載入JsonData進度
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
            MyLoadingProgress = new LoadingProgress(() => {
#if UNITY_EDITOR
                ExcelDataValidation.CheckDatas();//檢查excel資料有沒有填錯
#endif
                _action?.Invoke();
            });

            //Addressables版本
            AddLoadingKey("String");
            JsonString.SetStringDic_Remote(dic => {
                StringDic = dic;
                //完成MyLoadingProgress進度，全部都載完就會回傳LoadJsonDataToDic傳入的Action
                MyLoadingProgress.FinishProgress("String");
            });

            JsonBase.SetDataStringKey_Remote<JsonGameSetting>(SetDic);
            JsonBase.SetData_Remote<JsonSceneTransition>(SetDic);
            JsonBase.SetData_Remote<JsonGladiator>(SetDic);
            JsonBase.SetData_Remote<JsonSkill>(SetDic);
            JsonBase.SetData_Remote<JsonBribe>(SetDic);
            JsonBase.SetDataStringKey_Remote<JsonSkillEffect>(SetDic);

            //設定X秒會顯示尚未載入的JsonData
            CoroutineJob.Instance.StartNewAction(ShowUnLoadedJsondata, 5);

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
                WriteLog.LogErrorFormat("{0}Json尚未載入", notFinishedKeys[i]);
        }
        /// <summary>
        /// 取得T類型的JsonData Dic
        /// </summary>
        public static Dictionary<int, T> GetIntKeyJsonDic<T>() where T : JsonBase {
            string dataName = GetDataName<T>();
            if (IntKeyJsonDic.ContainsKey(dataName)) {
                return IntKeyJsonDic[dataName].ToDictionary(a => a.Key, a => a.Value as T);
            } else {
                string log = string.Format("{0}表不存IntKeyJsonDic中", dataName);
                PopupUI.ShowClickCancel(log, null);
                WriteLog.LogErrorFormat(log);
                return null;
            }
        }
        /// <summary>
        /// 取得T類型的JsonData Dic
        /// </summary>
        public static Dictionary<string, T> GetStrKeyJsonDic<T>() where T : JsonBase {
            string dataName = GetDataName<T>();
            if (StrKeyJsonDic.ContainsKey(dataName)) {
                return StrKeyJsonDic[dataName].ToDictionary(a => a.Key, a => a.Value as T);
            } else {
                string log = string.Format("{0}表不存StrKeyJsonDic中", dataName);
                PopupUI.ShowClickCancel(log, null);
                WriteLog.LogErrorFormat(log);
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
                WriteLog.LogErrorFormat("GetJsonData傳入的T類沒有DataName這個屬性");
                return "";
            }
        }
        /// <summary>
        /// 取得T類型的JsonData
        /// </summary>
        public static T GetJsonData<T>(int _id, bool showErrorMsg = true) where T : JsonBase {
            if (IntKeyJsonDic == null)
                return null;
            string dataName = GetDataName<T>();
            if (IntKeyJsonDic.ContainsKey(dataName) && IntKeyJsonDic[dataName] != null && IntKeyJsonDic[dataName].ContainsKey(_id))
                return IntKeyJsonDic[dataName][_id] as T;
            else {
                string log = string.Format("{0}表不存在ID:{1}的資料", dataName, _id);
                if (showErrorMsg) {
                    PopupUI.ShowClickCancel(log, null);
                }
                WriteLog.LogErrorFormat(log);
                return null;
            }
        }
        /// <summary>
        /// 取得T類型的JsonData
        /// </summary>
        public static T GetJsonData<T>(string _id) where T : JsonBase {
            if (StrKeyJsonDic == null)
                return null;
            string dataName = GetDataName<T>();
            if (StrKeyJsonDic.ContainsKey(dataName) && StrKeyJsonDic[dataName] != null && StrKeyJsonDic[dataName].ContainsKey(_id))
                return StrKeyJsonDic[dataName][_id] as T;
            else {
                string log = string.Format("{0}表不存在ID:{1}的資料", dataName, _id);
                PopupUI.ShowClickCancel(log, null);
                WriteLog.LogErrorFormat(log);
                return null;
            }
        }
        /// <summary>
        /// 取得IItemJsonData Dic
        /// </summary>
        public static Dictionary<int, IItemJsonData> GetIItemJsonDic(ItemType _itemType) {
            if (ItemJsonDic.ContainsKey(_itemType)) {
                return ItemJsonDic[_itemType].ToDictionary(a => a.Key, a => a.Value as IItemJsonData);
            } else {
                string log = string.Format("{0}表不存ItemJsonDic中", _itemType);
                PopupUI.ShowClickCancel(log, null);
                WriteLog.LogErrorFormat(log);
                return null;
            }
        }
        /// <summary>
        /// 取得ItemJsonData
        /// </summary>
        public static IItemJsonData GetItemJsonData(ItemType _itemType, int _id) {
            if (ItemJsonDic.ContainsKey(_itemType) && ItemJsonDic[_itemType].ContainsKey(_id)) {
                IItemJsonData iItemJsonData = ItemJsonDic[_itemType][_id] as IItemJsonData;
                if (iItemJsonData != null)
                    return iItemJsonData;
                string log = string.Format("{0}表的資料不為IItemJsonData", _itemType);
                PopupUI.ShowClickCancel(log, null);
                WriteLog.LogErrorFormat("{0}表的資料不為IItemJsonData", _itemType);
                return null;
            } else {
                string log = string.Format("{0}表不存在ID:{1}的資料", _itemType, _id);
                PopupUI.ShowClickCancel(log, null);
                WriteLog.LogErrorFormat(log);
                return null;
            }
        }

        /// <summary>
        /// 設定已int作為Key值得 JsonData Dictionary
        /// </summary>
        static void SetDic(string _name, Dictionary<int, JsonBase> _dic) {

            if (_dic != null && _dic.Values.Count > 0) {
                //將JsonDataDic加到字典中
                IntKeyJsonDic[_name] = _dic;
                //如果是IItemType類的Json資料(會繼承IItemJsonData)也加到ItemJsonDic中
                if (_dic.Values.First() is IItemJsonData) {
                    ItemType itemType;
                    if (MyEnum.TryParseEnum(_name, out itemType)) {
                        ItemJsonDic[itemType] = _dic;
                    }
                }
            }
            //完成MyLoadingProgress進度，全部都載完就會回傳LoadJsonDataToDic傳入的Action
            MyLoadingProgress.FinishProgress(_name);
        }

        /// <summary>
        /// 設定已string作為Key值得 JsonData Dictionary
        /// </summary>
        static void SetDic(string _name, Dictionary<string, JsonBase> _dic) {

            if (_dic != null && _dic.Values.Count > 0) {
                StrKeyJsonDic[_name] = _dic;
            }

            //完成MyLoadingProgress進度，全部都載完就會回傳LoadJsonDataToDic傳入的Action
            MyLoadingProgress.FinishProgress(_name);
        }

    }
}
