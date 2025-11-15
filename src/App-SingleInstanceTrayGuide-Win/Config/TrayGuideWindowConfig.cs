using System.Configuration;
using System.IO;
using System.Windows.Media.Imaging;

namespace App_SingleInstanceTrayGuide_Win.Config;

public class TrayGuideWindowConfig : IConfig
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

    public TrayGuideWindowConfig() => LoadConfig();

    public void LoadConfig()
    {
        AppName = ConfigurationManager.AppSettings["GUI_AppName"];
        AppIconPath = ConfigurationManager.AppSettings["GUI_AppIconPath"];
        TaskbarImagePath = ConfigurationManager.AppSettings["GUI_TaskbarImagePath"];
        AppAlreadyRunningText = ConfigurationManager.AppSettings["GUI_AppAlreadyRunningText"];
        AppNowRunningText = ConfigurationManager.AppSettings["GUI_AppNowRunningText"];
        AppControlText = ConfigurationManager.AppSettings["GUI_AppControlText"];
        OverflowText = ConfigurationManager.AppSettings["GUI_OverflowText"];
        OverflowImagePath = ConfigurationManager.AppSettings["GUI_OverflowImagePath"];
        TaskSchedErrorText = ConfigurationManager.AppSettings["GUI_TaskSchedErrorText"];
        MultiInstanceErrorText = ConfigurationManager.AppSettings["GUI_MultiInstanceErrorText"];
        
        ResolvePaths();
        EvaluateStrings();
        LoadImages();
    }

    private void ResolvePaths()
    {
        FullAppIconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppIconPath);
        FullTaskbarImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TaskbarImagePath);
        FullOverflowImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, OverflowImagePath);
    }

    private void EvaluateStrings()
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

    private void LoadImages()
    {
        AppIconImage = new BitmapImage(new Uri(FullAppIconPath));
        TaskbarImage = new BitmapImage(new Uri(FullTaskbarImagePath));
        OverflowImage = new BitmapImage(new Uri(FullOverflowImagePath));
    }
}