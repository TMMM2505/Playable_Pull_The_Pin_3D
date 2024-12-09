using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public static class EventController
{
    public static Action OnWin;
    public static Action OnLose;
    public static Action<GameObject> CustomCurrencyChange;
    public static Action SaveCurrencyTotal;
    public static Action CurrencyTotalChanged;
    public static Action CurrentLevelChanged;
    public static Action OnNotifying;
    public static Action OnDebugging;
    public static Action CurrentBallChanged;
    public static Action CurrentPinChanged;
    public static Action CurrentThemeChanged;
    public static Action CurrentTrailChanged;
    public static Action OnPurchasingIAP;
    public static Action OnUpdateDailyTask;
    public static Action<bool> ToggleTutorialBackground;
    public static Action StartEventFromOtherPopup;
    public static Action OnRestoreDataComplete;
    
    // New tracking for big query
    public static Action BannerAdsShow;
    public static Action InterstitialAdsShow;
    public static Action RewardAdsShow;
    public static Action AchieveCoin;
    public static Action SpentCoin;
    public static Action PinSkinCount;
    public static Action BallSkinCount;
    public static Action ThemeSkinCount;
    public static Action AvatarSkinCount;
    public static Action TrailSkinCount;
    public static Action UnLockAreaCount;
    public static Action WinLevelNormal;
    public static Action WinLevelChallenge;
    public static Action WinLevelMultiply;
    public static Action<string> PurchaseIAP;
    
    //Collapsible areas
    public static Action<bool> ShowCollapsibleBanner;
    public static Action HideCollapsibleBanner;
    
    //Audio Ad
    public static Action ShowAudioAd;
}