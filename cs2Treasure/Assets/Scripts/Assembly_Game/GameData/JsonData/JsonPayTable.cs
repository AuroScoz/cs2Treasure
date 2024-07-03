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
    public class BetType {
        public int Bet { get; private set; }
        public string CaseRef { get; private set; }
        public Vector3 CasePos { get; set; }
        public Vector3 CaseRot { get; set; }
        public List<JsonPayTable> PayList = new List<JsonPayTable>();
        public BetType(int _bet, string _caseRef) {
            Bet = _bet;
            CaseRef = _caseRef;
        }

        /// <summary>
        /// (前端測試用)
        /// </summary>
        public JsonPayTable GetResultByWeight() {
            var weightList = PayList.ConvertAll(a => a.Weight);
            var idx = Prob.GetIndexFromWeigth(weightList);
            return PayList[idx];
        }
    }
    public class JsonPayTable : JsonBase {
        public static string DataName { get; set; }
        public int Group { get; private set; }
        public int Reward { get; private set; }
        public int Weight { get; private set; }
        public string Ref { get; private set; }
        public string CaseRef { get; private set; }
        public string CasePos { get; private set; }
        public string CaseRot { get; private set; }
        public enum Bet {
            Bet10 = 10,
            Bet20 = 20,
            Bet30 = 30,
            Bet50 = 50,
            Bet100 = 100,
        }


        public static Dictionary<int, BetType> PayTableDic = new Dictionary<int, BetType>();


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
            if (PayTableDic.ContainsKey(myData.Group)) {
                PayTableDic[myData.Group].PayList.Add(myData);
            } else {
                BetType betType = new BetType(myData.Group, myData.CaseRef);
                betType.CasePos = TextManager.ParseTextToVector3(myData.CasePos, ',');
                betType.CaseRot = TextManager.ParseTextToVector3(myData.CaseRot, ',');
                betType.PayList.Add(myData);
                PayTableDic.Add(myData.Group, betType);
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
            PayTableDic.Clear();
        }

        /// <summary>
        /// 傳入群組, 根據權重隨機取得該群組隨機一筆資料
        /// </summary>
        public static BetType GetBetType(int _bet) {
            if (!PayTableDic.ContainsKey(_bet)) {
                WriteLog.LogError($"傳入PayTable Group不存在 Group: {_bet}");
            }
            return PayTableDic[_bet];
        }
        /// <summary>
        /// (前端測試用)傳入群組, 根據權重隨機取得該群組隨機一筆資料
        /// </summary>
        public static JsonPayTable GetBetResult(int _bet) {
            var betType = GetBetType(_bet);
            if (betType == null) return null;
            return betType.GetResultByWeight();
        }

    }

}
