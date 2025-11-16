using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using App_SingleInstanceTrayGuide_Win.Config;
using App_SingleInstanceTrayGuide_Win.GUI.ViewModel;
using App_SingleInstanceTrayGuide_Win.Infrastructure.Interop;
using App_SingleInstanceTrayGuide_Win.Infrastructure.Windowing;

namespace App_SingleInstanceTrayGuide_Win;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private TrayGuideWindow _trayGuideWindow;
    private TrayGuideWindowViewModel ViewModel;
    
    private DebugConfig _debugConfig;
    private AppLaunchConfig _appLaunchConfig;
    private TrayGuideWindowConfig _trayGuideWindowConfig;
    private ErrorMessagesConfig _errorMessagesConfig;
    private WindowPositionConfig _windowPositionConfig;
    
    public static ServiceProvider Services { get; private set; }

    private void LaunchGUI(bool IsAppAlreadyRunning)
    {
        // Set label text
        _trayGuideWindowConfig.SetIsAppAlreadyRunning(IsAppAlreadyRunning);
        
        // Create window
        _trayGuideWindow = new TrayGuideWindow();
        ViewModel = new TrayGuideWindowViewModel(_trayGuideWindowConfig);
        _trayGuideWindow.DataContext = ViewModel;
        
        // Show window (must be done before 
        _trayGuideWindow.Show();
        
        // Based on size of created window, calculate desired window position based on config
        _windowPositionConfig = new WindowPositionConfig(_trayGuideWindow.Width, _trayGuideWindow.Height);
        
        // Set window position
        ViewModel.UpdateWindowPosition(_windowPositionConfig.CalculatedPosition);
        
        // Ensure window is topmost
        // Resolve TopmostService and enforce Topmost
        var topmostService = Services.GetRequiredService<ITopmostService>();
        topmostService.EnforceTopmost(_trayGuideWindow);
    }
    
    private void ConfigureServices(IServiceCollection services)
    {
        // Register TopmostService
        services.AddSingleton<ITopmostService, TopmostService>();
    }
    
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        // Configure DI
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        Services = serviceCollection.BuildServiceProvider();
        
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
                LaunchGUI(true);
                break;
            case 2:
                LaunchGUI(false);
                break;
            default:
                break;
        }
        
    }
}