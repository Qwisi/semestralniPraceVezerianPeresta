using CommunityToolkit.Mvvm.Input;
using Program.Interfaces;
using Program.Model;
using System.Windows;
using System.Windows.Input;

namespace Program.ViewModel
{
    public class SignInViewModel
    {
        public User User { get; set; }
        public ICommand ClickSignUp { get; }
        public ICommand ClickSignIn { get; }
        public ICommand ClickGuest { get; }
        public ICommand ClickExit { get; }

        private readonly IWindowService _windowService;
        private readonly IMessageBoxService _messageBoxService;

        public SignInViewModel()
        {
            _windowService = new WindowService();
            _messageBoxService = new MessageBoxService();

            
            ClickSignUp = new RelayCommand(OnSignUp);
            ClickSignIn = new RelayCommand(OnSignIn);
            ClickExit = new RelayCommand(OnExit);
            ClickGuest = new RelayCommand(OnGuest);
            User = new User("some@mail.com", "password");
        }

        private void OnSignIn()
        {
            string exception = string.Empty;
            if (DataChecker.ValidEmail(User.Email, ref exception) && DataChecker.ValidPass(User.Password, ref exception))
            {
                DataBaseCorrector baseCorrector = new DataBaseCorrector();
                bool isMeilProblem = false;
                if (baseCorrector.UserExist(User, ref isMeilProblem)) 
                {
                    _windowService.OpenWindow(new DataBaseViewModel(UsersEnum.USER_REGISTERED));
                    CloseWindow();
                }
                else
                {
                    string message = isMeilProblem ? "Email is incorrect!" : "Password is incorrect!";
                    _messageBoxService.ShowMessageBox(message, "Message Box Title",
                                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                _messageBoxService.ShowMessageBox(exception, "Message Box Title",
                                        MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void OnSignUp()
        {
            _windowService.OpenWindow(new SignUpViewModel());
            CloseWindow();
        }

        private void CloseWindow()
        {
            _windowService.CloseWindow(this);
        }

        private void OnExit()
        {
            CloseWindow();
        }

        private void OnGuest()
        {
            _windowService.OpenWindow(new DataBaseViewModel(UsersEnum.USER));
            CloseWindow();
        }
    }
}
