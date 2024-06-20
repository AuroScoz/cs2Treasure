using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEngine;
using Scoz.Func;
using System;
using System.Collections;
using UnityEngine.TestTools;
using System.Linq;
using Unity.EditorCoroutines.Editor;

namespace Scoz.Editor {
    public class SwitchVersion {
        //※這裡的版本有新增Dev,Test,Release以外的版本要記得GameManager那邊CurVersion也要新增

        //Firebase版本檔案路徑
        //const string FIREBASE_VERSION_PATH_ANDROID = "VersionSettings/{0}/google-services.json";
        //const string FIREBASE_SETTING_PATH_ANDROID = "Assets/StreamingAssets/google-services.json";
        //const string FIREBASE_VERSION_PATH_IOS = "VersionSettings/{0}/GoogleService-Info.plist";
        //const string FIREBASE_SETTING_PATH_IOS = "Assets/StreamingAssets/GoogleService-Info.plist";
        //const string FIREBASE_EDITOR_FILE = "Assets/StreamingAssets/google-services-desktop.json";


        const string ADDRESABLE_BIN_PATH = "Assets/AddressableAssetsData/{0}/";

        //非Release版本的Defines
        static readonly List<string> UnReleaseDefines = new List<string> { "DEBUG_LOG" };
        static object owner = new System.Object();

        //static Dictionary<EnvVersion, int> FACEBOOK_APP_INDEX_DIC = new Dictionary<EnvVersion, int>() {
        //    { EnvVersion.Dev, 0},
        //    { EnvVersion.Test, 1},
        //    { EnvVersion.Release, 2},
        //};

        public static Dictionary<EnvVersion, string> ADDRESABALE_PROFILE_DIC = new Dictionary<EnvVersion, string>() {
            { EnvVersion.Dev, "GoogleCloud-Dev"},
            { EnvVersion.Test, "GoogleCloud-Test"},
            { EnvVersion.Release, "GoogleCloud-Release"},
        };
        //static Dictionary<EnvVersion, string> PUN_APPID_DIC = new Dictionary<EnvVersion, string>() {
        //    { EnvVersion.Dev, ""},
        //    { EnvVersion.Test, ""},
        //    { EnvVersion.Release, ""},
        //};

        static Dictionary<EnvVersion, string> KEYSTORE_ALIAS_DIC = new Dictionary<EnvVersion, string>() {
            { EnvVersion.Dev, "123456"},
            { EnvVersion.Test, "123456"},
            { EnvVersion.Release, "herofishing"},
        };

        static Dictionary<EnvVersion, string> PACKAGE_NAME_DIC = new Dictionary<EnvVersion, string>() {
            { EnvVersion.Dev, "com.aura.herofishingdev"},
            { EnvVersion.Test, "com.aura.herofishingtest"},
            { EnvVersion.Release, "com.aura.herofishingrelease"},
        };



        [MenuItem("Scoz/SwitchVersion/1. Dev")]
        public static void SwitchToDev() {
            bool isYes = EditorUtility.DisplayDialog("切換環境版本", "切換版本至 " + EnvVersion.Dev.ToString(), "切!", "不好😔");
            if (isYes) {
                RunSwitchVersion(EnvVersion.Dev, result => {
                    if (result) {
                        WriteLog.Log(string.Format("<color=#8cff3f>切換版本 {0} 完成</color>", EnvVersion.Dev));
                    } else {
                        WriteLog.Log(string.Format("<color=#ff3f3f>切換版本 {0} 發生錯誤</color>", EnvVersion.Dev));
                    }
                });

            }
        }
        [MenuItem("Scoz/SwitchVersion/2. Test")]
        public static void SwitchToTest() {
            bool isYes = EditorUtility.DisplayDialog("切換版本", "切換版本至 " + EnvVersion.Test.ToString(), "切!", "不好😔");
            if (isYes) {
                RunSwitchVersion(EnvVersion.Test, result => {
                    if (result) {
                        WriteLog.Log(string.Format("<color=#8cff3f>切換版本 {0} 完成</color>", EnvVersion.Test));
                    } else {
                        WriteLog.Log(string.Format("<color=#ff3f3f>切換版本 {0} 發生錯誤</color>", EnvVersion.Test));
                    }
                });
            }
        }
        [MenuItem("Scoz/SwitchVersion/3. Release")]
        public static void SwitchToRelease() {
            bool isYes = EditorUtility.DisplayDialog("切換版本", "切換版本至 " + EnvVersion.Release.ToString(), "切!", "不好😔");
            if (isYes) {
                isYes = EditorUtility.DisplayDialog("最後警告", "真的要切到版本!!!!!!!!!!!!!!!!! " + EnvVersion.Release.ToString(), "不要怕!", "不好😱");
                RunSwitchVersion(EnvVersion.Release, result => {
                    if (result) {
                        WriteLog.Log(string.Format("<color=#8cff3f>切換版本 {0} 完成</color>", EnvVersion.Release));
                    } else {
                        WriteLog.Log(string.Format("<color=#ff3f3f>切換版本 {0} 發生錯誤</color>", EnvVersion.Release));
                    }
                });

            }
        }
        public static void RunSwitchVersion(EnvVersion _version, Action<bool> _cb) {


            //取代成該版本的Firebase setting
            //FileUtil.ReplaceFile(string.Format(FIREBASE_VERSION_PATH_ANDROID, _version), FIREBASE_SETTING_PATH_ANDROID);
            //FileUtil.ReplaceFile(string.Format(FIREBASE_VERSION_PATH_IOS, _version), FIREBASE_SETTING_PATH_IOS);


            //設定facebook setting
            //if (FACEBOOK_APP_INDEX_DIC.TryGetValue(_version, out int appIndex)) {
            //    Facebook.Unity.Settings.FacebookSettings.SelectedAppIndex = appIndex;
            //    EditorUtility.SetDirty(Facebook.Unity.Settings.FacebookSettings.Instance);
            //} else {
            //    WriteLog.LogError("FacebookSettings error.");
            //    _cb?.Invoke(false);
            //}

            //PUN設定
            //if (PUN_APPID_DIC.TryGetValue(_version, out string punAppID)) {
            //    //有串PUN的話要取消註解
            //    //Photon.Pun.PhotonNetwork.PhotonServerSettings.AppSettings.AppIdRealtime = punAppID;
            //    //EditorUtility.SetDirty(Photon.Pun.PhotonNetwork.PhotonServerSettings);
            //} else {
            //    WriteLog.LogError("PUN APP ID error.");
            //    _cb?.Invoke(false);
            //}

            //登出Firebase
            //FirebaseEditor.SignoutFirebaseAuth();
            //FileUtil.DeleteFileOrDirectory(FIREBASE_EDITOR_FILE);

            //修改Addressable設定
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            settings.ContentStateBuildPath = string.Format(ADDRESABLE_BIN_PATH, _version);
            if (ADDRESABALE_PROFILE_DIC.TryGetValue(_version, out string profileName)) {
                string prfileID = settings.profileSettings.GetProfileId(profileName);
                if (!string.IsNullOrEmpty(prfileID)) {
                    //WriteLog.Log("Profile ID : " + prfileID);
                    settings.activeProfileId = prfileID;//設定目前使用的Addressable Profile
                    //依據版本設定遠端載入的Bundle包位置
                    string remoteLoadPath = @"https://storage.googleapis.com/" + UploadBundle.GOOGLE_STORAGE_PATH_DIC[_version] + @"/{Scoz.Func.VersionSetting.AppLargeVersion}/[BuildTarget]";
                    settings.profileSettings.SetValue(prfileID, "RemoteLoadPath", remoteLoadPath);
                } else {
                    WriteLog.LogError("Addressable prfile setting error.");
                    _cb?.Invoke(false);

                }
            } else {
                WriteLog.LogError("Addressable prfile setting error.");
                _cb?.Invoke(false);
            }
            //修改Keystore
            //if (KEYSTORE_ALIAS_DIC.TryGetValue(_version, out string aliasName)) {
            //    PlayerSettings.Android.keystoreName = "../Key/auro.keystore";
            //    PlayerSettings.Android.keyaliasName = aliasName;
            //}
            //修改package名稱
            if (PACKAGE_NAME_DIC.TryGetValue(_version, out string packageName)) {
                PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, packageName);
                PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, packageName);
            }

            //重新讀取更新後的google-services.json避免沒有刷新問題
            AssetDatabase.Refresh();


            //在這裡寫Log可能會沒用，因為ChangeDefine會呼叫PlayerSettings.SetScriptingDefineSymbolsForGroup之後Unity會自動呼叫CompilationPipeline.RequestScriptCompilation()重新載入Scripts所以會清空log
            //修改PlayerSetting的Define
            //_cb?.Invoke(true);
            EditorCoroutine editorCoroutine = EditorCoroutineUtility.StartCoroutine(ChangeDefineAsync(_version, _cb), owner);
        }

        static IEnumerator ChangeDefineAsync(EnvVersion _envVersion, Action<bool> _cb) {
            try {
                BuildTargetGroup[] buildTargetGroups = new BuildTargetGroup[3] { BuildTargetGroup.Standalone, BuildTargetGroup.Android, BuildTargetGroup.iOS };
                for (int j = 0; j < buildTargetGroups.Length; j++) {
                    string oringinDefine = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroups[j]);
                    List<string> defines = oringinDefine.Split(';').ToList();
                    //依據版本增減Defines
                    if (_envVersion == EnvVersion.Release) {
                        defines.RemoveAll(a => UnReleaseDefines.Contains(a));
                    } else {
                        defines.AddRange(UnReleaseDefines);
                        defines = defines.Distinct().ToList();
                    }

                    string newDefine = "";
                    bool anyVersionDefine = false;

                    for (int i = 0; i < defines.Count; i++) {
                        if (MyEnum.IsTypeOfEnum<EnvVersion>(defines[i])) {
                            defines[i] = _envVersion.ToString();//將本來版本改為要設定的版本
                            anyVersionDefine = true;
                        }
                        defines[i] += ";";
                    }
                    newDefine = string.Concat(defines);
                    if (!anyVersionDefine) {//防止有人把VersionDefine刪掉了
                        newDefine = newDefine + ";" + _envVersion;
                    }

                    PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroups[j], newDefine);
                }
                _cb?.Invoke(true);
            } catch (Exception _ex) {
                _cb?.Invoke(false);
                Debug.LogError(_ex);
            }

            yield return new EditorWaitForSeconds(0.1f);
            //yield return new EditorWaitForSeconds(0.1f);
            //yield return new WaitWhile(() => { return EditorApplication.isCompiling; });
            //yield return WaitForCompilation();
            //WriteLog.LogFormat("<color=#ff833f>[Firebase] <<<<<<<<<<<<<<<<專案ID: {0}>>>>>>>>>>>>>>>> </color>", FirebaseApp.DefaultInstance.Options.ProjectId);

        }
        static IEnumerator WaitForCompilation() {
            //CompilationPipeline.RequestScriptCompilation();
            yield return new RecompileScripts();
        }
    }
}