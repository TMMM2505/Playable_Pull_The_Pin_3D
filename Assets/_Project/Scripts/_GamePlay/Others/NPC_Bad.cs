using System;
using Animancer;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NPC_Bad : MonoBehaviour
{
    public AnimancerComponent Animancer;
    public ClipTransition Idle;
    public ClipTransition IdleRelax;
    public ClipTransition Lose;
    public ClipTransition Think1;
    public ClipTransition Think2;
    public ClipTransition Victory;

    public Image TextBox;
    public Sprite LoseSprite;
    public Sprite Think1Sprite;
    public Sprite Think2Sprite1;
    public Sprite Think2Sprite2;
    public Sprite Think2Sprite3;
    public Sprite VictorySprite;
    

    private Sequence sequence;
    private Sequence talkSequence;

    void Start()
    {
        if (Data.UseNPCABTesting == 1)
        {
            gameObject.SetActive(false);
            return;
        }

        TextBox.gameObject.SetActive(false);
        
        PlayIdle();
        sequence = DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            PlayThink1();
            sequence = DOTween.Sequence().AppendInterval(4f).AppendCallback(() =>
            {
                PlayThink2();
                sequence = DOTween.Sequence().AppendInterval(6f).AppendCallback(() =>
                {
                    Action();
                });
            });
        });

        LevelEvent.OnLose += PlayLose;
        LevelEvent.OnWin += PlayVictory;
    }

    void OnDestroy()
    {
        sequence?.Kill();
        talkSequence?.Kill();
        
        LevelEvent.OnLose -= PlayLose;
        LevelEvent.OnWin -= PlayVictory;
    }

    public void Talk(Sprite sprite)
    {
        TextBox.gameObject.SetActive(true);
        TextBox.sprite = sprite;
        talkSequence = DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
        {
            TextBox.gameObject.SetActive(false);
        });
    }

    public void Action()
    {
        PlayIdleRelax();
        sequence = DOTween.Sequence().AppendInterval(7f).AppendCallback(() =>
        {
            PlayThink2();
            sequence = DOTween.Sequence().AppendInterval(7f).AppendCallback(() =>
            {
                Action();
            });
        });
    }

    public void PlayIdle()
    {
        if (Animancer.IsPlaying(Lose) || Animancer.IsPlaying(Victory)) return;
        Animancer.Play(Idle);
    }
    
    public void PlayIdleRelax()
    {
        if (Animancer.IsPlaying(Lose) || Animancer.IsPlaying(Victory)) return;
        var anim = Animancer.Play(IdleRelax);
        anim.Events.OnEnd += () =>
        {
            PlayIdle();
        };
    }
    
    public void PlayLose()
    {
        SoundController.Instance.PlayFX(SoundType.NpcLose);
        Animancer.Play(Lose);
        Talk(LoseSprite);
    }
    
    public void PlayThink1()
    {
        if (Animancer.IsPlaying(Lose) || Animancer.IsPlaying(Victory)) return;
        SoundController.Instance.PlayFX(SoundType.NpcThink1);
        var anim = Animancer.Play(Think1);
        Talk(Think1Sprite);
        anim.Events.OnEnd += () =>
        {
            PlayIdle();
        };
    }
    
    public void PlayThink2()
    {
        if (Animancer.IsPlaying(Lose) || Animancer.IsPlaying(Victory)) return;
        int rd = Random.Range(0, 3);
        if (rd == 0)
        {
            SoundController.Instance.PlayFX(SoundType.NpcThink2Ver1);
            Talk(Think2Sprite1);
        }
        else if (rd == 1)
        {
            SoundController.Instance.PlayFX(SoundType.NpcThink2Ver2);
            Talk(Think2Sprite2);
        }
        else
        {
            SoundController.Instance.PlayFX(SoundType.NpcThink2Ver3);
            Talk(Think2Sprite3);
        }
        var anim = Animancer.Play(Think2);
        anim.Events.OnEnd += () =>
        {
            PlayIdle();
        };
    }
    
    public void PlayVictory()
    {
        DOTween.Sequence().AppendInterval(.5f).AppendCallback(() =>
        {
            SoundController.Instance.PlayFX(SoundType.NpcWin);
            Animancer.Play(Victory);
            Talk(VictorySprite);
        });
    }
}
