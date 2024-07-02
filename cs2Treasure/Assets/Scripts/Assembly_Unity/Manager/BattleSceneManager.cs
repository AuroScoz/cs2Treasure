using cs2Treasure.Main;
using UnityEngine;

namespace cs2Treasure.Battle {
    public class BattleSceneManager : MonoBehaviour {
        void Start() {
            BaseManager.CreateNewInstance();
        }
    }
}