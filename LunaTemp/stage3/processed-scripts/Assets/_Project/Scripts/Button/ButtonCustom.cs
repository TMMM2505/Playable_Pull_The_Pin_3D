using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonCustom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Button.ButtonClickedEvent OnClick;
    public Button.ButtonClickedEvent OnPress;

    public bool CanClick = true;
    public bool HavePressEffect = true;
    [ReadOnly] public bool IsPoiterDown;
    [ReadOnly] public bool IsMoveEnter;
    [ReadOnly] public Vector3 LocalScale;
    private IPointerClickHandler _pointerClickHandlerImplementation;

    private void Awake()
    {
        LocalScale = transform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (CanClick)
        {
            OnPress?.Invoke();
            if (HavePressEffect) transform.DOScale(LocalScale-(Vector3.one*0.1f), .01f).SetUpdate(isIndependentUpdate:true).SetEase(Ease.OutQuint);
            IsMoveEnter = true;
            IsPoiterDown = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (CanClick)
        {
            transform.localScale = LocalScale;
            if (IsMoveEnter && IsPoiterDown)
            {
                IsPoiterDown = false;
            }
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsMoveEnter = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsMoveEnter = false;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (CanClick)
        {
            OnClick.Invoke();
            SoundController.Instance.PlayFX(SoundType.ButtonClick);
        }
    }
}