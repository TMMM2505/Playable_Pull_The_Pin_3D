using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Pancake.GameService;
//using PlayFab.ClientModels;
using UnityEngine;

public static partial class Data
{
    public static int LoseNumberBeforeWin
    {
        get => GetInt("LOSE_NUMBER_BEFORE_WIN", 0);
        set => SetInt("LOSE_NUMBER_BEFORE_WIN", value);
    }

    public static bool IsShowRestoreDataWaring
    {
        get => GetBool(Constant.IS_SHOW_RESTORE_DATA_WARNING, true);
        set => SetBool(Constant.IS_SHOW_RESTORE_DATA_WARNING, value);
    }

    public static string CreatedTimestamp
    {
        get => GetString(Constant.CREATED_TIMESTAMP, DateTime.Now.ToString());
        set => SetString(Constant.CREATED_TIMESTAMP, value);
    }

    public static bool IsTesting
    {
        get => PlayerPrefs.GetInt(Constant.IS_TESTING, 0) == 1;
        set
        {
            PlayerPrefs.SetInt(Constant.IS_TESTING, value ? 1 : 0);
            EventController.OnDebugging?.Invoke();
        }
    }

    #region GAME_DATA

    //public static string LastTimeShowCollapsibleAds
    //{
    //    get => PlayerPrefs.GetString(Constant.LAST_TIME_SHOW_COLLAPSIBLE_ADS, DateTime.Now.ToString());
    //    set => PlayerPrefs.SetString(Constant.LAST_TIME_SHOW_COLLAPSIBLE_ADS, value);
    //}

    //public static int NumberOpenGame
    //{
    //    get => PlayerPrefs.GetInt(Constant.NUMBERS_OPEN_GAME, 0);
    //    set => PlayerPrefs.SetInt(Constant.NUMBERS_OPEN_GAME, value);
    //}

    //public static bool FirstUnlockChallenge
    //{
    //    get => GetBool(Constant.FIRST_UNLOCK_CHALLENGE, true);
    //    set => SetBool(Constant.FIRST_UNLOCK_CHALLENGE, value);
    //}

    //public static bool FirstUnlockBuilding
    //{
    //    get => GetBool(Constant.FIRST_UNLOCK_BUILDING, true);
    //    set => SetBool(Constant.FIRST_UNLOCK_BUILDING, value);
    //}

    //public static string LastOpenGame
    //{
    //    get => GetString(Constant.LAST_OPEN_GAME, DateTime.Today.AddDays(-1).ToString());
    //    set => SetString(Constant.LAST_OPEN_GAME, value);
    //}

    //public static string FacebookLoginToken
    //{
    //    get => GetString(Constant.FACEBOOK_LOGIN_TOKEN, string.Empty);
    //    set => SetString(Constant.FACEBOOK_LOGIN_TOKEN, value);
    //}


    //public static bool IsFirstOpenGameOnToday()
    //{
    //    return (int)(DateTime.Now - DateTime.Parse(LastOpenGame)).TotalDays != 0;
    //}

    #endregion

    #region SOUND_DATA

    public static bool SoundState
    {
        get => GetBool(Constant.SOUND_STATE, true);
        set => SetBool(Constant.SOUND_STATE, value);
    }

    public static bool MusicState
    {
        get => GetBool(Constant.MUSIC_STATE, true);
        set => SetBool(Constant.MUSIC_STATE, value);
    }

    public static bool VibrateState
    {
        get => GetBool(Constant.VIBRATE_STATE, true);
        set => SetBool(Constant.VIBRATE_STATE, value);
    }

    #endregion

    #region DAILY_REWARD

    public static bool IsClaimedTodayDailyReward()
    {
        return (int)(DateTime.Now - DateTime.Parse(LastDailyRewardClaimed)).TotalDays == 0;
    }

    public static bool IsShowPopupRating
    {
        get => PlayerPrefs.GetInt(Constant.IS_SHOW_POPUP_RATING, 0) == 1;
        set => PlayerPrefs.SetInt(Constant.IS_SHOW_POPUP_RATING, value ? 1 : 0);
    }

    public static bool IsStartLoopingDailyReward
    {
        get => PlayerPrefs.GetInt(Constant.IS_START_LOOPING_DAILY_REWARD, 0) == 1;
        set => PlayerPrefs.SetInt(Constant.IS_START_LOOPING_DAILY_REWARD, value ? 1 : 0);
    }

    public static int DailyRewardDayIndex
    {
        get => GetInt(Constant.DAILY_REWARD_DAY_INDEX, 1);
        set => SetInt(Constant.DAILY_REWARD_DAY_INDEX, value);
    }

    public static string LastDailyRewardClaimed
    {
        get => GetString(Constant.LAST_DAILY_REWARD_CLAIM, DateTime.Now.AddDays(-1).ToString());
        set => SetString(Constant.LAST_DAILY_REWARD_CLAIM, value);
    }

    public static int TotalClaimDailyReward
    {
        get => GetInt(Constant.TOTAL_CLAIM_DAILY_REWARD, 0);
        set => SetInt(Constant.TOTAL_CLAIM_DAILY_REWARD, value);
    }

    #endregion

    #region PLAYER_DATA

    public static int CurrencyTotal
    {
        get => GetInt(Constant.CURRENCY_TOTAL, 0);
        set
        {
            if (value > CurrencyTotal) AchieveCoin += (value - CurrencyTotal);
            else SpentCoin += (CurrencyTotal - value);

            EventController.SaveCurrencyTotal?.Invoke();
            SetInt(Constant.CURRENCY_TOTAL, value);
            EventController.CurrencyTotalChanged?.Invoke();
            EventController.OnNotifying?.Invoke();
        }
    }

    public static int PercentWinGift
    {
        get => PlayerPrefs.GetInt(Constant.PERCENT_WIN_GIFT, 0);
        set => PlayerPrefs.SetInt(Constant.PERCENT_WIN_GIFT, value);
    }

    public static int CurrentBallSkinId
    {
        get => GetInt(Constant.CURRENT_BALL_SKIN, 1);

        set
        {
            SetInt(Constant.CURRENT_BALL_SKIN, value);
            EventController.CurrentBallChanged?.Invoke();
        }
    }

    public static int CurrentPinSkinId
    {
        get => GetInt(Constant.CURRENT_PIN_SKIN, 1);

        set
        {
            SetInt(Constant.CURRENT_PIN_SKIN, value);
            EventController.CurrentPinChanged?.Invoke();
        }
    }

    public static int CurrentThemeSkinId
    {
        get => GetInt(Constant.CURRENT_THEME_SKIN, 1);

        set
        {
            SetInt(Constant.CURRENT_THEME_SKIN, value);
            EventController.CurrentThemeChanged?.Invoke();
        }
    }

    public static int CurrentTrailSkinId
    {
        get => GetInt(Constant.CURRENT_TRAIL_SKIN, 0);

        set
        {
            SetInt(Constant.CURRENT_TRAIL_SKIN, value);
            EventController.CurrentTrailChanged?.Invoke();
        }
    }

    public static string IdSkinCheckUnlocked = "";

    public static bool IsSkinUnlocked
    {
        get => GetBool(IdSkinCheckUnlocked);
        set => SetBool(IdSkinCheckUnlocked, value);
    }

    //public static bool PurchasedRemoveAds => ConfigController.IAPConfig.IsPurchasedRemoveAds;

    public static bool IsIAPPackUnlocked(string name)
    {
        return GetBool($"IAP_{name}");
    }

    #endregion

    #region BUILD_CITY

    // Old Value
    public static string IdBuildingCheckUnlocked = "";

    public static bool IsBuildingUnlocked
    {
        get => GetBool(IdBuildingCheckUnlocked);
        set => SetBool(IdBuildingCheckUnlocked, value);
    }

    public static int CurrentMap
    {
        get => GetInt("CURRENT_MAP", 0);
        set => SetInt("CURRENT_MAP", value);
    }

    // New Value
    public static string IdBuilding = "";

    public static bool FirstTimeGetBuildingData
    {
        get => GetBool("FirstTimeGetBuildingData", true);
        set => SetBool("FirstTimeGetBuildingData", value);
    }

    //// Set old building data for new building -> remove in next version (4.4 for android or 7.6 for ios)///
    public static void GetOldBuildingData()
    {
        var buildingDictionary = new Dictionary<string, string>()
         {
             { "Building_Map1Flower", "Building_Coffee" },
             { "Building_Map1House", "Building_GasStation" },
             { "Building_Map1Stove", "Building_Mall" },
             { "Building_Map1WareHouse", "Building_Restaurant" },
             { "Building_Map1WaterFall", "Building_Shop" },
             { "Building_Map1WindMill", "Building_Stadium" },
             { "Building_Map1Farm", "Building_WapDonal" },

             { "Building_Map2Flower", "Building_ChillPlace" },
             { "Building_Map2House", "Building_GreenVilla" },
             { "Building_Map2Mountain", "Building_LightHouse" },
             { "Building_Map2WareHouse", "Building_PlayPlace" },
             { "Building_Map2Water", "Building_Race" },
             { "Building_Map2Stove", "Building_BeachRestaurant" },
             { "Building_Map2WindMill", "Building_SuperShip" },
         };

        foreach (var item in buildingDictionary)
        {
            if (GetInt(item.Key, 0) == 0)
            {
                SetInt(item.Key, GetInt(item.Value, 0));
            }
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    public static int CurrentLevelBuilding
    {
        get => GetInt(IdBuilding, 0);
        set => SetInt(IdBuilding, value);
    }

    #endregion

    #region FIREBASE

    public static bool IsLogStartFirstLevel(int level)
    {
        return GetBool($"FirstStartLevel_{level}");
    }

    public static void SetLogStartFirstLevel(int level, bool isOwned = true)
    {
        SetBool($"FirstStartLevel_{level}", isOwned);
    }

    // TOGGLE LEVEL AB TESTING? 0:NO, 1:YES
    public static int DEFAULT_USE_LEVEL_AB_TESTING = 0;

    public static int UseLevelABTesting
    {
        get => PlayerPrefs.GetInt(Constant.USE_LEVEL_AB_TESTING, DEFAULT_USE_LEVEL_AB_TESTING);
        set => PlayerPrefs.SetInt(Constant.USE_LEVEL_AB_TESTING, value);
    }

    public static int DEFAULT_USE_NPC_AB_TESTING = 0;

    public static int UseNPCABTesting
    {
        get => PlayerPrefs.GetInt(Constant.USE_NPC_AB_TESTING, DEFAULT_USE_NPC_AB_TESTING);
        set => PlayerPrefs.SetInt(Constant.USE_NPC_AB_TESTING, value);
    }

    // SET LEVEL TO ENABLE INTERSTITIAL
    public static int DEFAULT_LEVEL_TURN_ON_INTERSTITIAL = 5;

    public static int LevelTurnOnInterstitial
    {
        get => PlayerPrefs.GetInt(Constant.LEVEL_TURN_ON_INTERSTITIAL,
            DEFAULT_LEVEL_TURN_ON_INTERSTITIAL);
        set => PlayerPrefs.SetInt(Constant.LEVEL_TURN_ON_INTERSTITIAL, value);
    }

    // SET COUNTER VARIABLE
    public static int DEFAULT_COUNTER_NUMBER_BETWEEN_TWO_INTERSTITIAL = 2;

    public static int CounterNumbBetweenTwoInterstitial
    {
        get => PlayerPrefs.GetInt(Constant.COUNTER_NUMBER_BETWEEN_TWO_INTERSTITIAL,
            DEFAULT_COUNTER_NUMBER_BETWEEN_TWO_INTERSTITIAL);
        set => PlayerPrefs.SetInt(Constant.COUNTER_NUMBER_BETWEEN_TWO_INTERSTITIAL, value);
    }

    // SET TIME TO ENABLE BETWEEN 2 INTERSTITIAL (ON WIN,LOSE,REPLAY GAME)
    public static int DEFAULT_SPACE_TIME_WIN_BETWEEN_TWO_INTERSTITIAL = 30;

    public static int TimeWinBetweenTwoInterstitial
    {
        get => PlayerPrefs.GetInt(Constant.SPACE_TIME_WIN_BETWEEN_TWO_INTERSTITIAL,
            DEFAULT_SPACE_TIME_WIN_BETWEEN_TWO_INTERSTITIAL);
        set => PlayerPrefs.SetInt(Constant.SPACE_TIME_WIN_BETWEEN_TWO_INTERSTITIAL, value);
    }

    // TOGGLE SHOW INTERSTITIAL ON LOSE GAME ? 0:NO, 1:YES
    public static int DEFAULT_SHOW_INTERSTITIAL_ON_LOSE_GAME = 0;

    public static int UseShowInterstitialOnLoseGame
    {
        get => PlayerPrefs.GetInt(Constant.SHOW_INTERSTITIAL_ON_LOSE_GAME, DEFAULT_SHOW_INTERSTITIAL_ON_LOSE_GAME);
        set => PlayerPrefs.SetInt(Constant.SHOW_INTERSTITIAL_ON_LOSE_GAME, value);
    }

    // SET TIME TO ENABLE BETWEEN 2 INTERSTITIAL (ON LOSE GAME)
    public static int DEFAULT_SPACE_TIME_LOSE_BETWEEN_TWO_INTERSTITIAL = 45;

    public static int TimeLoseBetweenTwoInterstitial
    {
        get => PlayerPrefs.GetInt(Constant.SPACE_TIME_LOSE_BETWEEN_TWO_INTERSTITIAL,
            DEFAULT_SPACE_TIME_LOSE_BETWEEN_TWO_INTERSTITIAL);
        set => PlayerPrefs.SetInt(Constant.SPACE_TIME_LOSE_BETWEEN_TWO_INTERSTITIAL, value);
    }

    public static int DEFAULT_USE_APP_OPEN_ADS = 1;

    public static int UseAppOpenAds
    {
        get => PlayerPrefs.GetInt(Constant.USE_APP_OPEN_ADS, DEFAULT_USE_APP_OPEN_ADS);
        set => PlayerPrefs.SetInt(Constant.USE_APP_OPEN_ADS, value);
    }

    public static int DEFAULT_USE_SHOW_BANNER = 1;

    public static int UseShowBanner
    {
        get => PlayerPrefs.GetInt(Constant.USE_SHOW_BANNER, DEFAULT_USE_SHOW_BANNER);
        set => PlayerPrefs.SetInt(Constant.USE_SHOW_BANNER, value);
    }

    public static int DEFAULT_LEVEL_AB_13032023 = 0;

    public static int LevelAB13032023
    {
        get => PlayerPrefs.GetInt(Constant.LEVEL_AB_13032023, DEFAULT_LEVEL_AB_13032023);
        set => PlayerPrefs.SetInt(Constant.LEVEL_AB_13032023, value);
    }

    public static int TIME_BETWEEN_COLLAPSIBLE
    {
        get => PlayerPrefs.GetInt(Constant.TIME_BETWEEN_COLLAPSIBLE_BANNER_ADS, 180);
        set => PlayerPrefs.SetInt(Constant.TIME_BETWEEN_COLLAPSIBLE_BANNER_ADS, value);
    }

    public static int FirstTimeShowBannerCollapsible
    {
        get => PlayerPrefs.GetInt("first_time_show_banner_collapsible", 1);
        set => PlayerPrefs.SetInt("first_time_show_banner_collapsible", value);
    }

    public static int USE_COLLAPSIBLE_BANNER_ADS
    {
        get => PlayerPrefs.GetInt(Constant.USE_COLLAPSIBLE_BANNER_ADS, 1);
        set => PlayerPrefs.SetInt(Constant.USE_COLLAPSIBLE_BANNER_ADS, value);
    }

    #endregion

    #region Event

    public static int EventHalloweenItem2023
    {
        get => PlayerPrefs.GetInt(Constant.EVENT_HALLOWEEN_ITEM_2023, 0);
        set => PlayerPrefs.SetInt(Constant.EVENT_HALLOWEEN_ITEM_2023, value);
    }

    public static int EventNoelItem2023
    {
        get => PlayerPrefs.GetInt(Constant.EVENT_NOEL_ITEM_2023, 0);
        set => PlayerPrefs.SetInt(Constant.EVENT_NOEL_ITEM_2023, value);
    }

    #endregion

    #region Card Collection

    public static bool IsReceivedCardCollectionGift
    {
        get => GetBool(Constant.RECEIVED_CARD_COLLECTION_GIFT);
        set => SetBool(Constant.RECEIVED_CARD_COLLECTION_GIFT, value);
    }

    public static bool IsCompleteCardTutorial
    {
        get => GetBool(Constant.COMPLETE_CARD_TUTORIAL);
        set => SetBool(Constant.COMPLETE_CARD_TUTORIAL, value);
    }

    public static bool FirstOpenGame
    {
        get => GetBool(Constant.FIRST_OPEN_GAME, true);
        set => SetBool(Constant.FIRST_OPEN_GAME, value);
    }

    public static string PackId = "";

    public static bool IsReceivedPackCompleteGift
    {
        get => GetBool(PackId);
        set => SetBool(PackId, value);
    }

    public static bool IsPackNewlyUnlocked
    {
        get => GetBool(PackId, true);
        set => SetBool(PackId, value);
    }

    public static string CardId = "";

    public static int CardOwned
    {
        get => GetInt(CardId, 0);
        set => SetInt(CardId, value);
    }

    public static bool CardNewlyUnlocked
    {
        get => GetBool(CardId, true);
        set => SetBool(CardId, value);
    }

    #endregion

    #region PLAYFAB_DATA

    public static string PlayfabLoginId
    {
        get => GetString(Constant.PLAYFAB_LOGIN_ID, null);
        set => SetString(Constant.PLAYFAB_LOGIN_ID, value);
    }

    // public static string CustomId
    // {
    //     get => GetString(Constant.CUSTOM_ID, string.Empty);
    //     set => SetString(Constant.CUSTOM_ID, value);
    // }

    public static string PlayerName
    {
        get => GetString(Constant.PLAYER_NAME, string.Empty);
        set => SetString(Constant.PLAYER_NAME, value);
    }


    #endregion

    #region Leaderboard Event

    public static bool IsCompleteEventTutorial
    {
        get => GetBool(Constant.COMPLETE_EVENT_TUTORIAL);
        set => SetBool(Constant.COMPLETE_EVENT_TUTORIAL, value);
    }

    public static bool IsCompleteEventPopupTutorial
    {
        get => GetBool(Constant.COMPLETE_EVENT_POPUP_TUTORIAL);
        set => SetBool(Constant.COMPLETE_EVENT_POPUP_TUTORIAL, value);
    }

    public static bool PlayingLeaderboardEvent
    {
        get => GetBool(Constant.PLAYING_LEADERBOARD_EVENT);
        set => SetBool(Constant.PLAYING_LEADERBOARD_EVENT, value);
    }

    public static string PlayerListJson
    {
        get => GetString(Constant.LEADERBOARD_EVENT_PLAYER_DICT, "");
        set => SetString(Constant.LEADERBOARD_EVENT_PLAYER_DICT, value);
    }

    public static double EventStartDateTime
    {
        get => TimeUtils.DateTimeToSeconds(DateTime.Parse(GetString(Constant.LEADERBOARD_EVENT_START_TIME,
            TimeUtils.Epoch.ToString(CultureInfo.CurrentCulture))));
        set => SetString(Constant.LEADERBOARD_EVENT_START_TIME,
            TimeUtils.SecondsToDateTime(value).ToString(CultureInfo.CurrentCulture));
    }

    public static double LastTimePlayEvent
    {
        get => TimeUtils.DateTimeToSeconds(DateTime.Parse(GetString(Constant.LEADERBOARD_EVENT_LAST_PLAY_TIME,
            TimeUtils.Epoch.ToString(CultureInfo.CurrentCulture))));
        set => SetString(Constant.LEADERBOARD_EVENT_LAST_PLAY_TIME,
            TimeUtils.SecondsToDateTime(value).ToString(CultureInfo.CurrentCulture));
    }

    public static int PlayedTimeSinceEventStart
    {
        get => GetInt(Constant.PLAYED_TIME_SINCE_EVENT_START, 0);
        set => SetInt(Constant.PLAYED_TIME_SINCE_EVENT_START, value);
    }

    #endregion

    #region StarBonus

    public static int StarGot
    {
        get => GetInt(Constant.STAR_GOT, 0);
        set => SetInt(Constant.STAR_GOT, value);
    }

    public static bool ChooseCardFirstTime
    {
        get => GetBool(Constant.CHOOSE_CARD_FIRST_TIME, true);
        set => SetBool(Constant.CHOOSE_CARD_FIRST_TIME, value);
    }

    #endregion

    #region NoBackupData

    public static bool IsBackedUpRankData
    {
        get => GetBool(Constant.IS_BACKED_UP_RANK_DATA);
        set => SetBool(Constant.IS_BACKED_UP_RANK_DATA, value);
    }

    public static bool IsRestoredPurchase
    {
        get => GetBool(Constant.IS_RESTORED_PURCHASE);
        set => SetBool(Constant.IS_RESTORED_PURCHASE, value);
    }

    #endregion

    #region Event looker

    public static int CurrentLevel
    {
        get => GetInt(Constant.INDEX_LEVEL_CURRENT, 1);

        set
        {
            SetInt(Constant.INDEX_LEVEL_CURRENT, value >= 1 ? value : 1);
            EventController.CurrentLevelChanged?.Invoke();

            //hardcode for tracking unlocked area, fix when change level unlocked of mapItem
            SetAreaCount();
        }
    }

    public static int HighestLevelMultiply
    {
        get => GetInt(Constant.MULTIPY_CURRENT, 1);

        set
        {
            if (value < HighestLevelMultiply) return;
            SetInt(Constant.MULTIPY_CURRENT, value >= 1 ? value : 1);
            EventController.WinLevelMultiply?.Invoke();
        }
    }

    public static int HighestLevelChallenge
    {
        get => GetInt(Constant.CHALLENGE_CURRENT, 1);

        set
        {
            if (value < HighestLevelChallenge) return;
            SetInt(Constant.CHALLENGE_CURRENT, value >= 1 ? value : 1);
            EventController.WinLevelChallenge?.Invoke();
        }
    }

    public static int IapCount
    {
        get => GetInt(Constant.IAP_COUNT, 0);
        set => SetInt(Constant.IAP_COUNT, value);
    }

    public static float IapRevenue
    {
        get => GetFloat(Constant.IAP_REVENUE, 0);
        set => SetFloat(Constant.IAP_REVENUE, value);
    }

    public static int BannerAdCount
    {
        get => GetInt(Constant.BANNER_AD_COUNT, 0);
        set
        {
            SetInt(Constant.BANNER_AD_COUNT, value);
            EventController.BannerAdsShow?.Invoke();
        }
    }

    public static int InterstitialAdCount
    {
        get => GetInt(Constant.INTERSTITIAL_AD_COUNT, 0);
        set
        {
            SetInt(Constant.INTERSTITIAL_AD_COUNT, value);
            EventController.InterstitialAdsShow?.Invoke();
        }
    }

    public static int RewardAdCount
    {
        get => GetInt(Constant.REWARD_AD_COUNT, 0);
        set
        {
            SetInt(Constant.REWARD_AD_COUNT, value);
            EventController.RewardAdsShow?.Invoke();
        }
    }

    public static int AchieveCoin
    {
        get => GetInt(Constant.ACHIEVE_COIN, 0);
        set
        {
            SetInt(Constant.ACHIEVE_COIN, value);
            EventController.AchieveCoin?.Invoke();
        }
    }

    public static int SpentCoin
    {
        get => GetInt(Constant.SPENT_COIN, 0);
        set
        {
            SetInt(Constant.SPENT_COIN, value);
            EventController.SpentCoin?.Invoke();
        }
    }

    public static int PinSkinCount
    {
        get => GetInt(Constant.PIN_SKIN_COUNT, 1);
        set
        {
            SetInt(Constant.PIN_SKIN_COUNT, value);
            EventController.PinSkinCount?.Invoke();
        }
    }

    public static int BallSkinCount
    {
        get => GetInt(Constant.BALL_SKIN_COUNT, 1);
        set
        {
            SetInt(Constant.BALL_SKIN_COUNT, value);
            EventController.BallSkinCount?.Invoke();
        }
    }

    public static int ThemeSkinCount
    {
        get => GetInt(Constant.THEME_SKIN_COUNT, 1);
        set
        {
            SetInt(Constant.THEME_SKIN_COUNT, value);
            EventController.ThemeSkinCount?.Invoke();
        }
    }

    public static int TrailSkinCount
    {
        get => GetInt(Constant.TRAIL_SKIN_COUNT, 1);
        set
        {
            SetInt(Constant.TRAIL_SKIN_COUNT, value);
            EventController.TrailSkinCount?.Invoke();
        }
    }

    public static int AvatarSkinCount
    {
        get => GetInt(Constant.AVATAR_SKIN_COUNT, 0);
        set
        {
            SetInt(Constant.AVATAR_SKIN_COUNT, value);
            EventController.AvatarSkinCount?.Invoke();
        }
    }

    private static void SetAreaCount()
    {
        UnlockAreaCount = CurrentLevel switch
        {
            >= 350 => 8,
            >= 300 => 7,
            >= 250 => 6,
            >= 200 => 5,
            >= 150 => 4,
            >= 100 => 3,
            >= 50 => 2,
            >= 26 => 1,
            _ => UnlockAreaCount
        };
    }

    public static int UnlockAreaCount
    {
        get => GetInt(Constant.UNLOCKED_AREA_COUNT, 0);
        set
        {
            if (UnlockAreaCount == value) return;
            SetInt(Constant.UNLOCKED_AREA_COUNT, value);
            EventController.UnLockAreaCount?.Invoke();
        }
    }

    #endregion
}

public static partial class Data
{
    private static double GetDouble(string key, double defaultValue)
    {
        var defaultVal = DoubleToString(defaultValue);
        return StringToDouble(PlayerPrefs.GetString(key, defaultVal));
    }

    private static void SetDouble(string key, double value)
    {
        PlayerPrefs.SetString(key, DoubleToString(value));
    }

    private static string DoubleToString(double target)
    {
        return target.ToString("R");
    }

    private static double StringToDouble(string target)
    {
        return string.IsNullOrEmpty(target) ? 0d : double.Parse(target);
    }

    private static bool GetBool(string key, bool defaultValue = false)
    {
        return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) > 0;
    }

    private static void SetBool(string id, bool value)
    {
        PlayerPrefs.SetInt(id, value ? 1 : 0);
    }

    private static int GetInt(string key, int defaultValue)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    private static void SetInt(string id, int value)
    {
        PlayerPrefs.SetInt(id, value);
    }

    private static float GetFloat(string key, float defaultValue)
    {
        return PlayerPrefs.GetFloat(key, defaultValue);
    }

    private static void SetFloat(string id, float value)
    {
        PlayerPrefs.SetFloat(id, value);
    }

    private static string GetString(string key, string defaultValue)
    {
        return PlayerPrefs.GetString(key, defaultValue);
    }

    private static void SetString(string id, string value)
    {
        PlayerPrefs.SetString(id, value);
    }
}