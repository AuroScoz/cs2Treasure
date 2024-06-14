using Gladiators.Battle;
using Scoz.Func;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Gladiators.Main;

public class BattleSceneUI : BaseUI {
    [HeaderAttribute("==============AddressableAssets==============")]
    [SerializeField] AssetReference BattleManagerAsset;

    [HeaderAttribute("==============UI==============")]
    //TODO:考慮是否之後改腳本產生物件
    //上方角鬥士資訊
    [SerializeField] BattleGladiatorInfo PlayerGladiatorInfo;
    [SerializeField] BattleGladiatorInfo EnemyGladiatorInfo;

    [SerializeField] MyTextPro BattleLeftTime;//戰鬥剩餘時間

    //技能牌
    [SerializeField] BattleSkillButton SkillBtn1;
    [SerializeField] BattleSkillButton SkillBtn2;
    [SerializeField] BattleSkillButton SkillBtn3;
    [SerializeField] BattleSkillButton NextSkillBtn;

    [SerializeField] Image StaminaBar;//使用技能體力條

    [SerializeField] BattleSprintButton SprintBtn;//衝刺按鈕

    [SerializeField] GameObject SettingBtn;//設定按鈕


    [Header("Settings")]
    private bool _isSpellTest;

    public static BattleSceneUI Instance;

    private void Start() {
        Init();
    }
    public override void Init() {
        base.Init();
        SpawnBattleManager();
        Instance = this;

        //先用暫時寫死的技能
        SkillBtn1.SetData(GameDictionary.GetJsonData<JsonSkill>(1)); //這個是碰撞觸發技能
        SkillBtn2.SetData(GameDictionary.GetJsonData<JsonSkill>(2)); //這個是直接觸發技能
        SkillBtn3.SetData(GameDictionary.GetJsonData<JsonSkill>(3)); //這個是直接觸發技能
    }

    void SpawnBattleManager() {
        AddressablesLoader.GetPrefabByRef(BattleManagerAsset, (battleManagerPrefab, handle) => {
            GameObject go = Instantiate(battleManagerPrefab);
            var battleMaanger = go.GetComponent<BattleManager>();
            battleMaanger.Init();
        });
    }

    public override void RefreshText() {

    }

    //TODO:
    //1.秒數倒數 數到0送出戰鬥結束(已完成)
    //2.體力條扣除與自動恢復數值演出
    //3.衝刺操作與演出 做兩種 一種為長壓操作方式 另一種為ON/OFF方式 設參數切換模式(已完成)
    //4.設定按鈕點擊開啟設定介面製作
    //5.技能點擊演出 設參數供調整測試
    //6.血條演出 設參數供調整測試(已完成)

    //更新剩餘秒數
    public void SetTimeText(int num)
    {
        BattleLeftTime.text = num.ToString();
    }

    /// <summary>
    /// 通知施放碰撞觸發技能
    /// </summary>
    public void CastMeleeSkill(JsonSkill _Skill)
    {
        //UI作演出 並把技能使用掉 更新下一個技能上來
        if(SkillBtn1.SkillSelected)
            SkillBtn1.CastMeleeSkill();
        else if(SkillBtn2.SkillSelected)
            SkillBtn2.CastMeleeSkill();
        else if(SkillBtn3.SkillSelected)
            SkillBtn3.CastMeleeSkill();
    }
}
