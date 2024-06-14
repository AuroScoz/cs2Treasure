using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using System;
using UnityEngine.Rendering.Universal;
using LitJson;
using Cysharp.Threading.Tasks;
using Service.Realms;
using Gladiators.Main;
using Gladiators.Socket;
using UnityEditor.Playables;

namespace Scoz.Func {
    public enum DataLoad {
        GameDic,
        FirestoreData,
        AssetBundle,
    }
    public class GameManager : MonoBehaviour {
        public static GameManager Instance;
        public static bool IsInit { get; private set; } = false;
        static bool IsFinishedLoadAsset = false; //是否已經完成初始載包

        [HeaderAttribute("==============AddressableAssets==============")]
        [SerializeField] AssetReference PopupUIAsset;
        [SerializeField] AssetReference PostPocessingAsset;
        [SerializeField] AssetReference AddressableManageAsset;
        [SerializeField] AssetReference GameDictionaryAsset;
        [SerializeField] AssetReference UICanvasAsset;
        [SerializeField] AssetReference UICamAsset;
        [SerializeField] AddressableManage MyAddressableManagerPrefab;
        [SerializeField] AssetReference ResourcePreSetterAsset;
        [SerializeField] AssetReference VideoPlayerAsset;
        [SerializeField] AssetReference TestToolAsset;
        [SerializeField] AssetReference AudioPlayerAsset;
        [SerializeField] AssetReference PoolManagerAsset;

        [Serializable] public class SceneUIAssetDicClass : SerializableDictionary<MyScene, AssetReference> { }
        [HeaderAttribute("==============場景對應入口UI==============")]
        [SerializeField] SceneUIAssetDicClass MySceneUIAssetDic;//字典對應UI字典

        [HeaderAttribute("==============遊戲設定==============")]
        public int TargetFPS = 60;
        public static EnvVersion CurVersion {//取得目前版本
            get {
#if Dev
                return EnvVersion.Dev;
#elif Test
            return EnvVersion.Test;
#elif Release
            return EnvVersion.Release;
#else
                return EnvVersion.Dev;
#endif
            }
        }

        DateTimeOffset LastServerTime;
        DateTimeOffset LastClientTime;
        public DateTimeOffset NowTime {
            get {
                TimeSpan span = DateTimeOffset.Now - LastClientTime;
                return LastServerTime.AddSeconds(span.TotalSeconds);
            }
        }
        /// <summary>
        /// 返回本機時間與UTC+0的時差
        /// </summary>
        public int LocoHourOffset {
            get {
                return (int)TimeZoneInfo.Local.BaseUtcOffset.TotalHours;
            }
        }
        /// <summary>
        /// 返回本機時間與Server的時差
        /// </summary>
        public int LocoHourOffsetToServer {
            get {
                return (int)((DateTimeOffset.Now - NowTime).TotalHours);
            }
        }

        public static void UnloadUnusedAssets() {
            if (!CDChecker.DoneCD("UnloadUnusedAssets", JsonGameSetting.GetFloat(GameSetting.UnloadUnusedAssetsCD)))
                return;
            Resources.UnloadUnusedAssets();
        }

        private void Start() {
            WriteLog.LogColor("GameAssembly的GameManager載入成功", WriteLog.LogType.Addressable);
            Instance = this;
            Instance.Init();
        }



        public void SetTime(DateTimeOffset _serverTime) {
            LastServerTime = _serverTime;
            LastClientTime = DateTimeOffset.Now;
            WriteLog.Log("Get Server Time: " + LastServerTime);
        }

        public void Init() {
            if (IsInit) return;
            Instance = this;
            IsInit = true;

            //// 修改JsonMapper預設的反射數值類型是float而不是double
            //JsonMapper.RegisterImporter((double _value) => {
            //    return (float)_value;
            //});

            DontDestroyOnLoad(gameObject);
            //設定FPS與垂直同步
#if Dev
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 100;
#else
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = TargetFPS;
#endif
            RealmManager.NewApp();//初始化Realm
            //產生一個新玩家
            new GamePlayer();
            //建立FirebaseManager
            //gameObject.AddComponent<FirebaseManager>();
            //建立CoroutineJob
            gameObject.AddComponent<CoroutineJob>();
            //建立InternetChecker
            gameObject.AddComponent<InternetChecker>().Init();
            //建立DeviceManager
            gameObject.AddComponent<DeviceManager>();
            //建立TypeEffector
            gameObject.AddComponent<TextTypeEffector>().Init();
            //建立GameStateManager
            gameObject.AddComponent<GameStateManager>().Init();
            //建立CameraManager
            gameObject.AddComponent<CamManager>().Init();
            //建立UniTaskManager
            gameObject.AddComponent<UniTaskManager>().Init();
            //建立GameConnector
            gameObject.AddComponent<GameConnector>().Init();
            //Permission請求
#if UNITY_ANDROID
            gameObject.AddComponent<AndroidPermission>().RequestLaunchPermissions();
            //gameObject.AddComponent<AndroidPermission>().RequestNotificationPermissions();
#endif
            //初始化文字取代工具
            StringReplacer.Init();
            //初始化遊戲房間
            AllocatedRoom.Init();

            // 建立AddressableManage並開始載包
            StartDownloadAddressable();
        }

        public void CreateResourcePreSetter() {
            Addressables.LoadAssetAsync<GameObject>(Instance.ResourcePreSetterAsset).Completed += handle => {
                GameObject go = Instantiate(handle.Result);
                ResourcePreSetter preSetter = go.GetComponent<ResourcePreSetter>();
                preSetter.Init();
            };
        }


        public void OnAuthFinished(AuthType _authType) {
            // 初始化AppsFlyer
            SetAppsFlyer();
        }

        public void SetAppsFlyer() {
            // 詢問IOS玩家是否要開啟透明追蹤(Appsflyer會用到)
#if APPSFLYER && UNITY_IOS && !UNITY_EDITOR
             AppsFlyerManager.Inst.IOSAskATTUserTrack();
#endif

            //完成分析相關的註冊事件
#if APPSFLYER
                        // 設定玩家UID
                        AppsFlyerManager.Inst.SetCustomerUserId(RealmManager.MyApp.CurrentUser.Id);
                        // AppsFlyer紀錄玩家登入
                        AppsFlyerManager.Inst.Login(RealmManager.MyApp.CurrentUser.Id);
#endif

        }


        /// <summary>
        /// 依序執行以下
        /// 1. 下載Bundle包
        /// 2. 載入SceneCanvas
        /// 3. 將Bundle包中的json資料存起來(JsonDataDic)
        /// 4. 刷新文字介面(會刷新為StringJson的文字) 與 建立PopupUI 與 載入ResourcePreSetter
        /// 5. 根據所在場景產生場景UI
        /// </summary>
        public void StartDownloadAddressable() {
            var addressableManager = Instantiate(MyAddressableManagerPrefab);
            addressableManager.Init();

            AddressablesLoader.GetPrefabByRef(GameDictionaryAsset, (prefab, handle) => {//建立遊戲資料字典
                var dicGO = Instantiate(prefab);
                dicGO.GetComponent<GameDictionary>().InitDic();
                Addressables.Release(handle);
                GamePlayer.Instance.LoadLocoData();
                GameDictionary.LoadJsonDataToDic(() => { //載入Bundle的json資料
                    AddressablesLoader.GetPrefabByRef(UICamAsset, (sceneUIPrefab, handle) => {//載入UICam
                        var camGo = Instantiate(sceneUIPrefab);
                        camGo.GetComponent<UICam>().Init();
                        Addressables.Release(handle);
                        Instance.SpawnPopupUI(() => { //載入PopupUI
                            AddressableManage.Instance.StartLoadAsset(() => { //預載其他Addressable資源
                                Instance.CreateResourcePreSetter();//載入ResourcePreSetter
                                Instance.CreateAddressableObjs();
                                IsFinishedLoadAsset = true;
                                SpawnSceneUI();
                            });
                        });
                    });
                });
            });


        }

        /// <summary>
        /// 根據所在Scene產生UI
        /// 1. 開始遊戲後GameManager跑StartDownloadAddressable完最後會跑這個func
        /// 2. 切換場景會跑這個func(透過AOT反射呼叫)
        /// </summary>
        public static void SpawnSceneUI() {
            if (!IsFinishedLoadAsset) return;
            AddressablesLoader.GetPrefabByRef(Instance.UICanvasAsset, (canvasPrefab, handle) => {//載入UICanvas
                GameObject canvasGO = Instantiate(canvasPrefab);
                canvasGO.GetComponent<UICanvas>().Init();
                var myScene = MyEnum.ParseEnum<MyScene>(SceneManager.GetActiveScene().name);
                AddressablesLoader.GetPrefabByRef(Instance.MySceneUIAssetDic[myScene], (prefab, handle) => {
                    GameObject go = Instantiate(prefab);
                    go.transform.SetParent(canvasGO.transform);
                    go.transform.localPosition = prefab.transform.localPosition;
                    go.transform.localScale = prefab.transform.localScale;
                    RectTransform rect = go.GetComponent<RectTransform>();
                    rect.anchorMin = new Vector2(0, 0);
                    rect.anchorMax = new Vector2(1, 1);
                    rect.offsetMin = rect.offsetMax = Vector2.zero;
                });
            });
        }

        void SpawnPopupUI(Action _ac) {
            //載入PopupUI
            AddressablesLoader.GetPrefabByRef(Instance.PopupUIAsset, (prefab, handle) => {
                GameObject go = Instantiate(prefab);
                go.GetComponent<PopupUI>().Init();
                go.transform.localPosition = Vector2.zero;
                go.transform.localScale = Vector3.one;
                RectTransform rect = go.GetComponent<RectTransform>();
                rect.offsetMin = Vector2.zero;//Left、Bottom
                rect.offsetMax = Vector2.zero;//Right、Top
                Addressables.Release(handle);
                _ac?.Invoke();
            });
        }

        void CreateAddressableObjs() {

            //載入PostProcessingManager
            AddressablesLoader.GetPrefabByRef(Instance.PostPocessingAsset, (prefab, handle) => {
                GameObject go = Instantiate(prefab);
                go.GetComponent<PostProcessingManager>().Init();
                Addressables.Release(handle);
            });
            //載入VideoPlayerManager
            AddressablesLoader.GetPrefabByRef(Instance.VideoPlayerAsset, (prefab, handle) => {
                GameObject go = Instantiate(prefab);
                go.GetComponent<MyVideoPlayer>().Init();
                Addressables.Release(handle);
            });

            //建立AudioPlayer
            AddressablesLoader.GetPrefabByRef(Instance.AudioPlayerAsset, (prefab, handle) => {
                GameObject go = Instantiate(prefab);
                go.GetComponent<AudioPlayer>().Init();
                Addressables.Release(handle);
            });



#if !Release
            //載入TestTool
            AddressablesLoader.GetPrefabByRef(Instance.TestToolAsset, (prefab, handle) => {
                GameObject go = Instantiate(prefab);
                go.GetComponent<TestTool>().Init();
                Addressables.Release(handle);
            });
#endif

        }

        /// <summary>
        /// 將指定camera加入到目前場景上的MainCameraStack中
        /// </summary>
        public void AddCamStack(Camera _cam) {
            if (_cam == null) return;
            Camera mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            if (mainCam == null) return;
            var cameraData = mainCam.GetUniversalAdditionalCameraData();
            if (cameraData == null) return;
            cameraData.cameraStack.Add(_cam);
        }

    }
}
