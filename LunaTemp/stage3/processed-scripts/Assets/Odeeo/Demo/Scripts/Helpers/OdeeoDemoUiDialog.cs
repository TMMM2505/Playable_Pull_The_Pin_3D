using UnityEngine;

namespace Odeeo.Demo
{
    public class OdeeoDemoUiDialog : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;

        [Space]
        [SerializeField] private OdeeoDemoUiElement closeButton;

        [SerializeField] private OdeeoDemoUiElement resetButton;
        [SerializeField] private OdeeoDemoUiElement applyButton;

        public void RemoveAllListeners()
        {
            closeButton.RemoveAllListeners();
            resetButton.RemoveAllListeners();
            applyButton.RemoveAllListeners();
        }
        
        public RectTransform RectTransform => rectTransform;
        public OdeeoDemoUiElement CloseButton => closeButton;
        
        public OdeeoDemoUiElement ResetButton => resetButton;
        public OdeeoDemoUiElement ApplyButton => applyButton;
    }
}
