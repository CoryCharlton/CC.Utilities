using System;

namespace CC.Utilities
{
    public static class DateTimeExtensions
    {
        public static string ToCommonDateString(this DateTime dateTime)
        {
            return dateTime.ToString("MM/dd/yyyy");
        }

        public static DateTime ToEndDate(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999);
        }

        public static string ToFileDateString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMdd");
        }

        public static DateTime ToStartDate(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 0);    
        }
    }
}
