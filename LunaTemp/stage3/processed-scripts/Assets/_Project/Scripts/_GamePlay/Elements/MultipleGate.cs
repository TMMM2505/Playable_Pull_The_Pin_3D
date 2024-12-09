using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class MultipleGate : MonoBehaviour
{
    public TextMeshProUGUI MultiplyText;
    public int MultiplyNumb = 2;

    [SerializeField] private readonly List<ObjectCircle> _cacheTriggerBalls = new List<ObjectCircle>();

    public void OnDrawGizmos()
    {
        if (MultiplyText)
        {
            MultiplyText.text = $"X{MultiplyNumb}";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var holderCountElement = other.GetComponent<HolderCountElement>(); 
        if (holderCountElement != null)
        {
            ObjectCircle tempObjectCircle = other.GetComponent<ObjectCircle>();
            
            if (tempObjectCircle)
            {
                if (_cacheTriggerBalls.Contains(tempObjectCircle)) return;

                SoundController.Instance.PlayFX(SoundType.TriggerGoodGate);
                for (int i = 0; i < MultiplyNumb - 1; i++)
                {
                    GameObject newObjectCircle = Instantiate(other.gameObject,
                        other.transform.position + Vector3.down * .5f, Quaternion.identity,
                        LevelController.Instance.CurrentLevel.transform);
                    _cacheTriggerBalls.Add(newObjectCircle.GetComponent<ObjectCircle>());
                    _cacheTriggerBalls.Add(tempObjectCircle);
                }

                LevelEvent.OnMultipleBallChange?.Invoke();
            }
        }
    }
}