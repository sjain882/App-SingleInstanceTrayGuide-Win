using App_SingleInstanceTrayGuide_Win.Infrastructure.Theming;
using Microsoft.Win32;

namespace App_SingleInstanceTrayGuide_Win.Infrastructure.Theming;

public class OSThemeDetector : IOSThemeDetector
{
    public bool IsDarkThemeEnabled()
    {
        int appsUseLightTheme = 1;
        bool isDarkThemeEnabled = false;

        try
        {
            appsUseLightTheme = (int)Registry.GetValue(
                @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize",
                "AppsUseLightTheme",
                -1);
        }
        catch
        {
            return false;
        }

        if (appsUseLightTheme == 0)
            isDarkThemeEnabled = true;

        return isDarkThemeEnabled;
    }
}
