using Cysharp.Threading.Tasks;
using Scoz.Func;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities.UniversalDelegates;
using UnityEngine;
using UnityEngine.UI;
using static Codice.CM.Common.CmCallContext;

namespace cs2Treasure.Main {


    public class WeaponScroller : ItemSpawner_Remote<WeaponItem> {
        [SerializeField] int ResultDelayMiliSec;
        [SerializeField] float ScrollSpd;
        [SerializeField] Animator TargetFrameAni;
        [SerializeField] float ItemDist = 550;


        float StoppingDecelerationRate = 0.99f;
        float StopCheckDist = 300;
        float LockSpd = 1000;
        float LockMinSpd = 50;
        float TotalLength;



        public void SetItems(BetType _betType) {
            if (!LoadItemFinished) {
                WriteLog.LogError("WeaponItem尚未載入完成");
                return;
            }
            InActiveAllItem();
            var datas = _betType.PayList;
            if (datas == null || datas.Count == 0) return;
            SetActive(true);
            AddressablesLoader.GetSpriteAtlas("Weapon", atlas => {
                for (int i = 0; i < datas.Count; i++) {
                    Sprite sprite = atlas.GetSprite(datas[i].Ref);
                    if (sprite == null) WriteLog.LogErrorFormat("datas[i].Ref=" + datas[i].Ref);
                    if (i < ItemList.Count) {
                        ItemList[i].SetItem(sprite, datas[i].Reward);
                        ItemList[i].IsActive = true;
                        ItemList[i].gameObject.SetActive(true);
                    } else {
                        var item = Spawn();
                        item.SetItem(sprite, datas[i].Reward);
                    }
                    float posX = (i - 3) * ItemDist;
                    ItemList[i].transform.localPosition = new Vector3(posX, 0, 0);
                }
                TotalLength = ItemList.Count * ItemDist;
            });
        }

        public override void RefreshText() {
        }
        public enum SpinState {
            Stop,
            Spining,//捲動中
            Stopping,//停止中
            LockToTarget,//停止中, 要把贏得獎勵轉到中心的過程
        }
        public SpinState CurSpinState;
        float MoveDist = 0;
        void ResetScroller() {
            float startPos = -3 * ItemDist;
            for (int i = 0; i < ItemList.Count; i++) {
                float posX = startPos + (i * ItemDist);
                ItemList[i].transform.localPosition = new Vector3(posX, 0, 0);
            }
        }

        public override void Init() {
            base.Init();
            CurSpinState = SpinState.Stop;

            ResetScroller();
        }


        public void Play(JsonPayTable _result) {
            var idx = ItemList.FindIndex(a => a.Reward == _result.Reward);
            SetActive(true);
            UniTask.Void(async () => {
                Spin();
                await UniTask.Delay(ResultDelayMiliSec);
                Stop(idx);
            });

        }

        void PlayFrameAni() {
            TargetFrameAni.SetTrigger("Play");
        }

        void Spin() {
            CurSpinState = SpinState.Spining;
            RunSpin().Forget();
        }


        async UniTask RunSpin() {

            var curScrollSpd = ScrollSpd;
            float passDist = 0;

            while (CurSpinState == SpinState.Spining || CurSpinState == SpinState.Stopping) {

                if (CurSpinState == SpinState.Stopping) {
                    if (curScrollSpd > LockSpd) curScrollSpd *= StoppingDecelerationRate;
                    else curScrollSpd = LockSpd;
                }


                MoveDist += curScrollSpd * Time.deltaTime;

                // Item每經過TargetFrame就要播放TargetFrame動畫演出
                passDist += curScrollSpd * Time.deltaTime;
                if (passDist > ItemDist) {
                    passDist = 0;
                    PlayFrameAni();
                }

                if (MoveDist >= TotalLength) {
                    MoveDist -= TotalLength;
                }

                for (int i = 0; i < ItemList.Count; i++) {
                    float newX = -(ItemDist * 3) + (i * ItemDist) + MoveDist;
                    if (newX > 1650) newX -= TotalLength;
                    ItemList[i].transform.localPosition = new Vector3(newX, ItemList[i].transform.localPosition.y, ItemList[i].transform.localPosition.z);
                }

                if (CurSpinState == SpinState.Stopping) {
                    float currentX = ItemList[WinIdx].transform.localPosition.x;
                    if (currentX < 0 && currentX > -StopCheckDist && Mathf.Abs(curScrollSpd) <= LockSpd) {
                        CurSpinState = SpinState.LockToTarget;
                        LockToTarget(curScrollSpd).Forget();
                    }
                }

                await UniTask.Yield(PlayerLoopTiming.Update);
            }
        }
        async UniTask LockToTarget(float _curScrollSpd) {
            float initialDirection = ItemList[WinIdx].transform.localPosition.x > 0 ? -1 : 1;
            var curScrollSpd = _curScrollSpd;
            float passDist = 0;
            while (CurSpinState == SpinState.LockToTarget) {
                float currentX = ItemList[WinIdx].transform.localPosition.x;
                if (currentX < 0 && currentX > -200 && curScrollSpd > LockMinSpd) {
                    curScrollSpd *= StoppingDecelerationRate;
                }


                MoveDist += curScrollSpd * initialDirection * Time.deltaTime;
                if (MoveDist >= TotalLength) {
                    MoveDist -= TotalLength;
                }


                // Item每經過TargetFrame就要播放TargetFrame動畫演出
                passDist += curScrollSpd * Time.deltaTime;
                if (passDist > ItemDist) {
                    passDist = 0;
                    PlayFrameAni();
                }

                for (int i = 0; i < ItemList.Count; i++) {
                    float newX = -1650 + (i * 550) + MoveDist;
                    if (newX > 1650) newX -= TotalLength;
                    ItemList[i].transform.localPosition = new Vector3(newX, ItemList[i].transform.localPosition.y, ItemList[i].transform.localPosition.z);
                }

                //當ItemList[WinIdx].localPosition.x 目標item位置非常接近0時要停止並把所以item都設定到對的位置
                float distToCenter = ItemList[WinIdx].transform.localPosition.x;
                if (Mathf.Abs(distToCenter) < 10) {
                    CurSpinState = SpinState.Stop;
                    for (int i = 0; i < ItemList.Count; i++) {
                        Vector3 currentPosition = ItemList[i].transform.localPosition;
                        currentPosition.x -= distToCenter;
                        ItemList[i].transform.localPosition = currentPosition;
                    }
                    PlayFrameAni();
                    Stopped();
                    break;
                }

                await UniTask.Yield(PlayerLoopTiming.Update);
            }
        }
        int WinIdx = 0;
        void Stop(int _winIdx) {
            CurSpinState = SpinState.Stopping;
            WinIdx = _winIdx;
        }
        void Stopped() {
            UniTask.Void(async () => {
                await UniTask.Delay(500);
                ShowResult();
            });
        }
        void ShowResult() {
            GetInstance<PlayerControllUI>()?.ShowResult();
        }


    }
}