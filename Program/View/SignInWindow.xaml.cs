﻿using Program.ViewModel;
using System;
using System.Windows;

namespace Program.View
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
            DataContext = new SignInViewModel();
        }
    }
}
