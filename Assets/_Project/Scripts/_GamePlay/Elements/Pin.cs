using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Pin : MonoBehaviour
{
    [Header("--- TUTORIAL ---")] [SerializeField]
    protected GameObject tutorialHand;

    [SerializeField] protected bool isFirstTutorial;
    [SerializeField] protected Pin nextTutPin;

    [Header("--- PIN ---")] [SerializeField] [Range(0.1f, 10f)]
    protected float length = 1f;

    [SerializeField] protected BoxCollider2D boxTrigger2D;
    [SerializeField] protected BoxCollider2D boxPhysics2D;
    [SerializeField] protected PinSkin currentPinSkin;
    [SerializeField] protected Transform skinHolder;
    [SerializeField] [ReadOnly] protected PinState pinState;

    public bool IsFirstTutorial => isFirstTutorial;
    public bool IsTutorialPin => tutorialHand != null;
    public Pin NextTutorialPin => nextTutPin;
    public bool PinPulled => _pinPulled;
    public Action<Pin> PullPin;

    public bool IsPullAble { get; set; }

    private bool _pinPulled;

    private void Awake()
    {
        SetupPinSkin();
    }

    private void OnEnable()
    {
        EventController.CurrentPinChanged += SetupPinSkin;
    }

    private void OnDisable()
    {
        EventController.CurrentPinChanged -= SetupPinSkin;
    }

    protected virtual void SetupPinSkin()
    {
        skinHolder.Clear();

        foreach (var pinData in ConfigController.ItemConfig.pinDataList.Where(pinData =>
                     Data.CurrentPinSkinId == pinData.Id))
        {
            currentPinSkin = Instantiate(pinData.pinSkin, skinHolder);
            currentPinSkin.ToggleMaterialOnTutorial(IsPullAble);
            currentPinSkin.gameObject.SetActive(true);
        }

        UpdatePin();
    }

    protected void DisableColliders()
    {
        boxPhysics2D.enabled = false;
        boxTrigger2D.enabled = false;
    }

    public virtual void OnDrawGizmos()
    {
        if (Application.isPlaying) return;
        UpdatePin();
    }

    public void SetupTutorialHand(bool status)
    {
        IsPullAble = status;
        if (tutorialHand) tutorialHand.SetActive(status && !_pinPulled);
        currentPinSkin.ToggleMaterialOnTutorial(status);
        if (isFirstTutorial) EventController.ToggleTutorialBackground?.Invoke(status);
    }

    public virtual void ActivePin()
    {
        if (!IsPullAble) return;
        _pinPulled = true;

        if (tutorialHand)
        {
            tutorialHand.SetActive(false);
            currentPinSkin.ToggleMaterialOnTutorial(false);
            EventController.ToggleTutorialBackground?.Invoke(false);
        }

        if (nextTutPin) nextTutPin.SetupTutorialHand(true);

        PullPin?.Invoke(this);
    }

    protected virtual void UpdatePin()
    {
        if (!currentPinSkin) return;

        var tempTransform = transform.eulerAngles;
        transform.eulerAngles = Vector3.zero;

        // Set pos for tail
        currentPinSkin.Pin_body.localScale = new Vector3(length, currentPinSkin.Pin_body.localScale.y,
            currentPinSkin.Pin_body.localScale.z);
        currentPinSkin.Pin_tail.position = currentPinSkin.Pin_archor_tail.position;

        // Find center of pin
        var center = CalculateCenterPoint();

        boxTrigger2D.offset = CalculateCenterOfPin(center);
        boxPhysics2D.offset = CalculateCenterOfPin(center);

        // Set size of box collider
        boxTrigger2D.size = CalculateSizeOfCollider();
        boxPhysics2D.size = new Vector2(boxTrigger2D.size.x, boxPhysics2D.size.y);
        transform.eulerAngles = tempTransform;
    }

    protected virtual Vector2 CalculateCenterOfPin(Vector3 center)
    {
        return new Vector2(center.x - transform.localPosition.x, 0);
    }

    protected virtual Vector3 CalculateCenterPoint()
    {
        return (currentPinSkin.Pin_archor_left.position + currentPinSkin.Pin_archor_right.position) / 2;
    }

    protected virtual Vector2 CalculateSizeOfCollider()
    {
        return new Vector2(
            Mathf.Abs(currentPinSkin.Pin_archor_right.position.x - currentPinSkin.Pin_archor_left.position.x),
            boxTrigger2D.size.y);
    }
}

public enum PinState
{
    Idle,
    Moving,
}