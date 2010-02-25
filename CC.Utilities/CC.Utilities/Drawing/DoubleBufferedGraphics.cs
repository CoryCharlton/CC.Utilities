﻿using System;
using System.Drawing;

namespace CC.Utilities.Drawing
{
    /// <summary>
    /// Provides a double buffered <see cref="Graphics"/> object.
    /// </summary>
    public class DoubleBufferedGraphics : IDisposable
    {
        #region Constructor
        /// <summary>
        /// Creates a new <see cref="DoubleBufferedGraphics"/>.
        /// </summary>
        public DoubleBufferedGraphics() : this(0, 0) { }

        /// <summary>
        /// Creates a new <see cref="DoubleBufferedGraphics"/> using the specified <see cref="System.Drawing.Size"/>.
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public DoubleBufferedGraphics(int width, int height) : this(new Size(width, height)) { }

        /// <summary>
        /// Creates a new <see cref="DoubleBufferedGraphics"/> using the specified <see cref="System.Drawing.Size"/>.
        /// </summary>
        /// <param name="size">The size</param>
        public DoubleBufferedGraphics(Size size)
        {
            Size = size;
        }
        #endregion

        #region Private Fields
        #endregion

        #region Public Properties
        /// <summary>
        /// The <see cref="Graphics"/> object to draw to.
        /// </summary>
        public Graphics Graphics { get; private set; }

        /// <summary>
        /// True if the <see cref="DoubleBufferedGraphics"/> is initialized.
        /// </summary>
        public bool IsInitialized
        {
            get { return (MemoryImage != null); }
        }

        /// <summary>
        /// The underlying <see cref="Image"/>
        /// </summary>
        public Image MemoryImage { get; private set; }

        /// <summary>
        /// The <see cref="System.Drawing.Size"/>.
        /// </summary>
        public Size Size { get; private set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Release all resources used by this <see cref="DoubleBufferedGraphics"/>.
        /// </summary>
        public void Dispose()
        {
            if (MemoryImage != null)
            {
                MemoryImage.Dispose();
                MemoryImage = null;
            }

            if (Graphics != null)
            {
                Graphics.Dispose();
                Graphics = null;
            }
        }

        /// <summary>
        /// Initialize this <see cref="DoubleBufferedGraphics"/>.
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void Initialize(int width, int height)
        {
            Initialize(new Size(width, height));
        }

        /// <summary>
        /// Initialize this <see cref="DoubleBufferedGraphics"/>.
        /// </summary>
        /// <param name="size">The size</param>
        public void Initialize(Size size)
        {
            if (size.Height > 0 && size.Width > 0)
            {
                if (size != Size)
                {
                    Size = size;
                    Reset();
                }
            }
        }

        /// <summary>
        /// Draw this <see cref="DoubleBufferedGraphics"/> to the supplied <see cref="System.Drawing.Graphics"/>
        /// </summary>
        /// <param name="graphics"></param>
        public void Render(Graphics graphics)
        {
            if (MemoryImage != null)
            {
                // TODO: I think the rectangles are backwards on this. Should it autoscale?
                graphics.DrawImage(MemoryImage, MemoryImage.GetRectangle(), 0, 0, Size.Width, Size.Height, GraphicsUnit.Pixel);
            }
        }

        /// <summary>
        /// Reset this <see cref="DoubleBufferedGraphics"/>.
        /// </summary>
        public void Reset()
        {
            if (MemoryImage != null)
            {
                MemoryImage.Dispose();
                MemoryImage = null;
            }

            if (Graphics != null)
            {
                Graphics.Dispose();
                Graphics = null;
            }

            MemoryImage = new Bitmap(Size.Width, Size.Height);
            Graphics = Graphics.FromImage(MemoryImage);
        }

        /// <summary>
        /// This method is the preferred method of drawing a background image.
        /// It is *MUCH* faster than any of the Graphics.DrawImage() methods.
        /// Warning: The memory image and the <see cref="System.Drawing.Graphics"/> object
        /// will be reset after calling this method. This should be your first
        /// drawing operation.
        /// </summary>
        /// <param name="image">The image to draw.</param>
        public void SetBackgroundImage(Image image)
        {
            if (MemoryImage != null)
            {
                MemoryImage.Dispose();
                MemoryImage = null;
            }

            if (Graphics != null)
            {
                Graphics.Dispose();
                Graphics = null;
            }

            MemoryImage = image.Clone() as Image;

            if (MemoryImage != null)
            {
                Graphics = Graphics.FromImage(MemoryImage);
            }
        }
        #endregion
    }
}
