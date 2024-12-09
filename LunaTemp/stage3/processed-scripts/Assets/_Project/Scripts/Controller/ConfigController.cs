using UnityEngine;

public class ConfigController : MonoBehaviour
{
    [SerializeField] private GameConfig gameConfig;
    [SerializeField] private SoundConfig soundConfig;
    [SerializeField] private ItemConfig itemConfig;
    [SerializeField] private ChallengeConfig challengeConfig;
    [SerializeField] private GameEventConfig gameEventConfig;

    public static GameConfig Game;
    public static SoundConfig Sound;
    public static ItemConfig ItemConfig;
    public static ChallengeConfig ChallengeConfig;
    public static GameEventConfig GameEventConfig;

    private void Start()
    {
        Debug.Log("Config check");
        DontDestroyOnLoad(gameObject);

        Game = gameConfig;
        Sound = soundConfig;
        ItemConfig = itemConfig;
        ChallengeConfig = challengeConfig;
        GameEventConfig = gameEventConfig;

        ItemConfig.Initialize();
        // IAPConfig.Initialize();
        ChallengeConfig.Initialize();

        SoundController.Instance.Initialize();
        //PopupController.Instance.Initialize();
    }

    private void OnDestroy()
    {
        //IAPConfig.UnRegisterPurchaseSuccess();
    }
}