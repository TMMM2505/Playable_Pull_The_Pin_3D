using UnityEngine;

public class EventCollectionItem : ObjectCircle
{
    void Start()
    {
        var eventGameData = ConfigController.GameEventConfig.GetGameEventData(GameEventType.Noel2023);
        if (eventGameData.IsExpired())
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            LevelController.Instance.CurrentLevel.isGetEventItem = true;
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.CompareTag("BallHolder"))
        {
            VFXSpawnController.Instance.SpawnVFX(VisualEffectType.CollectHalloweenItem,
                other.ClosestPoint(transform.position) + Vector2.down * 1.5f, LevelController.Instance.transform);
        }
    }
}