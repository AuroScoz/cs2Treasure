using UnityEngine;

namespace cs2Treasure.Main {
    public class MainSceneManager : MonoBehaviour {
        private void Start() {
            BaseManager.CreateNewInstance();
        }
    }
}