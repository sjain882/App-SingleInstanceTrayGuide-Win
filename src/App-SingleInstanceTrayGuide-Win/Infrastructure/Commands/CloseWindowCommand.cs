using System.Windows;
using System.Windows.Input;

namespace App_SingleInstanceTrayGuide_Win.GUI.Infrastructure.Commands;

public class CloseWindowCommand : ICommand
{
    public bool CanExecute(object parameter)
    {
        return true;
    }
    
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
    
    public void Execute(object? parameter)
    {
        Application.Current.Shutdown(0);
    }
}