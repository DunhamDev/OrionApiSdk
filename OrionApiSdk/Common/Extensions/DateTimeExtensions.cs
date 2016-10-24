using System;

namespace OrionApiSdk.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static string NullableDateToString(this DateTime? dateToConvert)
        {
            if (dateToConvert.HasValue)
            {
                return dateToConvert.Value.ToString("MM-dd-yyyy");
            }
            return null;
        }
    }
}
