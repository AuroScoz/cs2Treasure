using Gladiators.Main;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

namespace Scoz.Func {

    public enum LocoDataName {
        PlayerSetting,//玩家設定
    }
    public class LocoDataManager {
        public static void SaveDataToLoco(LocoDataName _name, string _json) {
            PlayerPrefs.SetString(_name.ToString(), _json);
            WriteLog.LogColorFormat("SaveDataToLoco-{0}: {1}", WriteLog.LogType.Loco, _name, _json);
        }


        public static string GetDataFromLoco(LocoDataName _name) {
            string json = "";
            if (PlayerPrefs.HasKey(_name.ToString())) {
                json = PlayerPrefs.GetString(_name.ToString());
                WriteLog.LogColorFormat("GetDataFromLoco-{0}: {1}", WriteLog.LogType.Loco, _name, json);
            } else {
                WriteLog.LogColorFormat("No Loco Data-{0}", WriteLog.LogType.Loco, _name);
            }
            return json;
        }
    }
}