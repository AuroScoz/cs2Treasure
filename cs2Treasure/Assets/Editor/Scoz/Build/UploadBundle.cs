using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using Scoz.Func;
using UnityEngine;

namespace Scoz.Editor {
    public class UploadBundle {
        const string DIALOG_MESSAGE = "上傳資源包到Google Storage，請確認以下：\n\n1. 已安裝GoogleCloud工具，並完成初始化\n2. 已加入環境變數\n3. 已登入有權限的帳號\n\n環境: {0}\nBundle包版號: {1}\n";
        static Dictionary<EnvVersion, string> GOOGLE_PROJECT_DIC = new Dictionary<EnvVersion, string>() {
            { EnvVersion.Dev, "gladiators-dev"},
            { EnvVersion.Test, "gladiators-test"},
            { EnvVersion.Release, "gladiators-release"},
        };
        public static Dictionary<EnvVersion, string> GOOGLE_STORAGE_PATH_DIC = new Dictionary<EnvVersion, string>() {
            { EnvVersion.Dev, "gladiators_bundle_dev"},
            { EnvVersion.Test, "gladiators_bundle_test"},
            { EnvVersion.Release, "gladiators_bundle_release"},
        };
        [MenuItem("Scoz/UploadBundle/Dev")]
        public static void UploadBundleToDev() {
            bool isYes = EditorUtility.DisplayDialog("上傳資源包", string.Format(DIALOG_MESSAGE, "Dev", VersionSetting.AppLargeVersion), "好!", "先不要><");
            if (isYes)
                UploadGoogleCloud(EnvVersion.Dev);
        }
        [MenuItem("Scoz/UploadBundle/Test")]
        public static void UploadBundleToTest() {
            bool isYes = EditorUtility.DisplayDialog("上傳資源包", string.Format(DIALOG_MESSAGE, "Test", VersionSetting.AppLargeVersion), "好!", "先不要><");
            if (isYes)
                UploadGoogleCloud(EnvVersion.Test);
        }
        [MenuItem("Scoz/UploadBundle/Release")]
        public static void UploadBundleToRelease() {
            bool isYes = EditorUtility.DisplayDialog("上傳資源包", string.Format(DIALOG_MESSAGE, "Release", VersionSetting.AppLargeVersion), "好!", "先不要><");
            if (isYes)
                UploadGoogleCloud(EnvVersion.Release);
        }

        static void UploadGoogleCloud(EnvVersion _envVersion) {
            string googleProjectID = "";
            if (GOOGLE_PROJECT_DIC.TryGetValue(_envVersion, out string id)) {
                googleProjectID = id;
            } else {
                WriteLog.LogError("找不到GPC專案ID：" + _envVersion + " version.");
                return;
            }

            string storagePath = "";
            if (GOOGLE_STORAGE_PATH_DIC.TryGetValue(_envVersion, out string path)) {
                storagePath = path;
            } else {
                WriteLog.LogError("找不到GPC專案ID：" + _envVersion + " version.");
                return;
            }

            var logStrs = new List<string>();

            // start the child process
            Process process = new Process();


            WriteLog.LogFormat("專案ID: {0}  StoragePath: {1}  BundleVersion: {2}", googleProjectID, storagePath, VersionSetting.AppLargeVersion);
#if UNITY_EDITOR_WIN
            // redirect the output stream of the child process.
            string fileName = "UploadBundle.bat";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.StandardOutputEncoding = System.Text.Encoding.UTF8;
            process.StartInfo.StandardErrorEncoding = System.Text.Encoding.UTF8;
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = string.Format("{0} {1} {2}", googleProjectID, storagePath, VersionSetting.AppLargeVersion);
            process.StartInfo.WorkingDirectory = "./";
#elif UNITY_ANDROID
            string fileName = "UploadBundle.bat";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.StandardOutputEncoding = System.Text.Encoding.UTF8;
            process.StartInfo.StandardErrorEncoding = System.Text.Encoding.UTF8;
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = string.Format("{0} {1} {2}", googleProjectID, storagePath, VersionSetting.AppLargeVersion);
            process.StartInfo.WorkingDirectory = "./";
#elif UNITY_EDITOR_OSX
        string fileName = "UploadBundle.sh";
        process.Start();
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.StandardOutputEncoding = System.Text.Encoding.UTF8;
        process.StartInfo.StandardErrorEncoding = System.Text.Encoding.UTF8;
        process.StartInfo.FileName = "/bin/sh";
        process.StartInfo.Arguments = Application.dataPath + string.Format("/../{0} {1} {2} {3}",fileName, googleProjectID, storagePath, VersionSetting.AppLargeVersion);
        process.StartInfo.WorkingDirectory = "./";
#endif
            int exitCode = -1;
            //string output = null;
            WriteLog.Log("命令檔位置：" + process.StartInfo.WorkingDirectory + process.StartInfo.FileName);
            try {

                // 讀取外部執行檔Log
                process.OutputDataReceived += (sender, args) => {
                    if (!string.IsNullOrEmpty(args.Data))
                        logStrs.Add(args.Data);
                };
                process.ErrorDataReceived += (sender, args) => {
                    if (!string.IsNullOrEmpty(args.Data))
                        logStrs.Add(args.Data);
                };

                process.Start();

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                // do not wait for the child process to exit before
                // reading to the end of its redirected stream.
                process.WaitForExit(); // 確保 Unity 等待外部命令檔執行完成

                // 顯示到 Unity 的 Console
                foreach (var str in logStrs) {
                    WriteLog.Log(str);
                }

            } catch (Exception e) {
                WriteLog.LogError("發生錯誤：" + e.ToString()); // or throw new Exception
            } finally {
                exitCode = process.ExitCode;
                process.Dispose();
                process = null;
            }
            if (exitCode != 0) {
                WriteLog.LogError("執行失敗 ExitCode：" + exitCode);
                EditorUtility.DisplayDialog("執行" + fileName, "執行中斷，請查看Console Log", "嗚嗚嗚", "");
            } else {
                WriteLog.Log("執行成功 ExitCode：" + exitCode);
                EditorUtility.DisplayDialog("執行" + fileName, "執行成功，請查看Console Log確保無任何錯誤", "確認", "");
            }
        }
    }
}