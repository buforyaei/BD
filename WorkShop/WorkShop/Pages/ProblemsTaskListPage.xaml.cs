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
    /// Interaction logic for ProblemsTaskList.xaml
    /// </summary>
    public partial class ProblemsTaskListPage : Page
    {
        private ProblemsTaskListViewModel _viewModel = new ProblemsTaskListViewModel();
          public int Id { get; set; }
        public ProblemsTaskListPage()
        {
            InitializeComponent();
            DataContext = _viewModel;
            _viewModel.LoadCmd.Execute(null);
        }

        public ProblemsTaskListPage(string id)
        {
            InitializeComponent();
            try
            {
                Id = Int32.Parse(id.Substring(4));
                _viewModel.ReloadCmd.Execute(Id);
            }
            catch (Exception e)
            {
                // ignored
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.ProblemsPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //konstruktor musi przekaza prametry tasku
            if (NavigationService != null) NavigationService.Navigate(new TaskSimplePage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(new TaskSimplePage(Id));
        }
    }
}
