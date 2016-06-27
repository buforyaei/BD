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
    public partial class ProblemsTaskListPage : Page
    {
        private ProblemsTaskListViewModel _viewModel = new ProblemsTaskListViewModel();
    

        public ProblemsTaskListPage()
        {
            InitializeComponent();
            DataContext = _viewModel;
            _viewModel.LoadCmd.Execute(null);
        }

        public ProblemsTaskListPage(ProblemListItem problemlistItem)
        {
            InitializeComponent();
            DataContext = _viewModel;
            _viewModel.CurrentProblem = problemlistItem;
            
            _viewModel.LoadCmd.Execute(null);
            if (StaticPagesUi.User.IsEmployy())
            {
                ComboBox.IsEnabled = false;
                Description.IsEnabled = false;
                BeginDate.IsEnabled = false;
            }
             
            
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.MenuManagerPage);
        }

        private void CurrentProblemGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CurrentProblemGrid.Visibility == Visibility.Visible)
            {
                CurrentProblemGrid.Visibility = Visibility.Collapsed;
                Problem.Visibility = Visibility.Visible;
            }
        }

        private void Problem_OnClick(object sender, RoutedEventArgs e)
        {
            if (Problem.Visibility == Visibility.Visible)
            {
                Problem.Visibility = Visibility.Collapsed;
                CurrentProblemGrid.Visibility = Visibility.Visible;
            }
        }
      

        private void TasksListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!TasksListBox.Items.IsEmpty)
            {
                var c = TasksListBox.SelectedItem as TaskListItem;
                if (c != null) _viewModel.FillFieldsByClickedItemCmd.Execute(c.ThisTask);
            }
        }
    }
}
