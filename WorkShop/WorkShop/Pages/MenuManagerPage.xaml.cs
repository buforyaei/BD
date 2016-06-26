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
using WorkShop.Models;
using WorkShop.ViewModel;

namespace WorkShop.Pages
{
    /// <summary>
    /// Interaction logic for MenuManagerPage.xaml
    /// </summary>
    public partial class MenuManagerPage : Page
    {
        public MenuManagerPage()
        {
            InitializeComponent();
        }

        private void ObjectsButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.ObjectListPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.ProblemsPage);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.SearchPage);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.Cleanup();
            // Application.Current.Shutdown();
            StaticPagesUi.User = new User();
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.LoginPage);
        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
           if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.ClientsPage);
        }

        private void RegisterProblemButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.RegisterProblemPage);
        }
    }
}
