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
    public partial class RegisterProblemPage : Page
    {
        private RegisterProblemViewModel _viewModel = new RegisterProblemViewModel();
        public RegisterProblemPage()
        {
            InitializeComponent();
            DataContext = _viewModel;
            _viewModel.LoadCmd.Execute(null);
        }
        public RegisterProblemPage(ProblemListItem problemItem)
        {
            InitializeComponent();
            DataContext = _viewModel;
            _viewModel.LoadCmd.Execute(null);
            Name.Text = problemItem.ClientName.Content.ToString().Substring(13);
            Phone.Text = problemItem.Phone.Content.ToString().Substring(7);
            Address.Text = problemItem.Address.Substring(9);
            Description.Text = problemItem.Description.Content.ToString().Substring(12);
            ResultDesc.Text = problemItem.ResultDescription.Content.ToString().Substring(7);
            VehicleName.Text = problemItem.Object.Content.ToString().Substring(8);
            Object.Text = problemItem.Object.Content.ToString().Substring(8);
            Id.Text = problemItem.Id.Content.ToString().Substring(4);



        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.MenuManagerPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.ProblemsPage);
        }
    }
}
