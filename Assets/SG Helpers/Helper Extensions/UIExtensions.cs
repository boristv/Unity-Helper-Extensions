using UnityEngine;
using UnityEngine.UI;

namespace SG.Utils
{
    public static class UIExtensions
    {
        public static void RefreshLayout(this RectTransform self, bool hard = false)
        {
            if (hard)
            {
                LayoutRebuilder.ForceRebuildLayoutImmediate(self);
            }
            else
            {
                LayoutRebuilder.MarkLayoutForRebuild(self);
            }
        }

        public static void SetColorAlpha(this MaskableGraphic targetGraphic, float newAlpha)
        {
            var newColor = targetGraphic.color;
            newColor.a = newAlpha;
            targetGraphic.color = newColor;
        }
    }
}