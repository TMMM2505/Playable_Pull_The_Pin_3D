using System.Collections.Generic;
using DG.Tweening;
using MoreMountains.NiceVibrations;
using UnityEngine;

public class PullingPin : Pin
{
    [Header("--- PULLING PIN ---")] [Range(0.1f, 100f)]
    public float distanceMove = 20f;

    [Range(0.1f, 3f)] public float timeMove = 1f;
    [ReadOnly] public List<Ball> balls;

    public override void ActivePin()
    {
        base.ActivePin();
        if (!IsPullAble)
        {
            return;
        }

        if (pinState == PinState.Moving || GameManager.Instance.GameState != GameState.PlayingGame) return;

        pinState = PinState.Moving;
        LevelEvent.OnPullPin?.Invoke();

        foreach (var item in balls)
        {
            item.Rigidbody2D.isKinematic = false;
            item.KeyPin = null;
        }

        LevelController.Instance.CurrentLevel.PinDragNumb++;
        MMVibrationManager.Haptic(HapticTypes.LightImpact);
        SoundController.Instance.PlayFX(SoundType.PinNormal);
        transform.DOMove(transform.position + transform.right * distanceMove, timeMove).OnKill(() => transform.DOKill())
            .OnComplete(() =>
            {
                pinState = PinState.Idle;
                gameObject.SetActive(false);
            });
        DisableColliders();
    }
}