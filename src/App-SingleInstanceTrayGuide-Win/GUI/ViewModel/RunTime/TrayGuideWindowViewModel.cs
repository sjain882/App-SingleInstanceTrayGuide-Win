using System.Windows;
using System.Windows.Media.Imaging;
using App_SingleInstanceTrayGuide_Win.Config;
using App_SingleInstanceTrayGuide_Win.GUI.MVVM;
using App_SingleInstanceTrayGuide_Win.GUI.Infrastructure.Commands;

namespace App_SingleInstanceTrayGuide_Win.GUI.ViewModel;

public class TrayGuideWindowViewModel : ViewModelBase
{
    private TrayGuideWindowConfig _trayGuideWindowConfig;

    private BitmapImage _appIconImage;
    private string _appControlText;
    private BitmapImage _overflowImage;
    private string _overflowText;
    private BitmapImage _taskbarImage;
    private string _titleLabelText;
    private string _okButtonText;

    private int _win_left;
    private int _win_top;
    private int _win_xHeight;
    private int _win_yHeight;


    public TrayGuideWindowViewModel(TrayGuideWindowConfig trayGuideWindowConfig)
    {
        _trayGuideWindowConfig = trayGuideWindowConfig;
        
        TitleLabelText = _trayGuideWindowConfig.TitleLabelText;
        TaskbarImage = _trayGuideWindowConfig.TaskbarImage;
        AppControlText = _trayGuideWindowConfig.AppControlText;
        AppIconImage = _trayGuideWindowConfig.AppIconImage;
        OverflowText = _trayGuideWindowConfig.OverflowText;
        OverflowImage = _trayGuideWindowConfig.OverflowImage;
        OKButtonText = _trayGuideWindowConfig.OKButtonText;
        
        CloseWindowCommand = new CloseWindowCommand();
    }

    public void UpdateWindowPosition(Point windowPosition)
    {
        Left = (int)windowPosition.X;
        Top  = (int)windowPosition.Y;
    }

    // -------------------- DATA BINDINGS START --------------------

    public string TitleLabelText
    {
        get => _titleLabelText;
        set
        {
            _titleLabelText = value;
            OnPropertyChanged();
        }
    }

    public BitmapImage TaskbarImage
    {
        get => _taskbarImage;
        set
        {
            _taskbarImage = value;
            OnPropertyChanged();
        }
    }

    public string AppControlText
    {
        get => _appControlText;
        set
        {
            _appControlText = value;
            OnPropertyChanged();
        }
    }

    public BitmapImage AppIconImage
    {
        get => _appIconImage;
        set
        {
            _appIconImage = value;
            OnPropertyChanged();
        }
    }

    public string OverflowText
    {
        get => _overflowText;
        set
        {
            _overflowText = value;
            OnPropertyChanged();
        }
    }

    public BitmapImage OverflowImage
    {
        get => _overflowImage;
        set
        {
            _overflowImage = value;
            OnPropertyChanged();
        }
    }

    public string OKButtonText
    {
        get => _okButtonText;
        set
        {
            _okButtonText = value;
            OnPropertyChanged();
        }
    }
    
    
    // --------------------- OK BUTTON COMMAND ---------------------
    
    public CloseWindowCommand CloseWindowCommand { get; set; }

    
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