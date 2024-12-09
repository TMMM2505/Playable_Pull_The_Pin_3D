using System;
using System.Collections.Generic;
using UnityEngine;

namespace Odeeo.Demo
{
    public class OdeeoDemoUiBase : MonoBehaviour
    {
        public enum InitializationState
        {
            Default,
            InProgress,
            Initialized
        }
        
        [Serializable]
        public class GeneralElements
        {
            public Canvas canvas;
            public OdeeoDemoUiElement initializeButton;
            
            [Header("Messages")]
            [Space]
            public OdeeoDemoUiMessage messagePrefab;
            public RectTransform messagesContainer;
            
            [Header("UI Debug")]
            [Space]
            public OdeeoDemoUiDebugContainer OdeeoDemoUiDebugContainerPrefab;
        }
        
        [Header("Demo Scenes Helper Object")]

        [Space]
        [SerializeField] protected GeneralElements generalElements;
        
        // Messages
        private readonly List<OdeeoDemoUiMessage> _messages = new List<OdeeoDemoUiMessage>();
        private readonly List<OdeeoDemoUiMessage> _messagesPool = new List<OdeeoDemoUiMessage>();
        private OdAnimation _clearCall;
        
        // Safe Area
        private Vector2 _containerBaseSize;
        private ScreenOrientation _screenOrientation;
        private int _screenHeight;
        
        private InitializationState _initializationState;
        
        public virtual void Init()
        {
            _containerBaseSize = GetComponent<RectTransform>().sizeDelta;
            ApplySafeArea();
        }
        
        private void ApplySafeArea()
        {
            _screenOrientation = Screen.orientation;
            _screenHeight = Screen.height;
            
            Rect safeArea = Screen.safeArea;
            float ratio = generalElements.canvas.GetComponent<RectTransform>().sizeDelta.y / Screen.height;
            
            float topAreaPixels = Screen.height - safeArea.y - safeArea.height;
            float topShift = topAreaPixels * ratio;
            
            RectTransform containerRect = GetComponent<RectTransform>();
            containerRect.sizeDelta = new Vector2(_containerBaseSize.x, _containerBaseSize.y - topShift);
            containerRect.anchoredPosition = new Vector2(0f, containerRect.sizeDelta.y * -0.5f - topShift);
        }
        
        public void SetInitializationState(InitializationState state)
        {
            switch (state)
            {
                case InitializationState.Default:
                    InitializeButton.Interactable = true;
                    InitializeButton.SetText("INITIALIZE");
                    InitializeButton.Icon.gameObject.SetActive(false);
                    break;
                case InitializationState.InProgress:
                    InitializeButton.Interactable = true;
                    InitializeButton.SetText("INITIALIZATION...");
                    InitializeButton.Icon.gameObject.SetActive(true);
                    break;
                case InitializationState.Initialized:
                    InitializeButton.Interactable = false;
                    InitializeButton.SetText("INITIALIZED");
                    InitializeButton.Icon.gameObject.SetActive(false);
                    break;
            }
            
            _initializationState = state;
        }
        
        private void Update()
        {
            if (_screenHeight != Screen.height || _screenOrientation != Screen.orientation)
                ApplySafeArea();

            if (_initializationState == InitializationState.InProgress)
            {
                InitializeButton.Icon.transform.localRotation = Quaternion.Euler(0f, 0f, InitializeButton.Icon.transform.localRotation.eulerAngles.z + 360f * Time.deltaTime);
            }
        }

        #region Messages

        public void ShowMessage(string message, OdeeoDemoUiMessage.MessageColor color)
        {
            MoveMessages();
            
            OdeeoDemoUiMessage messageElement;
            if (_messagesPool.Count > 0)
            {
                messageElement = _messagesPool[_messagesPool.Count - 1];
                _messagesPool.RemoveAt(_messagesPool.Count - 1);
            }
            else
            {
                messageElement = Instantiate(generalElements.messagePrefab, generalElements.messagesContainer);
            }

            messageElement.Init(message, color);
            
            _messages.Add(messageElement);
        }

        private void MoveMessages()
        {
            if (_clearCall != null)
            {
                _clearCall.Kill();
                _clearCall = null;
            }
            
            for (int i = 0; i < _messages.Count; i++)
            {
                OdeeoDemoUiMessage message = _messages[_messages.Count - 1 - i];
                message.Rect.OdAnchoredMove(new Vector2(0f, -120f * (i + 1)), 0.15f, OdeeoAnimator.Ease.EaseOutSine);
            }
            
            _clearCall = OdeeoAnimator.DelayedCall(0.2f, ClearMessages);
        }

        private void ClearMessages()
        {
            for (int i = _messages.Count - 1; i >= 0; i--)
            {
                OdeeoDemoUiMessage message = _messages[i];
                if (message.Rect.anchoredPosition.y * -1 > generalElements.messagesContainer.sizeDelta.y)
                {
                    _messages.RemoveAt(i);
                    
                    message.gameObject.SetActive(false);
                    _messagesPool.Add(message);
                }
            }

            _clearCall = null;
        }

        #endregion

        public virtual void RemoveAllListeners()
        {
            generalElements.initializeButton.RemoveAllListeners();
        }
        
        public OdeeoDemoUiElement InitializeButton => generalElements.initializeButton;
    }
}
