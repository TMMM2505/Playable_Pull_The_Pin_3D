using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Odeeo.Demo
{
    public class OdeeoDemoUiDebugController : MonoBehaviour,
        IPointerClickHandler,
        IPointerDownHandler,
        IDragHandler,
        ISelectHandler,
        IDeselectHandler
    {
        private RectTransform _rect;

        private OdeeoDemoUiDebugContainer _debugContainer;
        private RectTransform _canvasRect;

        private bool _isActive = false;

        private Vector2 _touchStartPosition;
        private Vector2 _touchStartDelta;
        private Vector2 _touchStartSize;

        private enum InteractionMode
        {
            None,
            Drag,
            Scale
        }

        private InteractionMode _currentInteractionMode = InteractionMode.None;

        private bool _isSelected;

        public void Initialize(Canvas canvas, OdeeoDemoUiDebugContainer debugContainer)
        {
            _canvasRect = canvas.GetComponent<RectTransform>();
            _debugContainer = debugContainer;

            _rect = GetComponent<RectTransform>();
            _isSelected = false;
        }

        public void SetActive(bool value)
        {
            _isActive = value;
            _debugContainer.SetVisible(value);

            if (_isActive)
                StartCoroutine(RescaleGizmo());
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_isSelected || !_isActive)
                return;

            List<GameObject> hovered = eventData.hovered;
            for (int i = 0; i < hovered.Count; i++)
            {
                if (hovered[i].name.Equals("scaleArrow"))
                {
                    _touchStartSize = _rect.sizeDelta;
                    _touchStartPosition = ScreenToCanvasPosition(_canvasRect, eventData.position);
                    _touchStartDelta = _rect.sizeDelta * 0.5f - _touchStartPosition;

                    _currentInteractionMode = InteractionMode.Scale;
                    return;
                }
            }

            _touchStartDelta = _rect.anchoredPosition - ScreenToCanvasPosition(_canvasRect, eventData.position);
            _currentInteractionMode = InteractionMode.Drag;
        }

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            if (!_isActive)
                return;

            EventSystem.current.SetSelectedGameObject(gameObject, pointerEventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!_isSelected || !_isActive)
                return;

            switch (_currentInteractionMode)
            {
                case InteractionMode.Drag:
                    UpdateDrag(eventData);
                    break;
                case InteractionMode.Scale:
                    UpdateScale(eventData);
                    break;
            }
        }

        private void UpdateDrag(PointerEventData eventData)
        {
            _rect.anchoredPosition = ScreenToCanvasPosition(_canvasRect, eventData.position) + _touchStartDelta;
        }

        private void UpdateScale(PointerEventData eventData)
        {
            Vector2 touchPosition = ScreenToCanvasPosition(_canvasRect, eventData.position);
            Vector2 touchDist = touchPosition - _touchStartPosition;
            Vector2 newSize = new Vector2(_touchStartSize.x + touchDist.x, _touchStartSize.y + touchDist.y * -1f);

            newSize.x = Mathf.Clamp(newSize.x, 24f, float.PositiveInfinity);
            newSize.y = Mathf.Clamp(newSize.y, 24f, float.PositiveInfinity);

            _rect.sizeDelta = newSize;

            StartCoroutine(RescaleGizmo());
        }

        public void OnSelect(BaseEventData eventData)
        {
            if (!_isActive)
                return;

            _debugContainer.SetSelected(true);
            _isSelected = true;

            StartCoroutine(RescaleGizmo());
        }

        public void OnDeselect(BaseEventData eventData)
        {
            _debugContainer.SetSelected(false);

            _isSelected = false;
        }

        private IEnumerator RescaleGizmo()
        {
            yield return new WaitForEndOfFrame();

            Vector2 sizeDelta = _rect.sizeDelta;
            _debugContainer.Rescale(sizeDelta);
        }

        private Vector2 ScreenToCanvasPosition(RectTransform canvasRect, Vector2 screenPos)
        {
            Vector2 canvasSizeDelta = canvasRect.sizeDelta;
            Vector2 pos = new Vector2();

            pos.x = canvasSizeDelta.x * (screenPos.x / Screen.width) - canvasSizeDelta.x * 0.5f;
            pos.y = canvasSizeDelta.y * (screenPos.y / Screen.height) - canvasSizeDelta.y * 0.5f;

            return pos;
        }
    }
}
