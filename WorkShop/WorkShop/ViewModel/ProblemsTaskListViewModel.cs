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



        public ProblemsTaskListViewModel()
        {
            InitializeCommands();
        }
        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
          
        }
        public void Load()
        {
            ObservableCollection<TaskListItem> tasksList = new ObservableCollection<TaskListItem>();
            tasksList.Add(_w0);
            tasksList.Add(_w1);
            tasksList.Add(_w2);
            tasksList.Add(_w3);
            tasksList.Add(_w4);
            TasksList = tasksList;
        }
    }
}
