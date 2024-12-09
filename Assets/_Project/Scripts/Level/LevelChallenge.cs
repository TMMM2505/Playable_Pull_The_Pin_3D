using DG.Tweening;
using UnityEngine;

public class LevelChallenge : Level
{
    [Header("Level Challenge Config")] public int numberMove = 1;
    public float timeWaitResult = 5f;
    
    public override LevelType Type => LevelType.Challenge;
    public CameraChallenge CameraChallenge => GetComponentInChildren<CameraChallenge>();
    protected override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
        CameraChallenge.OnStartLevel();

    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}