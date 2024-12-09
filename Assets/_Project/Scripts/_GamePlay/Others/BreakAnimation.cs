using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class BreakAnimation : MonoBehaviour
{
    [SerializeField] private Transform breakParent;
    [SerializeField] private List<Transform> elements;
    [SerializeField] private float breakForce;
    [SerializeField] private float rotateForce;
    [SerializeField] private float scaleDuration;

    public void SetBreakParent(Transform parent)
    {
        breakParent = parent;
    }
    
    public void Break()
    {
        transform.SetParent(breakParent);
        
        foreach (var element in elements)
        {
            var rigidBody2D = element.gameObject.AddComponent<Rigidbody2D>();

            rigidBody2D.AddForce(Random.insideUnitCircle * breakForce);

            // rigidBody2D.AddForce((element.position - transform.position).normalized * breakForce *
            //                      Random.Range(0.5f, 1.0f));
            rigidBody2D.AddTorque(rotateForce);
        }

        transform.DOScale(Vector3.zero, scaleDuration).SetTarget(this)
            .OnComplete(() =>
            {
                transform.gameObject.SetActive(false);
            });

    }
}