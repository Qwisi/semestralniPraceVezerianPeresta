﻿using StoreManager.DB_classes;
using StoreManager.ViewModels.Core;
using StoreManager.ViewModels.Services;
using StoreManager.ViewModels.Sign;
using StoreManager.ViewModels.StoreInteraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private INavigationService _navigation;
        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }
        private User user;
        public RelayCommand NavigateToMainSignCommand { get; set; }
        public MainWindowViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            NavigateToMainSignCommand = new RelayCommand(NavigateToMainSignViewModel);
            NavigateToMainSignCommand.Execute(this);
        }
        public MainWindowViewModel(User user, INavigationService navigation)
        {
            this.user = user;
            Navigation = navigation;
            NavigateToMainSignCommand = new RelayCommand(NavigateToMainSignViewModelWithParameter);
            NavigateToMainSignCommand.Execute(this);
        }
        private void NavigateToMainSignViewModel(object parameter)
        {
            Navigation.NavigateTo<MainStoreInterationViewModel>();
        }
        private void NavigateToMainSignViewModelWithParameter(object parameter)
        {
            Navigation.NavigateTo<MainStoreInterationViewModel>(user);
        }
    }
}
