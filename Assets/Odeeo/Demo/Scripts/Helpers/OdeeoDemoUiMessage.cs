using System;
using UnityEngine;
using UnityEngine.UI;

namespace Odeeo.Demo
{
    public class OdeeoDemoUiMessage : MonoBehaviour
    {
        public enum MessageColor
        {
            Red,
            Green
        }
        
        [SerializeField] private Color textColorRed;
        [SerializeField] private Color textColorGreen;
        [SerializeField] private Text text;

        [Space]
        [SerializeField] private GameObject backRed;
        [SerializeField] private GameObject backGreen;

        [Space]
        [SerializeField] private RectTransform rect;
        [SerializeField] private CanvasGroup group;

        private OdAnimation _animation;
        private OdAnimation _delayedCall;
        private MessageColor _currentColor;

        public void Init(string message, MessageColor color)
        {
            _currentColor = color;
            
            gameObject.SetActive(true);
            group.alpha = 1f;
            
            text.text = message;
            text.color = color == MessageColor.Red ? textColorRed : textColorGreen;
            
            backRed.SetActive(color == MessageColor.Red);
            backGreen.SetActive(color == MessageColor.Green);

            rect.anchoredPosition = new Vector2(0f, 0f);
            rect.localScale = new Vector3(1f, 0f, 1f);

            OdeeoAnimator.AnimateFloat(0f, 1f, 0.15f, OdeeoAnimator.Ease.EaseOutSine)
                .OnUpdate((value) =>
                {
                    rect.localScale = new Vector3(1f, value, 1f);
                });

            _delayedCall = OdeeoAnimator.DelayedCall(3f, FadeOut);
        }

        private void FadeOut()
        {
            _animation = OdeeoAnimator.AnimateFloat(1f, 0f, 2f, OdeeoAnimator.Ease.Linear)
                .OnUpdate((value) => 
                { 
                    group.alpha = value; 
                });
        }

        private void OnDisable()
        {
            if (_delayedCall != null)
            {
                _delayedCall.Kill();
                _delayedCall = null;
            }
            
            if (_animation != null)
            {
                _animation.Kill();
                _animation = null;
            }
        }

        public RectTransform Rect => rect;
    }
}
