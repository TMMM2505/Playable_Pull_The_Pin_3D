using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pancake;
using UnityEngine;

public class PackElementController : MonoBehaviour
{
    public Transform parrent;

    [SerializeField] private GameObject objSpawn;
    [ReadOnly] public List<Transform> listTransformDefault = new List<Transform>();


    [Button("Setup Pack")]
    private void SetupPack()
    {
        listTransformDefault.Clear();
        listTransformDefault = parrent.GetComponentsInChildren<Transform>().ToList();
        listTransformDefault.RemoveAt(0);
        for (int i = 0; i < listTransformDefault.Count; i++)
        {
            GameObject obj = Instantiate(objSpawn, listTransformDefault[i].position, objSpawn.transform.rotation, this.transform);
        }
    }
}
