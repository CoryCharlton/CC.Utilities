using System;

namespace CC.Utilities
{
    /// <summary>
    /// Contains extension methods for <see cref="DateTime"/>
    /// </summary>
    public static class DateTimeExtensions
    {
        #region Public Static Methods
        /// <summary>
        /// Returns a <see cref="DateTime"/> <see cref="string"/> using ToString("MM/dd/yyyy")
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to work with</param>
        /// <returns>A <see cref="string"/></returns>
        public static string ToCommonDateString(this DateTime dateTime)
        {
            return dateTime.ToString("MM/dd/yyyy");
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> with a time of 23:59:59.999
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to work with</param>
        /// <returns>A <see cref="string"/></returns>
        public static DateTime ToEndDate(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999, dateTime.Kind);
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> <see cref="string"/> using ToString("MM/dd/yyyy")
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to work with</param>
        /// <returns>A <see cref="string"/></returns>
        public static string ToFileDateString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMdd");
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> with a time of 00:00:00.000
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to work with</param>
        /// <returns>A <see cref="string"/></returns>
        public static DateTime ToStartDate(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 0, dateTime.Kind);
        }
        #endregion
    }
}
