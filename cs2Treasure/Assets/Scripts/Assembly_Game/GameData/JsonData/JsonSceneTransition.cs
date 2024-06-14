using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scoz.Func;
using LitJson;
using System;
using System.Linq;

namespace Gladiators.Main {
    public class JsonSceneTransition : JsonBase {
        public static string DataName { get; set; }
        public string Description {
            get {
                return JsonString.GetString_static(DataName + "_" + ID, "Description");
            }
        }
        public string RefPic { get; private set; }
        public int Weight { get; private set; }
        protected override void SetDataFromJson(JsonData _item) {
            JsonData item = _item;
            foreach (string key in item.Keys) {
                switch (key) {
                    case "ID":
                        ID = int.Parse(item[key].ToString());
                        break;
                    case "RefPic":
                        RefPic = item[key].ToString();
                        break;
                    case "Weight":
                        Weight = int.Parse(item[key].ToString());
                        break;
                    default:
                        WriteLog.LogWarning(string.Format("{0}表有不明屬性:{1}", DataName, key));
                        break;
                }
            }
        }
        public static JsonSceneTransition GetRandomData() {
            var dic = GameDictionary.GetIntKeyJsonDic<JsonSceneTransition>();
            if (dic == null)
                return null;
            List<JsonSceneTransition> dataList = dic.Values.ToList();
            if (dataList == null || dataList.Count == 0)
                return null;
            List<int> weights = new List<int>();
            for (int i = 0; i < dataList.Count; i++)
                weights.Add(dataList[i].Weight);
            return dataList[Prob.GetIndexFromWeigth(weights)];
        }

        protected override void ResetStaticData() {
        }
    }

}
