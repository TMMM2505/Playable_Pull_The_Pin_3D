using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    [SerializeField] private bool isFloating;
    [SerializeField] private bool isRotating;
    [SerializeField] private bool unscaleDeltaTime;
    [SerializeField] private float moveDistanceMultiply = 1;
    [SerializeField] private float moveDurationMultiply = 1;

    private Sequence _moveSequence;
    private Vector3 _starPos;
    private float _moveDistance;
    private float _moveDuration;

    private const float MoveDistance = 0.15f;
    private const float MoveDuration = 1.0f;

    private const float RotateDuration = 8.0f;
    private readonly Vector3 _rotateBy = new(0, 360, 0);

    private void Awake()
    {
        _starPos = transform.position;
        _moveDistance = MoveDistance * moveDistanceMultiply;
        _moveDuration = MoveDuration * moveDurationMultiply;
    }

    private void OnEnable()
    {
        DoFloating();
    }

    private void DoFloating()
    {
        if (isRotating)
        {
            transform.DOLocalRotate(_rotateBy, RotateDuration, RotateMode.LocalAxisAdd)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Incremental).SetTarget(this)
                .SetUpdate(isIndependentUpdate: unscaleDeltaTime);
        }

        if (isFloating)
        {
            var endPos = _starPos + new Vector3(0.0f, _moveDistance * moveDistanceMultiply, 0.0f);

            _moveSequence = DOTween.Sequence();

            _moveSequence.Append(transform.DOMove(endPos, _moveDuration).SetEase(Ease.InOutSine));
            _moveSequence.Append(transform.DOMove(_starPos, _moveDuration).SetEase(Ease.InOutSine));

            _moveSequence.SetLoops(-1);

            _moveSequence.Play().SetUpdate(isIndependentUpdate: unscaleDeltaTime).SetTarget(this);
        }
    }

    private void OnDisable()
    {
        DOTween.Kill(this);
        transform.position = _starPos;
    }
}