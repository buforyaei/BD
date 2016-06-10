using System.Windows;
using System.Windows.Controls;
using WorkShop.ViewModel;

namespace WorkShop.Pages
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuEmployyPage : Page
    {
        public MenuEmployyPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewModelLocator.Cleanup();
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.MyTasksPage);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.ProblemsPage);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(StaticPagesUi.SearchPage);
        }
    }
}
