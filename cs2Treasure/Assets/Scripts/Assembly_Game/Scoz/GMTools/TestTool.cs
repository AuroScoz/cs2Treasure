using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Numerics;
using UnityEngine.Profiling;
using Gladiators.Main;
using UnityEngine.SceneManagement;
using System;

namespace Scoz.Func {
    public partial class TestTool : MonoBehaviour {
        public static TestTool Instance;
        [SerializeField] Text EnvText;
        [SerializeField] Text Text_FPS;
        [SerializeField] Text VersionText;
        public float InfoRefreshInterval = 0.5f;


        int FrameCount = 0;
        float PassTimeByFrames = 0.0f;
        float LastFrameRate = 0.0f;

        MyTimer InfoRefreshTimer = null;


        public Camera GetCamera() {
            return GetComponent<Camera>();
        }



        void OnDestroy() {
        }

        public void Init() {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            GetComponent<RectTransform>().sizeDelta = new UnityEngine.Vector2(Screen.width, Screen.height);
            VersionText.text = "Ver: " + Application.version;
#if Dev
            EnvText.text = EnvVersion.Dev.ToString();
#elif Test
            EnvText.text = EnvVersion.Test.ToString();
#elif Release
            EnvText.text = EnvVersion.Release.ToString();

#endif
        }

        void FPSCalc() {
            if (Text_FPS == null || !Text_FPS.isActiveAndEnabled)
                return;
            if (PassTimeByFrames < InfoRefreshInterval) {
                PassTimeByFrames += Time.deltaTime;
                FrameCount++;
            } else {
                LastFrameRate = (float)FrameCount / PassTimeByFrames;
                FrameCount = 0;
                PassTimeByFrames = 0.0f;
            }
            Text_FPS.text = string.Format("FPS:{0}", Mathf.Round(LastFrameRate).ToString());
        }
        void Update() {
            FPSCalc();
            KeyDetector();
            if (InfoRefreshTimer != null)
                InfoRefreshTimer.RunTimer();
        }

    }
}
