using System.Configuration;

namespace App_SingleInstanceTrayGuide_Win.Config;

public class ErrorMessagesConfig : IConfig
{
    
    public string TaskSchedErrorText { get; set; }
    public string MultiInstanceErrorText { get; set; }
    
    public ErrorMessagesConfig() => LoadConfig();

    public void LoadConfig()
    {
        TaskSchedErrorText = ConfigurationManager.AppSettings["GUI_TaskSchedErrorText"];
        MultiInstanceErrorText = ConfigurationManager.AppSettings["GUI_MultiInstanceErrorText"];
    }

    public void EvaluateStrings()
    {
        TaskSchedErrorText = TaskSchedErrorText.Replace("\\n", Environment.NewLine);
        MultiInstanceErrorText = MultiInstanceErrorText.Replace("\\n", Environment.NewLine);
    }
}