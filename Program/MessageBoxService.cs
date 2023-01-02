using Program.Interfaces;
using System.Windows;

namespace Program
{
    public class MessageBoxService : IMessageBoxService
    {
        public void ShowMessageBox(string message, string title, MessageBoxButton button, MessageBoxImage icon)
        {
            MessageBox.Show(message, title, button, icon);
        }
    }
}
