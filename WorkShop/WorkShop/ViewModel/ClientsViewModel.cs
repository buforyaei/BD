using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BizLayer.Query;
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

        private ObservableCollection<ClientListItem> _clients;
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
            AddClientCmd = new RelayCommand(AddClient);
            ClearFieldsCmd = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(ClearFields);
        }

        private void AddClient()
        {
            if (!string.IsNullOrEmpty(ClientId))
            {
                try
                { 
                    
                    var client = BizLayer.Query.ClientQuery.GetClient(Int32.Parse(ClientId)).ToArray();
                   //tochyba jest glupie bosie podmienia person BizLayer.Query.ClientQuery.UpdateClient(Int32.Parse(ClientId), client[0].Person.personID);
                    BizLayer.Query.PersonQuery.UpdatePerson(client[0].Person.personID,Name,Name,Street,Int32.Parse(Phone));
                    Load();
                    Name = String.Empty;
                    Phone = String.Empty;
                    Street = String.Empty;
                    City = String.Empty;
                    HouseNumber = String.Empty;
                    ClientId = String.Empty;
                }
                catch
                {
                
                }
            }
            else if (!string.IsNullOrEmpty(Phone) && !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(Street) && !string.IsNullOrEmpty(HouseNumber))
            {
                try
                {
                    BizLayer.Query.PersonQuery.AddPerson(Name, Name, City, Int32.Parse(Phone));

                    var persons = BizLayer.Query.PersonQuery.GetPersons().ToArray();
                    var thisPerson = persons[persons.Length-1];
                    if (thisPerson != null) BizLayer.Query.ClientQuery.AddClient(thisPerson.personID);
                    MessageBox.Show("User was successfully added to system", "OK",
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
            Street = o.Person.address;
            City = o.Person.address;
            HouseNumber = o.Person.address;
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
