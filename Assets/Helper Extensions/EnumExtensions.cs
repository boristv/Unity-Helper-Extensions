using System;

namespace SG.Extensions
{
    public static class EnumExtensions
    {
        public static T GetNext<T>(this T self) where T : Enum
        {
            T[] arr = (T[]) Enum.GetValues(self.GetType());
            int j = Array.IndexOf(arr, self) + 1;
            return (arr.Length == j) ? arr[0] : arr[j];
        }
    }
}