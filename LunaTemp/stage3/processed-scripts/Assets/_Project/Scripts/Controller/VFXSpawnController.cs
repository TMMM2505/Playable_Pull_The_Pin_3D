using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lean.Pool;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;


public class VFXSpawnController : SingletonDontDestroy<VFXSpawnController>
{
    public List<VisualEffectData> visualEffectData;
    
    private DateTime _prevTime;

    private VisualEffectData GetVisualEffectDataByType(VisualEffectType visualEffectType)
    {
        return visualEffectData.Find(item => item.VisualEffectType == visualEffectType);
    }

    public GameObject SpawnVFX(VisualEffectType visualEffectType, [Bridge.Ref] Vector3 position, Color? color = null,
        Vector3? localScale = null, bool isDestroyedOnEnd = true, float timeDestroy = 3f, bool useTimeDelay = false, float timeDelay = 0f)
    {
        if (useTimeDelay)
        {
            var deltaTime = (DateTime.Now - _prevTime).TotalMilliseconds;
            if (deltaTime < timeDelay) return null;
            _prevTime = DateTime.Now;
        }
        
        var effectData = GetVisualEffectDataByType(visualEffectType);
        if (effectData == null) return null;

        var randomEffect = effectData.GetRandomEffect();
        if (randomEffect == null) return null;

        // Spawn vfx
        var vfxSpawn = LeanPool.Spawn(randomEffect, transform);
        vfxSpawn.transform.position = position;
        if (color != null)
        {
            foreach (var item in vfxSpawn.GetComponentsInChildren<ParticleSystem>())
            {
                var mainColor = item.main;
                mainColor.startColor = (Color)color;
            }
        }

        if (localScale != null) vfxSpawn.transform.localScale = localScale.Value;
        if (isDestroyedOnEnd) LeanPool.Despawn(vfxSpawn, timeDestroy);

        return vfxSpawn;
    }

    public GameObject SpawnVFX(VisualEffectType visualEffectType, [Bridge.Ref] Vector3 position, Transform parent,
        Color? color = null,
        Vector3? localScale = null, bool isDestroyedOnEnd = true, float timeDestroy = 3f)
    {
        // Get vfx data
        var effectData = GetVisualEffectDataByType(visualEffectType);
        if (effectData == null) return null;

        var randomEffect = effectData.GetRandomEffect();
        if (randomEffect == null) return null;

        // Spawn vfx
        var vfxSpawn = LeanPool.Spawn(randomEffect, parent);
        vfxSpawn.transform.position = position;
        if (color != null)
        {
            foreach (var item in vfxSpawn.GetComponentsInChildren<ParticleSystem>())
            {
                var mainColor = item.main;
                mainColor.startColor = (Color)color;
            }
        }

        if (localScale != null) vfxSpawn.transform.localScale = localScale.Value;
        if (isDestroyedOnEnd) LeanPool.Despawn(vfxSpawn, timeDestroy);

        return vfxSpawn;
    }

    private bool IsItemExistedByVisualEffectType(VisualEffectType visualEffectType)
    {
        return visualEffectData.Any(item => item.VisualEffectType == visualEffectType);
    }

    public void UpdateVfXs()
    {
        for (var i = 0; i < Enum.GetNames(typeof(VisualEffectType)).Length; i++)
        {
            var ved = new VisualEffectData
            {
                VisualEffectType = (VisualEffectType)i
            };
            if (IsItemExistedByVisualEffectType(ved.VisualEffectType)) continue;
            visualEffectData.Add(ved);
        }

        visualEffectData = visualEffectData.GroupBy(elem => elem.VisualEffectType).Select(group => group.First())
            .ToList();
    }

    public void DeActiveAllEffectWhenRestartLevel()
    {
        foreach (Transform item in transform)
        {
            item.gameObject.SetActive(false);
        }
    }
}

[Serializable]
public class VisualEffectData
{
    public List<GameObject> EffectList;
    public VisualEffectType VisualEffectType;

    public GameObject GetRandomEffect()
    {
        return EffectList[Random.Range(0, EffectList.Count)];
    }
}

public enum VisualEffectType
{
    Disappear,
    Ex,
    Explosion,
    BonusCoin,
    CollectHalloweenItem,
    HitLava,
    ChestDisappear,
    CollectStar,
    OpenCard,
    StarArrive,
    HitLaser,
    ActiveCoin
}

#if UNITY_EDITOR
[CustomEditor(typeof(VFXSpawnController))]
public class VFXSpawnControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        VFXSpawnController vfxSpawnController = (VFXSpawnController)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Update VFXs", GUILayout.Height(60)))
        {
            vfxSpawnController.UpdateVfXs();
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif