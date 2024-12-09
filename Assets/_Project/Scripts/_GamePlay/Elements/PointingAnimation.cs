using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PointingAnimation : MonoBehaviour
{
    [SerializeField] private float moveDistance;
    [SerializeField] private float animationTime;

    private Vector3 _defaultPos;
    private Vector3 _movedPos;

    private void Awake()
    {
        _defaultPos = transform.localPosition;
    }

    private void Start()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(transform.DOLocalMove(_defaultPos - transform.right * moveDistance, animationTime).SetEase(Ease.InQuart));

        sequence.Append(transform.DOLocalMove(_defaultPos, animationTime).SetEase(Ease.Linear));

        sequence.SetLoops(-1);

        sequence.Play();
    }
}