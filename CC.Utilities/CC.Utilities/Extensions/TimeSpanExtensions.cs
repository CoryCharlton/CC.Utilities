﻿using System;

namespace CC.Utilities
{
    /// <summary>
    /// Contains extension methods for <see cref="TimeSpan"/>
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Converts a TimeSpan to a formatted string
        /// </summary>
        /// <param name="timeSpan">The TimeSpan to convert</param>
        /// <param name="showMilliseconds">Whether or not to display milliseconds</param>
        /// <returns>A formatted string</returns>
        public static string ToFriendlyString(this TimeSpan timeSpan, bool showMilliseconds)
        {
            string returnValue;

            if (timeSpan.TotalHours > 24)
            {
                returnValue = showMilliseconds ?
                    string.Format("{0}.{1:00}:{2:00}:{3:00}.{4:000}", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds) :
                    string.Format("{0}.{1:00}:{2:00}:{3:00}", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            }
            else if (timeSpan.TotalHours > 1)
            {
                returnValue = showMilliseconds ?
                    string.Format("{0:00}:{1:00}:{2:00}.{3:000}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds) :
                    string.Format("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            }
            else
            {
                returnValue = showMilliseconds ?
                    string.Format("{0:00}:{1:00}.{2:000}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds) :
                    string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
            }

            return returnValue;
        }
    }
}
