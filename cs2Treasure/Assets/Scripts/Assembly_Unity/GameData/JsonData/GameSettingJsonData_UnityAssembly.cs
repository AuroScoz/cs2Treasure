using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;
using SimpleJSON;

namespace Scoz.Func {
    public class GameSettingJsonData_UnityAssembly : MyJsonData_UnityAssembly {
        public static string DataName { get; set; }
        public new string ID;
        //一般
        static Dictionary<GameSetting_UnityAssembly, string> SettingDic = new Dictionary<GameSetting_UnityAssembly, string>();


        public static int GetInt(GameSetting_UnityAssembly _type) {
            return int.Parse(SettingDic[_type]);
        }
        public static float GetFloat(GameSetting_UnityAssembly _type) {
            return float.Parse(SettingDic[_type]);
        }
        public static bool GetBool(GameSetting_UnityAssembly _type) {
            return bool.Parse(SettingDic[_type]);
        }
        public static byte GetByte(GameSetting_UnityAssembly _type) {
            return byte.Parse(SettingDic[_type]);
        }
        public static string GetStr(GameSetting_UnityAssembly _type) {
            return SettingDic[_type];
        }
        public static JSONNode GetJsNode(GameSetting_UnityAssembly _type) {
            string jsStr = GetStr(_type);
            JSONNode jsNode = JSONNode.Parse(jsStr);
            return jsNode;
        }
        protected override void ResetStaticData() {
            SettingDic.Clear();
        }
        protected override void SetDataFromJson(JsonData _item) {
            JsonData item = _item;
            if (item.Keys.Contains("ID") && item.Keys.Contains("Value")) {
                string id = item["ID"].ToString();
                var key = MyEnum_UnityAssembly.ParseEnum<GameSetting_UnityAssembly>(id);
                SettingDic.Add(key, item["Value"].ToString());
            }
        }
    }
}
