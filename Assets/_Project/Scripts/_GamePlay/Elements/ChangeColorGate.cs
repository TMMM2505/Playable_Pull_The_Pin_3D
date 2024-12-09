using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorGate : MonoBehaviour
{
    //[SerializeField] private Material ballMaterial;

    //private List<Collider2D> _interactedList;

    //private void Awake()
    //{
    //    _interactedList = new List<Collider2D>();
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (_interactedList.Contains(other)) return;
        
    //    if (other.CompareTag("Ball") && other.TryGetComponent<Ball>(out var ball) && ball.IsActivated)
    //    {
    //        _interactedList.Add(other);

    //        var ballPos = ball.transform.position;
    //        var fxPos = new Vector3(ballPos.x, ballPos.y, -0.5f);

    //        SoundController.Instance.PlayFX(SoundType.TriggerGoodGate);
    //        VFXSpawnController.Instance.SpawnVFX(VisualEffectType.Ex, fxPos,
    //            LevelController.Instance.CurrentLevel.transform, ballMaterial.color);

    //        ball.ChangeBallColor(ballMaterial);
    //    }
    //}
}