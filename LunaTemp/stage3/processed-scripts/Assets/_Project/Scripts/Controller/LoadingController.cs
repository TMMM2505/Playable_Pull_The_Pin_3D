using System;
using System.Collections;
using System.Globalization;
using DG.Tweening;
using I2.Loc;
//using Pancake.Monetization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_IOS
using Unity.Advertisement.IosSupport;
#endif

public class LoadingController : MonoBehaviour
{
    [SerializeField][Range(0, 5f)] private float timeLoading = 5f;
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI loadingText;

    private bool _flagDoneProgress;
    private AsyncOperation _operation;

    private void Start()
    {
        //FirebaseManager.OnStartLoading();
        //Advertising.TurnOffAppOpenAds();

        var stateOneTime = timeLoading / 3;
        var stateTwoTime = timeLoading / 3 * 2;

        DOTween.Sequence().AppendInterval(stateOneTime).AppendCallback(() =>
        {
            SceneManager.LoadScene(Constant.REMOTE_SCENE, LoadSceneMode.Additive);
        });

        DOTween.Sequence().AppendInterval(stateTwoTime).AppendCallback(() =>
        {
            SceneManager.LoadScene(Constant.DATA_SCENE, LoadSceneMode.Additive);
        });

        progressBar.fillAmount = 0;
        var loadingParameter = loadingText.GetComponent<LocalizationParamsManager>();
        progressBar.DOFillAmount(1, timeLoading)
            .OnUpdate(() =>
                loadingParameter.SetParameterValue("value", ((int)(progressBar.fillAmount * 100)).ToString()))
            .OnComplete(() =>
            {
#if UNITY_EDITOR
                SceneManager.LoadScene(Constant.GAMEPLAY_SCENE);
#else
                //StartCoroutine(LoadingGameScene());
#endif
            });
    }

    //private IEnumerator LoadingGameScene()
    //{
    //    yield return new WaitUntil(() => QDPRController.Instance.IsNotConsented || Advertising.IsInitialized);

    //    SceneManager.LoadScene(Constant.GAMEPLAY_SCENE);
    //}
}