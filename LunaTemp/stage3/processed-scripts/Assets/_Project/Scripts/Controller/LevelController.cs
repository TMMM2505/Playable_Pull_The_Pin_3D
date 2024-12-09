using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelController : Singleton<LevelController>
{
    public IconDataConfig iconDataConfig;
    public LevelType LevelType;
    public Level CurrentLevel;
    public LevelLoadingType LevelLoadingType;

    private readonly Dictionary<string, Level> _loadedLevels = new Dictionary<string, Level>();

    public int LevelCount => _loadedLevels.Count;

    public void PrepareNormalLevel(Level level)
    {
        GenerateNormalLevel(level);
    }

    public void PrepareChallengeLevel(LevelChallenge levelChallenge)
    {
        GenerateChallengeLevel(levelChallenge);
    }

    public void PrepareChallengeMultiple(MultipleChallenge multipleChallenge)
    {
        GenerateChallengeMultiple(multipleChallenge);
    }

    private void GenerateNormalLevel(Level level)
    {
        //LevelType = LevelType.Normal;
        //var indexLevel = Data.CurrentLevel;
        //if (CurrentLevel != null)
        //{
        //    DestroyImmediate(CurrentLevel.gameObject);
        //}

        //if (indexLevel > ConfigController.Game.maxLevel)
        //{
        //    LevelLoadingType = LevelLoadingType.LoopLevel;
        //    indexLevel =
        //        (indexLevel - ConfigController.Game.startLoopLevel) %
        //        (ConfigController.Game.maxLevel - ConfigController.Game.startLoopLevel + 1) +
        //        ConfigController.Game.startLoopLevel;
        //}
        //else
        //{
        //    LevelLoadingType = LevelLoadingType.NormalLevel;
        //    indexLevel = (indexLevel - 1) % ConfigController.Game.maxLevel + 1;
        //}

        //var level = GetLevelByIndex(indexLevel);
        if (CurrentLevel != null)
        {
            DestroyImmediate(CurrentLevel.gameObject);
        }
        CurrentLevel = Instantiate(level);
    }

    private void GenerateChallengeLevel(LevelChallenge levelChallenge)
    {
        LevelType = LevelType.Challenge;
        if (CurrentLevel != null)
        {
            DestroyImmediate(CurrentLevel.gameObject);
        }

        CurrentLevel = Instantiate(levelChallenge);
    }

    private void GenerateChallengeMultiple(MultipleChallenge multipleChallenge)
    {
        LevelType = LevelType.Multiple;
        if (CurrentLevel != null)
        {
            DestroyImmediate(CurrentLevel.gameObject);
        }

        CurrentLevel = Instantiate(multipleChallenge);
    }

    private Level GetLevelByIndex(int indexLevel)
    {
        var suffix = Data.UseLevelABTesting == 0 ? "A" : "B";
        
        if (_loadedLevels.TryGetValue($"{indexLevel}", out var cachedLevelDefault))
        {
            return cachedLevelDefault;
        }
        
        if (_loadedLevels.TryGetValue($"{indexLevel}{suffix}", out var cachedLevelAB))
        {
            return cachedLevelAB;
        }
        
        var levelGo = Resources.Load($"Levels/Level {indexLevel}") as GameObject;
        
        if (levelGo != null)
        {
            if (levelGo.TryGetComponent<Level>(out var levelComponent))
            {
                _loadedLevels[$"{indexLevel}"] = levelComponent;
                return levelComponent;
            }
        
            Debug.LogError($"Level {indexLevel}{suffix} does not have a Level Component");
        }
        else
        {
            levelGo = Resources.Load($"Levels{suffix}/Level {indexLevel}{suffix}") as GameObject;
            if (levelGo != null)
            {
                if (levelGo.TryGetComponent<Level>(out var levelComponent))
                {
                    _loadedLevels[$"{indexLevel}{suffix}"] = levelComponent;
                    return levelComponent;
                }
        
                Debug.LogError($"Level {indexLevel}{suffix} does not have a Level Component");
            }
            else
            {
                Debug.LogError("Level AB Not Found");
            }
        }
        
        Debug.LogError("Level Default Not Found");
        
        return null;
    }
}

public enum LevelLoadingType
{
    NormalLevel,
    LoopLevel,
}


public static class LevelEvent
{
    public static LevelChallengeItem CurrentLevelChallengeItem;
    public static MultipleChallengeItem CurrentMultipleChallengeItem;

    public static Action OnCurrentScoreChange;
    public static Action OnTotalCoinChange;
    public static Action OnWin;
    public static Action OnLose;
    public static Action OnPullPin;
    public static Action OnStartLevel;

    public static Action OnStackBall;

    // Level challenge
    public static Action OnMoveLeftChange;
    public static Action OnWinChallenge;

    public static Action OnLoseChallenge;

    // Multiple challenge
    public static Action OnBallActive;
    public static Action OnLoseMultiple;
    public static Action OnWinMultiple;

    public static Action OnMultipleBallChange;

    // Event
    public static Action OnGetHalloweenItem;
}

public enum LevelType
{
    Normal,
    Challenge,
    Multiple,
    ColorBall
}

public enum LevelNotificationType
{
    None,
    SmallIcon,
    BigIcon,
}