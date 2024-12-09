using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class PopupController : Singleton<PopupController>
{
    public Transform CanvasTransform;
    public CanvasScaler CanvasScaler;
    public List<Popup> Popups = new();

    private Dictionary<Type, Popup> _popupDictionary = new();
    private Popup _tempPopup;

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
        CanvasScaler.matchWidthOrHeight = Camera.main.aspect > .6f ? 1 : 0;
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        CanvasScaler.matchWidthOrHeight = Camera.main.aspect > .6f ? 1 : 0;
    }

    public void Show<T>(int index = 0, LevelType type = LevelType.Normal, bool isOpenNavigateBar = false)
    {
        var popup = Get<T>();
        if (popup != null && !popup.isActiveAndEnabled)
        {
            popup.Show(index, type, isOpenNavigateBar);
        }
    }

    public void Hide<T>()
    {
        var popup = Get<T>();
        if (popup != null && popup.isActiveAndEnabled)
        {
            popup.Hide();
        }
    }

    public void HideAll()
    {
        foreach (var item in _popupDictionary.Values.Where(item => item.isActiveAndEnabled))
        {
            item.Hide();
        }
    }

    public Popup Get<T>()
    {
        if (_popupDictionary.TryGetValue(typeof(T), out var popup))
        {
            return popup;
        }
        for (var i = 0; i < Popups.Count; i++)
        {
            if (Popups[i].GetType() == typeof(T))
            {
                var newPopup = Instantiate(Popups[i], CanvasTransform);
                newPopup.Initialize();
                newPopup.gameObject.SetActive(false);
                newPopup.Canvas.sortingOrder = i;
                _popupDictionary.Add(newPopup.GetType(), newPopup);

                return newPopup;
            }
        }

        return null;
    }
}