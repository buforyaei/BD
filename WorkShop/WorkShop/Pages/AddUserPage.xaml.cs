﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataLayer;
using WorkShop.Models;
using WorkShop.ViewModel;

namespace WorkShop.Pages
{
    /// <summary>
    /// Interaction logic for AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        private AddUserViewModel _viewModel = new AddUserViewModel();
        public AddUserPage()
        {
            InitializeComponent();
            DataContext = _viewModel;
            _viewModel.LoadCmd.Execute(null);
            Street.Height = Cityy.Height;
        }
        public AddUserPage(Employee employee)
        {
            InitializeComponent();
            DataContext = _viewModel;
            _viewModel.Employee = employee;
          _viewModel.FillFieldsWithUser();
            Login.IsEnabled = false;
            Street.Height = Cityy.Height;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.Cleanup();
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.MenuAdminPage);
        }

        private void Password_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.Password = Password.Password;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _viewModel.AddUserCmd.Execute(null);
            Password.Password = "";
            if (_viewModel.WasSuccesfull)
                Login.IsEnabled = true;
        }
    }
}
