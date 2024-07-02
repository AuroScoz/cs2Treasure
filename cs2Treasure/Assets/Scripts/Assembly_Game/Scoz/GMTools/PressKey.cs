using UnityEngine;
using Service.Realms;
using System.Linq;
using cs2Treasure.Socket;
using cs2Treasure.Main;
using UnityEngine.SceneManagement;
using System;
using Cysharp.Threading.Tasks;
using cs2Treasure.Main;

namespace Scoz.Func {
    public partial class TestTool : MonoBehaviour {

        [SerializeField] GameObject ToolGO;

        public static Animator MyAni;
        int key = 0;
        // Update is called once per frame
        void KeyDetector() {


            if (Input.GetKeyDown(KeyCode.Q)) {

            } else if (Input.GetKeyDown(KeyCode.W)) {
                UniTask.Void(async () => {
                    var bsonDoc = await RealmManager.Query_GetDoc("player", GamePlayer.Instance.GetDBPlayerDoc<DBPlayer>().ID);
                    WriteLog.LogError("bsonDoc=" + bsonDoc);
                });


            } else if (Input.GetKeyDown(KeyCode.E)) {

            } else if (Input.GetKeyDown(KeyCode.R)) {

            } else if (Input.GetKeyDown(KeyCode.P)) {
            } else if (Input.GetKeyDown(KeyCode.O)) {
                Action connFunc = null;
                if (SceneManager.GetActiveScene().name != MyScene.MainScene.ToString())
                    PopupUI.CallSceneTransition(MyScene.MainScene);//跳轉到MainScene
                PopupUI.ShowLoading(JsonString.GetUIString("Loading"));
                connFunc = () => GameConnector.Instance.ConnectToMatchgameTestVer(() => {
                    PopupUI.HideLoading();
                }, () => {
                    WriteLog.LogError("連線遊戲房失敗");
                }, () => {
                    if (AllocatedRoom.Instance.CurGameState == AllocatedRoom.GameState.Playing) {
                        WriteLog.LogError("需要斷線重連");
                        connFunc();
                    }
                });
                connFunc();
            } else if (Input.GetKeyDown(KeyCode.I)) {

            } else if (Input.GetKeyDown(KeyCode.L)) {
            }
        }


        public void OnModifyHP(int _value) {
        }
        public void OnModifySanP(int _value) {
        }
        public void ClearLocoData() {
            PlayerPrefs.DeleteAll();
        }

    }
}
