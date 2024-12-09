using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Odeeo.Demo
{
    public class OdeeoDemoUiElement : MonoBehaviour
    {
        public static readonly Color ColorDefault = new Color(0.29f, 0.33f, 0.39f, 1f);
        public static readonly Color ColorWhite = new Color(1f, 1f, 1f, 1f);
        public static readonly Color ColorBlue = new Color(0.17f, 0.72f, 0.95f, 1f);
        public static readonly Color ColorGrey = new Color(0.7f, 0.71f, 0.76f, 0.6f);
        public static readonly Color ColorRed = new Color(0.83f, 0.06f, 0.23f, 1f);
        public static readonly Color ColorGreen = new Color(0.07f, 0.61f, 0.21f, 1f);
        public static readonly Color ColorLightGreen = new Color(0.82f, 1f, 0.85f, 1f);
        
        private static readonly Color ColorLabelActive = Color.black;
        private static readonly Color ColorLabelInactive = new Color(0.41f, 0.46f, 0.52f, 1f);
        
        private bool _isInteractable = true;

        [SerializeField] private Text label;
        [SerializeField] private Text valueText;
        [SerializeField] private Image colorBar;
        [SerializeField] private List<Image> images = new List<Image>();
        [SerializeField] private Image icon;

        private Button _button;
        private Slider _slider;
        private Scrollbar _scrollbar;
        private Dropdown _dropdown;

        private Color _enabledColor = ColorWhite;
        private Color _disabledColor = ColorGrey;

        private bool _isInitialized = false;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            if(_isInitialized)
                return;
            
            _isInitialized = true;
            
            _button = GetComponent<Button>();
            _slider = GetComponent<Slider>();
            _scrollbar = GetComponent<Scrollbar>();
            _dropdown = GetComponent<Dropdown>();

            if (_scrollbar && colorBar)
                _scrollbar.onValueChanged.AddListener(ColorSliderListener);
            
            if(_slider && valueText)
                _slider.onValueChanged.AddListener(ValueSliderListener);
        }

        private void ColorSliderListener(float value)
        {
            Color color = Color.HSVToRGB(value, 0.77f,0.93f);
            colorBar.color = color;
        }

        private void ValueSliderListener(float value)
        {
            valueText.text = Mathf.RoundToInt(value).ToString();
        }

        public void SetColor([Bridge.Ref] Color color)
        {
            for (int i = 0; i < images.Count; i++)
            {
                images[i].color = color;
            }

            if (colorBar)
                colorBar.color = color;
        }

        public void SetDefaultColors(Color enabledColor, bool tintDisabledColor = false)
        {
            _enabledColor = enabledColor;

            if (tintDisabledColor)
            {
                Color.RGBToHSV(enabledColor, out float h, out float s, out float v);
                _disabledColor = Color.HSVToRGB(h, 0.4f, v);
                _disabledColor.a = ColorGrey.a;
            }
        }
        
        public void SetText(string text)
        {
            if(label) label.text = text;
        }

        public void AddDropdownListener(UnityAction<int> listener)
        {
            Init();
            if(_dropdown) _dropdown.onValueChanged.AddListener(listener);
        }
        
        public void AddSliderListener(UnityAction<float> listener)
        {
            Init();
            if(_slider) _slider.onValueChanged.AddListener(listener);
        }
        
        public void AddListener(UnityAction listener)
        {
            Init();
            if(_button) _button.onClick.AddListener(listener);
        }

        public void RemoveAllListeners()
        {
            if(_dropdown) _dropdown.onValueChanged.RemoveAllListeners();
            if(_slider) _slider.onValueChanged.RemoveAllListeners();
            if(_button) _button.onClick.RemoveAllListeners();
        }

        public bool Interactable
        {
            get => _isInteractable;
            set
            {
                Init();
                
                _isInteractable = value;
                
                if (_slider) _slider.interactable = _isInteractable;
                if (_button) _button.interactable = _isInteractable;
                if (_dropdown) _dropdown.interactable = _isInteractable;

                if (!_button)
                {
                    if (_dropdown || _slider || _scrollbar)
                        if (label)
                            label.color = _isInteractable ? ColorLabelActive : ColorLabelInactive;

                    for (int i = 0; i < images.Count; i++)
                    {
                        images[i].color = _isInteractable ? _enabledColor : _disabledColor;
                    }
                }
            }
        }

        public Button Button
        {
            get
            {
                Init();
                return _button;
            }
        }

        public Scrollbar Scrollbar
        {
            get
            {
                Init();
                return _scrollbar;
            }
        }

        public float Value
        {
            get
            {
                Init();
                
                if (_slider)
                    return _slider.value;

                if (_scrollbar)
                    return _scrollbar.value;

                if (_dropdown)
                    return _dropdown.value;

                return 0f;
            }

            set
            {
                Init();
                
                if (_slider)
                    _slider.value = value;

                if (_scrollbar)
                    _scrollbar.value = value;

                if (_dropdown)
                    _dropdown.value = (int)value;
            }
        }

        public Dropdown Dropdown
        {
            get
            {
                Init();
                return _dropdown;
            }
        }

        public Image Icon => icon;
    }
}
