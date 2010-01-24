﻿using System;
using System.Runtime.InteropServices;

namespace CC.Utilities.Interop
{
    public static class User32
    {
        // ReSharper disable InconsistentNaming
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, [In, Out] SCROLLINFO lpsi);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, [Out] RECT rect);

        [DllImport("user32.dll")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, UInt32 msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, UInt32 msg, int wParam, IntPtr lParam);

        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        //public static extern int SendMessage(IntPtr hWnd, UInt32 msg, Int32 wParam, [In, Out] BlittableStruct lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, UInt32 msg, Int32 wParam, [In, Out] CHARFORMAT2 lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, UInt32 msg, Int32 wParam, [In, Out] FORMATRANGE lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, UInt32 msg, Int32 wParam, [In, Out] PARAFORMAT2 lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, UInt32 msg, Int32 wParam, [In, Out] RECT lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SetScrollInfo(IntPtr hwnd, UInt32 fnBar, [In, Out] SCROLLINFO lpsi, bool fRedraw);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowScrollBar(IntPtr hWnd, UInt32 wBar, bool bShow);
        // ReSharper restore InconsistentNaming
    }
}