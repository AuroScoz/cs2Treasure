using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace cs2Treasure.Main {
    public class WeaponItem : MonoBehaviour {
        [SerializeField] Image MyImg;
        [SerializeField] Text OddsText;

        public void SetItem(Sprite _sprite, string _text) {
            MyImg.sprite = _sprite;
            OddsText.text = _text;
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