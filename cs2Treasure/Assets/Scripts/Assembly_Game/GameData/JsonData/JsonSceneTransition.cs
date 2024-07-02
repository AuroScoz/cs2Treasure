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
    public class JsonSceneTransition : JsonBase {
        public static string DataName { get; set; }
        public string Description {
            get {
                return JsonString.GetString_static(DataName + "_" + ID, "Description");
            }
        }
        public int Weight { get; private set; }
        public string Ref { get; private set; }



        protected override void SetDataFromJson(JsonData _item) {
            JsonData item = _item;
            //反射屬性
            var myData = JsonMapper.ToObject<JsonSceneTransition>(item.ToJson());
            foreach (PropertyInfo propertyInfo in this.GetType().GetProperties()) {
                if (propertyInfo.CanRead && propertyInfo.CanWrite) {
                    //下面這行如果報錯誤代表上方的sonMapper.ToObject<XXXXX>(item.ToJson());<---XXXXX忘了改目前Class名稱
                    var value = propertyInfo.GetValue(myData, null);
                    propertyInfo.SetValue(this, value, null);
                }
            }

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
        }

        public static JsonSceneTransition GetRandomData() {
            List<JsonSceneTransition> itemList = GameDictionary.GetIntKeyJsonDic<JsonSceneTransition>().Values.ToList();
            var weightList = itemList.ConvertAll(a => a.Weight);
            var idx = Prob.GetIndexFromWeigth(weightList);
            return itemList[idx];
        }
    }

}
