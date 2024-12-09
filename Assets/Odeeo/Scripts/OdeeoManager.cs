using System;
using Odeeo;
using Odeeo.Data;
using UnityEngine;

public class OdeeoManager : SingletonDontDestroy<OdeeoManager>
{
    [SerializeField] private OdeeoSdk.LogLevel logLevel;

    private const string APP_KEY = "6a73067e-f412-4716-a746-ad14b8e35f43";
    private const string ICON_PLACEMENT_ID = "396876920";

    private string _currentId;
    private bool _isLinkedIconAds;

    private void Start()
    {
        OdeeoSdk.OnInitializationFinished += OdeeoSdk_OnInitializationFinished;
        OdeeoSdk.OnInitializationFailed += OdeeoSdk_OnInitializationFailed;
        OdeeoSdk.SetLogLevel(logLevel);
        OdeeoSdk.Initialize(APP_KEY);
    }

    private void OdeeoSdk_OnInitializationFinished()
    {
        Debug.Log("OddeoSdk Initialize Successfully");

        // OdeeoSdk.SetIsChildDirected(true);
        OdeeoAdManager.CreateAudioIconAd(ICON_PLACEMENT_ID);
        // OdeeoAdManager.LinkIconToRectTransform("376373450", OdeeoSdk.IconPosition.TopRight, rect, canvas);
        // OdeeoAdManager.SetIconPosition(ICON_PLACEMENT_ID, OdeeoSdk.IconPosition.TopRight, 100, 100);
        // OdeeoAdManager.SetIconSize(ICON_PLACEMENT_ID, 70);
    }

    private void OdeeoSdk_OnInitializationFailed(int errorParam, string error)
    {
        Debug.Log($"OddeoSdk Initialize Failed - ErrorParam: {errorParam} - ErrorLog: {error}");
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        OdeeoSdk.onApplicationPause(pauseStatus);
    }

    //private bool IsSufficientConditionToShowOdeeoAds(string placementId)
    //{
    //    return !Data.PurchasedRemoveAds && !OdeeoAdManager.IsAdPlaying(placementId) &&
    //           OdeeoAdManager.IsAdAvailable(placementId);
    //}

    #region IngameIconAds

    public void ShowInGameIconAds(RectTransform rect, Canvas can, Action actionCallBack)
    {
        //if (IsSufficientConditionToShowOdeeoAds(ICON_PLACEMENT_ID))
        //{
        //    if (!_isLinkedIconAds)
        //    {
        //        _isLinkedIconAds = true;
        //        OdeeoAdManager.LinkIconToRectTransform(ICON_PLACEMENT_ID, OdeeoSdk.IconPosition.CenterLeft, rect, can);
        //    }

        //    OdeeoAdManager.ShowAd(ICON_PLACEMENT_ID);
        //    actionCallBack?.Invoke();
        //}
    }

    public void ShowInGameIconAds()
    {
        //    if (!_isLinkedIconAds) return;
        //    if (IsSufficientConditionToShowOdeeoAds(ICON_PLACEMENT_ID))
        //    {
        //        OdeeoAdManager.ShowAd(ICON_PLACEMENT_ID);
        //    }
    }

    public void RemoveInGameIconAds()
    {
        if (OdeeoAdManager.IsAdPlaying(ICON_PLACEMENT_ID)) OdeeoAdManager.RemoveAd(ICON_PLACEMENT_ID);
    }

    #endregion

    public void PauseAds(bool isPause)
    {
        OdeeoSdk.onApplicationPause(isPause);
    }
}