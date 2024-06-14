using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scoz.Func;
using LitJson;
using System;
using System.Linq;

namespace Gladiators.Main {
    /// <summary>
    /// 物品類型
    /// </summary>
    public enum ItemType {
        Gold,
        Point,
        //有新增新的類型也要追加
    }
    //非獨立資料類道具，記錄在PlayerData-Item裡的道具都屬於非獨立資料類道具
    public enum NotUniqueItemTypes {

    }
    public class ItemData {
        public ItemType Type { get; private set; }
        public long Value { get; private set; }
        public string Name {
            get {
                string name = "NoName";
                switch (Type) {
                    case ItemType.Gold:
                    case ItemType.Point:
                        name = string.Format("{0}{1}", Value, JsonString.GetUIString(Type.ToString()));
                        break;
                    default:
                        var itemJsonData = GameDictionary.GetItemJsonData(Type, (int)Value);
                        name = itemJsonData.Name;
                        break;
                }
                return name;
            }
        }
        public ItemData(ItemType _type, long _value) {
            Type = _type;
            Value = _value;
        }

    }
}
