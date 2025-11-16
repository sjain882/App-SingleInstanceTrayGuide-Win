using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using App_SingleInstanceTrayGuide_Win.Config;
using App_SingleInstanceTrayGuide_Win.GUI.Infrastructure.Commands;
using App_SingleInstanceTrayGuide_Win.GUI.ViewModel;
using App_SingleInstanceTrayGuide_Win.Infrastructure.Windowing;
using App_SingleInstanceTrayGuide_Win.Infrastructure.Theming;
using App_SingleInstanceTrayGuide_Win.Infrastructure.System;

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
        // Audio ping
        System.Media.SystemSounds.Asterisk.Play();
        
        // Set label text
        _trayGuideWindowConfig.SetIsAppAlreadyRunning(IsAppAlreadyRunning);
        
        // Create window
        _trayGuideWindow = new TrayGuideWindow();
        ViewModel = new TrayGuideWindowViewModel(_trayGuideWindowConfig);
        _trayGuideWindow.DataContext = ViewModel;
        
        // Set initial positon off screen to avoid brief flash in wrong position
        ViewModel.UpdateWindowPosition(new Point(9999, 9999));
        
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
        services.AddSingleton<ITopmostService, TopmostService>();
        services.AddSingleton<IOSThemeDetector, OSThemeDetector>();
    }
    
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        // Configure DI
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        Services = serviceCollection.BuildServiceProvider();

        // Detect OS Theme
        var osThemeDetector = Services.GetRequiredService<IOSThemeDetector>();
        bool isDarkThemeEnabled = osThemeDetector.IsDarkThemeEnabled();

        // Load config
        _debugConfig = new DebugConfig();
        _appLaunchConfig = new AppLaunchConfig();
        _trayGuideWindowConfig = new TrayGuideWindowConfig(isDarkThemeEnabled);
        _errorMessagesConfig = new ErrorMessagesConfig();

        // Debug logic
        switch (_debugConfig.ShowGUI)
        {
            case 0:
                break;
            case 1:
                LaunchGUI(true);
                return;
            case 2:
                LaunchGUI(false);
                return;
            default:
                break;
        }
        
        // Main logic
        // Check if app running
        var appProcesses =  Process.GetProcessesByName(_appLaunchConfig.AppProcessName);
        
        // Multi-instance is unsupported
        if (appProcesses.Length > 1)
        {
            MessageBox.Show($"{_trayGuideWindowConfig.AppName} / {_appLaunchConfig.AppProcessName}{_errorMessagesConfig.MultiInstanceErrorText}",
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        // Already running
        else if (appProcesses.Length > 0)
        {
            System.Media.SystemSounds.Asterisk.Play();
            LaunchGUI(true);
        }
        // Not running - now we have to launch it
        else
        {
            if (_appLaunchConfig.LaunchAppViaTaskScheduler)
            {
                // Trigger both tasks and wait for completion
                bool task1Success = TaskSchedulerHelper.TriggerTask(_appLaunchConfig.Task1);
                Thread.Sleep(_appLaunchConfig.DelayBetweenTasksMs);
                bool task2Success = TaskSchedulerHelper.TriggerTask(_appLaunchConfig.Task2);

                if (task1Success && task2Success)
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    LaunchGUI(false);
                }
                else
                {
                    MessageBox.Show($"{_trayGuideWindowConfig.AppName} / {_appLaunchConfig.AppProcessName}{_errorMessagesConfig.TaskSchedErrorText}",
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                using (var process = new Process())
                {
                    process.StartInfo = new ProcessStartInfo
                    {
                        FileName = _appLaunchConfig.AppExecutablePath,
                        WorkingDirectory = _appLaunchConfig.AppWorkingDirectory,
                        Arguments = _appLaunchConfig.AppArguments,
                        UseShellExecute = true
                    };
                    process.Start();
                }
                
                LaunchGUI(false);
            }
        }
    }
}