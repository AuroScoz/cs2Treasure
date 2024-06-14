using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Scoz.Func {
    public class UniTaskManager : MonoBehaviour {
        public static UniTaskManager Instance { get; private set; }

        static Dictionary<string, CancellationTokenSource> cancellationDic = new Dictionary<string, CancellationTokenSource>();
        static Dictionary<string, Action> actionDic = new Dictionary<string, Action>();
        static Dictionary<string, int> miliSecDic = new Dictionary<string, int>();

        public void Init() {
            Instance = this;
        }

        public static void StartRepeatTask(string taskName, Action task, int miliSecs) {
            if (!Instance) {
                WriteLog.LogError("尚未初始化UniTaskManager");
                return;
            }
            if (cancellationDic.ContainsKey(taskName) || actionDic.ContainsKey(taskName) || miliSecDic.ContainsKey(taskName)) {
                WriteLog.LogWarningFormat("重複的Task名稱：{0}", taskName);
                return;
            }

            var cancellationTokenSource = new CancellationTokenSource();
            cancellationDic.Add(taskName, cancellationTokenSource);
            miliSecDic.Add(taskName, miliSecs);
            actionDic.Add(taskName, task);

            _ = Instance.RepeatTask(taskName, cancellationTokenSource.Token);
        }


        async UniTask RepeatTask(string taskName, CancellationToken cancellationToken) {
            while (!cancellationToken.IsCancellationRequested) {
                try {
                    ExecuteTask(taskName);
                    await UniTask.Delay(miliSecDic[taskName], cancellationToken: cancellationToken);
                } catch (OperationCanceledException) {
                    // 確保當任務被取消時不會拋出異常
                    break;
                } catch (Exception ex) {
                    // 其他未預期的異常
                    WriteLog.LogErrorFormat("RepeatTask錯誤異常 Task名稱：{0}，錯誤訊息：{1}", taskName, ex.Message);
                }
            }
        }

        public static void StartTask(string taskName, Action task, int miliSecs) {
            if (!Instance) {
                WriteLog.LogError("尚未初始化UniTaskManager");
                return;
            }
            if (cancellationDic.ContainsKey(taskName) || actionDic.ContainsKey(taskName) || miliSecDic.ContainsKey(taskName)) {
                WriteLog.LogWarningFormat("重複的Task名稱：{0}", taskName);
                return;
            }

            var cancellationTokenSource = new CancellationTokenSource();
            cancellationDic.Add(taskName, cancellationTokenSource);
            miliSecDic.Add(taskName, miliSecs);
            actionDic.Add(taskName, task);

            _ = Instance.OneTimesTask(taskName, cancellationTokenSource.Token);
        }
        async UniTask OneTimesTask(string taskName, CancellationToken cancellationToken) {
            try {
                await UniTask.Delay(miliSecDic[taskName], cancellationToken: cancellationToken);
                ExecuteTask(taskName);
                StopTask(taskName);
            } catch (OperationCanceledException) {
                // 確保當任務被取消時不會拋出異常
            } catch (Exception ex) {
                // 其他未預期的異常
                WriteLog.LogErrorFormat("OneTimesTask錯誤異常 Task名稱：{0}，錯誤訊息：{1}", taskName, ex.Message);
            } finally {
                StopTask(taskName);
            }
        }

        public static void StopTask(string taskName) {
            if (!Instance) {
                WriteLog.LogError("尚未初始化UniTaskManager");
                return;
            }
            if (!cancellationDic.ContainsKey(taskName)) return;
            cancellationDic[taskName].Cancel();
            cancellationDic[taskName].Dispose(); //CancellationTokenSource有繼承 IDisposable要主動釋放資源
            cancellationDic.Remove(taskName);
            miliSecDic.Remove(taskName);
            actionDic.Remove(taskName);
        }

        void ExecuteTask(string taskName) {
            if (!actionDic.ContainsKey(taskName)) return;
            actionDic[taskName]?.Invoke();
        }
    }
}