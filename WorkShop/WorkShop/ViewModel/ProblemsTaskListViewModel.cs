using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WorkShop.UserControls;

namespace WorkShop.ViewModel
{
    public class ProblemsTaskListViewModel : ViewModelBase
    {
        TaskListItem _w0 = new TaskListItem("Topic 1", "Kowalski","16-06-2016", "testdescritpion", "done without problems");
        TaskListItem _w1 = new TaskListItem("Topicrve 1", "Kazmierczak","16-06-2016", "testdescritpion", "done without problems");
        TaskListItem _w2 = new TaskListItem("Topic sdas1", "Glac","16-06-2016", "testdescritpiontestdescritpiontestdescritpiontestdescritpiontestdescritpiontestdescritpiontestdescritpion", "done without problems");
        TaskListItem _w3 = new TaskListItem("Topic sad1", "Kowalski","16-6-2016", "testdescritpion", "done without problems");
        TaskListItem _w4 = new TaskListItem("Topic vdverver1", "Kowalski","14-06-2016", "testdescritpiontestdescritpiontestdescritpiontestdescritpion", "done without problems");




        public ObservableCollection<TaskListItem> TasksList
        {
            get { return _tasksList; }
            set { Set(ref _tasksList, value); }
        }

        private ObservableCollection<TaskListItem> _tasksList;
        public ICommand LoadCmd { get; set; }
        public ICommand ReloadCmd { get; set; }


        public ProblemsTaskListViewModel()
        {
            InitializeCommands();
        }
        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            ReloadCmd = new RelayCommand<int>(Reload);
        }
        public void Reload(int id)
        {
            ObservableCollection<TaskListItem> tasksList = new ObservableCollection<TaskListItem>();
            var tasks = BizLayer.Query.TaskQuery.GetTasks();
            var sortedTasks = new List<DataLayer.Task>();
            foreach(var task in tasks)
            {
                if (task.problemID == id) sortedTasks.Add(task);
            }
            if (sortedTasks.Any())
            {
                foreach (var task in sortedTasks)
                {
                    if (task.employID != null)
                    {
                        var empl = BizLayer.Query.EmployeesQuery.GetEmployee(task.employID.Value);
                        //empl wypluwa chyba prywatnie wszystko i nie mozna do niego wejsc
                        if (task.problemID != null && task.endDate.HasValue)
                            tasksList.Add(new TaskListItem(task.problemID.Value.ToString(), "Seba paczek",
                                task.endDate.Value.ToString(CultureInfo.CurrentCulture), task.taskDesc, task.resultDesc));
                    }
                }
                TasksList = tasksList;
            }
            else
            {
                ObservableCollection<TaskListItem> fakeTasks = new ObservableCollection<TaskListItem>();
                fakeTasks.Add(_w0);
                fakeTasks.Add(_w1);
                fakeTasks.Add(_w2);
                fakeTasks.Add(_w3);
                fakeTasks.Add(_w4);
                TasksList = tasksList;
            }
          
        }
        public void Load()
        {
          
            
            
            //Nie można wykonać operacji tworzenia, aktualizacji lub usuwania w odniesieniu do elementu 
            //„Table(Task)”, ponieważ nie ma ona klucza podstawowego
            //BizLayer.Query.TaskQuery.AddTask(DateTime.Today, DateTime.MaxValue, "jeden z taskow 23problemu numer 3","resultdescpire","open",3,1 );
            //BizLayer.Query.TaskQuery.AddTask(DateTime.Today, DateTime.MaxValue, "jeden z taskow 12problemu numer 3", "resultdescpire", "open", 3,1);
            //BizLayer.Query.TaskQuery.AddTask(DateTime.Today, DateTime.MaxValue, "jeden z taskow21212 problemu numer 2", "resultdescpire", "open", 2, 1);
            //BizLayer.Query.TaskQuery.AddTask(DateTime.Today, DateTime.MaxValue, "jeden z taskow 342342problemu numer 2", "resultdescpire", "open", 2, 1);
        }
    }
}
