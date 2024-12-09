using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallHolderSkin : MonoBehaviour
{
    public int Id;
    [SerializeField] private List<MeshRenderer> objectRenderers;
    [SerializeField] private MeshRenderer glassRenderer;
    [SerializeField] private Material objectBurnMaterial;
    [SerializeField] private Material glassBurnMaterial;

    public void SetupSkin()
    {
        gameObject.SetActive(Data.CurrentThemeSkinId == Id);
    }

    public void Burn()
    {
        if (Data.CurrentThemeSkinId != Id) return;

        foreach (var objectRenderer in objectRenderers)
        {
            objectRenderer.material = objectBurnMaterial;
        }

        glassRenderer.material = glassBurnMaterial;
    }

}
