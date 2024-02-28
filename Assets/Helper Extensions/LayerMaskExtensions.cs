using UnityEngine;

namespace SG.Extensions
{
    public static class LayerMaskExtensions
    {
        /// <summary>
        /// Check if a layer is in a layer mask
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static bool Contains(this LayerMask mask, int layer)
        {
            return mask == (mask | (1 << layer));
        }
    }
}