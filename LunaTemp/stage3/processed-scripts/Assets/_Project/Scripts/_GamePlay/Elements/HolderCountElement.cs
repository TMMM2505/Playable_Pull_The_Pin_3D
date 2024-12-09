using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HolderCountElement : ObjectCircle, IDestroyByLaser, Ilava, IBomb
{
    [SerializeField] [ReadOnly] protected bool isAchieve;
    [SerializeField] [ReadOnly] protected bool isActivated;
    public int totalScore;
    
    public virtual void InteractWithLaser()
    {
        VFXSpawnController.Instance.SpawnVFX(VisualEffectType.HitLaser, transform.position, useTimeDelay: true, timeDelay: 25);
        SoundController.Instance.PlayFX(SoundType.Lava);
        gameObject.SetActive(false);
    }

    public virtual bool GetActiveState()
    {
        return isActivated;
    }

    public virtual void SetActiveState(bool active)
    {
        isActivated = active;
    }

    public virtual bool GetArchiveState()
    {
        return isAchieve;
    }

    public virtual void SetArchiveState(bool archive)
    {
        isAchieve = archive;
    }

    public virtual void InteractWithLava()
    {
        VFXSpawnController.Instance.SpawnVFX(VisualEffectType.HitLaser, transform.position, useTimeDelay: true, timeDelay: 25);
        SoundController.Instance.PlayFX(SoundType.Lava);
        gameObject.SetActive(false);
    }

    public virtual void ChangePhysicTo3D()
    {
        ChangeTo3DPhysics();
    }

    public virtual void AddForce(Collider hit, float Force)
    {

    }

    public virtual void SpecialInteraction()
    {
 
    }

    public virtual void InteractWithBallHolder(BallColorType ballColorType = BallColorType.YELLOW)
    {
        
    }
}
