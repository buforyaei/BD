using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using WorkShop.ViewModel;

namespace WorkShop.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private LoginViewModel _viewModel = new LoginViewModel();
        
        public LoginPage()
        {
            InitializeComponent();
            
            DataContext = _viewModel;
            /////////////////
            LoginBox.Text = "manager";
            //LoginBox.Text = "admin";
            //LoginBox.Text = "emoployy";
            LoginLabel.Visibility = Visibility.Collapsed;
            ////////////////
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PasswordBox.Password != "") LoginLabel.Visibility = Visibility.Collapsed;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text != "") LoginLabel.Visibility = Visibility.Collapsed;


        }

        private void PasswordLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PasswordLabel.Visibility = Visibility.Collapsed;
            LoginBox.Focus();
            
            
        }

        private void LoginLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginLabel.Visibility = Visibility.Collapsed;
            LoginBox.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StaticPagesUi.User.UserLoggedIn(LoginBox.Text, PasswordBox.Password);
            if (NavigationService != null)
            {
                if (StaticPagesUi.User.IsAdmin()) NavigationService.Navigate(StaticPagesUi.MenuAdminPage);
                    //next goes to emoloyy instead of manager menu
                else if (StaticPagesUi.User.IsManaager()) NavigationService.Navigate(StaticPagesUi.MenuManagerPage);
                else if (StaticPagesUi.User.IsEmployy()) NavigationService.Navigate(StaticPagesUi.MenuEmployyPage);
                else Application.Current.Shutdown();
              
            }
                
        }
    }
}
