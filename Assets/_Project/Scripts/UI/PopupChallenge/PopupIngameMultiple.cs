using TMPro;
using UnityEngine;

public class PopupIngameMultiple : Popup
{
    public GameObject txtLevel;
    public GameObject fxWin1;
    public GameObject fxWin2;
    public TextMeshProUGUI txtBall;

    private Level _currentLevel => LevelController.Instance.CurrentLevel;

    public void OnEnable()
    {
        LevelEvent.OnWinMultiple += OnWin;
        LevelEvent.OnBallActive += UpdateBallActive;
        LevelEvent.OnMultipleBallChange += UpdateBallActive;
        if (LevelController.Instance && _currentLevel) UpdateBallActive();
    }

    public void OnDisable()
    {
        LevelEvent.OnWinMultiple -= OnWin;
        LevelEvent.OnBallActive -= UpdateBallActive;
        LevelEvent.OnMultipleBallChange -= UpdateBallActive;
    }

    protected override void BeforeShow()
    {
        base.BeforeShow();
        //AdsManager.HideBanner();
    }

    private void UpdateBallActive()
    {
        txtBall.text = $"{_currentLevel.GetNumberActiveBalls()}";
    }

    public void Setup(int index)
    {
        fxWin1.SetActive(false);
        fxWin2.SetActive(false);
    }

    private void OnWin()
    {
        SoundController.Instance.PlayFX(SoundType.FireworkFX);
        SoundController.Instance.PlayFX(SoundType.FireworkFX);
        fxWin1.SetActive(true);
        fxWin2.SetActive(true);
    }

}