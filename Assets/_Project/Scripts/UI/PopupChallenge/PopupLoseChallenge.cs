public class PopupLoseChallenge : Popup
{
    protected override void BeforeShow()
    {
        base.BeforeShow();
        SoundController.Instance.PlayFX(SoundType.Lose);
        PopupController.Instance.Show<PopupUI>();
    }
    
    protected override void BeforeHide()
    {
        base.BeforeHide();
        PopupController.Instance.Hide<PopupUI>();
    }
    
    public void OnClickRetry()
    {
        if (LevelController.Instance.LevelType == LevelType.Challenge)
        {
            LevelEvent.CurrentLevelChallengeItem.OnClickPlay();
        }
        else
        {
            LevelEvent.CurrentMultipleChallengeItem.OnClickPlay();
        }
    }
}
