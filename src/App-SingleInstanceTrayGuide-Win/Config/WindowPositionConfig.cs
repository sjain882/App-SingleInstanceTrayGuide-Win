using System;
using System.Configuration;
using System.Windows; // for Point, SystemParameters

namespace App_SingleInstanceTrayGuide_Win.Config;

public class WindowPositionConfig : IConfig
{
    // User choice
    public WindowPosition ChosenPosition { get; private set; }
    
    // Actual location
    public Point CalculatedPosition { get; private set; }

    private readonly double _winWidth;
    private readonly double _winHeight;

    public WindowPositionConfig(double winWidth, double winHeight)
    {
        _winWidth = winWidth;
        _winHeight = winHeight;
        LoadConfig();
    }

    public void LoadConfig()
    {
        string windowPosition = ConfigurationManager.AppSettings["GUI_WindowPosition"];
        if (!Enum.TryParse(windowPosition, true, out WindowPosition parsedWindowPosition))
        {
            parsedWindowPosition = WindowPosition.BottomRight; // default
        }

        ChosenPosition = parsedWindowPosition;
        CalculatedPosition = CalculateLocation(ChosenPosition, _winWidth, _winHeight);
    }

    private Point CalculateLocation(WindowPosition chosenWindowPosition, double winWidth, double winHeight)
    {
        var workArea = SystemParameters.WorkArea;

        return chosenWindowPosition switch
        {
            WindowPosition.TopLeft     => new Point(workArea.Left, workArea.Top),
            WindowPosition.TopRight    => new Point(workArea.Right - winWidth, workArea.Top),
            WindowPosition.BottomLeft  => new Point(workArea.Left, workArea.Bottom - winHeight),
            WindowPosition.BottomRight => new Point(workArea.Right - winWidth, workArea.Bottom - winHeight),
            _                          => new Point(workArea.Right - winWidth, workArea.Bottom - winHeight)
        };
    }
}
