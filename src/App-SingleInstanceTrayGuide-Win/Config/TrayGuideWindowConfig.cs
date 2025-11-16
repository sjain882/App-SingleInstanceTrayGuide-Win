using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace App_SingleInstanceTrayGuide_Win.Config;

public class TrayGuideWindowConfig : IConfig
{
    private readonly bool _isDarkThemeEnabled;
    public string AppName { get; set; }
    public string AppAlreadyRunningText { get; set; }
    public string AppNowRunningText { get; set; }
    public string TitleLabelText { get; set; }
    
    public string TaskbarGuideText { get; set; }
    public string TaskbarImagePath { get; set; }
    public string FullTaskbarImagePath { get; set; }
    public BitmapImage TaskbarImage { get; set; }
    
    public string AppControlText { get; set; }
    public string AppIconPath { get; set; }
    public string FullAppIconPath { get; set; }
    public BitmapImage AppIconImage { get; set; }
    
    public string OverflowText { get; set; }
    public ImageSource OverflowIcon { get; set; }
    
    public string OKButtonText { get; set; } = "OK";

    public TrayGuideWindowConfig(bool isDarkThemeEnabled)
    {
        _isDarkThemeEnabled = isDarkThemeEnabled;
        LoadConfig();
    }

    public void LoadConfig()
    {
        AppName = ConfigurationManager.AppSettings["GUI_AppName"];
        AppAlreadyRunningText = ConfigurationManager.AppSettings["GUI_AppAlreadyRunningText"];
        AppNowRunningText = ConfigurationManager.AppSettings["GUI_AppNowRunningText"];
        TitleLabelText = String.Empty;
        
        TaskbarGuideText = ConfigurationManager.AppSettings["GUI_TaskbarGuideText"];
        TaskbarImagePath = ConfigurationManager.AppSettings["GUI_TaskbarImagePath"];
        
        AppControlText = ConfigurationManager.AppSettings["GUI_AppControlText"];
        AppIconPath = ConfigurationManager.AppSettings["GUI_AppIconPath"];
        
        OverflowText = ConfigurationManager.AppSettings["GUI_OverflowText"];
        OverflowIcon = (ImageSource)Application.Current.Resources[_isDarkThemeEnabled ? "OverflowDark" : "OverflowLight"];

        OKButtonText = ConfigurationManager.AppSettings["GUI_OKButtonText"];
        
        ResolvePaths();
        EvaluateStrings();
        LoadImages();
    }

    public void SetIsAppAlreadyRunning(bool isRunning)
    {
        if (isRunning)
        {
            TitleLabelText = AppAlreadyRunningText;
        }
        else
        {
            TitleLabelText = AppNowRunningText;
        }
    }

    private void ResolvePaths()
    {
        FullAppIconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppIconPath);
        FullTaskbarImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TaskbarImagePath);
    }

    private void EvaluateStrings()
    {
        AppAlreadyRunningText = AppName + AppAlreadyRunningText;
        AppNowRunningText = AppName + AppNowRunningText;
        
        AppAlreadyRunningText = AppAlreadyRunningText.Replace("\\n", Environment.NewLine);
        AppNowRunningText = AppNowRunningText.Replace("\\n", Environment.NewLine);
        TaskbarGuideText = TaskbarGuideText.Replace("\\n", Environment.NewLine);
        AppControlText = AppControlText.Replace("\\n", Environment.NewLine);
        OverflowText = OverflowText.Replace("\\n", Environment.NewLine);
        OKButtonText = OKButtonText.Replace("\\n", Environment.NewLine);
    }

    private void LoadImages()
    {
        AppIconImage = new BitmapImage(new Uri(FullAppIconPath));
        TaskbarImage = new BitmapImage(new Uri(FullTaskbarImagePath));
    }
}