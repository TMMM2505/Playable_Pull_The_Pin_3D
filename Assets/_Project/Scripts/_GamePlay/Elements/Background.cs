using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class Background : MonoBehaviour
{
    public Transform SkinHolder;
    public GameObject tutorialBg;

    private void OnEnable()
    {
        EventController.ToggleTutorialBackground += EventController_ToggleTutorialBackground;
        EventController.CurrentThemeChanged += SetupBackgroundSkin;
    }

    private void OnDisable()
    {
        EventController.ToggleTutorialBackground -= EventController_ToggleTutorialBackground;
        EventController.CurrentThemeChanged -= SetupBackgroundSkin;
    }

    public void Start()
    {
        SetupBackgroundSkin();
    }

    private void EventController_ToggleTutorialBackground(bool status)
    {
        if (!LevelController.Instance.CurrentLevel.isShowTutorialBg) return;
        tutorialBg.SetActive(status);
    }

    private void SetupBackgroundSkin()
    {
        SkinHolder.Clear();
        foreach (var bgSkin in from themeData in ConfigController.ItemConfig.themeDataList
                 where themeData.Id == Data.CurrentThemeSkinId
                 select Instantiate(themeData.backgroundSkin, SkinHolder))
        {
            bgSkin.gameObject.SetActive(true);
        }
    }
}