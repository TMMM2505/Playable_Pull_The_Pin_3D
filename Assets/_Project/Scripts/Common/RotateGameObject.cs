using UnityEngine;

public class RotateGameObject : MonoBehaviour
{
    [Header("Attributes")] [Range(0.1f, 100f)]
    public float Speed = 1f;

    public bool IsRotationX;
    public bool IsRotationY;
    public bool IsRotationZ;

    public void Update()
    {
        if (IsRotationX)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x + Time.unscaledDeltaTime * 90f * Speed,
                transform.eulerAngles.y, transform.eulerAngles.z);
        }

        if (IsRotationY)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                transform.eulerAngles.y + Time.unscaledDeltaTime * 90f * Speed, transform.eulerAngles.z);
        }

        if (IsRotationZ)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                transform.eulerAngles.y, transform.eulerAngles.z + Time.unscaledDeltaTime * 90f * Speed);
        }
    }
}