
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.AddressableAssets.ResourceLocators;
using System.Linq;
using UnityEngine.ResourceManagement.ResourceLocations;
using Unity.VisualScripting;
using Cysharp.Threading.Tasks;

namespace Scoz.Func {

    [Serializable]
    public sealed class AddressableManage_UnityAssembly : MonoBehaviour {
        public static AddressableManage_UnityAssembly Instance;

        public List<string> Keys = null;
        [SerializeField] Image ProgressImg = null;
        [SerializeField] Text ProgressText = null;
        [SerializeField] GameObject DownloadGO = null;
        [SerializeField] GameObject BG;
        Coroutine CheckInternetCoroutine = null;
        Action FinishedAction = null;

        static HashSet<AsyncOperationHandle> ResourcesToReleaseWhileChangingScene = new HashSet<AsyncOperationHandle>();//加入到此清單的資源Handle會在切場景時一起釋放
        void Awake() {
            BG.SetActive(false);
            ShowDownloadUI(false);
        }
        void Start() {
            SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }

        void OnDestroy() {
            SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }
        void OnLevelFinishedLoading(Scene _scene, LoadSceneMode _mode) {
        }

        /// <summary>
        /// 加入到此清單的資源Handle會在切場景時一起釋放
        /// </summary>
        /// <param name="_handle">要釋放的Addressables Handle</param>
        public static void SetToChangeSceneRelease(AsyncOperationHandle _handle) {
            if (ResourcesToReleaseWhileChangingScene.Contains(_handle)) return;
            ResourcesToReleaseWhileChangingScene.Add(_handle);
        }


        public static AddressableManage_UnityAssembly CreateNewAddressableManage() {
            if (Instance != null) {
            } else {
                GameObject prefab = Resources.Load<GameObject>("Prefabs/Common/AddressableManage_UnityAssembly");
                GameObject go = Instantiate(prefab);
                go.name = "AddressableManage_UnityAssembly";
                Instance = go.GetComponent<AddressableManage_UnityAssembly>();
                DontDestroyOnLoad(Instance.gameObject);
            }
            return Instance;
        }
        IEnumerator ClearAllCache(Action _cb) {
            /*沒辦法清 常常會報錯 但偶爾又不會
            AsyncOperationHandle handler = Addressables.ClearDependencyCacheAsync(Keys, false);
            yield return handler;
            Addressables.Release(handler);
            */
            yield return null;
            //Addressables.ClearResourceLocators();
            //AssetBundle.UnloadAllAssetBundles(true);
            if (Caching.ClearCache()) {
                WriteLog_UnityAssembly.Log("Successfully cleaned the cache");
                _cb?.Invoke();
            } else {
                WriteLog_UnityAssembly.Log("Cache is being used");
                _cb?.Invoke();
            }

            //ProgressImg.fillAmount = 0;
            //顯示載入進度文字
            ProgressText.text = StringJsonData_UnityAssembly.GetUIString("ReDownload");
            WriteLog_UnityAssembly.Log("重新載入中....................");
        }
        Coroutine Downloader;
        public void StartLoadAsset(Action _action) {
            BG.SetActive(false);
            WriteLog_UnityAssembly.LogColor("LoadAsset-Start", WriteLog_UnityAssembly.LogType.Addressable);
            Keys.RemoveAll(a => a == "");
#if UNITY_EDITOR
            Keys.RemoveAll(a => a == "Dlls");//編輯器不需要載入Dlls
#endif
            PopupUI_Local.ShowLoading(StringJsonData_UnityAssembly.GetUIString("AddressableLoading"));
            FinishedAction = _action;
            Downloader = StartCoroutine(LoadAssets());//不輕快取用這個(正式版)
        }
        void OnClearCatchCB() {
            Downloader = StartCoroutine(LoadAssets());
        }
        public void ReDownload() {
            if (Downloader != null)
                StopCoroutine(Downloader);
            StartCoroutine(ClearAllCache(OnClearCatchCB));
        }
        IEnumerator WaitForCheckingBundle() {
            yield return new WaitForSeconds(20);
            if (CheckInternetCoroutine != null)
                StopCoroutine(CheckInternetCoroutine);
            PopupUI_Local.ShowClickCancel(StringJsonData_UnityAssembly.GetUIString("NoInternetShutDown"), "",() => {
                Application.Quit();
            });
        }

        IEnumerator LoadAssets() {
            //var handle = Addressables.LoadAssetAsync<TextAsset>("Assets/AddressableAssets/Jsons/String.json");
            //yield return handle;  // 如果在協程中
            //WriteLog.Log(handle.Status);
            //WriteLog.Log(handle.Result);

            PopupUI_Local.HideLoading();//開始抓到bundle包就取消loading
            yield return new WaitForSeconds(0.1f);

            //等待20秒若時間到還沒載到資源包需求內容就當網路錯誤
            if (CheckInternetCoroutine != null)
                StopCoroutine(CheckInternetCoroutine);
            CheckInternetCoroutine = StartCoroutine(WaitForCheckingBundle());
            //取Bundle包大小
            AsyncOperationHandle<long> getDownloadSize = Addressables.GetDownloadSizeAsync(Keys);
            yield return getDownloadSize;
            long totalSize = getDownloadSize.Result;
            WriteLog_UnityAssembly.LogColorFormat("LoadAsset-TotalSize={0}", WriteLog_UnityAssembly.LogType.Addressable, MyMath_UnityAssembly.BytesToMB(totalSize).ToString("0.00"));

            //已經抓到資料就取消Coroutine
            if (CheckInternetCoroutine != null)
                StopCoroutine(CheckInternetCoroutine);

            if (totalSize > 0) {//有要下載跳訊息
                string downloadStr = string.Format(StringJsonData_UnityAssembly.GetUIString("StartDownloadAsset"), MyMath_UnityAssembly.BytesToMB(totalSize).ToString("0.00"));
                PopupUI_Local.ShowClickCancel(downloadStr,"", () => {
                    //顯示下載條
                    ShowDownloadUI(true);
                    StartCoroutine(Loading(totalSize));
                });
            } else {//沒需要下載就直接跳到完成
                OnFinishedDownload();
                yield break;
            }

        }
        IEnumerator Loading(long _totalSize) {
            //開始下載
            AsyncOperationHandle curDownloading = new AsyncOperationHandle();
            curDownloading = Addressables.DownloadDependenciesAsync(Keys, Addressables.MergeMode.Union);
            bool downloading = true;
            while (downloading) {
                float curDownloadPercent = curDownloading.GetDownloadStatus().Percent;
                long curDownloadSize = (long)(curDownloadPercent * _totalSize);

                //顯示載入進度與文字
                ProgressImg.fillAmount = curDownloadPercent;
                ProgressText.text = string.Format(StringJsonData_UnityAssembly.GetUIString("AssetUpdating"), MyMath_UnityAssembly.BytesToMB(curDownloadSize).ToString("0.00"), MyMath_UnityAssembly.BytesToMB(_totalSize).ToString("0.00"));
                //完成後跳出迴圈

                if (curDownloading.GetDownloadStatus().IsDone) {
                    Addressables.Release(curDownloading); // Addressable1.21.15版本更新後，必須要在載完資源後釋放，否則LoadAssetAsync會取不到資源
                    downloading = false;
                }
                yield return new WaitForSeconds(0.1f);
            }
            OnFinishedDownload();
        }

        void OnFinishedDownload() {
            ShowDownloadUI(false);
            WriteLog_UnityAssembly.LogColorFormat("LoadAsset-Finished", WriteLog_UnityAssembly.LogType.Addressable);
            FinishedAction?.Invoke();

        }
        public static void PreLoadToMemory(Action _ac = null) {
            DateTime now = DateTime.Now;
            WriteLog_UnityAssembly.LogErrorFormat("開始下載MaJam資源圖");
            //初始化UI
            Addressables.LoadAssetsAsync<Texture>("MaJam", null).Completed += handle => {
                WriteLog_UnityAssembly.LogErrorFormat("載入MaJam花費: {0}秒", (DateTime.Now - now).TotalSeconds);
                _ac?.Invoke();
            };
        }
        public void ShowDownloadUI(bool _show) {
            DownloadGO.gameObject.SetActive(_show);
            if (_show) {
                ProgressImg.fillAmount = 0;
                ProgressText.text = StringJsonData_UnityAssembly.GetUIString("Downloading");
            }
        }



        /// <summary>
        /// 傳入Addressable的key確認此Addressable是否存在
        /// </summary>
        public void CheckIfAddressableExist(List<string> _keys, Action<bool> _cb) {
            StartCoroutine(CheckIfAddressableExistCoroutine(_keys, _cb));
        }
        IEnumerator CheckIfAddressableExistCoroutine(List<string> _keys, Action<bool> _cb) {
            if (_keys == null || _keys.Count == 0) {
                _cb?.Invoke(false);
                yield break;
            }

            var locationHandle = Addressables.LoadResourceLocationsAsync(_keys, Addressables.MergeMode.Union);
            yield return locationHandle;
            if (locationHandle.Result.Count == 0) {//為0代表沒有此資源包
                _cb?.Invoke(false);
                yield break;
            }
            _cb?.Invoke(true);
        }

        /// <summary>
        /// 傳入Addressable的key取得下載大小(mb)(用於App玩到一半才有載入需求的資源)
        /// </summary>
        public void GetDownloadAddressableSize(List<string> _keys, Action<float> _cb) {
            CheckIfAddressableExist(_keys, result => {
                if (result == true) {
                    StartCoroutine(GetDownloadAddressableSizeCoroutine(_keys, _cb));
                } else {
                    _cb?.Invoke(0);
                }
            });

        }
        IEnumerator GetDownloadAddressableSizeCoroutine(List<string> _keys, Action<float> _cb) {
            if (_keys == null && _keys.Count == 0) {
                _cb?.Invoke(0);
                yield break;
            }

            //取Bundle包大小
            AsyncOperationHandle<long> getDownloadSize = Addressables.GetDownloadSizeAsync(_keys);
            yield return getDownloadSize;
            long totalSize = getDownloadSize.Result;
            float mb = MyMath_UnityAssembly.BytesToMB(totalSize);
            _cb?.Invoke(mb);
        }

        /// <summary>
        /// 傳入Addressable的key目標下載大小(mb)(用於App玩到一半才有載入需求的資源)
        /// </summary>
        public void DownloadAddressable(List<string> _keys, bool _showBG, Action<bool> _cb) {
            CheckIfAddressableExist(_keys, result => {
                if (result == true) {
                    StartCoroutine(DownloadAddressableCheck(_keys, _showBG, _cb));
                } else {
                    _cb?.Invoke(false);
                }
            });
        }
        IEnumerator DownloadAddressableCheck(List<string> _keys, bool _showBG, Action<bool> _cb) {
            if (_keys == null || _keys.Count == 0) {
                _cb?.Invoke(false);
                yield break;
            }

            //取Bundle包大小
            AsyncOperationHandle<long> getDownloadSize = Addressables.GetDownloadSizeAsync(_keys);
            yield return getDownloadSize;


            long totalSize = getDownloadSize.Result;
            WriteLog_UnityAssembly.Log("Download TotalSize=" + totalSize);
            if (totalSize > 0) {//有要下載跳訊息
                string downloadStr = string.Format(StringJsonData_UnityAssembly.GetUIString("StartDownloadAsset"), MyMath_UnityAssembly.BytesToMB(totalSize).ToString("0.00"));
                //顯示下載條
                ShowDownloadUI(true);
                StartCoroutine(DownloadingAddressable(_keys, totalSize, _showBG, _cb));
                /*
                PopupUI.ShowConfirmCancel(downloadStr, () => {

                }, () => {
                    _cb?.Invoke(false);//取消下載
                });
                */
            } else {//沒需要下載就直接跳到完成
                _cb?.Invoke(true);
                yield break;
            }

        }
        IEnumerator DownloadingAddressable(List<string> _keys, long _totalSize, bool _showBG, Action<bool> _cb) {
            AsyncOperationHandle curDownloading = new AsyncOperationHandle();
            curDownloading = Addressables.DownloadDependenciesAsync(_keys, Addressables.MergeMode.Union);
            bool downloading = true;
            BG.SetActive(_showBG);
            while (downloading) {

                float curDownloadPercent = curDownloading.GetDownloadStatus().Percent;
                long curDownloadSize = (long)(curDownloadPercent * _totalSize);

                //顯示載入進度與文字
                ProgressImg.fillAmount = curDownloadPercent;
                ProgressText.text = string.Format(StringJsonData_UnityAssembly.GetUIString("AssetUpdating"), MyMath_UnityAssembly.BytesToMB(curDownloadSize).ToString("0.00"), MyMath_UnityAssembly.BytesToMB(_totalSize).ToString("0.00"));
                //完成後跳出迴圈
                if (curDownloading.GetDownloadStatus().IsDone) {
                    Addressables.Release(curDownloading); // Addressable1.21.15版本更新後，必須要在載完資源後釋放，否則LoadAssetAsync會取不到資源
                    downloading = false;
                }

                yield return new WaitForSeconds(0.1f);
            }

            ShowDownloadUI(false);
            BG.SetActive(false);
            _cb?.Invoke(true);
        }

    }
}