using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSkin : MonoBehaviour
{
    public MeshRenderer MeshRenderer;
    public List<Material> DeactivatedMaterials;
    public List<Material> ActivatedMaterials;

    private int _ballID;
    private Ball _parentBall;

    public void Setup(Ball ball, int ballID)
    {
        _ballID = ballID;
        _parentBall = ball;

        // if (_ballID == Data.CurrentBallSkinId)
        // {
        //     gameObject.SetActive(true);
        //     _parentBall.CurrentBallSkin = this;
        // }
        // else
        // {
        //     gameObject.SetActive(false);
        // }

        transform.rotation = Random.rotation;
    }

    public void Deactivating()
    {
        var rdMat = DeactivatedMaterials[Random.Range(0, DeactivatedMaterials.Count)];
        if (rdMat)
        {
            MeshRenderer.sharedMaterial = rdMat;
        }
    }

    public void Activating()
    {
        LevelEvent.OnBallActive?.Invoke();

        var rdMat = ActivatedMaterials[Random.Range(0, ActivatedMaterials.Count)];
        if (rdMat)
        {
            MeshRenderer.sharedMaterial = rdMat;
        }
    }

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

        if (_ballID == Data.CurrentBallSkinId)
        {
            _parentBall.gameObject.SetActive(false);
        }
    }

    public void ChangeActiveMaterial(Material newMaterial)
    {
        ActivatedMaterials.Clear();
        ActivatedMaterials.Add(newMaterial);
    }

    public Color GetMaterialColor()
    {
        return MeshRenderer.sharedMaterial.color;
    }
}