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
        private UsersEnum _userType;

        public UsersEnum UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        private TablesEnum _selectedComboBoxItem;
        public TablesEnum SelectedComboBoxItem
        {
            get { return _selectedComboBoxItem; }
            set { 
                _selectedComboBoxItem = value;
                ShowTable(value);
            }
        }

        private ObservableCollection<Goods> _items;
        public ObservableCollection<Goods> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        private readonly IWindowService _windowService;
        private readonly IMessageBoxService _messageBoxService;

        public ICommand ClickBack { get; }

        public ObservableCollection<TablesEnum> ComboBoxItems { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DataBaseViewModel(UsersEnum userType)
        {
            _userType = userType;

            _items = new ObservableCollection<Goods>();
            _windowService = new WindowService();
            _messageBoxService = new MessageBoxService();
            ClickBack = new RelayCommand(OnBack);

            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            if (_userType == UsersEnum.USER)
            {
                ComboBoxItems = new ObservableCollection<TablesEnum>
                {
                    TablesEnum.GOODS,
                    TablesEnum.STORAGE
                };
            }
            if (_userType == UsersEnum.USER_REGISTERED)
            {
                ComboBoxItems = new ObservableCollection<TablesEnum>
                {
                    TablesEnum.ADRESS,
                    TablesEnum.GOODS,
                    TablesEnum.CLIENT,
                    TablesEnum.STORAGE,
                };
            }
            if (_userType == UsersEnum.ADMIN)
            {
                ComboBoxItems = new ObservableCollection<TablesEnum>
                {
                    TablesEnum.ADRESS,
                    TablesEnum.CARD,
                    TablesEnum.CASH,
                    TablesEnum.GOODS,
                    TablesEnum.INSURANCE,
                    TablesEnum.CLIENT,
                    TablesEnum.PAYMENT,
                    TablesEnum.STORAGE,
                    TablesEnum.USER,
                    TablesEnum.WORKER,
                };
            }
            SelectedComboBoxItem = TablesEnum.GOODS;
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

        private void ShowTable(TablesEnum table)
        {
            DataBaseCorrector dataBaseCorrector = new DataBaseCorrector();
            _items?.Clear();
            _items = dataBaseCorrector.GetTable(table);
        }
    }
}
