using System;
using DG.Tweening;
using UnityEngine;

public class LavaSeed2D : LavaSeed
{
    public LavaState lavaState = LavaState.Lava;
    public GameObject lava;
    public GameObject rock;
    [SerializeField] private Collider2D boxTrigger;

    public void Start()
    {
        SetupState(LavaState.Lava);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (lavaState == LavaState.Rock) return;

        if ((other.CompareTag("Rock") || other.CompareTag("Water")) && lavaState == LavaState.Lava)
        {
            SoundLava();
            SetupState(LavaState.Rock);
            boxTrigger.enabled = false;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (lavaState == LavaState.Rock) return;

        if ((other.gameObject.CompareTag("Rock") || other.gameObject.CompareTag("Water")) &&
            lavaState == LavaState.Lava)
        {
            SoundLava();
            SetupState(LavaState.Rock);
        }
    }

    private void SetupState(LavaState state)
    {
        if (lavaState == state) return;
        lavaState = state;

        if (lavaState == LavaState.Lava)
        {
            lava.SetActive(true);
            rock.SetActive(false);
            tag = "LavaSeed";
            name = "Lava";
        }
        else
        {
            VFXSpawnController.Instance.SpawnVFX(VisualEffectType.HitLava, transform.position);
            lava.SetActive(false);
            rock.SetActive(true);
            tag = "Rock";
            name = "Rock";
        }
    }
}

public enum LavaState
{
    Lava,
    Rock
}