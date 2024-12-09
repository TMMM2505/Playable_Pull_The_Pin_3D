using UnityEngine;
using DG.Tweening;
using Pancake;

public class Popup : MonoBehaviour
{
    public bool useAnimation;
    public GameObject Background;

    public ShowAnimationType ShowAnimationType;

    public bool UseHideAnimation;

    public HideAnimationType HideAnimationType;

    private CanvasGroup CanvasGroup => GetComponent<CanvasGroup>();
    public Canvas Canvas => GetComponent<Canvas>();

    public virtual void Show(int index = 0, LevelType type = LevelType.Normal, bool isOpenNavigateBar = false)
    {
        BeforeShow();
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        BeforeHide();
    }

    public virtual void Initialize()
    {
    }

    protected virtual void BeforeShow()
    {
    }

    protected virtual void AfterShown()
    {
    }

    protected virtual void BeforeHide()
    {
    }

    protected virtual void AfterHidden()
    {
    }
}

public enum ShowAnimationType
{
    OutBack,
    Flip,
    Fade,
}

public enum HideAnimationType
{
    InBack,
    Fade,
}