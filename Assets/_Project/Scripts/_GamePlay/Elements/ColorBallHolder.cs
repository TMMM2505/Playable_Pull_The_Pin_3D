using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorBallHolder : BallHolder2D, IBomb
{
    [Header("Color ball holder")] 
    [SerializeField] private BallColorType ballColorType;
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private Material redMat;
    [SerializeField] private Material yellowMat;
    [SerializeField] private Material blueMat;
    
    private LevelColorBall _levelColorBall;

    private void Awake()
    {
        _levelColorBall = GetComponentInParent<LevelColorBall>();
    }
    
    #if UNITY_EDITOR
    private void OnValidate()
    {
        switch (ballColorType)
        {
            case BallColorType.YELLOW:
                mesh.material = yellowMat;
                break;
            case BallColorType.RED:
                mesh.material = redMat;
                break;
            case BallColorType.BULE:
                mesh.material = blueMat;
                break;
        }
    }
#endif

    protected override void SetupSkin()
    {
        // Do nothing here
    }

    protected override void HandleInteractWithColorBall(Collider other, HolderCountElement holderCountElement)
    {
        var colorBall = holderCountElement.GetComponent<ColorBall>();
        if (colorBall != null)
        {
            if (ballColorType == colorBall.BallColorType)
            {
                if (!holderCountElement.GetArchiveState())
                {
                    _levelColorBall.UpdateColorBallScore(ballColorType, colorBall.TotalScore);
                    holderCountElement.SetArchiveState(true);
                    colorBall.InteractWithBallHolder(ballColorType);
                    OnCurrentScoreChange();
                }
            }
            else
            {
                SoundController.Instance.PlayFX(SoundType.Lava);
                VFXSpawnController.Instance.SpawnVFX(VisualEffectType.HitLava, colorBall.transform.position);
                holderCountElement.gameObject.SetActive(false);
            }
        }
    }

    protected void OnCurrentScoreChange()
    {
        if (CurrentLevel.Type == LevelType.Multiple)
        {
        }
        else
        {
            var ballScore = _levelColorBall.GetColorBallScoreByType(ballColorType);
            SetPercent(Mathf.Clamp((int)((float)(ballScore.currentScore) / ballScore.targetColorBallScore * 100), 0, 100));
        }
    }
}