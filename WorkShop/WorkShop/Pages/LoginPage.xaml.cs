using System.Linq;
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
            LoginBox.Text = "mant";
            //LoginBox.Text = "admint";
            //LoginBox.Text = "emoplt";
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
            BizLayer.Query.PersonQuery.AddPerson("Admin Test", "Rybnik", "Rynek", "23A", "769865456");
            BizLayer.Query.PersonQuery.AddPerson("ManAger Test", "Rybnik", "Rudzka", "13A", "769865456");
            BizLayer.Query.PersonQuery.AddPerson("Employee Test", "Rybnik", "Rudzka", "13C", "769865456");
            BizLayer.Query.EmployeesQuery.AddEmployee("admint", "", "Admin", 1);
            BizLayer.Query.EmployeesQuery.AddEmployee("mant", "", "Manager", 2);
            BizLayer.Query.EmployeesQuery.AddEmployee("emplt", "", "Employy", 3);
            //////////////////////
            BizLayer.Query.PersonQuery.AddPerson("Johan", "Oslo", "TsjfStrrer", "253", "789456123");
            BizLayer.Query.PersonQuery.AddPerson("Tom Scavo", "Sadney", "WhisteriaLane", "1012", "325623564");
            BizLayer.Query.ClientQuery.AddClient(4);
            BizLayer.Query.ClientQuery.AddClient(5);

            /////////////////////
            var persons =   BizLayer.Query.PersonQuery.GetPersons().ToArray();
            StaticPagesUi.User.UserLoggedIn(LoginBox.Text, PasswordBox.Password);
            var users = BizLayer.Query.EmployeesQuery.GetEmployees();
            if (NavigationService != null && _viewModel.Login())
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
