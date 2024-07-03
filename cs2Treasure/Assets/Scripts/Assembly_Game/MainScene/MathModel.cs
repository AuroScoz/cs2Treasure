using Scoz.Func;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gladiators.Main {
    public static class MathModel {
        public struct Item {
            public int Idx;
            public int Reward;
            public int Weight;
            public Item(int _idx, int _reward, int _weight) {
                Idx = _idx;
                Reward = _reward;
                Weight = _weight;
            }
        }
        static List<Item> Items;
        public static void SetItems(List<Item> _items) {
            Items = _items;
        }
        public static Item GetResult() {
            List<int> weights = Items.ConvertAll(a => a.Weight);
            int idx = Prob.GetIndexFromWeigth(weights);
            return Items[idx];
        }
    }
}