using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUnlockChallenge : Popup
{
    protected override void BeforeShow()
    {
        base.BeforeShow();
        //Data.FirstUnlockChallenge = false;
    }

    public void PlayChallenge()
    {
        if (PopupController.Instance.Get<PopupChallenge>() is not PopupChallenge popupChallenge)
        {
            Hide();
            return;
        }

        popupChallenge.PlayFirstChallengeItem();
    }
}