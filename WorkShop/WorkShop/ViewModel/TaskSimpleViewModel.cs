using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WorkShop.UserControls;

namespace WorkShop.ViewModel
{
    public class TaskSimpleViewModel : ViewModelBase
    {
        private ObservableCollection<DataLayer.Employee> _employees;
        private ObservableCollection<String> _employeesString;
        private string _topic;
        private string _comment;
        private string _description;
        private DateTime _deadline;
        private string _selectedEmployee;
        public ObservableCollection<DataLayer.Employee> Employees
        {
            get { return _employees; }
            set { Set(ref _employees, value); }
        }
        public string SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { Set(ref _selectedEmployee, value); }
        }
        public ObservableCollection<String> EmployeesString
        {
            get { return _employeesString; }
            set { Set(ref _employeesString, value); }
        }
        public string Topic
        {
            get { return _topic; }
            set { Set(ref _topic, value); }
        }
        public string Comment
        {
            get { return _comment; }
            set { Set(ref _comment, value); }
        }
        public string Description
        {
            get { return _description; }
            set { Set(ref _description, value); }
        }
          public DateTime Deadline
        {
            get { return _deadline; }
            set { Set(ref _deadline, value); }
        }
        public ICommand LoadCmd { get; set; }
        public ICommand AddTaskCmd { get; set; }
        
        public TaskSimpleViewModel()
        {
            InitializeCommands();
        }
        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand<int>(Load);
            AddTaskCmd = new RelayCommand<int>(AddTask);
          
        }

        public void AddTask(int id)
        {
            if (SelectedEmployee != null && Description !=null && Deadline != null )
            {
                var empl = BizLayer.Query.EmployeesQuery.GetEmployees();
                foreach (var e in empl)
                {
                    if (e.username == SelectedEmployee)
                    {
                        BizLayer.Query.TaskQuery.AddTask(DateTime.Today, Deadline, Description, "", "open", id, e.employID);
                        break;
                    }
                }
               
            }
        }
        public void Load(int id)
        {
            var employees = new ObservableCollection<DataLayer.Employee>();
            var employeesstring = new ObservableCollection<string>();
            var empl = BizLayer.Query.EmployeesQuery.GetEmployees();
            foreach (var e in empl)
            {
                employees.Add(e);
                employeesstring.Add(e.username);
            }
            Employees = employees;
            EmployeesString = employeesstring;
            var problem = BizLayer.Query.ProblemQuery.GetProblem(id);
            Topic = problem.ToString();
            Deadline = DateTime.Today;

        }
    }
}
