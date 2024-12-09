using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PinSkin : MonoBehaviour
{
    public int PinID;

    public Transform Pin_body;
    public Transform Pin_tail;
    public Transform Pin_archor_tail;
    public Transform Pin_archor_left;
    public Transform Pin_archor_right;

    private List<MeshRenderer> _meshRendererList;

    private void Awake()
    {
        _meshRendererList = GetComponentsInChildren<MeshRenderer>().ToList();
    }

    public void ToggleMaterialOnTutorial(bool status)
    {
        foreach (var meshRenderer in _meshRendererList)
            meshRenderer.material.renderQueue = status ? 3600 : 2000;
    }

    public void Setup()
    {
        if (PinID == Data.CurrentPinSkinId)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}