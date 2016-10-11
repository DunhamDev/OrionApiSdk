using System;

namespace OrionApiSdk.Common.ExtensionMethods
{
    public static class DateTimeExtensionMethods
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
