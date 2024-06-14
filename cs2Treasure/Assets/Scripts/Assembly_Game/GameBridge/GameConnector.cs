using Cysharp.Threading.Tasks;
using Gladiators.Main;
using Newtonsoft.Json.Linq;
using Scoz.Func;
using Service.Realms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using UniRx;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gladiators.Socket {
    public partial class GameConnector : MonoBehaviour {
        public static GameConnector Instance = null;

        #region 共用參數設定

        const float RETRY_INTERVAL_SECS = 3.0f; //重連間隔時間
        const int MAX_RETRY_TIMES = 1; //最大重連次數
        const float CONNECT_TIMEOUT_SECS = 60.0f; //連線超時時間60秒
        GladiatorsSocket Socket => GladiatorsSocket.GetInstance();

        #endregion


        public void Init() {
            Instance = this;
            Socket.LogInObservable.Subscribe(_ => OnLoginToMatchmaker(), ex => OnLoginToMatchmakerError().Forget());
            Socket.CreateRoomObservable.Subscribe(OnCreateRoom, OnCreateRoomError);
            Socket.JoinRoomObservable.Subscribe(_ => JoinGameSuccess(), JoinGameFailed);
        }

        /// <summary>
        /// 送RestfulAPI請求
        /// </summary>
        public static async UniTask<object> SendRestfulAPI(string _endPoint, string _valueJson) {
            string baseURL = "https://aurafordev.com/";
            string url = baseURL + _endPoint;
            var token = await RealmManager.GetValidAccessToken();
            string jsonPayload = $"{{\"token\": \"{token}\", \"valueJson\":\"{_valueJson}\"}}";
            var result = await Poster.Post(url, jsonPayload);
            return result;
        }

        void OnDisConnect() {
            WriteLog.LogColor("OnDisConnect", WriteLog.LogType.Connection);
        }

        public void CheckLobbyServerStatus(Action<bool, bool> _cb) {
            WriteLog.LogColor("CheckLobbyServerStatus", WriteLog.LogType.Connection);
        }

    }
}