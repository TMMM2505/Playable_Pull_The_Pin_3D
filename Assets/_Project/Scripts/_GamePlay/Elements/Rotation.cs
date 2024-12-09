using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Pancake.Tween;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private bool isRotateLeft;
    [SerializeField] private Rigidbody2D rigidbody;
    
    void FixedUpdate()
    {
        float rot = rotateSpeed * (isRotateLeft ? -1f : 1f);
        rigidbody.angularVelocity = rot;
    }
}
