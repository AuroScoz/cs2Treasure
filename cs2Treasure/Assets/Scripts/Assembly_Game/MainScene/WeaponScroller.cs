using Cysharp.Threading.Tasks;
using Scoz.Func;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Codice.CM.Common.CmCallContext;

namespace cs2Treasure.Main {
    public class WeaponScroller : MonoBehaviour {
        [SerializeField] RectTransform ParentTrans;
        [SerializeField] WeaponItem[] WeaponItems;
        Transform[] WeaponTrans;

        [SerializeField] float ScrollSpd;
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Q)) {
                Stop(0);
            } else if (Input.GetKeyDown(KeyCode.W)) {
                Spin();
            }
        }
        public enum SpinState {
            Stop,
            Spining,//捲動中
            Stopping,//停止中
            LockToTarget,//停止中, 要把贏得獎勵轉到中心的過程
        }
        public SpinState CurSpinState;
        float MoveDist = 0;

        private void Start() {
            InitGame();
        }

        void InitGame() {
            CurSpinState = SpinState.Stop;
            WeaponTrans = new Transform[WeaponItems.Length];
            for (int i = 0; i < WeaponItems.Length; i++) {
                WeaponTrans[i] = WeaponItems[i].GetComponent<Transform>();
            }
            TotalLength = WeaponTrans.Length * 550;
            SetSymbols(new string[6] { "AK47", "AWP", "DesertEagle", "M4A1", "NOVA", "P250" });
            Spin();
        }

        void SetSymbols(string[] _symbols) {
            try {
                AddressablesLoader.GetSpriteAtlas("Weapon", atlas => {
                    for (int i = 0; i < WeaponTrans.Length; i++) {
                        WeaponItems[i].SetImg(atlas.GetSprite(_symbols[i]));
                    }
                });
            } catch {
                WriteLog.LogError("SetSymbols錯誤");
            }
        }

        public void Spin() {
            CurSpinState = SpinState.Spining;
            RunSpin().Forget();
        }

        float StoppingDecelerationRate = 0.99f;
        float StopCheckDist = 300;
        float LockSpd = 1000;
        float LockMinSpd = 50;
        float TotalLength;
        async UniTask RunSpin() {

            var curScrollSpd = ScrollSpd;

            while (CurSpinState == SpinState.Spining || CurSpinState == SpinState.Stopping) {

                if (CurSpinState == SpinState.Stopping) {
                    if (curScrollSpd > LockSpd) curScrollSpd *= StoppingDecelerationRate;
                    else curScrollSpd = LockSpd;
                }


                MoveDist += curScrollSpd * Time.deltaTime;
                if (MoveDist >= TotalLength) {
                    MoveDist -= TotalLength;
                }

                for (int i = 0; i < WeaponTrans.Length; i++) {
                    float newX = -1650 + (i * 550) + MoveDist;
                    if (newX > 1650) newX -= TotalLength;
                    WeaponTrans[i].localPosition = new Vector3(newX, WeaponTrans[i].localPosition.y, WeaponTrans[i].localPosition.z);
                }

                if (CurSpinState == SpinState.Stopping) {
                    float currentX = WeaponTrans[WinIdx].localPosition.x;
                    if (currentX < 0 && currentX > -StopCheckDist && Mathf.Abs(curScrollSpd) <= LockSpd) {
                        CurSpinState = SpinState.LockToTarget;
                        LockToTarget(curScrollSpd).Forget();
                    }
                }

                await UniTask.Yield(PlayerLoopTiming.Update);
            }
        }
        async UniTask LockToTarget(float _curScrollSpd) {
            float initialDirection = WeaponTrans[WinIdx].localPosition.x > 0 ? -1 : 1;
            var curScrollSpd = _curScrollSpd;
            while (CurSpinState == SpinState.LockToTarget) {
                float currentX = WeaponTrans[WinIdx].localPosition.x;
                if (currentX < 0 && currentX > -200 && curScrollSpd > LockMinSpd) {
                    curScrollSpd *= StoppingDecelerationRate;
                }

                MoveDist += curScrollSpd * initialDirection * Time.deltaTime;
                if (MoveDist >= TotalLength) {
                    MoveDist -= TotalLength;
                }
                for (int i = 0; i < WeaponTrans.Length; i++) {
                    float newX = -1650 + (i * 550) + MoveDist;
                    if (newX > 1650) newX -= TotalLength;
                    WeaponTrans[i].localPosition = new Vector3(newX, WeaponTrans[i].localPosition.y, WeaponTrans[i].localPosition.z);
                }

                //當WeaponTrans[WinIdx].localPosition.x 目標item位置非常接近0時要停止並把所以item都設定到對的位置
                float distToCenter = WeaponTrans[WinIdx].localPosition.x;
                if (Mathf.Abs(distToCenter) < 10) {
                    CurSpinState = SpinState.Stop;
                    for (int i = 0; i < WeaponTrans.Length; i++) {
                        Vector3 currentPosition = WeaponTrans[i].localPosition;
                        currentPosition.x -= distToCenter;
                        WeaponTrans[i].localPosition = currentPosition;
                    }
                    break;
                }

                await UniTask.Yield(PlayerLoopTiming.Update);
            }
        }
        int WinIdx = 0;
        public void Stop(int _winIdx) {
            CurSpinState = SpinState.Stopping;
            WinIdx = _winIdx;
        }
    }
}