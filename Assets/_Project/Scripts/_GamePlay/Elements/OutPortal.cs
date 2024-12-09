using UnityEngine;
using Random = UnityEngine.Random;

public class OutPortal : MonoBehaviour
{
    [SerializeField, Range(0.0f, 1.0f)] private float appearRange;

    private Vector3 _portalPos;
    private const float MoveDuration = 0.7f;

    private void Awake()
    {
        _portalPos = transform.position;
    }

    public void TeleportObject(ObjectCircle teleportedObject)
    {
        var randomPos = Random.insideUnitCircle * appearRange;
        teleportedObject.transform.position =
            new Vector3(_portalPos.x + randomPos.x, _portalPos.y + randomPos.y, _portalPos.z);
        teleportedObject.BackToDefault(MoveDuration);
        
        SoundController.Instance.PlayFX(SoundType.OutPortal);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
        Gizmos.DrawSphere(transform.position, appearRange);
    }
#endif
}