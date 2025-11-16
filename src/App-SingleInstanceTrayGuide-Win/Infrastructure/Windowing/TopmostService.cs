using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace App_SingleInstanceTrayGuide_Win.Infrastructure.Windowing;

// Credit: user5129133 @ https://stackoverflow.com/a/42381157

public class TopmostService : ITopmostService
{
    private const int RetrySetTopMostDelayMs = 200;
    private const int RetrySetTopMostMax = 20;

    internal const int GWL_EXSTYLE = -20;
    internal const int WS_EX_TOPMOST = 0x00000008;

    [DllImport("user32.dll")]
    internal static extern int GetWindowLong(IntPtr hwnd, int index);

    public void EnforceTopmost(Window window)
    {
        if (window is null) return;

        // Initial attempt
        window.Topmost = true;

        var hwnd = new WindowInteropHelper(window).Handle;

        // Fire-and-forget retry loop on dispatcher
        Application.Current.Dispatcher.BeginInvoke(
            new Action(async () => await RetrySetTopMostAsync(window, hwnd)));
    }

    private static async Task RetrySetTopMostAsync(Window window, IntPtr hwnd)
    {
        for (int i = 0; i < RetrySetTopMostMax; i++)
        {
            await Task.Delay(RetrySetTopMostDelayMs);

            int winStyle = GetWindowLong(hwnd, GWL_EXSTYLE);

            if ((winStyle & WS_EX_TOPMOST) != 0)
                break;

            // Flip Topmost off/on to reapply WS_EX_TOPMOST
            window.Topmost = false;
            window.Topmost = true;
        }
    }
}
