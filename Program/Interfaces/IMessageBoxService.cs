using System.Windows;

namespace Program.Interfaces
{
    public interface IMessageBoxService
    {
        void ShowMessageBox(string message, string title, MessageBoxButton button, MessageBoxImage icon);
    }
}
