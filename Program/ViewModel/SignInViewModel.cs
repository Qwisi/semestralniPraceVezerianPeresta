using CommunityToolkit.Mvvm.Input;
using Program.Model;
using System.Windows.Input;

namespace Program.ViewModel
{
    public class SignInViewModel
    {
        public User User { get; set; } = new User();
        public ICommand ClickSignUp { get; }
        public ICommand ClickSignIn { get; }

        private readonly IWindowService _windowService;

        public SignInViewModel(IWindowService windowService)
        {
            _windowService = windowService;
            ClickSignUp = new RelayCommand(OpenSignUpWindow);
            ClickSignIn = new RelayCommand(WriteDataToBase);
        }

        private void WriteDataToBase()
        {
            DataBaseCorrector baseCorrector = new DataBaseCorrector();
            baseCorrector.CorrectUsers(User);
        }

        private void OpenSignUpWindow()
        {
            _windowService.OpenWindow(new SignUpViewModel());
            CloseWindow();
        }

        private void CloseWindow()
        {
            _windowService.CloseWindow(this);
        }
    }
}
