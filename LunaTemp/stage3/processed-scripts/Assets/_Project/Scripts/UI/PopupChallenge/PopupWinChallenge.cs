using DG.Tweening;
//using Pancake.Monetization;
using TMPro;
using UnityEngine;


public class PopupWinChallenge : Popup
{
    public BonusArrowHandler BonusArrowHandler;
    public TextMeshProUGUI RewardText;
    public TextMeshProUGUI BonusAdsRewardText;
    public GameObject RewardAdsBtn;
    public GameObject TapToContinueBtn;

    private int multipleBonusValue = 1;
    private int totalCoin;
    private Sequence sequence;

    private LevelType _levelType;
    private int _currentLevel;

    public override void Show(int level = 0, LevelType levelType = LevelType.Normal, bool isOpenNavigateBar = false)
    {
        base.Show(level, levelType, isOpenNavigateBar);
        _levelType = levelType;
        _currentLevel = level;
    }

    protected override void BeforeShow()
    {
        base.BeforeShow();
        SoundController.Instance.PlayFX(SoundType.Win);
        PopupController.Instance.Show<PopupUI>();
        Setup();
    }

    public void Setup()
    {
        if (LevelController.Instance.LevelType == LevelType.Challenge)
        {
            totalCoin = LevelEvent.CurrentLevelChallengeItem.Model.CoinReward;
        }
        else if (LevelController.Instance.LevelType == LevelType.Multiple)
        {
            totalCoin = ConfigController.ChallengeConfig.MultipleChallengeConfig.CoinReward + LevelController.Instance.CurrentLevel.BonusCoin;
        }
        
        RewardText.text = $"+ {totalCoin}";
        RewardAdsBtn.SetActive(true);
        TapToContinueBtn.SetActive(false);
        BonusArrowHandler.MoveObject.IsRun = true;

        sequence = DOTween.Sequence().AppendInterval(2f).AppendCallback(() => { TapToContinueBtn.SetActive(true); });
    }

    protected override void BeforeHide()
    {
        base.BeforeHide();
        PopupController.Instance.Hide<PopupUI>();
    }

    public void Update()
    {
        if (BonusArrowHandler.CurrentAreaItem != null && BonusAdsRewardText != null)
        {
            BonusAdsRewardText.text = $"+{totalCoin * BonusArrowHandler.CurrentAreaItem.MultiBonus}";
        }
    }
}
