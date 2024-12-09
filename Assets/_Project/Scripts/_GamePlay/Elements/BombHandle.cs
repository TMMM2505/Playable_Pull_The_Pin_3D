using UnityEngine;

public class BombHandle : MonoBehaviour
{
    [SerializeField] private Bomb Bomb => GetComponentInParent<Bomb>();

    private void OnBecameInvisible()
    {
        if (LevelController.Instance == null) return;
        if (LevelController.Instance.CurrentLevel != null &&
            LevelController.Instance.CurrentLevel.Type == LevelType.Challenge)
        {
            if (LevelController.Instance.CurrentLevel is LevelChallenge levelChallenge &&
                levelChallenge.CameraChallenge != null)
            {
                return;
            }
        }

        if (Bomb != null)
        {
            Bomb.gameObject.SetActive(false);
        }
    }
}