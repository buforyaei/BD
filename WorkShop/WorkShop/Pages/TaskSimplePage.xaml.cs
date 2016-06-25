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
    /// Interaction logic for TaskSimplePage.xaml
    /// </summary>
    public partial class TaskSimplePage : Page
    {
        private TaskSimpleViewModel _viewModel = new TaskSimpleViewModel();
        public int Id
        {
            get;
            set;
        }
        public TaskSimplePage()
        {
            InitializeComponent();
            DataContext = _viewModel;
            //_viewModel.Load();
        }
        public TaskSimplePage(int id)
        {
            InitializeComponent();
            DataContext = _viewModel;
            Id = id;
            _viewModel.Load(Id);
        }
       

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddTaskCmd.Execute(Id);
        }
    }
}
