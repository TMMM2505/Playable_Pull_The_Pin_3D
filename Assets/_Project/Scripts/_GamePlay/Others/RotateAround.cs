using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private bool isRotateLeft;

    void Update()
    {
        float currentAngleZ = transform.eulerAngles.z;
        if (currentAngleZ > 180) currentAngleZ -= 360;
        float rot = currentAngleZ + rotateSpeed * Time.deltaTime * (isRotateLeft ? -1f : 1f);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rot);
    }
}