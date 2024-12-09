using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using MoreMountains.NiceVibrations;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Level : MonoBehaviour
{
    [Header("Level Config")] public int ScoreWin;
    public LayerMask cameraLayerMask;

    [Header("Show TutorialBg Config")] public bool isShowTutorialBg = true;

    [Header("Read only attributes")] [ReadOnly]
    public int BonusCoin;

    [Header("Level normal type")] 
    public LevelNotificationType notificationType;
    public IconType iconType;
    [SerializeField] private bool usingCustomIcon;
    [SerializeField, ConditionalShow("usingCustomIcon", true)] public Sprite customImage;
    
    [Header("Read only attributes")]
    [ReadOnly] public int TotalScoreCanGet;
    [ReadOnly] public int InactiveBallsNumb;
    [ReadOnly] public int BallBreakNumb;
    [ReadOnly] public int BombExplodeNumb;
    [ReadOnly] public int PinDragNumb;
    [ReadOnly] public bool isGetEventItem;
    [SerializeField] [ReadOnly] private int currentScore;
    [SerializeField] [ReadOnly] private int totalCoin;

    private List<HolderCountElement> listHolderCount = new List<HolderCountElement>();
    private List<Ball> Balls => GetComponentsInChildren<Ball>().ToList();
    private float _timeBallStackDelay = .5f;
    private bool _isFingerDown;
    private List<Pin> _pintList;
    private Camera _mainCamera;
    private bool _isWining = false;

    public BallHolder BallHolder { get; private set; }
    public virtual LevelType Type => LevelType.Normal;

    private int GetNumberInactiveBalls()
    {
        return Balls.FindAll(item => !item.IsActivated).Count;
    }

    public int GetNumberActiveBalls()
    {
        return Balls.FindAll(item => item.IsActivated).Count;
    }

    public Ball GetRandomActiveBall()
    {
        var tempBalls = Balls.FindAll(item => item.IsActivated);
        return tempBalls[Random.Range(0, tempBalls.Count)];
    }

    protected virtual void Awake()
    {
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() => {
            _mainCamera = Camera.main;
        });

        _pintList = GetComponentsInChildren<Pin>().ToList();
        listHolderCount = GetComponentsInChildren<HolderCountElement>().ToList();
    }

    public void RefreshHolderCountElementList()
    {
        listHolderCount = GetComponentsInChildren<HolderCountElement>().ToList();
    }

    public virtual void Start()
    {
        SetupTutorial();

        BallHolder = GetComponentInChildren<BallHolder>();

        UpdateTotalScoreCanGet();

        InactiveBallsNumb = GetNumberInactiveBalls();

        LevelEvent.OnStackBall += OnStackBall;
    }

    public virtual void OnDestroy()
    {
        LevelEvent.OnStackBall -= OnStackBall;
    }

    private void OnEnable()
    {
        DoEnabled();
    }

    private void OnDisable()
    {
        DoDisabled();
    }

    protected virtual void DoEnabled()
    {
        Lean.Touch.LeanTouch.OnFingerDown += HandleFingerDown;
        Lean.Touch.LeanTouch.OnFingerUp += HandleFingerUp;
        Lean.Touch.LeanTouch.OnFingerUpdate += HandleFingerUpdate;
    }

    protected virtual void DoDisabled()
    {
        Lean.Touch.LeanTouch.OnFingerDown -= HandleFingerDown;
        Lean.Touch.LeanTouch.OnFingerUp -= HandleFingerUp;
        Lean.Touch.LeanTouch.OnFingerUpdate -= HandleFingerUpdate;
    }

    private void SetupTutorial()
    {
        foreach (var pin in _pintList)
        {
            if (pin.IsTutorialPin) pin.PullPin += Pin_PullPin;
            pin.SetupTutorialHand(!_pintList.Any(p => p.IsTutorialPin));
        }

        _pintList.FirstOrDefault(p => p.IsFirstTutorial)?.SetupTutorialHand(true);

        if (!_pintList.Any(p => p.IsTutorialPin))
        {
            EventController.ToggleTutorialBackground?.Invoke(false);
        }

        if (_pintList.Count(p => p.IsTutorialPin) == 1 || !isShowTutorialBg)
        {
            EventController.ToggleTutorialBackground?.Invoke(false);
            foreach (var pin in _pintList)
            {
                pin.IsPullAble = true;
            }
        }
    }

    private void Pin_PullPin(Pin pin)
    {
        if (pin.NextTutorialPin == null)
        {
            foreach (var p in _pintList)
            {
                p.IsPullAble = true;
            }
        }

        if (!pin.IsFirstTutorial && !_pintList.FirstOrDefault(p => p.IsFirstTutorial)!.PinPulled && isShowTutorialBg)
        {
            foreach (var p in _pintList) p.SetupTutorialHand(false);
        }
    }


    private void HandleFingerDown(Lean.Touch.LeanFinger finger)
    {
        if (finger.IsOverGui) return;

        _isFingerDown = true;
        RayElement(finger);
    }

    private void HandleFingerUp(Lean.Touch.LeanFinger finger)
    {
        _isFingerDown = false;
    }

    private void HandleFingerUpdate(Lean.Touch.LeanFinger finger)
    {
        if (!_isFingerDown) return;

        RayElement(finger);
    }

    private void RayElement(Lean.Touch.LeanFinger finger)
    {
        //Ray to move pin 2D
        var hit2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(finger.ScreenPosition),
            Mathf.Infinity, cameraLayerMask);

        if (hit2D.collider == null) return;

        if (hit2D.collider.CompareTag("Pin"))
        {
            hit2D.collider.GetComponentInParent<Pin>().ActivePin();
        }
    }

    private void OnStackBall()
    {
        if (_timeBallStackDelay > 0) return;
        MMVibrationManager.Haptic(HapticTypes.LightImpact);
        _timeBallStackDelay = .5f;
    }

    public virtual void Update()
    {
        if (_timeBallStackDelay > 0)
        {
            _timeBallStackDelay -= Time.deltaTime;
        }
    }

    public int CurrentScore
    {
        get => currentScore;
        set
        {
            currentScore = value;
            if (!_isWining && currentScore >= ScoreWin && (GameManager.Instance.GameState == GameState.PlayingGame ||
                                             GameManager.Instance.GameState == GameState.WaitingResult))
            {
                _isWining = true;
                OnWinGame();
            }
        }
    }

    
    
    protected void OnWinGame()
    {
        SoundController.Instance.PlayFX(SoundType.TargetSucceed);
        GameManager.Instance.OnWinGame();
    }

    public int TotalCoin
    {
        get => totalCoin;
        set
        {
            totalCoin = value;
            //LevelEvent.OnTotalCoinChange?.Invoke();
        }
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying) return;
        UpdateTotalScoreCanGetOnDrawGizmos();
    }

    protected virtual void UpdateTotalScoreCanGetOnDrawGizmos()
    {
        var tempListHolderCount = GetComponentsInChildren<HolderCountElement>().ToList();
        TotalScoreCanGet = 0;
        foreach (var item in tempListHolderCount)
        {
            if (item.GetComponent<Ball>()) TotalScoreCanGet += item.GetComponent<Ball>().TotalScore;
            else TotalScoreCanGet += item.totalScore;
        }
    }

    public virtual void UpdateTotalScoreCanGet()
    {
        TotalScoreCanGet = 0;
        Debug.Log("check 4");
        foreach (var item in listHolderCount)
        {
            if (item.gameObject.activeSelf)
            {
                TotalScoreCanGet += item.totalScore;
            }
        }
        
        if (Application.isPlaying && GameManager.Instance.GameState == GameState.PlayingGame &&
            ScoreWin > TotalScoreCanGet)
        {
            GameManager.Instance.OnLoseGame();
        }
    }
    
    public virtual async Task CheckingLoseLevel(float timeDelay)
    {
        await Task.Delay((int)timeDelay * 1000);
        if (listHolderCount.Any(item => item.gameObject.activeSelf && item.GetActiveState() && !item.GetArchiveState()))
        {
            return;
        }
        GameManager.Instance.OnLoseGame();
    }
}