﻿using StoreManager.Models.Abstract.Classes;
using StoreManager.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using StoreManager.ViewModels.Services;
using StoreManager.Views.Admin.Interactions.Creating;
using StoreManager.DB_classes;

namespace StoreManager.ViewModels.Admin.Interactions.Creating
{
    public class CreateCategoryViewModel : ViewModelBase
    {
        private readonly ManagerStoreInteraction _admin;
        private readonly CreateCategoryView createCategoryView;
        public CreateCategoryViewModel(ManagerStoreInteraction admin)
        {
            _admin = admin ?? throw new ArgumentNullException(nameof(admin));

            CreateCategoryButtonCommand = new RelayCommand(CreateCategory, CanCreateCategory);
            LoadData();

            createCategoryView = new CreateCategoryView()
            {
                DataContext = this
            };
            createCategoryView.Show();
        }


        private void LoadData()
        {
            DataTable categoriesTable = _admin.GetDataFromView("ProductsCategoriesView");
            foreach (DataRow row in categoriesTable.Rows)
            {
                ComboBoxParentCategoryItemsSource.Add(new ComboBoxItem
                {
                    Tag = row[0],
                    Content = row[1]
                });
            }
        }

        #region Properties

        private string _categoryNameText;
        public string CategoryNameText
        {
            get => _categoryNameText;
            set => SetProperty(ref _categoryNameText, value, nameof(CategoryNameText));
        }

        private string _categoryDescriptionText;
        public string CategoryDescriptionText
        {
            get => _categoryDescriptionText;
            set => SetProperty(ref _categoryDescriptionText, value, nameof(CategoryDescriptionText));
        }

        private ObservableCollection<ComboBoxItem> _comboBoxParentCategoryItemsSource = new ObservableCollection<ComboBoxItem>();
        public ObservableCollection<ComboBoxItem> ComboBoxParentCategoryItemsSource
        {
            get => _comboBoxParentCategoryItemsSource;
            set
            {
                if (_comboBoxParentCategoryItemsSource != value)
                {
                    _comboBoxParentCategoryItemsSource = value;
                    OnPropertyChanged(nameof(ComboBoxParentCategoryItemsSource));
                }
            }
        }

        private ComboBoxItem _comboBoxParentCategorySelectedItem;
        public ComboBoxItem ComboBoxParentCategorySelectedItem
        {
            get => _comboBoxParentCategorySelectedItem;
            set
            {
                if (_comboBoxParentCategorySelectedItem != value)
                {
                    _comboBoxParentCategorySelectedItem = value;
                    OnPropertyChanged(nameof(ComboBoxParentCategorySelectedItem));
                }
            }
        }

        #endregion

        #region Commands

        public ICommand CreateCategoryButtonCommand { get; }

        private void CreateCategory(object parameter)
        {
            int? parentCategoryId = ComboBoxParentCategorySelectedItem?.Tag != null
                ? Convert.ToInt32(ComboBoxParentCategorySelectedItem.Tag)
                : (int?)null;

            Category category = new Category(CategoryNameText, CategoryDescriptionText, parentCategoryId);

            _admin.CreateCategory(category);
            MessageBox.Show("Category created");
            createCategoryView.Close();
        }

        private bool CanCreateCategory(object parameter)
        {
            return !string.IsNullOrEmpty(CategoryNameText) && !string.IsNullOrEmpty(CategoryDescriptionText);
        }

        #endregion
    }
}
