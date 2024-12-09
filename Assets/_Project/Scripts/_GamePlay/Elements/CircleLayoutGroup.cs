using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class CircleLayoutGroup : MonoBehaviour
{
    [Range(0,360)]
    private int angleView = 360;
    private float radius = 1f;
    private bool ChangeRotation = false;
    Transform[] Slot;
    [SerializeField] private float radiusToAdd;
    private float currentRadius;
    private TweenerCore<float, float, FloatOptions> sequence;
    void Start()
    {
        getChildTransform();
        CircleLG();
        currentRadius = radius;
    }
    
    void LateUpdate()
    {
        getChildTransform();
        CircleLG();
    }
    public void CircleLG()
    {
        for(int i=0;i<transform.childCount;i++)
        {
            float angle = i * (angleView*Mathf.Deg2Rad)/transform.childCount;
            Slot[i].localPosition = new Vector3(Mathf.Cos(angle)*radius ,Mathf.Sin(angle)*radius,0);
            
            if(ChangeRotation)
                Slot[i].localRotation = Quaternion.Euler(0,0,angle * Mathf.Rad2Deg);
            else
                Slot[i].localRotation = Quaternion.identity;
        }
    }

    void getChildTransform()
    {
        Slot = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Slot[i] = transform.GetChild(i).GetComponent<Transform>();
        }
    }

    public void AddRadius()
    {
        currentRadius += radiusToAdd;
        sequence.Kill();
        sequence = DOTween.To(()=> radius, x=> radius = x, currentRadius, .5f);
    }
}
