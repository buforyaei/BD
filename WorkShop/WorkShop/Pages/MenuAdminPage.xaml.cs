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

namespace WorkShop.Pages
{
    /// <summary>
    /// Interaction logic for AdminMenuPage.xaml
    /// </summary>
    public partial class MenuAdminPage : Page
    {
        public MenuAdminPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.AddUserPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.EditUserPage);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.RaportPage);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
