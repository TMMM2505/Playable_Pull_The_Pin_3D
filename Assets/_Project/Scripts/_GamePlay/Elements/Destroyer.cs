using UnityEngine;

public class Destroyer : MonoBehaviour, ILaser
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball") || other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
        }
    }

    public void InteractWithLaser()
    {
        // Do nothing
    }
}
