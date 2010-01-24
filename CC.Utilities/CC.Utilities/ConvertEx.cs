using System.Drawing;

namespace CC.Utilities
{
    public static class ConvertEx
    {
        public static Color ColorRefToColor(uint colorRef)
        {
            byte r = (byte)(colorRef);
            byte g = (byte)(colorRef >> 8);
            byte b = (byte)(colorRef >> 16);
            
            return Color.FromArgb(r, g, b);    
        }

        /// <summary>
        /// Convert between 1/100 inch (unit used by the .NET framework)
        /// and twips (1/1440 inch, used by Win32 API calls)
        /// </summary>
        /// <param name="n">Value in 1/100 inch</param>
        /// <returns>Value in twips</returns>
        public static int HundredthInchToTwips(int n)
        {
            return (int)(n * 14.4);
        }

        /// <summary>
        /// Converts inches to pixels using the supplied dpi
        /// </summary>
        /// <param name="length">The length of inches to convert</param>
        /// <param name="dpi">The dpi value of the return value</param>
        /// <returns>The number of pixels</returns>
        public static float InchesToPixels(float length, float dpi)
        {
            return length*dpi;
        }

        public static float InchesToTwips(float inches)
        {
            return inches*1440;
        }

        /*
        public static string NullTerminatedCharArrayToString(char[] charArray)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in charArray)
            {
                if (c == 0)
                {
                    break;
                }

                stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }
        */

        /// <summary>
        /// Convert points to twips
        /// </summary>
        /// <param name="points"></param>
        /// <returns>A <see cref="float"/> that respresents the number of twips</returns>
        public static float PointsToTwips(float points)
        {
            return (points*20f);
        }

        /// <summary>
        /// Converts pixels to inches using the supplied dpi
        /// </summary>
        /// <param name="length">The value of pixels to convert</param>
        /// <param name="dpi">The dpi value of the length paramater</param>
        /// <returns>A <see cref="float"/> that respresents the number of inches</returns>
        public static float PixelsToInches(float length, float dpi)
        {
            return length/dpi;
        }

        /// <summary>
        /// Convert twips to inches
        /// </summary>
        /// <param name="twips">The twips value</param>
        /// <returns>A <see cref="float"/> that respresents the number of inches</returns>
        public static float TwipsToInches(float twips)
        {
            return twips/1440f;
        }

        /// <summary>
        /// Convert twips to points
        /// </summary>
        /// <param name="twips">The twips value</param>
        /// <returns>A <see cref="float"/> that respresents the number of inches</returns>
        public static float TwipsToPoints(int twips)
        {
            return (twips/20f);
        }
    }
}
