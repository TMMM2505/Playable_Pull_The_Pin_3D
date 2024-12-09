using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SoundController : Singleton<SoundController>
{
    public AudioSource BackgroundAudio;
    public AudioSource FxAudio;
    public List<AudioClip> AudioClips = new();

    [SerializeField] private float delayTimeStack = .05f;
    [SerializeField] private float delayTimeLava = 1f;
    [SerializeField] private float delayTimePortal = 0.2f;
    [SerializeField] private float delayTimeCoin = 0.2f;
    [SerializeField] private float delayBallInBallHolder = 0.2f;

    private bool _playingLavaSound;
    private bool _playingInPortalSound;
    private bool _playingOutPortalSound;
    private bool _playingCoinSound;
    private bool _playingBallHolderSound;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (delayTimeStack > 0)
        {
            delayTimeStack -= Time.deltaTime;
        }
    }

    public void Initialize()
    {
        BackgroundAudio.loop = true;

        for (int i = 0; i < Enum.GetNames(typeof(SoundType)).Length; i++)
        {
            SoundData soundData = ConfigController.Sound.SoundDatas.Find(item => item.SoundType == (SoundType)i);
            AudioClips.Add(soundData.Clip);
        }
    }

    public void PlayFX(SoundType soundType)
    {
        var audioClip = AudioClips[(int)soundType];

        if (!audioClip || !Data.SoundState) return;

        switch (soundType)
        {
            case SoundType.Stack:
                if (delayTimeStack <= 0)
                {
                    FxAudio.PlayOneShot(audioClip);
                    delayTimeStack = .05f;
                }

                break;
            case SoundType.Lava:
                if (_playingLavaSound) return;

                _playingLavaSound = true;
                FxAudio.PlayOneShot(audioClip);
                DOTween.Sequence().AppendInterval(delayTimeLava).AppendCallback(() => _playingLavaSound = false);

                break;
            case SoundType.InPortal:
                if (_playingInPortalSound) return;

                _playingInPortalSound = true;
                FxAudio.PlayOneShot(audioClip);
                DOTween.Sequence().AppendInterval(delayTimePortal).AppendCallback(() => _playingInPortalSound = false);

                break;
            case SoundType.OutPortal:
                if (_playingOutPortalSound) return;

                _playingOutPortalSound = true;
                FxAudio.PlayOneShot(audioClip);
                DOTween.Sequence().AppendInterval(delayTimePortal).AppendCallback(() => _playingOutPortalSound = false);

                break;
            case SoundType.CoinMove:
                if (_playingCoinSound) return;

                _playingCoinSound = true;
                FxAudio.PlayOneShot(audioClip);
                DOTween.Sequence().AppendInterval(delayTimeCoin).AppendCallback(() => _playingCoinSound = false)
                    .SetUpdate(isIndependentUpdate: true);

                break;
            case SoundType.TargetBallSucceed:
                if (_playingBallHolderSound) return;

                _playingBallHolderSound = true;
                FxAudio.PlayOneShot(audioClip);
                DOTween.Sequence().AppendInterval(delayBallInBallHolder)
                    .AppendCallback(() => _playingBallHolderSound = false)
                    .SetUpdate(isIndependentUpdate: true);

                break;
            default:
                FxAudio.PlayOneShot(audioClip);
                break;
        }
    }

    #region NotUse
    public void PlayBackground(SoundType soundType)
    {
        AudioClip clip = AudioClips[(int)soundType];

        if (!clip || !Data.MusicState) return;

        BackgroundAudio.clip = clip;
        BackgroundAudio.Play();
    }

    public void PauseBackground()
    {
        if (BackgroundAudio)
        {
            BackgroundAudio.Pause();
        }
    }

    public AudioSource PlayLoop(SoundType soundType)
    {
        AudioClip clip = AudioClips[(int)soundType];

        if (!clip || !Data.SoundState) return null;

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.playOnAwake = true;
        audioSource.loop = true;
        audioSource.Play();

        return audioSource;
    }
    #endregion
}