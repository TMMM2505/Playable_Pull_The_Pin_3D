using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class NumberedBridge : MonoBehaviour
{
    [SerializeField] private BreakAnimation locker;
    [SerializeField] private TextMeshPro countText;
    [SerializeField] private int ballRequired;
    [SerializeField] private float timeToCollapse;
    [SerializeField] private float scaleDuration;
    [SerializeField] private List<HingeJoint2D> elementList;
    [SerializeField] private HingeJoint2D lastHinge;

    private List<Ball> _interactedBall;
    private List<Rigidbody2D> _rigidbody2DList;
    private bool _firstInteract;

    public List<HingeJoint2D> ElementList => elementList;

    private void Awake()
    {
        _interactedBall = new List<Ball>();
        _rigidbody2DList = new List<Rigidbody2D>();

        countText.SetText(ballRequired.ToString());

        var elementScriptList = GetComponentsInChildren<BridgeElement>();

        foreach (var element in elementScriptList)
        {
            element.Bridge = this;
            _rigidbody2DList.Add(element.GetComponent<Rigidbody2D>());
        }
    }

    public void BallInteract(Ball ball)
    {
        if (_interactedBall.Contains(ball)) return;
        _interactedBall.Add(ball);

        ballRequired--;
        if (ballRequired >= 0) countText.SetText(ballRequired.ToString());

        if (ballRequired == 0)
        {
            SoundController.Instance.PlayFX(SoundType.NumberedBridge);
            locker.Break();

            DOTween.Sequence().AppendInterval(timeToCollapse).AppendCallback(() =>
            {
                foreach (var element in elementList)
                {
                    element.enabled = false;
                    element.transform.DOScale(0.0f, scaleDuration);
                }

                lastHinge.enabled = false;
            });
        }
    }

    public void DisableFreeze()
    {
        if (_firstInteract) return;
        _firstInteract = true;
        
        foreach (var rb in _rigidbody2DList)
        {
            rb.constraints = RigidbodyConstraints2D.None ;
        }
    }

    public void SetupLocker(BreakAnimation newLock, TextMeshPro lockText)
    {
        locker = newLock;
        countText = lockText;
    }

    public void SetLastHinge(HingeJoint2D hingeJoint2D)
    {
        lastHinge = hingeJoint2D;
    }
}