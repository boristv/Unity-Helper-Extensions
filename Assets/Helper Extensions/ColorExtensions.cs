using UnityEngine;

namespace SG.Utils
{
    public static class ColorExtensions
    {
        public static Color32 RandomColor32 =>
            new Color32((byte) Random.Range(0, 256), 
                (byte) Random.Range(0, 256),
                (byte) Random.Range(0, 256),
                255);
        
        public static Color RandomColor => new Color(Random.value, Random.value, Random.value);
        
        public static string ToHex(this Color32 color) => $"#{color.r:X2}{color.g:X2}{color.b:X2}{color.a:X2}";

        public static string ToHex(this Color color)
        {
            Color32 color32 = color;
            return color32.ToHex();
        }

        public static Color32 SetAlpha(this Color32 color, byte alpha)
        {
            color.a = alpha;
            return color;
        }

        public static Color SetAlpha(this Color color, byte alpha)
        {
            color.a = alpha;
            return color;
        }
        
        public static Color32 WithAlpha(this Color32 color, byte alpha)
        {
            return new Color32(color.r, color.g, color.b, alpha);
        }

        public static Color WithAlpha(this Color color, byte alpha)
        {
            return new Color(color.r, color.g, color.b, alpha);
        }
    }
}
