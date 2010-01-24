using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CC.Utilities
{
    /// <summary>
    /// A static class responsible for logging
    /// </summary>
    public static class Logging
    {
        /// <summary>
        /// Log a message when you enter a method
        /// </summary>
        /// <param name="methodName">The name of the method</param>
        /// <returns>The DateTime this method was called</returns>
        public static DateTime EnterMethod(string methodName)
        {
            DateTime enterTime = DateTime.Now;

            LogMessage("Entered " + methodName + " at " + enterTime.ToLongTimeString());

            return enterTime;
        }

        /// <summary>
        /// Log a message when you exit a method
        /// </summary>
        /// <param name="methodName">The name of the method</param>
        /// <param name="enterTime">The DateTime that EnterMethod() was called</param>
        public static void ExitMethod(string methodName, DateTime enterTime)
        {
            DateTime exitTime = DateTime.Now;
            TimeSpan timeSpent = exitTime - enterTime;
            LogMessage("Exited " + methodName + " at " + exitTime.ToLongTimeString() + " spent " + timeSpent.ToFriendlyString(true));
        }

        /// <summary>
        /// Log a message that displays the contents of an exception
        /// </summary>
        /// <param name="exception">The System.Exception to log</param>
        public static void LogException(Exception exception)
        {
            LogMessage("Exception: " + exception);    
        }

        /// <summary>
        /// Log a message
        /// </summary>
        /// <param name="message">The message to log</param>
        public static void LogMessage(string message)
        {
            Trace.WriteLine(Application.ProductName + ": " + message);    
        }

        /// <summary>
        /// Log a message
        /// </summary>
        /// <param name="message">The message format</param>
        /// <param name="args">The arguments used in the message format</param>
        public static void LogMessage(string message, params object[] args)
        {
            LogMessage(string.Format(message, args));
        }
    }
}
