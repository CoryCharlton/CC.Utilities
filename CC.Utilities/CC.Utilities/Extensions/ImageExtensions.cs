using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CC.Utilities
{
    /// <summary>
    /// Contains extension methods for <see cref="Image"/>
    /// </summary>
    public static class ImageExtensions
    {
        #region Public Static Methods
        /// <summary>
        /// Creates a new <see cref="Image"/> with an adjusted brightness.
        /// </summary>
        /// <param name="image">The <see cref="Image"/> to adjust brightness</param>
        /// <param name="brightness">The brightness value ranging from -1.0 (decrease brightness) to 1.0 (increase brightness)</param>
        /// <returns>A new <see cref="Image"/> with an adjusted brightness</returns>
        public static Image AdjustBrightness(this Image image, float brightness)
        {
            if (brightness < -1 || brightness > 1)
            {
                throw new ArgumentOutOfRangeException("brightness", brightness, "Brightness must be between -1.0 and 1.0");
            }
            
            Bitmap outputBitmap = new Bitmap(image.Width, image.Height, image.PixelFormat);

            using (Graphics graphics = Graphics.FromImage(outputBitmap))
            {
                using (ImageAttributes imageAttributes = new ImageAttributes())
                {
                    ColorMatrix colorMatrix = new ColorMatrix(new []
                                                             {
                                                                 new [] {1f, 0f, 0f, 0f, 0f},
                                                                 new [] {0f, 1f, 0f, 0f, 0f},
                                                                 new [] {0f, 0f, 1f, 0f, 0f},
                                                                 new [] {0f, 0f, 0f, 1f, 0f},
                                                                 new [] {brightness, brightness, brightness, 0f, 1f}
                                                             });

                    imageAttributes.SetColorMatrix(colorMatrix);
                    graphics.DrawImage(image, image.GetRectangle(), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
                }
            }

            return outputBitmap;
        }

        /// <summary>
        /// Creates a new <see cref="Image"/> with an adjusted contrast.
        /// </summary>
        /// <param name="image">The <see cref="Image"/> to adjust contrast</param>
        /// <param name="contrast">The contrast value ranging from -1.0 (decrease contrast) to 1.0 (increase contrast)</param>
        /// <returns>A new <see cref="Image"/> with an adjusted contrast</returns>
        public static Image AdjustContrast(this Image image, float contrast)
        {
            if (contrast < -1 || contrast > 1)
            {
                throw new ArgumentOutOfRangeException("contrast", contrast, "Contrast must be between -1.0 and 1.0");
            }

            Bitmap outputBitmap = new Bitmap(image.Width, image.Height, image.PixelFormat);
            
            using (Graphics graphics = Graphics.FromImage(outputBitmap))
            {
                using (ImageAttributes imageAttributes = new ImageAttributes())
                {
                    ColorMatrix colorMatrix = new ColorMatrix(new[]
                                                             {
                                                                 new [] {contrast, 0f, 0f, 0f, 0f},
                                                                 new [] {0f, 1f, contrast, 0f, 0f},
                                                                 new [] {0f, 0f, 1f, contrast, 0f},
                                                                 new [] {0f, 0f, 0f, 1f, 0f},
                                                                 new [] {0f, 0f, 0f, 0f, 1f}
                                                             });

                    imageAttributes.SetColorMatrix(colorMatrix);
                    graphics.DrawImage(image, image.GetRectangle(), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
                }
            }

            return outputBitmap;
        }

        /// <summary>
        /// Creates a new <see cref="Image"/> using <see cref="ControlPaint.DrawImageDisabled"/> and <see cref="AdjustBrightness"/> with a brightness value of 0.215f.
        /// </summary>
        /// <param name="image">The <see cref="Image"/> to disable</param>
        /// <returns>A disabled <see cref="Image"/></returns>
        public static Image GetDisabledImage(this Image image)
        {
            return image.GetDisabledImage(0.215f);
        }

        /// <summary>
        /// Creates a new <see cref="Image"/> using <see cref="ControlPaint.DrawImageDisabled"/> and <see cref="AdjustBrightness"/>.
        /// </summary>
        /// <param name="image">The <see cref="Image"/> to disable</param>
        /// <param name="brightness">The brightness value ranging from -1.0 (decrease brightness) to 1.0 (increase brightness)</param>
        /// <returns>A disabled <see cref="Image"/></returns>
        public static Image GetDisabledImage(this Image image, float brightness)
        {
            using (Bitmap controlPaintBitmap = new Bitmap(image.Width, image.Height, image.PixelFormat))
            {
                using (Graphics graphics = Graphics.FromImage(controlPaintBitmap))
                {
                    ControlPaint.DrawImageDisabled(graphics, image, 0, 0, Color.Transparent);
                }

                return controlPaintBitmap.AdjustBrightness(brightness);
            }
        }

        /// <summary>
        /// Gets a rectangle that corresponds to the height and width of the <see cref="Image"/>
        /// </summary>
        /// <param name="image">The <see cref="Image"/> to work with</param>
        /// <returns>A <see cref="Rectangle"/> that corresponds to the height and width of the <see cref="Image"/></returns>
        public static Rectangle GetRectangle(this Image image)
        {
            return new Rectangle(0, 0, image.Width, image.Height);
        }
        #endregion
    }
}
