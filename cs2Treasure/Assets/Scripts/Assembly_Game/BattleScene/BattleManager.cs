using Gladiators.Main;
using Gladiators.Socket;
using Gladiators.Socket.Matchgame;
using Scoz.Func;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Cysharp.Threading.Tasks;
using Unity.Entities.UniversalDelegates;

namespace Gladiators.Battle {
    public class BattleManager : MonoBehaviour {
        public static BattleManager Instance;
        [SerializeField] Camera MyCam;
        public Camera BattleCam => MyCam;

        [SerializeField] int BattleDefaultTime = 60;//設定戰鬥時間

        [SerializeField] bool BattleIsEnd = false;//控制戰鬥是否結束 先序列化出來供測試用
        int BattleLeftTime;

        JsonSkill SelectedMeleeSkill;


        [HeaderAttribute("==============TEST==============")]
        //測試參數區塊
        [Tooltip("重置戰鬥")][SerializeField] bool bResetBattle = false;
        [Tooltip("前端演示測試 打勾表示只使用純前端邏輯模擬")][SerializeField] bool bFrontEndTest = true;

        void Update() {
            if (bResetBattle) {
                ResetBattle();
                bResetBattle = false;
            }
        }

        public void Init() {
            Instance = this;
            SetCam();//設定攝影機模式
            ResetBattle();
            CheckGameState();
        }
        void CheckGameState() {
            switch (AllocatedRoom.Instance.CurGameState) {
                case AllocatedRoom.GameState.NotInGame://本地測試
                    break;
                case AllocatedRoom.GameState.UnAuth://需要等待Matchgame Server回傳Auth成功
                    PopupUI.ShowLoading(JsonString.GetUIString("Loading"));
                    break;
                case AllocatedRoom.GameState.GotPlayer://如果已經收到雙方玩家資料就送Ready
                    GameConnector.Instance.SetReady();
                    break;
            }
        }
        public void GotEnemy() {
            GameConnector.Instance.SetReady();
        }
        public void GoBribe() {
            WriteLog.LogError("開始賄賂");
        }

        void SetCam() {
            //因為戰鬥場景的攝影機有分為場景與UI, 要把場景攝影機設定為Base, UI設定為Overlay, 並在BaseCamera中加入Camera stack
            UICam.Instance.SetRendererMode(CameraRenderType.Overlay);
            AddCamStack(UICam.Instance.MyCam);
        }
        /// <summary>
        /// 將指定camera加入到MyCam的CameraStack中
        /// </summary>
        void AddCamStack(Camera _cam) {
            if (_cam == null) return;
            var cameraData = MyCam.GetUniversalAdditionalCameraData();
            if (cameraData == null) return;
            cameraData.cameraStack.Add(_cam);
        }

        //重啟戰鬥
        void ResetBattle() {
            //相關參數在此重設 設定完才去更新UI
            BattleIsEnd = false;
            BattleLeftTime = BattleDefaultTime;
            ResetBattleSceneUI();
            //TODO:這裡可能需要加入一個延遲等待開場演出
            CountDownBattleTime().Forget();
        }

        //重設戰鬥UI
        void ResetBattleSceneUI() {
            if (BattleSceneUI.Instance == null)
                return;
            BattleSceneUI.Instance.SetTimeText(BattleLeftTime);
        }

        #region 技能施放
        /// <summary>
        /// 施放直接觸發技能
        /// </summary>
        /// <param name="_skill">技能Data</param>
        public void CastInstantSKill(JsonSkill _skill)
        {
            //TODO:在這裡做演出
            if (bFrontEndTest)
            {
                //走前端流程 直接演出
            }
            else
            {
                //走後端流程送包
            }
            Debug.LogFormat("施放直接觸發技能! 技能ID: {0}", _skill.ID);
        }

        /// <summary>
        /// 設定碰撞觸發技能
        /// </summary>
        /// <param name="_skill">技能Data</param>
        /// <param name="_selected">是否選中技能</param>
        public void SetMeleeSkill(JsonSkill _skill, bool _selected)
        {
            //會先把技能存在在此 等到真正碰撞後才會施放
            if (_selected)
            {
                SelectedMeleeSkill = _skill;
                Debug.LogFormat("設定碰撞觸發技能! 技能ID: {0}", _skill.ID);
            }
            else
            {
                SelectedMeleeSkill = null;
                Debug.LogFormat("取消碰撞觸發技能! 技能ID: {0}", _skill.ID);
            }
        }

        /// <summary>
        /// 施放碰撞觸發技能
        /// </summary>
        public void CastMeleeSkill()
        {
            //TODO:實際發生碰撞請呼叫此方法來進行判定
            if (bFrontEndTest)
            {
                //走前端流程 直接演出
                if (SelectedMeleeSkill == null)
                {
                    //沒選技能 則純粹挨打
                    Debug.Log("沒選擇碰撞觸發技能!");
                }
                else
                {
                    //有選技能 施放技能
                    Debug.LogFormat("施放碰撞技能. ID: {0}", SelectedMeleeSkill.ID);
                }
            }
            else
            {
                //走後端流程送包
            }
        }
        #endregion

        //TODO:
        //體力條計算(自動恢復 使用技能消耗 衝刺消耗)
        //對撞計算(傷害計算>>血量 擊退距離>>人物模型位置改變 撞牆判定>>是否被打到邊界 要額外扣血演出 這個建議不要跟傷害一起演出 而是先有撞牆演出後再扣血)
        //血量計算(傷害量/恢復量傳給UI演出)
        //戰鬥結算
        //buff設定

        //戰鬥剩餘秒數計算
        async UniTaskVoid CountDownBattleTime() {
            ReCount:
            //Debug.Log("測試倒數秒數.現在秒數: " + BattleLeftTime);
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            //有可能會發生剩下一秒的時候分出勝負 所以一秒數完還是要再次確認是否已經分出勝負 沒有才繼續數秒
            if (!BattleIsEnd) {
                BattleLeftTime -= 1;
                BattleSceneUI.Instance.SetTimeText(BattleLeftTime);
                if (BattleLeftTime <= 0)
                    BattleEnd();
                else
                    goto ReCount;
            }
            //Debug.Log("結束時間倒數計算!");
        }

        //戰鬥結束
        void BattleEnd() {
            //進入結算環節 避免出bug 如果已經開始結算就不要重複執行
            if (BattleIsEnd) return;
            BattleIsEnd = true;
            Debug.Log("戰鬥結束");
        }

    }
}