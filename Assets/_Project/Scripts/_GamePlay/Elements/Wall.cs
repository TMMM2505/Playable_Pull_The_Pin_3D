using System;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public MeshRenderer MeshRenderer;
    
    private Material material;
    void Start()
    {
        SetupWall();
        
        EventController.CurrentThemeChanged += SetupWall;
    }

    private void OnDestroy()
    {
        EventController.CurrentThemeChanged -= SetupWall;
    }

    private void SetupWall()
    {
        material = ConfigController.ItemConfig.GetMaterialByThemeId(Data.CurrentThemeSkinId);
        if (material)
        {
            MeshRenderer.material = material;
        }
    }
}
