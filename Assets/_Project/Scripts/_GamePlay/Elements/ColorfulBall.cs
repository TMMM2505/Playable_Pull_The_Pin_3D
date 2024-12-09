using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class ColorfulBall : Ball
{
    [SerializeField] private List<MeshRenderer> cornerBallList;
    [SerializeField] private MeshRenderer mainBall;
    [SerializeField] private float sizeDecrease;
    [SerializeField] private float disappearSize;
    [SerializeField] protected List<GeneratedBall> generatedBallList;
    [SerializeField] private float explodeForce;

    private List<Ball> _interactedList;
    private Vector3 _defScale;
    private Vector3 _currentScale;
    private Material _ballMaterial;
    private Color _ballColor;
    private bool _isExploding;

    public override int TotalScore
    {
        get
        {
            var score = generatedBallList.Sum(generatedBall =>
                generatedBall.amount * generatedBall.ballPrefab.TotalScore);

            return score;
        }
    }

    protected override void SetupBallSkin()
    {
        _interactedList = new List<Ball>();
        _currentScale = _defScale = transform.localScale;

        _ballMaterial = mainBall.material;
        _ballColor = _ballMaterial.color;
        foreach (var cornerBall in cornerBallList)
        {
            cornerBall.material = _ballMaterial;
        }
    }

    public override void OnCollisionStay2D(Collision2D other)
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_isExploding) return;

        var otherGameObject = other.gameObject;
        if (otherGameObject.CompareTag("Ball") && otherGameObject.TryGetComponent<Ball>(out var ball))
        {
            if (_interactedList.Contains(ball)) return;
            _interactedList.Add(ball);

            if (ball.IsActivated)
            {
                if (ball.CurrentBallSkin.GetMaterialColor() == _ballColor)
                {
                    DOTween.Kill(this);
                    var newScale = _currentScale - Vector3.one * sizeDecrease;

                    if (newScale.x < disappearSize)
                    {
                        _isExploding = true;
                        transform.DOScale(_defScale, 0.7f).SetEase(Ease.InBack).SetTarget(this)
                            .OnComplete(() =>
                            {
                                foreach (var generatedBall in generatedBallList)
                                {
                                    for (var i = 0; i < generatedBall.amount; i++)
                                    {
                                        var newBall = Instantiate(generatedBall.ballPrefab,
                                            transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * .3f, Quaternion.identity,
                                            LevelController.Instance.CurrentLevel.transform);
                                        newBall.ChangeColorToNumberedBall(_ballMaterial, true);
                                        newBall.Rigidbody2D.AddForce(explodeForce * UnityEngine.Random.insideUnitCircle);
                                    }
                                }

                                SoundController.Instance.PlayFX(SoundType.BallBroken);
                                VFXSpawnController.Instance.SpawnVFX(VisualEffectType.Ex,
                                    transform.position + Vector3.back, LevelController.Instance.CurrentLevel.transform,
                                    CurrentBallSkin.GetMaterialColor(),
                                    Vector3.one * 1.5f);

                                Destroy(gameObject);
                            });
                        return;
                    }

                    transform.localScale = _currentScale;
                    transform.DOScale(newScale, 0.7f).SetEase(Ease.InBack).SetTarget(this);
                    SoundController.Instance.PlayFX(SoundType.ButtonClick);
                    _currentScale = newScale;
                }
            }
            else
            {
                ball.ChangeBallColor(_ballMaterial);

                SoundController.Instance.PlayFX(SoundType.Stack);
                VFXSpawnController.Instance.SpawnVFX(VisualEffectType.Ex, ball.transform.position,
                    LevelController.Instance.CurrentLevel.transform, _ballColor);
            }
        }
    }
}