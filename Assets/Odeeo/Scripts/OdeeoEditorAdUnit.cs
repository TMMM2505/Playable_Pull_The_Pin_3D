#if UNITY_EDITOR
using System.Collections;
using Odeeo.Data;
using Odeeo.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Odeeo
{
    internal class OdeeoEditorAdUnit : MonoBehaviour
    {
        private const string AD_POPUP_PREFAB_FILENAME = "OdeeoPopup.prefab";

        [SerializeField] private RectTransform rect;
        [SerializeField] private Canvas canvas;
        [SerializeField] private int playLength = 8;
        
        [Space]
        [SerializeField] private Text timerText;
        [SerializeField] private Button buttonAd;
        [SerializeField] private Button buttonAction;

        [Space]
        [SerializeField] private RectTransform actionButtonCloseImage;

        private RectTransform _buttonActionRect;

        private EditorAdUnitData _data;
        private OdeeoAdListener _adListener;
        
        private OdeeoEditorPopUp _popUp;

        private bool _isPaused = false;
        
        internal void Init(EditorAdUnitData data, OdeeoAdListener adListener)
        {
            _data = data;
            _adListener = adListener;
            
            buttonAd.onClick.AddListener(OnAdClicked);
            buttonAction.onClick.AddListener(OnActionClicked);

            _buttonActionRect = buttonAction.GetComponent<RectTransform>();
            
            if(data.Type != OdeeoSdk.PlacementType.AudioIconAd)
                buttonAction.gameObject.SetActive(false);

            StartCoroutine(Timer());
            
            SetPosition();
            SetActionButton();
            CreatePopUp();
            
            _adListener.OnAvailabilityChanged(false, new OdeeoAdData(_data.Type, _data.CustomTag));
            _adListener.OnShow();
            
            OdeeoImpressionData impressionData = new OdeeoImpressionData(_data.Type, _data.CustomTag);
            _adListener.OnImpression(impressionData);
        }

        private IEnumerator Timer()
        {
            int time = playLength;
            while (time > 0)
            {
                timerText.text = time.ToString();
                yield return new WaitForSeconds(1f);
                
                if(!_isPaused)
                    time--;
            }

            if (OdeeoAdManager.IsAdRewardedType(_data.Type))
                _adListener.OnReward(0);

            DestroyAd(OdeeoAdUnit.CloseReason.AdCompleted);
            
            yield return null;
        }

        internal void SetPause(bool isPaused, OdeeoAdUnit.StateChangeReason stateChangeReason)
        {
            _isPaused = isPaused;

            if (isPaused)
                _adListener.OnPause(stateChangeReason);
            else
                _adListener.OnResume(stateChangeReason);
        }

        internal void DestroyAd(OdeeoAdUnit.CloseReason reasonType)
        {
            _adListener.OnClose(reasonType);
            _adListener.OnAvailabilityChanged(true, new OdeeoAdData(_data.Type, _data.CustomTag));
            _adListener = null;

            StopAllCoroutines();

            if (_popUp) Destroy(_popUp.gameObject);
            _popUp = null;

            Destroy(gameObject);
        }

        private void OnAdClicked()
        {
            _adListener.OnClick();
        }

        private void OnActionClicked()
        {
            DestroyAd(OdeeoAdUnit.CloseReason.UserClose);
        }

        private void SetPosition()
        {
            float deviceScale = OdeeoSdk.GetDeviceScale();
            float canvasScaleFactor = canvas.scaleFactor;
            
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.anchorMin = new Vector2(0.5f, 0.5f);

            float scaleMultiplier = 1f;

            Vector2 scaledSize = new Vector2(_data.Size.x * deviceScale, _data.Size.y * deviceScale);
            
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

        private void SetActionButton()
        {
            float deviceScale = OdeeoSdk.GetDeviceScale();
            float canvasScaleFactor = canvas.scaleFactor;
            
            float buttonSize = 20f * deviceScale / canvasScaleFactor;
            Vector2 sizeDelta = new Vector2(buttonSize, buttonSize);
            _buttonActionRect.sizeDelta = sizeDelta;
            actionButtonCloseImage.sizeDelta = sizeDelta * 0.9f;

            switch (_data.ActionButtonPosition)
            {
                case OdeeoAdUnit.ActionButtonPosition.TopLeft:
                    _buttonActionRect.anchorMin = _buttonActionRect.anchorMax = new Vector2(0f, 1f);
                    _buttonActionRect.pivot = new Vector2(0f, 1f);
                    _buttonActionRect.anchoredPosition = Vector2.zero;
                    break;
                case OdeeoAdUnit.ActionButtonPosition.TopRight:
                    _buttonActionRect.anchorMin = _buttonActionRect.anchorMax = new Vector2(1f, 1f);
                    _buttonActionRect.pivot = new Vector2(1f, 1f);
                    _buttonActionRect.anchoredPosition = Vector2.zero;
                    break;
            }
        }

        private void CreatePopUp()
        {
            if (!OdeeoAdManager.IsAdRewardedType(_data.Type))
                return;

            string prefabPath = OdeeoEditorHelper.GetAssetBasedPath(AD_POPUP_PREFAB_FILENAME);
            if (string.IsNullOrEmpty(prefabPath))
            {
                OdeeoSdk.LogE(OdeeoSdk.LogLevel.Debug, "Can't find " + AD_POPUP_PREFAB_FILENAME + " asset");
                return;
            }

            OdeeoEditorPopUp logoPrefab = AssetDatabase.LoadAssetAtPath<OdeeoEditorPopUp>(prefabPath);
            _popUp = Instantiate(logoPrefab, Vector3.zero, Quaternion.identity);

            OdeeoAdUnit.PopUpType popupType = GetPopupType();

            EditorPopUpData popUpData = new EditorPopUpData();
            popUpData.AdUnit = _data.AdUnit;
            popUpData.PopUpType = popupType;
            popUpData.IconPosition = _data.PopupPosition ?? _data.IconPosition;
            popUpData.OffsetX = popupType == OdeeoAdUnit.PopUpType.IconPopUp ? _data.PopupOffsetX : 0;
            popUpData.OffsetY = popupType == OdeeoAdUnit.PopUpType.IconPopUp ? _data.PopupOffsetY : 0;
            popUpData.OptimalDPI = OdeeoSdk.GetScreenDPI();

            _popUp.ShowPopUp(popUpData);

            DontDestroyOnLoad(_popUp);
        }

        private OdeeoAdUnit.PopUpType GetPopupType()
        {
            if (_data.PopupType != null)
                return _data.PopupType.Value;
            
            if(OdeeoAdManager.IsBannerType(_data.Type))
                return OdeeoAdUnit.PopUpType.BannerPopUp;
            
            return OdeeoAdUnit.PopUpType.IconPopUp;
        }

        public void OnDestroy()
        {
            _data = null;
            buttonAd.onClick.RemoveAllListeners();
            buttonAction.onClick.RemoveAllListeners();
        }
    }

    public class EditorAdUnitData
    {
        public OdeeoAdUnit AdUnit;
        
        public OdeeoSdk.PlacementType Type;
        
        public OdeeoSdk.IconPosition IconPosition;
        public int OffsetX;
        public int OffsetY;
        public Vector2 Size;
        
        public OdeeoAdUnit.PopUpType? PopupType;
        public OdeeoSdk.IconPosition? PopupPosition;
        public int PopupOffsetX;
        public int PopupOffsetY;

        public string CustomTag;

        public OdeeoAdUnit.ActionButtonPosition ActionButtonPosition;
    }
}
#endif