using UnityEngine;
namespace Scoz.Func {
    public class UICanvas : MonoBehaviour {
        public static UICanvas Instance { get; private set; }
        Canvas MyCanvas;
        public void Init() {
            Instance = this;
            MyCanvas = GetComponent<Canvas>();
            SetCanvasCamera(UICam.Instance.MyCam);
        }
        /// <summary>
        /// 設定Canvas的Camera
        /// </summary>
        public void SetCanvasCamera(Camera _cam) {
            MyCanvas.worldCamera = _cam;
        }
    }
}