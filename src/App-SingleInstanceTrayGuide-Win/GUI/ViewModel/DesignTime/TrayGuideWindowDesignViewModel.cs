using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using App_SingleInstanceTrayGuide_Win.Config;
using App_SingleInstanceTrayGuide_Win.GUI.Infrastructure.Commands;

namespace App_SingleInstanceTrayGuide_Win.GUI.ViewModel.DesignTime;

public class TrayGuideWindowDesignViewModel
{
    // -------------------- DATA BINDINGS (EXAMPLE VALUES) --------------------

    public string TitleLabelText => "OBS is already running!";

    public BitmapImage TaskbarImage => new BitmapImage(
        new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Taskbar.png")));

    public string TaskbarGuideText => "Down here in the bottom right of the screen:";

    public string AppControlText => "Right click this icon to control it:";

    public BitmapImage AppIconImage => new BitmapImage(
        new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "AppIcon.png")));

    public string OverflowText => "If you can't find it,"
        + Environment.NewLine + "click this icon to check the overflow area:";

    public BitmapImage OverflowImage => new BitmapImage(
        new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Overflow.png")));

    public string OKButtonText => "OK";

    // --------------------- OK BUTTON COMMAND ---------------------

    public CloseWindowCommand CloseWindowCommand => new CloseWindowCommand();

    // --------------------- WINDOW DIMENSIONS ---------------------

    //public int XWidth => 400;
    //public int YHeight => 300;
    //public int Left   => 100;
    //public int Top    => 100;
}