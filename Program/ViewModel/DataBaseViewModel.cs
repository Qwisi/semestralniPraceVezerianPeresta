using CommunityToolkit.Mvvm.Input;
using Program.Interfaces;
using Program.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Program.ViewModel
{
    public class DataBaseViewModel : INotifyPropertyChanged
    {
        private UsersEnum _userType = UsersEnum.USER;

        public UsersEnum UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        private TablesEnum _selectedComboBoxItem;
        public TablesEnum SelectedComboBoxItem
        {
            get { return _selectedComboBoxItem; }
            set { _selectedComboBoxItem = value; }
        }

        private readonly IWindowService _windowService;
        private readonly IMessageBoxService _messageBoxService;

        public ICommand ClickBack { get; }

        public ICommand ClickShowTable { get; }

        private ObservableCollection<Adress> _items;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Adress> DataTable
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public DataBaseViewModel(UsersEnum userType)
        {
            _userType = userType;

            SelectedComboBoxItem = TablesEnum.ADRESS;

            _items = new ObservableCollection<Adress>();
            _windowService = new WindowService();
            _messageBoxService = new MessageBoxService();
            ClickBack = new RelayCommand(OnBack);
            ClickShowTable = new RelayCommand(OnShowTable);
        }

        public DataBaseViewModel()
        {
            SelectedComboBoxItem = TablesEnum.GOODS;

            _items = new ObservableCollection<Adress>();
            _windowService = new WindowService();
            _messageBoxService = new MessageBoxService();
            ClickBack = new RelayCommand(OnBack);
            ClickShowTable = new RelayCommand(OnShowTable);
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

        private void OnShowTable()
        {
            DataBaseCorrector dataBaseCorrector = new DataBaseCorrector();
            _items.Clear();
            _items = dataBaseCorrector.GetTable(_selectedComboBoxItem);
            OnPropertyChanged("DataTable");
        }
    }
}
