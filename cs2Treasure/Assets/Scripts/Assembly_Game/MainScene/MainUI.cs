using Scoz.Func;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace cs2Treasure.Main {

    public enum Bet {
        Bet1 = 1,
        Bet3 = 3,
        Bet5 = 5,
        Bet10 = 10,
        Bet15 = 15,
        Bet20 = 20,
        Bet30 = 30,
        Bet50 = 50,
        Bet100 = 100,
    }

    public class MainUI : MonoBehaviour {
        [SerializeField] Dropdown BetDropDown;

        Bet CurBet = Bet.Bet1;

        private void Start() {
            Init();
        }

        private void Init() {
            SetBetDropDown();
        }
        void SetBetDropDown() {
            BetDropDown.ClearOptions();
            List<Dropdown.OptionData> dropDwonDatas = new List<Dropdown.OptionData>();
            List<Bet> betItems = MyEnum.GetList<Bet>();
            foreach (var item in betItems) {
                var data = new Dropdown.OptionData(item.ToString());
                dropDwonDatas.Add(data);
                WriteLog.LogError(item.ToString());
            }
            BetDropDown.AddOptions(dropDwonDatas);
        }

        public void DropdownValueChanged(Dropdown change) {
            CurBet = MyEnum.GetList<Bet>()[change.value];
            WriteLog.LogError("CurBet=" + CurBet);
        }

        int BetToCaseIdx() {
            if ((int)CurBet <= 5) return 0;
            else if ((int)CurBet <= 20) return 1;
            return 2;
        }

        public void OnPlayClick() {
            MainManager.Instance.DropCase(BetToCaseIdx());
        }
        public void AutoPlayClick() {

        }
    }
}
