using System;
using System.Globalization;

namespace SG.Utils
{
    public static partial class Helper
    {
        public static class Date
        {
            public static string ConvertFromDateTime(DateTime value)
            {
                return value.ToString("u", CultureInfo.InvariantCulture);
            }

            public static DateTime ConvertToDateTime(string value, DateTime defaultTime)
            {
                if (DateTime.TryParseExact(value, "u", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
                {
                    return result;
                }

                return defaultTime;
            }

            public static bool AreDaysEqual(DateTime date1, DateTime date2)
            {
                return date1.Year == date2.Year &&
                       date1.Month == date2.Month &&
                       date1.Day == date2.Day;
            }
        }
    }
}