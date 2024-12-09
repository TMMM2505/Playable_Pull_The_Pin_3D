using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectCircle : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    [SerializeField] protected ObjectType type;
    public bool IsUseMultipleVel = true;
    public bool IsUseXAxis = true;
    public bool IsUseYAxis = true;
    [Range(1f, 1.05f)] public float MultipleVel = 1.02f;
    [Range(.1f, 10f)] public float MinIncreaseVel = .5f;

    public ObjectType Type => type;
    public Rigidbody2D Rigidbody => _rigidbody2D;

    private CircleCollider2D _circleCollider2D;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _defaultScale;
    private List<InPortal> _portalList;

    protected void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _defaultScale = transform.localScale;
        _portalList = new List<InPortal>();
    }

    public void FixedUpdate()
    {
        if (Rigidbody2D)
        {
            if (IsUseMultipleVel)
            {
                if (IsUseXAxis && Mathf.Abs(Rigidbody2D.velocity.x) > MinIncreaseVel)
                {
                    Rigidbody2D.velocity *= new Vector2(1, MultipleVel);
                }

                if (IsUseYAxis && Rigidbody2D.velocity.y < -MinIncreaseVel)
                {
                    Rigidbody2D.velocity *= new Vector2(MultipleVel, 1f);
                }
            }

            var velocityX = Mathf.Clamp(Rigidbody2D.velocity.x, -15f, 15f);
            var velocityY = Mathf.Clamp(Rigidbody2D.velocity.y, -15f, 15f);
            Rigidbody2D.velocity = new Vector2(velocityX, velocityY);
        }
    }


    public void ChangeTo3DPhysics()
    {
        var radius = _circleCollider2D.radius;
        var center = _circleCollider2D.offset;
        if (_circleCollider2D)
        {
            Destroy(_circleCollider2D);
        }

        var velocity = _rigidbody2D.velocity;
        var angularVelocity = _rigidbody2D.angularVelocity;
        if (_rigidbody2D)
        {
            Destroy(_rigidbody2D);
        }

        DOTween.Sequence().AppendInterval(.01f).AppendCallback(() =>
        {
            if (GetComponent<Rigidbody>() != null) return;

            var sphereCollider = gameObject.AddComponent<SphereCollider>();
            sphereCollider.radius = radius;
            sphereCollider.center = center;
            var rb = gameObject.AddComponent<Rigidbody>();
            rb.velocity = velocity;
            rb.angularVelocity = new Vector3(angularVelocity, angularVelocity);
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            if (gameObject.CompareTag("LavaSeed") || gameObject.CompareTag("Water") || gameObject.CompareTag("Chest"))
                rb.constraints = RigidbodyConstraints.FreezeRotation;
        }).SetTarget(this);
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BallHolder"))
        {
            ChangeTo3DPhysics();
        }
    }

    public virtual void BeingPulledInPortal(InPortal inPortal, float moveDuration, Action teleportCallback)
    {
        if (_portalList.Contains(inPortal)) return;
        if (_circleCollider2D == null || _rigidbody2D == null) return;

        _portalList.Add(inPortal);

        _circleCollider2D.enabled = false;
        _rigidbody2D.velocity = Vector2.zero;

        transform.DOMove(inPortal.transform.position, moveDuration);
        transform.DOScale(0.0f, moveDuration).OnComplete(() => teleportCallback?.Invoke());
    }

    public virtual void BackToDefault(float moveDuration)
    {
        _circleCollider2D.enabled = true;
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.angularVelocity = 0.0f;

        transform.DOScale(_defaultScale, moveDuration);
    }

    public virtual void OnDestroy()
    {
        DOTween.Kill(this);
    }
}

[Serializable]
public enum ObjectType
{
    Lava,
    Water,
    Rock,
    Null,
    Ball
}