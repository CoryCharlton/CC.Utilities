using System;
using System.Drawing;
using CC.Utilities.Interop;

namespace CC.Utilities
{
    /// <summary>
    /// General utility methods that don't seem to fit under another namespace
    /// </summary>
    public static class Utilities
    {
        #region Public Methods
        /// <summary>
        /// Captures an <see cref="Image"/> of the screen
        /// </summary>
        /// <returns>An <see cref="Image"/> of the screen</returns>
        public static Image CaptureScreen()
        {
            return CaptureWindow(User32.GetDesktopWindow());
        }

        /// <summary>
        /// Captures an <see cref="Image"/> of the specified window
        /// </summary>
        /// <param name="handle">The handle of the window to capture</param>
        /// <returns>An <see cref="Image"/> of the specified window</returns>
        public static Image CaptureWindow(IntPtr handle)
        {

            IntPtr hdcSrc = User32.GetWindowDC(handle);

            RECT windowRect = new RECT();
            User32.GetWindowRect(handle, windowRect);

            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;

            IntPtr hdcDest = Gdi32.CreateCompatibleDC(hdcSrc);
            IntPtr hBitmap = Gdi32.CreateCompatibleBitmap(hdcSrc, width, height);

            IntPtr hOld = Gdi32.SelectObject(hdcDest, hBitmap);
            Gdi32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, InteropConstants.SRCCOPY);
            Gdi32.SelectObject(hdcDest, hOld);
            Gdi32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);

            Image image = Image.FromHbitmap(hBitmap);
            Gdi32.DeleteObject(hBitmap);

            return image;
        }

        /// <summary>
        /// A generic TryParse() method.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the </typeparam>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TryParse<T>(string text, out T value)
        {
            value = default(T);

            try
            {
                value = (T)Convert.ChangeType(text, typeof(T));
                return true;
            }

            catch
            {
                return false;
            }
        }
        #endregion
    }
}
