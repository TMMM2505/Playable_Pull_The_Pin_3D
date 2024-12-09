using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Pancake;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class RotatePin : Pin
{
    [Header("--- ROTATE PIN ---")] 
    [SerializeField] [Range(0, 180f)] private float angle;
    [SerializeField] private bool clockwise = true;
    [SerializeField] private float timePerDeg;
    [SerializeField] private Rigidbody2D rigid;
    
    private bool _isRotateBack;
    private bool _canMovePin;
    private float _currentAngleZ;
    
    protected void Start()
    {
       ResetPin();
    }

    private void ResetPin()
    {
        _isRotateBack = false;
        _currentAngleZ = transform.rotation.eulerAngles.z;
        _currentAngleZ = NormalizeAngle(_currentAngleZ);
        
        // DoRotate has issues with (2k+1)pi
        if ((int)_currentAngleZ == 180) transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _currentAngleZ - 0.01f);
        if ((int)_currentAngleZ == -180) transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _currentAngleZ + 0.01f);
        _canMovePin = true;
        if (clockwise) angle = -angle;
    }

    private float NormalizeAngle(float deg)
    {
        var degNormal = deg;
        degNormal = degNormal > 0
            ? degNormal - (int)(degNormal / 360).Floor() * 360
            : degNormal + (int)(degNormal / 360).Floor() * 360;
        
        if (Mathf.Abs(degNormal) > 180)
        {
            degNormal = degNormal > 0 
                ? degNormal - 360 
                : degNormal + 360;
        }

        return degNormal;
    }

#if  UNITY_EDITOR

    private void OnValidate()
    {
        if (_canMovePin)
        {
            ResetPin();
        }
    }

#endif
    
    protected override void SetupPinSkin()
    {
        //DoNotTouch
        //base.SetupPinSkin();
    }
    
    public override void ActivePin()
    {
        base.ActivePin();
        if (!IsPullAble) return;
        if (_canMovePin) DoRotate();
    }
    
    private void DoRotate()
    {
        var endAngle = _currentAngleZ + angle;
        //endAngle = NormalizeAngle(endAngle);
        _canMovePin = false;
        SoundController.Instance.PlayFX(SoundType.PinNormal);
        if (_isRotateBack)
        {
            rigid
                .DORotate(_currentAngleZ, Mathf.Abs(timePerDeg * angle))
                .OnComplete(() =>
                {
                    _canMovePin = true;
                    _isRotateBack = false;
                });
        }
        else
        {
            rigid
                .DORotate(endAngle, Mathf.Abs(timePerDeg * angle))
                .OnComplete(() =>
                {
                    _canMovePin = true;
                    _isRotateBack = true;
                });
        }
    }
    
//     [Header("--- ROTATE PIN ---")]
//     [SerializeField] private float rotationAngle; 
//     [SerializeField] private float rotationTimePerDeg;   
//     
//     private float _rotationSpeed;      
//     private float _elapsedTime = 0f;
//     private Rigidbody2D _rigid => GetComponent<Rigidbody2D>();
//
//     private bool _isRotating;
//     private bool _isRotateBack;
//
//     void Start()
//     {
//         ResetWhenChangeDeg();
//     }
//
// #if  UNITY_EDITOR
//     private void OnValidate()
//     {
//         ResetWhenChangeDeg();
//     }
// #endif
//
//     protected override void SetupPinSkin()
//     {
//         
//     }
//
//     private void ResetWhenChangeDeg()
//     {
//         _isRotating = false;
//         _isRotateBack = false;
//         _rotationSpeed = rotationAngle / Mathf.Abs(rotationTimePerDeg * rotationAngle);
//     }
//
//     public override void ActivePin()
//     {
//         if (!_isRotating) 
//         {
//             base.ActivePin();
//             _isRotating = true;
//         }
//     }
//
//     void Update()
//     {
//         if (_isRotating)
//         {
//             if (_elapsedTime < Mathf.Abs(rotationTimePerDeg * rotationAngle))
//             {
//                 float rotationStep = _rotationSpeed * Time.deltaTime;
//                 _rigid.transform.Rotate(0, 0, rotationStep);
//                 _elapsedTime += Time.deltaTime;
//             }
//             else
//             {
//                 _isRotating = false;
//                 _isRotateBack = !_isRotateBack;
//                 _rotationSpeed = -_rotationSpeed;
//                 _elapsedTime = 0;
//             }
//         }
//     }
}