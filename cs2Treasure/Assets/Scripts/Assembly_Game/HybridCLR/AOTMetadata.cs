using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ※這裡遊戲中會透過反射來取資料所以不要追加命名空間或更名, 否則反射會抓不到
public static class AOTMetadata {
    public static List<string> AotDllList = new List<string> {"Cinemachine.dll",
		"DOTween.dll",
		"FlutterUnityIntegration.dll",
		"LitJson.dll",
		"Loxodon.Framework.dll",
		"Realm.dll",
		"SerializableDictionary.dll",
		"System.Core.dll",
		"System.dll",
		"UniRx.dll",
		"UniTask.dll",
		"Unity.Addressables.dll",
		"Unity.Burst.dll",
		"Unity.Collections.dll",
		"Unity.Entities.Hybrid.dll",
		"Unity.Entities.dll",
		"Unity.RenderPipelines.Core.Runtime.dll",
		"Unity.ResourceManager.dll",
		"Unity.VisualScripting.Core.dll",
		"UnityEngine.AndroidJNIModule.dll",
		"UnityEngine.CoreModule.dll",
		"mscorlib.dll",};
}
