using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scoz.Func;
using System;
using System.Linq;
using LitJson;
using SimpleJSON;

namespace Gladiators.Main {

    public partial class GamePlayer : MyPlayer {

        public void LoadAllDataFromLoco() {
            List<LocoDataName> locoDataNames = MyEnum.GetList<LocoDataName>();
            locoDataNames.Remove(LocoDataName.PlayerSetting);
            foreach (var name in locoDataNames) {
                try {
                    LoadDataFromLoco(name);
                } catch (Exception _e) {
                    WriteLog.LogError("LoadDataFromLoco 錯誤:" + _e);
                }
            }
        }
        public void LoadDataFromLoco(LocoDataName _name) {
            string json = LocoDataManager.GetDataFromLoco(_name);
            if (string.IsNullOrEmpty(json)) return;
            switch (_name) {
                default:
                    WriteLog.LogErrorFormat("尚未實作LocoData為{0}類型的json轉Dic方法", _name);
                    break;
            }
        }


    }
}
