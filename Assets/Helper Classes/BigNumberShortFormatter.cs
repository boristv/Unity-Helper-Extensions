using System;
using UnityEngine;

namespace SG.Utils
{
    public class BigNumberShortFormatter
    {
        public void Get(float number)
        {
            /*int mag = (int)(Mathf.Floor(Mathf.Log10(number))/3); // Truncates to 6, divides to 2
            double divisor = Mathf.Pow(10, mag*3);

            double shortNumber = number / divisor;

            string suffix;
            switch(mag)
            {
                case 0:
                    suffix = string.Empty;
                    break;
                case 1:
                    suffix = "k";
                    break;
                case 2:
                    suffix = "m";
                    break;
                case 3:
                    suffix = "b";
                    break;
            }
            string result = shortNumber.ToString("N1") + suffix;*/
        }
    }
}