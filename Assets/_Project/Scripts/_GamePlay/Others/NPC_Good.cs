using System.Collections;
using System.Collections.Generic;
using Animancer;
using DG.Tweening;
using UnityEngine;

public class NPC_Good : MonoBehaviour
{
    public AnimancerComponent Animancer;
    public ClipTransition Idle;
    public ClipTransition Think;
    public ClipTransition Encourage;
    public ClipTransition Lose;
    public ClipTransition Victory;
    
    private Sequence sequence;
    
    void Start()
    {
        if (Data.UseNPCABTesting == 1)
        {
            gameObject.SetActive(false);
            return;
        }

        PlayThink();

        LevelEvent.OnLose += PlayLose;
        LevelEvent.OnWin += PlayVictory;
    }
    
    void OnDestroy()
    {
        sequence?.Kill();

        LevelEvent.OnLose -= PlayLose;
        LevelEvent.OnWin -= PlayVictory;
    }
    
    public void PlayIdle()
    {
        if (Animancer.IsPlaying(Lose) || Animancer.IsPlaying(Victory)) return;
        Animancer.Play(Idle);
        sequence = DOTween.Sequence().AppendInterval(3f).AppendCallback(PlayEncourage);
    }
    
    public void PlayLose()
    {
        sequence?.Kill();
        SoundController.Instance.PlayFX(SoundType.NpcLose);
        Animancer.Play(Lose);
    }
    
    public void PlayEncourage()
    {
        SoundController.Instance.PlayFX(SoundType.NpcEncourage);
        var anim = Animancer.Play(Encourage);
        anim.Events.OnEnd += () =>
        {
            PlayIdle();
        };
    }
    
    public void PlayThink()
    {
        if (Animancer.IsPlaying(Lose) || Animancer.IsPlaying(Victory)) return;
        SoundController.Instance.PlayFX(SoundType.NpcThink1);
        var anim = Animancer.Play(Think);
        anim.Events.OnEnd += () =>
        {
            PlayIdle();
        };
    }

    public void PlayVictory()
    {
        sequence?.Kill();
        DOTween.Sequence().AppendInterval(.5f).AppendCallback(() =>
        {
            SoundController.Instance.PlayFX(SoundType.NpcWin);
            Animancer.Play(Victory);
        });
    }
}
