using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupChallenge : Popup
{
    [SerializeField] private ChallengeConfig challengeConfig;
    [SerializeField] private Page currentPage = Page.LevelChallenge;
    [SerializeField] private LevelChallengeItem levelChallengeItemPrefab;
    [SerializeField] private MultipleChallengeItem multipleChallengeItemPrefab;
    [SerializeField] private LevelChallengeContent levelChallenge;
    [SerializeField] private MultiplyChallengeContent multiplyChallenge;
    [SerializeField] private GameObject lockMultiply;

    private MultipleChallengePlayer MultipleChallengePlayer => challengeConfig.MultipleChallengePlayer;
    private LevelChallengeConfig LevelChallengeConfig => challengeConfig.LevelChallengeConfig;
    private MultipleChallengeConfig MultipleChallengeConfig => challengeConfig.MultipleChallengeConfig;

    private bool _isInitialize;
    private bool _isNavigateFromInGame;

    public override void Initialize()
    {
        EventController.OnRestoreDataComplete += EventController_OnRestoreDataComplete;

        LevelEvent.OnLoseChallenge += OnLoseChallenge;
        LevelEvent.OnWinMultiple += OnWinMultiple;
        LevelEvent.OnLoseMultiple += OnLoseMultiple;
        
        SetupMultiplyChallengeContent();
        SetupLevelChallengeContent();
    }

    public void OnDestroy()
    {
        LevelEvent.OnLoseChallenge -= OnLoseChallenge;
        LevelEvent.OnWinMultiple -= OnWinMultiple;
        LevelEvent.OnLoseMultiple -= OnLoseMultiple;
    }

    protected override void BeforeShow()
    {
        base.BeforeShow();
        lockMultiply.SetActive(!MultipleChallengeConfig.IsUnlock());

        challengeConfig.SaveData();
        SetupContent(currentPage);

        PopupController.Instance.Show<PopupUI>();
    }

    protected override void AfterHidden()
    {
        if (!_isNavigateFromInGame) return;

        _isNavigateFromInGame = false;
        PopupController.Instance.Hide<PopupUI>();
    }

    private void EventController_OnRestoreDataComplete()
    {
        for (var i = 0; i < LevelChallengeConfig.Datas.Count; i++)
        {
            levelChallenge.levelChallengeItemList[i].Setup(i, LevelChallengeConfig.Datas[i], challengeConfig);
        }

        for (var i = 0; i < MultipleChallengeConfig.Datas.Count; i++)
        {
            multiplyChallenge.multiplyChallengeItemList[i].Setup(i, MultipleChallengePlayer.currentIndex,
                MultipleChallengeConfig.Datas[i],
                challengeConfig);
        }
    }

    private void SetupLevelChallengeContent()
    {
        for (var i = 0; i < LevelChallengeConfig.Datas.Count; i++)
        {
            var levelItem = Instantiate(levelChallengeItemPrefab, levelChallenge.challengeContent, false);
            levelItem.Setup(i, LevelChallengeConfig.Datas[i], challengeConfig);
            levelChallenge.levelChallengeItemList.Add(levelItem);
        }
    }

    private void SetupMultiplyChallengeContent()
    {
        for (var i = 0; i < MultipleChallengeConfig.Datas.Count; i++)
        {
            var multipleItem = Instantiate(multipleChallengeItemPrefab, multiplyChallenge.challengeContent, false);
            multipleItem.Setup(i, MultipleChallengePlayer.currentIndex, MultipleChallengeConfig.Datas[i],
                challengeConfig);
            multiplyChallenge.multiplyChallengeItemList.Add(multipleItem);
        }

        multiplyChallenge.SetupGiftProcess();
    }

    private void SetupContent(Page page)
    {
        if (page == Page.LevelChallenge)
        {
            levelChallenge.ToggleActive(true);
            multiplyChallenge.ToggleActive(false);
        }
        else
        {
            levelChallenge.ToggleActive(false);
            multiplyChallenge.ToggleActive(true);
        }
    }

    public void PlayFirstChallengeItem()
    {
        levelChallenge.levelChallengeItemList[0].OnClickPlay();
    }

    public void OnClickClaimGift()
    {
        SoundController.Instance.PlayFX(SoundType.PurchaseComplete);
        MultipleChallengePlayer.giftNumb -= MultipleChallengeConfig.GiftNumber;
        multiplyChallenge.UpdateGiftProcess();
        challengeConfig.SaveData();
    }

    public void OnClickLevelChallenge()
    {
        currentPage = Page.LevelChallenge;
        SetupContent(currentPage);
    }

    public void OnClickMultipleChallenge()
    {
        currentPage = Page.MultipleChallenge;
        SetupContent(currentPage);
    }

    private void OnWinChallenge()
    {
        challengeConfig.SaveData();
    }

    private void OnLoseChallenge()
    {
        LevelEvent.CurrentLevelChallengeItem.UserData.isPlayed = true;
        LevelEvent.CurrentLevelChallengeItem.UserData.isWined = false;
    }

    private void OnWinMultiple()
    {
        //FirebaseManager.LevelEnd(LevelType.Multiple.ToString(), LevelEvent.CurrentMultipleChallengeItem.index + 1, 1, "true");
        var playerMultipleData = challengeConfig.MultipleChallengePlayer;
        if (LevelEvent.CurrentMultipleChallengeItem.index >=
            playerMultipleData.currentIndex)
        {
            playerMultipleData.currentIndex++;
        }

        playerMultipleData.giftNumb++;
        challengeConfig.SaveData();
    }

    private void OnLoseMultiple()
    {
        //FirebaseManager.LevelEnd(LevelType.Multiple.ToString(), LevelEvent.CurrentMultipleChallengeItem.index + 1, 0, "false");
        challengeConfig.SaveData();
    }
}

[Serializable]
public class ChallengeContent
{
    public GameObject selectedBtn;
    public GameObject notSelectedBtn;
    public GameObject challengeFrame;
    public Transform challengeContent;

    public void ToggleActive(bool status)
    {
        if (status) RefreshContent();

        selectedBtn.SetActive(status);
        notSelectedBtn.SetActive(!status);
        challengeFrame.SetActive(status);
    }

    public virtual void RefreshContent()
    {
    }
}

[Serializable]
public class LevelChallengeContent : ChallengeContent
{
    public List<LevelChallengeItem> levelChallengeItemList;

    public override void RefreshContent()
    {
        foreach (var challengeItem in levelChallengeItemList)
        {
            challengeItem.Refresh();
        }
    }
}

[Serializable]
public class MultiplyChallengeContent : ChallengeContent
{
    public List<MultipleChallengeItem> multiplyChallengeItemList;
    public Image giftProgress;
    public TextMeshProUGUI textProgress;
    public GameObject fxGiftReady;
    public GameObject btnClaimGift;
    public TextMeshProUGUI textGiftCoin;

    private MultipleChallengePlayer MultipleChallengePlayer => ConfigController.ChallengeConfig.MultipleChallengePlayer;
    private MultipleChallengeConfig MultipleChallengeConfig => ConfigController.ChallengeConfig.MultipleChallengeConfig;

    public override void RefreshContent()
    {
        foreach (var multipleItem in multiplyChallengeItemList)
        {
            multipleItem.Refresh(MultipleChallengePlayer.currentIndex);
        }

        UpdateGiftProcess();
    }

    public void SetupGiftProcess()
    {
        giftProgress.fillAmount = (float)MultipleChallengePlayer.giftNumb / MultipleChallengeConfig.GiftNumber;
        textGiftCoin.text = $"{MultipleChallengeConfig.GiftClaimReward}";
    }

    public void UpdateGiftProcess()
    {
        giftProgress.DOFillAmount((float)MultipleChallengePlayer.giftNumb / MultipleChallengeConfig.GiftNumber, 1f)
            .SetUpdate(isIndependentUpdate: true);
        textProgress.text = $"{MultipleChallengePlayer.giftNumb}/{MultipleChallengeConfig.GiftNumber}";
        if (MultipleChallengePlayer.giftNumb >= MultipleChallengeConfig.GiftNumber)
        {
            btnClaimGift.SetActive(true);
            fxGiftReady.SetActive(true);
        }
        else
        {
            btnClaimGift.SetActive(false);
            fxGiftReady.SetActive(false);
        }
    }
}

public enum Page
{
    LevelChallenge,
    MultipleChallenge,
}