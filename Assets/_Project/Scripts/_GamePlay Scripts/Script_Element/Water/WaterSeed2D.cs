using System;
using DG.Tweening;
using UnityEngine;

public class WaterSeed2D : WaterSeed, IDestroyByLaser
{
    [ReadOnly] public WaterState waterState = WaterState.Water;
    public GameObject water;
    public GameObject rock;
    public GameObject triggerWater;

    public void Start()
    {
        SetupState(WaterState.Water);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.CompareTag("Rock") || other.CompareTag("LavaSeed")) &&
            waterState == WaterState.Water)
        {
            DOTween.Sequence().AppendInterval(.05f).AppendCallback(() => SetupState(WaterState.Rock));
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if ((other.gameObject.CompareTag("Rock") || other.gameObject.CompareTag("LavaSeed")) &&
            waterState == WaterState.Water)
        {
            DOTween.Sequence().AppendInterval(.05f).AppendCallback(() => SetupState(WaterState.Rock));
        }
    }

    private void SetupState(WaterState state)
    {
        if (waterState == state) return;
        waterState = state;

        switch (waterState)
        {
            case WaterState.Water:
                water.SetActive(true);
                rock.SetActive(false);
                tag = "Water";
                name = "Water";
                break;
            case WaterState.Rock:
                VFXSpawnController.Instance.SpawnVFX(VisualEffectType.HitLava, transform.position);
                water.SetActive(false);
                rock.SetActive(true);
                tag = "Rock";
                name = "Rock";
                triggerWater.SetActive(false);
                break;
        }
    }

    public void InteractWithLaser()
    {
        if(CompareTag("Rock")) return;
        VFXSpawnController.Instance.SpawnVFX(VisualEffectType.HitLaser, transform.position, useTimeDelay: true, timeDelay: 25);
        gameObject.SetActive(false);
    }
}

public enum WaterState
{
    Water,
    Rock,
    WaterDirty
}