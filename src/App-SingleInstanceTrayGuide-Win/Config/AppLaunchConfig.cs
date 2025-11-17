using System.Collections.Specialized;
using System.Configuration;

namespace App_SingleInstanceTrayGuide_Win.Config;

public class AppLaunchConfig : IConfig
{
    public bool LaunchAppViaTaskScheduler;
    public string Task1;
    public string Task2;
    public int DelayBetweenTasksMs;
    public string AppProcessName;
    public string AppExecutablePath;
    public string AppWorkingDirectory;
    public string AppArguments;
    public StringDictionary EnvironmentVariables { get; set; }
    
    public AppLaunchConfig() => LoadConfig();
    
    public void LoadConfig()
    {
        LaunchAppViaTaskScheduler = ConfigurationManager.AppSettings["LaunchAppViaTaskScheduler"] == "true";
        Task1 = ConfigurationManager.AppSettings["Task1"];
        Task2 = ConfigurationManager.AppSettings["Task2"];
        DelayBetweenTasksMs = int.TryParse(ConfigurationManager.AppSettings["DelayBetweenTasksMs"], out int d) ? d : 1000;
        AppProcessName = ConfigurationManager.AppSettings["AppProcessName"];
        AppExecutablePath = ConfigurationManager.AppSettings["AppExecutablePath"];
        AppWorkingDirectory = ConfigurationManager.AppSettings["AppWorkingDirectory"];
        AppArguments = ConfigurationManager.AppSettings["AppArguments"];
        
        // Build environment variable dictionary from keys starting with AppEnvVar_
        EnvironmentVariables = new StringDictionary();

        var envVars = ConfigurationManager.AppSettings.AllKeys
            .Where(name => name.StartsWith("AppEnvVar_"))
            .Select(pair => new
            {
                Key = pair.Substring("AppEnvVar_".Length), // strip prefix
                Value = ConfigurationManager.AppSettings[pair]
            });

        foreach (var item in envVars)
        {
            EnvironmentVariables[item.Key] = item.Value;
        }
    }
}