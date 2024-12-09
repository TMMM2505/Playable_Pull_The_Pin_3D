using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class BannerCollapsible : MonoBehaviour
{
    [SerializeField] private float offSetX;
    [SerializeField] private float offSetY;

    private float _positionX;
    private float _positionY;
    private RectTransform _rectTransform => GetComponent<RectTransform>();

    private void Awake()
    {
        _positionX = _rectTransform.anchoredPosition.x;
        _positionY = _rectTransform.anchoredPosition.y;
        EventController.HideCollapsibleBanner += SetupHide;
        EventController.ShowCollapsibleBanner += SetupShow;
    }

    private void OnDestroy()
    {
        EventController.HideCollapsibleBanner -= SetupHide;
        EventController.ShowCollapsibleBanner -= SetupShow;
    }

    private void SetupHide()
    {
        _rectTransform.anchoredPosition = new Vector3(_positionX, _positionY);
    }
    
    private void SetupShow(bool isBottom)
    {
        if (!isBottom)
        {
            _rectTransform.anchoredPosition = new Vector3(_positionX + offSetX, _positionY + offSetY);
        }
    }
}