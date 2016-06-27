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
using BizLayer.Query;
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
          public ICommand RefreshCmd { get; set; }
          public ICommand FillFieldsByClickedItemCmd { get; set; }
          public ICommand ClearFieldsCmd { get; set; }
          public ICommand FilterByNameCmd { get; set; }

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

        private ObjectItem _selctedObject;

        public ObjectItem SelectedObject
        {
            get { return _selctedObject; }
            set { Set(ref _selctedObject, value); }
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
        private string _filterString;
        public string FilterString
        {
            get { return _filterString; }
            set { Set(ref _filterString, value); }
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
            ClientChangedCmd = new RelayCommand<DataLayer.Client>(ClientChanged);
            RefreshCmd = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(Refresh);
            FillFieldsByClickedItemCmd = new RelayCommand<DataLayer.Object>(FillFieldsByClickedItem);
            ClearFieldsCmd = new RelayCommand(ClearFields);
            FilterByNameCmd = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(FilterByName);
        }

        private void FillFieldsByClickedItem(DataLayer.Object obj)
        {
            Name = obj.name;
            Model = obj.model;
            ObjId = obj.objectID.ToString();
            try
            {
                SelectedClient = obj.Client;
            }catch
            {
                //ingored
            }
            
        }
        private void Refresh()
        {
            Load();
        }
        private void FilterByName()
        {
            if (string.IsNullOrEmpty(FilterString))
                Load();
            else
            {
                Load();
                ObservableCollection<ObjectItem> objects = new ObservableCollection<ObjectItem>();
                var objsDb = ObjectQuery.GetObjects().ToArray();
                var objectsArray = Objects.ToArray();
                for(int i = 0; i<Objects.Count ;i++)
                {
                    if (objsDb[i].name.Contains(FilterString) || objsDb[i].model.Contains(FilterString))
                        
                        objects.Add(objectsArray[i]);
                }
                Objects = null;
                Objects = objects;
            }
        }
        private void ClearFields()
        {
            Name = "";
            Model = "";
            ObjId = "";
        }
        private void AddObject()
        {
            try
            {
                if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Model) && SelectedClient != null)
                {
                    if (string.IsNullOrEmpty(ObjId)) ObjectQuery.AddObject(SelectedClient.clientID, Name, Model);
                    else ObjectQuery.UpdateObject(Int32.Parse(ObjId), SelectedClient.clientID, Name, Model);

                    MessageBox.Show("Operation successfull", "OK",
                        MessageBoxButton.OK);
                    Load();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Some unnullable fields where left emppty.", "Ops!",
                        MessageBoxButton.OK);
                }
            }
            catch
            {
                MessageBox.Show("Operation failed", "Ops!", MessageBoxButton.OK);
            }
        }

        private void ClientChanged(DataLayer.Client selectedClient)
        {
            foreach (var client in Clients)
            {
                if (client.Person.name == selectedClient.Person.name)
                {
                    SelectedClient = client;
                }
            }
           
            ClientNameString = SelectedClient.Person.name;
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
            var objectsBizLayer = ObjectQuery.GetObjects();
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
            if (objects.Count > 0)
            {
                Objects = objects;
                SelectedObject = Objects.FirstOrDefault();
            }
            
        }
    }
}
