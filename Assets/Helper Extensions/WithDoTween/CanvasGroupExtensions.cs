using System;
using DG.Tweening;
using UnityEngine;

namespace SG.Utils
{
    public static class CanvasGroupExtension
    {
        public static void Set(this CanvasGroup canvasGroup, float alpha, bool interactable, bool blocksRaycasts)
        {
            canvasGroup.DOKill();
            canvasGroup.alpha = alpha;
            canvasGroup.interactable = interactable;
            canvasGroup.blocksRaycasts = blocksRaycasts;
        }

        /// <param name="duration">Duration of fading in, cannot be negative</param>
        /// <param name="delay">Delay before canvas group show, cannot be negative</param>
        public static void Show(this CanvasGroup canvasGroup, float duration = 0, float delay = 0,
            bool onlyAlpha = false, Action callback = null)
        {
            if (duration < 0) throw new ArgumentException("Value cannot be negative", nameof(duration));

            if (delay < 0) throw new ArgumentException("Value cannot be negative", nameof(delay));

            canvasGroup.DOKill();
            if (duration == 0 && delay == 0)
            {
                canvasGroup.alpha = 1;
                CompleteShow();
            }
            else
            {
                canvasGroup.DOFade(1, duration)
                    .SetLink(canvasGroup.gameObject)
                    .SetDelay(delay)
                    .OnComplete(CompleteShow);
            }

            void CompleteShow()
            {
                if (!onlyAlpha)
                {
                    canvasGroup.interactable = true;
                    canvasGroup.blocksRaycasts = true;
                }
                callback?.Invoke();
            }
        }

        /// <param name="duration">Duration of fading out, cannot be negative</param>
        /// <param name="delay">Delay before canvas group hide, cannot be negative</param>
        public static void Hide(this CanvasGroup canvasGroup, float duration = 0, float delay = 0,
            bool onlyAlpha = false, Action callback = null)
        {
            if (duration < 0) throw new ArgumentException("Value cannot be negative", nameof(duration));

            if (delay < 0) throw new ArgumentException("Value cannot be negative", nameof(delay));

            canvasGroup.DOKill();
            if (duration == 0 && delay == 0)
            {
                StartHide();
                canvasGroup.alpha = 0;
                CompleteHide();
            }
            else
            {
                canvasGroup.DOFade(0, duration)
                    .SetLink(canvasGroup.gameObject)
                    .SetDelay(delay)
                    .OnStart(StartHide)
                    .OnComplete(CompleteHide);
            }

            void StartHide()
            {
                if (!onlyAlpha)
                {
                    canvasGroup.interactable = false;
                    canvasGroup.blocksRaycasts = false;
                }
            }

            void CompleteHide()
            {
                callback?.Invoke();
            }
        }

        public static bool IsActive(this CanvasGroup canvasGroup)
        {
            bool isActive = Mathf.Approximately(canvasGroup.alpha, 1f);
            return isActive;
        }
    }
}