using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Odeeo.Utils
{
    internal class OdeeoMainThreadDispatcher : MonoBehaviour
    {
        private static readonly Queue<Action> s_executionQueue = new Queue<Action>();
        
        private static OdeeoMainThreadDispatcher _instance = null;

        private static bool Exists()
        {
            return _instance != null;
        }

        internal static OdeeoMainThreadDispatcher Instance()
        {
            if (!Exists())
            {
                GameObject go = new GameObject();
                go.name = "OdeeoMainThreadDispatcher";
                _instance = go.AddComponent<OdeeoMainThreadDispatcher>();
            }

            return _instance;
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

        private void Update()
        {
            lock (s_executionQueue)
            {
                while (s_executionQueue.Count > 0)
                {
                    s_executionQueue.Dequeue().Invoke();
                }
            }
        }

        /// <summary>
        /// Locks the queue and adds the IEnumerator to the queue
        /// </summary>
        /// <param name="action">IEnumerator function that will be executed from the main thread.</param>
        internal void Enqueue(IEnumerator action)
        {
            lock (s_executionQueue)
            {
                s_executionQueue.Enqueue(() => { StartCoroutine(action); });
            }
        }

        internal void Enqueue(Action action)
        {
            Enqueue(ActionWrapper(action));
        }

        internal Task EnqueueAsync(Action action)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

            void WrappedAction()
            {
                try
                {
                    action();
                    tcs.TrySetResult(true);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            Enqueue(ActionWrapper(WrappedAction));
            return tcs.Task;
        }


        private IEnumerator ActionWrapper(Action action)
        {
            action();
            yield return null;
        }

        private void OnDestroy()
        {
            _instance = null;
        }
    }
}