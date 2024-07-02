using Cysharp.Threading.Tasks;
using Scoz.Func;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace cs2Treasure.Main {
    public class PlayerControllUI : BaseUI {

        [SerializeField] Dropdown BetDropDown;
        [SerializeField] Text Text_PlayerPT;
        [SerializeField] Text Text_AddPT;
        [SerializeField] Animator Ani_AddPT;

        public enum Bet {
            Bet10 = 10,
            Bet20 = 20,
            Bet30 = 30,
            Bet50 = 50,
            Bet100 = 100,
        }

        Bet CurBet = Bet.Bet10;

        protected override void OnEnable() {
            base.OnEnable();
        }

        public override void RefreshText() {
            Text_PlayerPT.text = GamePlayer.Instance.Pt.ToString();
        }

        public override void Init() {
            base.Init();
            SetBetDropDown();
        }

        void AddPlayerPT(int _value) {
            if (_value == 0) return;
            string aniTrigger = "add";
            if (_value < 0) {
                aniTrigger = "reduce";
            }
            Ani_AddPT.SetTrigger(aniTrigger);
            if (_value > 0) Text_AddPT.text = "+" + _value.ToString();
            else Text_AddPT.text = _value.ToString();
            RefreshText();
        }
        void SetBetDropDown() {
            BetDropDown.ClearOptions();
            List<Dropdown.OptionData> dropDwonDatas = new List<Dropdown.OptionData>();
            List<Bet> betItems = MyEnum.GetList<Bet>();
            foreach (var item in betItems) {
                var data = new Dropdown.OptionData(item.ToString());
                dropDwonDatas.Add(data);
            }
            BetDropDown.AddOptions(dropDwonDatas);
        }

        public void DropdownValueChanged(Dropdown change) {
            CurBet = MyEnum.GetList<Bet>()[change.value];
        }

        int BetToCaseIdx() {
            if ((int)CurBet <= 30) return 0;
            else if ((int)CurBet <= 50) return 1;
            return 2;
        }

        public void OnPlayClick() {
            WeaponScroller.GetInstance<WeaponScroller>().SetActive(false);
            AddPlayerPT(-(int)CurBet);
            MainManager.Instance.DropCase(BetToCaseIdx());
        }
        public void AutoPlayClick() {

        }
        float ResultOdds;
        public void SetResult(float _odds) {
            ResultOdds = _odds;
        }
        public void ShowResult() {
            UniTask.Void(async () => {
                //MyPointRewardEffect.PlayReward(ResultOdds);
                await UniTask.Delay(500);
                AddPlayerPT(Mathf.RoundToInt(ResultOdds * (float)CurBet));
                RefreshText();
            });
        }
    }
}