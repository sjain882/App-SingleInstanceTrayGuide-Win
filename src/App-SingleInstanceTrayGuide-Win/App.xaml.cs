using System.Configuration;
using System.Data;
using System.Windows;
using App_SingleInstanceTrayGuide_Win.Config;

namespace App_SingleInstanceTrayGuide_Win;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        // Load config
        var debugConfig = new DebugConfig();
        var appLaunchConfig = new AppLaunchConfig();
        var trayGuideWindowConfig = new TrayGuideWindowConfig();
        
        var trayGuideWindow = new TrayGuideWindow();
        trayGuideWindow.Show();
    }
}