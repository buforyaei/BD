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

        private string _login;
        public string Login
        {
            get { return _login; }
            set { Set(ref _login, value); }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }
        private DataLayer.Employee _employee;
        public DataLayer.Employee Employee
        {
            get { return _employee; }
            set { Set(ref _employee, value); }
        }
        private string _city;
        public string City
        {
            get { return _city; }
            set { Set(ref _city, value); }
        }
        private string _street;
        public string Street
        {
            get { return _street; }
            set { Set(ref _street, value); }
        }
        private string _houseNumber;
        public string HouseNumber
        {
            get { return _houseNumber; }
            set { Set(ref _houseNumber, value); }
        }
        
        private string _userId;
        public string UserId
        {
            get { return _userId; }
            set { Set(ref _userId, value); }
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

        public bool IsManagerChecked
        {
            get { return _isManagerChecked; }
            set { Set(ref _isManagerChecked, value); }
        }
        private bool _isManagerChecked;

        public bool IsAdminChecked
        {
            get { return _isAdminChecked; }
            set { Set(ref _isAdminChecked, value); }
        }
        private bool _isAdminChecked;

        public bool WasSuccesfull
        {
            get { return _wasSuccesfull; }
            set { Set(ref _wasSuccesfull, value); }
        }
        private bool _wasSuccesfull;

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

        public void FillFieldsWithUser()
        {
            Name = Employee.Person.name;
            Login = Employee.username;
            UserId = Employee.employID.ToString();
            Password = String.Empty;
            Phone = Employee.Person.phone;
            if (Employee.role.Contains("anager"))
            {
                IsManagerChecked = true;
                IsEmployeeChecked = false;
                IsAdminChecked = false; 
            }
            else if (Employee.role.Contains("dmin"))
            {
                IsAdminChecked = true; 
                IsEmployeeChecked = false;
                IsManagerChecked = true;
            }
            else
            {
                IsEmployeeChecked = true;
                IsManagerChecked = false;
                IsAdminChecked = false; 
            }
            City = Employee.Person.city;
            Street = Employee.Person.street;
            HouseNumber = Employee.Person.housenumber;
        }
        private void AddUser()
        {
            if (!string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Phone) && !string.IsNullOrEmpty(City) &&
                !string.IsNullOrEmpty(Street) && !string.IsNullOrEmpty(HouseNumber))
            {
                if (UserId == String.Empty)
                {
                    BizLayer.Query.PersonQuery.AddPerson(Name, City, Street, HouseNumber, Phone);
                    var persons = BizLayer.Query.PersonQuery.GetPersons().ToList();
                    var personId = persons[persons.Count - 1].personID;
                        
                        if (IsEmployeeChecked)
                        {
                            BizLayer.Query.EmployeesQuery.AddEmployee(Login, Password.GetHashCode().ToString(),
                                Role.Employy.ToString(), personId);

                        }
                        else if (IsManagerChecked)
                        {
                            BizLayer.Query.EmployeesQuery.AddEmployee(Login, Password.GetHashCode().ToString(),
                                Role.Manager.ToString(), personId);

                        }
                        else
                        {
                            BizLayer.Query.EmployeesQuery.AddEmployee(Login, Password.GetHashCode().ToString(),
                               Role.Admin.ToString(), personId);
                        }
                    
                    MessageBox.Show("Operation successfull", "OK",
                        MessageBoxButton.OK);
                    WasSuccesfull = true;
                    ClearFields();
                }
                else
                {
                    BizLayer.Query.PersonQuery.UpdatePerson(Employee.personID.Value, Name, City, Street, HouseNumber, Phone);
                    if (IsEmployeeChecked)
                    {
                        if(Password==string.Empty)
                        BizLayer.Query.EmployeesQuery.UpdateEmployee(Int32.Parse(UserId), Login, Employee.password,
                            Role.Employy.ToString(), Employee.personID.Value);
                        else
                            BizLayer.Query.EmployeesQuery.UpdateEmployee(Int32.Parse(UserId), Login, Password.GetHashCode().ToString(),
                          Role.Employy.ToString(), Employee.personID.Value);
                    }
                    else if (IsManagerChecked)
                    {
                        if (Password == string.Empty)
                            BizLayer.Query.EmployeesQuery.UpdateEmployee(Int32.Parse(UserId), Login, Employee.password,
                                Role.Manager.ToString(), Employee.personID.Value);
                        else
                            BizLayer.Query.EmployeesQuery.UpdateEmployee(Int32.Parse(UserId), Login,
                                Password.GetHashCode().ToString(),
                                Role.Employy.ToString(), Employee.personID.Value);

                    }
                    else
                    {
                        if (Password == string.Empty)
                            BizLayer.Query.EmployeesQuery.UpdateEmployee(Int32.Parse(UserId), Login, Employee.password,
                                Role.Admin.ToString(), Employee.personID.Value);
                        else
                            BizLayer.Query.EmployeesQuery.UpdateEmployee(Int32.Parse(UserId), Login,
                                Password.GetHashCode().ToString(),
                                Role.Admin.ToString(), Employee.personID.Value); 
                    }
                    MessageBox.Show("Operation successfull", "OK",
                        MessageBoxButton.OK);
                    WasSuccesfull = true;
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Some unnullable fields where left emppty.", "Ops!",
                    MessageBoxButton.OK);
            }


        }

        private void ClearFields()
        {
            Name = String.Empty;
            Login = String.Empty;
            Password = String.Empty;
            City = String.Empty;
            HouseNumber = String.Empty;
            Street = String.Empty;
            Phone = String.Empty;
            UserId = String.Empty;
        }
        private  void Load()
        {
            ClearFields();
            IsEmployeeChecked = true;

        }
    }
}
