using UnityEngine;

public class TutorialGameObject : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(LevelController.Instance.LevelLoadingType == LevelLoadingType.NormalLevel);
    }
}