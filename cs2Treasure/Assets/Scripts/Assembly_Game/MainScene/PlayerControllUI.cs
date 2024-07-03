using Cysharp.Threading.Tasks;
using Scoz.Func;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static Codice.CM.Common.CmCallContext;
namespace cs2Treasure.Main {
    public class PlayerControllUI : BaseUI {

        [SerializeField] Dropdown BetDropDown;
        [SerializeField] Text Text_PlayerPT;
        [SerializeField] Text Text_AddPT;
        [SerializeField] Animator Ani_AddPT;


        List<BetType> BetTypes_Sorted = new List<BetType>();
        public BetType CurBet = null;

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
            BetTypes_Sorted.Clear();
            List<Dropdown.OptionData> dropDwonDatas = new List<Dropdown.OptionData>();
            BetTypes_Sorted = JsonPayTable.PayTableDic.Values.OrderBy(a => a.Bet).ToList();
            var betOptions = BetTypes_Sorted.ConvertAll(a => a.Bet.ToString());
            BetDropDown.AddOptions(betOptions);
            CurBet = BetTypes_Sorted[0];
        }

        public void DropdownValueChanged(Dropdown change) {
            CurBet = BetTypes_Sorted[change.value];
            WeaponScroller.GetInstance<WeaponScroller>().SetItems(CurBet);
        }

        public void OnPlayClick() {
            WeaponScroller.GetInstance<WeaponScroller>().SetActive(false);
            GamePlayer.Instance.AddPt(-CurBet.Bet);
            AddPlayerPT(-CurBet.Bet);
            MainManager.Instance.DropCase(CurBet);
        }
        public void AutoPlayClick() {

        }
        JsonPayTable ResultJsonPayTable;
        public void SetResult(JsonPayTable _jsonData) {
            ResultJsonPayTable = _jsonData;
        }
        public void ShowResult() {
            UniTask.Void(async () => {
                //MyPointRewardEffect.PlayReward(ResultOdds);
                await UniTask.Delay(500);
                AddPlayerPT(ResultJsonPayTable.Reward);
                RefreshText();
            });
        }
    }
}