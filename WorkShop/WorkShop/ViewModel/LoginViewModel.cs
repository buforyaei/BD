using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace WorkShop.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoadCmd { get; set; }
        public ICommand LoginCmd { get; set; }

        public LoginViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            LoginCmd = new RelayCommand(Login); 
        }

        private  void Login()
        {
           
        }
        private  void Load()
        {
            
        }
    }
}