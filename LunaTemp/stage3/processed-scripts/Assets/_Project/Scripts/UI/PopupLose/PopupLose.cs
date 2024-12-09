using PubScale.SdkOne.NativeAds;
using UnityEngine;

public class PopupLose : Popup
{

    protected override void BeforeShow()
    {
        SoundController.Instance.PlayFX(SoundType.Lose);
        PopupController.Instance.Show<PopupUI>();
    }

    protected override void AfterShown()
    {
        base.AfterShown();
    }

    protected override void BeforeHide()
    {
        base.BeforeHide();
        PopupController.Instance.Hide<PopupUI>();
    }
}