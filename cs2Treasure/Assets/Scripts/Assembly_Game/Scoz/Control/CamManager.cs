using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Scoz.Func {


    public class CamManager : MonoBehaviour {

        public static CamManager Instance;
        static bool Shaking;
        static Vector3 CamPos;
        static Quaternion CamRot;

        public enum CamNames {
            Battle,
        }
        static CinemachineBrain MyCinemachineBrain;
        static Dictionary<CamNames, CinemachineVirtualCamera> VirtualCams = new Dictionary<CamNames, CinemachineVirtualCamera>();
        public void Init() {
            Instance = this;
        }
        public static void SetCam(CinemachineBrain _brain) {
            if (_brain == null)
                return;
            MyCinemachineBrain = _brain;
            MyCinemachineBrain.m_DefaultBlend.m_Time = 2;
        }
        /// <summary>
        /// 攝影機震動
        /// </summary>
        /// <param name="_camName">攝影機名稱</param>
        /// <param name="_amplitudeGain">震動強度</param>
        /// <param name="_frequencyGain">震動頻率</param>
        /// <param name="_duration">持續秒數</param>
        public static void ShakeCam(CamNames _camName, float _amplitudeGain, float _frequencyGain, float _duration) {
            CinemachineBasicMultiChannelPerlin perlin = GetVirtualCam(_camName)?.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            if (perlin != null) {
                if (Shaking) return;
                Shaking = true;
                CamPos = MyCinemachineBrain.transform.localPosition;
                CamRot = MyCinemachineBrain.transform.localRotation;
                perlin.m_AmplitudeGain = _amplitudeGain;
                perlin.m_FrequencyGain = _frequencyGain;
                UniTaskManager.StartTask("ShakeCam", () => {
                    perlin.m_AmplitudeGain = 0;
                    UniTaskManager.StartTask("ShakeCam2", () => {
                        MyCinemachineBrain.transform.localPosition = CamPos;
                        MyCinemachineBrain.transform.localRotation = CamRot;
                        Shaking = false;
                    }, 100);
                }, (int)(_duration * 1000));
            }
        }
        public static void AddVirtualCam(CamNames _camName, CinemachineVirtualCamera _cam) {
            if (!VirtualCams.ContainsKey(_camName))
                VirtualCams.Add(_camName, _cam);
            else
                VirtualCams[_camName] = _cam;
        }

        public static void RemoveVirtualCam(CamNames _name) {
            VirtualCams.Remove(_name);
        }
        public static CinemachineVirtualCamera GetVirtualCam(CamNames _key) {
            if (VirtualCams.ContainsKey(_key))
                return VirtualCams[_key];
            return null;
        }
        public static void ChangeCamTransitionTime(float _time) {
            if (MyCinemachineBrain == null)
                return;
            MyCinemachineBrain.m_DefaultBlend.m_Time = _time;
        }
    }
}