using System.Windows.Media.Imaging;
using App_SingleInstanceTrayGuide_Win.GUI.MVVM;
using App_SingleInstanceTrayGuide_Win.GUI.ViewModel.Commands;

namespace App_SingleInstanceTrayGuide_Win.GUI.ViewModel;

public class TrayGuideWindowViewModel : ViewModelBase
{
    private BitmapImage _appIconImage;
    private string _appIconText;
    private BitmapImage _overflowImage;
    private string _overflowText;
    private BitmapImage _taskbarImage;
    private string _titleLabelText;
    private string _okButtonText;

    private int _win_left;
    private int _win_top;
    private int _win_xHeight;
    private int _win_yHeight;


    public TrayGuideWindowViewModel()
    {
        // Set the default window dimensions
        // XWidth = 500;
        // YHeight = 660;

        // Create "close window" command object, passing a reference to this ViewModel 
        CloseWindowCommand = new CloseWindowCommand();
    }

    // -------------------- DATA BINDINGS START --------------------

    public string TitleLabelText { get => _titleLabelText; }
    public BitmapImage TaskbarImage { get => _taskbarImage; }
    public string AppIconText { get => _appIconText; }
    public BitmapImage AppIconImage { get => _appIconImage; }
    public string OverflowText { get => _overflowText; }
    public BitmapImage OverflowImage { get => _overflowImage; }
    public CloseWindowCommand CloseWindowCommand { get; set; }
    public string OKButtonText { get => _okButtonText; }

    
    // --------------------- WINDOW DIMENSIONS ---------------------

    // ----- X / Width

    public int XWidth
    {
        get => _win_xHeight;
        set
        {
            _win_xHeight = value;
            OnPropertyChanged();
        }
    }


    // ----- Y / Height

    public int YHeight
    {
        get => _win_yHeight;
        set
        {
            _win_yHeight = value;
            OnPropertyChanged();
        }
    }


    // ----- Left

    public int Left
    {
        get => _win_left;
        set
        {
            _win_left = value;
            OnPropertyChanged();
        }
    }


    // ----- Top

    public int Top
    {
        get => _win_top;
        set
        {
            _win_top = value;
            OnPropertyChanged();
        }
    }

    // --------------------- DATA BINDINGS END ---------------------
}