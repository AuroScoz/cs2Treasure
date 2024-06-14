using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Scoz.Func {
    public class InternetChecker : MonoBehaviour {
        static InternetChecker Instance;
        Action OnConnectedAction;
        Coroutine CheckInternetCoroutine;
        public void Init() {
            Instance = this;
        }
        public static bool InternetConnected {
            get {
                if (Application.internetReachability == 0) //Not reachable at all
                {
                    WriteLog.LogError("No internet connection");
                    return false;
                }
                return true;
            }
        }
        public static void StartCheckInternet(Action _action) {
            Instance.OnConnectedAction = _action;
            Instance.CheckInternetCoroutine = Instance.StartCoroutine(Instance.CheckInternet());
        }


        IEnumerator CheckInternet() {
            if (!InternetConnected) {
                PopupUI.ShowClickCancel(string.Format(JsonString.GetUIString("NoInternetReTry"), "Disconnected"), () => {
                    CheckInternetCoroutine = StartCoroutine(CheckInternet());
                });
                if (CheckInternetCoroutine != null)
                    StopCoroutine(CheckInternetCoroutine);
            }
            using (UnityWebRequest webRequest = UnityWebRequest.Get("https://www.google.com/")) {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();
                switch (webRequest.result) {
                    case UnityWebRequest.Result.ConnectionError:
                        PopupUI.ShowClickCancel(string.Format(JsonString.GetUIString("NoInternetReTry"), webRequest.result), () => {
                            CheckInternetCoroutine = StartCoroutine(CheckInternet());
                        });
                        if (CheckInternetCoroutine != null)
                            StopCoroutine(CheckInternetCoroutine);
                        break;
                    case UnityWebRequest.Result.DataProcessingError:
                        PopupUI.ShowClickCancel(string.Format(JsonString.GetUIString("NoInternetReTry"), webRequest.result), () => {
                            CheckInternetCoroutine = StartCoroutine(CheckInternet());
                        });
                        if (CheckInternetCoroutine != null)
                            StopCoroutine(CheckInternetCoroutine);
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        PopupUI.ShowClickCancel(string.Format(JsonString.GetUIString("NoInternetReTry"), webRequest.result), () => {
                            CheckInternetCoroutine = StartCoroutine(CheckInternet());
                        });
                        if (CheckInternetCoroutine != null)
                            StopCoroutine(CheckInternetCoroutine);
                        break;
                    case UnityWebRequest.Result.Success:
                        if (CheckInternetCoroutine != null)
                            StopCoroutine(CheckInternetCoroutine);
                        OnConnectedAction?.Invoke();
                        break;
                    default:
                        PopupUI.ShowClickCancel(string.Format(JsonString.GetUIString("NoInternetReTry"), webRequest.result), () => {
                            CheckInternetCoroutine = StartCoroutine(CheckInternet());
                        });
                        if (CheckInternetCoroutine != null)
                            StopCoroutine(CheckInternetCoroutine);
                        break;
                }
            }
        }
    }
}
