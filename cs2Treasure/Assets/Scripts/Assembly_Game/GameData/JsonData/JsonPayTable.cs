using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scoz.Func;
using LitJson;
using System;
using System.Linq;
using SimpleJSON;
using System.Reflection;

namespace cs2Treasure.Main {
    public class JsonPayTable : JsonBase {
        public static string DataName { get; set; }
        public int Group { get; private set; }
        public double Odds { get; private set; }
        public int Weight { get; private set; }
        public string Ref { get; private set; }

        public static Dictionary<int, List<JsonPayTable>> PayTableDic = new Dictionary<int, List<JsonPayTable>>();


        protected override void SetDataFromJson(JsonData _item) {
            JsonData item = _item;
            //反射屬性
            var myData = JsonMapper.ToObject<JsonPayTable>(item.ToJson());
            foreach (PropertyInfo propertyInfo in this.GetType().GetProperties()) {
                if (propertyInfo.CanRead && propertyInfo.CanWrite) {
                    //下面這行如果報錯誤代表上方的sonMapper.ToObject<XXXXX>(item.ToJson());<---XXXXX忘了改目前Class名稱
                    var value = propertyInfo.GetValue(myData, null);
                    propertyInfo.SetValue(this, value, null);
                }
            }
            if (PayTableDic.ContainsKey(myData.Group)) PayTableDic[myData.Group].Add(myData);
            else PayTableDic.Add(myData.Group, new List<JsonPayTable>() { myData });
            //自定義屬性
            //foreach (string key in item.Keys) {
            //    switch (key) {
            //        case "ID":
            //            ID = int.Parse(item[key].ToString());
            //            break;
            //        default:
            //            WriteLog.LogWarning(string.Format("{0}表有不明屬性:{1}", DataName, key));
            //            break;
            //    }
            //}
        }
        protected override void ResetStaticData() {
            PayTableDic.Clear();
        }

        /// <summary>
        /// 傳入群組, 根據權重隨機取得該群組隨機一筆資料
        /// </summary>
        public static JsonPayTable GetRndDataInGroup(int _group) {
            if (!PayTableDic.ContainsKey(_group)) {
                WriteLog.LogError($"傳入PayTable Group不存在 Group: {_group}");
            }
            var weightList = PayTableDic[_group].ConvertAll(a => a.Weight);
            var idx = Prob.GetIndexFromWeigth(weightList);
            return PayTableDic[_group][idx];
        }
    }

}
