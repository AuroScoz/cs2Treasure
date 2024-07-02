using Cysharp.Threading.Tasks;
using Scoz.Func;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace cs2Treasure.Main {

    public enum MainUIs {
        WeaponScrollerUI,//卷軸UI
        PlayerControllUI,//玩家操作UI
    }

    public enum MainUIStates {
        Beting,//下注中
        Scrolling,//抽武器中
        Result,//結果顯示中
    }


    public class MainSceneUI : BaseUI {
        [SerializeField] AssetReference MainManagerAsset;
        [SerializeField] WeaponScroller MyWeaponScroller;
        [SerializeField] PlayerControllUI MyPlayerControllUI;

        Dictionary<MainUIs, BaseUI> UIs = new Dictionary<MainUIs, BaseUI>();
        LoadingProgress MyUILoadingProgress;


        private void Start() {
            Init();
            CreateMainManager();
        }

        void CreateMainManager() {
            AddressablesLoader.GetAssetRef<GameObject>(MainManagerAsset, prefab => {
                var go = Instantiate(prefab);
                go.GetComponent<MainManager>().Init();
            });
        }

        public override void Init() {
            base.Init();
            MyUILoadingProgress = new LoadingProgress(OnUIFinishedLoad);

            MyWeaponScroller.Init();
            UIs.Add(MainUIs.WeaponScrollerUI, MyWeaponScroller);

            MyPlayerControllUI.Init();
            UIs.Add(MainUIs.PlayerControllUI, MyPlayerControllUI);

        }

        /// <summary>
        /// 所有UI都載入完跑這裡
        /// </summary>
        void OnUIFinishedLoad() {

        }
        void HideAllUIs() {
            foreach (var ui in UIs.Values) {
                if (ui != null) ui.SetActive(false);
            }
        }
        /// <summary>
        /// 切換UI狀態
        /// </summary>
        public void SwitchUI(MainUIStates _state) {
            HideAllUIs();

            //根據目前UI狀態選擇要打開的UI
            switch (_state) {
                case MainUIStates.Beting:
                    break;
                case MainUIStates.Scrolling:

                    break;
                case MainUIStates.Result:
                    break;
            }
        }

        public override void RefreshText() {
        }
    }
}
