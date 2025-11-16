using System.Windows.Media.Imaging;
using App_SingleInstanceTrayGuide_Win.Config;
using App_SingleInstanceTrayGuide_Win.GUI.Infrastructure.Commands;

namespace App_SingleInstanceTrayGuide_Win.GUI.ViewModel.DesignTime;

public class TrayGuideWindowDesignViewModel
{
    // -------------------- DATA BINDINGS (EXAMPLE VALUES) --------------------

    public string TitleLabelText => "Tray Guide Window";

    public BitmapImage TaskbarImage => new BitmapImage(
        new Uri("pack://application:,,,/images/taskbar.png"));

    public string AppControlText => "Control Panel";

    public BitmapImage AppIconImage => new BitmapImage(
        new Uri("pack://application:,,,/images/obs.png"));

    public string OverflowText => "Overflow Menu";

    public BitmapImage OverflowImage => new BitmapImage(
        new Uri("pack://application:,,,/images/overflow.png"));

    public string OKButtonText => "OK";

    // --------------------- OK BUTTON COMMAND ---------------------

    public CloseWindowCommand CloseWindowCommand => new CloseWindowCommand();

    // --------------------- WINDOW DIMENSIONS ---------------------

    public int XWidth => 400;
    public int YHeight => 300;
    public int Left   => 100;
    public int Top    => 100;


}