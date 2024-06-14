using System.Collections;
using UnityEngine;
using Scoz.Func;

namespace Gladiators.Socket {
    public class ServerTimeSyncer : MonoBehaviour {
        private const float SERVER_UPDATE_TIME = 1.0f;
        private float serverTime = 0;
        private float lastRecieveTime = 0;
        private float lantency = 0;
        private WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();
        private void Start() {
            DontDestroyOnLoad(this);
        }
        public void SycServerTime(double time) {
            //WriteLog.LogError("lantency : " + lantency + " serverTime:" + serverTime + " time:" + time + " lastRecieveTime:" + lastRecieveTime);
            serverTime = (float)time;
            lantency = lastRecieveTime - SERVER_UPDATE_TIME;
            lastRecieveTime = 0;
        }

        public void StartCountTime() {
            serverTime = 0;
            lastRecieveTime = 0;
            lantency = 0;
            StopAllCoroutines();
            StartCoroutine(TimerFixUpdate());
        }

        public float GetTime() {
            return serverTime;
        }

        public float GetLantency() {
            //如果退到背景再回來 這裡應該會是負的
            if (lantency < 0)
                return 0;
            return lantency;
        }

        private IEnumerator TimerFixUpdate() {
            while (true) {
                serverTime += Time.fixedDeltaTime;
                lastRecieveTime += Time.fixedDeltaTime;
                yield return fixedUpdate;
            }
        }
    }
}