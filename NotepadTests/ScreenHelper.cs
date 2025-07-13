using System.Runtime.InteropServices;

namespace NotepadTests;

public static class ScreenHelper
{
    [DllImport("user32.dll")]
    private static extern int GetSystemMetrics(int nIndex);

    [DllImport("user32.dll")]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);

    [StructLayout(LayoutKind.Sequential)]
    private struct Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    public static int GetTaskbarHeight()
    {
        var taskbarHandle = FindWindow("Shell_TrayWnd", null);
        if (taskbarHandle == IntPtr.Zero) return 0;

        GetWindowRect(taskbarHandle, out Rect rect);
        return rect.Bottom - rect.Top;
    }
    
    public static int GetScreenWidth() => GetSystemMetrics(0);
    public static int GetScreenHeight() => GetSystemMetrics(1);
}