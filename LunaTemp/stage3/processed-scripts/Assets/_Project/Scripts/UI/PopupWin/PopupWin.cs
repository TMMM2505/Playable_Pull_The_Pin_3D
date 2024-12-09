using System;
using System.Collections;
using DG.Tweening;
//using Pancake.Monetization;
using PubScale.SdkOne.NativeAds;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupWin : Popup
{
    public GameObject TapToContinueBtn;
    public GameObject RewardAdsBtn;

    protected override void BeforeShow()
    {
        base.BeforeShow();
        SoundController.Instance.PlayFX(SoundType.Win);
    }

    protected override void BeforeHide()
    {
        base.BeforeHide();
    }
    public override void Show(int index = 0, LevelType type = LevelType.Normal, bool isOpenNavigateBar = false)
    {
        base.Show(index, type, isOpenNavigateBar);
    }
    public IEnumerator OnClickContinue()
    {
        yield return new WaitForSeconds(1.5f);
        TapToContinueBtn.SetActive(false);
        DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
        {
            VFXSpawnController.Instance.DeActiveAllEffectWhenRestartLevel();
            GameManager.Instance.PlayCurrentLevel();
        });
    }

}