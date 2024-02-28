using System.Collections.Generic;
using UnityEngine;

namespace SG.Extensions
{
    public static class TransformExtensions
    {
        public static List<Transform> GetChildren(this Transform parent)
        {
            List<Transform> list = new List<Transform>();
            foreach (Transform child in parent) list.Add(child);
            return list;
        }
        
        public static void DestroyChildren(this Transform transform)
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
                Object.Destroy(transform.GetChild(i).gameObject);
        }

        public static void Reset(this Transform transform)
        {
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            transform.localScale = Vector3.one;
        }
        
        public static float DistanceTo(this Transform transform, Transform target)
        {
            return Vector3.Distance(transform.position, target.position);
        }
        
        public static float DistanceTo(this Transform transform, Vector3 targetPoint)
        {
            return Vector3.Distance(transform.position, targetPoint);
        }
        
        public static T GetNearest<T>(this ICollection<T> list, Vector3 point) where T : Component
        {
            if (list.Count == 0) return null;

            var minSqrDistance = float.MaxValue;
            T result = null;

            foreach (var element in list)
            {
                var sqrDistance = (point - element.transform.position).sqrMagnitude;

                if (sqrDistance < minSqrDistance)
                {
                    minSqrDistance = sqrDistance;
                    result = element;
                }
            }

            return result;
        }
        
        public static T GetNearest<T>(this ICollection<T> list, Transform target) where T : Component
        {
            return GetNearest(list, target.position);
        }
        
        public static T GetNearest<T>(this Transform target, ICollection<T> list) where T : Component
        {
            return GetNearest(list, target.position);
        }
    }
}
