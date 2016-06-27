using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DataLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WorkShop.UserControls;
using Task = DataLayer.Task;

namespace WorkShop.ViewModel
{
    public class ProblemsTaskListViewModel : ViewModelBase
    {
        public ICommand LoadCmd { get; set; }
        public ICommand RefreshCmd { get; set; }
        public ICommand ClearFieldsCmd { get; set; }
        public ICommand AddTaskCmd { get; set; }
        public ICommand FillFieldsByClickedItemCmd { get; set; }

        private DateTime _beginDate;
        private DateTime _endDate;
        private ObservableCollection<Employee> _employees;
        private Employee _selectedEmployee;
        private string _taskId;
        private string _description;
        private string _resultDescription;
        private ProblemListItem _currentProblem;
        private ObservableCollection<ProblemListItem> _currentProblemAsList;
        private ObservableCollection<TaskListItem> _tasksList;

        public DateTime BeginDate
        {
            get { return _beginDate; }
            set { Set(ref _beginDate, value); }
        }
        public DateTime EndDate
        {
            get { return _endDate; }
            set { Set(ref _endDate, value); }
        }
        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set { Set(ref _employees, value); }
        }

        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { Set(ref _selectedEmployee, value); }
        }
        public string TaskId
        {
            get { return _taskId; }
            set { Set(ref _taskId, value); }
        }
        public string Description
        {
            get { return _description; }
            set { Set(ref _description, value); }
        }
        public string ResultDescription
        {
            get { return _resultDescription; }
            set { Set(ref _resultDescription, value); }
        }
        public ObservableCollection<ProblemListItem> CurrentProblemAsList
        {
            get { return _currentProblemAsList; }
            set { Set(ref _currentProblemAsList, value); }
        }
        public ProblemListItem CurrentProblem
        {
            get { return _currentProblem; }
            set { Set(ref _currentProblem, value); }
        }
        public ObservableCollection<TaskListItem> TasksList
        {
            get { return _tasksList; }
            set { Set(ref _tasksList, value); }
        }
        
        public ProblemsTaskListViewModel()
        {
            InitializeCommands();
        }
        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            RefreshCmd = new RelayCommand(Refresh);
            ClearFieldsCmd = new RelayCommand(ClearFields);
            AddTaskCmd = new RelayCommand(AddTask);
            FillFieldsByClickedItemCmd = new RelayCommand<DataLayer.Task>(FillFieldsByClickedItem);
        }
        private void FillFieldsByClickedItem(Task task)
        {
            Description = task.taskDesc;
            TaskId = task.taskID.ToString();
            ResultDescription = task.resultDesc;
            BeginDate = task.beginDate.Value;
            EndDate = task.endDate.Value;
            try
            {
                if (Employees.Any())
                    SelectedEmployee = task.Employee;
            }
            catch
            {
                //ignored :)
            }
            
        }
        private void AddTask()
        {
            if (!String.IsNullOrEmpty(Description) && SelectedEmployee != null)
            {
                if (string.IsNullOrEmpty(TaskId) && StaticPagesUi.User.IsManaager())
                {
                    BizLayer.Query.TaskQuery.AddTask(BeginDate, EndDate, Description, ResultDescription,
                     "removethisprop", CurrentProblem.Problem.problemID, SelectedEmployee.employID);
                    MessageBox.Show("Operation successfull", "OK",
                        MessageBoxButton.OK);
                    ClearFields();
                    Load();
                }
                 
                else
                {
                    try
                    {
                        BizLayer.Query.TaskQuery.UpdateTask(Int32.Parse(TaskId), BeginDate, EndDate, Description,
                            ResultDescription, "removethisproperty", CurrentProblem.Problem.problemID,
                            SelectedEmployee.employID);
                        MessageBox.Show("Operation successfull", "OK",
                             MessageBoxButton.OK);
                        ClearFields();
                        Load();
                    }
                    catch
                    {
                        MessageBox.Show("Operation failed", "Ops!",
                   MessageBoxButton.OK);
                        Load();
                    }
                }
              
            }
            else
            {
                MessageBox.Show("Operation failed", "Ops!",
                  MessageBoxButton.OK);
                Load();
            }
        }
        private void ClearFields()
        {
            Description = String.Empty;
            TaskId = String.Empty;
            ResultDescription = String.Empty;
            BeginDate = DateTime.Today;
            EndDate = DateTime.MaxValue;
            try
            {
                if (Employees.Any())
                    SelectedEmployee = Employees.FirstOrDefault();
            }
            catch
            {
                
            }
            
        }
        private void Refresh()
        {
            Load();
        }
        private void Load()
        {
            //Combobox Employees fill
            var empolyees = BizLayer.Query.EmployeesQuery.GetEmployees();
            var empolyeesObservable = new ObservableCollection<Employee>();
            foreach (var e in empolyees)
            {
                if (e.role.Contains("mplo"))
                empolyeesObservable.Add(e);
            }
            if (empolyeesObservable.Any())
            {
                Employees = empolyeesObservable;
                SelectedEmployee = Employees.FirstOrDefault();
            }
            //CurrentProblem inject
            var currentProblemAsList = new ObservableCollection<ProblemListItem>();
            currentProblemAsList.Add(CurrentProblem);
            CurrentProblemAsList = currentProblemAsList;
            //TasksList Load
            var tasks = BizLayer.Query.TaskQuery.GetTasks();
            var tasksListForCurrentProblem = new ObservableCollection<TaskListItem>();
            foreach (var t in tasks)
            {
                if(t.problemID.HasValue)
                    if (t.problemID.Value == CurrentProblem.Problem.problemID)
                    {
                       tasksListForCurrentProblem.Add(new TaskListItem(t));
                    }
            }
            if (tasksListForCurrentProblem.Any())
            {
                TasksList = tasksListForCurrentProblem;
            }
            ClearFields();
        }
    }
}
