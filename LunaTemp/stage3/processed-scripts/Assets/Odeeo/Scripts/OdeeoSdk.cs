using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using Odeeo.Utils;
using UnityEngine;

namespace Odeeo
{
    public class OdeeoSdk
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        public const string ANDROID_HELPER = "io.odeeo.sdk.OdeeoAndroidHelper";
        
        private const string ANDROID_BRIDGE = "io.odeeo.sdk.OdeeoSDK";
        private static AndroidJavaObject _androidBridge; 

        private static AndroidJavaObject getBridge ()
        {
            if (_androidBridge == null)
                using (AndroidJavaClass pluginClass = new AndroidJavaClass(ANDROID_BRIDGE))
                    _androidBridge = pluginClass.GetStatic<AndroidJavaObject> ("INSTANCE");

            return _androidBridge;
        }
#endif

#if UNITY_IOS && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void _odeeoSdkInitialize(string apiKey);
        [DllImport("__Internal")]
        private static extern void _odeeoSdkSetEngineInfo(string engineName, string engineVersion);
        [DllImport("__Internal")]
        private static extern bool _odeeoSdkIsInitialized();

        // Regulation
        [DllImport("__Internal")]
        private static extern void _odeeoSdkSetIsChildDirected(bool flag);
        [DllImport("__Internal")]
        private static extern void _odeeoSdkRequestTrackingAuthorization();
        
        // Regulation Type
        [DllImport("__Internal")]
        private static extern void _odeeoSdkForceRegulationType(int type);
        [DllImport("__Internal")]
        private static extern void _odeeoSdkClearForceRegulationType();
        [DllImport("__Internal")]
        private static extern int _odeeoSdkGetRegulationType();
        
        //GDPR
        [DllImport("__Internal")]
        private static extern void _odeeoSdkSetGdprConsentString(string consentString);
        [DllImport("__Internal")]
        private static extern void _odeeoSdkSetGdprConsent(bool consent);
        [DllImport("__Internal")]
        private static extern void _odeeoSdkSetGdprConsentWithString(bool consent, string consentString);
        
        //DoNotSell
        [DllImport("__Internal")]
        private static extern void _odeeoSdkSetDoNotSellPrivacyString(string privacyString);
        [DllImport("__Internal")]
        private static extern void _odeeoSdkSetDoNotSell(bool isApplied);
        [DllImport("__Internal")]
        private static extern void _odeeoSdkSetDoNotSellWithString(bool isApplied, string privacyString);
        
        //End Regulation
        
        [DllImport("__Internal")]
        private static extern void _odeeoSdkSetLogLevel(int level);
        [DllImport("__Internal")]
        private static extern void _odeeoSdkAddCustomAttribute(string key, string value);
        [DllImport("__Internal")]
        private static extern void _odeeoSdkClearCustomAttributes();
        [DllImport("__Internal")]
        private static extern void _odeeoSdkRemoveCustomAttribute(string key);
        [DllImport("__Internal")]
        private static extern IntPtr _odeeoSdkSetOnInitializationListener(IntPtr callbackRef, OdeeoSdkListener.OdeeoSdkNoArgsDelegateNative onInitializationSuccess, OdeeoSdkListener.OdeeoSdkNoArgsDelegateNative onInitializationFail);
        [DllImport("__Internal")]
        private static extern String _odeeoSdkGetCustomAttributes();
        [DllImport("__Internal")]
        private static extern String _odeeoSdkGetCustomAttributesWithKey(string key);
        [DllImport("__Internal")]
        private static extern String _odeeoSdkGetPublisherUserID();
        [DllImport("__Internal")]
        private static extern void _odeeoSdkSetPublisherUserID(string value);
        [DllImport("__Internal")]
        private static extern float _odeeoSdkGetDeviceVolumeLevel();
        [DllImport("__Internal")]
        private static extern float _odeeoSdkGetDeviceScale();
        [DllImport("__Internal")]
        private static extern void _odeeoSdkPause();
        [DllImport("__Internal")]
        private static extern void _odeeoSdkResume();
#endif

#if UNITY_EDITOR
        private static int _editorDpi = 0;
        private static bool _isSetByUserDPI = false;
#endif
        private static int _targetDPI = -1;
        private static LogLevel _logLevel = LogLevel.Debug;
        
        private static bool _isInitialized = false;
        private static bool _isInitializationInProgress = false;
        
        public const string SDK_VERSION = OdeeoBuildConfig.SDK_VERSION;

        public enum LogLevel
        {
            None,
            Info,
            Debug
        }

        public enum IconPosition
        {
            TopLeft = 0,
            TopCenter = 1,
            TopRight = 2,
            CenterLeft = 3,
            Centered = 4,
            CenterRight = 5,
            BottomLeft = 6,
            BottomCenter = 7,
            BottomRight = 8
        }

        public enum BannerPosition
        {
            TopCenter = 1,
            BottomCenter = 7
        }

        public enum PlacementType
        {
            AudioBannerAd,
            RewardedAudioBannerAd,
            AudioIconAd,
            RewardedAudioIconAd
        }

        public enum ConsentType
        {
            Undefined,
            None,
            Gdpr,
            Ccpa
        }

        public enum AdSizingMethod
        {
            Flexible,
            Strict
        }

        public delegate void OdeeoSdkDelegate();
        public delegate void OdeeoSdkDelegate<in T>(T result);
        public delegate void OdeeoSdkDelegate<in T1, in T2>(T1 value, T2 result);
        public delegate void OdeeoSdkDelegate<in T1, in T2, in T3>(T1 value1, T2 value2, T3 value3);
        public delegate void OdeeoSdkErrorDelegate(int errorParam, String error);

        public class OdeeoSdkListener
#if UNITY_ANDROID && !UNITY_EDITOR
    : AndroidJavaProxy
#endif
        {
            public OdeeoSdkDelegate OnInitializationFinished = () => { };
            public OdeeoSdkErrorDelegate OnInitializationFailed = (errorParam, error) => { };

#if UNITY_ANDROID && !UNITY_EDITOR
            public OdeeoSdkListener() : base ("io.odeeo.sdk.common.SdkInitializationListener") { }

            void onInitializationFinished ()
            {
                OdeeoMainThreadDispatcher.Instance().Enqueue( () => OnInitializationFinished() ) ;
            }

            void onInitializationFailed(int errorParam, String error)
            {
                OdeeoMainThreadDispatcher.Instance().Enqueue( () => OnInitializationFailed(errorParam, error) ) ;
            }
#endif

#if UNITY_IOS && !UNITY_EDITOR
            public IntPtr OdeeoSdkNativeListenerRef;

            public delegate void OdeeoSdkNoArgsDelegateNative (IntPtr client);

            private static OdeeoSdkListener IntPtrToClient(IntPtr cl){
                GCHandle handle = (GCHandle)cl;
                return handle.Target as OdeeoSdkListener;
            }

            [MonoPInvokeCallback(typeof(OdeeoSdkNoArgsDelegateNative ))]
            public static void OnInitializationSuccessNative(IntPtr client){
                OdeeoSdkListener listener = IntPtrToClient(client);
                OdeeoMainThreadDispatcher.Instance().Enqueue( () => listener.OnInitializationFinished() );
            }

            [MonoPInvokeCallback(typeof(OdeeoSdkNoArgsDelegateNative ))]
            public static void OnInitializationFailNative(IntPtr client){
                OdeeoSdkListener listener = IntPtrToClient(client);
                OdeeoMainThreadDispatcher.Instance().Enqueue( () => listener.OnInitializationFailed(0, "Failed") );
            }
#endif
        }
        
        #region Initialization
        
        public static OdeeoSdkDelegate OnInitializationFinished = () => { };
        public static OdeeoSdkErrorDelegate OnInitializationFailed = (errorParam, error) => { };

        private static OdeeoSdkListener _odeeoSdkListener = new OdeeoSdkListener();
        
#pragma warning disable 0162
        public static void Initialize(string appKey)
        {
#if !UNITY_ANDROID && !UNITY_IOS
            LogE(LogLevel.Info, "Unsupported platform. Only iOS and Android are supported at the moment.");
            return;
#endif
            if (_isInitializationInProgress)
            {
                LogW(LogLevel.Info, "OdeeoSDK Initialization in progress");
                return;
            }
            
            if (_isInitialized)
            {
                LogW(LogLevel.Info, "OdeeoSDK already initialized");
                return;
            }

            _isInitializationInProgress = true;
            
            OdeeoMainThreadDispatcher.Instance();
            string unityVersion = Application.unityVersion;

            _odeeoSdkListener.OnInitializationFinished += OnInitializationFinishedInt;
            _odeeoSdkListener.OnInitializationFailed += OnInitializationFailedInt;
            
#if UNITY_ANDROID && !UNITY_EDITOR
            using (AndroidJavaObject helper = new AndroidJavaObject(ANDROID_HELPER))
                helper.Call("initialize", unityVersion, SDK_VERSION, _odeeoSdkListener, appKey);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkListener.OdeeoSdkNativeListenerRef =
                _odeeoSdkSetOnInitializationListener((IntPtr)GCHandle.Alloc(_odeeoSdkListener), OdeeoSdkListener.OnInitializationSuccessNative, OdeeoSdkListener.OnInitializationFailNative);
            _odeeoSdkSetEngineInfo("unity_" + unityVersion, SDK_VERSION);
            _odeeoSdkInitialize(appKey);
#else
            LogI(LogLevel.Info,"Unity Editor Dummy Initialization");
            OnInitializationFinishedInt();
#endif
        }
#pragma warning restore 0162

        private static void OnInitializationFinishedInt()
        {
            _isInitialized = true;
            _isInitializationInProgress = false;
            
            _odeeoSdkListener.OnInitializationFinished -= OnInitializationFinishedInt;
            _odeeoSdkListener.OnInitializationFailed -= OnInitializationFailedInt;
            
            LogI(LogLevel.Info, "Initialized");
            
            OnInitializationFinished();
        }

        private static void OnInitializationFailedInt(int errorParam, string error)
        {
            _isInitialized = false;
            _isInitializationInProgress = false;
            
            _odeeoSdkListener.OnInitializationFinished -= OnInitializationFinishedInt;
            _odeeoSdkListener.OnInitializationFailed -= OnInitializationFailedInt;
            
            LogE(LogLevel.Info, $"Initialization Failed with param: {errorParam.ToString()} and error: {error}");

            OnInitializationFailed(errorParam, error);
        }

        public static bool IsInitialized()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            return getBridge ().CallStatic<bool>("isInitialized");
#elif UNITY_IOS && !UNITY_EDITOR
            return _odeeoSdkIsInitialized();
#else
            return _isInitialized;
#endif
        }
        
        #endregion

        #region Regulation

        public static void SetIsChildDirected(bool flag)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            getBridge ().CallStatic("setIsChildDirected", flag);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetIsChildDirected(flag);
#endif
        }

        public static void RequestTrackingAuthorization()
        {
#if UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkRequestTrackingAuthorization();
#else
            LogW(LogLevel.Info,
                "RequestTrackingAuthorization() ignored. Requesting tracking authorization is made only for iOS platform.");
#endif
        }
        
        #region RegulationType
        public static void ForceRegulationType(ConsentType type)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass consentEnum = new AndroidJavaClass ("io.odeeo.sdk.dto.consent.ConsentType");
            AndroidJavaObject curType = consentEnum.CallStatic<AndroidJavaObject> ("valueOf", type.ToString ());
            getBridge ().CallStatic("forceRegulationType", curType);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkForceRegulationType((int)type);
#endif
        }

        public static void ClearForceRegulationType()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            getBridge ().CallStatic("clearForceRegulationType");
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkClearForceRegulationType();
#endif
        }

        public static ConsentType GetRegulationType()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaObject consentEnum = getBridge ().CallStatic<AndroidJavaObject>("getRegulationType");
            int typeIndex = consentEnum.Call<int> ("ordinal");
            return (ConsentType)typeIndex;
#elif UNITY_IOS && !UNITY_EDITOR
            return (ConsentType)_odeeoSdkGetRegulationType();
#endif
            return ConsentType.None;
        }
        
        #endregion

        #region Gdpr
        
        public static void SetGdprConsentString(string consentString)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            getBridge ().CallStatic("setGdprConsentString", consentString);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetGdprConsentString(consentString);
#endif
        }

        public static void SetGdprConsent(bool consent)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            getBridge ().CallStatic("setGdprConsent", consent);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetGdprConsent(consent);
#endif
        }
        
        public static void SetGdprConsent(bool consent, string consentString)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            getBridge ().CallStatic("setGdprConsent", consent, consentString);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetGdprConsentWithString(consent, consentString);
#endif
        }
        
        #endregion
        
        #region DoNotSell
        
        public static void SetDoNotSellPrivacyString(string privacyString)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            getBridge ().CallStatic("setDoNotSellPrivacyString", privacyString);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetDoNotSellPrivacyString(privacyString);
#endif
        }
        
        public static void SetDoNotSell(bool isApplied)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            getBridge ().CallStatic("setDoNotSell", isApplied);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetDoNotSell(isApplied);
#endif
        }

        public static void SetDoNotSell(bool isApplied, string privacyString)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            getBridge ().CallStatic("setDoNotSell", isApplied, privacyString);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetDoNotSellWithString(isApplied, privacyString);
#endif
        }
        
        #endregion

        #endregion
        
        /// <summary>
        /// Returns current device volume in Percentages from 0 to 100
        /// </summary>
        public static float GetDeviceVolumeLevel()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            return getBridge ().CallStatic<float>("getDeviceVolumeLevel");
#elif UNITY_IOS && !UNITY_EDITOR
            return _odeeoSdkGetDeviceVolumeLevel();
#else
            LogW(LogLevel.Debug, "Editor mode is not supported. Returned value always 100");
            return 100.0f;
#endif
        }

        public static void AddCustomAttribute(string key, string value)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            getBridge ().CallStatic("addCustomAttribute", key, value);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkAddCustomAttribute(key, value);
#endif
        }

        public static void ClearCustomAttributes()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            getBridge ().CallStatic("clearCustomAttributes");
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkClearCustomAttributes();
#endif
        }

        public static void RemoveCustomAttribute(string key)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            getBridge ().CallStatic("removeCustomAttribute", key);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkRemoveCustomAttribute(key);
#endif
        }

        public static List<KeyValuePair<String, String>> GetCustomAttributes()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaObject obj = getBridge ().CallStatic<AndroidJavaObject>("getCustomAttributes");
            string str = obj.Call<string>("toString");
            return ParseCustomAttributesStringAndroid(str);
#elif UNITY_IOS && !UNITY_EDITOR
            return ParseCustomAttributesStringIOS(_odeeoSdkGetCustomAttributes());
#else
            return new List<KeyValuePair<String, String>>();
#endif
        }

        public static List<KeyValuePair<String, String>> GetCustomAttributes(string key)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaObject obj = getBridge ().CallStatic<AndroidJavaObject>("getCustomAttributes", key);
            string str = obj.Call<string>("toString");
            return ParseCustomAttributesStringAndroid(str);
#elif UNITY_IOS && !UNITY_EDITOR
            return ParseCustomAttributesStringIOS(_odeeoSdkGetCustomAttributesWithKey(key));
#else
            return new List<KeyValuePair<String, String>>();
#endif
        }

        private static List<KeyValuePair<string, string>> ParseCustomAttributesStringAndroid(string str)
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            
            if (string.IsNullOrEmpty(str) || str.Length == 2)
                return list;

            str = str.Substring(1, str.Length - 2);
            string[] elements = str.Split(new [] { ", " }, StringSplitOptions.None);
            
            for (int i = 0; i < elements.Length; i++)
            {
                string[] keyValue = elements[i].Split('=');
                list.Add(new KeyValuePair<string, string>(keyValue[0], keyValue[1]));
            }

            return list;
        }

        private static List<KeyValuePair<string, string>> ParseCustomAttributesStringIOS(string str)
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            
            if (string.IsNullOrEmpty(str) || str.Length == 2)
                return list;
            
            str = str.Substring(1, str.Length - 2);
            string[] elements = str.Split(new [] { "," }, StringSplitOptions.None);
            
            for (int i = 0; i < elements.Length; i++)
            {
                string element = elements[i];
                element = element.Substring(1, element.Length - 2);
                
                string[] keyValue = element.Split(new [] { ": " }, StringSplitOptions.None);
                list.Add(new KeyValuePair<string, string>(keyValue[0], keyValue[1]));
            }
            
            return list;
        }

        public static void SetPublisherUserID(string id)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            getBridge ().CallStatic("setPublisherUserID", id);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetPublisherUserID(id);
#endif
        }

        public static string GetPublisherUserID()
        {
            string id = "";
#if UNITY_ANDROID && !UNITY_EDITOR
            id = getBridge ().CallStatic<string>("getPublisherUserID");
#elif UNITY_IOS && !UNITY_EDITOR
            id = _odeeoSdkGetPublisherUserID();
#endif
            return id;
        }

        #region ScreenSettings
        
        internal static void SetOptimalDPI()
        {
#if UNITY_EDITOR
            int dpi = GetOptimalDPI();

            if(!_isSetByUserDPI)
                _editorDpi = dpi;
#endif
        }

        private static int GetOptimalDPI()
        {
            int dpi = OdeeoEditorHelper.GetScreenDPI(Screen.width, Screen.height);
            if (dpi > 0)
                return dpi;

            float shortSide = Screen.width < Screen.height ? Screen.width : Screen.height;
            if (shortSide >= 1440)
                dpi = 440;
            else if (shortSide >= 1080)
                dpi = 323;
            else if (shortSide >= 720)
                dpi = 252;
            else if (shortSide >= 480)
                dpi = 170;

            return dpi;
        }

        public static void SetUnityEditorDPI(int dpi)
        {
#if UNITY_EDITOR
            _editorDpi = dpi;
            _isSetByUserDPI = true;
#endif
        }

        public static void SetTargetDPI(int dpi)
        {
            _targetDPI = dpi;
        }
        
        internal static float GetScreenDPI()
        {
#if UNITY_EDITOR
            return _editorDpi;
#else
            return Screen.dpi;
#endif
        }

        internal static float GetDpiMultiplier()
        {
            if (_targetDPI <= 0)
                return 1f;

            float currentDPI = Mathf.Min(GetScreenDPI(), _targetDPI);
            return GetScreenDPI() / currentDPI;
        }

        internal static float GetDeviceScale()
        {
            float scale = 1f;
#if UNITY_ANDROID
            scale =  GetScreenDPI() / 160f;
#elif UNITY_IOS && !UNITY_EDITOR
            scale = _odeeoSdkGetDeviceScale();
#elif UNITY_IOS && UNITY_EDITOR
            scale =  Mathf.Round(GetScreenDPI() / 160f);
#endif
            return Mathf.Max(1f, scale);
        }

        #endregion

        #region Pause
        
        public delegate void OnApplicationPause(bool isPaused);

        public static OnApplicationPause onApplicationPause = (isPaused) =>
        {
            if (isPaused) OnPause();
            else OnResume();
        };
        
        private static void OnPause()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            getBridge ().CallStatic ("onPause");
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkPause();
#endif
        }

        private static void OnResume()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            getBridge ().CallStatic ("onResume");
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkResume();
#endif
        }
        
        #endregion

        #region Logging

        public static void SetLogLevel(LogLevel level)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass typeEnum = new AndroidJavaClass ("io.odeeo.sdk.common.LogLevel");
            AndroidJavaObject curType = typeEnum.CallStatic<AndroidJavaObject> ("valueOf", level.ToString ());
            getBridge ().CallStatic("setLogLevel", curType);
#elif UNITY_IOS && !UNITY_EDITOR
            _odeeoSdkSetLogLevel((int)level);
#elif UNITY_EDITOR
            _logLevel = level;
#endif
        }
        
        internal static void LogE(LogLevel type, string message)
        {
            switch (_logLevel)
            {
                case LogLevel.Debug:
                    Debug.LogError("OdeeoSdk: " + message);
                    break;

                case LogLevel.Info:
                    if (type == LogLevel.Info)
                        Debug.LogError("OdeeoSdk: " + message);
                    break;

                case LogLevel.None:
                    break;
            }
        }

        internal static void LogW(LogLevel type, string message)
        {
            switch (_logLevel)
            {
                case LogLevel.Debug:
                    Debug.LogWarning("OdeeoSdk: " + message);
                    break;

                case LogLevel.Info:
                    if (type == LogLevel.Info)
                        Debug.LogWarning("OdeeoSdk: " + message);
                    break;

                case LogLevel.None:
                    break;
            }
        }

        internal static void LogI(LogLevel type, string message)
        {
            switch (_logLevel)
            {
                case LogLevel.Debug:
                    Debug.Log("OdeeoSdk: " + message);
                    break;

                case LogLevel.Info:
                    if (type == LogLevel.Info)
                        Debug.Log("OdeeoSdk: " + message);
                    break;

                case LogLevel.None:
                    break;
            }
        }
        
        #endregion
    }
}