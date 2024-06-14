
using UnityEngine;
using UnityEditor;
using Service.Realms;
using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

public class RealmEditor : MonoBehaviour {
    [MenuItem("Scoz/Realm/Signout")]
    public static async UniTask SignoutRealmAuth() {
        RealmManager.NewApp(); // 創建 Realm App
        if (RealmManager.MyApp == null) { Debug.Log("無法取得Realm App"); return; }
        if (RealmManager.MyApp.CurrentUser == null) { Debug.Log("玩家尚未登入"); return; }
        try {
            Debug.Log("開始登出Realm...");

            var task = RealmManager.MyApp.CurrentUser.LogOutAsync();
            var delay = Task.Delay(TimeSpan.FromSeconds(2));//超時處理
            await Task.WhenAny(task, delay).ConfigureAwait(false);

            //if (delay.IsCompleted) {
            //    Debug.Log("登出操作超時");
            //}

            Debug.Log("登出Realm完成!");
            //await UniTask.SwitchToMainThread();
            //AssetDatabase.Refresh();

        } catch (Exception _e) {
            Debug.LogError("登出錯誤: " + _e.Message);
            Debug.LogError("Stack Trace: " + _e.StackTrace);
        }
    }
}

