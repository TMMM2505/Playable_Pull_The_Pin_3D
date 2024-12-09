using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Dreamteck.Splines;
using MoreMountains.NiceVibrations;
using Spine.Unity;
using UnityEngine;
using UnityEngine.Purchasing;
using Random = UnityEngine.Random;

public class Bomb : ObjectCircle, IDestroyByLaser
{
    [SerializeField] private Transform centerPoint;
    [SerializeField] private GameObject fireParticle;
    public SkinnedMeshRenderer SkinnedMeshRenderer;
    public float Force = 100f;
    public float Radius = 1f;

    [ReadOnly] public bool IsHitBall;
    [ReadOnly] public bool IsHitBallHolder;
    [ReadOnly] [SerializeField] private bool isExploded;

    private Material _material;
    private TweenerCore<Vector3, Vector3, VectorOptions> _sequence;
    private Vector3 _explodeScale;
    public void Start()
    {
        _material = SkinnedMeshRenderer.materials[0];
        _material.color = new Color(.156f, .156f, .156f, 1f);
        _explodeScale = transform.localScale * 1.2f;
        // fireParticle.SetActive(false);
        StartCoroutine(StartIdleAnimForBomb());
    }

    #region Animation

    [Header("Bomb anim")] [SerializeField] private SkeletonAnimation bombAnim;
    [SerializeField, SpineAnimation] private string idle1;
    [SerializeField, SpineAnimation] private string idle2;
    [SerializeField, SpineAnimation] private string explosion;

    private bool _isPlayIdle1;
    private WaitForSeconds _timeDelay = new WaitForSeconds(3);

    private IEnumerator StartIdleAnimForBomb()
    {
        while (!isExploded)
        {
            if (!_isPlayIdle1)
            {
                PlayAnim(idle1);
                _isPlayIdle1 = true;
            }
            else
            {
                PlayAnim(idle2);
                _isPlayIdle1 = false;
            }

            yield return _timeDelay;
        }

        yield return null;
    }

    private void PlayAnim(string anim)
    {
        bombAnim.PlayAnim(animName: anim, loop: true);
    }

    #endregion

    public void OnCollisionEnter2D(Collision2D other)
    {
        var iBomb = other.collider.GetComponent<IBomb>();
        if (iBomb != null)
        {
            IsHitBall = true;
            Exploding();
        }
        
        if (other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("LavaSeed") ||
            other.gameObject.CompareTag("Water") || other.gameObject.CompareTag("Chest"))
        {
            IsHitBall = true;
            Exploding();
        }
        else if (other.gameObject.CompareTag("Bomb") || other.gameObject.CompareTag("Sharp") ||
                 other.gameObject.CompareTag("Wood"))
        {
            Exploding();
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.CompareTag("BallHolder"))
        {
            IsHitBallHolder = true;
            Exploding();
        }
    }

    private void ChangeToPhysic3D()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, Radius);
        foreach (var hit in colliders)
        {
            var iBomb = hit.GetComponent<IBomb>();
            if (iBomb != null)
            {
                if (!CheckBlockBombRaycast(centerPoint.position, hit.transform.position))
                {
                    iBomb.ChangePhysicTo3D();
                }
            }
            else if (hit.CompareTag("Rock") && hit.TryGetComponent<Rock>(out var rock))
            {
                if (!CheckBlockBombRaycast(centerPoint.position, hit.transform.position))
                {
                    rock.BeDestroy();
                }
            }
            else if ((hit.CompareTag("Water") || hit.CompareTag("LavaSeed") || hit.CompareTag("Chest")) &&
                     hit.TryGetComponent<ObjectCircle>(out var objectCircle))
            {
                if (!CheckBlockBombRaycast(centerPoint.position, hit.transform.position))
                {
                    objectCircle.ChangeTo3DPhysics();
                }
            }
            else if (hit.CompareTag("Wood") && hit.TryGetComponent<Wood>(out var wood))
            {
                if (!CheckBlockBombRaycast(centerPoint.position, hit.transform.position))
                {
                    wood.Broke(Force, transform);
                }
            }
            else if (hit.CompareTag("StarBonus"))
            {
                if (!CheckBlockBombRaycast(centerPoint.position, hit.transform.position))
                {
                    hit.gameObject.SetActive(false);
                }
            }
        }
    }
    
    private bool CheckBlockBombRaycast(Vector3 startPos, Vector3 endPos)
    {
        var direction = (endPos - startPos).normalized;
        var distance = (endPos - startPos).sqrMagnitude;
        var hits= Physics2D.RaycastAll(startPos, direction, distance);
        var blockObject = hits.FirstOrDefault(hit => hit.collider != null && ((hit.collider.CompareTag("Pin") && !hit.collider.isTrigger) || hit.collider.GetComponent<SplineMesh>() != null));
        if (blockObject.collider != null)
        {
            return true;
        }

        return false;
    }

    private void AddForceToObject()
    {
        var colliderList = Physics.OverlapSphere(transform.position, Radius);
        foreach (var hit in colliderList)
        {
            var iBomb = hit.GetComponent<IBomb>();
            if (iBomb != null)
            {
                iBomb.AddForce(hit, Force);
            }
            
            if (hit.CompareTag("Ball") &&
                hit.TryGetComponent<Rigidbody>(out var rigid))
            {
                rigid.constraints = RigidbodyConstraints.None;
                rigid.AddForce((new Vector3(0, Random.Range(.2f, .5f), Random.Range(-3f, -1f)) *
                                Random.Range(2f, 4f) +
                                (hit.transform.position - transform.position).normalized) * (Force * Random.Range(.2f, .3f)));
            }
            else if ((hit.CompareTag("Water") || hit.CompareTag("LavaSeed")) &&
                     hit.TryGetComponent<Rigidbody>(out var rigidObject))
            {
                rigidObject.constraints = RigidbodyConstraints.FreezeRotation;
                rigidObject.AddForce((new Vector3(0, Random.Range(.2f, .5f), Random.Range(-3f, -1f)) *
                                      Random.Range(2f, 4f) +
                                      (hit.transform.position - transform.position).normalized) * (Force * Random.Range(.2f, .3f)));
            }
            else if (hit.CompareTag("Chest") && hit.TryGetComponent<Rigidbody>(out var chestRigid))
            {
                chestRigid.constraints = RigidbodyConstraints.None;
                chestRigid.AddForce((new Vector3(0, Random.Range(.2f, .5f), Random.Range(-3f, -1f)) *
                                     Random.Range(2f, 4f) +
                                     (hit.transform.position - transform.position).normalized) * (Force * Random.Range(.2f, .3f)));
                chestRigid.AddTorque(Random.onUnitSphere * Random.Range(100f, 150f));
            }
        }
    }

    private void DestroyByBomb()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, Radius);
        foreach (var hit in colliders)
        {
            if (hit.CompareTag("Ball") && hit.TryGetComponent<Rigidbody2D>(out var rb))
            {
                rb.AddForce((hit.transform.position - transform.position).normalized * (Force * .5f));
            }
            else if (hit.CompareTag("Rock") && hit.TryGetComponent<Rock>(out var rock))
            {
                rock.BeDestroy();
            }
            else if ((hit.CompareTag("Water") || hit.CompareTag("LavaSeed")) &&
                     hit.TryGetComponent<Rigidbody2D>(out var rigid))
            {
                rigid.AddForce(
                    (hit.gameObject.transform.position - transform.position).normalized * (Force * .5f));
            }
            else if (hit.CompareTag("Wood") && hit.TryGetComponent<Wood>(out var wood))
            {
                wood.Broke(Force, transform);
            }
            else if (hit.CompareTag("StarBonus"))
            {
                if (!CheckBlockBombRaycast(centerPoint.position, hit.transform.position))
                {
                    hit.gameObject.SetActive(false);
                }
            }
        }
    }

    public void Exploding()
    {
        if (isExploded) return;

        fireParticle.SetActive(true);
        PlayAnim(explosion);
        isExploded = true;
        _material.DOColor(new Color(.784f, .196f, .196f, 1), 0.85f);

        _sequence = transform.DOScale(_explodeScale, 0.85f).OnComplete(() =>
        {
            LevelController.Instance.CurrentLevel.BombExplodeNumb++;
            SoundController.Instance.PlayFX(SoundType.Bomb);
            MMVibrationManager.Haptic(HapticTypes.MediumImpact);
            VFXSpawnController.Instance.SpawnVFX(VisualEffectType.Explosion, transform.position);

            if (IsHitBall || IsHitBallHolder)
            {
                ChangeToPhysic3D();
                DOTween.Sequence().AppendInterval(.01f).AppendCallback(AddForceToObject);
            }
            else
            {
                DestroyByBomb();
            }

            gameObject.SetActive(false);
        });
    }

    public override void OnDestroy()
    {
        _sequence?.Kill();
    }

    public void InteractWithLaser()
    {
        // Exploding by laser
        
        if (isExploded) return;
        fireParticle.SetActive(true);
        isExploded = true;
        
        LevelController.Instance.CurrentLevel.BombExplodeNumb++;
        SoundController.Instance.PlayFX(SoundType.Bomb);
        MMVibrationManager.Haptic(HapticTypes.MediumImpact);
        VFXSpawnController.Instance.SpawnVFX(VisualEffectType.Explosion, transform.position);
        
        if (IsHitBall || IsHitBallHolder)
        {
            ChangeToPhysic3D();
            AddForceToObject();
        }
        else
        {
            DestroyByBomb();
        }

        gameObject.SetActive(false);
    }
}