using Scoz.Func;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace cs2Treasure.Main {
    public class WeaponItem : MonoBehaviour, IItem {
        [SerializeField] Image MyImg;
        [SerializeField] Text Text_Reward;

        public int Reward { get; private set; }

        public bool IsActive { get; set; }

        public void SetItem(Sprite _sprite, int _reward) {
            MyImg.sprite = _sprite;
            Reward = _reward;
            Text_Reward.text = _reward.ToString();
        }

    }
    public class WeaponItemData {
        public string SymbolText { get; private set; }
        public float SymbolOdds { get; private set; }
        public WeaponItemData(string _symbolText, float _symbolOdds) {
            SymbolText = _symbolText;
            SymbolOdds = _symbolOdds;
        }
    }
}