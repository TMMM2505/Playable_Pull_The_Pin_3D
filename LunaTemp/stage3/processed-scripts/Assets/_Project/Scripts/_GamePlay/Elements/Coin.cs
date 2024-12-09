using System;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : HolderCountElement
{
    [Header("Coin")] [SerializeField] private int coinMultiplier;
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private Collider2D collider2D;
    [SerializeField] private Material activeMat;
    [SerializeField] private Material inactiveMat;

    public void DisableCoin()
    {
        mesh.enabled = false;
        Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        collider2D.enabled = false;
    }

    public void EnableCoin()
    {
        mesh.enabled = true;
        Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        collider2D.enabled = true;
    }

    private bool IsActivated
    {
        get => isActivated;
        set
        {
            isActivated = value;
            mesh.sharedMaterial = isActivated ? activeMat : inactiveMat;
        }
    }

    public int CoinMultiplier => coinMultiplier;

    private void OnCollisionStay2D(Collision2D other)
    {
        var coinScript = other.collider.GetComponent<Coin>();
        if (coinScript != null && coinScript.IsActivated && !IsActivated)
        {
            var spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            VFXSpawnController.Instance.SpawnVFX(VisualEffectType.ActiveCoin, spawnPos, timeDestroy: 0.25f);
            IsActivated = true;
        }
    }

    private void OnDisable()
    {
        if (GameManager.Instance == null || GameManager.Instance.GameState != GameState.PlayingGame) return;
        
        if (LevelController.Instance == null) return;
        var currentLevel = LevelController.Instance.CurrentLevel;
        
        if (currentLevel == null) return;
        currentLevel.UpdateTotalScoreCanGet();
    }

    #region Interact with bomb

    public override void ChangePhysicTo3D()
    {
        ChangeTo3DPhysics();
    }

    public override void AddForce(Collider hit, float Force)
    {
        var rigid = GetComponent<Rigidbody>();

        rigid.constraints = RigidbodyConstraints.None;
        rigid.AddForce((new Vector3(0, Random.Range(.5f, .7f), Random.Range(-4f, -1.5f)) *
                        Random.Range(2f, 4f) +
                        (hit.transform.position - transform.position).normalized) * (Force * Random.Range(.25f, .45f)));
    }

    public override void SpecialInteraction()
    {
    }

    public override void SetActiveState(bool active)
    {
        IsActivated = active;
    }

    #endregion
}