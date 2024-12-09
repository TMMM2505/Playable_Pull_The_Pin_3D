using DG.Tweening;
using TMPro;
using UnityEngine;

public class CoinTotal : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyTotal;

    private void Awake()
    {
        EventController.CurrencyTotalChanged += UpdateCurrencyText;
        UpdateCurrencyText();
    }

    private void UpdateCurrencyText()
    {
        //DOTween.Sequence().AppendCallback(() =>
        //{
        //    currencyTotal.text = Data.CurrencyTotal.ToString();
        //}).SetUpdate(isIndependentUpdate: true);
        
    }
}
