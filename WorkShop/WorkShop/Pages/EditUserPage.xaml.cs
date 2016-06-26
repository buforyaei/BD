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
    public partial class EditUserPage : Page
    {
        public UserListItem SelectedUserItem { get; set; }

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

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.AddUserPage);
        }

        private void GoBackButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.MenuAdminPage);
        }
      
        private void EditUser_Click_1(object sender, RoutedEventArgs e)
        {
            if (SelectedUserItem != null)
            {
                var user = BizLayer.Query.EmployeesQuery.GetEmployee(Int32.Parse(SelectedUserItem.Id.Content.ToString())).ToList();

                if (NavigationService != null) NavigationService.Navigate(new AddUserPage(user.First()));
            }
           
        }

        private void DeleteUser_OnClick(object sender, RoutedEventArgs e)
        {
           //deleteuser with BizLayer
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!ListBox.Items.IsEmpty)
            {
                var c = ListBox.SelectedItem as UserListItem;
                if (c != null) SelectedUserItem = c;
            }
        }
    }
}
