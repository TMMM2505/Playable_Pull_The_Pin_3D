using Odeeo.Data;
using UnityEngine;

namespace Odeeo.Demo
{
    public class OdeeoDemoSimple : MonoBehaviour
    {
#if UNITY_ANDROID
        private const string APP_KEY = "f0f492d3-34ea-47ad-b98f-84640bd2f36a";
        private const string BANNER_PLACEMENT_ID = "340339090";
        private const string BANNER_REWARDED_PLACEMENT_ID = "300632690";
        private const string ICON_PLACEMENT_ID = "376373450";
        private const string ICON_REWARDED_PLACEMENT_ID = "353360647";
#elif UNITY_IOS
        private const string APP_KEY = "6736cfbf-dccc-4def-a022-16b6686639e2";
        private const string BANNER_PLACEMENT_ID = "334872774";
        private const string BANNER_REWARDED_PLACEMENT_ID = "385528236";
        private const string ICON_PLACEMENT_ID = "302988162";
        private const string ICON_REWARDED_PLACEMENT_ID = "397800061";
#else
        private const string APP_KEY = "";
        private const string BANNER_PLACEMENT_ID = "";
        private const string BANNER_REWARDED_PLACEMENT_ID = "";
        private const string ICON_PLACEMENT_ID = "";
        private const string ICON_REWARDED_PLACEMENT_ID = "";
#endif
        
        [SerializeField] protected OdeeoDemoUiSimple odeeoDemoUi;
        
        private bool _isInitializationInProgress = false;

        void Start()
        {
            odeeoDemoUi.Init();
            
            InitButtons();
            RefreshButtons();
        }

        private void Initialize()
        {
            if (!OdeeoSdk.IsInitialized() && !_isInitializationInProgress)
            {
                OdeeoSdk.OnInitializationFinished += OnInitializationFinished;
                OdeeoSdk.OnInitializationFailed += OnInitializationFailed;
                
                _isInitializationInProgress = true;
            }
            
            RefreshButtons();

            OdeeoSdk.SetLogLevel(OdeeoSdk.LogLevel.Debug);
            OdeeoSdk.Initialize(APP_KEY);
        }
        
        private void OnInitializationFinished()
        {
            _isInitializationInProgress = false;
            
            odeeoDemoUi.ShowMessage("Initialization Complete", OdeeoDemoUiMessage.MessageColor.Green);

            OdeeoSdk.OnInitializationFinished -= OnInitializationFinished;
            OdeeoSdk.OnInitializationFailed -= OnInitializationFailed;
            
            // Create Icon Ad
            OdeeoAdManager.CreateAudioIconAd(ICON_PLACEMENT_ID);
            OdeeoAdManager.SetIconPosition(ICON_PLACEMENT_ID, OdeeoSdk.IconPosition.BottomRight, 10, 10);
            OdeeoAdManager.SetIconSize(ICON_PLACEMENT_ID, 80);
            SubscribePlacement(ICON_PLACEMENT_ID);
            
            //Create Banner Ad
            OdeeoAdManager.CreateAudioBannerAd(BANNER_PLACEMENT_ID);
            OdeeoAdManager.SetBannerPosition(BANNER_PLACEMENT_ID, OdeeoSdk.BannerPosition.BottomCenter);
            SubscribePlacement(BANNER_PLACEMENT_ID);
            
            // Create Rewarded Icon Ad
            OdeeoAdManager.CreateRewardedAudioIconAd(ICON_REWARDED_PLACEMENT_ID);
            OdeeoAdManager.SetIconPosition(ICON_REWARDED_PLACEMENT_ID, OdeeoSdk.IconPosition.BottomRight, 10, 10);
            OdeeoAdManager.SetIconSize(ICON_REWARDED_PLACEMENT_ID, 80);
            SubscribePlacement(ICON_REWARDED_PLACEMENT_ID);
            
            // Create Rewarded Banner Ad
            OdeeoAdManager.CreateRewardedAudioBannerAd(BANNER_REWARDED_PLACEMENT_ID);
            OdeeoAdManager.SetBannerPosition(BANNER_REWARDED_PLACEMENT_ID, OdeeoSdk.BannerPosition.BottomCenter);
            SubscribePlacement(BANNER_REWARDED_PLACEMENT_ID);
            
            RefreshButtons();
        }

        private void OnInitializationFailed(int errorParam, string error)
        {
            _isInitializationInProgress = false;
            
            odeeoDemoUi.ShowMessage("Initialization Failed: " + error, OdeeoDemoUiMessage.MessageColor.Red);
            RefreshButtons();
        }

        private void ShowIconAd()
        {
            OdeeoAdManager.ShowAd(ICON_PLACEMENT_ID);
        }

        private void ShowBannerAd()
        {
            OdeeoAdManager.ShowAd(BANNER_PLACEMENT_ID);
        }

        private void ShowRewardedIconAd()
        {
            OdeeoAdManager.ShowAd(ICON_REWARDED_PLACEMENT_ID);
        }

        private void ShowRewardedBannerAd()
        {
            OdeeoAdManager.ShowAd(BANNER_REWARDED_PLACEMENT_ID);
        }

        private void RemoveAd()
        {
            if(!OdeeoAdManager.IsAnyAdPlaying())
                return;
            
            if(OdeeoAdManager.IsPlacementExist(ICON_PLACEMENT_ID) && OdeeoAdManager.IsAdPlaying(ICON_PLACEMENT_ID))
                OdeeoAdManager.RemoveAd(ICON_PLACEMENT_ID);
            
            if(OdeeoAdManager.IsPlacementExist(BANNER_PLACEMENT_ID) && OdeeoAdManager.IsAdPlaying(BANNER_PLACEMENT_ID))
                OdeeoAdManager.RemoveAd(BANNER_PLACEMENT_ID);
            
            if(OdeeoAdManager.IsPlacementExist(ICON_REWARDED_PLACEMENT_ID) && OdeeoAdManager.IsAdPlaying(ICON_REWARDED_PLACEMENT_ID))
                OdeeoAdManager.RemoveAd(ICON_REWARDED_PLACEMENT_ID);
            
            if(OdeeoAdManager.IsPlacementExist(BANNER_REWARDED_PLACEMENT_ID) && OdeeoAdManager.IsAdPlaying(BANNER_REWARDED_PLACEMENT_ID))
                OdeeoAdManager.RemoveAd(BANNER_REWARDED_PLACEMENT_ID);
            
            RefreshButtons();
        }

        #region Events

        private void AdOnAvailabilityChanged(bool flag, OdeeoAdData data)
        {
            RefreshButtons();
        }
        
        private void AdOnShow()
        {
            odeeoDemoUi.ShowMessage("Ad Shown", OdeeoDemoUiMessage.MessageColor.Green);
            RefreshButtons();
        }
        
        private void AdOnShowFailed(string placementId, OdeeoAdUnit.ErrorShowReason reason, string description)
        {
            odeeoDemoUi.ShowMessage("Ad Show Failed: " + reason, OdeeoDemoUiMessage.MessageColor.Red);
            RefreshButtons();
        }
        
        private void AdOnReward(float amount)
        {
            odeeoDemoUi.ShowMessage("Reward Granted", OdeeoDemoUiMessage.MessageColor.Green);
            RefreshButtons();
        }
        
        private void SubscribePlacement(string placementId)
        {
            if (!OdeeoAdManager.IsPlacementExist(placementId))
                return;
            
            //Common callbacks
            OdeeoAdManager.AdUnitCallbacks(placementId).OnAvailabilityChanged += AdOnAvailabilityChanged;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnShow += AdOnShow;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnShowFailed += AdOnShowFailed;
            
            //If rewarded ad type, rewarded callback
            OdeeoAdManager.AdUnitCallbacks(placementId).OnReward += AdOnReward;
        }
        
        private void UnsubscribePlacement(string placementId)
        {
            if (!OdeeoAdManager.IsPlacementExist(placementId))
                return;
            
            //Common callbacks
            OdeeoAdManager.AdUnitCallbacks(placementId).OnAvailabilityChanged -= AdOnAvailabilityChanged;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnShow -= AdOnShow;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnShowFailed -= AdOnShowFailed;

            //If rewarded ad type, rewarded callback
            OdeeoAdManager.AdUnitCallbacks(placementId).OnReward -= AdOnReward;
        }

        #endregion

        private void RefreshButtons()
        {
            bool isInitialized = OdeeoSdk.IsInitialized();
            
            OdeeoDemoUiBase.InitializationState initializationState = isInitialized ? OdeeoDemoUiBase.InitializationState.Initialized : OdeeoDemoUiBase.InitializationState.Default;
            if (_isInitializationInProgress)
                initializationState = OdeeoDemoUiBase.InitializationState.InProgress;
            
            odeeoDemoUi.SetInitializationState(initializationState);

            odeeoDemoUi.ShowIconAdButton.Interactable = isInitialized && OdeeoAdManager.IsAdAvailable(ICON_PLACEMENT_ID);
            odeeoDemoUi.ShowBannerAdButton.Interactable = isInitialized && OdeeoAdManager.IsAdAvailable(BANNER_PLACEMENT_ID);
            odeeoDemoUi.ShowRewardedIconAdButton.Interactable = isInitialized && OdeeoAdManager.IsAdAvailable(ICON_REWARDED_PLACEMENT_ID);
            odeeoDemoUi.ShowRewardedBannerAdButton.Interactable = isInitialized && OdeeoAdManager.IsAdAvailable(BANNER_REWARDED_PLACEMENT_ID);

            odeeoDemoUi.RemoveAdButton.Interactable = OdeeoAdManager.IsAnyAdPlaying();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            OdeeoSdk.onApplicationPause(pauseStatus);
        }
        
        private void InitButtons()
        {
            odeeoDemoUi.InitializeButton.AddListener(Initialize);
            
            odeeoDemoUi.ShowIconAdButton.AddListener(ShowIconAd);
            odeeoDemoUi.ShowBannerAdButton.AddListener(ShowBannerAd);
            odeeoDemoUi.ShowRewardedIconAdButton.AddListener(ShowRewardedIconAd);
            odeeoDemoUi.ShowRewardedBannerAdButton.AddListener(ShowRewardedBannerAd);
            odeeoDemoUi.RemoveAdButton.AddListener(RemoveAd);
        }

        private void OnDestroy()
        {
            odeeoDemoUi.RemoveAllListeners();
            
            if(OdeeoAdManager.IsPlacementExist(BANNER_PLACEMENT_ID))
                UnsubscribePlacement(BANNER_PLACEMENT_ID);
            
            if(OdeeoAdManager.IsPlacementExist(BANNER_REWARDED_PLACEMENT_ID))
                UnsubscribePlacement(BANNER_REWARDED_PLACEMENT_ID);
            
            if(OdeeoAdManager.IsPlacementExist(ICON_PLACEMENT_ID))
                UnsubscribePlacement(ICON_PLACEMENT_ID);
            
            if(OdeeoAdManager.IsPlacementExist(ICON_REWARDED_PLACEMENT_ID))
                UnsubscribePlacement(ICON_REWARDED_PLACEMENT_ID);
        }
    }
}
