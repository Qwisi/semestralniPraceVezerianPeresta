using CommunityToolkit.Mvvm.Input;
using Program.Interfaces;
using Program.Model;
using System.Net.Mail;
using System.Windows;
using System;
using System.Windows.Input;

namespace Program.ViewModel
{
    public class SignInViewModel
    {
        public User User { get; set; } = new User();
        public ICommand ClickSignUp { get; }
        public ICommand ClickSignIn { get; }
        public ICommand ClickExit { get; }

        private readonly IWindowService _windowService;
        private readonly IMessageBoxService _messageBoxService;

        public SignInViewModel()
        {
            _windowService = new WindowService();
            _messageBoxService = new MessageBoxService();
            ClickSignUp = new RelayCommand(OpenSignUpWindow);
            ClickSignIn = new RelayCommand(SignIn);
            ClickExit = new RelayCommand(Exit);
        }

        private void SignIn()
        {
            if (ValidData())
            {
                DataBaseCorrector baseCorrector = new DataBaseCorrector();
                baseCorrector.CorrectUsers(User);
            }
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

        private void Exit()
        {
            CloseWindow();
        }

        private bool ValidData()
        {
            try
            {
                MailAddress addr = new MailAddress(User.Email);
                if (User.Password == null || User.Password.Length < 8)
                {
                    _messageBoxService.ShowMessageBox("Password is less than 8 digits", "Message Box Title",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                _messageBoxService.ShowMessageBox("Email address is not correct", "Message Box Title",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return false;
        }
    }
}
