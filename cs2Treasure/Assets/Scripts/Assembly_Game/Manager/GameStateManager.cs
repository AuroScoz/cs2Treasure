using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Scoz.Func;
using System.Linq;
using UnityEngine.SceneManagement;
using Service.Realms;

namespace Gladiators.Main {
    public class GameStateManager : MonoBehaviour {
        public static GameStateManager Instance;
        public int ScheduledInGameNotificationIndex = 0;
        public enum CanPlayGameState {
            NeedGetNewVersion,//玩家版本過低，須強制到商店更新
            GotNewVersion,//有新版本可以更新，建議到商店更新
            Maintain,//維護中，只有特定開發者能進遊戲
            Ban,//該玩家被封鎖了，不能進遊戲
            Available,//可以直接進行遊戲
        }
        public void Init() {
            Instance = this;
        }
        /// <summary>
        /// ※登入並載完資源包後會依序執行
        /// 1. 判斷玩家版本，若版本低於最低遊戲版本則會跳強制更新(在MaintainExemptPlayerUIDs中的玩家不會跳更新)
        /// 2. 判斷玩家版本，若版本低於目前遊戲版本則會跳更新建議(在MaintainExemptPlayerUIDs中的玩家不會跳更新)
        /// 3. 判斷Maintain是否為true，若為true則不在MaintainExemptPlayerUIDs中的玩家都會跳維護中
        /// 4. 判斷該玩家是否被Ban，不是才能進遊戲
        /// </summary>
        public CanPlayGameState GetCanPlayGameState(DBGameSetting _gameState) {

            WriteLog.LogFormat("LocoVer: {0}", Application.version);
            WriteLog.LogFormat("GameVersion: {0}", _gameState.GameVersion);
            WriteLog.LogFormat("MinimumGameVersion: {0}", _gameState.MinGameVersion);

            var playerDoc = GamePlayer.Instance.GetDBPlayerDoc<DBPlayer>();

            //黑名單檢查
            if (playerDoc.Ban ?? false) return CanPlayGameState.Ban;

            //維護中檢查
            if (_gameState.Maintain == true) {
                if (!_gameState.MaintainExemptPlayerIDs.Contains(playerDoc.ID))//白名單中的玩家不會跳維護
                    return CanPlayGameState.Maintain;
            }

            //強制版本更新檢查
            if (!TextManager.AVersionGreaterEqualToBVersion(Application.version, _gameState.MinGameVersion)) {
                if (!_gameState.MaintainExemptPlayerIDs.Contains(playerDoc.ID))//白名單中的玩家不會跳強制更新
                    return CanPlayGameState.NeedGetNewVersion;
            }

            //可版本更新檢查
            if (!TextManager.AVersionGreaterEqualToBVersion(Application.version, _gameState.GameVersion)) {
                return CanPlayGameState.GotNewVersion;
            }

            return CanPlayGameState.Available;
        }

        /// <summary>
        /// 剛開始進遊戲時檢測是否可以進遊戲用，不能進入遊戲就跳對應的通知視窗
        /// </summary>
        public void StartCheckCanPlayGame(Action _passAction) {
            var gameState = RealmManager.MyRealm.Find<DBGameSetting>(DBGameSettingDoc.GameState.ToString());
            var address = RealmManager.MyRealm.Find<DBGameSetting>(DBGameSettingDoc.Address.ToString());
            var state = GetCanPlayGameState(gameState);
            switch (state) {
                case CanPlayGameState.Available://可直接進行遊戲
                    _passAction?.Invoke();
                    break;
                case CanPlayGameState.GotNewVersion://有新版本(不強制更新)
                    string url = address.StoreURL_Apple;
                    if (Application.platform == RuntimePlatform.Android)
                        url = address.StoreURL_Google;
                    PopupUI.ShowConfirmCancel(JsonString.GetUIString(state.ToString()), () => {
                        //點確認就去商店更新並關閉遊戲
                        Application.OpenURL(url);
                        Application.Quit();
                    }, () => {
                        //點取消
                        _passAction?.Invoke();
                    });
                    break;
                case CanPlayGameState.NeedGetNewVersion://有新版本(強制更新)
                    string url2 = address.StoreURL_Apple;
                    if (Application.platform == RuntimePlatform.Android)
                        url2 = address.StoreURL_Google;
                    PopupUI.ShowClickCancel(JsonString.GetUIString(state.ToString()), () => {
                        //點擊後就去商店更新並關閉遊戲
                        Application.OpenURL(url2);
                        Application.Quit();
                    });
                    break;
                case GameStateManager.CanPlayGameState.Maintain://維護中
                    if (GameManager.Instance.NowTime < gameState.MaintainEndAt) {
                        PopupUI.ShowClickCancel(string.Format(JsonString.GetUIString("MaintainWithTime"), gameState.MaintainEndAt), () => {
                            //點擊後關閉遊戲
                            Application.Quit();
                        });
                    } else {
                        PopupUI.ShowClickCancel(JsonString.GetUIString("Maintain"), () => {
                            //點擊後關閉遊戲
                            Application.Quit();
                        });
                    }
                    break;
                case GameStateManager.CanPlayGameState.Ban://玩家被Ban
                    PopupUI.ShowClickCancel(JsonString.GetUIString(state.ToString()), () => {
                        //點擊後就跳至官方客服網頁並關閉遊戲
                        Application.OpenURL(address.CustomerServiceURL);
                        Application.Quit();
                    });
                    break;
                default:
                    WriteLog.LogError("尚未定義的CanPlayGameState類型: " + state);
                    break;
            }
        }

        /// <summary>
        /// 玩家玩到一半時檢測是否可以繼續進行遊戲用，並跳對應的通知視窗
        /// 1. 不在StartScene時，GameData-Setting>Version資料更新時被呼叫
        /// 2. 不在StartScene時，每1分鐘被呼叫
        /// 3. 玩家自己的PlayerData-Player更新且Ban為true時被呼叫
        /// </summary>
        public void InGameCheckCanPlayGame() {
            if (SceneManager.GetActiveScene().name == MyScene.StartScene.ToString()) return;//不在StartScene時才會執行
            var gameState = RealmManager.MyRealm.Find<DBGameSetting>(DBGameSettingDoc.GameState.ToString());
            var address = RealmManager.MyRealm.Find<DBGameSetting>(DBGameSettingDoc.Address.ToString());
            var state = GetCanPlayGameState(gameState);
            switch (state) {
                case GameStateManager.CanPlayGameState.Available://可直接進行遊戲
                    break;
                case GameStateManager.CanPlayGameState.GotNewVersion://有新版本(不強制更新)
                    break;
                case GameStateManager.CanPlayGameState.NeedGetNewVersion://有新版本(強制更新)
                    string url = address.StoreURL_Apple;
                    if (Application.platform == RuntimePlatform.Android)
                        url = address.StoreURL_Google;
                    PopupUI.ShowClickCancel(JsonString.GetUIString(state.ToString()), () => {
                        //點擊後就去商店更新並關閉遊戲
                        Application.OpenURL(url);
                        Application.Quit();
                    });
                    break;
                case GameStateManager.CanPlayGameState.Maintain://維護中
                    if (GameManager.Instance.NowTime < gameState.MaintainEndAt) {
                        PopupUI.ShowClickCancel(string.Format(JsonString.GetUIString("MaintainWithTime"), gameState.MaintainEndAt), () => {
                            //點擊後關閉遊戲
                            Application.Quit();
                        });
                    } else {
                        PopupUI.ShowClickCancel(JsonString.GetUIString("Maintain"), () => {
                            //點擊後關閉遊戲
                            Application.Quit();
                        });
                    }
                    break;
                case GameStateManager.CanPlayGameState.Ban://玩家被Ban
                    PopupUI.ShowClickCancel(JsonString.GetUIString(state.ToString()), () => {
                        //點擊後就跳至官方客服網頁並關閉遊戲
                        Application.OpenURL(address.CustomerServiceURL);
                        Application.Quit();
                    });
                    break;
                default:
                    WriteLog.LogError("尚未定義的CanPlayGameState類型: " + state);
                    break;
            }
        }
    }
}