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
        protected void OnNavigatedTo(NavigationEventArgs e)
        {
           _viewModel.LoadCmd.Execute(null);

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
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

        private void EditProblem_Click(object sender, RoutedEventArgs e)
        {

            foreach(var item in _viewModel.ProblemsList)
            {
                if (item.IsSelected)
                {
                    var editProblem = new RegisterProblemPage(item);
                    if (NavigationService != null) NavigationService.Navigate(editProblem);
                    return;
                }
             
               
            }
        }

        private void TasksList_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in _viewModel.ProblemsList)
            {
                if (item.IsSelected)
                {
                    if (NavigationService != null) NavigationService.Navigate(new ProblemsTaskListPage(item));
                    return;
                }


            }
        }

        private void Page_GotFocus(object sender, RoutedEventArgs e)
        {
           
        }

        private async void ListView_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
           
        }

      


    }
}
