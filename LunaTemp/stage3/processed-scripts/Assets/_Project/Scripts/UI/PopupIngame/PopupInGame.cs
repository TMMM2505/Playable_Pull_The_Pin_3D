using System;
using System.Collections.Generic;
using DG.Tweening;
using Odeeo;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class PopupInGame : Popup
{
    public GameObject ConfesttiWin1;
    public GameObject ConfesttiWin2;

    private void Awake()
    {
        //_starBarDefaultScale = starBar.transform.localScale;
        //_starBarCanvasGroup = starBar.GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        var eventGameData = ConfigController.GameEventConfig.GetGameEventData(GameEventType.Noel2023);
    }

    private void OnEnable()
    {
        LevelEvent.OnWin += OnWin;
        EventController.OnNotifying += Setup;
    }

    private void OnDisable()
    {
        LevelEvent.OnWin -= OnWin;
        EventController.OnNotifying -= Setup;
    }

    public override void Show(int index = 0, LevelType type = LevelType.Normal, bool isOpenNavigateBar = false)
    {
        base.Show(index, type, isOpenNavigateBar);
    }

    //private void ShowNavigationBar()
    //{
    //    DOTween.Kill(navigateBar);
    //    navigateBar.gameObject.SetActive(true);
    //    navigateBarOverlay.SetActive(true);
    //}

    private bool IsEnableToClick()
    {
        return GameManager.Instance.GameState == GameState.PlayingGame;
    }

    protected override void BeforeShow()
    {
        base.BeforeShow();
        Setup();
    }

    protected override void AfterShown()
    {
        //if (Data.PlayingLeaderboardEvent && leaderboardEventConfig.IsTournamentEnd)
        //{
        //    if (PopupController.Instance.Get<PopupEventResult>() is not PopupEventResult popupEventResult)
        //        return;

        //    popupEventResult.Show(leaderboardEventConfig.GetPlayerTop());
        //}
        //else if (!Data.IsCompleteEventTutorial && Data.CurrentLevel >= leaderboardEventConfig.LevelToUnlock)
        //{
        //    tutorialComponent.RunTutorial(GetComponent<Canvas>().sortingOrder + 1, tutorialHand, tutorialBlocker);
        //    _isRunningTutorial = true;
        //}
    }


    private void Setup()
    {
        ConfesttiWin1.SetActive(false);
        ConfesttiWin2.SetActive(false);
    }

    //private void UpdateTextEvent()
    //{
    //    //TextEventCounter.text = $"{Data.EventNoelItem2023}";
    //}

    private void OnWin()
    {
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            SoundController.Instance.PlayFX(SoundType.FireworkFX);
            SoundController.Instance.PlayFX(SoundType.FireworkFX);
            ConfesttiWin1.SetActive(true);
            ConfesttiWin2.SetActive(true);
        });
    }

}
    

