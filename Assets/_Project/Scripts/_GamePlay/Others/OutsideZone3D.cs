using UnityEngine;

public class OutsideZone3D : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") || other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
