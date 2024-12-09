using UnityEngine;

public class PopupInGameChallenge : Popup
{
    public GameObject LevelText;
    public GameObject MoveLeftText;
    public GameObject ConfesttiWin1;
    public GameObject ConfesttiWin2;

    public void OnEnable()
    {
        LevelEvent.OnWinChallenge += OnWin;
    }
    public void OnDisable()
    {
        LevelEvent.OnWinChallenge -= OnWin;
    }

    protected override void BeforeShow()
    {
        base.BeforeShow();
        //AdsManager.HideBanner();
    }

    public void Setup(int index)
    {
        ConfesttiWin1.SetActive(false);
        ConfesttiWin2.SetActive(false);
    }

    private void OnWin()
    {
        SoundController.Instance.PlayFX(SoundType.FireworkFX);
        SoundController.Instance.PlayFX(SoundType.FireworkFX);
        ConfesttiWin1.SetActive(true);
        ConfesttiWin2.SetActive(true);
    }
}
