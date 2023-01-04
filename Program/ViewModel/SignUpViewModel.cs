using CommunityToolkit.Mvvm.Input;
using Program.Interfaces;
using Program.Model;
using System.Windows.Input;
using System.Windows;

namespace Program.ViewModel
{
    public class SignUpViewModel
    {
        private readonly IWindowService _windowService;
        private readonly IMessageBoxService _messageBoxService;
        public User User { get; set; }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { _confirmPassword = value; }
        }
        public ICommand ClickSignUp { get; }
        public ICommand ClickBack { get; }

        public SignUpViewModel() {
            _windowService = new WindowService();
            _messageBoxService = new MessageBoxService();

            ClickSignUp = new RelayCommand(OnSignUp);
            ClickBack = new RelayCommand(OnBack);
            User = new User("some@mail.com", "password");
            ConfirmPassword = "confirm password";
        }

        private void OnSignUp()
        {
            string exception = string.Empty;
            if (DataChecker.ValidEmail(User.Email, ref exception) 
                && DataChecker.ValidPass(User.Password, ref exception) 
                && DataChecker.CheckPasswordEquals(User.Password, _confirmPassword, ref exception))
            {
                DataBaseCorrector baseCorrector = new DataBaseCorrector();
                if (baseCorrector.LineInTableExist(TablesEnum.USER, "user_name", User.Email))
                {
                    _messageBoxService.ShowMessageBox("User already exist", "Message Box Title",
                                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    baseCorrector.AddUser(User);
                    _windowService.OpenWindow(new DataBaseViewModel(UsersEnum.USER_REGISTERED));
                    CloseWindow();
                }
            }
            else
            {
                _messageBoxService.ShowMessageBox(exception, "Message Box Title",
                                        MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
