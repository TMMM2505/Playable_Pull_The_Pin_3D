using UnityEngine;
//using Firebase;
//using Firebase.Analytics;
//using Firebase.Extensions;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
//using com.adjust.sdk;
//using Firebase.RemoteConfig;
using Pancake.IAP;

public class FirebaseManager : MonoBehaviour
{
    //static DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
    //public static bool IsInitialized = false;

    // Start is called before the first frame update
    public static void Initialize()
    {
        //FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        //{
        //    dependencyStatus = task.Result;
        //    if (dependencyStatus == DependencyStatus.Available)
        //    {
        //        InitializeFirebase();

        //        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLogin);
        //    }
        //    else
        //    {
        //        Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
        //    }
        //});
        
        //Register event for new tracking looker
        //RegisterLookerEvent();
    }
    
    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            //UpdateTrackingOnlineTime();
        }
    }

    private static async void InitializeFirebase()
    {
        //FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);

        //var defaults = new System.Collections.Generic.Dictionary<string, object>
        //{
        //    { Constant.USE_LEVEL_AB_TESTING, Data.DEFAULT_USE_LEVEL_AB_TESTING },
        //    { Constant.USE_NPC_AB_TESTING, Data.DEFAULT_USE_NPC_AB_TESTING },
        //    { Constant.LEVEL_TURN_ON_INTERSTITIAL, Data.DEFAULT_LEVEL_TURN_ON_INTERSTITIAL },
        //    { Constant.COUNTER_NUMBER_BETWEEN_TWO_INTERSTITIAL, Data.DEFAULT_COUNTER_NUMBER_BETWEEN_TWO_INTERSTITIAL },
        //    { Constant.SPACE_TIME_WIN_BETWEEN_TWO_INTERSTITIAL, Data.DEFAULT_SPACE_TIME_WIN_BETWEEN_TWO_INTERSTITIAL },
        //    { Constant.SHOW_INTERSTITIAL_ON_LOSE_GAME, Data.DEFAULT_SHOW_INTERSTITIAL_ON_LOSE_GAME },
        //    {
        //        Constant.SPACE_TIME_LOSE_BETWEEN_TWO_INTERSTITIAL, Data.DEFAULT_SPACE_TIME_LOSE_BETWEEN_TWO_INTERSTITIAL
        //    },
        //    { Constant.USE_APP_OPEN_ADS, Data.DEFAULT_USE_APP_OPEN_ADS },
        //    { Constant.USE_SHOW_BANNER, Data.DEFAULT_USE_SHOW_BANNER },
        //    { Constant.LEVEL_AB_13032023, Data.DEFAULT_LEVEL_AB_13032023 },
        //};
        //await Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.SetDefaultsAsync(defaults)
        //    .ContinueWithOnMainThread(task =>
        //    {
        //        // [END set_defaults]
        //        Debug.Log("RemoteConfig configured and ready!");
        //    });

        //await FetchDataAsync();
    }

    //private static Task FetchDataAsync()
    //{
    //    //Debug.Log("Fetching data...");
    //    //System.Threading.Tasks.Task fetchTask =
    //    //    Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
    //    //if (fetchTask.IsCanceled)
    //    //{
    //    //    Debug.Log("Fetch canceled.");
    //    //}
    //    //else if (fetchTask.IsFaulted)
    //    //{
    //    //    Debug.Log("Fetch encountered an error.");
    //    //}
    //    //else if (fetchTask.IsCompleted)
    //    //{
    //    //    Debug.Log("Fetch completed successfully!");
    //    //}

    //    //return fetchTask.ContinueWithOnMainThread(tast =>
    //    //{
    //    //    var info = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.Info;
    //    //    //SET NEW DATA FROM REMOTE CONFIG
    //    //    if (info.LastFetchStatus == LastFetchStatus.Success)
    //    //    {
    //    //        Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.ActivateAsync()
    //    //            .ContinueWithOnMainThread(task =>
    //    //            {
    //    //                Debug.Log(String.Format("Remote data loaded and ready (last fetch time {0}).",
    //    //                    info.FetchTime));
    //    //            });

    //    //        Data.UseLevelABTesting = int.Parse(FirebaseRemoteConfig.DefaultInstance
    //    //            .GetValue(Constant.USE_LEVEL_AB_TESTING).StringValue);
    //    //        Data.UseNPCABTesting = int.Parse(FirebaseRemoteConfig.DefaultInstance
    //    //            .GetValue(Constant.USE_NPC_AB_TESTING).StringValue);
    //    //        Data.LevelTurnOnInterstitial = int.Parse(FirebaseRemoteConfig.DefaultInstance
    //    //            .GetValue(Constant.LEVEL_TURN_ON_INTERSTITIAL).StringValue);
    //    //        Data.CounterNumbBetweenTwoInterstitial = int.Parse(FirebaseRemoteConfig.DefaultInstance
    //    //            .GetValue(Constant.COUNTER_NUMBER_BETWEEN_TWO_INTERSTITIAL).StringValue);
    //    //        Data.USE_COLLAPSIBLE_BANNER_ADS = int.Parse(FirebaseRemoteConfig.DefaultInstance
    //    //            .GetValue(Constant.USE_COLLAPSIBLE_BANNER_ADS).StringValue); 
    //    //        Data.TIME_BETWEEN_COLLAPSIBLE = int.Parse(FirebaseRemoteConfig.DefaultInstance
    //    //            .GetValue(Constant.TIME_BETWEEN_COLLAPSIBLE_BANNER_ADS).StringValue);
    //    //        Data.TimeWinBetweenTwoInterstitial = int.Parse(FirebaseRemoteConfig.DefaultInstance
    //    //            .GetValue(Constant.SPACE_TIME_WIN_BETWEEN_TWO_INTERSTITIAL).StringValue);
    //    //        Data.UseShowInterstitialOnLoseGame = int.Parse(FirebaseRemoteConfig.DefaultInstance
    //    //            .GetValue(Constant.SHOW_INTERSTITIAL_ON_LOSE_GAME).StringValue);
    //    //        Data.TimeLoseBetweenTwoInterstitial = int.Parse(FirebaseRemoteConfig.DefaultInstance
    //    //            .GetValue(Constant.SPACE_TIME_LOSE_BETWEEN_TWO_INTERSTITIAL).StringValue);
    //    //        Data.UseAppOpenAds = int.Parse(FirebaseRemoteConfig.DefaultInstance
    //    //            .GetValue(Constant.USE_APP_OPEN_ADS).StringValue);
    //    //        Data.UseShowBanner = int.Parse(FirebaseRemoteConfig.DefaultInstance
    //    //            .GetValue(Constant.USE_SHOW_BANNER).StringValue);
    //    //        Data.LevelAB13032023 = int.Parse(FirebaseRemoteConfig.DefaultInstance
    //    //            .GetValue(Constant.LEVEL_AB_13032023).StringValue);

    //    //        Debug.Log("<color=Green>Firebase Remote Config Fetching Values</color>");
    //    //        Debug.Log($"<color=Green>Data.UseLevelABTesting: {Data.UseLevelABTesting}</color>");
    //    //        Debug.Log($"<color=Green>Data.UseNPCABTesting: {Data.UseNPCABTesting}</color>");
    //    //        Debug.Log($"<color=Green>Data.LevelTurnOnInterstitial: {Data.LevelTurnOnInterstitial}</color>");
    //    //        Debug.Log(
    //    //            $"<color=Green>Data.CounterNumbBetweenTwoInterstitial: {Data.CounterNumbBetweenTwoInterstitial}</color>");
    //    //        Debug.Log(
    //    //            $"<color=Green>Data.TimeWinBetweenTwoInterstitial: {Data.TimeWinBetweenTwoInterstitial}</color>");
    //    //        Debug.Log(
    //    //            $"<color=Green>Data.UseShowInterstitialOnLoseGame: {Data.UseShowInterstitialOnLoseGame}</color>");
    //    //        Debug.Log(
    //    //            $"<color=Green>Data.TimeLoseBetweenTwoInterstitial: {Data.TimeLoseBetweenTwoInterstitial}</color>");
    //    //        Debug.Log(
    //    //            $"<color=Green>Data.UseAppOpenAds: {Data.UseAppOpenAds}</color>");
    //    //        Debug.Log(
    //    //            $"<color=Green>Data.UseShowBanner: {Data.UseShowBanner}</color>");
    //    //        Debug.Log(
    //    //            $"<color=Green>Data.LevelAB13032023: {Data.LevelAB13032023}</color>");
    //    //        Debug.Log("<color=Green>Firebase Remote Config Fetching completed!</color>");
    //    //    }
    //    //    else
    //    //    {
    //    //        Debug.Log("Fetching data did not completed!");
    //    //    }

    //    //    IsInitialized = true;
    //    //});
    //}
    
    public static void OnResourceSource(string playMode, int level, string name, int amount, int balance, ResourceSourceItem item, ResourceSourceItemType itemType)
    {
        //Parameter[] parameters =
        //{
        //    new Parameter("play_mode", playMode.ToLower()),
        //    new Parameter("level", level),
        //    new Parameter("name", name),
        //    new Parameter("amount", amount),
        //    new Parameter("balance", balance),
        //    new Parameter("item", item.ToString()),
        //    new Parameter("item_type", itemType.ToString()),
        //};
        //LogEvent("resource_source", parameters);
    }

    public enum ResourceSourceItem
    {
        win_level,
        prize_multiple,
        daily_reward,
        task,
        star,
        ball_master,
        full_cards,
        progress_gift,
        purchase,
    }

    public enum ResourceSourceItemType
    {
        claim,
        ads,
        purchase
    }
    
    public static void OnResourceSink(string playMode, int level, string name, int amount, int balance, ItemResourceSink item, ItemTypeResourceSink itemType)
    {
        //Parameter[] parameters =
        //{
        //    new Parameter("play_mode", playMode.ToLower()),
        //    new Parameter("level", level),
        //    new Parameter("name", name),
        //    new Parameter("amount", amount),
        //    new Parameter("balance", balance),
        //    new Parameter("item", item.ToString()),
        //    new Parameter("item_type", itemType.ToString()),
        //};
        //LogEvent("resource_sink", parameters);
    }

    public enum ItemResourceSink
    {
        pin,
        ball,
        theme,
        cards,
        build
    }
    
    public enum ItemTypeResourceSink
    {
        purchase
    }

    public static void OnFirstStartLevel_X(string levelName)
    {
        //Parameter[] parameters =
        //{
        //    new Parameter("level_name", levelName)
        //};
        //MethodBase function = MethodBase.GetCurrentMethod();
        //LogEvent(function?.Name, parameters);
    }

    public static void OnFirstStartLevel(string levelName)
    {
        //Parameter[] parameters = new[]
        //{
        //    new Parameter("level_name", levelName)
        //};
        //MethodBase function = MethodBase.GetCurrentMethod();
        //LogEvent(function?.Name, parameters);
    }

    public static void OnStartLevel(int levelIndex, string levelName)
    {
        //Parameter[] parameters =
        //{
        //    new Parameter("level", levelIndex),
        //    new Parameter("level_name", levelName)
        //};
        //LogEvent("OnStartLevel", parameters);
    }

    public static void OnLoseGame(int levelIndex, string levelName)
    {
        //MethodBase function = MethodBase.GetCurrentMethod();
        //Parameter[] _parameters =
        //{
        //    new Parameter(FirebaseAnalytics.ParameterLevel, levelIndex),
        //    new Parameter("level_name", levelName)
        //};
        //LogEvent(function.Name, _parameters);
    }

    public static void OnWinGame(int levelIndex, string levelName)
    {
        //MethodBase function = MethodBase.GetCurrentMethod();
        //Parameter[] _parameters =
        //{
        //    new Parameter(FirebaseAnalytics.ParameterLevel, levelIndex),
        //    new Parameter("level_name", levelName)
        //};
        //LogEvent(function.Name, _parameters);
    }

    public static void OnReplayGame(int levelIndex, string levelName)
    {
        //MethodBase function = MethodBase.GetCurrentMethod();
        //Parameter[] _parameters =
        //{
        //    new Parameter(FirebaseAnalytics.ParameterLevel, levelIndex),
        //    new Parameter("level_name", levelName)
        //};
        //LogEvent(function.Name, _parameters);
    }

    public static void OnClaimDailyReward(int dayIndex)
    {
        //var function = MethodBase.GetCurrentMethod();
        //var contentValue = $"{dayIndex}";
        //Parameter[] _parameters =
        //{
        //    new("day_claimed", contentValue)
        //};
        //LogEvent(function.Name, _parameters);
    }

    public static void OnClaimDailyRewardX5(int dayIndex)
    {
        //var function = MethodBase.GetCurrentMethod();
        //var contentValue = $"{dayIndex}";
        //Parameter[] _parameters =
        //{
        //    new("day_claimed", contentValue)
        //};
        //LogEvent(function.Name, _parameters);
    }

    public static void OnUnlockSkin(string skinId)
    {
        //MethodBase function = MethodBase.GetCurrentMethod();
        //string contentValue = $"{skinId}";
        //Parameter[] _parameters =
        //{
        //    new Parameter("skin_unlocked", contentValue),
        //};
        //LogEvent(function.Name, _parameters);
    }

    public static void CompletePack(string packId)
    {
        //Parameter[] parameters =
        //{
        //    new("complete_pack", packId)
        //};
        //LogEvent("CompletePack", parameters);
    }

//    #region  Tracking BI
    
//    public static void EarnResource(string source, string sourceId, string resourceId, int value)
//    {
//        //Parameter[] parameters =
//        //{
//        //    new Parameter("source", source),
//        //    new Parameter("source_id", sourceId),
//        //    new Parameter("resource_id", resourceId),
//        //    new Parameter("value", value.ToString()),
//        //};
//        //LogEvent("earn_resource", parameters);
//    }
    
//    public static void SpendResource(string source, string sourceId, string resourceId, int value)
//    {
//        Parameter[] parameters =
//        {
//            new Parameter("source", source),
//            new Parameter("source_id", sourceId),
//            new Parameter("resource_id", resourceId),
//            new Parameter("value", value.ToString()),
//        };

//        LogEvent("spend_resource", parameters);
//    }
    
//    public static void AdRequest(string placementType)
//    {
//        Parameter[] parameters =
//        {
//            new Parameter("placement_type", placementType)
//        };
//        LogEvent("ad_request", parameters);
//    }
    
//    public static void AdComplete(string placementType)
//    {
//        Parameter[] parameters =
//        {
//            new Parameter("placement_type", placementType)
//        };
//        LogEvent("ad_complete", parameters);
//    }
    
//    public static void OnAdRevenuePaidEvent(MaxSdkBase.AdInfo impressionData, string playMode, string placement)
//    {
//        Parameter[] AdRevenueParameters =
//        {
//            new Parameter("play_mode", playMode),
//            new Parameter("placement_type", placement),
//            new Parameter("value", impressionData.Revenue.ToString(CultureInfo.InvariantCulture)),
//            new Parameter("ad_format",impressionData.AdFormat ?? ""),
//            new Parameter("ad_network", impressionData.NetworkName),
//            new Parameter("level", Data.CurrentLevel.ToString())
//        };
//        LogEvent("ad_revenue_sdk", AdRevenueParameters);
//    }
    
//    public static void OnAdRevenueForOtherAds(string playMode, string value, string placement, string adFormat, string adNetwork)
//    {
//        Parameter[] AdRevenueParameters =
//        {
//            new Parameter("play_mode", playMode),
//            new Parameter("placement_type", placement),
//            new Parameter("value", value),
//            new Parameter("ad_format", adFormat),
//            new Parameter("ad_network", adNetwork),
//            new Parameter("level", Data.CurrentLevel.ToString())
//        };
//        LogEvent("ad_revenue_sdk", AdRevenueParameters);
//    }
//    public static void LevelStart(string playMode, int level)
//    {
//        string battleId = SystemInfo.deviceUniqueIdentifier.ToString() + "_" + DateTime.Now.ToString();
//        Parameter[] parameters =
//        {
//            new Parameter("play_mode", playMode),
//            new Parameter("level", level.ToString()),
//            new Parameter("battle_id", battleId)
//        };
//        LogEvent("level_start", parameters);
//    }

//    public static void LevelEnd(string playMode, int level, int result, string success)
//    {
//        string number;
//        if (result == 1)
//        {
//            number = Data.LoseNumberBeforeWin.ToString();
//            Data.LoseNumberBeforeWin = 0;
//        }
//        else
//        {
//            number = "null";
//            Data.LoseNumberBeforeWin++;
//        }
        
//        string battleId = SystemInfo.deviceUniqueIdentifier.ToString() + "_" + DateTime.Now.ToString();
//        Parameter[] parameters =
//        {
//            new Parameter("play_mode", playMode),
//            new Parameter("level", level.ToString()),
//            new Parameter("battle_id", battleId),
//            new Parameter("result", result.ToString()),
//            new Parameter("number", number),
//            new Parameter("success", success)
//        };
//        LogEvent("level_end", parameters);
//    }
    
//    public static void PurchaseFail(string reason)
//    {
//        Parameter[] parameters =
//        {
//            new Parameter("reason", reason)
//        };
//        LogEvent("purchase_fail", parameters);
//    }
    
//    public static void ButtonClick(string buttonCategory, string buttonName, string buttonId)
//    {
//        buttonId = "button_" + buttonName;
//        Parameter[] parameters =
//        {
//            new Parameter("button_category", buttonCategory),
//            new Parameter("button_name", buttonName),
//            new Parameter("button_id", buttonId),
//        };
//        LogEvent("button_click", parameters);
//    }
    
//    public static void IapSdk(string productId)
//    {
//        var product = IAPManager.Instance.Controller.products.WithStoreSpecificID(productId);
//        Parameter[] IAPRevenueParameters =
//        {
//            new Parameter("play_mode", LevelType.Normal.ToString()),
//            new Parameter("transaction_id", product.transactionID),
//            new Parameter("product_id", productId),
//            new Parameter("currency", product.metadata.isoCurrencyCode),
//            new Parameter("value", product.metadata.localizedPriceString)
//        };
//        LogEvent("iap_sdk", IAPRevenueParameters);
//    }
    
//    public static void Build(string itemId, string itemLevel)
//    {
//        Parameter[] parameters =
//        {
//            new Parameter("item_id", itemId),
//            new Parameter("item_level", itemLevel),
//        };
//        LogEvent("build", parameters);
//    }
    
//    public static void EarnSkin(string skinType, string skinSource, string skinName)
//    {
//        Parameter[] parameters =
//        {
//            new Parameter("skin_type", skinType),
//            new Parameter("skin_source", skinSource),
//            new Parameter("skin_name", skinName),
//        };
//        LogEvent("earn_skin", parameters);
//    }
    
//    public static void BallMasterEnd(string ballMasterEndId)
//    {
//        Parameter[] parameters =
//        {
//            new Parameter("ball_master_end_id", ballMasterEndId),
//        };
//        LogEvent("ball_master_end", parameters);
//    }
    
//    public static void ClaimTask(string taskId)
//    {
//        Parameter[] parameters =
//        {
//            new Parameter("task_id", taskId),
//        };
//        LogEvent("claim_task", parameters);
//    }
    
//    public static void EarnCardCollection(string cardSource, string cardId, int cardStar)
//    {
//        Parameter[] parameters =
//        {
//            new Parameter("card_source", cardSource),
//            new Parameter("card_id", cardId),
//            new Parameter("card_star", cardStar.ToString()),
//        };
//        LogEvent("earn_card_collection", parameters);
//    }
    
//    #endregion

//    #region EventNoParams

//    public static void OnCollectEnoughStarBonus()
//    {
//        LogEvent("OnCollectEnoughStarBonus");
//    }

//    public static void FirstTimeStartLevel(int level)
//    {
//        LogEvent($"FirstTimeStartLevel_{level}");
//    }

//    public static void OnClickButtonDailyReward()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnStartLoading()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnWatchAdsIAPShop()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnClickButtonSetting()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnClickButtonStart()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnClickButtonShop()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnClickButtonIAP()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnClickButtonSpinReward()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnClickButtonReplay()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnClickButtonSkipLevel()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnRequestInterstitial()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnShowInterstitial()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnShowInterstitialSucceed()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnRequestReward()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnShowReward()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnShowRewardSucceed()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnShowBanner()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnWatchAdsRewardWin()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnClaimDailyTaskGift1()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnClaimDailyTaskGift2()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnClaimDailyTaskGift3()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnClickButtonBuild()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnClickButtonDailyTask()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnClickButtonChallenge()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnClickButtonCardCollection()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnLoseLevelChallenge()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnWinLevelChallenge()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void UpgradeBuildingSucceed()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnClaimDailyTask()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnUnlockSkinShop()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnStartLevelChallenge()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnStartLevelMultiply()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnWatchAdsToGetStar()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnClaimBallMaster()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnFillName()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnBuyChest()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void OnClickButtonNavi()
//    {
//        MethodBase function = MethodBase.GetCurrentMethod();
//        LogEvent(function.Name);
//    }

//    public static void TrackingAdjustLevel(int level)
//    {
//        if (!IsMobile()) return;
//        AdjustEvent adjustEvent = null;
//        switch (level)
//        {
//            case 1:
//                adjustEvent = new AdjustEvent("v0dh5c");
//                break;
//            case 2:
//                adjustEvent = new AdjustEvent("8hxivk");
//                break;
//            case 3:
//                adjustEvent = new AdjustEvent("cni5mu");
//                break;
//            case 4:
//                adjustEvent = new AdjustEvent("vinst1");
//                break;
//            case 5:
//                adjustEvent = new AdjustEvent("r262t0");
//                break;
//            case 6:
//                adjustEvent = new AdjustEvent("uprimn");
//                break;
//            case 7:
//                adjustEvent = new AdjustEvent("m82f8b");
//                break;
//            case 8:
//                adjustEvent = new AdjustEvent("dup7er");
//                break;
//            case 9:
//                adjustEvent = new AdjustEvent("76uajh");
//                break;
//            case 10:
//                adjustEvent = new AdjustEvent("2ncsw3");
//                break;
//            case 15:
//                adjustEvent = new AdjustEvent("n4uwmc");
//                break;
//            case 20:
//                adjustEvent = new AdjustEvent("x8medq");
//                break;
//            case 25:
//                adjustEvent = new AdjustEvent("moihmw");
//                break;
//            case 30:
//                adjustEvent = new AdjustEvent("zh4ggh");
//                break;
//            case 35:
//                adjustEvent = new AdjustEvent("cdjf6f");
//                break;
//            case 40:
//                adjustEvent = new AdjustEvent("4fsy2v");
//                break;
//            case 45:
//                adjustEvent = new AdjustEvent("5ziytv");
//                break;
//            case 50:
//                adjustEvent = new AdjustEvent("bh832v");
//                break;
//            case 60:
//                adjustEvent = new AdjustEvent("3z1vg1");
//                break;
//            case 70:
//                adjustEvent = new AdjustEvent("n8zt8b");
//                break;
//            case 80:
//                adjustEvent = new AdjustEvent("vw9dy3");
//                break;
//            case 90:
//                adjustEvent = new AdjustEvent("3dw43u");
//                break;
//            case 100:
//                adjustEvent = new AdjustEvent("hivaj3");
//                break;
//            case 125:
//                adjustEvent = new AdjustEvent("rf644r");
//                break;
//            case 150:
//                adjustEvent = new AdjustEvent("wylaed");
//                break;
//        }

//        if (adjustEvent != null)
//        {
//            Adjust.trackEvent(adjustEvent);
//        }
//    }

//    #endregion
    
//    #region Tracking Big Query

//    private static void RegisterLookerEvent()
//    {
//        EventController.WinLevelNormal += UpdateTrackingLevelNormal;
//        EventController.WinLevelMultiply += UpdateTrackingLevelMultiple;
//        EventController.WinLevelChallenge += UpdateTrackingLevelChallenge;
//        EventController.PurchaseIAP += UpdateTrackingBuyIAP;
//        EventController.BannerAdsShow += UpdateTrackingBannerAds;
//        EventController.InterstitialAdsShow += UpdateTrackingInterstitialAds;
//        EventController.RewardAdsShow += UpdateTrackingRewardAds;
//        EventController.AchieveCoin += UpdateTrackingAchieveCoin;
//        EventController.SpentCoin += UpdateTrackingSpentCoin;
//        EventController.PinSkinCount += UpdateTrackingPinSkinCount;
//        EventController.BallSkinCount += UpdateTrackingBallSkinCount;
//        EventController.ThemeSkinCount += UpdateTrackingThemeSkinCount;
//        EventController.TrailSkinCount += UpdateTrackingTrailSkinCount;
//        EventController.AvatarSkinCount += UpdateTrackingAvatarSkinCount;
//        EventController.UnLockAreaCount += UpdateTrackingUnlockedAreaCount;
//    }
//      public static void SetFirstTrackingUserProperties()
//    {
//        SetUserProperty(Constant.PLAYER_ID_DEVICE, SystemInfo.deviceUniqueIdentifier);
//        SetUserProperty(Constant.ADJUST_ID, AdjustController.Instance.adjust.appToken);

//        SetUserProperty(Constant.CREATED_TIMESTAMP, DateTime.Now.ToString());
//        SetUserProperty(Constant.ONLINE_TIME, "0");

//        SetUserProperty(Constant.LEVEL_CURRENT, Data.CurrentLevel.ToString());

//        SetUserProperty(Constant.IAP_COUNT, "0");
//        SetUserProperty(Constant.IAP_REVENUE, "0");
        
//        SetUserProperty(Constant.BANNER_AD_COUNT, "0");
//        SetUserProperty(Constant.INTERSTITIAL_AD_COUNT, "0");
//        SetUserProperty(Constant.REWARD_AD_COUNT, "0");

//        SetUserProperty(Constant.ACHIEVE_COIN, "0");
//        SetUserProperty(Constant.SPENT_COIN, "0");
        
//        SetUserProperty(Constant.PIN_SKIN_COUNT, "1");
//        SetUserProperty(Constant.BALL_SKIN_COUNT, "1");
//        SetUserProperty(Constant.THEME_SKIN_COUNT, "1");
//        SetUserProperty(Constant.TRAIL_SKIN_COUNT, "1");
//        SetUserProperty(Constant.AVATAR_SKIN_COUNT, "0");
//        SetUserProperty(Constant.UNLOCKED_AREA_COUNT, "0");
//        SetUserProperty(Constant.MULTIPY_CURRENT, "1");
//    }

//    private void UpdateTrackingOnlineTime()
//    {
//        DateTime result;
//        if (DateTime.TryParse(Data.CreatedTimestamp, out result))
//        {
//            int totalPlayedSecond = (int) (DateTime.Now - DateTime.Parse(Data.CreatedTimestamp)).TotalSeconds;
//            SetUserProperty(Constant.ONLINE_TIME, totalPlayedSecond.ToString());
//        }
//    }

//    private static void UpdateTrackingLevelNormal()
//    {
//        SetUserProperty(Constant.LEVEL_CURRENT, Data.CurrentLevel.ToString());
//    }

//    private static void UpdateTrackingLevelMultiple()
//    {
//        SetUserProperty(Constant.MULTIPY_CURRENT, Data.HighestLevelMultiply.ToString());
//    }
    
//    private static void UpdateTrackingLevelChallenge()
//    {
//        SetUserProperty(Constant.CHALLENGE_CURRENT, Data.HighestLevelChallenge.ToString());
//    }
    
//    private static void UpdateTrackingBuyIAP(string productId)
//    {
//        var product = IAPManager.Instance.Controller.products.WithStoreSpecificID(productId);
//        if (product != null)
//        {
//            SetUserProperty(Constant.IAP_COUNT, Data.IapCount.ToString());

            
//            Dictionary<string, float> dollarDictionary = new Dictionary<string, float>()
//            {
//                #if UNITY_ANDROID
//                ["com.pullpin3d.removeads"] = 2.99f,
//                ["com.pullpin3d.coin"] = 2.99f,
//                ["com.pullpin3d.vip"] = 3.99f,
//                ["com.pullpin3d.coin10k"] = 0.99f,
//                ["com.pullpin3d.coin25k"] = 1.99f,
//                ["com.pullpin3d.packspecial"] = 6.99f,
//                #endif
                
//                #if UNITY_IOS
//                ["com.pullpin3dios.removeads"] = 2.99f,
//                ["com.pullpin3dios.coin"] = 2.99f,
//                ["com.pullpin3dios.vip"] = 3.99f,
//                ["com.pullpin3dios.coin10K"] = 0.99f,
//                ["com.pullpin3dios.coin25K"] = 1.99f,
//                ["com.pullpin3dios.packspecial"] = 6.99f,
//                #endif
//            };

//            Data.IapRevenue += dollarDictionary[productId];
            
//            SetUserProperty(Constant.IAP_REVENUE, $"${Data.IapRevenue}$");
//        }
//    }
    
//    private static void UpdateTrackingBannerAds()
//    {
//        SetUserProperty(Constant.BANNER_AD_COUNT, Data.BannerAdCount.ToString());
//    }
    
//    private static void UpdateTrackingInterstitialAds()
//    {
//        SetUserProperty(Constant.INTERSTITIAL_AD_COUNT, Data.InterstitialAdCount.ToString());
//    }
    
//    private static void UpdateTrackingRewardAds()
//    {
//        SetUserProperty(Constant.REWARD_AD_COUNT, Data.RewardAdCount.ToString());
//    }
    
//    private static void UpdateTrackingAchieveCoin()
//    {
//        SetUserProperty(Constant.ACHIEVE_COIN, Data.AchieveCoin.ToString());
//    }

//    private static void UpdateTrackingSpentCoin()
//    {
//        SetUserProperty(Constant.SPENT_COIN, Data.SpentCoin.ToString());
//    }
    
//    private static void UpdateTrackingPinSkinCount()
//    {
//        SetUserProperty(Constant.PIN_SKIN_COUNT, Data.PinSkinCount.ToString());
//    }
    
//    private static void UpdateTrackingBallSkinCount()
//    {
//        SetUserProperty(Constant.BALL_SKIN_COUNT, Data.BallSkinCount.ToString());
//    }
    
//    private static void UpdateTrackingThemeSkinCount()
//    {
//        SetUserProperty(Constant.THEME_SKIN_COUNT, Data.ThemeSkinCount.ToString());
//    }
    
//    private static void UpdateTrackingTrailSkinCount()
//    {
//        SetUserProperty(Constant.TRAIL_SKIN_COUNT, Data.TrailSkinCount.ToString());
//    }
    
//    private static void UpdateTrackingAvatarSkinCount()
//    {
//        SetUserProperty(Constant.AVATAR_SKIN_COUNT, Data.AvatarSkinCount.ToString());
//    }
    
//    private static void UpdateTrackingUnlockedAreaCount()
//    {
//        SetUserProperty(Constant.UNLOCKED_AREA_COUNT, Data.UnlockAreaCount.ToString());
//    }

//    #endregion

//    #region BaseLogFunction

//    private static bool IsMobile()
//    {
//        return Application.platform == RuntimePlatform.Android ||
//               Application.platform == RuntimePlatform.IPhonePlayer;
//    }

//    private static void LogEvent(string paramName, Parameter[] parameters)
//    {
//        // if (!IsMobile()) return;
//        try
//        {
//            FirebaseAnalytics.LogEvent(paramName, parameters);
//        }
//        catch (Exception e)
//        {
//            Debug.LogError("Event log error: " + e);
//            throw;
//        }
//    }

//    private static void LogEvent(string paramName)
//    {
//        if (!IsMobile()) return;
//        try
//        {
//            FirebaseAnalytics.LogEvent(paramName);
//        }
//        catch (Exception e)
//        {
//            Debug.LogError("Event log error: " + e);
//            throw;
//        }
//    }

//    public static void SetUserProperty(string name, string property)
//    {
//        if(!IsMobile() || dependencyStatus != DependencyStatus.Available) return;
//        try
//        {
//            FirebaseAnalytics.SetUserProperty(name, property);
//        }
//        catch (Exception e)
//        {
//            Debug.LogError($"User property log error:  {e.ToString()}");
//            throw;
//        }
//    }

//    #endregion
}