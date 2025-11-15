using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using System.Windows;
using App_SingleInstanceTrayGuide_Win.Config;

namespace App_SingleInstanceTrayGuide_Win;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private TrayGuideWindow _trayGuideWindow;
    private DebugConfig _debugConfig;
    private AppLaunchConfig _appLaunchConfig;
    private TrayGuideWindowConfig _trayGuideWindowConfig;
    private ErrorMessagesConfig _errorMessagesConfig;
    
    
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        // Load config
        _debugConfig = new DebugConfig();
        _appLaunchConfig = new AppLaunchConfig();
        _trayGuideWindowConfig = new TrayGuideWindowConfig();
        _errorMessagesConfig = new ErrorMessagesConfig();

        // Debug logic
        switch (_debugConfig.ShowGUI)
        {
            case 0:
                break;
            case 1:
                _trayGuideWindowConfig.SetIsAppAlreadyRunning(true);
                MessageBox.Show(_trayGuideWindowConfig.TitleLabelText);
                _trayGuideWindow = new TrayGuideWindow(_trayGuideWindowConfig);
                _trayGuideWindow.Show();
                break;
            case 2:
                _trayGuideWindowConfig.SetIsAppAlreadyRunning(false);
                MessageBox.Show(_trayGuideWindowConfig.TitleLabelText);
                _trayGuideWindow = new TrayGuideWindow(_trayGuideWindowConfig);
                _trayGuideWindow.Show();
                break;
            default:
                break;
        }
        
    }
}