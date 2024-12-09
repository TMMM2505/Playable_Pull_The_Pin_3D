using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeElement : MonoBehaviour
{
    public NumberedBridge Bridge { get; set; }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Bridge.DisableFreeze();
        }
    }
}