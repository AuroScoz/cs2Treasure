using UnityEngine;

namespace Gladiators.Main {
    public class MainSceneManager : MonoBehaviour {
        private void Start() {
            BaseManager.CreateNewInstance();
        }
    }
}