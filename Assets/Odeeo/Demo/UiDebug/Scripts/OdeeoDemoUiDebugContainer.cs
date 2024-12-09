using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Odeeo.Demo
{
    public class OdeeoDemoUiDebugContainer : MonoBehaviour
    {
        [SerializeField] private Text label;
        [SerializeField] private RectTransform backImage;
        [SerializeField] private RectTransform scaleArrow;
        [SerializeField] private RectTransform dragIcon;

        private bool _isSelected = false;
        private bool _isVisible = false;

        public void SetText(string text)
        {
            label.text = text;
        }

        public void SetSelected(bool value)
        {
            _isSelected = value;

            UpdateView();
        }

        public void SetVisible(bool value)
        {
            _isVisible = value;

            if (!_isVisible)
                _isSelected = false;

            UpdateView();
        }

        public void Rescale(Vector2 size)
        {
            backImage.sizeDelta = size;
            scaleArrow.anchoredPosition = new Vector2(size.x * 0.5f, -size.y * 0.5f);
        }

        private void UpdateView()
        {
            backImage.gameObject.SetActive(_isVisible);
            label.gameObject.SetActive(_isVisible);
            scaleArrow.gameObject.SetActive(_isVisible && _isSelected);
            dragIcon.gameObject.SetActive(_isVisible && _isSelected);
        }
    }
}
