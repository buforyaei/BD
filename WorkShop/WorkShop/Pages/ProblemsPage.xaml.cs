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
    /// <summary>
    /// Interaction logic for ProblemsPage.xaml
    /// </summary>
    public partial class ProblemsPage : Page
    {
        private ProblemsViewModel _viewModel = new ProblemsViewModel();
        public ProblemsPage()
        {
            InitializeComponent();
            DataContext = _viewModel;
            _viewModel.LoadCmd.Execute(null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (StaticPagesUi.User.IsManaager())
            {
                if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.MenuManagerPage);
            }
            else if (StaticPagesUi.User.IsEmployy())
            {
                if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.MenuEmployyPage);
            }
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //nalezy stworzyc konstruktor z argumentami dla zazanczonego problemu do edycji
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.RegisterProblemPage);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
             if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.ProblemsTaskListPage);
        }
        
    }
}
