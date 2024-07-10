using System;
using System.Collections;
using UnityEngine;

namespace SG.Utils
{
    public static class CoroutineExtensions
    {
        /// <summary>
        /// StopCoroutine
        /// </summary>
        /// <param name="coroutine"></param>
        /// <param name="owner">"Usually (this)"</param>
        public static void Stop(this Coroutine coroutine, MonoBehaviour owner)
        {
            if (coroutine != default) owner.StopCoroutine(coroutine);
        }

        public static void DoNextFrame(this MonoBehaviour owner, Action action)
        {
            owner.StartCoroutine(NextFrameCoroutine());

            IEnumerator NextFrameCoroutine()
            {
                yield return null;
                action.Invoke();
            }
        }
        
        public static Coroutine DoWithDelay(this MonoBehaviour owner, float delay, Action action)
        {
            return owner.StartCoroutine(DelayCoroutine());

            IEnumerator DelayCoroutine()
            {
                yield return new WaitForSeconds(delay);
                action.Invoke();
            }
        }
    }
}
