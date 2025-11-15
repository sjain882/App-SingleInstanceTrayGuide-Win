using System.Configuration;

namespace App_SingleInstanceTrayGuide_Win.Config;

public class DebugConfig
{
    public int ShowGUI { get; set; }

    public void LoadConfig()
    {
        ShowGUI = int.TryParse(ConfigurationManager.AppSettings["Debug_ShowGUI"], out int d) ? d : 0;
    }
}