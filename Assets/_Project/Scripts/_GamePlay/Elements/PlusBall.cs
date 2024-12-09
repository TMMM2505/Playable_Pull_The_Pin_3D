using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
//using PlayFab.MultiplayerModels;
using TMPro;
using UnityEngine;

public class PlusBall : Ball
{
    [SerializeField, Range(0.0f, 1.0f)] private float appearRange;
    [SerializeField] private int plusNumber;
    [SerializeField] private TextMeshPro plusText;
    [SerializeField] private Transform textParent;
    [SerializeField] private Ball smallBall;

    private Material _ballMaterial;
    private Color _ballColor;
    private List<Ball> _interactedBallList;
    private bool _isRandom;

    public override int TotalScore => 20;

    protected override void Initialize()
    {
        base.Initialize();

        _interactedBallList = new List<Ball>();
        plusText.SetText($"+{plusNumber}");

        if (appearRange < BallRadius + smallBall.BallRadius)
        {
            _isRandom = false;
            appearRange = BallRadius + smallBall.BallRadius;
        }
        else
        {
            _isRandom = true;
        }
    }

    protected override void SetupBallSkin()
    {
        _ballMaterial = DefaultSkin.MeshRenderer.material;
        _ballColor = _ballMaterial.color;
        DefaultSkin.ChangeActiveMaterial(_ballMaterial);
        if (Camera.main != null) textParent.LookAt(Camera.main.transform.position);
    }

    public override void OnCollisionStay2D(Collision2D other)
    {
        if (plusNumber != 0) return;
        base.OnCollisionStay2D(other);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (plusNumber == 0) return;

        var otherGameObject = other.gameObject;
        if (otherGameObject.CompareTag("Ball") && otherGameObject.TryGetComponent<Ball>(out var ball))
        {
            if (ball.IsNumberedChild || _interactedBallList.Contains(ball)) return;

            _interactedBallList.Add(ball);

            var ballPos = ball.transform.position;
            var fxPos = new Vector3(ballPos.x, ballPos.y, -0.5f);

            if (ball.IsActivated)
            {
                if (ball.CurrentBallSkin.GetMaterialColor() == _ballColor)
                {
                    for (var i = 0; i < plusNumber; i++)
                    {
                        DOTween.Sequence().AppendInterval(i * 0.2f).AppendCallback(() =>
                        {
                            var randomPosXY = _isRandom
                                ? Random.insideUnitCircle * Random.Range(BallRadius + smallBall.BallRadius, appearRange)
                                : Random.insideUnitCircle * appearRange;
                            var newBall = Instantiate(smallBall,
                                transform.position + (Vector3)randomPosXY, Quaternion.identity,
                                LevelController.Instance.CurrentLevel.transform);
                            newBall.ChangeColorToNumberedBall(_ballMaterial, true);
                            // newBall.Rigidbody2D.AddForce(AppearForce * Random.insideUnitCircle);

                            var newBallPos = newBall.transform.position;
                            fxPos = new Vector3(newBallPos.x, newBallPos.y, -0.5f);

                            SoundController.Instance.PlayFX(SoundType.Stack);
                            VFXSpawnController.Instance.SpawnVFX(VisualEffectType.Ex, fxPos,
                                LevelController.Instance.CurrentLevel.transform, _ballMaterial.color);
                        });
                    }
                }
            }
            else
            {
                ball.ChangeColorToNumberedBall(_ballMaterial, false);

                SoundController.Instance.PlayFX(SoundType.Stack);
                VFXSpawnController.Instance.SpawnVFX(VisualEffectType.Ex, fxPos,
                    LevelController.Instance.CurrentLevel.transform, _ballMaterial.color);
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
        Gizmos.DrawSphere(transform.position, appearRange);
    }
#endif
}