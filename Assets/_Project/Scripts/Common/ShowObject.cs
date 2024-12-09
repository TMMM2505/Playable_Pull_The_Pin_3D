using System;
using System.Text.RegularExpressions;
using DG.Tweening;
using Pancake;
using Pancake.IAP;
using UnityEngine;

public class ShowObject : MonoBehaviour
{
    public bool IsShowByTesting;
    public bool IsShowByLevel;
    public bool IsShowByIAPAds;
    public float DelayShowTime;

    //[Group("Show level setting")][ShowIf("IsShowByLevel")] public bool UseCurrentLevel;
    //[Group("Show level setting")][ShowIf("IsShowByLevel")] public int LevelShow;
    
    
    //public void OnDrawGizmos()
    //{
    //    if (!UseCurrentLevel) return;
    //    try
    //    {
    //        var getNumb = Regex.Match(transform.root.name, @"\d+").Value;
    //        LevelShow = Int32.Parse(getNumb);
    //    }
    //    catch (Exception e)
    //    {
    //        Console.WriteLine(e);
    //        throw;
    //    }
    //}
    
    //private bool EnableToShow()
    //{
    //    bool levelCondition = LevelShow == Data.CurrentLevel;
    //    bool testingCondition = Data.IsTesting;
    //    return (IsShowByTesting && testingCondition) || (IsShowByLevel && levelCondition);
    //}

    void Awake()
    {
        Setup();
        
        if (IsShowByLevel) EventController.CurrentLevelChanged += Setup;
        if (IsShowByTesting) EventController.OnDebugging += Setup;
        if (IsShowByIAPAds) EventController.OnPurchasingIAP += Setup;
    }
    
    private void OnDestroy()
    {
        if (IsShowByLevel) EventController.CurrentLevelChanged -= Setup;
        if (IsShowByTesting) EventController.OnDebugging -= Setup;
        if (IsShowByIAPAds) EventController.OnPurchasingIAP -= Setup;
    }


    public void Setup()
    {
        //if (IsShowByIAPAds)
        //{
        //    #if UNITY_ANDROID
        //    //gameObject.SetActive(!(IAPManager.Instance.IsPurchased(Constant.ANDROID_IAP_REMOVE_ADS) || IAPManager.Instance.IsPurchased(Constant.ANDROID_IAP_VIP)));
        //    #endif
        //    #if UNITY_IOS
        //    gameObject.SetActive(!(IAPManager.Instance.IsPurchased(Constant.IOS_IAP_REMOVE_ADS) || IAPManager.Instance.IsPurchased(Constant.IOS_IAP_VIP)));
        //    #endif
        //}
        //else
        //{
        //    if (DelayShowTime>0) gameObject.SetActive(false);
        //    DOTween.Sequence().AppendInterval(DelayShowTime).AppendCallback(()=>gameObject.SetActive(EnableToShow()));
        //}
    }
}