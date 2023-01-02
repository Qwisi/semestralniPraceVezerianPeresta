using CommunityToolkit.Mvvm.Input;
using Program.Model;
using System.Windows.Input;

namespace Program.ViewModel
{
    public class SignUpViewModel
    {
        private WindowService _windowService { get; set; }

        public User User { get; set; }

        public ICommand ClickSignIn { get; }
        public ICommand ClickBack { get; }

        public SignUpViewModel() {
            _windowService = new WindowService();
            ClickSignIn = new RelayCommand(OnSignIn);
            ClickBack = new RelayCommand(OnBack);
            User = new User();
        }

        private void OnSignIn()
        {
            DataBaseCorrector dataBase = new DataBaseCorrector();
            dataBase.CorrectUsers(User);


            _windowService.OpenWindow(new SignInViewModel());
            CloseWindow();
        }
        private void OnBack()
        {
            _windowService.OpenWindow(new SignInViewModel());
            CloseWindow();
        }

        private void CloseWindow()
        {
            _windowService.CloseWindow(this);
        }
    }
}
