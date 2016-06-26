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
    public partial class ClientsPage : Page
    {
        public int LastClientId { get; set; }
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
            if (!ListBox.Items.IsEmpty)
            {
                var c = ListBox.SelectedItem as ClientListItem;
                if (c != null)
                {
                    _viewModel.FillFieldsByClickedItem(c.Client);
                    LastClientId = c.Client.clientID;
                }
            }
        }

        private void ObjectsListBox_OnSelectionChanged_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // throw new NotImplementedException();
        }

        private void SelectedObjectsButton_Click(object sender, RoutedEventArgs e)
        {
            if (LastClientId != 0) { 
                _viewModel.ClientsObjectsLoadCmd.Execute(LastClientId);
                if (ListBox.Visibility == Visibility.Visible)
                {
                    ListBox.Visibility = Visibility.Collapsed;
                    ObjectsListBox.Visibility = Visibility.Visible;
                    SelectedObjectsButton.Background = Brushes.Gray;
                }
                else
                {
                    ListBox.Visibility = Visibility.Visible;
                    ObjectsListBox.Visibility = Visibility.Collapsed;
                    SelectedObjectsButton.Background = Brushes.DodgerBlue;
                }
            }
           
        }
    }
}
