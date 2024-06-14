using UnityEngine;
using UnityEngine.Rendering.Universal;
namespace Scoz.Func {
    public class UICam : MonoBehaviour {
        public static UICam Instance { get; private set; }
        public Camera MyCam { get; private set; }
        public void Init() {
            Instance = this;
            MyCam = GetComponent<Camera>();
            DontDestroyOnLoad(gameObject);
        }
        public void SetRendererMode(CameraRenderType _type) {
            if (MyCam == null) return;
            UniversalAdditionalCameraData cameraData = MyCam.GetComponent<UniversalAdditionalCameraData>();
            if (cameraData != null) {
                cameraData.renderType = _type;
            }
        }
    }
}