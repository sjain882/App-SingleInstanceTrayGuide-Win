using System.Windows;

namespace App_SingleInstanceTrayGuide_Win.Infrastructure.Windowing;

public interface ITopmostService
{
    /// <summary>
    /// Ensures the given window is set to Topmost reliably,
    /// retrying if the WS_EX_TOPMOST style is lost.
    /// </summary>
    /// <param name="window">The WPF window to enforce Topmost on.</param>
    void EnforceTopmost(Window window);
}
