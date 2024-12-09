using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DG.Tweening;
using Pancake.GameService;
using Pancake.IAP;
//using Pancake.Monetization;
using UnityEngine;
#if UNITY_IOS
using UnityEngine.iOS;
#endif

public class GameManager : Singleton<GameManager>
{
    public LevelController LevelController;
    public GameState GameState;

    [SerializeField] private List<Level> _levelList = new System.Collections.Generic.List<Level>();

    private int _currentLevel = 0;

    private LevelType _levelType;
    protected override void Awake()
    {
        base.Awake();
        Application.targetFrameRate = 60;
        Input.multiTouchEnabled = false;
        DOTween.SetTweensCapacity(300, 100);
        Data.FirstTimeShowBannerCollapsible = 1;
    }

    private int winCount = 0, loseCount = 0;

    private void Start()
    {
        DontDestroyOnLoad(this);

        _levelType = LevelType.Normal;

        PlayCurrentLevel();
        ReturnGameplay();
    }
    public void PrepareNormalLevel()
    {
        GameState = GameState.PrepareGame;
        LevelController.PrepareNormalLevel(_levelList[_currentLevel]);
    }

    public void PrepareChallengeLevel()
    {
        GameState = GameState.PrepareGame;
        LevelController.PrepareChallengeLevel(_levelList[_currentLevel].GetComponent<LevelChallenge>());
    }
    public void PrepareMultipleLevel()
    {
        GameState = GameState.PrepareGame;
        LevelController.PrepareChallengeMultiple(_levelList[_currentLevel].GetComponent<MultipleChallenge>());
    }

    public void ReturnGameplay()
    {
        PopupController.Instance.HideAll();
        PopupController.Instance.Show<PopupInGame>();
    }

    public void PlayCurrentLevel()
    {
        if (_levelType == LevelType.Normal)
        {
            PrepareNormalLevel();
        }
        else if (_levelType == LevelType.Challenge)
        {
            PrepareChallengeLevel();
        }
        else if (_levelType == LevelType.Multiple)
        {
            PrepareMultipleLevel();
        }
        GameState = GameState.PlayingGame;
    }

    void NextLevel()
    {
        _currentLevel++;
        DOTween.Sequence().AppendInterval(2.5f).AppendCallback(() =>
        {
            PlayCurrentLevel();
        });
    }
    public void OnWinGame(float delayPopupShowTime = 2.5f)
    {
        if (GameState is GameState.LoseGame or GameState.WinGame) return;

        LevelEvent.OnWin?.Invoke();

        SoundController.Instance.PlayFX(SoundType.Win);

        GameState = GameState.WinGame;
        if (_levelType == LevelType.Normal)
        {
            DOTween.Sequence().AppendInterval(delayPopupShowTime).AppendCallback(() =>
            {
                PopupController.Instance.HideAll();
                PopupController.Instance.Show<PopupWin>();
            });
            //_levelType = LevelType.Challenge;
            //NextLevel();
        }
        //else if (_levelType == LevelType.Challenge)
        //{
        //    _levelType = LevelType.Multiple;
        //    NextLevel();
        //}
        //else if (_levelType == LevelType.Multiple)
        //{
        //    DOTween.Sequence().AppendInterval(delayPopupShowTime).AppendCallback(() =>
        //    {
        //        PopupController.Instance.HideAll();
        //        Debug.Log("check 1");
        //        PopupController.Instance.Show<PopupWin>();
        //        Debug.Log("check 2");
        //    });
        //}
    }

    public void OnLoseGame(float delayPopupShowTime = 2.5f)
    {
        if (GameState is GameState.LoseGame or GameState.WinGame) return;
        GameState = GameState.LoseGame;
        SoundController.Instance.PlayFX(SoundType.Lose);
        DOTween.Sequence().AppendInterval(delayPopupShowTime).AppendCallback(() =>
        {
            PopupController.Instance.HideAll();
            PopupController.Instance.Show<PopupLose>();
        });
    }
}

public enum GameState
{
    PrepareGame,
    PlayingGame,
    WaitingResult,
    LoseGame,
    WinGame,
}