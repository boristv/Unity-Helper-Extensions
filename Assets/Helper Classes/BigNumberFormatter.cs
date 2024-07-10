using System.Globalization;

namespace SG.Utils
{
    public class BigNumberFormatter
    {
        private readonly NumberFormatInfo _formatInfo;
        
        public BigNumberFormatter(string separator)
        {
            _formatInfo = new NumberFormatInfo { NumberGroupSeparator = separator, NumberDecimalDigits = 0 };
        }

        public string Get(int number)
        {
            return number.ToString("n", _formatInfo);
        }
    }
}