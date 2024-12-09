//using com.adjust.sdk;
using UnityEngine;
#if UNITY_IOS
using Unity.Advertisement.IosSupport;
#endif

public class AdjustController : SingletonDontDestroy<AdjustController>
{
    //public Adjust adjust;

    protected override void Awake()
    {
        base.Awake();
#if UNITY_IOS
        if (ATTrackingStatusBinding.GetAuthorizationTrackingStatus() == ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
        {
            ATTrackingStatusBinding.RequestAuthorizationTracking(CallbackAuthorizationTracking);
        }
        else
        {
            InitAdjust();
        }
#else
            InitAdjust();
#endif
    }

    private void CallbackAuthorizationTracking(int status)
    {
        InitAdjust();
    }

    private void InitAdjust()
    {
        //AdjustConfig adjustConfig = new AdjustConfig(adjust.appToken, adjust.environment, (adjust.logLevel == AdjustLogLevel.Suppress));
        //adjustConfig.setLogLevel(adjust.logLevel);
        //adjustConfig.setSendInBackground(adjust.sendInBackground);
        //adjustConfig.setEventBufferingEnabled(adjust.eventBuffering);
        //adjustConfig.setLaunchDeferredDeeplink(adjust.launchDeferredDeeplink);
        //adjustConfig.setDefaultTracker(adjust.defaultTracker);
        //adjustConfig.setUrlStrategy(adjust.urlStrategy.ToLowerCaseString());
        //adjustConfig.setAppSecret(adjust.secretId, adjust.info1, adjust.info2, adjust.info3, adjust.info4);
        //adjustConfig.setDelayStart(adjust.startDelay);
        //adjustConfig.setNeedsCost(adjust.needsCost);
        //adjustConfig.setPreinstallTrackingEnabled(adjust.preinstallTracking);
        //adjustConfig.setPreinstallFilePath(adjust.preinstallFilePath);
        ////adjustConfig.setAllowiAdInfoReading(adjust.iadInfoReading);
        //adjustConfig.setAllowAdServicesInfoReading(adjust.adServicesInfoReading);
        //adjustConfig.setAllowIdfaReading(adjust.idfaInfoReading);
        //adjustConfig.setCoppaCompliantEnabled(adjust.coppaCompliant);
        //adjustConfig.setPlayStoreKidsAppEnabled(adjust.playStoreKidsApp);
        //adjustConfig.setLinkMeEnabled(adjust.linkMe);
        //if (!adjust.skAdNetworkHandling)
        //{
        //    adjustConfig.deactivateSKAdNetworkHandling();
        //}
        
        //Adjust.start(adjustConfig);
        
        //QDPRController.Instance.Request();
    }

    public void TrackEvent(string adjustToken, double price)
    {
        //var purchasedEvent = new AdjustEvent(adjustToken);
        //purchasedEvent.setRevenue(price, "USD");
        //Adjust.trackEvent(purchasedEvent);
    }
}
