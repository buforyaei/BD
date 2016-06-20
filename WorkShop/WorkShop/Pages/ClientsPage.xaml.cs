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
using WorkShop.UserControls;
using WorkShop.ViewModel;

namespace WorkShop.Pages
{
    /// <summary>
    /// Interaction logic for ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        private ClientsViewModel _viewModel = new ClientsViewModel(); 
        public ClientsPage()
        {
            InitializeComponent();
            DataContext = _viewModel;
            _viewModel.LoadCmd.Execute(null);
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.MenuManagerPage);
        }
    
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var c = e.AddedItems[0] as ClientListItem;
            if (c != null) _viewModel.FillFieldsByClickedItem(c.Client);
        }
    }
}
