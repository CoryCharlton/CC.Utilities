using System;
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
        /// Creates a new <see cref="DoubleBufferedGraphics"/> using the specified width and height.
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public DoubleBufferedGraphics(int width, int height)
        {
            Height = height;
            Width = width;
        }
        #endregion

        #region Private Fields
        private Image _MemoryBitmap;
        #endregion

        #region Public Properties
        /// <summary>
        /// The <see cref="Graphics"/> object to draw to.
        /// </summary>
        public Graphics Graphics { get; private set; }

        /// <summary>
        /// The height.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// True if the <see cref="DoubleBufferedGraphics"/> is initialized.
        /// </summary>
        public bool Initialized
        {
            get { return (_MemoryBitmap != null); }
        }

        /// <summary>
        /// The width.
        /// </summary>
        public int Width { get; private set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Release all resources used by this <see cref="DoubleBufferedGraphics"/>.
        /// </summary>
        public void Dispose()
        {
            if (_MemoryBitmap != null)
            {
                _MemoryBitmap.Dispose();
                _MemoryBitmap = null;
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
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Initialize(int width, int height)
        {
            if (height > 0 && width > 0)
            {
                if ((height != Height) || (width != Width))
                {
                    Height = height;
                    Width = width;

                    Reset();
                }
            }
        }

        /// <summary>
        /// Draw this <see cref="DoubleBufferedGraphics"/> to the supplied <see cref="Graphics"/>.
        /// </summary>
        /// <param name="graphics"></param>
        public void Render(Graphics graphics)
        {
            if (_MemoryBitmap != null)
            {
                graphics.DrawImage(_MemoryBitmap, _MemoryBitmap.GetRectangle(), 0, 0, Width, Height, GraphicsUnit.Pixel);
            }
        }

        /// <summary>
        /// Reset this <see cref="DoubleBufferedGraphics"/>.
        /// </summary>
        public void Reset()
        {
            if (_MemoryBitmap != null)
            {
                _MemoryBitmap.Dispose();
                _MemoryBitmap = null;
            }

            if (Graphics != null)
            {
                Graphics.Dispose();
                Graphics = null;
            }

            _MemoryBitmap = new Bitmap(Width, Height);
            Graphics = Graphics.FromImage(_MemoryBitmap);
        }

        /// <summary>
        /// This method is the preferred method of drawing a background image.
        /// It is *MUCH* faster than any of the Graphics.DrawImage() methods.
        /// Warning: The memory image and the <see cref="Graphics"/> object
        /// will be reset after calling this method. This should be your first
        /// drawing operation.
        /// </summary>
        /// <param name="image">The image to draw.</param>
        public void SetBackgroundImage(Image image)
        {
            if (_MemoryBitmap != null)
            {
                _MemoryBitmap.Dispose();
                _MemoryBitmap = null;
            }

            if (Graphics != null)
            {
                Graphics.Dispose();
                Graphics = null;
            }

            _MemoryBitmap = image.Clone() as Image;

            if (_MemoryBitmap != null)
            {
                Graphics = Graphics.FromImage(_MemoryBitmap);
            }
        }
        #endregion
    }
}
