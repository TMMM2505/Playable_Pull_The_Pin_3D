using System;
using System.Collections.Generic;
using Pancake;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BrokenBall : Ball
{
    [SerializeField] protected List<GeneratedBall> generatedBallList;
    [SerializeField] protected float breakForce = 300.0f;

    [SerializeField] protected CircleLayoutGroup circleLayoutGroup;

    public override int TotalScore => 16;

    protected override void SetupTrailSkin()
    {
        //Did nothing
    }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Sharp"))
        {
            Explode();
        }
    }

    public virtual void Explode()
    {
        foreach (var generatedBall in generatedBallList)
        {
            for (var i = 0; i < generatedBall.amount; i++)
            {
                var newBall = Instantiate(generatedBall.ballPrefab,
                    transform.position + (Vector3)Random.insideUnitCircle * .3f, Quaternion.identity,
                    LevelController.Instance.CurrentLevel.transform);
                newBall.IsActivated = IsActivated;
                newBall.Rigidbody2D.AddForce(breakForce * Random.insideUnitCircle);
            }
        }

        LevelController.Instance.CurrentLevel.BallBreakNumb++;
        SoundController.Instance.PlayFX(SoundType.BallBroken);
        VFXSpawnController.Instance.SpawnVFX(VisualEffectType.Ex, transform.position + Vector3.back,
            LevelController.Instance.CurrentLevel.transform, CurrentBallSkin.GetMaterialColor(),
            Vector3.one * 1.5f);
        
        LevelController.Instance.CurrentLevel.RefreshHolderCountElementList();
        gameObject.SetActive(false);
    }

    public void IncreaseRadiusRotateBrokenBall()
    {
        if (BallType == BallType.RotateBrokenBall && circleLayoutGroup != null)
        {
            circleLayoutGroup.AddRadius();
        }
    }
}

[Serializable]
public class GeneratedBall
{
    public Ball ballPrefab;
    public int amount;
}