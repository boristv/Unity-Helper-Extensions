using UnityEngine;

namespace SG.Utils
{
    public static class MathExtensions
    {
        /// <summary>
        ///Re-maps a number from one range to another
        /// </summary>
        public static float Remap(this float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        public static float ClampAngle(this float angle, float min, float max)
        {
            angle = Mathf.Repeat(angle, 360);
            min = Mathf.Repeat(min, 360);
            max = Mathf.Repeat(max, 360);
            bool inverse = false;
            var tMin = min;
            var tangle = angle;
            if (min > 180)
            {
                inverse = !inverse;
                tMin -= 180;
            }

            if (angle > 180)
            {
                inverse = !inverse;
                tangle -= 180;
            }

            var result = !inverse ? tangle > tMin : tangle < tMin;
            if (!result)
                angle = min;

            inverse = false;
            tangle = angle;
            var tMax = max;
            if (angle > 180)
            {
                inverse = !inverse;
                tangle -= 180;
            }

            if (max > 180)
            {
                inverse = !inverse;
                tMax -= 180;
            }

            result = !inverse ? tangle < tMax : tangle > tMax;
            if (!result)
                angle = max;
            return angle;
        }
    }
}