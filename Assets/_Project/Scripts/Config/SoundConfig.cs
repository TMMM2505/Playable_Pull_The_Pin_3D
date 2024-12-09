using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName ="SoundConfig",menuName = "ScriptableObject/SoundConfig")]
public class SoundConfig : ScriptableObject
{
    public List<SoundData> SoundDatas;

    public void UpdateSoundDatas()
    {
        for (int i = 0; i < Enum.GetNames(typeof(SoundType)).Length; i++)
        {
            SoundData soundData = new SoundData();
            soundData.SoundType = (SoundType) i;
            if (IsItemExistedBySoundType(soundData.SoundType)) continue;
            SoundDatas.Add(soundData);
        }

        SoundDatas = SoundDatas.GroupBy(elem => elem.SoundType).Select(group => group.First()).ToList();
    }

    private bool IsItemExistedBySoundType(SoundType soundType)
    {
        foreach (SoundData item in SoundDatas)
        {
            if (item.SoundType == soundType)
            {
                return true;
            }
        }

        return false;
    }
    
}

[Serializable]
public class SoundData
{
    public SoundType SoundType;
    public AudioClip Clip;
}

public enum SoundType
{
    Background,
    Win,
    Lose,
    ButtonClick,
    CoinMove,
    Bomb,
    PinNormal,
    PurchaseComplete,
    Stack,
    TargetBallSucceed,
    TargetBallFailed,
    TargetSucceed,
    FireworkFX,
    TargetCoinSucceed,
    NpcThink1,
    NpcThink2Ver1,
    NpcThink2Ver2,
    NpcThink2Ver3,
    NpcWin,
    NpcLose,
    BallBroken,
    NpcEncourage,
    TriggerGoodGate,
    TriggerBadGate,
    Lava,
    InPortal,
    OutPortal,
    NumberedBridge,
    Rope,
    CardDraw,
    CardInPack,
    ChestOpen,
    EventWin,
    EventLose,
    EatStar,
    Crowd,
    BrokenPig
}
