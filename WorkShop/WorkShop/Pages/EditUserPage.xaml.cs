using System;
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
using WorkShop.ViewModel;

namespace WorkShop.Pages
{
    public partial class EditUserPage : Page
    {


        private EditUserViewModel ViewModel
        {
            get { return DataContext as EditUserViewModel; }
        }

        public EditUserPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.LoadCmd.Execute(null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.AddUserPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.MenuAdminPage);
        }
    }
}
