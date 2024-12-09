using System;
using UnityEngine;

namespace Odeeo.Demo
{
    public class OdeeoDemoUiSimple : OdeeoDemoUiBase
    {
        [Serializable]
        public class SimpleSceneUiElements
        {
            public OdeeoDemoUiElement showIconAdButton;
            public OdeeoDemoUiElement showBannerAdButton;
            public OdeeoDemoUiElement showRewardedIconAdButton;
            public OdeeoDemoUiElement showRewardedBannerAdButton;
            public OdeeoDemoUiElement removeAdButton;
        }
        
        [Space]
        [SerializeField] private SimpleSceneUiElements simpleSceneElements;
        
        public override void RemoveAllListeners()
        {
            base.RemoveAllListeners();
            
            simpleSceneElements.showIconAdButton.RemoveAllListeners();
            simpleSceneElements.showBannerAdButton.RemoveAllListeners();
            simpleSceneElements.showRewardedIconAdButton.RemoveAllListeners();
            simpleSceneElements.showRewardedBannerAdButton.RemoveAllListeners();
            simpleSceneElements.removeAdButton.RemoveAllListeners();
        }
        
        public OdeeoDemoUiElement ShowIconAdButton => simpleSceneElements.showIconAdButton;
        public OdeeoDemoUiElement ShowBannerAdButton => simpleSceneElements.showBannerAdButton;
        public OdeeoDemoUiElement ShowRewardedIconAdButton => simpleSceneElements.showRewardedIconAdButton;
        public OdeeoDemoUiElement ShowRewardedBannerAdButton => simpleSceneElements.showRewardedBannerAdButton;
        public OdeeoDemoUiElement RemoveAdButton => simpleSceneElements.removeAdButton;
    }
}
