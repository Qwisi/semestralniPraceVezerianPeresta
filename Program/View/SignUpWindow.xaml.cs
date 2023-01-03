using Program.Model;
using Program.ViewModel;
using System.Windows;

namespace Program.View
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
            DataContext = new SignUpViewModel();
        }

        private void colorButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
