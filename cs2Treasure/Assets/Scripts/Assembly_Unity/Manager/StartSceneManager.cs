using UnityEngine;

namespace Gladiators.Main {
    public class StartSceneManager : MonoBehaviour {
        private void Start() {
            BaseManager.CreateNewInstance();
        }
    }
}