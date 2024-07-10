using System;
using UnityEngine;

namespace SG.Extensions
{
    public static class NumericExtensions
    {
        public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T>
        {
            T result;

            if (value.CompareTo(min) < 0)
            {
                result = min;
            }
            else if (value.CompareTo(max) > 0)
            {
                result = max;
            }
            else
            {
                result = value;
            }

            return result;
        }

        public static T ClampMin<T>(this T value, T min) where T : IComparable<T>
        {
            T result = value.CompareTo(min) < 0 ? min : value;

            return result;
        }

        public static T ClampMax<T>(this T value, T max) where T : IComparable<T>
        {
            T result = value.CompareTo(max) > 0 ? max : value;

            return result;
        }

        public static bool IsBetween<T>(this T value, T min, T max, bool includeMin = true, bool includeMax = true)
            where T : IComparable<T>
        {
            if (min.CompareTo(max) > 0)
            {
                (min, max) = (max, min);
            }

            return (includeMin ? value.CompareTo(min) >= 0 : value.CompareTo(min) > 0) &&
                   (includeMax ? value.CompareTo(max) <= 0 : value.CompareTo(max) < 0);
        }

        public static bool IsBetweenStrictly<T>(this T value, T min, T max) where T : IComparable<T>
        {
            return IsBetween(value, min, max, false, false);
        }

        public static float Cut(this float value, int tail)
        {
            float t = Mathf.Pow(10, tail);
            int intValue = (int) (value * t);

            return intValue / t;
        }

        public static bool IsEven(this int value) => value % 2 == 0;

        public static bool IsOdd(this int value) => !IsEven(value);

        public static int Sign(this int value) => value > 0 ? 1 : -1;

        public static int Sign(this float value) => value > 0 ? 1 : -1;
    }
}