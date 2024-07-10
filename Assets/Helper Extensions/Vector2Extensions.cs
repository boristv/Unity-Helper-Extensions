using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SG.Utils
{
    public static class Vector2Extensions
    {
        public static Vector2 Swap(this Vector2 self) => new Vector2(self.y, self.x);

        public static Vector2Int Swap(this Vector2Int self) => new Vector2Int(self.y, self.x);

        public static float GetRandom(this Vector2 self) => Random.Range(self.x, self.y);

        public static int GetRandom(this Vector2Int self) => Random.Range(self.x, self.y);

        public static Vector3 X0Z(this Vector2 self) => new Vector3(self.x, 0, self.y);

        public static Vector3 ToVector3(this Vector2 self, float y = 0)
        {
            return new Vector3
            {
                x = self.x,
                y = y,
                z = self.y
            };
        }

        public static Vector2 GetClosestVector2From(this Vector2 vector, List<Vector2> otherVectors)
        {
            if (otherVectors.Count == 0)
                throw new Exception("The list of other vectors is empty");

            var minDistance = Vector2.Distance(vector, otherVectors[0]);
            var minVector = otherVectors[0];
            for (var i = otherVectors.Count - 1; i > 0; i--)
            {
                var newDistance = Vector2.Distance(vector, otherVectors[i]);
                if (newDistance < minDistance)
                {
                    minDistance = newDistance;
                    minVector = otherVectors[i];
                }
            }

            return minVector;
        }
    }
}