using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using WorkShop.Models;
using WorkShop.ViewModel;

namespace WorkShop.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private LoginViewModel _viewModel = new LoginViewModel();
        private ProgressBar ProgressBarMainWindow { get; set; }
        private Label LoginLabelMainWindow { get; set; }
        public LoginPage()
        {
            InitializeComponent();
            //ProgressBarMainWindow = progressBar;
            DataContext = _viewModel;
            /////////////////
            LoginBox.Text = "mant";
            //LoginBox.Text = "admint";
            //LoginBox.Text = "emoplt";
            LoginLabel.Visibility = Visibility.Collapsed;
            ////////////////
        }
        public LoginPage(ProgressBar progressBar, Label loadingLabel)
        {
            InitializeComponent();
            ProgressBarMainWindow = progressBar;
            LoginLabelMainWindow = loadingLabel;
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
            ProgressBar.Visibility = Visibility.Visible;
            Login();
         
            ProgressBar.Visibility = Visibility.Hidden;   
        }

        private void Login()
        {
            BizLayer.Query.PersonQuery.AddPerson("Admin Test", "Rybnik", "Rynek", "23A", "769865456");
            BizLayer.Query.PersonQuery.AddPerson("ManAger Test", "Rybnik", "Rudzka", "13A", "769865456");
            BizLayer.Query.PersonQuery.AddPerson("Jessica Mak", "Rybnik", "Rudzka", "13C", "769865456");
            BizLayer.Query.PersonQuery.AddPerson("Sebastian Orc", "Ruda", "Kopernika", "1", "764265456");
            BizLayer.Query.EmployeesQuery.AddEmployee("admint", "".GetHashCode().ToString(), "Admin", 1);
            BizLayer.Query.EmployeesQuery.AddEmployee("mant", "".GetHashCode().ToString(), "Manager", 2);
            BizLayer.Query.EmployeesQuery.AddEmployee("Jessica Mak", "".GetHashCode().ToString(), "Employy", 3);
            BizLayer.Query.EmployeesQuery.AddEmployee("Sebastian Orc", "".GetHashCode().ToString(), "Employy", 4);
            //////////////////////
            BizLayer.Query.PersonQuery.AddPerson("Johan", "Oslo", "Uber Strase", "253", "789456123");
            BizLayer.Query.PersonQuery.AddPerson("Tom Scavo", "Sadney", "WhisteriaLane", "1012", "325623564");
            BizLayer.Query.ClientQuery.AddClient(4);
            BizLayer.Query.ClientQuery.AddClient(5);
            BizLayer.Query.ObjectQuery.AddObject(1, "Opel Corsa", "SWD0545");
            BizLayer.Query.ObjectQuery.AddObject(1, "Volvo S60", "SJZ4564");
            BizLayer.Query.ObjectQuery.AddObject(2, "Fiat Punto", "SWD0545");
            BizLayer.Query.ProblemQuery.AddProblem(DateTime.Today, DateTime.MaxValue, "Wymiana opon.", null, 1);
            BizLayer.Query.ProblemQuery.AddProblem(new DateTime(2016, 1, 5), DateTime.Today, "Lakierowanie nadkola - lewego.", "Wykonano wszystko pomyślnie.", 2);
            BizLayer.Query.ProblemQuery.AddProblem(new DateTime(2016, 3, 15), new DateTime(2016, 4, 1), "Spawanie progów", "All Done correctly", 1);
            ///////////////////
            var persons = BizLayer.Query.PersonQuery.GetPersons().ToArray();
            StaticPagesUi.User.UserLoggedIn(LoginBox.Text, PasswordBox.Password.GetHashCode().ToString());
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
           // StaticPagesUi.User = new User();
           // BizLayer.Query.ObjectQuery.GetObjects();
            Page.Visibility = Visibility.Visible;
            if (LoginLabelMainWindow != null && ProgressBarMainWindow != null)
            {
                LoginLabelMainWindow.Visibility = Visibility.Collapsed;
                ProgressBarMainWindow.Visibility = Visibility.Collapsed;
            }
            
        }
    }
}
