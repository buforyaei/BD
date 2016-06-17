using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WorkShop.Models;

namespace WorkShop.ViewModel
{
    public class AddUserViewModel : ViewModelBase
    {
        public ICommand LoadCmd { get; set; }
        public ICommand AddUserCmd { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { Set(ref _address, value); }
        }
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { Set(ref _phone, value); }
        }

        public bool IsEmployeeChecked
        {
            get { return _isEmployeeChecked; }
            set { Set(ref _isEmployeeChecked, value); }
        }
        private bool _isEmployeeChecked;

        private string _password;
        public string Password
        {
            get { return _password; }
            set { Set(ref _password, value); }
        }
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
            if (Name != "" && Password != "" && Name != null && Password != null)
            {
                //zabezpieczyc ze np spacje i literki nie moga byc w numerze telfonu
                BizLayer.Query.PersonQuery.AddPerson(Name,Name,Address,Int32.Parse(Phone));
                var persons = BizLayer.Query.PersonQuery.GetPersons().ToArray();
                if (IsEmployeeChecked)
                        BizLayer.Query.EmployeesQuery.AddEmployee(Name, Password, Role.Employy.ToString(),persons.Last().personID);
                else 
                        BizLayer.Query.EmployeesQuery.AddEmployee(Name, Password, Role.Manager.ToString(), persons.Last().personID);
                MessageBox.Show("User was successfully added to system", "OK",
                     MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Some unnullable fields where left emppty.", "Ops!",
                    MessageBoxButton.OK);
            }
            var users = BizLayer.Query.EmployeesQuery.GetEmployees();
            Name = "";
            Password = "";
            Address = "";
            Phone = "";
        }
        private  void Load()
        {
            

        }
    }
}
