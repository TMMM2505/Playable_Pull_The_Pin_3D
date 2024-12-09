using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Odeeo.Demo
{
    public class OdeeoDemoUiAdvanced : OdeeoDemoUiBase
    {
        [Serializable]
        public class AdvancedSceneUiElements
        {
            public OdeeoDemoUiElement positionDropdown;
            public OdeeoDemoUiElement adTypeDropdown;
        
            [Header("Icon Settings")]
            [Space]
            public OdeeoDemoUiElement iconSettingsButton;
            public OdeeoDemoUiElement linkTypeDropdown;

            [Header("Visual Settings")]
            [Space]
            public OdeeoDemoUiElement visualSettingsButton;

            [Header("Control")]
            [Space]
            public OdeeoDemoUiElement createAdButton;
            public OdeeoDemoUiElement isAdAvailableButton;
            public OdeeoDemoUiElement showOrRemoveAdButton;
            
            [Header("PopUp Settings")]
            [Space]
            public OdeeoDemoUiElement popupSettingsButton;

            [Header("Dialog Icon Settings")]
            [Space]
            public OdeeoDemoUiDialog iconSettingsDialog;
            public OdeeoDemoUiElement iconSizeSlider;
            public OdeeoDemoUiElement iconOffsetSliderX;
            public OdeeoDemoUiElement iconOffsetSliderY;

            [Header("Dialog Visual Settings")]
            [Space]
            public OdeeoDemoUiDialog visualSettingsDialog;
            public OdeeoDemoUiElement mainColorSlider;
            public OdeeoDemoUiElement backgroundColorSlider;
            public OdeeoDemoUiElement progressColorSlider;

            [Header("Dialog PopUp Settings")]
            [Space]
            public OdeeoDemoUiDialog popupSettingsDialog;
            public OdeeoDemoUiElement popupTypeDropdown;
            public OdeeoDemoUiElement popupPositionDropdown;
            public OdeeoDemoUiElement popupOffsetSliderX;
            public OdeeoDemoUiElement popupOffsetSliderY;
            
            [Header("Dialogs Addition")]
            [Space]
            public Image dialogsBackImage;
            public Button dialogsBackButton;
        }
        
        [Space]
        [SerializeField] private AdvancedSceneUiElements advancedSceneElements;
        
        // Dialogs
        private Color _dialogsBackColor;
        private OdAnimation _dialogAnimation;
        private OdAnimation _dialogBackAnimation;
        private RectTransform _currentDialog;

        public override void Init()
        {
            InitDialogs();
            base.Init();
        }
        
        private void InitDialogs()
        {
            _dialogsBackColor = advancedSceneElements.dialogsBackImage.color;
            advancedSceneElements.dialogsBackButton.onClick.AddListener(CloseCurrentDialog);
            advancedSceneElements.dialogsBackImage.rectTransform.sizeDelta = generalElements.canvas.GetComponent<RectTransform>().sizeDelta;

            advancedSceneElements.iconSettingsDialog.CloseButton.AddListener(CloseCurrentDialog);
            advancedSceneElements.visualSettingsDialog.CloseButton.AddListener(CloseCurrentDialog);
            advancedSceneElements.popupSettingsDialog.CloseButton.AddListener(CloseCurrentDialog);
        }
        
        public override void RemoveAllListeners()
        {
            base.RemoveAllListeners();

            advancedSceneElements.positionDropdown.RemoveAllListeners();
            advancedSceneElements.adTypeDropdown.RemoveAllListeners();

            advancedSceneElements.iconSettingsButton.RemoveAllListeners();
            advancedSceneElements.linkTypeDropdown.RemoveAllListeners();
            
            advancedSceneElements.visualSettingsButton.RemoveAllListeners();
            
            advancedSceneElements.createAdButton.RemoveAllListeners();
            advancedSceneElements.isAdAvailableButton.RemoveAllListeners();
            advancedSceneElements.showOrRemoveAdButton.RemoveAllListeners();
            
            advancedSceneElements.popupSettingsButton.RemoveAllListeners();

            // Icon settings dialog
            advancedSceneElements.iconSizeSlider.RemoveAllListeners();
            advancedSceneElements.iconOffsetSliderX.RemoveAllListeners();
            advancedSceneElements.iconOffsetSliderY.RemoveAllListeners();
            advancedSceneElements.iconSettingsDialog.RemoveAllListeners();
            
            // Visual settings dialog
            advancedSceneElements.mainColorSlider.RemoveAllListeners();
            advancedSceneElements.backgroundColorSlider.RemoveAllListeners();
            advancedSceneElements.progressColorSlider.RemoveAllListeners();
            advancedSceneElements.visualSettingsDialog.RemoveAllListeners();
            
            // PopUp settings dialog
            advancedSceneElements.popupTypeDropdown.RemoveAllListeners();
            advancedSceneElements.popupPositionDropdown.RemoveAllListeners();
            advancedSceneElements.popupOffsetSliderX.RemoveAllListeners();
            advancedSceneElements.popupOffsetSliderY.RemoveAllListeners();
            advancedSceneElements.popupSettingsDialog.RemoveAllListeners();
        }
        
        public void ShowDialog(RectTransform dialog)
        {
            _currentDialog = dialog;
            _currentDialog.gameObject.SetActive(true);
            _currentDialog.anchoredPosition = new Vector2(0f, 950f);

            _dialogAnimation = _currentDialog
                .OdAnchoredMove(new Vector2(0f, 0f), 0.3f, OdeeoAnimator.Ease.EaseOutBack)
                .OnComplete(() => _dialogAnimation = null);

            _dialogsBackColor.a = 0f;
            advancedSceneElements.dialogsBackImage.color = _dialogsBackColor;
            advancedSceneElements.dialogsBackImage.gameObject.SetActive(true);

            _dialogBackAnimation = OdeeoAnimator.AnimateFloat(0f, 0.8f, 0.3f, OdeeoAnimator.Ease.Linear)
                .OnUpdate((value) =>
                {
                    _dialogsBackColor.a = value;
                    advancedSceneElements.dialogsBackImage.color = _dialogsBackColor;
                })
                .OnComplete(() => { _dialogBackAnimation = null; });
        }

        public void CloseCurrentDialog()
        {
            if (!_currentDialog)
                return;

            if (_dialogAnimation != null)
                return;

            if (_dialogBackAnimation != null)
                return;

            _currentDialog
                .OdAnchoredMove(new Vector2(0f, 900f), 0.3f, OdeeoAnimator.Ease.EaseInBack)
                .OnComplete(() =>
                {
                    _currentDialog.gameObject.SetActive(false);
                    _currentDialog = null;
                });

            _dialogBackAnimation = OdeeoAnimator.AnimateFloat(0.8f, 0f, 0.3f, OdeeoAnimator.Ease.Linear)
                .OnUpdate((value) =>
                {
                    _dialogsBackColor.a = value;
                    advancedSceneElements.dialogsBackImage.color = _dialogsBackColor;
                })
                .OnComplete(() =>
                {
                    advancedSceneElements.dialogsBackImage.gameObject.SetActive(false);
                    _dialogBackAnimation = null;
                });
        }

        internal void FillPositionsDropdown(OdeeoDemoUiElement dropdown, Enum positionEnum)
        {
            List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
            string[] enumNames = Enum.GetNames(positionEnum.GetType());
            
            for (int i = 0; i < enumNames.Length; i++)
            {
                options.Add(new Dropdown.OptionData { text = enumNames[i] });
            }

            dropdown.Dropdown.ClearOptions();
            dropdown.Dropdown.options = options;
        }
        
        // Main
        public OdeeoDemoUiElement PositionDropdown => advancedSceneElements.positionDropdown;
        public OdeeoDemoUiElement ADTypeDropdown => advancedSceneElements.adTypeDropdown;
        
        // Icon Settings
        public OdeeoDemoUiElement IconSettingsButton => advancedSceneElements.iconSettingsButton;
        public OdeeoDemoUiElement LinkTypeDropdown => advancedSceneElements.linkTypeDropdown;

        // Visual Settings
        public OdeeoDemoUiElement VisualSettingsButton => advancedSceneElements.visualSettingsButton;
        
        // Control
        public OdeeoDemoUiElement CreateAdButton => advancedSceneElements.createAdButton;
        public OdeeoDemoUiElement IsAdAvailableButton => advancedSceneElements.isAdAvailableButton;
        public OdeeoDemoUiElement ShowOrRemoveAdButton => advancedSceneElements.showOrRemoveAdButton;

        // PopUp Settings
        public OdeeoDemoUiElement PopupSettingsButton => advancedSceneElements.popupSettingsButton;
        
        // Dialog Icon
        public OdeeoDemoUiDialog IconSettingsDialog => advancedSceneElements.iconSettingsDialog;
        public OdeeoDemoUiElement IconSizeSlider => advancedSceneElements.iconSizeSlider;
        public OdeeoDemoUiElement IconOffsetSliderX => advancedSceneElements.iconOffsetSliderX;
        public OdeeoDemoUiElement IconOffsetSliderY => advancedSceneElements.iconOffsetSliderY;

        // Dialog Visual
        public OdeeoDemoUiDialog VisualSettingsDialog => advancedSceneElements.visualSettingsDialog;
        public OdeeoDemoUiElement MainColorSlider => advancedSceneElements.mainColorSlider;
        public OdeeoDemoUiElement BackgroundColorSlider => advancedSceneElements.backgroundColorSlider;
        public OdeeoDemoUiElement ProgressColorSlider => advancedSceneElements.progressColorSlider;
        
        // Dialog Popup
        public OdeeoDemoUiDialog PopupSettingsDialog => advancedSceneElements.popupSettingsDialog;
        public OdeeoDemoUiElement PopupTypeDropdown => advancedSceneElements.popupTypeDropdown;
        public OdeeoDemoUiElement PopupPositionDropdown => advancedSceneElements.popupPositionDropdown;
        public OdeeoDemoUiElement PopupOffsetSliderX => advancedSceneElements.popupOffsetSliderX;
        public OdeeoDemoUiElement PopupOffsetSliderY => advancedSceneElements.popupOffsetSliderY;
        
        // Ui Debug
        public OdeeoDemoUiDebugContainer UIDebugContainerPrefab => generalElements.OdeeoDemoUiDebugContainerPrefab;
        public OdeeoDemoUiDebugController RectDebugController { get; set; }
        public OdeeoDemoUiDebugController AnchorDebugController { get; set; }
    }
}
