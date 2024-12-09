using System;
using System.Threading.Tasks;
using DG.Tweening;
using Lean.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

public class CurrencyGenerate : MonoBehaviour
{
    public GameObject overlay;
    public GameObject coinPrefab;
    public GameObject from;
    public GameObject to;
    public int numberCoin;
    public int delay;
    public float durationNear;
    public float durationTarget;
    public Ease easeNear;
    public Ease easeTarget;
    public float scale = 1;
    private int _numberCoinMoveDone;
    private Action _moveOneCoinDone;
    private Action _moveAllCoinDone;
    private GameObject _defaultFrom;
    private GameObject _defaultTo;
    private int _defaultCoinNumber;

    private void Awake()
    {
        _defaultFrom = from;
        _defaultTo = to;
        _defaultCoinNumber = numberCoin;
    }

    private void Start()
    {
        overlay.SetActive(false);
    }

    public async void GenerateCoin(System.Action moveOneCoinDone, System.Action moveAllCoinDone, GameObject fromObject = null,
        GameObject toObject = null, int coinNumber = -1)
    {
        _moveOneCoinDone = moveOneCoinDone;
        _moveAllCoinDone = moveAllCoinDone;
        from = fromObject == null ? _defaultFrom : fromObject;
        to = toObject == null ? _defaultTo : toObject;
        numberCoin = coinNumber < 0 ? _defaultCoinNumber : coinNumber;
        _numberCoinMoveDone = 0;
        overlay.SetActive(true);
        for (var i = 0; i < numberCoin; i++)
        {
            await Task.Delay(Random.Range(0, delay));
            // var coin = Instantiate(coinPrefab, transform);
            var coin = LeanPool.Spawn(coinPrefab, transform);
            coin.transform.localScale = Vector3.one * scale;
            coin.transform.position = from.transform.position;
            MoveCoin(coin);
        }
    }

    private void MoveCoin(GameObject coin)
    {
        SoundController.Instance.PlayFX(SoundType.CoinMove);
        MoveToNear(coin).SetUpdate(isIndependentUpdate: true).OnComplete(() =>
        {
            MoveToTarget(coin).SetUpdate(isIndependentUpdate: true).OnComplete(() =>
            {
                _numberCoinMoveDone++;
                LeanPool.Despawn(coin);
                // Destroy(coin);
                _moveOneCoinDone?.Invoke();
                if (_numberCoinMoveDone >= numberCoin)
                {
                    _moveAllCoinDone?.Invoke();
                    overlay.SetActive(false);
                }
            });
        });
    }

    private DG.Tweening.Core.TweenerCore<Vector3, Vector3, DG.Tweening.Plugins.Options.VectorOptions> MoveTo(
        Vector3 endValue, GameObject coin, float duration, Ease ease)
    {
        return coin.transform.DOMove(endValue, duration).SetEase(ease);
    }

    private DG.Tweening.Core.TweenerCore<Vector3, Vector3, DG.Tweening.Plugins.Options.VectorOptions> MoveToNear(
        GameObject coin)
    {
        return MoveTo(coin.transform.position + (Vector3)Random.insideUnitCircle * 3, coin, durationNear, easeNear);
    }

    private DG.Tweening.Core.TweenerCore<Vector3, Vector3, DG.Tweening.Plugins.Options.VectorOptions> MoveToTarget(
        GameObject coin)
    {
        return MoveTo(to.transform.position, coin, durationTarget, easeTarget);
    }
}