using DG.Tweening;
using MoreMountains.NiceVibrations;
using UnityEngine;

public class ExplosiveBrokenBall : BrokenBall
{
    [SerializeField] private GameObject fireParticle;
    [SerializeField] private float explodeRadius;

    private Vector3 _explodeScale;
    private bool _isExploding;

    protected override void Initialize()
    {
        base.Initialize();
        _explodeScale = transform.localScale * 1.2f;
    }

    protected override void SetupBallSkin()
    {
        // base.SetupBallSkin();
        // fireParticle.SetActive(false);
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (_isExploding) return;

        base.OnCollisionEnter2D(other);

        var otherGameObject = other.gameObject;
        if (otherGameObject.CompareTag("Ball") && otherGameObject.TryGetComponent<Ball>(out var ball) &&
            ball as BrokenBall)
        {
            _isExploding = true;
            Explode();
        }
    }

    public override void Explode()
    {
        fireParticle.SetActive(true);
        
        transform.DOScale(_explodeScale, 1.0f).SetTarget(this).OnComplete(() =>
        {
            var explodePos = transform.position;

            SoundController.Instance.PlayFX(SoundType.Bomb);
            MMVibrationManager.Haptic(HapticTypes.MediumImpact);
            VFXSpawnController.Instance.SpawnVFX(VisualEffectType.Explosion, explodePos,
                LevelController.Instance.CurrentLevel.transform);

            var colliders = Physics2D.OverlapCircleAll(explodePos, explodeRadius);
            foreach (var hit in colliders)
            {
                if (hit.CompareTag("Ball"))
                {
                    if (hit.TryGetComponent<BrokenBall>(out var brokenBall))
                    {
                        brokenBall.Explode();
                    }
                    else if (hit.TryGetComponent<Rigidbody2D>(out var rb))
                    {
                        rb.AddForce((hit.transform.position - transform.position).normalized * breakForce * .5f);
                    }
                }
                else if (hit.CompareTag("Rock") && hit.TryGetComponent<Rock>(out var rock))
                {
                    rock.BeDestroy();
                }
                else if ((hit.CompareTag("Water") || hit.CompareTag("LavaSeed") || hit.CompareTag("Bomb")) &&
                         hit.TryGetComponent<Rigidbody2D>(out var rigid))
                {
                    rigid.AddForce(
                        (hit.gameObject.transform.position - transform.position).normalized * breakForce * .5f);
                }
                else if (hit.CompareTag("Wood") && hit.TryGetComponent<Wood>(out var wood))
                {
                    wood.Broke(breakForce, transform);
                }
            }
            
            base.Explode();
        });
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
        Gizmos.DrawSphere(transform.position, explodeRadius);
    }
#endif
}