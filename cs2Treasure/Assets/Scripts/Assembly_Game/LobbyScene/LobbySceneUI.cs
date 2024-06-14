using UnityEngine;
using Scoz.Func;
using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Service.Realms;

namespace Gladiators.Main {

    public class LobbySceneUI : BaseUI {

        public enum LobbyUIs {
            Lobby,//預設介面
            Map,//地圖介面
            Hero,//英雄介面
        }
        public Dictionary<LobbyUIs, BaseUI> UIs = new Dictionary<LobbyUIs, BaseUI>();
        public LobbyUIs CurUI { get; private set; } = LobbyUIs.Lobby;
        public BaseUI LastPopupUI { get; private set; }//紀錄上次的彈出介面(切介面時要關閉上次的彈出介面)

        static bool FirstEnterLobby = true;//第一次進入大廳後會設定回false 用來判斷是否第一次進入大廳而做判斷


        public static LobbySceneUI Instance { get; private set; }


        //進遊戲不先初始化，等到要用時才初始化的UI放這裡

        private void Start() {
            Init();
        }

        public override void Init() {
            base.Init();
            Instance = this;


            //檢查realmg登入檢查
            RealmLoginCheck(() => {
                //初始化UIs
                //UIs.Add(LobbyUIs.Map, MyMapUI);
                SwitchUI(LobbyUIs.Lobby);

            });
        }


        void RealmLoginCheck(Action _ac) {
            if (RealmManager.MyApp.CurrentUser == null) {//尚無Realm帳戶
                PopupUI.ShowLoading("玩家尚未登入Realm 要先登入Realm才能從Lobby開始遊戲");
                WriteLog.LogError("玩家尚未登入Realm 要先登入Realm才能從Lobby開始遊戲");
                return;
            } else {//已經有Realm帳戶，就登入Realm
                if (RealmManager.MyRealm == null) {// 還沒有設定Realm Config就先設定
                    PopupUI.ShowLoading(JsonString.GetUIString("DataLoading"));
                    UniTask.Void(async () => {
                        await RealmManager.OnSignin();
                        RealmManager.OnDataLoaded();
                        PopupUI.HideLoading();
                        _ac?.Invoke();
                    });
                } else {
                    _ac?.Invoke();
                }
            }
        }

        void CloseUIExcept(LobbyUIs _exceptUI) {
            foreach (var key in UIs.Keys) {
                UIs[key].SetActive(key == _exceptUI);
            }
        }

        public void SwitchUI(LobbyUIs _ui, Action _cb = null) {

            if (LastPopupUI != null)
                LastPopupUI.SetActive(false);//關閉彈出介面

            CloseUIExcept(_ui);//打開目標UI關閉其他UI

            switch (_ui) {
                case LobbyUIs.Lobby://本來在其他介面時，可以傳入Lobby來關閉彈出介面並顯示回預設介面
                    _cb?.Invoke();
                    LastPopupUI = null;
                    break;
                case LobbyUIs.Map:
                    _cb?.Invoke();
                    //LastPopupUI = MyMapUI;
                    break;
                case LobbyUIs.Hero:
                    //LastPopupUI = MyHeroUI;
                    break;
            }
        }

        public override void RefreshText() {
        }

        //void LoadAssets(AdventureUIs _ui, Action _cb) {
        //    switch (_ui) {
        //        case AdventureUIs.Battle:
        //            PopupUI.ShowLoading(StringData.GetUIString("WaitForLoadingUI"));
        //            //初始化UI
        //            AddressablesLoader.GetPrefabByRef(BattleUIAsset, (prefab, handle) => {
        //                PopupUI.HideLoading();
        //                GameObject go = Instantiate(prefab);
        //                go.transform.SetParent(BattleUIParent);

        //                RectTransform rect = go.GetComponent<RectTransform>();
        //                go.transform.localPosition = prefab.transform.localPosition;
        //                go.transform.localScale = prefab.transform.localScale;
        //                rect.offsetMin = Vector2.zero;//Left、Bottom
        //                rect.offsetMax = Vector2.zero;//Right、Top

        //                MyBattleUI = go.GetComponent<BattleUI>();
        //                MyBattleUI.Init();
        //                MyBattleUI.SetBattle();
        //                _cb?.Invoke();
        //            }, () => { WriteLog.LogError("載入BattleUIAsset失敗"); });
        //            break;
        //    }
        //}




    }
}