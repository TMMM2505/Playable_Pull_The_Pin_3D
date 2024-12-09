using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraBuild : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;
    [SerializeField] private float offSetZ;

    private TweenerCore<Vector3, Vector3, VectorOptions> _cameraMoveSequence;
    private bool _isFingerDown;
    private bool _isFingerDrag;

    void OnEnable()
    {
        Lean.Touch.LeanTouch.OnFingerDown += HandleFingerDown;
        Lean.Touch.LeanTouch.OnFingerUp += HandleFingerUp;
        Lean.Touch.LeanTouch.OnFingerUpdate += HandleFingerUpdate;
    }

    void OnDisable()
    {
        Lean.Touch.LeanTouch.OnFingerDown -= HandleFingerDown;
        Lean.Touch.LeanTouch.OnFingerUp -= HandleFingerUp;
        Lean.Touch.LeanTouch.OnFingerUpdate -= HandleFingerUpdate;
    }

    void HandleFingerDown(Lean.Touch.LeanFinger finger)
    {
        if (!finger.IsOverGui)
        {
            _isFingerDown = true;
        }
    }

    void HandleFingerUp(Lean.Touch.LeanFinger finger)
    {
        _isFingerDown = false;
        _isFingerDrag = false;
    }

    void HandleFingerUpdate(Lean.Touch.LeanFinger finger)
    {
        if (_isFingerDown)
        {
            _isFingerDrag = true;
        }
    }

    void Update()
    {
        if (Input.touchCount > 0 && _isFingerDown)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchDeltaPosition = touch.deltaPosition;

            var position = transform.position;
            position += new Vector3(touchDeltaPosition.x * speed * Time.unscaledDeltaTime, 0,
                touchDeltaPosition.y * speed * Time.unscaledDeltaTime);

            float xPos = Mathf.Clamp(position.x, minX, maxX);
            float zPos = Mathf.Clamp(position.z, minZ, maxZ);
            position = new Vector3(xPos, position.y, zPos);

            transform.position = position;
        }
    }

    public void MoveTo([Bridge.Ref] Vector3 buildingPos, Action moveDoneCallback = null)
    {
        _cameraMoveSequence?.Kill();
        if ((transform.position - new Vector3(buildingPos.x, transform.position.y, buildingPos.z + offSetZ)).sqrMagnitude <= 0.2f)
        // if (transform.position == new Vector3(buildingPos.x, transform.position.y, buildingPos.z + offSetZ))
        {
            moveDoneCallback?.Invoke();
        }
        else
        {
            _cameraMoveSequence = transform
                .DOMove(new Vector3(buildingPos.x, transform.position.y, buildingPos.z + offSetZ), 0.5f)
                .SetEase(Ease.OutCubic)
                .SetUpdate(true)
                .OnComplete(() => moveDoneCallback?.Invoke());
        }
    }
}