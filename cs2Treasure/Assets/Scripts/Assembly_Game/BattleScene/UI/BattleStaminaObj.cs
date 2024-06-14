using Scoz.Func;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 戰鬥體力條元件
/// </summary>
public class BattleStaminaObj : MonoBehaviour {
    
    [SerializeField] Image Icon;
    [SerializeField] Image Bar;
    [SerializeField] Text CurrentVal;
    [SerializeField] Text MaxVal;
    [SerializeField] MyTextPro SkillCostVal1;
    [SerializeField] MyTextPro SkillCostVal2;
    [SerializeField] MyTextPro SkillCostVal3;
    [SerializeField] MyTextPro SkillCostValNext;

    //TODO:
    //1.體力條消耗演出
    //2.體力條補充演出
    //3.技能消耗數值

    public void SetCostVal(int pos, int val)
    {
        switch(pos)
        {
            case 1:
                SkillCostVal1.text = val.ToString();
                break;
            case 2:
                SkillCostVal2.text = val.ToString();
                break;
            case 3:
                SkillCostVal3.text = val.ToString();
                break;
            default:
                SkillCostValNext.text = val.ToString();
                break;
        }
    }
}