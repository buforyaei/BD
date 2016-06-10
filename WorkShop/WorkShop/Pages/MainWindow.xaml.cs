using System.Windows;
using System.Windows.Navigation;

namespace WorkShop.Pages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            Main.Content = new LoginPage();
        }
    }
}
