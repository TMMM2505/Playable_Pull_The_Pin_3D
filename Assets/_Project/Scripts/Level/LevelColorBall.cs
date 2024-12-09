using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pancake;
using UnityEngine;

public class LevelColorBall : Level
{
    [Header("Color ball mode")] 
    public int targetRed;
    public int targetYellow;
    public int targetBlue;
    
    public ColorBallScore redBall;
    public ColorBallScore yellowBall;
    public ColorBallScore blueBall;

    [SerializeField, HideInInspector] private List<ColorBallHolder> _listHolder = new List<ColorBallHolder>();
    [SerializeField, HideInInspector] private List<ColorBall> _ballList = new List<ColorBall>();
    [SerializeField, HideInInspector] private List<ColorBallScore> _ballScoreList;
    
    public override LevelType Type => LevelType.ColorBall;

    private bool _hasWonLevel = false;
    
    public void CheckWinByScore()
    {
        var winLevel = _ballScoreList.All(ballScore => ballScore.currentScore >= ballScore.targetColorBallScore);
        if (winLevel && !_hasWonLevel)
        {
            _hasWonLevel = true;
            OnWinGame();
        }
    }

    protected override void Awake()
    {
        base.Awake();
        Setup();
    }

    private void Setup()
    {
        _listHolder = GetComponentsInChildren<ColorBallHolder>().ToList();
        
        _ballList = GetComponentsInChildren<ColorBall>().ToList();
        _ballScoreList = new List<ColorBallScore>(){redBall , yellowBall, blueBall};

        redBall.colorType = BallColorType.RED;
        yellowBall.colorType = BallColorType.YELLOW;
        blueBall.colorType = BallColorType.BULE;

        redBall.targetColorBallScore = targetRed;
        yellowBall.targetColorBallScore = targetYellow;
        blueBall.targetColorBallScore = targetBlue;

        foreach (var ballScore in _ballScoreList)
        {
            ballScore.listBallInScene = new List<ColorBall>();
        }
        
        foreach (var ball in _ballList)
        {
            var colorOfBall = ball.BallColorType;
            switch (colorOfBall)
            {
                case BallColorType.RED:
                    redBall.listBallInScene.Add(ball);
                    break;
                case BallColorType.YELLOW:
                    yellowBall.listBallInScene.Add(ball);
                    break;
                case BallColorType.BULE:
                    blueBall.listBallInScene.Add(ball);
                    break;
                default:
                    break;
            }
        }
        
        UpdateTotalScoreCanGet();
    }

    private void SetupListColorBall()
    {
        
    }

    public override void UpdateTotalScoreCanGet()
    {
        ResetScore();
        foreach (var ballScore in _ballScoreList)
        {
            ballScore.totalColorBallScore = UpdateScoreForColorBall(ballScore.listBallInScene);
        }

        CheckLoseByTotalScore();
    }

    private void CheckLoseByTotalScore()
    {
        foreach (var ballScore in _ballScoreList)
        {
            if (Application.isPlaying && GameManager.Instance.GameState == GameState.PlayingGame && ballScore.targetColorBallScore > ballScore.totalColorBallScore)
            {
                GameManager.Instance.OnLoseGame();
            }
        }
    }

    private void ResetScore()
    {
        foreach (var ballScore in _ballScoreList)
        {
            ballScore.totalColorBallScore = 0;
        }
    }

    public void UpdateColorBallScore(BallColorType ballColorType, int amount)
    {
        foreach (var ballScore in _ballScoreList)
        {
            if (ballScore.colorType == ballColorType)
            {
                ballScore.currentScore += amount;
                break;
            }
        }
        CheckWinByScore();
    }

    private int UpdateScoreForColorBall(List<ColorBall> listBalls)
    {
        int tempTotalScore = 0;
        foreach (var item in listBalls)
        {
            if (item.gameObject.activeSelf)
            {
                tempTotalScore += item.TotalScore;
            }
        }
        return tempTotalScore;
    }
    
    public override Task CheckingLoseLevel(float timeDelay)
    {
        // do nothing here
        return null;
    }

    protected override void UpdateTotalScoreCanGetOnDrawGizmos()
    {
        Setup();
    }

    public ColorBallScore GetColorBallScoreByType(BallColorType type)
    {
        foreach (var ballScore in _ballScoreList)
        {
            if (ballScore.colorType == type) return ballScore;
        }

        return null;
    }

#if UNITY_EDITOR
    [Button("Refresh score")]
    private void RefreshScore()
    {
        Setup();
    }
#endif
}

[Serializable]
public class ColorBallScore
{
    public BallColorType colorType;
    [ReadOnly] public int totalColorBallScore;
    [ReadOnly, HideInInspector] public int targetColorBallScore;
    [ReadOnly, HideInInspector] public List<ColorBall> listBallInScene;
    [ReadOnly, HideInInspector] public int currentScore;
}