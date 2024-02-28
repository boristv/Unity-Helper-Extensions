using UnityEngine;

namespace SG.Extensions
{
    public static class GameObjectExtensions
    {
        public static T GetOrAddComponent<T>(this GameObject self) where T : Component
        {
            T result = self.GetComponent<T>() ?? self.AddComponent<T>();
            return result;
        }
    }
}