using UnityEngine;

public class InPortal : MonoBehaviour
{
    [SerializeField] private OutPortal outPortal;
    [SerializeField] private float moveDuration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<ObjectCircle>(out var suckableObject))
        {
            SoundController.Instance.PlayFX(SoundType.InPortal);
            suckableObject.BeingPulledInPortal(this, moveDuration, () => TeleportCallback(suckableObject));
        }
    }

    private void TeleportCallback(ObjectCircle teleportedObject)
    {
        outPortal.TeleportObject(teleportedObject);
    }
}