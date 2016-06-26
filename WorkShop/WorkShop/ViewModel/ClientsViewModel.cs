using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BizLayer.Query;
using DataLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WorkShop.UserControls;

namespace WorkShop.ViewModel
{
    public class ClientsViewModel :ViewModelBase
    {
          public ICommand LoadCmd { get; set; }
          public ICommand AddClientCmd { get; set; }
          public ICommand ClearFieldsCmd { get; set; }
          public ICommand RefreshCmd { get; set; }
          public ICommand ClientsObjectsLoadCmd { get; set; }
          public ICommand FilterByNameCmd { get; set; }
        private ObservableCollection<ClientListItem> _clients;
        private ObservableCollection<ObjectItem> _clientObjects;
        public ObservableCollection<ObjectItem> ClientObjects
        {
            get { return _clientObjects; }
            set { Set(ref _clientObjects, value); }
        }
        public ObservableCollection<ClientListItem> Clients
        {
            get { return _clients; }
            set { Set(ref _clients, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }
        private string _filterString;
        public string FilterString
        {
            get { return _filterString; }
            set { Set(ref _filterString, value); }
        }
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { Set(ref _phone, value); }
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
        private string _clientId;
        public string ClientId
        {
            get { return _clientId; }
            set { Set(ref _clientId, value); }
        }
        public ClientsViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            RefreshCmd = new RelayCommand(Refresh);
            AddClientCmd = new RelayCommand(AddClient);
            ClearFieldsCmd = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(ClearFields);
            ClientsObjectsLoadCmd = new RelayCommand<int>(ClientsObjectsLoad);
            FilterByNameCmd = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(FilterByName);
        }

        private void FilterByName()
        {
            if (string.IsNullOrEmpty(FilterString))
                Load();
            else
            {
                ObservableCollection<ClientListItem> clients = new ObservableCollection<ClientListItem>();
                var clientsFromDb = ClientQuery.GetClients().ToList();
                foreach (var c in clientsFromDb)
                {
                    if(c.Person.name.Contains(FilterString))
                    clients.Add(new ClientListItem(c));
                }
                Clients = null;
                Clients = clients;
            }
        }
        private void ClientsObjectsLoad(int clientId)
        {
            ClientObjects = null;
            var objects = BizLayer.Query.ObjectQuery.GetObjects();
            var clientObjects = new ObservableCollection<ObjectItem>();
            foreach (var o in objects)
            {
                if (o.clientID == clientId)
                {
                    var problems = BizLayer.Query.ProblemQuery.GetProblems();
                    var objProblems = new List<Problem>();
                    foreach (var p in problems)
                    {
                        if(p.objectID == o.objectID)
                            objProblems.Add(p);
                    }
                        clientObjects.Add(new ObjectItem(o, o.Client, objProblems.ToList()));                 
                }
            }
            if (clientObjects.Any())
            {
                ClientObjects = clientObjects;
            }
        }
        private void AddClient()
        {
            if (!string.IsNullOrEmpty(ClientId))
            {
                try
                { 
                    
                    var client = BizLayer.Query.ClientQuery.GetClient(Int32.Parse(ClientId)).ToArray();
                    BizLayer.Query.PersonQuery.UpdatePerson(client[0].Person.personID, Name, City, Street, HouseNumber, Phone);
                    MessageBox.Show("User was successfully updated", "OK",
                       MessageBoxButton.OK);
                    Load();
                    ClearFields();
                }
                catch
                {
                
                }
            }
            else if (!string.IsNullOrEmpty(Phone) && !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(Street) && !string.IsNullOrEmpty(HouseNumber))
            {
                try
                {
                    BizLayer.Query.PersonQuery.AddPerson(Name, City, Street, HouseNumber, Phone);

                    var persons = BizLayer.Query.PersonQuery.GetPersons().ToArray();
                    var thisPerson = persons[persons.Length-1];
                    if (thisPerson != null) BizLayer.Query.ClientQuery.AddClient(thisPerson.personID);
                    MessageBox.Show("User was successfully added", "OK",
                        MessageBoxButton.OK);
                    Load();
                   ClearFields();
                }
                catch
                {
                    
                }
            }
            else
            {
                MessageBox.Show("Some unnullable fields where left emppty.", "Ops!",
                    MessageBoxButton.OK);
            }
            
        }

        private void Refresh()
        {
            Load();
        }
      
        private  void Load()
        {
            //comboBox Loading
            //var clientsAsList = BizLayer.Query.ClientQuery.GetClients().ToList();
            //var clientsAsObservable = new ObservableCollection<DataLayer.Client>();
            //foreach (var item in clientsAsList)
            //    clientsAsObservable.Add(item);
            //Clients = clientsAsObservable;
            //SelectedClient = Clients.FirstOrDefault();
            //if (SelectedClient != null) ClientNameString = SelectedClient.Person.name;
            //Clients loading

            ObservableCollection<ClientListItem> clients = new ObservableCollection<ClientListItem>();
            var clientsFromDb = ClientQuery.GetClients().ToList();
            foreach (var c in clientsFromDb)
            {
                clients.Add(new ClientListItem(c));
            }
            Clients = clients;
        }
        public void FillFieldsByClickedItem(DataLayer.Client o)
        {
            Name = o.Person.name;
            Phone = o.Person.phone.ToString();
            Street = o.Person.street;
            City = o.Person.city;
            HouseNumber = o.Person.housenumber;
            ClientId = o.clientID.ToString();


        }
        public void ClearFields()
        {
            Name = String.Empty;
            Phone = String.Empty;
            Street = String.Empty;
            City = String.Empty;
            HouseNumber = String.Empty;
            ClientId = String.Empty;


        }
    }
}
