using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CurrencyCounter : MonoBehaviour
{
    public TextMeshProUGUI CurrencyAmountText;
    public int StepCount = 10;
    public float DelayTime = .01f;
    public CurrencyGenerate CurrencyGenerate;

    private int _currentCoin;
    private GameObject _customFrom;

    private void Awake()
    {
        EventController.CustomCurrencyChange += CustomCurrencyChange;
        EventController.SaveCurrencyTotal += SaveCurrency;
        EventController.CurrencyTotalChanged += UpdateCurrencyAmountText;
    }

    private void Start()
    {
        // EventController.CustomCurrencyChange += CustomCurrencyChange;
        // EventController.SaveCurrencyTotal += SaveCurrency;
        // EventController.CurrencyTotalChanged += UpdateCurrencyAmountText;
        //CurrencyAmountText.text = Data.CurrencyTotal.ToString();
    }

    private void CustomCurrencyChange(GameObject from)
    {
        _customFrom = from;
    }

    private void SaveCurrency()
    {
        //_currentCoin = Data.CurrencyTotal;
    }

    private void UpdateCurrencyAmountText()
    {
        //if (Data.CurrencyTotal > _currentCoin)
        //{
        //    if (_customFrom != null)
        //    {
        //        IncreaseCurrency(_customFrom, null, 10);
        //        _customFrom = null;
        //    }
        //    else
        //    {
        //        IncreaseCurrency();
        //    }

        //    DailyTaskController.Instance.DoDailyTask(DailyTaskType.GetCoin, Data.CurrencyTotal - _currentCoin);
        //}
        //else
        //{
        //    DecreaseCurrency();
        //}
    }

    private void IncreaseCurrency(GameObject from = null, GameObject to = null, int coinNumber = -1)
    {
        //var isPopupUIActive = PopupController.Instance.Get<PopupUI>().isActiveAndEnabled;
        //if (!isPopupUIActive) PopupController.Instance.Show<PopupUI>();

        //var isFirstMove = false;
        //CurrencyGenerate.GenerateCoin(() =>
        //{
        //    if (isFirstMove) return;
        //    isFirstMove = true;

        //    var currentCurrencyAmount = int.Parse(CurrencyAmountText.text);
        //    var nextAmount = (Data.CurrencyTotal - currentCurrencyAmount) / StepCount;
        //    var step = StepCount;

        //    CurrencyTextCount(currentCurrencyAmount, nextAmount, step);
        //}, () =>
        //{
        //    if (!isPopupUIActive) PopupController.Instance.Hide<PopupUI>();
        //}, from, to, coinNumber);
    }

    private void DecreaseCurrency()
    {
        //var currentCurrencyAmount = int.Parse(CurrencyAmountText.text);
        //var nextAmount = (Data.CurrencyTotal - currentCurrencyAmount) / StepCount;
        //var step = StepCount;
        //CurrencyTextCount(currentCurrencyAmount, nextAmount, step);
    }

    private void CurrencyTextCount(int currentCurrencyValue, int nextAmountValue, int stepCount)
    {
        //if (stepCount == 0)
        //{
        //    CurrencyAmountText.text = Data.CurrencyTotal.ToString();
        //    return;
        //}

        //var totalValue = currentCurrencyValue + nextAmountValue;
        //DOTween.Sequence().AppendInterval(DelayTime).SetUpdate(isIndependentUpdate: true)
        //    .AppendCallback(() => { CurrencyAmountText.text = totalValue.ToString(); }).AppendCallback(() =>
        //    {
        //        CurrencyTextCount(totalValue, nextAmountValue, stepCount - 1);
        //    });
    }
}