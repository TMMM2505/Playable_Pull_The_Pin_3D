using System;
using System.Collections.Generic;
using UnityEngine;

namespace Odeeo.Demo
{
    public class OdeeoAnimator : MonoBehaviour
    {
        internal delegate float EasingFunction(float from, float to, float value);

        private static readonly List<OdAnimation> s_animations = new List<OdAnimation>();

        private static OdeeoAnimator _instance;

        public enum Ease
        {
            Linear,
            EaseInSine,
            EaseOutSine,
            EaseInBack,
            EaseOutBack
        }
        
        private static void CreateInstance()
        {
            if (_instance)
                return;
            
            GameObject go = new GameObject();
            go.name = "OdeeoAnimator";
                
            _instance = go.AddComponent<OdeeoAnimator>();
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public static OdAnimation AnimateFloat(float from, float to, float duration, Ease ease)
        {
            CreateInstance();
            
            OdAnimation anim = new OdAnimation();
            anim.Init(from, to, duration, GetEasingFunction(ease));
            
            s_animations.Add(anim);

            return anim;
        }

        public static OdAnimation DelayedCall(float delay, Action action)
        {
            OdAnimation animation = AnimateFloat(0f, 1f, delay, Ease.Linear).OnComplete(action);
            return animation;
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;

            for (int i = s_animations.Count - 1; i >= 0; i--)
            {
                OdAnimation anim = s_animations[i];
                anim.Update(deltaTime);
                
                if(anim.IsFinished)
                    s_animations.RemoveAt(i);
            }
        }

        private static EasingFunction GetEasingFunction(Ease ease)
        {
            EasingFunction easingFunction = null;
            
            switch (ease)
            {
                case Ease.Linear:
                    easingFunction = Linear;
                    break;
                case Ease.EaseInSine:
                    easingFunction = EaseInSine;
                    break;
                case Ease.EaseOutSine:
                    easingFunction = EaseOutSine;
                    break;
                case Ease.EaseInBack:
                    easingFunction = EaseInBack;
                    break;
                case Ease.EaseOutBack:
                    easingFunction = EaseOutBack;
                    break;
                default:
                    easingFunction = Linear;
                    break;
            }

            return easingFunction;
        }
        
        private static float Linear(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, value);
        }
        
        private static float EaseInSine(float start, float end, float value)
        {
            end -= start;
            return -end * Mathf.Cos(value * (Mathf.PI * 0.5f)) + end + start;
        }
        
        private static float EaseOutSine(float start, float end, float value)
        {
            end -= start;
            return end * Mathf.Sin(value * (Mathf.PI * 0.5f)) + start;
        }
        
        private static float EaseInBack(float start, float end, float value)
        {
            end -= start;
            value /= 1;
            float s = 1.70158f;
            return end * (value) * value * ((s + 1) * value - s) + start;
        }
        
        private static float EaseOutBack(float start, float end, float value)
        {
            float s = 1.70158f;
            end -= start;
            value = (value) - 1;
            return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
        }
    }

    public static class Extensions
    {
        public static OdAnimation OdLocalMove(this Transform transform, Vector3 to, float duration, OdeeoAnimator.Ease ease)
        {
            OdAnimatorLocalMove localMove = new OdAnimatorLocalMove(transform, transform.localPosition, to, duration, ease);
            return localMove.Animation;
        }

        public static OdAnimation OdAnchoredMove(this RectTransform rect, Vector2 to, float duration, OdeeoAnimator.Ease ease)
        {
            OdAnimatorAnchoredMove anchoredMove = new OdAnimatorAnchoredMove(rect, rect.anchoredPosition, to, duration, ease);
            return anchoredMove.Animation;
        }
    }

    public class OdAnimatorLocalMove
    {
        public OdAnimatorLocalMove(Transform transform, Vector3 from, Vector3 to, float duration, OdeeoAnimator.Ease ease)
        {
            Vector3 diff = to - from;
            
            Animation = OdeeoAnimator.AnimateFloat(0f, 1f, duration, ease)
                .OnUpdate((value) =>
                {
                    transform.localPosition = from + diff * value;
                });
        }
        
        public OdAnimation Animation { get; }
    }
    
    public class OdAnimatorAnchoredMove
    {
        public OdAnimatorAnchoredMove(RectTransform rect, Vector2 from, Vector2 to, float duration, OdeeoAnimator.Ease ease)
        {
            Vector2 diff = to - from;
            
            Animation = OdeeoAnimator.AnimateFloat(0f, 1f, duration, ease)
                .OnUpdate((value) =>
                {
                    rect.anchoredPosition = from + diff * value;
                });
        }
        
        public OdAnimation Animation { get; }
    }
    
    public class OdAnimation
    {
        private float _from;
        private float _to;
        private float _duration;
        private OdeeoAnimator.EasingFunction _easingFunction;

        private float _time;
        
        private bool _isFinished;
        
        private Action<float> _onUpdate;
        private Action _onComplete;

        internal void Init(float from, float to, float duration, OdeeoAnimator.EasingFunction easingFunction)
        {
            _from = from;
            _to = to;
            _duration = duration;
            _easingFunction = easingFunction;
        }

        public OdAnimation OnUpdate(Action<float> onUpdate)
        {
            _onUpdate += onUpdate;
            return this;
        }

        public OdAnimation OnComplete(Action onComplete)
        {
            _onComplete += onComplete;
            return this;
        }

        public OdAnimation Kill()
        {
            _isFinished = true;
            
            _onUpdate = null;
            _onComplete = null;
            
            return this;
        }

        internal void Update(float deltaTime)
        {
            if(_isFinished)
                return;
            
            _time += deltaTime;
            if (_time >= _duration)
            {
                _onUpdate?.Invoke(_to);
                _onComplete?.Invoke();
                _isFinished = true;

                _onUpdate = null;
                _onComplete = null;
                
                return;
            }
            
            float easedValue = _easingFunction.Invoke(_from, _to, _time / _duration);
            _onUpdate?.Invoke(easedValue);
        }

        public bool IsFinished => _isFinished;
    }
}
