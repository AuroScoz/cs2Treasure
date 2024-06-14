using Gladiators.Main;
using UnityEngine;

namespace Gladiators.Battle {
    public class BattleSceneManager : MonoBehaviour {
        void Start() {
            BaseManager.CreateNewInstance();
        }
    }
}