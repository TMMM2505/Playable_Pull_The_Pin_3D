using UnityEngine;

public class OutsideZone2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball") || other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
