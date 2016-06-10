using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace WorkShop.ViewModel
{
    public class AddUserViewModel : ViewModelBase
    {
        public ICommand LoadCmd { get; set; }
        public ICommand AddUserCmd { get; set; }

        public AddUserViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            AddUserCmd = new RelayCommand(AddUser); 
        }

        private void AddUser()
        {
           
        }
        private  void Load()
        {
            
        }
    }
}
