using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall : Ball
{
    [Header("Color Ball")]
    [SerializeField] private BallColorType ballColorType;

    [Header("Material")] [SerializeField] private Material redMat;
    [SerializeField] private Material yellowMat;
    [SerializeField] private Material blueMat;

    public BallColorType BallColorType => ballColorType;

    public override void InteractWithBallHolder(BallColorType ballColorTypes = BallColorType.YELLOW)
    {
        base.InteractWithBallHolder(ballColorTypes);
        var gameState = GameManager.Instance.GameState;
        if (gameState is GameState.LoseGame or GameState.WinGame) return;
        SoundController.Instance.PlayFX(SoundType.TargetBallSucceed);
    }

    protected override void SetupBallSkin()
    {
        // Do nothing here
    }

    protected override Color GetCurrentColor()
    {
        switch (ballColorType)
        {
            case BallColorType.RED:
                return Color.red;
            case BallColorType.BULE:
                return Color.green;
            case BallColorType.YELLOW:
                return Color.yellow;
            default:
                return Color.black;
        }
    }

    public override void ChangeBallColor(Material newMaterial)
    {
        // Do nothing here
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        // Change color of ball
        switch (ballColorType)
        {
            case BallColorType.RED:
                CurrentBallSkin.MeshRenderer.material = redMat;
                break;
            case BallColorType.BULE:
                CurrentBallSkin.MeshRenderer.material = blueMat;
                break;
            case BallColorType.YELLOW:
                CurrentBallSkin.MeshRenderer.material = yellowMat;
                break;
            default:
                break;
        }
    }
#endif
}

public enum BallColorType
{
    RED,
    YELLOW,
    BULE,
}