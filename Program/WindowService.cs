using System;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Program.Model
{
    public class WindowService : IWindowService
    {
        public void OpenWindow(object viewModel)
        {
            Type viewType = GetViewType(viewModel);
            Window window = (Window)Activator.CreateInstance(viewType);
            window.DataContext = viewModel;
            window.Show();
        }

        public void CloseWindow(object viewModel)
        {
            Type viewType = GetViewType(viewModel);
            Window window = (Window)Application.Current.Windows.OfType<Window>()
                .FirstOrDefault(w => w.DataContext == viewModel);
            window?.Close();
        }

        private Type GetViewType(object viewModel)
        {
            string viewTypeName = viewModel.GetType().Name.Replace("ViewModel", "Window");
            return Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == viewTypeName);
        }
    }
}
