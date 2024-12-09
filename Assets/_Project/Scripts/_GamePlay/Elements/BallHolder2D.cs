using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using MoreMountains.NiceVibrations;
using TMPro;
using UnityEngine;

public class BallHolder2D : BallHolder, IBomb
{
    public GameObject GreenTick;
    public Transform CanvasTransform;
    public float DistanceDown = .8f;

    private Vector3 currentPos;
    private Vector3 currentPosCanvas;
    private bool vibrateFlag;
    private Sequence sequence;
    protected virtual Level CurrentLevel => LevelController.Instance.CurrentLevel;
    private List<BallHolderSkin> _ballHolderSkinList;
    private int _bonusCoin;
    private bool _isBurned;

    protected override void Start()
    {
        base.Start();
        Setup();

        //LevelEvent.OnCurrentScoreChange += OnCurrentScoreChange;
        LevelEvent.OnTotalCoinChange += OnCurrentCoinChange;
        EventController.CurrentThemeChanged += SetupSkin;
    }

    private void Setup()
    {
        if (CurrentLevel.Type == LevelType.Multiple)
            _bonusCoin = ConfigController.ChallengeConfig.MultipleChallengeConfig.BonusMoneyPerBall;

        _ballHolderSkinList = GetComponentsInChildren<BallHolderSkin>(true).ToList();

        SetupSkin();
        currentPos = transform.position;
        currentPosCanvas = CanvasTransform.position;

        GreenTick.SetActive(false);

        Text.text = CurrentLevel.Type != LevelType.Multiple ? "0%" : $"{CurrentLevel.ScoreWin}";
    }

    protected virtual void SetupSkin()
    {
        foreach (var item in _ballHolderSkinList)
        {
            item.SetupSkin();
        }
    }

    public void Burn()
    {
        if (_isBurned) return;
        _isBurned = true;

        foreach (var item in _ballHolderSkinList)
        {
            item.Burn();
        }
    }

    private void OnDestroy()
    {
        //LevelEvent.OnCurrentScoreChange -= OnCurrentScoreChange;
        LevelEvent.OnTotalCoinChange -= OnCurrentCoinChange;
        EventController.CurrentThemeChanged -= SetupSkin;
    }

    //protected virtual void OnCurrentScoreChange()
    //{
    //    SetPercent(Mathf.Clamp((int)((float)CurrentLevel.CurrentScore / CurrentLevel.ScoreWin * 100), 0, 100));
    //}

    private void OnCurrentCoinChange()
    {
        if (!vibrateFlag)
        {
            vibrateFlag = true;
            MMVibrationManager.Haptic(HapticTypes.LightImpact);
            DOTween.Sequence().AppendInterval(.1f).AppendCallback(() => { vibrateFlag = false; });
        }

        SoundController.Instance.PlayFX(SoundType.TargetCoinSucceed);
        Text.text = $"+{CurrentLevel.TotalCoin}";
        sequence?.Kill();
        sequence = DOTween.Sequence().AppendInterval(1f).AppendCallback(() => { GameManager.Instance.OnWinGame(); });
    }

    protected void SetPercent(int numb)
    {
        if (IsBroken) return;
        Text.text = $"{numb}%";
        if (numb == 100)
        {
            GreenTick.SetActive(true);
            Text.gameObject.SetActive(false);
        }

        var nextPosition = new Vector3(currentPos.x, currentPos.y - DistanceDown * numb / 100f, currentPos.z);
        var nextPositionCanvas = new Vector3(currentPosCanvas.x, currentPosCanvas.y - DistanceDown * numb / 100f,
            currentPosCanvas.z);
        transform.DOMove(nextPosition, .05f);
        CanvasTransform.DOMove(nextPositionCanvas, .05f);
    }

    private void UpdateTextScore()
    {
        if (CurrentLevel.ScoreWin > 0)
        {
            Debug.Log("check 3");
            Text.text = $"{CurrentLevel.ScoreWin}";
        }
        else
        {
            GreenTick.SetActive(true);
            Text.gameObject.SetActive(false);
        }
    }

    private HolderCountElement holderCountElement;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (IsBroken) return;

        var coin = other.GetComponent<Coin>();
        if (coin != null)
        {
            if (!coin.GetArchiveState() && coin.GetActiveState())
            {
                CurrentLevel.TotalCoin += coin.CoinMultiplier;
            }
        }

        if (other.TryGetComponent<IHolder>(out var iHolder))
        {
            iHolder.InteractWithHolder();
        }

        if (other.CompareTag("Bomb"))
        {
            _isTriggerWithBomb = true;
        }

        if (other.TryGetComponent<HolderCountElement>(out holderCountElement))
        {
            HandleInteractWithColorBall(other, holderCountElement);
        }
    }

    protected virtual void HandleInteractWithColorBall(Collider other, HolderCountElement holderCountElements)
    {
        HandleIHolderCount(other);
    }

    private void HandleIHolderCount(Collider other)
    {
        if (!vibrateFlag)
        {
            vibrateFlag = true;
            MMVibrationManager.Haptic(HapticTypes.LightImpact);
            DOTween.Sequence().AppendInterval(.1f).AppendCallback(() => { vibrateFlag = false; });
        }
        Debug.Log("check 1");
        if (holderCountElement.GetActiveState())
        {
            if (_isBurned)
            {
                Debug.Log("check 2");
                SoundController.Instance.PlayFX(SoundType.Lava);
                VFXSpawnController.Instance.SpawnVFX(VisualEffectType.HitLava, other.transform.position);
                holderCountElement.SetActiveState(false);
            }
            else
            {
                var gameState = GameManager.Instance.GameState;
                if (gameState is GameState.LoseGame or GameState.WinGame) return;
                SoundController.Instance.PlayFX(SoundType.TargetBallSucceed);
            }

            if (CurrentLevel.Type != LevelType.Multiple)
            {
                if (!_isBurned && !holderCountElement.GetArchiveState())
                {
                    CurrentLevel.CheckingLoseLevel(timeDelay: 2);
                    CurrentLevel.CurrentScore += holderCountElement.totalScore;
                    holderCountElement.SetArchiveState(true);
                    Debug.Log("check 5");
                }
            }
            else
            {
                if (!holderCountElement.GetArchiveState())
                {
                    holderCountElement.SetArchiveState(true);
                    CurrentLevel.ScoreWin--;
                    CurrentLevel.UpdateTotalScoreCanGet();
                    Debug.Log("check 6");
                    UpdateTextScore();
                    if (CurrentLevel.ScoreWin <= 0)
                    {
                        if (CurrentLevel.ScoreWin < 0)
                        {
                            holderCountElement.gameObject.SetActive(false);
                            var otherPos = other.transform.position;
                            VFXSpawnController.Instance.SpawnVFX(VisualEffectType.BonusCoin,
                                new Vector3(otherPos.x, otherPos.y, -1f));
                            CurrentLevel.BonusCoin += _bonusCoin;
                        }

                        sequence = DOTween.Sequence().AppendCallback(() => { GameManager.Instance.OnWinGame(4f); });
                    }
                }
            }
        }
        else
        {
            SoundController.Instance.PlayFX(SoundType.TargetBallFailed);
            VFXSpawnController.Instance.SpawnVFX(VisualEffectType.Disappear,
                other.ClosestPoint(transform.position));
            holderCountElement.gameObject.SetActive(false);
        }
    }

    #region Interact with bomb

    private bool _isExploding = false;
    private bool _isTriggerWithBomb = false;

    public void ChangePhysicTo3D()
    {

    }

    public void AddForce(Collider hit, float Force)
    {
        if (_isExploding || !_isTriggerWithBomb) return;
        _isExploding = true;
        if (GameManager.Instance.GameState == GameState.PlayingGame)
        {
            trigger.SetActive(false);
            OnBombExploding();
            var rdDir = new Vector3(Random.Range(-1.25f, 1.25f), Random.Range(0, 1f), -2);
            var rid = transform.gameObject.GetComponent<Rigidbody>();
            rid.isKinematic = false;
            rid.AddForce(rdDir * (Force * .5f));
            GameManager.Instance.OnLoseGame();
        }
    }

    public void SpecialInteraction()
    {

    }

    #endregion
}