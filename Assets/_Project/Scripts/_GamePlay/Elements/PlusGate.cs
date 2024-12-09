using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlusGate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI plusText;
    [SerializeField] public int plusNumb = 2;

    [SerializeField] private readonly List<ObjectCircle> _cacheTriggerBalls = new List<ObjectCircle>();
    public void OnDrawGizmos()
    {
        if (plusText != null)
        {
            plusText.text = $"+{plusNumb}";
        }
    }

    private void OnAddBall()
    {
        plusNumb--;
        if (plusNumb>0)
        {
            plusText.text = $"+{plusNumb}";
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            ObjectCircle tempObjectCircle = other.GetComponent<ObjectCircle>();
            if (tempObjectCircle)
            {
                if (plusNumb <= 0 || _cacheTriggerBalls.Contains(tempObjectCircle))
                {
                    return;
                }
                else
                {
                    SoundController.Instance.PlayFX(SoundType.TriggerGoodGate);
                    GameObject newObjectCircle = Instantiate(other.gameObject,other.transform.position+Vector3.down*.5f,Quaternion.identity, LevelController.Instance.CurrentLevel.transform);
                    _cacheTriggerBalls.Add(newObjectCircle.GetComponent<ObjectCircle>());
                    OnAddBall();
                    LevelEvent.OnMultipleBallChange?.Invoke();
                }
            }
        }
    }
}
