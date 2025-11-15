using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App_SingleInstanceTrayGuide_Win.GUI.MVVM;

public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    // Call at end of each property's setter
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}