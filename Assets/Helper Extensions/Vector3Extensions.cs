using System.Collections.Generic;
using UnityEngine;

namespace SG.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 WithX(this Vector3 value, float x)
        {
            return new Vector3(x, value.y, value.z);
        }
    
        public static Vector3 WithY(this Vector3 value, float y)
        {
            return new Vector3(value.x, y, value.z);
        }
    
        public static Vector3 WithZ(this Vector3 value, float z)
        {
            return new Vector3(value.x, value.y, z);
        }
    
        public static Vector3 AddX(this Vector3 value, float x)
        {
            value.x += x;
            return value;
        }
    
        public static Vector3 AddY(this Vector3 value, float y)
        {
            value.y += y;
            return value;
        }
    
        public static Vector3 AddZ(this Vector3 value, float z)
        {
            value.z += z;
            return value;
        }
        
        public static Vector2 XZ(this Vector3 self) => new Vector2(self.x, self.z);
        
        public static Vector2 ToVector2(this Vector3 self)
        {
            return new Vector2
            {
                x = self.x,
                y = self.z
            };
        }
        
        public static Vector3Int FloorToVector3Int(this Vector3 self)
        {
            return new Vector3Int
            {
                x = Mathf.FloorToInt(self.x),
                y = Mathf.FloorToInt(self.x),
                z = Mathf.FloorToInt(self.x)
            };
        }
        public static Vector3Int FloorToVector3Int(this Vector3 self, float offset)
        {
            return new Vector3Int
            {
                x = Mathf.FloorToInt(self.x + offset),
                y = Mathf.FloorToInt(self.y + offset),
                z = Mathf.FloorToInt(self.z + offset),
            };
        }
        
        /// <param name="axisDirection">unit vector in direction of an axis (eg, defines a line that passes through zero)</param>
        /// <param name="point">the point to find nearest on line for</param>
        public static Vector3 NearestPointOnAxis(this Vector3 axisDirection, Vector3 point, bool isNormalized = false)
        {
            if (!isNormalized) axisDirection.Normalize();
            var dot = Vector3.Dot(point, axisDirection);
            return axisDirection * dot;
        }

        /// <param name="lineDirection">unit vector in direction of line</param>
        /// <param name="pointOnLine">a point on the line (allowing us to define an actual line in space)</param>
        /// <param name="point">the point to find nearest on line for</param>
        public static Vector3 NearestPointOnLine(
            this Vector3 lineDirection, Vector3 point, Vector3 pointOnLine, bool isNormalized = false)
        {
            if (!isNormalized) lineDirection.Normalize();
            var dot = Vector3.Dot(point - pointOnLine, lineDirection);
            return pointOnLine + (lineDirection * dot);
        }
        
        public static bool TryGetNearest(this IList<Vector3> list, Vector3 point, out Vector3 nearestPoint)
        {
            nearestPoint = default;
            if (list.Count == 0) return false;

            var minSqrDistance = float.MaxValue;

            foreach (var element in list)
            {
                var sqrDistance = (point - element).sqrMagnitude;

                if (sqrDistance < minSqrDistance)
                {
                    minSqrDistance = sqrDistance;
                    nearestPoint = element;
                }
            }

            return true;
        }
        
        public static bool TryGetNearest<T>(this Vector3 target, IList<Vector3> list, out Vector3 nearestPoint)
        {
            return TryGetNearest(list, target, out nearestPoint);
        }
    }
}
