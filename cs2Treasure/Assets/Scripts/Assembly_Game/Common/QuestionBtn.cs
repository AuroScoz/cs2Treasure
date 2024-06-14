using Scoz.Func;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gladiators.Main {
    public class QuestionBtn : MonoBehaviour {
        /// <summary>
        /// 開啟遊戲內文字說明
        /// </summary>
        public void OnQuestionBtnClick(string _gameInfoStrID) {
            PopupUI.ShowGameInfo(_gameInfoStrID);
        }
        /// <summary>
        /// 開啟遊戲外網頁
        /// </summary>
        public void OnQuestionBtnClick_URL(string _urlStringID) {
            Application.OpenURL(JsonString.GetUIString(_urlStringID));
        }
        /// <summary>
        /// 開啟遊戲內崁網頁
        /// </summary>
        public void OnQuestionBtnClick_WebViewURL(string _urlStringID) {
            Rect rect = new Rect(0, 0, Screen.width, Screen.height);
            WebViewManager.Inst.ShowWebview(JsonString.GetUIString(_urlStringID), rect);
        }
    }
}