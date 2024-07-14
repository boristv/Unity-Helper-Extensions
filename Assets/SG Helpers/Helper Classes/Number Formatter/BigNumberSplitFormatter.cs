using System.Globalization;
using System.Numerics;

namespace SG.Utils
{
    public class BigNumberSplitFormatter
    {
        private readonly NumberFormatInfo _formatInfo;
        
        public BigNumberSplitFormatter(string separator)
        {
            _formatInfo = new NumberFormatInfo { NumberGroupSeparator = separator, NumberDecimalDigits = 0 };
        }

        public string Get(int number)
        {
            return number.ToString("n", _formatInfo);
        }
        
        public string Get(float number)
        {
            return number.ToString("n", _formatInfo);
        }
        
        public string Get(decimal number)
        {
            return number.ToString("n", _formatInfo);
        }
        
        public string Get(double number)
        {
            return number.ToString("n", _formatInfo);
        }
        
        public string Get(BigInteger number)
        {
            return number.ToString("n", _formatInfo);
        }
    }
}