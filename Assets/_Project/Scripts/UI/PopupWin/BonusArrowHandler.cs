using System;
using UnityEngine;

public class BonusArrowHandler : MonoBehaviour
{
    public AreaItem CurrentAreaItem;
    public MoveObject MoveObject => GetComponent<MoveObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BonusArea"))
        {
            CurrentAreaItem = other.GetComponent<AreaItem>();
            CurrentAreaItem.ActivateBoderLight();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("BonusArea"))
        {
            other.GetComponent<AreaItem>().DeActivateBoderLight();
        }
    }
}