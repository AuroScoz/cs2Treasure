using System.Collections.Generic;
using UnityEngine;
using Scoz.Func;
using UnityEngine.UI;
using Service.Realms;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;

namespace Gladiators.Main {
    public class StartSceneUI : BaseUI {
        [SerializeField] Toggle TermsOfUseToggle;
        [SerializeField] Text VersionText;
        [SerializeField] GameObject GuestLoginBtn;//登入按鈕
        [SerializeField] GameObject ThirdpartBtns;//三方登入按鈕
        [SerializeField] GameObject AppleLoginGO;//蘋果登入
        [SerializeField] GameObject LogutoutGO;//登出
        [SerializeField] GameObject DeleteACGO;//刪除帳戶(蘋果要求)
        [SerializeField] GameObject BackToLobbyGO;//返回大廳按鈕
        [SerializeField] RectTransform QuestReportButton; // 問題回報的按鍵

        /// <summary>
        /// 是否第一次執行遊戲，第一次執行遊戲後會自動進大廳，之後透過從大廳的設定中點回到主介面就不會又自動進大廳了
        /// </summary>
        public static bool FirstTimeLaunchGame { get; private set; } = true;

        public static StartSceneUI Instance { get; private set; }

        public enum Condition {
            HideAll,//隱藏所有按鈕
            NotLogin,//還沒登入就顯示登入按鈕
            OfflineMode,//離線模式
            BackFromLobby_ShowLogoutBtn,//從大廳返回主介面 且 已經是登入狀態，會顯示登出按鈕與返回大廳按鈕
            BackFromLobby_ShowLoginBtn,//從大廳返回主介面 且 已經是登入狀態，會顯示登出按鈕與返回大廳按鈕
        }

        public override void Init() {
            base.Init();
            Instance = this;
        }
        public override void RefreshText() {
        }

        private void Start() {
            Init();
            ShowInfo();//顯示資訊
            // Apple登入要打開
#if UNITY_IOS
            AppleLoginGO.SetActive(true);
#else
            AppleLoginGO.SetActive(false);
#endif
            ShowUI(Condition.HideAll);
            AuthChek();

        }

        /// <summary>
        /// 登入狀態確認
        /// 1. (還沒登入)打開UI介面，讓玩家選擇登入方式
        /// 2. (已登入且第一次開遊戲)開始取同步Realm上的資料，都取完後就開始載Addressable資源包，載完後進入大廳場景(在編輯器模式中，為了測試不會直接進大廳)
        /// 3. (已登入且是從大廳退回主介面)打開UI介面，讓玩家選擇回大廳,登出還是移除帳戶(Apple限定)
        /// </summary>
        void AuthChek() {
            PopupUI.HideLoading();


            //※之後也要新增玩家註冊完但是初始化玩家資料失敗的流程(不太會發生 但要考慮這個可能性)
            //※之後也要新增玩家註冊完但是初始化玩家資料失敗的流程(不太會發生 但要考慮這個可能性)
            //※之後也要新增玩家註冊完但是初始化玩家資料失敗的流程(不太會發生 但要考慮這個可能性)
            //※之後也要新增玩家註冊完但是初始化玩家資料失敗的流程(不太會發生 但要考慮這個可能性)

            if (RealmManager.MyApp.CurrentUser == null) {//尚無Realm帳戶
                WriteLog.LogColor("玩家尚未登入Realm", WriteLog.LogType.Realm);
                ShowUI(Condition.NotLogin);
            } else {//已經有Realm帳戶，就登入Realm

                //是否第一次執行遊戲，第一次執行遊戲後會自動進大廳，之後透過從大廳的設定中點回到主介面就不會又自動進大廳了
                if (FirstTimeLaunchGame) {
                    PopupUI.ShowLoading(JsonString.GetUIString("DataLoading"));
                    UniTask.Void(async () => {
                        await RealmManager.OnSignin();
                        RealmManager.OnDataLoaded();
                        PopupUI.HideLoading();
                        //如果是Dev版本不直接轉場景(Dev版以外會直接進Lobby)
#if Dev
                        ShowUI(StartSceneUI.Condition.BackFromLobby_ShowLogoutBtn);
#else
                        GoLobby();//進入下一個場景
#endif

                    });
                } else {//如果是從大廳點設定回到主介面跑這裡，顯示登出按鈕與返回大廳按鈕
                    ShowUI(StartSceneUI.Condition.BackFromLobby_ShowLogoutBtn);
                }

            }
        }



        public void GoLobby() {
            ShowUI(Condition.HideAll);
            //繞過正式流程
            FirstTimeLaunchGame = false;
            PopupUI.InitSceneTransitionProgress(0);
            PopupUI.CallSceneTransition(MyScene.LobbyScene);
            return;

            /// 根據是否能進行遊戲來執行各種狀態
            /// 1. 判斷玩家版本，若版本低於最低遊戲版本則會跳強制更新
            /// 2. 判斷玩家版本，若版本低於目前遊戲版本則會跳更新建議
            /// 3. 判斷Maintain是否為true，若為true則不在MaintainExemptPlayerUIDs中的玩家都會跳維護中
            /// 4. 判斷該玩家是否被Ban，不是才能進遊戲
            GameStateManager.Instance.StartCheckCanPlayGame(() => {
                FirstTimeLaunchGame = false;
                PopupUI.InitSceneTransitionProgress(0, "LobbyUILoaded");
                PopupUI.CallSceneTransition(MyScene.LobbyScene);
            });
        }



        public void ShowUI(Condition _condition) {
            SetActive(true);
            switch (_condition) {
                case Condition.OfflineMode:
                    ShowLoginUI(false);
                    break;
                case Condition.HideAll:
                    SetActive(false);
                    break;
                case Condition.NotLogin:
                    ShowLoginUI(true);
                    break;
                case Condition.BackFromLobby_ShowLogoutBtn:
                    ShowLoginUI(false);
                    break;
                case Condition.BackFromLobby_ShowLoginBtn:
                    ShowLoginUI(true);
                    break;
            }
        }

        /// <summary>
        /// true:顯示登入按鈕並隱藏登出按鈕
        /// false:顯示登出按鈕並隱藏登入按鈕
        /// </summary>
        void ShowLoginUI(bool _show) {
            GuestLoginBtn.SetActive(_show);
            ThirdpartBtns.SetActive(_show);
            BackToLobbyGO.SetActive(!_show);
            LogutoutGO.SetActive(!_show);
            DeleteACGO.SetActive(!_show);
        }
        /// <summary>
        /// 1. (玩家尚未登入) 顯示版本
        /// 2. (玩家登入) 顯示版本+玩家ID
        /// </summary>
        public void ShowInfo() {
            if (RealmManager.MyApp != null && RealmManager.MyApp.CurrentUser != null)
                VersionText.text = string.Format("new版本: {0} {1} ", Application.version, RealmManager.MyApp.CurrentUser.Id);
            else
                VersionText.text = string.Format("new版本: {0}", Application.version);
        }
        /// <summary>
        /// 登入按鈕按下
        /// </summary>
        public void OnSignupClick(string _authTypeStr) {

            if (!TermsOfUseToggle.isOn) {//沒有勾選同意使用者條款的話會跳彈窗並返回
                PopupUI.ShowClickCancel(JsonString.GetUIString("NeedToAgreeTersOfUse"), null);
                return;
            }

            //錯誤的登入類型就返回
            AuthType authType = AuthType.Guest;
            if (!MyEnum.TryParseEnum(_authTypeStr, out authType)) { WriteLog.LogError("錯誤的登入類型: " + _authTypeStr); return; }

            switch (authType) {
                case AuthType.Guest:

                    if (RealmManager.MyApp.CurrentUser == null) {//玩家還沒登入
                        PopupUI.ShowLoading(string.Format("Loading"));

                        UniTask.Void(async () => {
                            await RealmManager.AnonymousSignup();//Realm訪客註冊
                            ShowUI(Condition.HideAll);
                            await InitPlayerData(authType);//初始化玩家資料
                            RealmManager.OnDataLoaded();
                            PopupUI.HideLoading();
                        });

                    } else {//如果本來就有登入，代表是UI顯示錯誤(登入中的玩家不該點的到訪客註冊)
                        WriteLog.LogError("本來就有登入，代表是UI顯示錯誤(登入中的玩家不該點的到訪客註冊)");
                    }
                    break;
                case AuthType.Facebook:
                    WriteLog.LogError("尚未實作FB登入");
                    //if (RealmManager.MyApp.CurrentUser == null) {//玩家還沒登入Realm，開始進行三方登入
                    //    FBAuth();
                    //} else {//如果玩家本來就有登入Firebase帳戶，代表是從大廳退回主畫面的，此時要登出後再進行三方登入
                    //    PopupUI.ShowConfirmCancel(StringJsonData.GetUIString("OverrideGuestAccountCheck"), () => {
                    //        StartCoroutine(FirebaseManager.Logout(() => {//登出
                    //            FBAuth();
                    //        }));
                    //    }, null);
                    //}
                    break;
                case AuthType.Apple:
                    WriteLog.LogError("尚未實作Apple登入");
                    //if (RealmManager.MyApp.CurrentUser == null) {//玩家還沒登入Firebase，開始進行三方登入
                    //    AppleAuth();
                    //} else {//如果玩家本來就有登入Firebase帳戶，代表是從大廳退回主畫面的，此時要登出後再進行三方登入
                    //    PopupUI.ShowConfirmCancel(StringJsonData.GetUIString("OverrideGuestAccountCheck"), () => {
                    //        StartCoroutine(FirebaseManager.Logout(() => {//登出
                    //            AppleAuth();
                    //        }));
                    //    }, null);
                    //}
                    break;
                case AuthType.Google:
                    WriteLog.LogError("尚未實作Google登入");
                    //#if UNITY_EDITOR
                    //                    PopupUI.ShowClickCancel("Editor不能使用Google登入", null);
                    //#else
                    //                                                    if (RealmManager.MyApp.CurrentUser == null) {//玩家還沒登入Firebase，開始進行三方登入
                    //                                                        GoogleAuth();
                    //                                                    } else {//如果玩家本來就有登入Firebase帳戶，代表是從大廳退回主畫面的，此時要登出後再進行三方登入
                    //                                                        PopupUI.ShowConfirmCancel(StringJsonData.GetUIString("OverrideGuestAccountCheck"), () => {
                    //                                                            StartCoroutine(FirebaseManager.Logout(() => {//登出
                    //                                                                GoogleAuth();
                    //                                                            }));
                    //                                                        }, null);
                    //                                                    }
                    //#endif
                    break;

            }
        }
        /// <summary>
        /// 初始化玩家資料
        /// </summary>
        async UniTask InitPlayerData(AuthType _authType) {
            WriteLog.LogColorFormat("尚無此玩家資料，開始初始化玩家 {0} 的資料", WriteLog.LogType.Realm, RealmManager.MyApp.CurrentUser.Id);
            var replyData = await RealmManager.CallAtlasFunc_InitPlayerData(AuthType.Guest);

            //如果是編輯器不直接轉場景(正式機才會直接進Lobby)
#if UNITY_EDITOR
            ShowUI(StartSceneUI.Condition.BackFromLobby_ShowLogoutBtn);
#else
            GoLobby();//進入下一個場景
#endif

        }
        /// <summary>
        /// 登出帳戶，按下後會登出並顯示回需要登入狀態
        /// </summary>
        public void Logout() {
            //PopupUI.ShowConfirmCancel(StringData.GetUIString("LogoutAccountCheck"), GameSettingData.GetInt(GameSetting.LogoutCowndownSecs), () => {
            //    StartCoroutine(FirebaseManager.Logout(() => {//登出
            //        ShowUI(Condietion.BackFromLobby_ShowLoginBtn);
            //    }));
            //}, null);
        }
        /// <summary>
        /// 移除帳戶，按下後會解除所有平台綁定並登出並顯示回需要登入狀態
        /// </summary>
        public void DeleteAccount() {
            PopupUI.ShowConfirmCancel(JsonString.GetUIString("DeleteAccountCheck"), JsonGameSetting.GetInt(GameSetting.LogoutCowndownSecs), () => {
                UnlinkAllPlatfromsAndLogout();
            }, null);
        }
        /// <summary>
        /// 遞迴解綁所有平台並登出帳戶
        /// </summary>
        void UnlinkAllPlatfromsAndLogout() {
            //if (FirebaseManager.IsLinkingAnyThirdPart) {
            //    if (FirebaseManager.IsLinkingThrdPart(ThirdPartLink.Facebook)) {//還沒綁定就進行綁定
            //        PopupUI.ShowLoading(StringData.GetUIString("UnLinkingFB"));
            //        FirebaseManager.UnlinkFacebook(result => {
            //            PopupUI.HideLoading();
            //            UnlinkAllPlatfromsAndLogout();
            //        });
            //        return;
            //    }
            //    if (FirebaseManager.IsLinkingThrdPart(ThirdPartLink.Apple)) {//還沒綁定就進行綁定
            //        PopupUI.ShowLoading(StringData.GetUIString("UnLinkingApple"));
            //        FirebaseManager.UnlinkApple(result => {
            //            PopupUI.HideLoading();
            //            UnlinkAllPlatfromsAndLogout();
            //        });
            //        return;
            //    }
            //    if (FirebaseManager.IsLinkingThrdPart(ThirdPartLink.Google)) {//還沒綁定就進行綁定
            //        PopupUI.ShowLoading(StringData.GetUIString("UnLinkingGoogle"));
            //        FirebaseManager.UnlinkGoogle(result => {
            //            PopupUI.HideLoading();
            //            UnlinkAllPlatfromsAndLogout();
            //        });
            //        return;
            //    }
            //} else {
            //    PopupUI.ShowLoading(StringData.GetUIString("Loading"));
            //    StartCoroutine(FirebaseManager.Logout(() => {//登出
            //        PopupUI.HideLoading();
            //        ShowUI(Condietion.BackFromLobby_ShowLoginBtn);
            //        PlayerPrefs.DeleteAll();//清除所有本機資料
            //    }));
            //}
        }
        void FBAuth() {
            //PopupUI.ShowLoading(string.Format("Loading"));
            //FirebaseManager.SignInWithFacebook(result => {
            //    PopupUI.HideLoading();
            //    if (!result) {
            //        PopupUI.ShowClickCancel(StringData.GetUIString("SigninFail"), null);
            //    } else {
            //        OnThirdPartAuthFinished(AuthType.Facebook);
            //    }
            //});
        }

        void AppleAuth() {
            //PopupUI.ShowLoading(string.Format("Loading"));
            //FirebaseManager.SignInWithApple(result => {
            //    PopupUI.HideLoading();
            //    if (!result) {
            //        PopupUI.ShowClickCancel(StringData.GetUIString("SigninFail"), null);
            //    } else {
            //        OnThirdPartAuthFinished(AuthType.Apple);
            //    }
            //});
        }
        void GoogleAuth() {
            //PopupUI.ShowLoading(string.Format("Loading"));
            //FirebaseManager.SignInWithGoogle(result => {
            //    PopupUI.HideLoading();
            //    if (!result) {
            //        PopupUI.ShowClickCancel(StringData.GetUIString("SigninFail"), null);
            //    } else {
            //        OnThirdPartAuthFinished(AuthType.Google);
            //    }
            //});
        }



        /// <summary>
        /// 三方登入驗證完成跑這裡
        /// </summary>
        void OnThirdPartAuthFinished(AuthType _authType) {
            // 通知分析註冊完成事件
            GameManager.Instance.OnAuthFinished(_authType);
        }


        /// <summary>
        /// 使用者條款
        /// </summary>
        public void OnTermsOfUseClick() {
            //PopupUI.ShowLoading(StringData.GetUIString("Loading"));
            //FirebaseManager.GetDataByDocID(ColEnum.GameSetting, "BackendURL", (col, dic) => {
            //    PopupUI.HideLoading();
            //    string backendAddress = dic[BackendURLType.BackendAddress.ToString()].ToString();
            //    string userContractURL = dic[BackendURLType.UserContractURL.ToString()].ToString();
            //    string showUrl = string.Concat(backendAddress, userContractURL);
            //    WriteLog.Log($"[OnTermsOfUseClick] showUrl={showUrl}");
            //    Rect rect = new Rect(0, 0, Screen.width, Screen.height);
            //    WebViewManager.Inst.ShowWebview(showUrl, rect);
            //});
        }

        /// <summary>
        /// 隱私權條款
        /// </summary>
        public void OnProtectionPolicyClick() {
            //PopupUI.ShowLoading(StringData.GetUIString("Loading"));
            //FirebaseManager.GetDataByDocID(ColEnum.GameSetting, "BackendURL", (col, dic) => {
            //    PopupUI.HideLoading();
            //    string backendAddress = dic[BackendURLType.BackendAddress.ToString()].ToString();
            //    string protectionPolicyURL = dic[BackendURLType.ProtectionPolicyURL.ToString()].ToString();
            //    string showUrl = string.Concat(backendAddress, protectionPolicyURL);
            //    WriteLog.Log($"[OnProtectionPolicyClick] showUrl={showUrl}");
            //    Rect rect = new Rect(0, 0, Screen.width, Screen.height);
            //    WebViewManager.Inst.ShowWebview(showUrl, rect);
            //});
        }

        public void OnClearBundleClick() {
            AddressableManage.Instance.ReDownload();
        }

        public void OnQuestReportButtonClick() {

            //PopupUI.ShowLoading(StringData.GetUIString("Loading"));
            //string version = Application.version;
            //FirebaseManager.GetDataByDocID(ColEnum.GameSetting, "BackendURL", (col, dic) => {
            //    PopupUI.HideLoading();
            //    string backendAddress = dic[BackendURLType.BackendAddress.ToString()].ToString();
            //    string customerServiceURL = dic[BackendURLType.CustomerServiceURL.ToString()].ToString();
            //    string uid = FirebaseManager.MyUser?.UserId ?? "";
            //    string addUserURL = string.Format(customerServiceURL, version, uid);
            //    string showURL = string.Concat(backendAddress, addUserURL);
            //    WriteLog.Log($"[OnQuestReportButtonClick] showURL = {showURL}, version={version}, uid={uid}");
            //    Rect rect = new Rect(0, 0, Screen.width, Screen.height);
            //    WebViewManager.Inst.ShowWebview(showURL, rect);
            //});

        }


    }
}