using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BizLayer.Query;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WorkShop.Models;

namespace WorkShop.ViewModel
{
    public class RegisterProblemViewModel : ViewModelBase
    {
        
        public ICommand LoadCmd { get; set; }
        public ICommand RegisterProblemCmd { get; set; }
        private bool _isEmployeeChecked;
        private string _name;
        private string _phoneNumber;
        private string _address;
        private string _descritpion;
        private string _vehicleName;
        private string _resultDescritpion;
        private string _object;

        public string Object
        {
            get { return _object; }
            set { Set(ref _object, value); }
        }
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }
        public string ResultDescritpion
        {
            get { return _resultDescritpion; }
            set { Set(ref _resultDescritpion, value); }
        }
        public string VehicleName
        {
            get { return _vehicleName; }
            set { Set(ref _vehicleName, value); }
        }
        public string Address
        {
            get { return _address; }
            set { Set(ref _address, value); }
        }
        public bool IsEmployeeChecked
        {
            get { return _isEmployeeChecked; }
            set { Set(ref _isEmployeeChecked, value); }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { Set(ref _phoneNumber, value); }
        }
        public string Descritpion
        {
            get { return _descritpion; }
            set { Set(ref _descritpion, value); }
        }
        public RegisterProblemViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            RegisterProblemCmd = new RelayCommand(RegisterProblem); 
        }

        private void RegisterProblem()
        {
            if (Name != null && PhoneNumber != null && Descritpion != null && Address != null && Name != null && PhoneNumber != "" && Descritpion != "" && Address != "")
            {
                PersonQuery.AddPerson(Name,Name,Address,Int32.Parse(PhoneNumber));
                var persons = PersonQuery.GetPersons().ToArray();
                ClientQuery.AddClient(persons.Last().personID);
                var clientss = ClientQuery.GetClients().ToArray();

                //ObjectTypeQuery.AddObjectType(1, VehicleName);
                BizLayer.ObjectQuery.AddObject(clientss.Last().clientID);
                    
                ProblemQuery.AddProblem(DateTime.Today, DateTime.MaxValue, Descritpion,"");
               
                MessageBox.Show("User was successfully added to system", "OK",
                     MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Some unnullable fields where left emppty.", "Ops!",
                    MessageBoxButton.OK);
            }
            var users = PersonQuery.GetPersons();
         //   var clients = ClientQuery.GetClients();
            Name = "";
            Descritpion = "";
        }
        private  void Load()
        {
            var users = ProblemQuery.GetProblems();

        }
    }

     
 }

