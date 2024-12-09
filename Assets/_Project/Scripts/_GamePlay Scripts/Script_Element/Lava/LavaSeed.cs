using System;
using DG.Tweening;
using Pancake;
using UnityEngine;

public class LavaSeed : Element, IHolder
{
    protected void SoundLava()
    {
        SoundController.Instance.PlayFX(SoundType.Lava);
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BallHolder")) ChangeTo3DPhysics();
        if(!gameObject.CompareTag("LavaSeed")) return;
        
        base.OnTriggerEnter2D(other);
        var iLava = other.GetComponent<Ilava>();
        if(iLava != null) iLava.InteractWithLava();
        
        if (other.CompareTag("Chest"))
        {
            other.gameObject.SetActive(false);
            VFXSpawnController.Instance.SpawnVFX(VisualEffectType.HitLava, other.transform.position);
            SoundLava();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BallHolder") && gameObject.CompareTag("LavaSeed") &&
            other.TryGetComponent<BallHolder2D>(out var ballHolder2D))
        {
            ballHolder2D.Burn();
            SoundLava();
            GameManager.Instance.OnLoseGame();
        }
    }

    public void InteractWithHolder()
    {
        SoundController.Instance.PlayFX(SoundType.Lava);
        VFXSpawnController.Instance.SpawnVFX(VisualEffectType.HitLava, transform.position);
        gameObject.SetActive(false);
    }
}