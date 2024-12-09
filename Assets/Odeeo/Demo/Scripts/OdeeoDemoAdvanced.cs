using System;
using Odeeo.Data;
using UnityEngine;

namespace Odeeo.Demo
{
    public class OdeeoDemoAdvanced : MonoBehaviour
    {
        private enum LinkType
        {
            Default,
            ToAnchor,
            ToRect
        }
        
        protected OdeeoSdk.PlacementType _adType = OdeeoSdk.PlacementType.AudioBannerAd;
        private LinkType _linkType = LinkType.Default;
        private OdeeoSdk.IconPosition _adIconPosition = OdeeoSdk.IconPosition.BottomRight;
        private OdeeoSdk.BannerPosition _adBannerPosition = OdeeoSdk.BannerPosition.BottomCenter;

        private static readonly Color s_adMainColorDefault = Color.white;
        private static readonly Color s_adBackgroundColorDefault = new Color(0.62f, 0.063f, 0.99f, 1f);
        private static readonly Color s_adProgressBarColorDefault = Color.white;

        private Color _adMainColor = s_adMainColorDefault;
        private Color _adBackgroundColor = s_adBackgroundColorDefault;
        private Color _adProgressBarColor = s_adProgressBarColorDefault;
        
        private const int ICON_SIZE_DEFAULT = 80;
        private const int ICON_OFFSET_X_DEFAULT = 10;
        private const int ICON_OFFSET_Y_DEFAULT = 10;
        
        private int _iconSize = ICON_SIZE_DEFAULT; 
        private int _iconOffsetX = ICON_OFFSET_X_DEFAULT;
        private int _iconOffsetY = ICON_OFFSET_Y_DEFAULT;

        private OdeeoAdUnit.PopUpType? _rewardPopupType = null;
        private OdeeoSdk.IconPosition? _rewardPopupIconPosition = null;
        private OdeeoSdk.BannerPosition? _rewardPopupBannerPosition = null;

        private const int POPUP_OFFSET_X_DEFAULT = 10;
        private const int POPUP_OFFSET_Y_DEFAULT = 10;

        private int _popupOffsetX = POPUP_OFFSET_X_DEFAULT;
        private int _popupOffsetY = POPUP_OFFSET_Y_DEFAULT;

#if UNITY_ANDROID
        private const string APP_KEY = "f0f492d3-34ea-47ad-b98f-84640bd2f36a";
        protected const string BANNER_PLACEMENT_ID = "340339090";
        protected const string BANNER_REWARDED_PLACEMENT_ID = "300632690";
        protected const string ICON_PLACEMENT_ID = "376373450";
        protected const string ICON_REWARDED_PLACEMENT_ID = "353360647";
#elif UNITY_IOS
        private const string APP_KEY = "6736cfbf-dccc-4def-a022-16b6686639e2";
        protected const string BANNER_PLACEMENT_ID = "334872774";
        protected const string BANNER_REWARDED_PLACEMENT_ID = "385528236";
        protected const string ICON_PLACEMENT_ID = "302988162";
        protected const string ICON_REWARDED_PLACEMENT_ID = "397800061";
#else
        private const string APP_KEY = "";
        protected const string BANNER_PLACEMENT_ID = "";
        protected const string BANNER_REWARDED_PLACEMENT_ID = "";
        protected const string ICON_PLACEMENT_ID = "";
        protected const string ICON_REWARDED_PLACEMENT_ID = "";
#endif

        [SerializeField] protected OdeeoDemoUiAdvanced odeeoDemoUi;
        
        [Space]
        [SerializeField] protected Canvas canvas;
        [SerializeField] protected RectTransform rect;
        [SerializeField] protected OdeeoIconAnchor iconAnchor;
        
        private bool _isColorsDirty = false;
        private bool _isRewardDirty = false;

        private bool _isInitializationInProgress = false;

        protected virtual void Start()
        {
            odeeoDemoUi.Init();
            
            CheckForPreviousInitialization();

            SetDefaults();
            InitButtons();
            AddDebugUI();
            
            RefreshButtons();
        }
        
        protected virtual void CheckForPreviousInitialization()
        {
            if(!OdeeoSdk.IsInitialized())
                return;
            
            if(OdeeoAdManager.IsPlacementExist(BANNER_PLACEMENT_ID))
                SubscribePlacement(BANNER_PLACEMENT_ID);
            
            if(OdeeoAdManager.IsPlacementExist(BANNER_REWARDED_PLACEMENT_ID))
                SubscribePlacement(BANNER_REWARDED_PLACEMENT_ID);
            
            if(OdeeoAdManager.IsPlacementExist(ICON_PLACEMENT_ID))
                SubscribePlacement(ICON_PLACEMENT_ID);
            
            if(OdeeoAdManager.IsPlacementExist(ICON_REWARDED_PLACEMENT_ID))
                SubscribePlacement(ICON_REWARDED_PLACEMENT_ID);
        }

        #region General
        
        protected virtual void Initialize()
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
#if UNITY_IOS && !UNITY_EDITOR
            //Wrapped native IOS requestTrackingAuthorization function, to be able fetch advertiser id
            OdeeoSdk.RequestTrackingAuthorization();
#endif
        }
        
        protected virtual void CreateAd()
        {
            if (OdeeoAdManager.IsPlacementExist(CurrentPlacementID))
            {
                Log("This placement already exists.");
                odeeoDemoUi.ShowMessage("This placement already exists.", OdeeoDemoUiMessage.MessageColor.Red);
                return;
            }

            switch (_adType)
            {
                case OdeeoSdk.PlacementType.AudioBannerAd:
                    OdeeoAdManager.CreateAudioBannerAd(CurrentPlacementID);
                    break;
                case OdeeoSdk.PlacementType.RewardedAudioBannerAd:
                    OdeeoAdManager.CreateRewardedAudioBannerAd(CurrentPlacementID);
                    break;
                case OdeeoSdk.PlacementType.AudioIconAd:
                    OdeeoAdManager.CreateAudioIconAd(CurrentPlacementID);
                    break;
                case OdeeoSdk.PlacementType.RewardedAudioIconAd:
                    OdeeoAdManager.CreateRewardedAudioIconAd(CurrentPlacementID);
                    break;
            }

            SubscribePlacement(CurrentPlacementID);

            RefreshButtons();
        }
        
        private void IsAdAvailable()
        {
            RefreshButtons();
        }

        private void ShowOrRemoveAd()
        {
            if (OdeeoAdManager.IsAdPlaying(CurrentPlacementID))
                RemoveAd();
            else
                ShowAd();
        }
        protected void ShowAd()
        {
            if (OdeeoAdManager.IsIconType(_adType))
            {
                //Three methods are used to set the position: SetIconPosition, LinkToIconAnchor, LinkIconToRectTransform
                // 1
                //SetIconPosition - Set the AdUnit position relative to the screen with offsets. Offsets must be specified in density pixels
                // 2
                //LinkToIconAnchor - Set the AdUnit to the same position and size as the IconAnchor object. Make sure the IconAnchor object is a child of your canvas
                // 3
                //LinkIconToRectTransform - Set the AdUnit position in the RectTransform. OdeeoSdk.Position specifies the location inside RectTransform.

                switch (_linkType)
                {
                    case LinkType.Default:
                        OdeeoAdManager.SetIconPosition(CurrentPlacementID, _adIconPosition, _iconOffsetX, _iconOffsetY);
                        OdeeoAdManager.SetIconSize(CurrentPlacementID, _iconSize);
                        break;
                    case LinkType.ToAnchor:
                        OdeeoAdManager.LinkToIconAnchor(CurrentPlacementID, iconAnchor);
                        break;
                    case LinkType.ToRect:
                        OdeeoAdManager.LinkIconToRectTransform(CurrentPlacementID, _adIconPosition, rect, canvas, OdeeoSdk.AdSizingMethod.Flexible);
                        break;
                }
            }
            else
            {
                //SetBanner - Set the AD Unit position relative to the screen.
                OdeeoAdManager.SetBannerPosition(CurrentPlacementID, _adBannerPosition);
            }

            UpdateAdSettings();
            
            OdeeoAdManager.ShowAd(CurrentPlacementID);
            RefreshButtons();
        }
        
        protected void RemoveAd()
        {
            OdeeoAdManager.RemoveAd(CurrentPlacementID);
            RefreshButtons();
        }

        #endregion
        
        #region Settings
        private void SetAdType(int newType)
        {
            _adType = (OdeeoSdk.PlacementType)newType;
            RefreshButtons();
        }
        
        private void SetAdPosition(int index)
        {
            string value = odeeoDemoUi.PositionDropdown.Dropdown.options[index].text;
            if (OdeeoAdManager.IsBannerType(_adType))
                _adBannerPosition = Enum.TryParse(value, out OdeeoSdk.BannerPosition result)
                    ? result
                    : OdeeoSdk.BannerPosition.BottomCenter;
            else
                _adIconPosition = Enum.TryParse(value, out OdeeoSdk.IconPosition result)
                    ? result
                    : OdeeoSdk.IconPosition.BottomCenter;
        }
        
        protected virtual void SetIconLinkType(int newType)
        {
            _linkType = (LinkType)newType;
            RefreshButtons();
        }

        private void ResetSizeAndOffset()
        {
            SetDefaults(true, false,false);
            odeeoDemoUi.CloseCurrentDialog();
        }

        private void ApplySizeAndOffset()
        {
            _iconSize = (int)odeeoDemoUi.IconSizeSlider.Value;
            _iconOffsetX = (int)odeeoDemoUi.IconOffsetSliderX.Value;
            _iconOffsetY = (int)odeeoDemoUi.IconOffsetSliderY.Value;
            
            odeeoDemoUi.CloseCurrentDialog();
        }

        private void ResetColors()
        {
            SetDefaults(false, true,false);
            odeeoDemoUi.CloseCurrentDialog();
        }

        private void ApplyColors()
        {
            _isColorsDirty = true;
            
            _adMainColor = Color.HSVToRGB(odeeoDemoUi.MainColorSlider.Value, 0.77f,0.93f);
            _adBackgroundColor = Color.HSVToRGB(odeeoDemoUi.BackgroundColorSlider.Value, 0.77f,0.93f);
            _adProgressBarColor = Color.HSVToRGB(odeeoDemoUi.ProgressColorSlider.Value, 0.77f,0.93f);
            
            odeeoDemoUi.CloseCurrentDialog();
        }

        private void RedrawPopup(int value)
        {
            bool isBannerPopup = OdeeoAdManager.IsBannerType((OdeeoAdUnit.PopUpType)value);
            
            if (isBannerPopup)
            {
                odeeoDemoUi.FillPositionsDropdown(odeeoDemoUi.PopupPositionDropdown, new OdeeoSdk.BannerPosition());
                odeeoDemoUi.PopupPositionDropdown.Value = Array.IndexOf(Enum.GetNames(typeof(OdeeoSdk.BannerPosition)),
                    _rewardPopupBannerPosition != null ? _rewardPopupBannerPosition.ToString() : _adBannerPosition.ToString());
            }
            else
            {
                odeeoDemoUi.FillPositionsDropdown(odeeoDemoUi.PopupPositionDropdown, new OdeeoSdk.IconPosition());
                odeeoDemoUi.PopupPositionDropdown.Value = Array.IndexOf(Enum.GetNames(typeof(OdeeoSdk.IconPosition)),
                    _rewardPopupIconPosition != null ? _rewardPopupIconPosition.ToString(): _adIconPosition.ToString());
            }
            
            odeeoDemoUi.PopupOffsetSliderX.Interactable = !isBannerPopup;
            odeeoDemoUi.PopupOffsetSliderY.Interactable = !isBannerPopup;
        }
        
        private void ResetPopup()
        {
            SetDefaults(false, false, true);
            odeeoDemoUi.CloseCurrentDialog();
        }

        private void ApplyPopup()
        {
            _isRewardDirty = true;
            
            _rewardPopupType = (OdeeoAdUnit.PopUpType)odeeoDemoUi.PopupTypeDropdown.Value;

            bool isBannerPopup = _rewardPopupType != null
                ? OdeeoAdManager.IsBannerType((OdeeoAdUnit.PopUpType)_rewardPopupType)
                : OdeeoAdManager.IsBannerType(_adType);

            string value = odeeoDemoUi.PopupPositionDropdown.Dropdown.options[odeeoDemoUi.PopupPositionDropdown.Dropdown.value].text;
            if (isBannerPopup)
                _rewardPopupBannerPosition = Enum.TryParse(value, out OdeeoSdk.BannerPosition result)
                    ? result
                    : OdeeoSdk.BannerPosition.BottomCenter;
            else
                _rewardPopupIconPosition = Enum.TryParse(value, out OdeeoSdk.IconPosition result)
                    ? result
                    : OdeeoSdk.IconPosition.BottomRight;

            _popupOffsetX = (int)odeeoDemoUi.PopupOffsetSliderX.Value;
            _popupOffsetY = (int)odeeoDemoUi.PopupOffsetSliderY.Value;
            
            odeeoDemoUi.CloseCurrentDialog();
        }
        
        #endregion

        #region Events

        private void OnInitializationFinished()
        {
            _isInitializationInProgress = false;
            
            Log("OnInitializationFinished Callback");
            odeeoDemoUi.ShowMessage("Initialization Complete", OdeeoDemoUiMessage.MessageColor.Green);

            OdeeoSdk.OnInitializationFinished -= OnInitializationFinished;
            OdeeoSdk.OnInitializationFailed -= OnInitializationFailed;
            
            RefreshButtons();
        }

        private void OnInitializationFailed(int errorParam, string error)
        {
            _isInitializationInProgress = false;
            
            Log("OnInitializationFailed Callback");
            odeeoDemoUi.ShowMessage("Initialization Failed: " + error, OdeeoDemoUiMessage.MessageColor.Red);
            
            RefreshButtons();
        }
        
        private void AdOnAvailabilityChanged(bool flag, OdeeoAdData data)
        {
            Log("AdOnAvailabilityChanged callback isAvailable: " + flag);
            RefreshButtons();
        }
        
        private void AdOnShow()
        {
            RefreshButtons();
            Log("AdOnShow callback");
            odeeoDemoUi.ShowMessage("Ad Shown", OdeeoDemoUiMessage.MessageColor.Green);
        }
        
        private void AdOnClick()
        {
            Log("AdOnClick callback");
        }

        private void AdOnClose(OdeeoAdUnit.CloseReason reason)
        {
            RefreshButtons();
            Log("AdOnClose callback with reason: " + reason);
        }
        
        private void AdOnReward(float amount)
        {
            Log("AdOnReward callback with amount: " + amount);
            odeeoDemoUi.ShowMessage("Reward Granted", OdeeoDemoUiMessage.MessageColor.Green);
        }

        private void AdOnImpression(OdeeoImpressionData data)
        {
            Log("AdOnImpression callback ->\n"
                + " SessionID: " + data.GetSessionID() + "\n"
                + " PlacementType: " + data.GetPlacementType() + "\n"
                + " PlacementID: " + data.GetPlacementID() + "\n"
                + " Country: " + data.GetCountry() + "\n"
                + " PayableAmount: " + data.GetPayableAmount() + "\n"
                + " TransactionID: " + data.GetTransactionID() + "\n"
                + " CustomTag: " + data.GetCustomTag()
            );
        }
        
        private void AdOnRewardedPopupAppear()
        {
            Log("AdOnRewardedPopupAppear callback");
        }

        private void AdOnRewardedPopupClosed(OdeeoAdUnit.CloseReason reason)
        {
            Log("AdOnRewardedPopupClosed callback with reason: " + reason);
        }

        private void AdOnPause(OdeeoAdUnit.StateChangeReason reason)
        {
            Log("AdOnPause callback with reason: " + reason);
        }

        private void AdOnResume(OdeeoAdUnit.StateChangeReason reason)
        {
            Log("AdOnResume callback with reason: " + reason);
        }

        private void AdOnMute()
        {
            Log("AdOnMute callback");
        }
        
        private void AdOnShowFailed(string placementId, OdeeoAdUnit.ErrorShowReason reason, string description)
        {
            Log("AdOnShowFailed with reason: " + reason.ToString() + ", and description: " + description);
            odeeoDemoUi.ShowMessage("Ad Show Failed: " + reason, OdeeoDemoUiMessage.MessageColor.Red);
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            OdeeoSdk.onApplicationPause(pauseStatus);
        }
        
        protected virtual void SubscribePlacement(string placementId)
        {
            if (!OdeeoAdManager.IsPlacementExist(placementId))
                return;
            
            //Common callbacks
            OdeeoAdManager.AdUnitCallbacks(placementId).OnAvailabilityChanged += AdOnAvailabilityChanged;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnShow += AdOnShow;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnClose += AdOnClose;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnClick += AdOnClick;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnPause += AdOnPause;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnResume += AdOnResume;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnMute += AdOnMute;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnShowFailed += AdOnShowFailed;
            
            //If rewarded ad type, rewarded callback
            OdeeoAdManager.AdUnitCallbacks(placementId).OnReward += AdOnReward;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnRewardedPopupAppear += AdOnRewardedPopupAppear;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnRewardedPopupClosed += AdOnRewardedPopupClosed;

            //If Impression turned on
            OdeeoAdManager.AdUnitCallbacks(placementId).OnImpression += AdOnImpression;
        }
        
        protected virtual void UnsubscribePlacement(string placementId)
        {
            if (!OdeeoAdManager.IsPlacementExist(placementId))
                return;
            
            //Common callbacks
            OdeeoAdManager.AdUnitCallbacks(placementId).OnAvailabilityChanged -= AdOnAvailabilityChanged;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnShow -= AdOnShow;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnClose -= AdOnClose;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnClick -= AdOnClick;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnPause -= AdOnPause;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnResume -= AdOnResume;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnMute -= AdOnMute;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnShowFailed -= AdOnShowFailed;

            //If rewarded ad type, rewarded callback
            OdeeoAdManager.AdUnitCallbacks(placementId).OnReward -= AdOnReward;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnRewardedPopupAppear -= AdOnRewardedPopupAppear;
            OdeeoAdManager.AdUnitCallbacks(placementId).OnRewardedPopupClosed -= AdOnRewardedPopupClosed;

            //If Impression turned on
            OdeeoAdManager.AdUnitCallbacks(placementId).OnImpression -= AdOnImpression;
        }

        #endregion

        private void UpdateAdSettings()
        {
            if (_isColorsDirty)
            {
                OdeeoAdManager.SetAudioOnlyBackground(CurrentPlacementID, _adBackgroundColor);
                OdeeoAdManager.SetAudioOnlyAnimation(CurrentPlacementID, _adMainColor);
                OdeeoAdManager.SetProgressBar(CurrentPlacementID, _adProgressBarColor);
            }

            if (_isRewardDirty)
            {
                bool isBannerPopup = _rewardPopupType != null
                    ? OdeeoAdManager.IsBannerType((OdeeoAdUnit.PopUpType)_rewardPopupType)
                    : OdeeoAdManager.IsBannerType(_adType);
                
                OdeeoAdUnit.PopUpType popupType = _rewardPopupType ?? (OdeeoAdManager.IsBannerType(_adType)
                    ? OdeeoAdUnit.PopUpType.BannerPopUp
                    : OdeeoAdUnit.PopUpType.IconPopUp);
                
                OdeeoAdManager.SetRewardedPopupType(CurrentPlacementID, popupType);
                
                if (isBannerPopup)
                {
                    OdeeoSdk.BannerPosition bannerPosition = _rewardPopupBannerPosition ?? _adBannerPosition;
                    OdeeoAdManager.SetRewardedPopupBannerPosition(CurrentPlacementID, bannerPosition);
                    return;
                }

                OdeeoSdk.IconPosition iconPosition = _rewardPopupIconPosition ?? _adIconPosition;
                OdeeoAdManager.SetRewardedPopupIconPosition(CurrentPlacementID, iconPosition, _popupOffsetX, _popupOffsetY);
            }
        }
        
        private void SetDefaults(bool sizeAndOffset = true, bool colors = true, bool popup = true)
        {
            if (sizeAndOffset)
            {
                odeeoDemoUi.IconSizeSlider.Value = _iconSize = ICON_SIZE_DEFAULT;
                odeeoDemoUi.IconOffsetSliderX.Value = _iconOffsetX = ICON_OFFSET_X_DEFAULT;
                odeeoDemoUi.IconOffsetSliderY.Value = _iconOffsetY = ICON_OFFSET_Y_DEFAULT;
            }

            if (colors)
            {
                odeeoDemoUi.MainColorSlider.Value = 0f;
                odeeoDemoUi.BackgroundColorSlider.Value = 0.75f;
                odeeoDemoUi.ProgressColorSlider.Value = 0f;
                
                odeeoDemoUi.MainColorSlider.SetColor(s_adMainColorDefault);
                odeeoDemoUi.BackgroundColorSlider.SetColor(s_adBackgroundColorDefault);
                odeeoDemoUi.ProgressColorSlider.SetColor(s_adProgressBarColorDefault);

                _adMainColor = s_adMainColorDefault;
                _adBackgroundColor = s_adBackgroundColorDefault;
                _adProgressBarColor = s_adProgressBarColorDefault;
            }

            if (popup)
            {
                _rewardPopupType = null;
                _rewardPopupBannerPosition = null;
                _rewardPopupIconPosition = null;

                odeeoDemoUi.PopupTypeDropdown.Value = (int)OdeeoAdUnit.PopUpType.IconPopUp;
                odeeoDemoUi.PopupPositionDropdown.Value = (int)OdeeoSdk.IconPosition.BottomCenter;

                odeeoDemoUi.PopupOffsetSliderX.Value = _popupOffsetX = POPUP_OFFSET_X_DEFAULT;
                odeeoDemoUi.PopupOffsetSliderY.Value = _popupOffsetY = POPUP_OFFSET_Y_DEFAULT;
            }
        }

        private void InitButtons()
        {
            odeeoDemoUi.InitializeButton.AddListener(Initialize);
            odeeoDemoUi.ADTypeDropdown.AddDropdownListener(SetAdType);
            odeeoDemoUi.PositionDropdown.AddDropdownListener(SetAdPosition);

            odeeoDemoUi.IconSettingsButton.AddListener(() => odeeoDemoUi.ShowDialog(odeeoDemoUi.IconSettingsDialog.RectTransform));
            odeeoDemoUi.LinkTypeDropdown.AddDropdownListener(SetIconLinkType);
            odeeoDemoUi.VisualSettingsButton.AddListener(() => odeeoDemoUi.ShowDialog(odeeoDemoUi.VisualSettingsDialog.RectTransform));

            odeeoDemoUi.CreateAdButton.AddListener(CreateAd);
            
            odeeoDemoUi.IsAdAvailableButton.AddListener(IsAdAvailable);
            odeeoDemoUi.ShowOrRemoveAdButton.AddListener(ShowOrRemoveAd);

            odeeoDemoUi.PopupSettingsButton.AddListener(() => odeeoDemoUi.ShowDialog(odeeoDemoUi.PopupSettingsDialog.RectTransform));
            
            odeeoDemoUi.IconSettingsDialog.ResetButton.AddListener(ResetSizeAndOffset);
            odeeoDemoUi.IconSettingsDialog.ApplyButton.AddListener(ApplySizeAndOffset);

            odeeoDemoUi.VisualSettingsDialog.ResetButton.AddListener(ResetColors);
            odeeoDemoUi.VisualSettingsDialog.ApplyButton.AddListener(ApplyColors);
            
            odeeoDemoUi.PopupSettingsDialog.ResetButton.AddListener(ResetPopup);
            odeeoDemoUi.PopupSettingsDialog.ApplyButton.AddListener(ApplyPopup);
            odeeoDemoUi.PopupTypeDropdown.AddDropdownListener(RedrawPopup);
        }
        
        protected virtual void RefreshButtons()
        {
            bool isInitialized = OdeeoSdk.IsInitialized();
            
            OdeeoDemoUiBase.InitializationState initializationState = isInitialized ? OdeeoDemoUiBase.InitializationState.Initialized : OdeeoDemoUiBase.InitializationState.Default;
            if (_isInitializationInProgress)
                initializationState = OdeeoDemoUiBase.InitializationState.InProgress;
            
            odeeoDemoUi.SetInitializationState(initializationState);

            if (OdeeoAdManager.IsBannerType(_adType))
            {
                odeeoDemoUi.FillPositionsDropdown(odeeoDemoUi.PositionDropdown, new OdeeoSdk.BannerPosition());
                odeeoDemoUi.PositionDropdown.Value = Array.IndexOf(Enum.GetNames(typeof(OdeeoSdk.BannerPosition)),
                    _adBannerPosition.ToString());
            }
            else
            {
                odeeoDemoUi.FillPositionsDropdown(odeeoDemoUi.PositionDropdown, new OdeeoSdk.IconPosition());
                odeeoDemoUi.PositionDropdown.Value = Array.IndexOf(Enum.GetNames(typeof(OdeeoSdk.IconPosition)),
                    _adIconPosition.ToString());
            }

            if (!isInitialized)
            {
                odeeoDemoUi.PositionDropdown.Interactable = false;
                odeeoDemoUi.ADTypeDropdown.Interactable = false;
                odeeoDemoUi.LinkTypeDropdown.Interactable = false;

                odeeoDemoUi.IconSettingsButton.Interactable = false;
                odeeoDemoUi.VisualSettingsButton.Interactable = false;
                odeeoDemoUi.PopupSettingsButton.Interactable = false;

                odeeoDemoUi.CreateAdButton.Interactable = false;

                odeeoDemoUi.IsAdAvailableButton.Interactable = false;
                odeeoDemoUi.IsAdAvailableButton.SetColor(OdeeoDemoUiElement.ColorWhite);

                odeeoDemoUi.ShowOrRemoveAdButton.Interactable = false;
                
                return;
            }
            
            odeeoDemoUi.RectDebugController.SetActive(OdeeoAdManager.IsIconType(_adType) && _linkType == LinkType.ToRect);
            odeeoDemoUi.AnchorDebugController.SetActive(OdeeoAdManager.IsIconType(_adType) && _linkType == LinkType.ToAnchor);
            
            bool isIcon = OdeeoAdManager.IsIconType(_adType);
            
            odeeoDemoUi.PositionDropdown.Interactable = _linkType != LinkType.ToAnchor || !OdeeoAdManager.IsIconType(_adType);
            odeeoDemoUi.ADTypeDropdown.Interactable = true;
            odeeoDemoUi.VisualSettingsButton.Interactable = true;
            
            if (odeeoDemoUi.LinkTypeDropdown) odeeoDemoUi.LinkTypeDropdown.Interactable = isIcon;
            
            // Icon Settings
            if (odeeoDemoUi.IconSettingsButton) odeeoDemoUi.IconSettingsButton.Interactable = isIcon && _linkType == LinkType.Default;
            
            if(odeeoDemoUi.IconSizeSlider) odeeoDemoUi.IconSizeSlider.Interactable = isIcon;
            if(odeeoDemoUi.IconOffsetSliderX) odeeoDemoUi.IconOffsetSliderX.Interactable = isIcon;
            if(odeeoDemoUi.IconOffsetSliderY) odeeoDemoUi.IconOffsetSliderY.Interactable = isIcon;
            
            // Popup Settings
            bool isBannerPopup = _rewardPopupType != null
                ? OdeeoAdManager.IsBannerType((OdeeoAdUnit.PopUpType)_rewardPopupType)
                : OdeeoAdManager.IsBannerType(_adType);

            odeeoDemoUi.PopupTypeDropdown.Dropdown.value = isBannerPopup ? 1 : 0;
            
            if (isBannerPopup)
            {
                odeeoDemoUi.FillPositionsDropdown(odeeoDemoUi.PopupPositionDropdown, new OdeeoSdk.BannerPosition());
                odeeoDemoUi.PopupPositionDropdown.Value = Array.IndexOf(Enum.GetNames(typeof(OdeeoSdk.BannerPosition)),
                    _rewardPopupBannerPosition != null ? _rewardPopupBannerPosition.ToString() : _adBannerPosition.ToString());
            }
            else
            {
                odeeoDemoUi.FillPositionsDropdown(odeeoDemoUi.PopupPositionDropdown, new OdeeoSdk.IconPosition());
                odeeoDemoUi.PopupPositionDropdown.Value = Array.IndexOf(Enum.GetNames(typeof(OdeeoSdk.IconPosition)),
                    _rewardPopupIconPosition != null ? _rewardPopupIconPosition.ToString() : _adIconPosition.ToString());
            }

            odeeoDemoUi.PopupSettingsButton.Interactable = OdeeoAdManager.IsAdRewardedType(_adType);
            odeeoDemoUi.PopupOffsetSliderX.Interactable = !isBannerPopup;
            odeeoDemoUi.PopupOffsetSliderY.Interactable = !isBannerPopup;
            
            if (!OdeeoAdManager.IsPlacementExist(CurrentPlacementID))
            {
                odeeoDemoUi.IsAdAvailableButton.Interactable = false;
                odeeoDemoUi.IsAdAvailableButton.SetColor(OdeeoDemoUiElement.ColorWhite);

                odeeoDemoUi.CreateAdButton.Interactable = true;
                
                odeeoDemoUi.ShowOrRemoveAdButton.Interactable = false;
                odeeoDemoUi.ShowOrRemoveAdButton.SetText("SHOW AD");
                
                return;
            }

            odeeoDemoUi.CreateAdButton.Interactable = false;
            odeeoDemoUi.IsAdAvailableButton.Interactable = true;

            bool isAdAvailable = OdeeoAdManager.IsAdAvailable(CurrentPlacementID);
            odeeoDemoUi.IsAdAvailableButton.SetColor(isAdAvailable ? OdeeoDemoUiElement.ColorGreen : OdeeoDemoUiElement.ColorRed);

            bool isAdPlaying = OdeeoAdManager.IsAdPlaying(CurrentPlacementID);
            odeeoDemoUi.ShowOrRemoveAdButton.Interactable = (isAdPlaying || !isAdPlaying && isAdAvailable);
            odeeoDemoUi.ShowOrRemoveAdButton.SetText(isAdPlaying ? "REMOVE AD" : "SHOW AD");
        }

        private void AddDebugUI()
        {
            if (rect)
            {
                OdeeoDemoUiDebugContainer uiDebugContainer = Instantiate(odeeoDemoUi.UIDebugContainerPrefab, rect);
                uiDebugContainer.SetText("RectTransform");
                
                odeeoDemoUi.RectDebugController = rect.gameObject.AddComponent<OdeeoDemoUiDebugController>();
                odeeoDemoUi.RectDebugController.Initialize(canvas, uiDebugContainer);
            }
            
            if (iconAnchor)
            {
                OdeeoDemoUiDebugContainer uiDebugContainer = Instantiate(odeeoDemoUi.UIDebugContainerPrefab, iconAnchor.RectTransform);
                uiDebugContainer.SetText("IconAnchor");

                odeeoDemoUi.AnchorDebugController = iconAnchor.gameObject.AddComponent<OdeeoDemoUiDebugController>();
                odeeoDemoUi.AnchorDebugController.Initialize(canvas, uiDebugContainer);
            }
        }
        
        protected virtual void OnDestroy()
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
        
        protected virtual string CurrentPlacementID
        {
            get
            {
                switch (_adType)
                {
                    case OdeeoSdk.PlacementType.AudioBannerAd:
                        return BANNER_PLACEMENT_ID;
                    case OdeeoSdk.PlacementType.RewardedAudioBannerAd:
                        return BANNER_REWARDED_PLACEMENT_ID;
                    case OdeeoSdk.PlacementType.AudioIconAd:
                        return ICON_PLACEMENT_ID;
                    case OdeeoSdk.PlacementType.RewardedAudioIconAd:
                        return ICON_REWARDED_PLACEMENT_ID;
                }

                return string.Empty;
            }
        }

        protected void Log(string message)
        {
            Debug.Log("UnityDemo: " + message);
        }
    }
}
