using TMPro;
using UnityEngine;

public class MultipleChallengeItem : MonoBehaviour
{
    [SerializeField] private GameObject unplayableGo;
    [SerializeField] private GameObject playableGo;
    [SerializeField] private GameObject successGo;
    [SerializeField] private GameObject btnPlayGo;
    [SerializeField] private GameObject btnPlayAgainGo;
    [SerializeField] private TextMeshProUGUI indexText;
    
    [ReadOnly] public int index;
    [ReadOnly] public MultipleChallengeConfigModel model;
    [ReadOnly] public MultipleChallengePlayerData data;

    public void Setup(int idx, int currentMultipleLevel, MultipleChallengeConfigModel modelParam, ChallengeConfig challengeConfig)
    {
        index = idx;
        model = modelParam;
        data = challengeConfig.MultipleChallengePlayer.Get(model.Id) ?? challengeConfig.MultipleChallengePlayer.Add(model.Id);
        Refresh(currentMultipleLevel);
    }

    private void SetupDefaultUI()
    {
        indexText.text = $"{index + 1}";
        unplayableGo.SetActive(false);
        playableGo.SetActive(false);
        successGo.SetActive(false);
        btnPlayGo.SetActive(false);
        btnPlayAgainGo.SetActive(false);
    }

    public void Refresh(int currentLevel)
    {
        SetupDefaultUI();

        if (index < currentLevel)
        {
            // win
            btnPlayGo.SetActive(true);
            successGo.SetActive(true);
        }
        else if (index == currentLevel)
        {
            // current
            playableGo.SetActive(true);
            btnPlayGo.SetActive(true);
        }
        else
        {
            // not playable
            unplayableGo.SetActive(true);
        }
    }

    public void OnClickPlay()
    {
        OnPlayThisLevel();
    }

    public void OnClickPlayAgain()
    {
        OnClickPlay();
    }

    private void OnPlayThisLevel()
    {
        LevelEvent.CurrentMultipleChallengeItem = this;
        var popup = PopupController.Instance.Get<PopupIngameMultiple>() as PopupIngameMultiple;
        popup?.Setup(index);
    }
}