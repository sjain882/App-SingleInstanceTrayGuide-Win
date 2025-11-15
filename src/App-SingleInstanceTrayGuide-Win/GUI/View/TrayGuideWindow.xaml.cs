using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using App_SingleInstanceTrayGuide_Win.Config;
using App_SingleInstanceTrayGuide_Win.GUI.ViewModel;

namespace App_SingleInstanceTrayGuide_Win;

/// <summary>
/// Interaction logic for TrayGuideWindow.xaml
/// </summary>
public partial class TrayGuideWindow : Window
{
    private TrayGuideWindowViewModel ViewModel;
    
    public TrayGuideWindow(TrayGuideWindowConfig trayGuideWindowConfig)
    {
        ViewModel = new TrayGuideWindowViewModel(trayGuideWindowConfig);
        DataContext = ViewModel;
        
        InitializeComponent();
    }
}