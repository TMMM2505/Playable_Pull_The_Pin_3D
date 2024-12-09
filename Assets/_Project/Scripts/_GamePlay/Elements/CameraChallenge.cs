using System;
using DG.Tweening;
using UnityEngine;

public class CameraChallenge : MonoBehaviour
{
    public bool isMovable = true;
    [SerializeField] private float minTransformY;
    [ReadOnly] public Vector3 vel;

    private Ball _followedBall;
    private Level _level;
    private bool _isKilled;
    private bool _levelStarted;
    private const float BallOffsetY = 1.0f;
    private const float BallHolderOffsetY = 7f;

    private BallHolder BallHolderGo => Level.BallHolder;

    private Level Level
    {
        get
        {
            if (_level == null)
            {
                _level = GetComponentInParent<Level>();
            }

            return _level;
        }
    }

    private Ball FollowedBall
    {
        get
        {
            if (_followedBall == null)
            {
                _followedBall = Level.GetRandomActiveBall();
            }

            return _followedBall;
        }
    }

    public void OnStartLevel()
    {
        if (!isMovable) return;

        var trans = transform;
        var pos = trans.position;
        pos = new Vector3(pos.x, BallHolderGo.transform.position.y, pos.z);
        trans.position = pos;

        transform.DOMoveY(Mathf.Max(FollowedBall.transform.position.y - BallOffsetY, minTransformY), 2f).SetTarget(this)
            .OnComplete(() => _levelStarted = true);
    }

    public void LateUpdate()
    {
        if (!_levelStarted || !isMovable) return;

        // if (Mathf.Abs(transform.position.y - FollowedBall.transform.position.y) < 3)
        // {
        var pos = transform.position;
        var ballPos = FollowedBall.transform.position;
        pos = Vector3.SmoothDamp(pos, new Vector3(pos.x, Mathf.Max(ballPos.y - BallOffsetY, minTransformY), pos.z), ref vel, .5f);
        transform.position = pos;
        // }
        // else
        // {
        // var pos = transform.position;
        // var ballPos = FollowedBall.transform.position;
        // pos = Vector3.SmoothDamp(pos, new Vector3(pos.x, ballPos.y - ballOffsetY, pos.z), ref vel, 2);
        // pos = new Vector3(pos.x,
        //     Mathf.Max(ballPos.y - ballOffsetY, BallHolderGo.transform.position.y + ballHolderOffsetY), pos.z);
        // transform.position =
        //     Vector3.SmoothDamp(pos, new Vector3(pos.x, ballPos.y, pos.z), ref vel, 2);
        // }
    }

    private void OnDisable()
    {
        DOTween.Kill(this);
    }
}