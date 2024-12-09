using TMPro;
using UnityEngine;

public class LevelChallengeItem : MonoBehaviour
{
    [SerializeField] private GameObject unplayableGo;
    [SerializeField] private GameObject playableGo;
    [SerializeField] private GameObject failGo;
    [SerializeField] private GameObject successGo;
    [SerializeField] private GameObject playBtn;
    [SerializeField] private GameObject playAgainBtn;
    [SerializeField] private TextMeshProUGUI indexText;
    [SerializeField] private TextMeshProUGUI coinValueText;
    [SerializeField] private TextMeshProUGUI coinValueText2;

    [ReadOnly] public int Index;
    [ReadOnly] public LevelChallengeConfigModel Model;
    [ReadOnly] public LevelChallengePlayerData UserData;

    public LevelChallengeConfig _levelChallengeConfig;

    public void Setup(int index, LevelChallengeConfigModel model, ChallengeConfig challengeConfig)
    {
        _levelChallengeConfig = challengeConfig.LevelChallengeConfig;

        Index = index;
        Model = model;
        UserData = challengeConfig.Get(Model.Id) ?? challengeConfig.Add(Model.Id);
        Refresh();
    }

    private void SetupDefaultUI()
    {
        indexText.text = $"{Index + 1}";
        unplayableGo.SetActive(false);
        playableGo.SetActive(false);
        failGo.SetActive(false);
        successGo.SetActive(false);
        playBtn.SetActive(false);
        playAgainBtn.SetActive(false);

        coinValueText.text = $"{Model.CoinReward}";
        coinValueText2.text = $"{Model.CoinReward}";
    }

    public void Refresh()
    {
        SetupDefaultUI();

        if (_levelChallengeConfig.IsUnlockLevelChallenge(Model))
        {
            if (UserData.isPlayed)
            {
                playAgainBtn.SetActive(true);
                if (UserData.isWined)
                {
                    successGo.SetActive(true);
                }
                else
                {
                    failGo.SetActive(true);
                }
            }
            else
            {
                playableGo.SetActive(true);
                playBtn.SetActive(true);
            }
        }
        else
        {
            unplayableGo.SetActive(true);
        }
    }

    public void OnClickPlay()
    {
        OnPlayThisLevel();
    }

    public void OnClickPlayAgain()
    {
        OnPlayThisLevel();
    }

    private void OnPlayThisLevel()
    {
        LevelEvent.CurrentLevelChallengeItem = this;
        var popup = PopupController.Instance.Get<PopupInGameChallenge>() as PopupInGameChallenge;
        if (popup != null) popup.Setup(Index);
    }
}