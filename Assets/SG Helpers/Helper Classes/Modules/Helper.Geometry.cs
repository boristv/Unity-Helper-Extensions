using System.Collections.Generic;
using UnityEngine;

namespace SG.Utils
{
    public static partial class Helper
    {
        public static class Geometry
        {
            public static List<Vector3> GetSectorVectors(Vector3 direction, int vectorCount, float maxAngle, Vector3 axis)
            {
                var list = new List<Vector3>();
            
                if (vectorCount <= 1)
                {
                    list.Add(direction);
                    return list;
                }

                var stepAngle = (maxAngle * 2) / (vectorCount - 1);
                for (var i = 0; i < vectorCount; i++)
                {
                    list.Add(Quaternion.Euler((stepAngle * i - maxAngle) * axis) * Vector3.down);
                }

                return list;
            }
        }
    }
}