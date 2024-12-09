using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMesh : MonoBehaviour
{
    [SerializeField] private Transform parent;
    private void OnBecameInvisible()
    {
        if (LevelController.Instance == null || GameManager.Instance.GameState != GameState.PlayingGame) return;
        if (LevelController.Instance.CurrentLevel != null && LevelController.Instance.CurrentLevel.Type == LevelType.Challenge)
        {
            if (LevelController.Instance.CurrentLevel is LevelChallenge levelChallenge && levelChallenge.CameraChallenge != null)
            {
                return;
            }
        }
        parent.gameObject.SetActive(false);       
    }
}
