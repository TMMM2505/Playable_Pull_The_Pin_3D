#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.UI;

namespace Odeeo
{
    public class OdeeoEditorPopUp : MonoBehaviour
    {
        [SerializeField] private RectTransform rect;
        [SerializeField] private Canvas canvas;
        [SerializeField] private Button buttonSkip;

        private EditorPopUpData _data;
        private Vector2 _size;
        
        public void ShowPopUp(EditorPopUpData data)
        {
            _data = data;
            buttonSkip.onClick.AddListener(OnCloseButtonPressed);

            if (_data.PopUpType == OdeeoAdUnit.PopUpType.BannerPopUp)
                _size = new Vector2(320, 50);
            else
                _size = new Vector2(120, 120);

            SetPosition();
        }

        private void OnCloseButtonPressed()
        {
            _data.AdUnit.RemoveAd();
        }

        private void SetPosition()
        {
            float deviceScale = OdeeoSdk.GetDeviceScale();
            float canvasScaleFactor = canvas.scaleFactor;
            
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            
            float scaleMultiplier = 1f;
            
            Vector2 scaledSize = new Vector2(_size.x * deviceScale, _size.y * deviceScale);
            
            if (scaledSize.x > Screen.width)
                scaleMultiplier = Screen.width / scaledSize.x;
            if (scaledSize.y > Screen.height)
                scaleMultiplier = Screen.height / scaledSize.y;

            scaledSize *= scaleMultiplier;
            
            rect.sizeDelta = scaledSize / canvasScaleFactor;

            float xPos = _data.OffsetX * deviceScale;
            float yPos = _data.OffsetY * deviceScale;
            
            xPos = Mathf.Clamp(xPos, 0f, Screen.width - scaledSize.x);
            yPos = Mathf.Clamp(yPos, 0f, Screen.height - scaledSize.y);

            RectTransform buttonRect = buttonSkip.GetComponent<RectTransform>();
            if (buttonRect)
            {
                Vector2 baseSize = new Vector2(45f, 45f);
                buttonRect.sizeDelta = new Vector2(
                    baseSize.x * deviceScale / canvasScaleFactor,
                    baseSize.y * deviceScale / canvasScaleFactor);
            }

            Rect canvasPixelRect = canvas.pixelRect;
            switch (_data.IconPosition)
            {
                case OdeeoSdk.IconPosition.Centered:
                    rect.pivot = new Vector2(0.5f, 0.5f);
                    yPos = canvasPixelRect.height * 0.5f - yPos;
                    xPos = canvasPixelRect.width * 0.5f - xPos;
                    break;
                case OdeeoSdk.IconPosition.BottomLeft:
                    rect.pivot = Vector2.zero;
                    break;
                case OdeeoSdk.IconPosition.BottomRight:
                    rect.pivot = new Vector2(1f, 0f);
                    xPos = canvasPixelRect.width - xPos;
                    break;
                case OdeeoSdk.IconPosition.TopLeft:
                    rect.pivot = new Vector2(0f, 1f);
                    yPos = canvasPixelRect.height - yPos;
                    break;
                case OdeeoSdk.IconPosition.TopRight:
                    rect.pivot = new Vector2(1f, 1f);
                    yPos = canvasPixelRect.height - yPos;
                    xPos = canvasPixelRect.width - xPos;
                    break;
                case OdeeoSdk.IconPosition.CenterLeft:
                    rect.pivot = new Vector2(0f, 0.5f);
                    yPos = canvasPixelRect.height * 0.5f - yPos;
                    break;
                case OdeeoSdk.IconPosition.CenterRight:
                    rect.pivot = new Vector2(1f, 0.5f);
                    yPos = canvasPixelRect.height * 0.5f - yPos;
                    xPos = canvasPixelRect.width - xPos;
                    break;
                case OdeeoSdk.IconPosition.BottomCenter:
                    rect.pivot = new Vector2(0.5f, 0f);
                    xPos = canvasPixelRect.width * 0.5f - xPos;
                    break;
                case OdeeoSdk.IconPosition.TopCenter:
                    rect.pivot = new Vector2(0.5f, 1f);
                    xPos = canvasPixelRect.width * 0.5f - xPos;
                    yPos = canvasPixelRect.height - yPos;
                    break;
            }

            rect.position = new Vector3(xPos, yPos, 0);
        }

        private void OnDestroy()
        {
            buttonSkip.onClick.RemoveAllListeners();
            _data = null;
        }
    }

    public class EditorPopUpData
    {
        public OdeeoAdUnit AdUnit;
        public OdeeoAdUnit.PopUpType PopUpType;
        public OdeeoSdk.IconPosition IconPosition;
        public int OffsetX;
        public int OffsetY;
        public float OptimalDPI;
    }
}
#endif
