using System;
using DG.Tweening;
using UnityEngine;

public class MovingPin : Pin
{
    [Header("--- MOVING PIN ---")] [SerializeField] private float moveSpeed = 10f;
    [SerializeField] [Range(.1f, 10f)] private float moldingLength = 1f;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private Transform rightPos;
    [SerializeField] private Transform leftPos;
    
    [Header("--- PIN HOLDER ---")]
    [SerializeField] private GameObject molding_body;
    [SerializeField] private GameObject molding_head1;
    [SerializeField] private GameObject molding_head2;
    [SerializeField] private Transform head1Pos;
    [SerializeField] private Transform head2Pos;

    private const float Distance = 1;

    private void Start()
    {
        UpdateMoldingPin();
        UpdatePin();
    }
    
    public override void OnDrawGizmos()
    {
        if (Application.isPlaying) return;
        base.OnDrawGizmos();
        UpdateMoldingPin();
    }

    public override void ActivePin()
    {
        base.ActivePin();
        if (!IsPullAble) return;
        
        if (pinState == PinState.Moving) return;
        pinState = PinState.Moving;
        SoundController.Instance.PlayFX(SoundType.PinNormal);

        if (Vector3.Distance(skinHolder.transform.position, startPoint.position) <= Distance)
        {
            rigid.DOMove(endPoint.position, moveSpeed).SetEase(Ease.Linear).SetSpeedBased().OnKill(() => rigid.DOKill())
                .OnComplete(() => { pinState = PinState.Idle; });
        }
        else
        {
            rigid.DOMove(startPoint.position, moveSpeed).SetEase(Ease.Linear).SetSpeedBased()
                .OnKill(() => rigid.DOKill()).OnComplete(() => { pinState = PinState.Idle; });
        }
    }

    private void UpdateMoldingPin()
    {
        rightPos.position = currentPinSkin.Pin_archor_right.position;
        leftPos.position = currentPinSkin.Pin_archor_left.position;
        
        if (head1Pos != null && head2Pos != null && molding_body != null && molding_head1 != null &&
            molding_head2 != null)
        {
            var localScale = molding_body.transform.localScale;
            localScale = new Vector3(localScale.x, localScale.y, moldingLength);
            molding_body.transform.localScale = localScale;

            molding_head1.transform.position = head1Pos.position;
            molding_head2.transform.position = head2Pos.position;
        }

        transform.position = new Vector2(transform.position.x, head1Pos.position.y);
    }

    protected override Vector2 CalculateCenterOfPin(Vector3 center)
    {
        return new Vector2(center.x, 0f);
    }

    protected override Vector3 CalculateCenterPoint()
    {
        return (rightPos.localPosition + leftPos.localPosition) / 2;
    }

    protected override Vector2 CalculateSizeOfCollider()
    {
        return new Vector2(
            Mathf.Abs(rightPos.localPosition.x - leftPos.localPosition.x),
            boxTrigger2D.size.y);
    }
}