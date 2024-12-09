using System;
using System.Collections.Generic;
using System.Linq;
using Pancake;
using UnityEngine;

public class ChallengeController : SingletonDontDestroy<ChallengeController>
{
    // [SerializeField] public List<LevelChallengePlayerData> levelChallenges;
    // [SerializeField] public MultipleChallengePlayer multipleChallengePlayer;
    //
    // protected override void Awake()
    // {
    //     base.Awake();
    //     Load();
    //     multipleChallengePlayer ??= new MultipleChallengePlayer();
    // }
    //
    // public LevelChallengePlayerData Get(string id)
    // {
    //     return levelChallenges?.FirstOrDefault(item => item.id == id);
    // }
    //
    // public LevelChallengePlayerData Add(string id)
    // {
    //     var data = new LevelChallengePlayerData() { id = id };
    //     if (levelChallenges.IsNullOrEmpty()) levelChallenges = new List<LevelChallengePlayerData>();
    //     levelChallenges.Add(data);
    //     return data;
    // }
    //
    // public void Save()
    // {
    //     Pancake.Data.Save("level-challenge", levelChallenges);
    //     Pancake.Data.Save("multiple-challenge", multipleChallengePlayer);
    // }
    //
    // private void Load()
    // {
    //     Pancake.Data.TryLoad("level-challenge", out levelChallenges);
    //     Pancake.Data.TryLoad("multiple-challenge", out multipleChallengePlayer);
    // }
    //
    // public bool IsShowNotification()
    // {
    //     if (levelChallenges.IsNullOrEmpty()) return false;
    //     if (levelChallenges.Any(data =>
    //             !data.isPlayed &&
    //             ConfigController.ChallengeConfig.LevelChallengeConfig.IsUnlockLevelChallenge(data.id)))
    //     {
    //         return true;
    //     }
    //
    //     if (multipleChallengePlayer != null)
    //     {
    //         if (multipleChallengePlayer.currentIndex < multipleChallengePlayer.multipleChallenges.Count &&
    //             ConfigController.ChallengeConfig.MultipleChallengeConfig.IsUnlock())
    //         {
    //             return true;
    //         }
    //     }
    //
    //     return false;
    // }
}

