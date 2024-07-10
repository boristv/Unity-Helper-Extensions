using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SG.Utils
{
    public static class ListExtensions
    {
        public static bool IsEmpty<T>(this IList<T> list) => list.Count == 0;
        
        public static int GetEqualsCount<T>(this IList<T> list, T target)
        {
            int count = 0;

            foreach (var element in list)
            {
                if (element.Equals(target)) count++;
            }

            return count;
        }
        
        public static bool TryGetRandomElement<T>(this IList<T> list, out T element)
        {
            if (list.Count == 0)
            {
                element = default;
                return false;
            }
            
            element = list[Random.Range(0, list.Count)];
            return true;
        }
        
        public static bool TryGetRandomElement<T>(this IList<T> list, IList<T> elementsToExclude, out T element)
        {
            var remainElements = list.Except(elementsToExclude).ToList();
            if (remainElements.Count == 0)
            {
                element = default;
                return false;
            }
            
            element = remainElements[Random.Range(0, remainElements.Count)];

            return true;
        }
        
        public static List<T> GetRandomElements<T>(this IList<T> list, int elementsCount)
        {
            if (list.Count == 0)
            {
                return default;
            }
            
            elementsCount = Mathf.Clamp(elementsCount, 1, list.Count);
            var elements = list.OrderBy(arg => Guid.NewGuid()).Take(elementsCount).ToList();
            return elements;
        }
        
        public static List<T> GetRandomElements<T>(this IList<T> list, int elementsCount, IList<T> elementsToExclude)
        {
            var remainElements = list.Except(elementsToExclude).ToList();
            if (remainElements.Count == 0)
            {
                return default;
            }
            
            elementsCount = Mathf.Clamp(elementsCount, 1, remainElements.Count);
            var elements = remainElements.OrderBy(arg => Guid.NewGuid()).Take(elementsCount).ToList();
            return elements;
        }
        
        public static bool TryRemoveRandomElement<T>(this IList<T> list, out T removedElement)
        {
            if (list.Count == 0)
            {
                removedElement = default;
                return false;
            }
            int index = Random.Range(0, list.Count);
            removedElement = list[index];
            list.RemoveAt(index);
            return true;
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            for (var i = list.Count - 1; i > 1; i--)
            {
                var j = Random.Range(0, i + 1);
                (list[j], list[i]) = (list[i], list[j]);
            }
        }
        
        public static List<T> DiffBetween<T>(this IList<T> list1, IList<T> list2)
        {
            var subset = new List<T>();

            foreach (T element1 in list1)
            {
                if (!list2.Contains(element1))
                {
                    subset.Add(element1);
                }
            }

            foreach (T element2 in list2)
            {
                if (!list1.Contains(element2))
                {
                    subset.Add(element2);
                }
            }

            return subset;
        }
        
        public static bool IsEqual<T>(this IList<T> list1, IList<T> list2)
        {
            bool result;
            
            if (list2 == null || list1 == null)
            {
                result = false;
            }
            else
            {
                result = (list1.Count == list2.Count);

                if (result)
                {
                    for (int i = 0; i < list1.Count && result; i++)
                    {
                        result &= list1[i].Equals(list2[i]);
                    }
                }
            }

            return result;
        }
        
        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            T[] result = source;

            if (index >= 0 && index < source.Length)
            {
                result = new T[source.Length - 1];

                if (index > 0)
                {
                    Array.Copy(source, 0, result, 0, index);
                }

                if (index < source.Length - 1)
                {
                    Array.Copy(source, index + 1, result, index, source.Length - index - 1);
                }
            }

            return result;
        }
    }
}
