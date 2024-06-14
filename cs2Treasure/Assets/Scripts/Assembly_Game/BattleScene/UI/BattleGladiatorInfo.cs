using UnityEngine;
using UnityEngine.UI;
using Scoz.Func;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Cysharp.Threading.Tasks;
using Codice.Utils;
using System.Threading;
using Unity.Mathematics;
using Unity.Entities.UniversalDelegates;
using DG.Tweening;
using System;

/// <summary>
/// 上方角鬥士資訊
/// </summary>
public class BattleGladiatorInfo : MonoBehaviour {
    
    [HeaderAttribute("==============UI==============")]
    [SerializeField] MyText HeroName;
    [SerializeField] Image HeroIcon;
    [SerializeField] Image HPChangeBar;
    [SerializeField] Transform CloneHPChangerBarTrans;
    [SerializeField] Image HPBar;
    [SerializeField] Image HPBarGray;
    [SerializeField] Image HPBarWhite;
    [SerializeField] Transform HeartBeatIconTrans; //心跳Icon物件
    [SerializeField] Image HeartBeatIcon;
    [SerializeField] Transform HeartBeatGrayIconTrans;
    [SerializeField] Image HeartBeatGrayIcon;
    [SerializeField] Transform BuffIconTrans;

    //TODO:buff管理集合
    //Dictionary<

    [HeaderAttribute("==============TEST==============")]
    [HeaderAttribute("=========受擊血量變動測試=========")]
    [Tooltip("測試血量扣減演出")][SerializeField] bool PerformHPReduce = false;
    [Tooltip("血量起始值 0~1 此值大於BarFinalVal表示扣血")][SerializeField] float BarStartVal = 1f;
    [Tooltip("血量剩餘值 0~1 此值大於BarStartVal表示回血")][SerializeField] float BarFinalVal = 0.7f;
    [Tooltip("血量變化停滯秒數 就是被打掉的或者恢復量的血條殘留時間")][SerializeField] float BarChangeSecDelay = 1f;
    [Tooltip("血量變化演出秒數 越短就越快")][SerializeField] float BarChangeSecNeed = 1f;
    [Tooltip("血量變化演出偵數 即每秒血條變化張數")][SerializeField] float BarChangeFrame = 60f;
    [Tooltip("心跳受擊旋轉角度")][SerializeField] Vector3 HittedRotateAngle = new Vector3(0f, 0f, 10f);
    [Tooltip("心跳受擊旋轉演出時間 即旋轉過去加轉回去的時間")][SerializeField] float HittedRotateDuration = 1f;
    [Tooltip("心跳受擊變色持續時間")][SerializeField] float HittedColorDuration = 1f;
    [Tooltip("受擊白色血條顯示時間")][SerializeField] float HittedHPBarWhiteDuration = 0.5f;
    [Tooltip("每扣多少%血量就產生一個殘影 數值為0(不含0)~1 數值越小越耗效能 殘影也越密集")][SerializeField] float HPRateGenerateAfterImage = 0.05f;
    [Tooltip("殘影滯留秒數")][SerializeField] float AfterImageDuration = 0.5f;
    [Tooltip("黑白血量變化停滯秒數 就是被打掉的或者恢復量的血條殘留時間")][SerializeField] float BarGrayChangeSecDelay = 0.4f;
    [Tooltip("黑白血條演出秒數 越短就越快")][SerializeField] float BarGrayChangeSecNeed = 0.4f;
    [HeaderAttribute("==============心臟跳動==============")]
    //[Tooltip("")][SerializeField];
    [Tooltip("更新心跳參數")][SerializeField] bool UpdateHeartBeatParameter = false;
    [Tooltip("滿血時每次心跳前等待所需秒數 即滿血時每幾秒跳一次(即最慢速)")][SerializeField] float HeartBeatDelayMax = 3f;
    [Tooltip("1%血量時每次心跳前等待所需秒數 即1%血量時每幾秒跳一次(即最快速)")][SerializeField] float HeartBeatDelayMin = 0.5f;
    [Tooltip("心跳放大倍數 1為原本比例沒放大 2就是放大一倍 建議1~2之間")][SerializeField] float HeartBeatTweenScale = 1.3f;
    [Tooltip("心跳所需時間 即從原本尺寸到放大再到變回來的所需時間 這個會自動隨著血量減少等比加快")][SerializeField] float HeartBeatDuration = 1f;
    [Tooltip("心跳需要反向 敵人頭像這個要打勾")][SerializeField] bool HeartBeatReverse = false;

    [HeaderAttribute("=========設定當前血量測試=========")]
    [Tooltip("更新當前血量")][SerializeField] bool UpdateCurrentHP;
    [Tooltip("設定當前HP剩餘量 最大為1(滿血) 最小為0(空血)")][SerializeField] float SettingCurrentHP = 1f;

    //TODO:
    //1.扣血/回血 血條(Bar)演出 血條總長度396 Right值越大長度越短 396就等於0%
      //1.心臟跳動效果(公式:100~1 >> Min~Max) >> 已完成(4/9)
      //2.受擊 >> 心跳變黑白 往左搖晃一下 之後變回原本顏色 血條瞬間全白後開始扣減 >> 已完成(4/11)
      //3.原本血條也要變黑白跟著縮減 縮減後變化血條不用隱藏 而是保留最後一小段 >> 已完成(4/11)
    //2.buff圖案

    CancellationTokenSource CurrentCTS; //用來中斷目前的血條演出

    //血條演出區塊參數
    RectTransform ChangeBarRect; //血條rt參考
    float HPChangeBarWidth; //血條長度
    float HPChangeBarOffsetY; //血條高度偏移量
    float CurrentHPRate = 1f; //目前血量比率
    Vector3 ChangeBarOriginPos;
    Color HideColor = new Color(1f, 1f, 1f, 0f);

    //心跳演出區塊參數
    Tweener HeartBeatScaleTween1;
    Tweener HeartBeatScaleTween2;
    Tweener HeartBeatGrayScaleTween1;
    Tweener HeartBeatGrayScaleTween2;

    private void Start()
    {
        ChangeBarRect = HPChangeBar.GetComponent<RectTransform>();
        HPChangeBarWidth = ChangeBarRect.rect.width;
        HPChangeBarOffsetY = ChangeBarRect.offsetMax.y;
        ChangeBarOriginPos = ChangeBarRect.anchoredPosition3D;
        SetHeartBeatParameter();
    }

    void Update()
    {
        //測試用 做血條演出
        if (PerformHPReduce)
        {
            UniTask.Void(async () => {
                if (CurrentCTS != null)
                    CurrentCTS.Cancel();
                CurrentCTS = new CancellationTokenSource();
                HPChange(CurrentCTS).Forget();
                });
            PerformHPReduce = false;
        }
        //測試用 做心跳演出
        if (UpdateHeartBeatParameter)
        {
            SetHeartBeatParameter();
            UpdateHeartBeatParameter = false;
        }
        //測試用 直接設定當前HP
        if (UpdateCurrentHP)
        {
            SetCurrentHP();
            UpdateCurrentHP = false;
        }
    }

    public void SetData()
    {
        //TODO:
        //英雄頭像設定
        //英雄名字設定
        //血量設定
    }

    //血條演出 之後改傳入起始值跟終值作演出判斷
    async UniTaskVoid HPChange(CancellationTokenSource ctk)
    {
        if (BarStartVal == BarFinalVal)
            return;
        Debug.Log("------開始演出血量-------");
        //TODO:之後改為接入實際扣減的數值 需要換算血量比例
        bool isReduce = BarStartVal >= BarFinalVal;
        float currentVal = BarStartVal;
        CurrentHPRate = BarFinalVal;
        //血條(彩色)設定為血量變化起始長度
        HPBar.fillAmount = BarStartVal;
        //血條(白色)設定為血量變化起始長度
        HPBarGray.fillAmount = BarStartVal;
        //血條(黑白)設定為血量變化起始長度
        HPBarWhite.fillAmount = BarStartVal;
        //顯示變化血條
        ShowHPBarChange(true);

        //還原設定
        HeartBeatIconTrans.localEulerAngles = Vector3.zero; //先歸0以免連續觸發演出導致角度不正常
        HeartBeatGrayIconTrans.localEulerAngles = Vector3.zero; //先歸0以免連續觸發演出導致角度不正常
        HeartBeatGrayIcon.color = HideColor; //還原顏色設定以免多次演出導致顏色異常
        HPBarWhite.color = HideColor;//還原顏色設定以免多次演出導致顏色異常
        SetHPBarChangePos(currentVal);//設置變化血條起始位置

        //等待血條停滯時間
        await UniTask.WaitForSeconds(BarChangeSecDelay, cancellationToken:ctk.Token);
        //算出每禎變化值
        float delta = math.abs(BarStartVal - BarFinalVal) / BarChangeSecNeed / BarChangeFrame;
        float duration = 1f / BarChangeFrame;
        
        //受擊演出 心跳變黑白旋轉 血條全白 顯示變化血條(直接接在血條末端)
        //旋轉演出
        Tweener HeartBeatRotate = HeartBeatIconTrans.DORotate(HittedRotateAngle, HittedRotateDuration/2, RotateMode.Fast);
        HeartBeatRotate.SetAutoKill(true);
        HeartBeatRotate.Pause();
        HeartBeatRotate.SetEase(Ease.OutSine);
        HeartBeatRotate.OnComplete(DOHeartBeatRotateBack);
        HeartBeatRotate.Restart();

        Tweener HeartBeatGrayRotate = HeartBeatGrayIconTrans.DORotate(HittedRotateAngle, HittedRotateDuration/2, RotateMode.Fast);
        HeartBeatGrayRotate.SetAutoKill(true);
        HeartBeatGrayRotate.Pause();
        HeartBeatGrayRotate.SetEase(Ease.OutSine);
        HeartBeatGrayRotate.OnComplete(DOHeartBeatGrayGotateBack);
        HeartBeatGrayRotate.Restart();

        //心臟變色演出
        Tweener HeartBeatGrayCutIn = HeartBeatGrayIcon.DOColor(Color.white, HittedColorDuration/2);
        HeartBeatGrayCutIn.SetAutoKill(true);
        HeartBeatGrayCutIn.Pause();
        HeartBeatGrayCutIn.SetEase(Ease.Linear);
        HeartBeatGrayCutIn.OnComplete(DoHeartBeatGrayHide);
        HeartBeatGrayCutIn.Restart();
        
        //血條變色(白色)演出 >> 原本是全透明 快速淡入又淡出
        Tweener HPBarShowWhite = HPBarWhite.DOColor(Color.white, HittedHPBarWhiteDuration/2);
        HPBarShowWhite.SetAutoKill(true);
        HPBarShowWhite.Pause();
        HPBarShowWhite.SetEase(Ease.Linear);
        HPBarShowWhite.OnComplete(HideHPBarWhite);
        HPBarShowWhite.Restart();

        //等待血條變色演出結束
        await UniTask.WaitForSeconds(HittedHPBarWhiteDuration, cancellationToken:ctk.Token);

        Debug.Log("------開始漸變------");
        Debug.Log("每秒變化量: " + delta + " 每次變化所需秒數: " + duration);
        //Debug.Log("current Val: " + currentVal +  " Final Val: " + BarFinalVal);
        //血量變化 >> 變化血條長度固定並隨著血條末端位移 要有殘影滯留逐步縮退 彩色血條先 底下一條灰階的血條快速跟隨縮退
        //黑白血條演出 另外開一個UniTask去跑
        float grayDelta = math.abs(BarStartVal - BarFinalVal) / BarGrayChangeSecNeed / BarChangeFrame;//黑白血條演出所需每次變化量
        float grayDuration = 1f / BarChangeFrame;//黑白血條演出每次間隔時間
        //紀錄上次殘影出現血量百分比
        float lastAfterImageHPRate = 0f;
        UniTask.Void(async () => { HPGrayChange(CurrentCTS, isReduce, currentVal, BarFinalVal, grayDuration, grayDelta).Forget(); });
        if (isReduce)
        {
            while(currentVal >= BarFinalVal) {
                await UniTask.WaitForSeconds(duration, cancellationToken:ctk.Token);
                currentVal -= delta;
                //目前血條(彩色)開始變化
                HPBar.fillAmount = currentVal;
                //變化血條位移
                SetHPBarChangePos(currentVal);
                //製造殘影(比對上一次產生殘影的血量 高於等於設定值就產生殘影)
                if (lastAfterImageHPRate == 0f || (Math.Abs(lastAfterImageHPRate - currentVal) >= HPRateGenerateAfterImage))
                {
                    lastAfterImageHPRate = currentVal;
                    GenerateHPBarChangeAfterImage();
                }
                Debug.Log("數值減少 目前百分比值: " + currentVal);
            }
        }
        else
        {
            while(currentVal <= BarFinalVal){
                await UniTask.WaitForSeconds(duration, cancellationToken:ctk.Token);
                currentVal += delta;
                //目前血條(彩色)開始變化
                HPBar.fillAmount = currentVal;
                //變化血條位移
                SetHPBarChangePos(currentVal);
                //製造殘影(比對上一次產生殘影的血量 高於等於設定值就產生殘影)
                if (lastAfterImageHPRate == 0f || (Math.Abs(lastAfterImageHPRate - currentVal) >= HPRateGenerateAfterImage))
                {
                    lastAfterImageHPRate = currentVal;
                    GenerateHPBarChangeAfterImage();
                }
                Debug.Log("數值增加 目前百分比值: " + currentVal);
            }
        }
        await UniTask.Yield(ctk.Token);
        //血量變化更改心跳速度
        SetHeartBeatRate();
        //目前血條(彩色)設定至定量避免計算有偏差
        HPBar.fillAmount = BarFinalVal;
        //變化血條設定至定量避免計算有偏差 >> 經過實測不加這行會縮退太多 因為上面計算一定不會剛好停止
        SetHPBarChangePos(BarFinalVal);
    }

    /// <summary>
    /// 血條(黑白)變化演出
    /// </summary>
    /// <param name="ctk">取消token</param>
    /// <param name="isReduce">是否血量減少</param>
    /// <param name="currentVal">目前血量數值 為0~1</param>
    /// <param name="changeFinalVal">最終血量數值 為0~1</param>
    /// <param name="duration">每次變化所需時間</param>
    /// <param name="delta">每次血條變化量</param>
    /// <returns></returns>
    async UniTaskVoid HPGrayChange(CancellationTokenSource ctk, bool isReduce, float currentVal, float changeFinalVal, 
        float duration, float delta)
    {
        //等待設置延遲的秒數
        await UniTask.WaitForSeconds(BarGrayChangeSecDelay, cancellationToken:ctk.Token);
        //以設置的演出時間開始變化血量
        if (isReduce)
        {
            while(currentVal >= changeFinalVal) {
                await UniTask.WaitForSeconds(duration, cancellationToken:ctk.Token);
                currentVal -= delta;
                //目前血條(黑白)開始變化
                HPBarGray.fillAmount = currentVal;
                //Debug.Log("黑白數值減少 目前百分比值: " + currentVal);
            }
        }
        else
        {
            while(currentVal <= changeFinalVal){
                await UniTask.WaitForSeconds(duration, cancellationToken:ctk.Token);
                currentVal += delta;
                //目前血條(黑白)開始變化
                HPBarGray.fillAmount = currentVal;
                //Debug.Log("黑白數值增加 目前百分比值: " + currentVal);
            }
        }
        await UniTask.Yield(ctk.Token);
        //目前血條(黑白)設定至定量避免計算有偏差
        HPBarGray.fillAmount = changeFinalVal;
    }

    //產生變化血條殘影
    void GenerateHPBarChangeAfterImage()
    {
        //複製Image 設置位置
        GameObject CloneChangeHPBar = Instantiate(HPChangeBar.gameObject, CloneHPChangerBarTrans);
        //淡出並銷毀
        Tweener CutOutTween = CloneChangeHPBar.GetComponent<Image>().DOColor(HideColor, AfterImageDuration);
        CutOutTween.SetAutoKill(true);
        CutOutTween.Pause();
        CutOutTween.SetEase(Ease.Linear);
        CutOutTween.OnComplete(()=> { Destroy(CloneChangeHPBar);});
        CutOutTween.Restart();
    }

    //設定血條變化量位置 作為血條變化演出 傳入值為0~1
    void SetHPBarChangePos(float percent)
    {
        //0.94~1X位移變化量約為1.6666667 因為圖案不是規則矩形導致斜率不是單一
        //公式為血量FillAmount為1時的所在位置(380)減去0.94時所在位置(370)除於區間差值(100-94)下去轉換變化量 所在位置(ChangeBar的PosX)是手動調整所得
        //float FirstChangeRate = (380 - 370) / 6f; //0.94~1的斜率變化量 
        //0.16~0.93的X位移變化量約為3.935 因為圖案不是規則矩形導致斜率不是單一(直到0都採此變化量 小於0.16血條已被心跳蓋住看不見)
        //公式為血量FillAmount為0.93時的所在位置(367)減去0.16時所在位置(64)除於區間差值(93-16)下去轉換變化量 所在位置(ChangeBar的PosX)是手動調整所得
        //float SecondChangeRate = (367 - 64) / 77f; //0~0.93的斜率變化量
        bool UseRate1 = percent >= 0.94f;
        float PercentStart = UseRate1 ? 1f : 0.93f;
        float XPosStart = UseRate1 ? 380f : 367f;
        float XPosEnd = UseRate1 ? 370f : 64f;
        float RateDenominator = UseRate1 ? 6f : 77f;
        float RealRate = (XPosStart - XPosEnd) / RateDenominator;
        float RealPosX = XPosStart - (PercentStart - percent) * RealRate * 100f;
        ChangeBarRect.anchoredPosition3D = new Vector3(RealPosX, ChangeBarOriginPos.y, ChangeBarOriginPos.z);
        //Debug.Log("Real Pos X: " + RealPosX);
    }

    void ShowHPBarChange(bool bShow)
    {
        HPChangeBar.color = bShow ? Color.white : HideColor;
    }

    void SetHeartBeatParameter()
    {
        //不為null就停止並殺掉原本的Tween
        if (HeartBeatScaleTween1 != null)
        {
            HeartBeatScaleTween1.Pause();
            HeartBeatScaleTween1.Kill();
        }
        if (HeartBeatScaleTween2 != null)
        {
            HeartBeatScaleTween2.Pause();
            HeartBeatScaleTween2.Kill();
        }
        if (HeartBeatGrayScaleTween1 != null)
        {
            HeartBeatGrayScaleTween1.Pause();
            HeartBeatGrayScaleTween1.Kill();
        }
        if (HeartBeatGrayScaleTween2 != null)
        {
            HeartBeatGrayScaleTween2.Pause();
            HeartBeatGrayScaleTween2.Kill();
        }
        //重置Scale 不然多次調整後初始Scale可能會錯誤
        HeartBeatIconTrans.localScale = HeartBeatReverse ? Vector3.left + Vector3.up + Vector3.forward : Vector3.one;
        HeartBeatGrayIconTrans.localScale = HeartBeatReverse ? Vector3.left + Vector3.up + Vector3.forward : Vector3.one;
        //新建立Tween
        HeartBeatScaleTween1 = HeartBeatIconTrans.DOScale(new Vector3(HeartBeatReverse ? -HeartBeatTweenScale : HeartBeatTweenScale, HeartBeatTweenScale, 1f), HeartBeatDuration/2);
        HeartBeatScaleTween1.SetAutoKill(false);
        HeartBeatScaleTween1.Pause();
        HeartBeatScaleTween1.SetDelay(HeartBeatDelayMax);
        HeartBeatScaleTween1.SetEase(Ease.OutSine);
        HeartBeatScaleTween1.OnComplete(HeartBeatBack);//OnComplete弄成循環

        HeartBeatScaleTween2 = HeartBeatIconTrans.DOScale(HeartBeatReverse ? Vector3.left + Vector3.up + Vector3.forward : Vector3.one, HeartBeatDuration/2);
        HeartBeatScaleTween2.SetAutoKill(false);
        HeartBeatScaleTween2.Pause();
        HeartBeatScaleTween2.SetEase(Ease.OutSine);
        HeartBeatScaleTween2.OnComplete(HeartBeat);//OnComplete弄成循環

        HeartBeatGrayScaleTween1 = HeartBeatGrayIconTrans.DOScale(new Vector3(HeartBeatReverse ? -HeartBeatTweenScale : HeartBeatTweenScale, HeartBeatTweenScale, 1f), HeartBeatDuration/2);
        HeartBeatGrayScaleTween1.SetAutoKill(false);
        HeartBeatGrayScaleTween1.Pause();
        HeartBeatGrayScaleTween1.SetDelay(HeartBeatDelayMax);
        HeartBeatGrayScaleTween1.SetEase(Ease.OutSine);
        HeartBeatGrayScaleTween1.OnComplete(HeartBeatGrayBack);//OnComplete弄成循環

        HeartBeatGrayScaleTween2 = HeartBeatGrayIconTrans.DOScale(HeartBeatReverse ? Vector3.left + Vector3.up + Vector3.forward : Vector3.one, HeartBeatDuration/2);
        HeartBeatGrayScaleTween2.SetAutoKill(false);
        HeartBeatGrayScaleTween2.Pause();
        HeartBeatGrayScaleTween2.SetEase(Ease.OutSine);
        HeartBeatGrayScaleTween2.OnComplete(HeartGrayBeat);//OnComplete弄成循環
        //建立完後根據血量決定演出的速度(TimeScale)
        SetHeartBeatRate();
        //開始演出
        HeartBeatScaleTween1.PlayForward();
        HeartBeatGrayScaleTween1.PlayForward();
    }

    //更新心跳率
    void SetHeartBeatRate()
    {
        //根據目前血量換算心跳速度應該多快
        float HeartBeatChangeRate = (HeartBeatDelayMax - HeartBeatDelayMin) / 100f; //每百分比加快的秒數
        float CurrentHPDelay = HeartBeatDelayMax - HeartBeatChangeRate * ((1f - CurrentHPRate) * 100f); //換算現在血量對應的delay時間
        if (HeartBeatScaleTween1 != null)
        {
            HeartBeatScaleTween1.timeScale = 1f / (CurrentHPDelay / HeartBeatDelayMax); //換算TimeScale應該加快多少
            Debug.Log("轉換心跳演出加速倍率: " + HeartBeatScaleTween1.timeScale);
        }
        if (HeartBeatScaleTween2 != null)
            HeartBeatScaleTween2.timeScale = 1f / (CurrentHPDelay / HeartBeatDelayMax);
        if (HeartBeatGrayScaleTween1 != null)
            HeartBeatGrayScaleTween1.timeScale = 1f / (CurrentHPDelay / HeartBeatDelayMax);
        if (HeartBeatGrayScaleTween2 != null)
            HeartBeatGrayScaleTween2.timeScale = 1f / (CurrentHPDelay / HeartBeatDelayMax);
    }

    //心跳跳回去(縮小回原尺寸)
    void HeartBeatBack()
    {
        HeartBeatScaleTween2.Restart();
        //Debug.Log("心跳跳回去");
    }

    //心跳跳動(放大尺寸)
    void HeartBeat()
    {
        HeartBeatScaleTween1.Restart();
        //Debug.Log("重新心跳");
    }

    //心跳跳回去(黑白圖 縮小回原尺寸)
    void HeartBeatGrayBack()
    {
        HeartBeatGrayScaleTween2.Restart();
        //Debug.Log("心跳跳回去");
    }

    //心跳跳動(黑白圖 放大尺寸)
    void HeartGrayBeat()
    {
        HeartBeatGrayScaleTween1.Restart();
        //Debug.Log("重新心跳");
    }

    void SetCurrentHP()
    {
        CurrentHPRate = SettingCurrentHP;
        HPBar.fillAmount = CurrentHPRate;
        HPBarGray.fillAmount = CurrentHPRate;
        HPBarWhite.fillAmount = CurrentHPRate;
        SetHPBarChangePos(CurrentHPRate);
        SetHeartBeatRate();
    }

    //心臟受擊旋轉回原位置
    void DOHeartBeatRotateBack()
    {
        Tweener HeartBeatRotateBack = HeartBeatIconTrans.DORotate(Vector3.zero, HittedRotateDuration/2, RotateMode.Fast);
        HeartBeatRotateBack.SetAutoKill(true);
        HeartBeatRotateBack.Pause();
        HeartBeatRotateBack.SetEase(Ease.OutSine);
        HeartBeatRotateBack.Restart();
    }

    //心臟受擊(黑白)旋轉回原位置
    void DOHeartBeatGrayGotateBack()
    {
        Tweener HeartBeatRotateBack = HeartBeatGrayIconTrans.DORotate(Vector3.zero, HittedRotateDuration/2, RotateMode.Fast);
        HeartBeatRotateBack.SetAutoKill(true);
        HeartBeatRotateBack.Pause();
        HeartBeatRotateBack.SetEase(Ease.OutSine);
        HeartBeatRotateBack.Restart();
    }

    //心臟受擊(黑白)隱藏
    void DoHeartBeatGrayHide()
    {
        Tweener HeartBeatGray = HeartBeatGrayIcon.DOColor(HideColor, HittedColorDuration/2);
        HeartBeatGray.SetAutoKill(true);
        HeartBeatGray.Pause();
        HeartBeatGray.SetEase(Ease.Linear);
        HeartBeatGray.Restart();
    }

    //白色血條隱藏
    void HideHPBarWhite()
    {
        Tweener HideTween = HPBarWhite.DOColor(HideColor, HittedHPBarWhiteDuration/2);
        HideTween.SetAutoKill(true);
        HideTween.Pause();
        HideTween.SetEase(Ease.Linear);
        HideTween.Restart();
    }
}