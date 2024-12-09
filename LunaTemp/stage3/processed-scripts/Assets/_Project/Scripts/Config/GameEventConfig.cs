using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEventConfig", menuName = "ScriptableObject/GameEventConfig")]
public class GameEventConfig : ScriptableObject
{
    public List<GameEventData> gameEvents = new List<GameEventData>();

    public GameEventData GetGameEventData(GameEventType type)
    {
        return gameEvents.Find(item => item.gameEventType == type);
    }
}

[Serializable]
public class GameEventData
{
    public GameEventType gameEventType;
    public GameEventTime timeEnd;

    public bool IsExpired()
    {
        DateTime expiredTime = new DateTime(timeEnd.year, timeEnd.month, timeEnd.day);
        return (DateTime.Now - expiredTime).TotalSeconds >= 0;
    }

    public TimeSpan GetTimeLeft()
    {
        DateTime expiredTime = new DateTime(timeEnd.year, timeEnd.month, timeEnd.day);
        if (DateTime.Now > expiredTime) return TimeSpan.Zero;
        return expiredTime - DateTime.Now;
    }
}

[Serializable]
public class GameEventTime
{
    public int day;
    public int month;
    public int year;
}

public enum GameEventType
{
    Halloween2023,
    Noel2023,
}