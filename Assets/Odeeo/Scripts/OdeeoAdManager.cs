using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Odeeo
{
    public class OdeeoAdManager : MonoBehaviour
    {
        private static readonly Dictionary<string, OdeeoAdUnit> s_adUnits = new Dictionary<string, OdeeoAdUnit>();

        #region Creation

        public static void CreateAudioBannerAd(string placementID)
        {
            CreateAd(OdeeoSdk.PlacementType.AudioBannerAd, placementID);
        }

        public static void CreateAudioIconAd(string placementID)
        {
            CreateAd(OdeeoSdk.PlacementType.AudioIconAd, placementID);
        }

        public static void CreateRewardedAudioBannerAd(string placementID)
        {
            CreateAd(OdeeoSdk.PlacementType.RewardedAudioBannerAd, placementID);
        }

        public static void CreateRewardedAudioIconAd(string placementID)
        {
            CreateAd(OdeeoSdk.PlacementType.RewardedAudioIconAd, placementID);
        }

        private static void CreateAd(OdeeoSdk.PlacementType adType, string placementID)
        {
            if (!OdeeoSdk.IsInitialized())
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Info,"Creation Audio Ad failed. OdeeoSDK is not Initialized.");
                return;
            }
            
            if (s_adUnits.ContainsKey(placementID))
            {
                OdeeoSdk.LogW(OdeeoSdk.LogLevel.Info,"Creation Audio Ad failed, this placement already exists.");
                return;
            }

            OdeeoAdUnit adUnit = new OdeeoAdUnit(adType, placementID);
            s_adUnits.Add(placementID, adUnit);
        }

        #endregion

        #region General

        public static void ShowAd(string placementID)
        {
            if (!s_adUnits.ContainsKey(placementID))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Info,"ShowAd failed, placement doesn't exists");
                return;
            }
            
#if UNITY_EDITOR
            if (IsAnyAdPlaying())
            {
                if (GetCurrentPlayingAdCount() > 1)
                {
                    s_adUnits[placementID].DispatchOnShowError(OdeeoAdUnit.ErrorShowReason.AnotherAdPlaying);
                    return;
                }
                
                OdeeoAdUnit playingAd = GetCurrentPlayingAd();
                bool isPlayAllowed = !IsAdRewardedType(playingAd.PlacementType) &&
                                     IsAdRewardedType(s_adUnits[placementID].PlacementType);

                if (!isPlayAllowed)
                {
                    s_adUnits[placementID].DispatchOnShowError(s_adUnits[placementID].IsPlaying
                        ? OdeeoAdUnit.ErrorShowReason.CurrentAdPlaying
                        : OdeeoAdUnit.ErrorShowReason.AnotherAdPlaying);
                    return;
                }
                
                playingAd.EditorAdUnit.SetPause(true, OdeeoAdUnit.StateChangeReason.OtherOdeeoPlacementStart);

                void Unpause(OdeeoAdUnit.CloseReason reason)
                {
                    if(playingAd != null && playingAd.EditorAdUnit)
                        playingAd.EditorAdUnit.SetPause(false, OdeeoAdUnit.StateChangeReason.OtherOdeeoPlacementEnd);
                    
                    s_adUnits[placementID].AdCallbacks.OnClose -= Unpause;
                }

                s_adUnits[placementID].AdCallbacks.OnClose += Unpause;
            }
#endif

            s_adUnits[placementID].ShowAd();
        }

        public static void RemoveAd(string placementID)
        {
            if (!s_adUnits.ContainsKey(placementID))
                return;

            s_adUnits[placementID].RemoveAd();
        }

        public static void SetIconPosition(string placementID, OdeeoSdk.IconPosition iconPosition, int xOffset, int yOffset)
        {
            if (!s_adUnits.ContainsKey(placementID))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Info,"SetIconPosition failed, placement doesn't exists");
                return;
            }

            s_adUnits[placementID].SetIconPosition(iconPosition, xOffset, yOffset);
        }

        public static void SetIconSize(string placementID, int size)
        {
            if (!s_adUnits.ContainsKey(placementID))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Info,"SetIconSize failed, placement doesn't exists");
                return;
            }

            s_adUnits[placementID].SetIconSize(size);
        }

        public static void SetBannerPosition(string placementID, OdeeoSdk.BannerPosition position)
        {
            if (!s_adUnits.ContainsKey(placementID))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Info,"SetBannerPosition failed, placement doesn't exists");
                return;
            }

            s_adUnits[placementID].SetBannerPosition(position);
        }

        #endregion

        #region Positioning

        public static void LinkToIconAnchor(string placementID, OdeeoIconAnchor iconAnchor)
        {
            if (!s_adUnits.ContainsKey(placementID))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Info,"LinkToIconAnchor failed, placement doesn't exists");
                return;
            }

            s_adUnits[placementID].LinkToIconAnchor(iconAnchor);
        }

        public static void LinkIconToRectTransform(string placementID, OdeeoSdk.IconPosition iconPosition,
            RectTransform rectTransform, Canvas canvas,
            OdeeoSdk.AdSizingMethod sizingMethod = OdeeoSdk.AdSizingMethod.Flexible)
        {
            if (!s_adUnits.ContainsKey(placementID))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Info,"LinkIconToRectTransform failed, placement doesn't exists");
                return;
            }

            s_adUnits[placementID].LinkIconToRectTransform(iconPosition, rectTransform, canvas, sizingMethod);
        }

        #endregion

        #region VisualSettings

        public static void SetAudioOnlyBackground(string placementID, Color color)
        {
            if (!s_adUnits.ContainsKey(placementID))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Info,"SetAudioOnlyBackgroundColor failed, placement doesn't exists");
                return;
            }

            s_adUnits[placementID].SetAudioOnlyBackgroundColor(color);
        }

        public static void SetAudioOnlyAnimation(string placementID, Color color)
        {
            if (!s_adUnits.ContainsKey(placementID))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Info,"SetAudioOnlyAnimationColor failed, placement doesn't exists");
                return;
            }

            s_adUnits[placementID].SetAudioOnlyAnimationColor(color);
        }

        public static void SetProgressBar(string placementID, Color progressBarColor)
        {
            if (!s_adUnits.ContainsKey(placementID))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Info,"SetVisualisationColors failed, placement doesn't exists");
                return;
            }

            s_adUnits[placementID].SetProgressBarColor(progressBarColor);
        }

        #endregion

        #region RewardSettings

        public static void SetRewardedPopupType(string placementID, OdeeoAdUnit.PopUpType type)
        {
            if (!s_adUnits.ContainsKey(placementID))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Info,"SetRewardedPopupType failed, placement doesn't exists");
                return;
            }

            s_adUnits[placementID].SetRewardedPopupType(type);
        }

        public static void SetRewardedPopupBannerPosition(string placementID, OdeeoSdk.BannerPosition bannerPosition)
        {
            if (!s_adUnits.ContainsKey(placementID))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Info,"SetRewardedPopupBannerPosition failed, placement doesn't exists");
                return;
            }
            
            s_adUnits[placementID].SetRewardedPopupBannerPosition(bannerPosition);
        }
        
        public static void SetRewardedPopupIconPosition(string placementID, OdeeoSdk.IconPosition iconPosition, int xOffset,
            int yOffset)
        {
            if (!s_adUnits.ContainsKey(placementID))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Info,"SetRewardedPopupIconPosition failed, placement doesn't exists");
                return;
            }

            s_adUnits[placementID].SetRewardedPopupIconPosition(iconPosition, xOffset, yOffset);
        }

        #endregion

        #region ActionButtonSettings

        public static void SetIconActionButtonPosition(string placementID, OdeeoAdUnit.ActionButtonPosition position)
        {
            if (!s_adUnits.ContainsKey(placementID))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Info,"SetIconActionButtonPosition failed, placement doesn't exists");
                return;
            }
            
            s_adUnits[placementID].SetIconActionButtonPosition(position);
        }

        #endregion

        public static void SetCustomTag(string placementID, string tag)
        {
            if (!s_adUnits.ContainsKey(placementID))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Info,"SetCustomTag failed, placement doesn't exists");
                return;
            }

            s_adUnits[placementID].SetCustomTag(tag);
        }

        public static void TrackRewardedOffer(string placementID)
        {
            if (!s_adUnits.ContainsKey(placementID))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Info,"TrackRewardedOffer failed, placement doesn't exists");
                return;
            }

            s_adUnits[placementID].TrackRewardedOffer();
        }

        public static OdeeoAdListener AdUnitCallbacks(string placementID)
        {
            if (!s_adUnits.ContainsKey(placementID))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Info,"AdUnitCallbacks failed, placement doesn't exists");
                return null;
            }

            return s_adUnits[placementID].AdCallbacks;
        }

        public static bool IsPlacementExist(string placementId)
        {
            return s_adUnits.ContainsKey(placementId);
        }

        public static bool IsAdAvailable(string placementId)
        {
            if (!IsPlacementExist(placementId))
                return false;

            return s_adUnits[placementId].IsAdAvailable();
        }

        public static bool IsAdCached(string placementId)
        {
            if (!IsPlacementExist(placementId))
                return false;

            return s_adUnits[placementId].IsAdCached();
        }

        public static bool IsRectTransformBlocked(string placementId)
        {
            if (!IsPlacementExist(placementId))
                return false;

            return s_adUnits[placementId].IsRectTransformBlocked();
        }

        public static bool IsAdPlaying(string placementId)
        {
            if (!IsPlacementExist(placementId))
                return false;

            return s_adUnits[placementId].IsPlaying;
        }

        public static bool IsAnyAdPlaying()
        {
            foreach (KeyValuePair<string, OdeeoAdUnit> entry in s_adUnits)
            {
                if (entry.Value.IsPlaying)
                    return true;
            }

            return false;
        }
        
        private static OdeeoAdUnit GetCurrentPlayingAd()
        {
            foreach (KeyValuePair<string, OdeeoAdUnit> entry in s_adUnits)
            {
                if (entry.Value.IsPlaying)
                    return entry.Value;
            }

            return null;
        }

        private static int GetCurrentPlayingAdCount()
        {
            int count = 0;
            
            foreach (KeyValuePair<string, OdeeoAdUnit> entry in s_adUnits)
            {
                if (entry.Value.IsPlaying)
                    count++;
            }
            
            return count;
        }

        public static bool IsIconType(OdeeoSdk.PlacementType adType)
        {
            return adType == OdeeoSdk.PlacementType.AudioIconAd || adType == OdeeoSdk.PlacementType.RewardedAudioIconAd;
        }

        public static bool IsBannerType(OdeeoSdk.PlacementType adType)
        {
            return adType == OdeeoSdk.PlacementType.AudioBannerAd ||
                   adType == OdeeoSdk.PlacementType.RewardedAudioBannerAd;
        }

        public static bool IsBannerType(OdeeoAdUnit.PopUpType popUpType)
        {
            return popUpType == OdeeoAdUnit.PopUpType.BannerPopUp;
        }

        public static bool IsAdRewardedType(OdeeoSdk.PlacementType adType)
        {
            return adType == OdeeoSdk.PlacementType.RewardedAudioIconAd ||
                   adType == OdeeoSdk.PlacementType.RewardedAudioBannerAd;
        }
    }
}