using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Pancake;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(fileName = "LevelChallengeConfig", menuName = "ScriptableObject/LevelChallengeConfig")]
public class ChallengeConfig : ScriptableObject
{
    public LevelChallengeConfig LevelChallengeConfig;
    public MultipleChallengeConfig MultipleChallengeConfig;

    public int LevelToUnlock => LevelChallengeConfig.Datas[0].LevelUnlock;
    //public bool IsShowUnlockPopup => Data.FirstUnlockChallenge && Data.CurrentLevel >= LevelToUnlock;
    public MultipleChallengePlayer MultipleChallengePlayer => _multipleChallengePlayer;

    private List<LevelChallengePlayerData> _levelChallenges = new System.Collections.Generic.List<LevelChallengePlayerData>();
    private MultipleChallengePlayer _multipleChallengePlayer;
    private const string NormalChallengeKey = "level-challenge";
    private const string MultipleChallengeKey = "multiple-challenge";

    public void Initialize()
    {
        //if (Data.CurrentLevel > LevelToUnlock) Data.FirstUnlockChallenge = false;

        Pancake.Data.TryLoad(NormalChallengeKey, out _levelChallenges);
        Pancake.Data.TryLoad(MultipleChallengeKey, out _multipleChallengePlayer);
        _multipleChallengePlayer = _multipleChallengePlayer ?? new MultipleChallengePlayer();
    }

    public LevelChallengePlayerData Get(string id)
    {
        return _levelChallenges?.FirstOrDefault(item => item.id == id);
    }

    public LevelChallengePlayerData Add(string id)
    {
        var data = new LevelChallengePlayerData { id = id };
        if (_levelChallenges.IsNullOrEmpty()) _levelChallenges = new List<LevelChallengePlayerData>();
        _levelChallenges.Add(data);
        return data;
    }

    public void SaveData()
    {
        Pancake.Data.Save(NormalChallengeKey, _levelChallenges);
        Pancake.Data.Save(MultipleChallengeKey, _multipleChallengePlayer);
    }

    public bool IsShowNotification()
    {
        if (_levelChallenges.IsNullOrEmpty()) return false;
        if (_levelChallenges.Any(data =>
                !data.isPlayed &&
                ConfigController.ChallengeConfig.LevelChallengeConfig.IsUnlockLevelChallenge(data.id)))
        {
            return true;
        }

        if (_multipleChallengePlayer != null)
        {
            if (_multipleChallengePlayer.currentIndex < _multipleChallengePlayer.multipleChallenges.Count &&
                ConfigController.ChallengeConfig.MultipleChallengeConfig.IsUnlock())
            {
                return true;
            }
        }

        return false;
    }

    #region Backup_data

    public string GetChallengeData()
    {
        SaveData();

        Pancake.Data.TryLoad(NormalChallengeKey, out List<LevelChallengePlayerData> normalChallengeData);
        Pancake.Data.TryLoad(MultipleChallengeKey, out MultipleChallengePlayer multipleChallengeData);

        var dataDict = new Dictionary<string, string>
        {
            [NormalChallengeKey] = JsonConvert.SerializeObject(normalChallengeData),
            [MultipleChallengeKey] = JsonConvert.SerializeObject(multipleChallengeData)
        };

        return JsonConvert.SerializeObject(dataDict);
    }

    public void SetChallengeData(string dataDictStr)
    {
        var dataDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(dataDictStr);

        _levelChallenges = JsonConvert.DeserializeObject<List<LevelChallengePlayerData>>(dataDict[NormalChallengeKey]);
        _multipleChallengePlayer =
            JsonConvert.DeserializeObject<MultipleChallengePlayer>(dataDict[MultipleChallengeKey]);
       
        SaveData();
    }

    #endregion
}

[Serializable]
public class LevelChallengeConfig
{
    public List<LevelChallengeConfigModel> Datas;

    public LevelChallengeConfigModel Get(string id)
    {
        return Datas.Find(item => item.Id == id);
    }

    public bool IsUnlockLevelChallenge(LevelChallengeConfigModel model)
    {
        return Data.CurrentLevel >= model.LevelUnlock;
    }

    public bool IsUnlockLevelChallenge(string id)
    {
        var model = Get(id);
        return model != null && Data.CurrentLevel >= model.LevelUnlock;
    }
}

[Serializable]
public class LevelChallengeConfigModel
{
    public string Id;
    public int LevelUnlock;
    public int CoinReward;

    public LevelChallenge LoadLevelChallenge()
    {
        var challengeGo = Resources.Load($"LevelChallenges/{Id}") as GameObject;
        if (challengeGo != null)
        {
            if (challengeGo.TryGetComponent<LevelChallenge>(out var levelChallenge))
            {
                return levelChallenge;
            }

            Debug.LogError($"{Id} does not have a LevelChallenge Component");
        }

        Debug.LogError($"There is no {Id}");
        return null;
    }
}


[Serializable]
public class MultipleChallengeConfig
{
    public int GiftNumber = 6;
    public int GiftClaimReward = 1000;
    public int CoinReward;
    public int BonusMoneyPerBall;
    public int FirstLevelUnlock;
    public List<MultipleChallengeConfigModel> Datas;

    public MultipleChallengeConfigModel Get(string id)
    {
        return Datas.Find(item => item.Id == id);
    }

    public bool IsUnlock()
    {
        return Data.CurrentLevel >= FirstLevelUnlock;
    }
}

[Serializable]
public class MultipleChallengeConfigModel
{
    public string Id;

    public MultipleChallenge LoadMultipleChallenge()
    {
        var multipleGo = Resources.Load($"MultipleChallenges/{Id}") as GameObject;
        if (multipleGo != null)
        {
            if (multipleGo.TryGetComponent<MultipleChallenge>(out var multipleChallenge))
            {
                return multipleChallenge;
            }

            Debug.LogError($"{Id} does not have a MultipleChallenge Component");
        }

        Debug.LogError($"There is no {Id}");
        return null;
    }
}

[Serializable]
public class LevelChallengePlayerData
{
    public string id;
    public bool isPlayed;
    public bool isWined;
    public int moveLeftNumb;
}

[Serializable]
public class MultipleChallengePlayer
{
    [SerializeField] [ReadOnly] public int currentIndex;
    [SerializeField] [ReadOnly] public int giftNumb;
    [SerializeField] public List<MultipleChallengePlayerData> multipleChallenges;

    public MultipleChallengePlayer()
    {
        currentIndex = 0;
        giftNumb = 0;
        multipleChallenges = new List<MultipleChallengePlayerData>();
    }

    public MultipleChallengePlayerData Get(string id)
    {
        return multipleChallenges?.Find(item => item.id == id);
    }

    public MultipleChallengePlayerData Add(string id)
    {
        var data = new MultipleChallengePlayerData() { id = id };
        if (multipleChallenges.IsNullOrEmpty()) multipleChallenges = new List<MultipleChallengePlayerData>();
        multipleChallenges.Add(data);
        return data;
    }
}

[Serializable]
public class MultipleChallengePlayerData
{
    public string id;
}