using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using DG.Tweening;

public class Ball : HolderCountElement
{
    public BallType BallType;

    public BallSkin CurrentBallSkin;
    public PullingPin KeyPin;
    public BallSkin DefaultSkin;
    public Transform SkinHolder;
    [SerializeField] private Transform trailHolder;

    [SerializeField][ReadOnly] private bool isHitRotateBrokenBall;
    [SerializeField][ReadOnly] private bool isNumberedBallChild;
    [SerializeField][ReadOnly] private bool isUnableToChangeColor;
    [SerializeField][ReadOnly] private NumberedBridge isBridged;

    private Material _newMaterial;

    public bool IsNumberedChild => isNumberedBallChild;

    public float BallRadius =>
        DefaultSkin.GetComponent<MeshFilter>().sharedMesh.bounds.extents.x * transform.localScale.x;

    public virtual int TotalScore => (int)BallType + 1;

    public virtual bool IsActivated
    {
        get => isActivated;
        set
        {
            isActivated = value;
            if (isActivated)
            {
                if (CurrentBallSkin) CurrentBallSkin.Activating();
            }
            else
            {
                if (CurrentBallSkin) CurrentBallSkin.Deactivating();
            }
        }
    }

    protected override void Initialize()
    {
        base.Initialize();

        totalScore = TotalScore;
        if (IsActivated)
        {
            isUnableToChangeColor = true;
        }
    }

    protected void OnEnable()
    {
        EventController.CurrentBallChanged += SetupBallSkin;
        EventController.CurrentTrailChanged += SetupTrailSkin;
    }

    protected virtual void OnDisable()
    {
        EventController.CurrentBallChanged -= SetupBallSkin;
        EventController.CurrentTrailChanged -= SetupTrailSkin;

        if (GameManager.Instance == null || GameManager.Instance.GameState != GameState.PlayingGame) return;

        if (LevelController.Instance == null) return;
        var currentLevel = LevelController.Instance.CurrentLevel;
        var levelColorBall = currentLevel.GetComponent<LevelColorBall>();
        if (currentLevel == null && levelColorBall != null) return;

        if (levelColorBall != null)
        {
            levelColorBall.UpdateTotalScoreCanGet();
            return;
        }
        currentLevel.UpdateTotalScoreCanGet();

        if (currentLevel.Type == LevelType.Multiple)
        {
            LevelEvent.OnMultipleBallChange?.Invoke();
        }
    }

    private void Start()
    {
        if (KeyPin)
        {
            Rigidbody2D.isKinematic = true;
            Rigidbody2D.velocity = Vector2.zero;
            KeyPin.balls.Add(this);
        }

        SetupBallSkin();
        SetupTrailSkin();
    }

    protected virtual void SetupTrailSkin()
    {
        trailHolder.Clear();

        if (Data.CurrentTrailSkinId == 0) return;

        foreach (var trailData in ConfigController.ItemConfig.trailDataList.Where(trailData =>
                     Data.CurrentTrailSkinId == trailData.Id))
        {
            var trail = Instantiate(trailData.trailPrefab, trailHolder);
            var trailRenderer = trail.GetComponentInChildren<TrailRenderer>();
            if (trailRenderer) trailRenderer.widthMultiplier = trailData.trailSize * transform.localScale.x;
            trail.transform.localPosition = Vector3.zero;
        }
    }

    protected virtual void SetupBallSkin()
    {
        if (_newMaterial != null) return;

        SkinHolder.Clear();
        foreach (var ballData in ConfigController.ItemConfig.ballDataList)
        {
            if (Data.CurrentBallSkinId == 1)
            {
                CurrentBallSkin = DefaultSkin;
                DefaultSkin.gameObject.SetActive(true);
                DefaultSkin.Setup(this, 1);
            }
            else if (Data.CurrentBallSkinId == ballData.Id)
            {
                DefaultSkin.gameObject.SetActive(false);
                CurrentBallSkin = Instantiate(ballData.ballSkin, SkinHolder);
                CurrentBallSkin.gameObject.SetActive(true);
                CurrentBallSkin.Setup(this, ballData.Id);
            }
        }

        if (isUnableToChangeColor && Data.CurrentBallSkinId == 1)
        {
        }
        else
        {
            IsActivated = IsActivated;
        }
    }

    protected void ActiveThisBall()
    {
        var pos = transform.position;
        var fxPos = new Vector3(pos.x, pos.y, -.5f);
        DOTween.Sequence().AppendCallback(() =>
        {
            SoundController.Instance.PlayFX(SoundType.Stack);
            IsActivated = true;
            VFXSpawnController.Instance.SpawnVFX(VisualEffectType.Ex, fxPos, GetCurrentColor());
        });
    }

    protected virtual Color GetCurrentColor()
    {
        return CurrentBallSkin.GetMaterialColor();
    }

    public void OnCollisionStay(Collision other)
    {
        if (IsActivated) return;
        if (other.gameObject.CompareTag("Ball") &&
            other.gameObject.TryGetComponent<Ball>(out var ball) && ball.IsActivated)
        {
            ActiveThisBall();
        }
    }

    public virtual void OnCollisionStay2D(Collision2D other)
    {
        if (!IsActivated)
        {
            if (other.gameObject.CompareTag("Ball") &&
                other.gameObject.TryGetComponent<Ball>(out var ball) && ball.IsActivated)
            {
                LevelEvent.OnStackBall?.Invoke();
                SoundController.Instance.PlayFX(SoundType.Stack);

                ActiveThisBall();
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Bridge") &&
                other.gameObject.TryGetComponent<BridgeElement>(out var bridgeElement))
            {
                isBridged = bridgeElement.Bridge;
                isBridged.BallInteract(this);
            }
            else if (other.gameObject.CompareTag("Ball") && other.gameObject.TryGetComponent<Ball>(out var ball) &&
                     ball.isBridged != null)
            {
                isBridged = ball.isBridged;
                isBridged.BallInteract(this);
            }

            if (!isHitRotateBrokenBall)
            {
                if (other.gameObject.CompareTag("Ball") &&
                    other.gameObject.TryGetComponent<BrokenBall>(out var brokenBall) &&
                    brokenBall.BallType == BallType.RotateBrokenBall && BallType != BallType.RotateBrokenBall)
                {
                    brokenBall.IncreaseRadiusRotateBrokenBall();
                    isHitRotateBrokenBall = true;
                }
            }
        }
    }

    // protected void OnDestroy()
    // {
    //     var currentLevel = LevelController.Instance.CurrentLevel;
    //     currentLevel.UpdateTotalScoreCanGet();
    //
    //     if (currentLevel.Type == LevelType.Multiple)
    //     {
    //         LevelEvent.OnMultipleBallChange?.Invoke();
    //     }
    // }

    public override void BeingPulledInPortal(InPortal inPortal, float moveDuration, Action teleportCallback)
    {
        base.BeingPulledInPortal(inPortal, moveDuration, teleportCallback);
        DOTween.Sequence().AppendInterval(moveDuration).AppendCallback(() => trailHolder.gameObject.SetActive(false));
    }

    public override void BackToDefault(float moveDuration)
    {
        base.BackToDefault(moveDuration);
        DOTween.Sequence().AppendInterval(moveDuration).AppendCallback(() => trailHolder.gameObject.SetActive(true));
    }

    public void ChangeColorToNumberedBall(Material numberedBallMaterial, bool isGenerated)
    {
        isNumberedBallChild = isGenerated;
        ChangeBallColor(numberedBallMaterial);
    }

    public virtual void ChangeBallColor(Material newMaterial)
    {
        _newMaterial = newMaterial;
        CurrentBallSkin.ChangeActiveMaterial(_newMaterial);
        IsActivated = true;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BallHolder"))
        {
            ChangeTo3DPhysics();
        }
    }

    #region overide for HolderCountElement

    public override void SetActiveState(bool active)
    {
        IsActivated = active;
    }

    #endregion
}

public enum BallType
{
    Small,
    Medium,
    Big,
    GiantBall,
    PlusBall,
    RotateBrokenBall
}