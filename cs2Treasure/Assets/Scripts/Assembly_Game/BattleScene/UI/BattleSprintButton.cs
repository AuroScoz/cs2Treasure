using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class BattleSprintButton : MonoBehaviour
{
    //兩種操作模式 做兩種用意是為了測試手感哪種比較好 決定用哪種之後再確定介面要怎麼演出
    //1.長壓模式(就是傳統的Press)
    //2.點擊切換On/off
    //TODO:日後確定哪種操作方式後 要補上演出

    [HeaderAttribute("==============TEST==============")]
    [Tooltip("打勾為長壓模式 否則為ON/OFF模式 ON/OFF模式操作方式為點一下ON再點一下OFF")][SerializeField] bool PressMode = true;

    [SerializeField] Text StateText;

    bool IsOn = false; //On/Off模式 true為On false為Off 預設為off 

    public void PressMode_Run()
    {
        if (PressMode)
        {
            Run();
            HideText();
        }
    }

    public void PressMode_Stop()
    {
        if (PressMode)
        {
            StopRun();
            HideText();
        }
    }

    public void OnOffMode_Click()
    {
        if(!PressMode)
        {
            IsOn = !IsOn;
            if(IsOn)
                OnOffMode_Run();
            else
                OnOffMode_Stop();
        }
    }

    void OnOffMode_Run()
    {
        if (!PressMode)
        {
            Run();
            OnText();
        }            
    }

    void OnOffMode_Stop()
    {
        if(!PressMode)
        {
            StopRun();
            OffText();
        }
    }

    void OnText()
    {
        StateText.text = "衝刺中";
    }

    void OffText()
    {
        StateText.text = "行走中";
    }

    void HideText()
    {
        StateText.text = "";
    }

    void Run()
    {
        Debug.Log("衝刺中~~~");
    }

    void StopRun()
    {
        Debug.Log("停止衝刺~~~~");
    }
}