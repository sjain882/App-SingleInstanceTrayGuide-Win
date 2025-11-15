using System.IO;
using System.Windows.Media.Imaging;

namespace App_SingleInstanceTrayGuide_Win.Config;

public class TrayGuideWindowConfig
{
    public string AppName { get; set; }
    public string AppIconPath { get; set; }
    public string FullAppIconPath { get; set; }
    public BitmapImage AppIconImage { get; set; }
    public string TaskbarImagePath { get; set; }
    public string FullTaskbarImagePath { get; set; }
    public BitmapImage TaskbarImage { get; set; }
    public string AppAlreadyRunningText { get; set; }
    public string AppNowRunningText { get; set; }
    public string AppControlText { get; set; }
    public string OverflowText { get; set; }
    public string OverflowImagePath { get; set; }
    public string FullOverflowImagePath { get; set; }
    public BitmapImage OverflowImage { get; set; }
    public string TaskSchedErrorText { get; set; }
    public string MultiInstanceErrorText { get; set; }

    public TrayGuideWindowConfig(
        string appName,
        string appIconPath,
        string taskbarImagePath,
        string appAlreadyRunningText,
        string appNowRunningText,
        string appControlText,
        string overflowText,
        string overflowImagePath,
        string taskSchedErrorText,
        string multiInstanceErrorText)
    {
        AppName = appName;
        AppIconPath = appIconPath;
        TaskbarImagePath = taskbarImagePath;
        AppAlreadyRunningText = appAlreadyRunningText;
        AppNowRunningText = appNowRunningText;
        AppControlText = appControlText;
        OverflowText = overflowText;
        OverflowImagePath = overflowImagePath;
        TaskSchedErrorText = taskSchedErrorText;
        MultiInstanceErrorText = multiInstanceErrorText;
        
        ResolvePaths();
        EvaluateStrings();
        LoadImages();
    }

    public void ResolvePaths()
    {
        FullAppIconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppIconPath);
        FullTaskbarImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TaskbarImagePath);
        FullOverflowImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, OverflowImagePath);
    }

    public void EvaluateStrings()
    {
        AppAlreadyRunningText = AppName + AppAlreadyRunningText;
        AppNowRunningText = AppName + AppNowRunningText;
        
        AppAlreadyRunningText = AppControlText.Replace("\\n", Environment.NewLine);
        AppNowRunningText = AppControlText.Replace("\\n", Environment.NewLine);
        AppControlText = AppControlText.Replace("\\n", Environment.NewLine);
        OverflowText = AppControlText.Replace("\\n", Environment.NewLine);
        TaskSchedErrorText = AppControlText.Replace("\\n", Environment.NewLine);
        MultiInstanceErrorText = AppControlText.Replace("\\n", Environment.NewLine);
    }

    public void LoadImages()
    {
        AppIconImage = new BitmapImage(new Uri(FullAppIconPath));
        TaskbarImage = new BitmapImage(new Uri(FullTaskbarImagePath));
        OverflowImage = new BitmapImage(new Uri(FullOverflowImagePath));
    }
}