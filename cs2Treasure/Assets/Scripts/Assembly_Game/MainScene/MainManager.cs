using Scoz.Func;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Cysharp.Threading.Tasks;
using Cinemachine;
using cs2Treasure.Socket;
using Gladiators.Main;
using Unity.Entities;

namespace cs2Treasure.Main {
    public class MainManager : MonoBehaviour {

        public static MainManager Instance;

        [SerializeField] Camera SceneCam;
        [SerializeField] ParticleSystem Particle_Flash;
        [SerializeField] Transform ObjParent;

        GameObject Go_Case;

        public enum GameState {
            WaitingForBet, // 等待下注
            Playing, // 演出中
        }
        public GameState CurState { get; private set; }

        public void Init() {
            Instance = this;
            ResetGame();
            AddCamStack(UICam.Instance.MyCam);
        }
        /// <summary>
        /// 將指定camera加入到MyCam的CameraStack中
        /// </summary>
        void AddCamStack(Camera _cam) {
            //因為場景的攝影機有分為場景與UI, 要把場景攝影機設定為Base, UI設定為Overlay, 並在BaseCamera中加入Camera stack
            UICam.Instance.SetRendererMode(CameraRenderType.Overlay);
            if (_cam == null) return;
            var cameraData = SceneCam.GetUniversalAdditionalCameraData();
            if (cameraData == null) return;
            cameraData.cameraStack.Add(_cam);
        }

        void ResetGame() {
            Particle_Flash.gameObject.SetActive(false);
            DestroyCase();
        }

        void DestroyCase() {
            if (Go_Case != null) Destroy(Go_Case);
        }

        public void DropCase(BetType _betType) {
            ResetGame();
            PlayDrop(_betType).Forget();
        }
        async UniTask PlayDrop(BetType _betType) {
            DestroyCase();
            string path = $"Assets/AddressableAssets/Prefabs/Case/{_betType.CaseRef}.prefab";
            var tuple = await AddressablesLoader.GetResourceByFullPath_Async<GameObject>(path);
            Go_Case = Instantiate(tuple.Item1);
            Go_Case.transform.SetParent(ObjParent);
            Go_Case.transform.localPosition = _betType.CasePos;
            Go_Case.transform.localRotation = Quaternion.Euler(_betType.CaseRot);
            await UniTask.Delay(1500);
            Particle_Flash.gameObject.SetActive(true);
            await UniTask.Delay(200);
            var resultJsonPayTable = _betType.GetResultByWeight();
            GamePlayer.Instance.AddPt(resultJsonPayTable.Reward);
            WeaponScroller.GetInstance<WeaponScroller>()?.Play(resultJsonPayTable);
            PlayerControllUI.GetInstance<PlayerControllUI>().SetResult(resultJsonPayTable);

        }


        public void ChangeState(GameState _state) {
            CurState = _state;
            switch (_state) {
                case GameState.WaitingForBet:

                    break;
                case GameState.Playing:
                    DropCase(PlayerControllUI.GetInstance<PlayerControllUI>().CurBet);
                    break;
            }
        }

    }
}
