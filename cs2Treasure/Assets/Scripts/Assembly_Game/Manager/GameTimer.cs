using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System;
using Scoz.Func;
using Service.Realms;
using System.Threading.Tasks;
using System.Linq;
using Cysharp.Threading.Tasks;

namespace Gladiators.Main {
    public class GameTimer : MonoBehaviour {
        static DateTimeOffset LastOverMidNightTime;
        public static GameTimer Instance;
        const int MinimumOnlineSentSec = 10;//送server目前在線的時間戳，最短間隔設為10，避免跟太頻繁修改DB

        public void Init() {
            Instance = this;

            //每分鐘定時檢查項目
            UniTaskManager.StartRepeatTask("DoMinteThings", DoMinteThings, 60 * 1000);

            //Realm在線時間更新
            var realmTimerDoc = RealmManager.MyRealm.Find<DBGameSetting>(DBGameSettingDoc.Timer.ToString());
            if (realmTimerDoc != null) {
                int onlineCheckSec = realmTimerDoc.OnlineCheckSec.GetValueOrDefault();
                if (onlineCheckSec <= MinimumOnlineSentSec) onlineCheckSec = MinimumOnlineSentSec;
                int miliSecs = onlineCheckSec * 1000;
                UniTaskManager.StartRepeatTask("OnlineSentRepeat", OnlineSentRepeat, miliSecs);
            }
        }

        /// <summary>
        /// 剛登入後，會先執一次，之後每分鐘執行1次
        /// </summary>
        void DoMinteThings() {
            GameStateManager.Instance.InGameCheckCanPlayGame();//檢測是否可繼續遊戲
        }
        void OnlineSentRepeat() {
            //送更新在線時間
            RealmManager.CallAtlasFuncNoneAsync(RealmManager.AtlasFunc.UpdateOnlineTime, null);
            //距離上一次更新不是同一天就會送登入
            if (LastOverMidNightTime == default(DateTimeOffset))
                LastOverMidNightTime = GameManager.Instance.NowTime;
            if (GameManager.Instance.NowTime.Day != LastOverMidNightTime.Day) {//確認上一次更新是不是同一天
                LastOverMidNightTime = GameManager.Instance.NowTime;
                RealmManager.CallAtlasFuncNoneAsync(RealmManager.AtlasFunc.Signin, null);
            }
        }

    }
}
