using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace cs2Treasure.Main {
    public class WeaponItem : MonoBehaviour {
        [SerializeField] Image MyImg;

        public void SetImg(Sprite _sprite) {
            MyImg.sprite = _sprite;
        }

    }
}