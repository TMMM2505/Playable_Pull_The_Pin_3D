using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class MultipleChallenge : Level
{
    public override LevelType Type => LevelType.Multiple;

    private List<MultipleGate> MultipleGates => GetComponentsInChildren<MultipleGate>().ToList();
    private List<PlusGate> PlusGates => GetComponentsInChildren<PlusGate>().ToList();
    
    private Sequence _loseSequence;

    protected override void DoDisabled()
    {
        base.DoDisabled();
        _loseSequence?.Kill();
    }
    
    public override void OnDestroy()
    {
        _loseSequence?.Kill();
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying) return;
        UpdateTotalScoreCanGet();
    }
    
    public override void UpdateTotalScoreCanGet()
    {
        TotalScoreCanGet = 0;
        var balls = GetComponentsInChildren<Ball>().ToList().FindAll(item => !item.GetArchiveState());
        TotalScoreCanGet += balls.Count;

        if (balls.Count > 0)
        {
            foreach (var plus in PlusGates.Select(plusGate => plusGate.plusNumb))
            {
                TotalScoreCanGet += plus;
            }

            foreach (var multiple in MultipleGates.Select(multipleGate => multipleGate.MultiplyNumb))
            {
                TotalScoreCanGet *= multiple;
            }
        }

        if (Application.isPlaying && GameManager.Instance.GameState == GameState.PlayingGame && ScoreWin > TotalScoreCanGet)
        {
            _loseSequence ??= DOTween.Sequence().AppendInterval(1f).SetUpdate(isIndependentUpdate: true).AppendCallback(() =>
            {
                GameManager.Instance.OnLoseGame();
            });
        }
    }
}
