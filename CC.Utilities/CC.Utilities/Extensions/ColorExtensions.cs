using System.Drawing;

namespace CC.Utilities
{
    /// <summary>
    /// Contains <see cref="Color"/> extension methods
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Inverts a <see cref="Color"/>
        /// </summary>
        /// <param name="color">The <see cref="Color"/> to invert</param>
        /// <returns>An inverted <see cref="Color"/></returns>
        public static Color Invert(this Color color)
        {
            return Color.FromArgb((byte)~color.R, (byte)~color.G, (byte)~color.B);
        }

        /// <summary>
        /// Converts a <see cref="Color"/> into a <see cref="uint"/> that can be used for native methods.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static uint ToColorRef(this Color color)
        {
            uint r = color.R;
            uint g = (uint)color.G << 8;
            uint b = (uint)color.B << 16;

            return r | g | b;
        }
    }
}
