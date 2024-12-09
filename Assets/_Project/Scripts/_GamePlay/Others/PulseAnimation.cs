using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PulseAnimation : MonoBehaviour
{
    [SerializeField] private float scale = 1.2f;
    [SerializeField] private float duration = 0.2f;
    [SerializeField] private Ease ease = Ease.Linear;
    [SerializeField] private int loopCount = -1;
    [SerializeField] private bool from;
    [SerializeField] private bool autoPlay;

    private Vector3 _originalScale;
    private TweenerCore<Vector3, Vector3, VectorOptions> _tween;

    private void Awake()
    {
        _originalScale = transform.localScale;
    }

    private void OnEnable()
    {
        if (autoPlay) PlayPulse();
    }

    public void ChangeProperties(float newScale, float newDuration, bool isAutoPlay)
    {
        scale = newScale;
        duration = newDuration;
        autoPlay = isAutoPlay;
#if UNITY_EDITOR
        EditorUtility.SetDirty(this);
#endif
    }

    public void PlayPulse()
    {
        DOTween.Kill(this);
        _tween = transform.DOScale(scale * _originalScale, duration);
        if (from)
        {
            _tween = _tween.From();
        }

        if (loopCount != 0)
        {
            _tween = _tween.SetLoops(loopCount, LoopType.Yoyo);
        }

        _tween.SetEase(ease).SetTarget(this);
        _tween.Play().SetUpdate(isIndependentUpdate: true);
    }

    public void StopPulse()
    {
        DOTween.Kill(this);
        transform.localScale = _originalScale;
    }

    private void OnDisable()
    {
        StopPulse();
    }
}