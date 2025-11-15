using System.Configuration;

namespace App_SingleInstanceTrayGuide_Win.Config;

public class DebugConfig : IConfig
{
    public int ShowGUI { get; set; }
    
    public DebugConfig() => LoadConfig();

    public void LoadConfig()
    {
        ShowGUI = int.TryParse(ConfigurationManager.AppSettings["Debug_ShowGUI"], out int d) ? d : 0;
    }
}