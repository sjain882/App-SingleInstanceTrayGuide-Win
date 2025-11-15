using System.Configuration;

namespace App_SingleInstanceTrayGuide_Win.Config;

public class AppLaunchConfig
{
    public bool LaunchAppViaTaskScheduler;
    public string Task1;
    public string Task2;
    public int DelayBetweenTasksMs;
    public string AppProcessName;
    public string AppExecutablePath;
    public string AppWorkingDirectory;
    public string AppArguments;
    
    public void LoadConfig()
    {
        LaunchAppViaTaskScheduler = ConfigurationManager.AppSettings["LaunchAppViaTaskScheduler"] == "true";
        Task1 = ConfigurationManager.AppSettings["Task1"];
        Task2 = ConfigurationManager.AppSettings["Task2"];
        DelayBetweenTasksMs = int.TryParse(ConfigurationManager.AppSettings["DelayBetweenTasksMs"], out int d) ? d : 1000;
        AppProcessName = ConfigurationManager.AppSettings["AppProcessName"];
        AppExecutablePath = ConfigurationManager.AppSettings["AppExecutablePath"];
        AppWorkingDirectory = ConfigurationManager.AppSettings["AppWorkingDirectory"];
        AppArguments = ConfigurationManager.AppSettings["AppWorkingDirectory"];
    }
}