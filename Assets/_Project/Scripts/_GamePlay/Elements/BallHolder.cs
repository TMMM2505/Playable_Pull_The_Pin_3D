using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class BallHolder : MonoBehaviour
{
    public TextMeshProUGUI Text;
    [ReadOnly] public bool IsBroken;
    public GameObject trigger;

    public List<MeshRenderer> MeshRenderers;
    private TweenerCore<Vector3, Vector3, VectorOptions> sequence;

    protected virtual void Start()
    {
        foreach (var item in MeshRenderers)
        {
            item.enabled = false;
        }

        Text.gameObject.SetActive(true);
    }

    public void OnBombExploding()
    {
        if (IsBroken) return;

        IsBroken = true;
        var layerIgnoreRaycast = LayerMask.NameToLayer("IgnoreBall");
        Utility.SetGameLayerRecursive(gameObject, layerIgnoreRaycast);
        gameObject.layer = layerIgnoreRaycast;
        transform.DOKill();
        transform.DORotate(new Vector3(Random.Range(0f, 180f), Random.Range(0f, 180f), Random.Range(0f, 180f)), 2f)
            .OnComplete(
                () =>
                {
                    transform.DORotate(
                        new Vector3(Random.Range(0f, 180f), Random.Range(0f, 180f), Random.Range(0f, 180f)), 2f);
                });
    }
}