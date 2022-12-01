using ModernWpf.Controls;
using MS.Win32;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace ModernWpf.Extensions
{
    internal static class UIExtensions
    {
        public static IconElement MakeIconElementFrom(this IconSource iconSource)
        {
            if (iconSource is FontIconSource fontIconSource)
            {
                FontIcon fontIcon = new FontIcon();

                fontIcon.Glyph = fontIconSource.Glyph;
                fontIcon.FontSize = fontIconSource.FontSize;
                var newForeground = fontIconSource.Foreground;
                if (newForeground != null)
                {
                    fontIcon.Foreground = newForeground;
                }

                if (fontIconSource.FontFamily != null)
                {
                    fontIcon.FontFamily = fontIconSource.FontFamily;
                }

                fontIcon.FontWeight = fontIconSource.FontWeight;
                fontIcon.FontStyle = fontIconSource.FontStyle;
                //fontIcon.IsTextScaleFactorEnabled = fontIconSource.IsTextScaleFactorEnabled;
                //fontIcon.MirroredWhenRightToLeft = fontIconSource.MirroredWhenRightToLeft;

                return fontIcon;
            }
            else if (iconSource is SymbolIconSource symbolIconSource)
            {
                SymbolIcon symbolIcon = new SymbolIcon();
                symbolIcon.Symbol = symbolIconSource.Symbol;
                var newForeground = symbolIconSource.Foreground;
                if (newForeground != null)
                {
                    symbolIcon.Foreground = newForeground;
                }
                return symbolIcon;
            }
            else if (iconSource is BitmapIconSource bitmapIconSource)
            {
                BitmapIcon bitmapIcon = new BitmapIcon();

                if (bitmapIconSource.UriSource != null)
                {
                    bitmapIcon.UriSource = bitmapIconSource.UriSource;
                }

                bitmapIcon.ShowAsMonochrome = bitmapIconSource.ShowAsMonochrome;
                var newForeground = bitmapIconSource.Foreground;
                if (newForeground != null)
                {
                    bitmapIcon.Foreground = newForeground;
                }
                return bitmapIcon;
            }
            else if (iconSource is PathIconSource pathIconSource)
            {
                PathIcon pathIcon = new PathIcon();

                if (pathIconSource.Data != null)
                {
                    pathIcon.Data = pathIconSource.Data;
                }
                var newForeground = pathIconSource.Foreground;
                if (newForeground != null)
                {
                    pathIcon.Foreground = newForeground;
                }
                return pathIcon;
            }
            return null;
        }

        /// <summary>
        /// Applies selected background effect to <see cref="Window"/> when is rendered.
        /// </summary>
        /// <param name="window">Window to apply effect.</param>
        /// <param name="force">Skip the compatibility check.</param>
        public static bool TryApplyMica(Window window, bool force = false)
        {
            if (!force && !(OSVersionHelper.OSVersion >= new Version(10, 0, 21996))) { return false; }

            window.WindowStyle = WindowStyle.SingleBorderWindow;

            var windowHandle = new WindowInteropHelper(window).EnsureHandle();

            if (windowHandle == IntPtr.Zero) { return false; }

            return TryApplyMica(windowHandle);
        }

        private static bool TryApplyMica(IntPtr handle)
        {
            int backdropPvAttribute;

            if (OSVersionHelper.OSVersion >= new Version(10, 0, 22523))
            {
                backdropPvAttribute = (int)DWMAPI.DWMSBT.DWMSBT_MAINWINDOW;

                DWMAPI.DwmSetWindowAttribute(handle, DWMAPI.DWMWINDOWATTRIBUTE.DWMWA_SYSTEMBACKDROP_TYPE,
                    ref backdropPvAttribute,
                    Marshal.SizeOf(typeof(int)));

                return true;
            }

            if (!RemoveTitleBar(handle)) { return false; }

            backdropPvAttribute = (int)DWMAPI.PvAttribute.Enable;

            DWMAPI.DwmSetWindowAttribute(handle, DWMAPI.DWMWINDOWATTRIBUTE.DWMWA_MICA_EFFECT,
                ref backdropPvAttribute,
                Marshal.SizeOf(typeof(int)));

            return true;
        }

        /// <summary>
        /// Tries to remove background effects if they have been applied to the <see cref="Window"/>.
        /// </summary>
        /// <param name="window">The window from which the effect should be removed.</param>
        public static void RemoveMica(Window window)
        {
            window.WindowStyle = WindowStyle.None;

            var windowHandle = new WindowInteropHelper(window).EnsureHandle();

            if (windowHandle == IntPtr.Zero) return;

            RemoveMica(windowHandle);
        }

        /// <summary>
        /// Tries to remove all effects if they have been applied to the <c>hWnd</c>.
        /// </summary>
        /// <param name="handle">Pointer to the window handle.</param>
        public static void RemoveMica(IntPtr handle)
        {
            if (handle == IntPtr.Zero) return;

            int pvAttribute = (int)DWMAPI.PvAttribute.Disable;
            int backdropPvAttribute = (int)DWMAPI.DWMSBT.DWMSBT_DISABLE;

            DWMAPI.DwmSetWindowAttribute(handle, DWMAPI.DWMWINDOWATTRIBUTE.DWMWA_MICA_EFFECT, ref pvAttribute,
                Marshal.SizeOf(typeof(int)));

            DWMAPI.DwmSetWindowAttribute(handle, DWMAPI.DWMWINDOWATTRIBUTE.DWMWA_SYSTEMBACKDROP_TYPE,
                ref backdropPvAttribute,
                Marshal.SizeOf(typeof(int)));
        }

        /// <summary>
        /// Tries to inform the operating system that this window uses dark mode.
        /// </summary>
        /// <param name="window">Window to apply effect.</param>
        public static void ApplyDarkMode(this Window window)
        {
            var windowHandle = new WindowInteropHelper(window).EnsureHandle();

            if (windowHandle == IntPtr.Zero) return;

            ApplyDarkMode(windowHandle);
        }

        /// <summary>
        /// Tries to inform the operating system that this <c>hWnd</c> uses dark mode.
        /// </summary>
        /// <param name="handle">Pointer to the window handle.</param>
        public static void ApplyDarkMode(IntPtr handle)
        {
            if (handle == IntPtr.Zero) return;

            var pvAttribute = (int)DWMAPI.PvAttribute.Enable;
            var dwAttribute = DWMAPI.DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE;

            if (OSVersionHelper.OSVersion < new Version(10, 0, 18985))
            {
                dwAttribute = DWMAPI.DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE_OLD;
            }

            DWMAPI.DwmSetWindowAttribute(handle, dwAttribute,
                ref pvAttribute,
                Marshal.SizeOf(typeof(int)));
        }

        /// <summary>
        /// Tries to clear the dark theme usage information.
        /// </summary>
        /// <param name="window">Window to remove effect.</param>
        public static void RemoveDarkMode(this Window window)
        {
            var windowHandle = new WindowInteropHelper(window).EnsureHandle();

            if (windowHandle == IntPtr.Zero) return;

            RemoveDarkMode(windowHandle);
        }

        /// <summary>
        /// Tries to clear the dark theme usage information.
        /// </summary>
        /// <param name="handle">Pointer to the window handle.</param>
        public static void RemoveDarkMode(IntPtr handle)
        {
            if (handle == IntPtr.Zero) { return; }

            var pvAttribute = (int)DWMAPI.PvAttribute.Disable;
            var dwAttribute = DWMAPI.DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE;

            if (OSVersionHelper.OSVersion < new Version(10, 0, 18985))
            {
                dwAttribute = DWMAPI.DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE_OLD;
            }

            DWMAPI.DwmSetWindowAttribute(handle, dwAttribute,
                ref pvAttribute,
                Marshal.SizeOf(typeof(int)));
        }

        /// <summary>
        /// Tries to remove default TitleBar from <c>hWnd</c>.
        /// </summary>
        /// <param name="window">Window to remove effect.</param>
        public static void RemoveTitleBar(this Window window)
        {
            var windowHandle = new WindowInteropHelper(window).EnsureHandle();

            if (windowHandle == IntPtr.Zero) return;

            RemoveTitleBar(windowHandle);
        }

        /// <summary>
        /// Tries to remove default TitleBar from <c>hWnd</c>.
        /// </summary>
        /// <param name="handle">Pointer to the window handle.</param>
        /// <returns><see langowrd="false"/> is problem occurs.</returns>
        private static bool RemoveTitleBar(IntPtr handle)
        {
            // Hide default TitleBar
            // https://stackoverflow.com/questions/743906/how-to-hide-close-button-in-wpf-window
            try
            {
                SetWindowLong(handle, -16, GetWindowLong(handle, -16) & ~0x80000);

                return true;
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine(e);
#endif
                return false;
            }
        }

        /// <summary>
        /// Retrieves information about the specified window.
        /// The function also retrieves the 32-bit (DWORD) value at the specified offset into the extra window memory.
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        /// <summary>
        /// Changes an attribute of the specified window.
        /// The function also sets the 32-bit (long) value at the specified offset into the extra window memory.
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    }
}
