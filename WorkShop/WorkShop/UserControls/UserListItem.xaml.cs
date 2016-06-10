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

namespace WorkShop.UserControls
{
    /// <summary>
    /// Interaction logic for UserListItem.xaml
    /// </summary>
    public partial class UserListItem : UserControl
    {
        public UserListItem(string name, string role, int id)
        {
            InitializeComponent();
            Name.Content = name;
            Role.Content = role;
            Id.Content = id.ToString();
        }
    }
}