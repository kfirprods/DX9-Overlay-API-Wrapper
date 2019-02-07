using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DX9OverlayAPIWrapper
{
    /// <summary>
    /// The binding of the original DX9 overlay binary to C#
    /// </summary>
    public static class Dx9Overlay
    {
        private const string OverlayBinaryPath = "dx9_overlay.dll";

        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextCreate(string font, int fontSize, bool bBold, bool bItalic, int x, int y, uint color, string text, bool bShadow, bool bShow);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextDestroy(int id);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextSetShadow(int id, bool b);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextSetShown(int id, bool b);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextSetColor(int id, uint color);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextSetPos(int id, int x, int y);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextSetString(int id, string str);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextUpdate(int id, string font, int fontSize, bool bBold, bool bItalic);

        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxCreate(int x, int y, int w, int h, uint dwColor, bool bShow);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxDestroy(int id);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxSetShown(int id, bool bShown);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxSetBorder(int id, int height, bool bShown);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxSetBorderColor(int id, uint dwColor);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxSetColor(int id, uint dwColor);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxSetHeight(int id, int height);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxSetPos(int id, int x, int y);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxSetWidth(int id, int width);

        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int LineCreate(int x1, int y1, int x2, int y2, int width, uint color, bool bShow);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int LineDestroy(int id);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int LineSetShown(int id, bool bShown);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int LineSetColor(int id, uint color);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int LineSetWidth(int id, int width);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int LineSetPos(int id, int x1, int y1, int x2, int y2);

        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImageCreate(string path, int x, int y, int rotation, int align, bool bShow);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImageDestroy(int id);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImageSetShown(int id, bool bShown);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImageSetAlign(int id, int align);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImageSetPos(int id, int x, int y);
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImageSetRotation(int id, int rotation);

        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DestroyAllVisual();
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ShowAllVisual();
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HideAllVisual();

        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFrameRate();
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetScreenSpecs(out int width, out int height);

        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Init();
        [DllImport(OverlayBinaryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetParam(string szParamName, string szParamValue);

        public static string ToHexValueRgb(Color color)
        {
            return $"{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        public static string ToHexValueArgb(Color color)
        {
            return $"{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        public static Point GetScreenSpecs()
        {
            GetScreenSpecs(out var x, out var y);
            return new Point(x, y);
        }
    }

    [Flags]
    public enum Align
    {
        Center = 1,
        Left = 0
    }

    [Flags]
    public enum TypeFace
    {
        Italic = 1,
        Bold = 2,
        None = 4
    }
}
