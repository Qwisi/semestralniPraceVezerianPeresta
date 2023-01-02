using CommunityToolkit.Mvvm.Input;
using Program.Interfaces;
using Program.Model;
using System.Windows.Input;

namespace Program.ViewModel
{
    public class DataBaseViewModel
    {
        private UsersEnum _userType = UsersEnum.USER;

        public UsersEnum UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        private readonly IWindowService _windowService;
        private readonly IMessageBoxService _messageBoxService;

        public ICommand ClickBack { get; }

        public DataBaseViewModel(UsersEnum userType)
        {
            _userType = userType;
            _windowService = new WindowService();
            _messageBoxService = new MessageBoxService();
            ClickBack = new RelayCommand(OnBack);
        }

        public DataBaseViewModel()
        {
            _windowService = new WindowService();
            _messageBoxService = new MessageBoxService();
            ClickBack = new RelayCommand(OnBack);
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
