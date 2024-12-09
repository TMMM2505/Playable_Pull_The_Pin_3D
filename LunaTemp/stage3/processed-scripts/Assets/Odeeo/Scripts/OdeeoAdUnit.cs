using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Odeeo.Data;
using Odeeo.Utils;
using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
using System.Threading.Tasks;
using Object = UnityEngine.Object;
#endif

namespace Odeeo
{
    public class OdeeoAdUnit : IDisposable
    {
        private enum LogoPositionType
        {
            Anchor,
            Rect,
            Direct
        }

        public enum CloseReason
        {
            AdCompleted,
            AdExpired,
            UserClose,
            VolumeChanged,
            UserCancel,
            AdRemovedByDev,
            Other
        }
        
        public enum StateChangeReason
        {
            AdCovered,
            AdUncovered,
            RewardedVolumeMinimum,
            RewardedVolumeIncrease,
            ApplicationInBackground,
            ApplicationInForeground,
            AudioSessionInterruption,
            AudioSessionInterruptionEnd,
            OtherOdeeoPlacementStart,
            OtherOdeeoPlacementEnd
        }

        public enum ErrorShowReason
        {
            NoInternetConnection,
            AnotherAdPlaying,
            CurrentAdPlaying,
            NoAd,
            SdkNotInitialized,
            GeneralError,
            RectTransformBlocked
        }

        public enum ActionButtonPosition
        {
            TopRight,
            TopLeft
        }

        private static readonly Dictionary<ErrorShowReason, string> s_errorShowMessage = new Dictionary<ErrorShowReason, string>()
        {
            { ErrorShowReason.NoInternetConnection, "Internet connection missing"},
            { ErrorShowReason.AnotherAdPlaying, "Unable to simultaneously play two different ad units"},
            { ErrorShowReason.CurrentAdPlaying, "Current ad already playing"},
            { ErrorShowReason.NoAd, "No ad to play"},
            { ErrorShowReason.SdkNotInitialized, "SDK not Initialized"},
            { ErrorShowReason.GeneralError, "General error"},
            { ErrorShowReason.RectTransformBlocked, "Ad show failed due to RectTransform size blocking"}
        };
        
        public enum PopUpType
        {
            IconPopUp,
            BannerPopUp
        }
        
        private const int AD_SIZE_LIMIT_DP_MIN = 70;
        private const int AD_SIZE_LIMIT_DP_MAX = 120;

        private readonly string _placementId;
        private readonly OdeeoSdk.PlacementType _type;
        
        private readonly OdeeoAdListener _adListener = new OdeeoAdListener();
        
        private OdeeoSdk.IconPosition _position = OdeeoSdk.IconPosition.BottomCenter;
        private int _xOffset = 10;
        private int _yOffset = 10;
        private int _size = 80;

        private OdeeoSdk.IconPosition _linkedPosition = OdeeoSdk.IconPosition.BottomCenter;
        private OdeeoIconAnchor _linkedAnchor;
        private RectTransform _linkedRect;
        private Canvas _linkedCanvas;
        
        private OdeeoSdk.AdSizingMethod _sizingMethod = OdeeoSdk.AdSizingMethod.Flexible;

        private LogoPositionType _posType = LogoPositionType.Direct;

        private const float FADE_VALUE = 0.1f;
        private float _sceneVolumeValue = 1f;
        
        private bool _isPlaying = false;

        // PopUp
        private PopUpType? _popupType = null;
        private OdeeoSdk.BannerPosition? _bannerPopupPosition = null;
        private OdeeoSdk.IconPosition? _iconPopupPosition = null;
        private int? _popUpOffsetX = null;
        private int? _popUpOffsetY = null;
        
        // Action Button
        private ActionButtonPosition? _actionButtonPosition = null;
        
#if UNITY_EDITOR
        private OdeeoEditorAdUnit _editorAdUnit;
        private const string AD_PREFAB_FILENAME = "OdeeoAd.prefab";
        private string _customTag = "";
#endif
        
#if UNITY_ANDROID && !UNITY_EDITOR
        protected AndroidJavaObject client;
#endif
        
#if UNITY_IOS && !UNITY_EDITOR
        protected IntPtr client;

        [DllImport("__Internal")]
        public static extern IntPtr _odeeoSdkCreateAudioAdUnit(int adType, string placementID, IntPtr listener);
        [DllImport("__Internal")]
        public static extern void _odeeoSdkShow(IntPtr client);
        [DllImport("__Internal")]
        public static extern void _odeeoSdkRemoveAd(IntPtr client);
        [DllImport("__Internal")]
        public static extern void _odeeoSdkSetIconPosition(IntPtr client, int position, int xOffset, int yOffset);
        [DllImport("__Internal")]
        public static extern void _odeeoSdkSetIconSize(IntPtr client, int size);
        [DllImport("__Internal")]
        public static extern void _odeeoSdkSetBannerPosition(IntPtr client, int position);
        [DllImport("__Internal")]
        public static extern bool _odeeoSdkIsAdAvailable(IntPtr client);
        [DllImport("__Internal")]
        public static extern bool _odeeoSdkIsAdCached(IntPtr client);
        
        [DllImport("__Internal")]
        public static extern IntPtr _odeeoSdkSetListeners(
            IntPtr client,
            IntPtr callbackRef,
            OdeeoAdListener.OdeeoSdkDelegateNative<bool, IntPtr> onAvailabilityChange,
            OdeeoAdListener.OdeeoSdkDelegateNative onShow,
            OdeeoAdListener.OdeeoSdkDelegateNative<string, int, string> onShowFailed,
            OdeeoAdListener.OdeeoSdkDelegateNative<int> onClose,
            OdeeoAdListener.OdeeoSdkDelegateNative onClick,
            OdeeoAdListener.OdeeoSdkDelegateNative<float> onReward,
            OdeeoAdListener.OdeeoSdkDelegateNative<IntPtr> onImpression,
            OdeeoAdListener.OdeeoSdkDelegateNative onRewardedPopupAppear,
            OdeeoAdListener.OdeeoSdkDelegateNative<int> onRewardedPopupClosed,
            OdeeoAdListener.OdeeoSdkDelegateNative<int> onPause,
            OdeeoAdListener.OdeeoSdkDelegateNative<int> onResume,
            OdeeoAdListener.OdeeoSdkDelegateNative onMute
            );
        
        [DllImport("__Internal")]
        public static extern IntPtr _odeeoSdkCreateMutableArray();
        [DllImport("__Internal")]
        public static extern void _odeeoSdkAddToMutableArray(IntPtr dictionary, int item);
        [DllImport("__Internal")]
        public static extern void _odeeoSdkSetRewardedPopupType(IntPtr client, int type);
        [DllImport("__Internal")]
        public static extern void _odeeoSdkSetRewardedPopupBannerPosition(IntPtr client, int position);
        [DllImport("__Internal")]
        public static extern void _odeeoSdkSetRewardedPopupIconPosition(IntPtr client, int position, int xOffset, int yOffset);
        [DllImport("__Internal")]
        public static extern void _odeeoSdkSetAudioOnlyAnimationColor(IntPtr client, string color);
        [DllImport("__Internal")]
        public static extern void _odeeoSdkSetAudioOnlyBackgroundColor(IntPtr client, string color);
        [DllImport("__Internal")]
        public static extern void _odeeoSdkSetProgressBarColor(IntPtr client, string tint);
        [DllImport("__Internal")]
        public static extern void _odeeoSdkSetIconActionButtonPosition(IntPtr client, int position);
        [DllImport("__Internal")]
        public static extern void _odeeoSdkSetCustomTag(IntPtr client, string tag);
        [DllImport("__Internal")]
        public static extern void _odeeoSdkDestroyBridgeReference(IntPtr obj);
        [DllImport("__Internal")]
        public static extern void _odeeoSdkTrackRewardedOffer(IntPtr obj);
        [DllImport("__Internal")]
        public static extern void _odeeoSdkTrackAdShowBlocked(IntPtr obj);
        [DllImport("__Internal")]
        public static extern void _odeeoSdkPause();
        [DllImport("__Internal")]
        public static extern void _odeeoSdkResume();
#endif
        
        public OdeeoAdUnit(OdeeoSdk.PlacementType adType, string placementID)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass typeEnum = new AndroidJavaClass ("io.odeeo.sdk.AdUnit$PlacementType");
            AndroidJavaObject curType = typeEnum.CallStatic<AndroidJavaObject> ("valueOf", adType.ToString ());
            
            client = new AndroidJavaObject ("io.odeeo.sdk.AdUnit", activity, curType, _adListener, placementID);
#elif UNITY_IOS && !UNITY_EDITOR
            SetAdListener();
            IntPtr adListener = _adListener.ADNativeListenerRef;
            
            client = _odeeoSdkCreateAudioAdUnit((int)adType, placementID, adListener);
#endif
            _placementId = placementID;
            _type = adType;
            
            _adListener.OnClose += OnClose;
            _adListener.OnShow += OnShow;
#if UNITY_EDITOR
            OdeeoSdk.SetOptimalDPI();
            Task.Delay(1000).ContinueWith(t=> OnAvailabilityChangeEditorCheck());
#endif
        }

        #region General

        internal void ShowAd()
        {
            RecalculatePositionAndSize();

            if (_adListener.IsAdBlocked)
            {
                DispatchOnShowError(ErrorShowReason.RectTransformBlocked);
                TrackAdShowBlocked();
                OdeeoSdk.LogW(OdeeoSdk.LogLevel.Info, "Ad blocked. Rect transform size is smaller than the minimum ad size");
                return;
            }
            
            SetPositionAndSize();

#if UNITY_ANDROID && !UNITY_EDITOR
            client.Call ("showAd");
#endif

#if UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkShow(client);
#endif

#if UNITY_EDITOR
            string adPrefabPath = OdeeoEditorHelper.GetAssetBasedPath(AD_PREFAB_FILENAME);
            if (string.IsNullOrEmpty(adPrefabPath))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Debug, "Can't find " + AD_PREFAB_FILENAME + " asset");
                return;
            }

            PopUpType popupType = _popupType ?? (OdeeoAdManager.IsBannerType(_type)
                ? PopUpType.BannerPopUp
                : PopUpType.IconPopUp);

            OdeeoSdk.IconPosition popupPosition;
            if (OdeeoAdManager.IsBannerType(popupType))
                popupPosition = _bannerPopupPosition != null ? (OdeeoSdk.IconPosition)(_bannerPopupPosition) : _position;
            else
                popupPosition = _iconPopupPosition ?? _position;

            EditorAdUnitData data = new EditorAdUnitData();
            data.AdUnit = this;
            data.IconPosition = _position;
            data.OffsetX = _xOffset;
            data.OffsetY = _yOffset;
            data.Size = new Vector2(_size, _size);
            data.Type = _type;
            data.PopupType = popupType;
            data.PopupPosition = popupPosition;
            data.PopupOffsetX = _popUpOffsetX ?? _xOffset;
            data.PopupOffsetY = _popUpOffsetY ?? _yOffset;
            data.CustomTag = _customTag;
            data.ActionButtonPosition = _actionButtonPosition ?? ActionButtonPosition.TopLeft;
            
            if (OdeeoAdManager.IsBannerType(_type))
            {
                data.Size = new Vector2(320, 50);
                data.OffsetX = 0;
                data.OffsetY = 0;
            }

            OdeeoEditorAdUnit logoPrefab = AssetDatabase.LoadAssetAtPath<OdeeoEditorAdUnit>(adPrefabPath);
            _editorAdUnit = Object.Instantiate(logoPrefab, Vector3.zero, Quaternion.identity);
            _editorAdUnit.Init(data, _adListener);
            Object.DontDestroyOnLoad(_editorAdUnit);
#endif
        }

        internal void RemoveAd()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            client.Call ("removeAd");
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkRemoveAd(client);
#elif UNITY_EDITOR
            if (_editorAdUnit)
                _editorAdUnit.DestroyAd(CloseReason.Other);
#endif
        }
        
        internal bool IsAdAvailable()
        {
            if (IsRectTransformBlocked())
                return false;
            
#if UNITY_ANDROID && !UNITY_EDITOR
            return client.Call<bool>("isAdAvailable");
#elif UNITY_IOS && !UNITY_EDITOR
            return _odeeoSdkIsAdAvailable(client);
#elif UNITY_EDITOR
            return _editorAdUnit == null;
#else
            return false;
#endif
        }

        internal bool IsAdCached()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            return client.Call<bool>("isAdCached");
#elif UNITY_IOS && !UNITY_EDITOR
            return _odeeoSdkIsAdCached(client);
#elif UNITY_EDITOR
            return true;
#else
            return false;
#endif
        }

        internal bool IsRectTransformBlocked()
        {
            if (_posType == LogoPositionType.Rect)
            {
                RecalculatePositionAndSize();
                return _adListener.IsAdBlocked;
            }

            return false;
        }

        private void SetAdListener()
        {
#if UNITY_IOS && !UNITY_EDITOR
            _adListener.ADNativeListenerRef = _odeeoSdkSetListeners(
            client, 
            (IntPtr)GCHandle.Alloc(_adListener),
            OdeeoAdListener.OnAvailabilityChangedNative,
            OdeeoAdListener.OnShowNative,
            OdeeoAdListener.OnShowFailedNative,
            OdeeoAdListener.OnCloseNative,
            OdeeoAdListener.OnClickNative,
            OdeeoAdListener.OnRewardNative,
            OdeeoAdListener.OnImpressionNative,
            OdeeoAdListener.OnRewardedPopupAppearNative,
            OdeeoAdListener.OnRewardedPopupClosedNative,
            OdeeoAdListener.OnPauseNative,
            OdeeoAdListener.OnResumeNative,
            OdeeoAdListener.OnMuteNative
            );
#endif
        }
        
        #endregion

        #region Positioning

        internal void SetBannerPosition(OdeeoSdk.BannerPosition position)
        {
            if (OdeeoAdManager.IsIconType(_type))
            {
                OdeeoSdk.LogW(OdeeoSdk.LogLevel.Debug, "SetBannerPosition can't be used with Icon ad type");
                return;
            }
            
            _position = (OdeeoSdk.IconPosition)position;
        }
        
        internal void LinkIconToRectTransform(OdeeoSdk.IconPosition iconPosition, RectTransform rectTransform, Canvas canvas, OdeeoSdk.AdSizingMethod sizingMethod)
        {
            if (OdeeoAdManager.IsBannerType(_type))
            {
                OdeeoSdk.LogW(OdeeoSdk.LogLevel.Debug, "LinkIconToRectTransform can't be used with Banner ad type");
                return;
            }
            
            _posType = LogoPositionType.Rect;
            _linkedRect = rectTransform;
            _linkedCanvas = canvas;
            _linkedPosition = iconPosition;
            _sizingMethod = sizingMethod;
            
            RecalculatePositionAndSize();
        }

        private void CalculateLinkToRectTransform()
        {
            if (!_linkedRect)
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Debug, "LinkIconToRectTransform function error. RectTransform is null");
                return;
            }

            if (!_linkedCanvas)
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Debug, "LinkIconToRectTransform function error. Canvas is null");
                return;
            }

            Rect rect = OdeeoRectHelper.GetScreenRect(_linkedRect, _linkedCanvas);
            rect = OdeeoRectHelper.LimitRectToScreen(rect);
            
            rect.position *= OdeeoSdk.GetDpiMultiplier();
            rect.size *= OdeeoSdk.GetDpiMultiplier();

            _adListener.IsAdBlocked = true;

            float bestSize = AD_SIZE_LIMIT_DP_MAX;
            Vector2 positinPx = Vector2.zero;
            int step = 5;
            for (int i = AD_SIZE_LIMIT_DP_MAX; i >= AD_SIZE_LIMIT_DP_MIN; i -= step)
            {
                bestSize = i;
                int sizeInPx = (int)(i * OdeeoSdk.GetDeviceScale());
                positinPx = OdeeoRectHelper.ConvertRectToPosition(rect, _linkedPosition, sizeInPx);
                Rect adRect = new Rect(positinPx, new Vector2(sizeInPx, sizeInPx));
                if (OdeeoRectHelper.IsRectContainsRect(adRect, rect))
                {
                    _adListener.IsAdBlocked = false;
                    break;
                }
            }

            switch (_sizingMethod)
            {
                case OdeeoSdk.AdSizingMethod.Flexible:
                    _adListener.IsAdBlocked = false; //using smallest icon, unblocking show
                    break;
                case OdeeoSdk.AdSizingMethod.Strict:
                    break;
            }

            Vector2 positionDp = OdeeoRectHelper.PixelPositionToDp(positinPx);
            
            _position = OdeeoSdk.IconPosition.BottomLeft;
            _xOffset = (int)positionDp.x;
            _yOffset = (int)positionDp.y;
            _size = (int)bestSize;
        }
        
        internal void LinkToIconAnchor(OdeeoIconAnchor iconAnchor)
        {
            if (OdeeoAdManager.IsBannerType(_type))
            {
                OdeeoSdk.LogW(OdeeoSdk.LogLevel.Debug, "LinkToIconAnchor can't be used with Banner ad type");
                return;
            }
            
            _posType = LogoPositionType.Anchor;
            _linkedAnchor = iconAnchor;

            RecalculatePositionAndSize();
        }

        private void CalculateLinkToPrefab()
        {
            if (!_linkedAnchor)
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Debug, "LinkToIconAnchor function error. IconAnchor is NULL");
                return;
            }

            RectTransform rt = _linkedAnchor.RectTransform;
            Canvas canvas = _linkedAnchor.Canvas;

            if (canvas == null || rt == null)
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Debug, "LinkToIconAnchor function error. IconAnchor Integrated incorrectly");
                return;
            }

            float multiplier = OdeeoSdk.GetDpiMultiplier();
            
            Rect rect = OdeeoRectHelper.GetScreenRect(rt, canvas);
            float s = rt.sizeDelta.x * canvas.scaleFactor * multiplier;
            Vector2 positionPx = OdeeoRectHelper.ConvertRectToPosition(rect, OdeeoSdk.IconPosition.BottomLeft, (int)s);
            positionPx *= multiplier;
            Vector2 positionDp = OdeeoRectHelper.PixelPositionToDp(positionPx);
            
            _position = OdeeoSdk.IconPosition.BottomLeft;
            _xOffset = (int)positionDp.x;
            _yOffset = (int)positionDp.y;
            _size = (int)(s / OdeeoSdk.GetDeviceScale());
        }

        internal void SetIconPosition(OdeeoSdk.IconPosition iconPosition, int xOffset, int yOffset)
        {
            if (OdeeoAdManager.IsBannerType(_type))
            {
                OdeeoSdk.LogW(OdeeoSdk.LogLevel.Debug, "SetIconPosition can't be used with Banner ad type");
                return;
            }

            _posType = LogoPositionType.Direct;
            
            _position = iconPosition;
            _xOffset = xOffset;
            _yOffset = yOffset;
        }

        internal void SetIconSize(int size)
        {
            _size = size;
        }

        private void RecalculatePositionAndSize()
        {
            _adListener.IsAdBlocked = false;
            
            switch (_posType)
            {
                case LogoPositionType.Direct:
                    break;
                case LogoPositionType.Anchor:
                    CalculateLinkToPrefab();
                    break;
                case LogoPositionType.Rect:
                    CalculateLinkToRectTransform();
                    break;
            }
        }

        private void SetPositionAndSize()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass posEnum;
            AndroidJavaObject curPos;
#endif
            // Banner Position
            if (OdeeoAdManager.IsBannerType(_type))
            {
#if UNITY_ANDROID && !UNITY_EDITOR
                posEnum = new AndroidJavaClass ("io.odeeo.sdk.AdPosition$BannerPosition");
                curPos = posEnum.CallStatic<AndroidJavaObject> ("valueOf", _position.ToString ());

                client.Call ("setBannerPosition", curPos);
#elif UNITY_IOS && !UNITY_EDITOR
                _odeeoSdkSetBannerPosition(client, (int)_position);
#endif
                return;
            }
            
            // Icon Position
#if UNITY_ANDROID && !UNITY_EDITOR
            posEnum = new AndroidJavaClass ("io.odeeo.sdk.AdPosition$IconPosition");
            curPos = posEnum.CallStatic<AndroidJavaObject> ("valueOf", _position.ToString ());

            client.Call ("setIconPosition", curPos, _xOffset, _yOffset);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetIconPosition(client, (int)_position, _xOffset, _yOffset);
#endif
            
            // Icon Size
#if UNITY_ANDROID && !UNITY_EDITOR
            client.Call ("setIconSize", _size);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetIconSize(client, _size);
#endif
        }

        #endregion

        #region RewardedPopUp

        internal void SetRewardedPopupType(PopUpType type)
        {
            _popupType = type;
            
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass en = new AndroidJavaClass ("io.odeeo.sdk.AdUnit$PopUpType");
            AndroidJavaObject curValue = en.CallStatic<AndroidJavaObject> ("valueOf", _popupType.ToString ());
            client.Call ("setRewardedPopUpType", curValue);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetRewardedPopupType(client, (int)_popupType);
#endif
        }

        internal void SetRewardedPopupBannerPosition(OdeeoSdk.BannerPosition position)
        {
            _bannerPopupPosition = position;
            
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass en = new AndroidJavaClass ("io.odeeo.sdk.AdPosition$BannerPosition");
            AndroidJavaObject curValue = en.CallStatic<AndroidJavaObject> ("valueOf", position.ToString ());
            client.Call ("setRewardedPopupBannerPosition", curValue);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetRewardedPopupBannerPosition(client, (int)position);
#endif
        }

        internal void SetRewardedPopupIconPosition(OdeeoSdk.IconPosition position, int xOffset, int yOffset)
        {
            _iconPopupPosition = position;
            
            _popUpOffsetX = xOffset;
            _popUpOffsetY = yOffset;

#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass en = new AndroidJavaClass ("io.odeeo.sdk.AdPosition$IconPosition");
            AndroidJavaObject curValue = en.CallStatic<AndroidJavaObject> ("valueOf", position.ToString ());
            client.Call ("setRewardedPopupIconPosition", curValue, xOffset, yOffset);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetRewardedPopupIconPosition(client, (int)position, xOffset, yOffset);
#endif
        }

        #endregion

        #region VisualSettings
        
        internal void SetProgressBarColor([Bridge.Ref] Color progressBarColor)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            string hexProgressBarColor = ColorUtility.ToHtmlStringRGBA(progressBarColor);
            hexProgressBarColor = "#" + hexProgressBarColor.Substring(6) + hexProgressBarColor.Remove(6);

            client.Call ("setProgressBarColor", hexProgressBarColor);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetProgressBarColor(client, "#"+ColorUtility.ToHtmlStringRGB(progressBarColor));
#endif
        }
        
        internal void SetAudioOnlyBackgroundColor([Bridge.Ref] Color color)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            string hexColor = ColorUtility.ToHtmlStringRGBA(color);
            hexColor = "#" + hexColor.Substring(6) + hexColor.Remove(6);
            
            client.Call ("setAudioOnlyBackgroundColor", hexColor);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetAudioOnlyBackgroundColor(client, "#"+ColorUtility.ToHtmlStringRGB(color));
#endif
        }

        internal void SetAudioOnlyAnimationColor([Bridge.Ref] Color color)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            string hexColor = ColorUtility.ToHtmlStringRGBA(color);
            hexColor = "#" + hexColor.Substring(6) + hexColor.Remove(6);

            client.Call ("setAudioOnlyAnimationColor", hexColor);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetAudioOnlyAnimationColor(client, "#"+ColorUtility.ToHtmlStringRGB(color));
#endif
        }

        #endregion

        #region ActionButton

        internal void SetIconActionButtonPosition(ActionButtonPosition position)
        {
            if (OdeeoAdManager.IsBannerType(_type))
            {
                OdeeoSdk.LogW(OdeeoSdk.LogLevel.Debug, "SetIconActionButtonPosition can't be used with Banner ad type");
                return;
            }

            if (OdeeoAdManager.IsAdRewardedType(_type))
            {
                OdeeoSdk.LogW(OdeeoSdk.LogLevel.Debug, "SetIconActionButtonPosition can't be used with Rewarded ad type");
                return;
            }
            
            _actionButtonPosition = position;
            
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass en = new AndroidJavaClass ("io.odeeo.sdk.AdUnit$ActionButtonPosition");
            AndroidJavaObject curValue = en.CallStatic<AndroidJavaObject> ("valueOf", _actionButtonPosition.ToString ());
            client.Call ("setIconActionButtonPosition", curValue);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetIconActionButtonPosition(client, (int)_actionButtonPosition);
#endif
        }

        #endregion

        #region Events
        
        private void OnShow()
        {
            _sceneVolumeValue = AudioListener.volume;
            AudioListener.volume = FADE_VALUE;

            _isPlaying = true;
            
            OdeeoSdk.LogI(OdeeoSdk.LogLevel.Debug, "Ad OnShow");
        }

        private void OnClose(CloseReason reason)
        {
            AudioListener.volume = _sceneVolumeValue;
            _isPlaying = false;
#if UNITY_EDITOR
            _editorAdUnit = null;
#endif
            OdeeoSdk.LogI(OdeeoSdk.LogLevel.Debug, "Ad OnClose");
        }
        
        #endregion

        internal void SetCustomTag(String tag)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            client.Call ("setCustomTag", tag);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetCustomTag(client, tag);
#elif UNITY_EDITOR
            _customTag = tag;
#endif
        }
        
        internal void TrackRewardedOffer()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            client.Call ("trackRewardedOffer");
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkTrackRewardedOffer(client);
#endif
        }
        
        private void TrackAdShowBlocked()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            client.Call ("trackAdShowBlocked");
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkTrackAdShowBlocked(client);
#endif
        }

        internal void DispatchOnShowError(ErrorShowReason reason, string customMessage = null)
        {
            string message = string.IsNullOrEmpty(customMessage) ? s_errorShowMessage[reason] : customMessage;
            _adListener.OnShowFailed.Invoke(_placementId, reason, message);
        }
        
#if UNITY_EDITOR
        private void OnAvailabilityChangeEditorCheck()
        {
            _adListener.OnAvailabilityChangedEditor(true, new OdeeoAdData(_type, _customTag));
        }
#endif
        
        public void Dispose()
        {
            _adListener.OnClose -= OnClose;
            _adListener.OnShow -= OnShow;
#if UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkDestroyBridgeReference(client);
            _odeeoSdkDestroyBridgeReference(_adListener.ADNativeListenerRef);
#endif
        }

        internal OdeeoAdListener AdCallbacks => _adListener;
        internal bool IsPlaying => _isPlaying;
        internal OdeeoSdk.PlacementType PlacementType => _type;
#if UNITY_EDITOR
        internal OdeeoEditorAdUnit EditorAdUnit => _editorAdUnit;
#endif
    }
}