using System.Drawing;
using System.Text;

namespace CC.Utilities
{
    public static class FontExtensions
    {
        /// <summary>
        /// Extends the <see cref="Font.ToString()"/>  method for parameters that are not included
        /// </summary>
        /// <param name="font">The <see cref="Font"/> to convert to a string</param>
        /// <returns>Returns a human readable representation of this <see cref="Font"/></returns>
        public static string ToStringEx(this Font font)
        {
            StringBuilder returnValue = new StringBuilder();

            returnValue.Append(font.ToString());
            returnValue.Remove(returnValue.Length - 1, 1);

            if (font.Style != FontStyle.Regular)
            {
                returnValue.Append(", Style=" + (int)font.Style);
            }

            returnValue.Append("]");

            return returnValue.ToString();
        }
    }
}
