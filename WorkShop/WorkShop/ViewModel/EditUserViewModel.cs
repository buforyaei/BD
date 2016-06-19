using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using WorkShop.UserControls;

namespace WorkShop.ViewModel
{
    public class EditUserViewModel : ViewModelBase
    {
        //UserListItem _w0 = new UserListItem("Kowalski Jan", "Manager", 1515);
        //UserListItem _w1 = new UserListItem("Test", "Employy", 6515);
        //UserListItem _w2 = new UserListItem("Katarzyna Bąk", "Manager", 1815);
        //UserListItem _w3 = new UserListItem("Każmierczak Mateusz", "Employy", 1715);
        //UserListItem _w4 = new UserListItem("Ban Ki Mun", "Employy", 1555);


        private ObservableCollection<UserListItem> _workerListItems;
        public ObservableCollection<UserListItem> WorkerListItems
        {
            get { return _workerListItems; }
            set { Set(ref _workerListItems, value); }
        }

       
        public ICommand LoadCmd { get; set; }
        public ICommand NameFilterCmd { get; set; }
        public ICommand IdFilterCmd { get; set; }
        public ICommand RoleFilterCmd { get; set; }
        
        
        
        public EditUserViewModel()
        {
            InitializeCommands();
        }
        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            NameFilterCmd = new RelayCommand(NameFilter);
            IdFilterCmd = new RelayCommand(IdFilter);
            RoleFilterCmd = new RelayCommand(RoleFilter);
        }
        private void RoleFilter()
        {

            if (WorkerListItems.Any())
            {
                ObservableCollection<UserListItem> workerListItems = WorkerListItems;
                var list = workerListItems.ToArray();
                for (int i = 0;i<list.Length;i++)
                {
                    if (list[i].Role.Content.ToString() == "Manager")
                    {
                        UserListItem item = list[i];
                        for (int j = i; j > 0; j--)
                            list[j] = workerListItems[j - 1];
                        list[0] = item;
                    }
                }
                WorkerListItems = new ObservableCollection<UserListItem>(); 
                foreach (UserListItem t in list)
                    WorkerListItems.Add(t);
            }
            
        }
        private void IdFilter()
        {
            var list = WorkerListItems.ToArray();
           

            int temp = 0;

            for (int write = 0; write < list.Length; write++)
            {
                for (int sort = 0; sort < list.Length - 1; sort++)
                {
                    if (Int32.Parse(list[sort].Id.Content.ToString()) > Int32.Parse(list[sort + 1].Id.Content.ToString()))
                    {
                        temp = Int32.Parse(list[sort + 1].Id.Content.ToString());
                        list[sort + 1].Id.Content = list[sort].Id.Content;
                        list[sort].Id.Content = temp.ToString();
                    }
                }
            }
            WorkerListItems = new ObservableCollection<UserListItem>();
            foreach (UserListItem t in list)
                WorkerListItems.Add(t);

        }
        private void NameFilter()
        {

            var list = WorkerListItems.ToList().OrderBy(x => x.Name.Content.ToString()).ToList();
            WorkerListItems = new ObservableCollection<UserListItem>();
            foreach (UserListItem t in list)
                WorkerListItems.Add(t);
        }
        private void Load()
        {
            ObservableCollection<UserListItem> workerListItems = new ObservableCollection<UserListItem>();
            var employees = BizLayer.Query.EmployeesQuery.GetEmployees();
            var persons = BizLayer.Query.PersonQuery.GetPersons();
            foreach (var employee in employees)
            {
                if(employee.Person!=null)
                workerListItems.Add(new UserListItem(employee.Person.name,employee.Person.phone.ToString(),
                    employee.Person.address,employee.role,employee.employID));
            }
            WorkerListItems = workerListItems;
            //workerListItems.Add(_w0);
            //workerListItems.Add(_w1);
            //workerListItems.Add(_w2);
            //workerListItems.Add(_w3);
            //workerListItems.Add(_w4);
            //WorkerListItems = workerListItems;
           // BizLayer.Query.EmployeesQuery.AddEmployee("sebix", "test", "Employy");
            
            var b = BizLayer.Query.ProblemQuery.GetProblems();
            var c = BizLayer.Query.ProblemQuery.GetProblem(3);

        }
    }
}
