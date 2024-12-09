using System;
using System.Runtime.InteropServices;
using AOT;
using Odeeo.Data;
using Odeeo.Utils;
using UnityEngine;

namespace Odeeo
{
    public class OdeeoAdListener
#if UNITY_ANDROID && !UNITY_EDITOR
        : AndroidJavaProxy
#endif
    {
        public OdeeoSdk.OdeeoSdkDelegate<bool, OdeeoAdData> OnAvailabilityChanged = (flag, data) => { };
        public OdeeoSdk.OdeeoSdkDelegate OnShow = () => { };
        public OdeeoSdk.OdeeoSdkDelegate<OdeeoAdUnit.CloseReason> OnClose = (result) => { };
        public OdeeoSdk.OdeeoSdkDelegate OnClick = () => { };
        public OdeeoSdk.OdeeoSdkDelegate<float> OnReward = (amount) => { };

        public OdeeoSdk.OdeeoSdkDelegate<OdeeoImpressionData> OnImpression = (data) => { };
        public OdeeoSdk.OdeeoSdkDelegate OnRewardedPopupAppear = () => { };
        public OdeeoSdk.OdeeoSdkDelegate<OdeeoAdUnit.CloseReason> OnRewardedPopupClosed = (result) => { };
        public OdeeoSdk.OdeeoSdkDelegate<OdeeoAdUnit.StateChangeReason> OnPause = (result) => { };
        public OdeeoSdk.OdeeoSdkDelegate<OdeeoAdUnit.StateChangeReason> OnResume = (result) => { };
        public OdeeoSdk.OdeeoSdkDelegate OnMute = () => { };

        public OdeeoSdk.OdeeoSdkDelegate<string, OdeeoAdUnit.ErrorShowReason, string> OnShowFailed =
            (placementId, result, description) => { };

        public bool IsAdBlocked = false;

#if UNITY_ANDROID && !UNITY_EDITOR
        public OdeeoAdListener() : base("io.odeeo.sdk.AdListener")
        {
        }

        void onAvailabilityChanged(bool availability, AndroidJavaObject data)
        {
            bool availabilityStatus = availability;
            if (IsAdBlocked)
                availabilityStatus = IsAdBlocked;
            
            OdeeoAdData adData = new OdeeoAdData(data);
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => OnAvailabilityChanged(availabilityStatus, adData));
        }

        void onShow()
        {
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => OnShow());
        }

        void onClose(AndroidJavaObject adResult)
        {
            int typeIndex = adResult.Call<int> ("ordinal");
            OdeeoAdUnit.CloseReason result = (OdeeoAdUnit.CloseReason)typeIndex;
            
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => OnClose(result));
        }

        void onClick()
        {
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => OnClick());
        }

        void onReward(float amount)
        {
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => OnReward(amount));
        }

        void onImpression(AndroidJavaObject data)
        {
            OdeeoImpressionData impressionData = new OdeeoImpressionData(data);
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => OnImpression(impressionData));
        }

        void onRewardedPopupAppear()
        {
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => OnRewardedPopupAppear());
        }

        void onRewardedPopupClosed(AndroidJavaObject reason)
        {
            int reasonIndex = reason.Call<int> ("ordinal");
            OdeeoAdUnit.CloseReason closeReason = (OdeeoAdUnit.CloseReason)reasonIndex;
            
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => OnRewardedPopupClosed(closeReason));
        }

        void onPause(AndroidJavaObject reason)
        {
            int reasonIndex = reason.Call<int> ("ordinal");
            OdeeoAdUnit.StateChangeReason stateChangeReason = (OdeeoAdUnit.StateChangeReason)reasonIndex;
            
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => OnPause(stateChangeReason));
        }
        
        void onResume(AndroidJavaObject reason)
        {
            int reasonIndex = reason.Call<int> ("ordinal");
            OdeeoAdUnit.StateChangeReason stateChangeReason = (OdeeoAdUnit.StateChangeReason)reasonIndex;
            
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => OnResume(stateChangeReason));
        }
        
        void onMute()
        {
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => OnMute());
        }

        void onShowFailed(string placementId, AndroidJavaObject reason, string description)
        {
            int reasonIndex = reason.Call<int>("ordinal");
            OdeeoAdUnit.ErrorShowReason errorShowReason = (OdeeoAdUnit.ErrorShowReason)reasonIndex;
            
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => OnShowFailed(placementId, errorShowReason, description));
        }
#endif


#if UNITY_IOS && !UNITY_EDITOR
        public IntPtr ADNativeListenerRef;

        public delegate void OdeeoSdkDelegateNative(IntPtr client);

        public delegate void OdeeoSdkDelegateNative<in T>(IntPtr client, T flag);

        public delegate void OdeeoSdkDelegateNative<in T1, in T2>(IntPtr client, T1 flag, T2 data);

        public delegate void OdeeoSdkDelegateNative<in T1, in T2, in T3>(IntPtr client, T1 data1, T2 data2, T3 data3);

        private static OdeeoAdListener IntPtrToClient(IntPtr cl)
        {
            GCHandle handle = (GCHandle)cl;
            return handle.Target as OdeeoAdListener;
        }

        [MonoPInvokeCallback(typeof(OdeeoSdkDelegateNative<bool, IntPtr>))]
        public static void OnAvailabilityChangedNative(IntPtr client, bool flag, IntPtr data)
        {
            OdeeoAdListener listener = IntPtrToClient(client);

            bool availabilityStatus = flag;
            if (listener.IsAdBlocked)
                availabilityStatus = listener.IsAdBlocked;

            OdeeoAdData adData = new OdeeoAdData(data);

            OdeeoMainThreadDispatcher.Instance()
                .Enqueue(() => listener.OnAvailabilityChanged(availabilityStatus, adData));
        }

        [MonoPInvokeCallback(typeof(OdeeoSdkDelegateNative))]
        public static void OnShowNative(IntPtr client)
        {
            OdeeoAdListener listener = IntPtrToClient(client);
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => listener.OnShow());
        }

        [MonoPInvokeCallback(typeof(OdeeoSdkDelegateNative<string, int, string>))]
        public static void OnShowFailedNative(IntPtr client, string placementId, int reason, string description)
        {
            OdeeoAdListener listener = IntPtrToClient(client);
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => listener.OnShowFailed(placementId, (OdeeoAdUnit.ErrorShowReason)reason, description));
        }

        [MonoPInvokeCallback(typeof(OdeeoSdkDelegateNative<int>))]
        public static void OnCloseNative(IntPtr client, int result)
        {
            OdeeoAdListener listener = IntPtrToClient(client);
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => listener.OnClose((OdeeoAdUnit.CloseReason)result));
        }
        
        [MonoPInvokeCallback(typeof(OdeeoSdkDelegateNative))]
        public static void OnClickNative(IntPtr client)
        {
            OdeeoAdListener listener = IntPtrToClient(client);
            OdeeoMainThreadDispatcher.Instance().Enqueue( () => listener.OnClick() );
        }
        
        [MonoPInvokeCallback(typeof(OdeeoSdkDelegateNative<float>))]
        public static void OnRewardNative(IntPtr client, float amount)
        {
            OdeeoAdListener listener = IntPtrToClient(client);
            OdeeoMainThreadDispatcher.Instance().Enqueue( () => listener.OnReward(amount) );
        }
        
        [MonoPInvokeCallback(typeof(OdeeoSdkDelegateNative<IntPtr>))]
        public static void OnImpressionNative(IntPtr client, IntPtr data)
        {
            OdeeoAdListener listener = IntPtrToClient(client);
            OdeeoImpressionData impressionData = new OdeeoImpressionData(data);
            OdeeoMainThreadDispatcher.Instance().Enqueue( () => listener.OnImpression(impressionData) );
        }
        
        [MonoPInvokeCallback(typeof(OdeeoSdkDelegateNative))]
        public static void OnRewardedPopupAppearNative(IntPtr client)
        {
            OdeeoAdListener listener = IntPtrToClient(client);
            OdeeoMainThreadDispatcher.Instance().Enqueue( () => listener.OnRewardedPopupAppear() );
        }
        
        [MonoPInvokeCallback(typeof(OdeeoSdkDelegateNative<int>))]
        public static void OnRewardedPopupClosedNative(IntPtr client, int result)
        {
            OdeeoAdListener listener = IntPtrToClient(client);
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => listener.OnRewardedPopupClosed((OdeeoAdUnit.CloseReason)result));
        }
        
        [MonoPInvokeCallback(typeof(OdeeoSdkDelegateNative<int>))]
        public static void OnPauseNative(IntPtr client, int result)
        {
            OdeeoAdListener listener = IntPtrToClient(client);
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => listener.OnPause((OdeeoAdUnit.StateChangeReason)result));
        }
        
        [MonoPInvokeCallback(typeof(OdeeoSdkDelegateNative<int>))]
        public static void OnResumeNative(IntPtr client, int result)
        {
            OdeeoAdListener listener = IntPtrToClient(client);
            OdeeoMainThreadDispatcher.Instance().Enqueue(() => listener.OnResume((OdeeoAdUnit.StateChangeReason)result));
        }
        
        [MonoPInvokeCallback(typeof(OdeeoSdkDelegateNative))]
        public static void OnMuteNative(IntPtr client)
        {
            OdeeoAdListener listener = IntPtrToClient(client);
            OdeeoMainThreadDispatcher.Instance().Enqueue( () => listener.OnMute() );
        }
#endif
        
#if UNITY_EDITOR
        public void OnAvailabilityChangedEditor(bool availability, OdeeoAdData adData)
        {
            bool availabilityStatus = availability;
            
            if (IsAdBlocked)
                availabilityStatus = IsAdBlocked;
            
            OnAvailabilityChanged(availabilityStatus, adData);
        }
#endif
    }
}