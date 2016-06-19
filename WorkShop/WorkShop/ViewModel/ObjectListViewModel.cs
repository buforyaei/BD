using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WorkShop.Models;
using WorkShop.UserControls;

namespace WorkShop.ViewModel
{
    public class ObjectListViewModel :ViewModelBase
    {
          public ICommand LoadCmd { get; set; }
          public ICommand AddObjectCmd { get; set; }
          public ICommand ClientChangedCmd { get; set; }
        private ObservableCollection<ObjectItem> _objects;
        public ObservableCollection<ObjectItem> Objects
        {
            get { return _objects; }
            set { Set(ref _objects, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private string _model;
        public string Model
        {
            get { return _model; }
            set { Set(ref _model, value); }
        }
        private string _clientNameString;
        public string ClientNameString
        {
            get { return _clientNameString; }
            set { Set(ref _clientNameString, value); }
        }
        private string _objId;
        public string ObjId
        {
            get { return _objId; }
            set { Set(ref _objId, value); }
        }

        private DataLayer.Client _selectedClient;
        private ObservableCollection<DataLayer.Client> _clients;
        public ObservableCollection<DataLayer.Client> Clients
        {
            get { return _clients; }
            set { Set(ref _clients, value); }
        }
        public DataLayer.Client SelectedClient
        {
            get { return _selectedClient; }
            set { Set(ref _selectedClient, value); }
        }
        public ObjectListViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            AddObjectCmd = new RelayCommand(AddObject); 
            ClientChangedCmd = new RelayCommand(ClientChanged);
        }

        private void AddObject()
        {
            if (Name != "" && Model != "" && Name != null && Model != null)
            {
              //dodawac objektu sie nie da
                //BizLayer.ObjectQuery.AddObject();
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
            Model = "";
        }

        private void ClientChanged()
        {
            ClientNameString = SelectedClient.Person.name + " "+SelectedClient.Person.surname;
        }
        private  void Load()
        {
            //comboBox Loading
            var clientsAsList = BizLayer.Query.ClientQuery.GetClients().ToList();
            var clientsAsObservable = new ObservableCollection<DataLayer.Client>();
            foreach (var item in clientsAsList)
                clientsAsObservable.Add(item);
            Clients = clientsAsObservable;
            SelectedClient = Clients.FirstOrDefault();
            if (SelectedClient != null) ClientNameString = SelectedClient.Person.name;
            //objects loading
            ObservableCollection<ObjectItem> objects = new ObservableCollection<ObjectItem>();
            var objectsBizLayer = BizLayer.ObjectQuery.GetObjects();
            var problems = BizLayer.Query.ProblemQuery.GetProblems();
            
            foreach (var o in objectsBizLayer)
            {
                var problemList = new List<DataLayer.Problem>();
                foreach (var p in problems)
                {
                    if(p.objectID == o.objectID) problemList.Add(p);
                }
                
                objects.Add(new ObjectItem(o, o.Client, problemList));
            }
            Objects = objects;
        }
    }
}
