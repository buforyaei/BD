using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WorkShop.Models;
using BizLayer.Query;

namespace WorkShop.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoadCmd { get; set; }
       // public ICommand LoginCmd { get; set; }

        public LoginViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
           // LoginCmd = new RelayCommand(Login); 
        }

        public bool Login()
        {
            foreach (DataLayer.Employee e in  EmployeesQuery.GetEmployees().ToArray())
            {
                if (e.username == StaticPagesUi.User.Name && e.password == StaticPagesUi.User.Password)
                {
                    if(e.role.Contains("mployy"))  StaticPagesUi.User.Role = Role.Employy;
                    else if (e.role.Contains("anager")) StaticPagesUi.User.Role = Role.Manager;
                    else if (e.role.Contains("dmin") ) StaticPagesUi.User.Role = Role.Admin;
                    return true;
                }    
            }
            return false;
        }
        private  void Load()
        {
            
        }
    }
}