using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WorkShop.UserControls
{
    /// <summary>
    /// Interaction logic for ClientListItem.xaml
    /// </summary>
    public partial class ClientListItem : UserControl
    {
        public DataLayer.Client Client { get; set; }
        public ClientListItem(DataLayer.Client client)
        {
            InitializeComponent();
            Client = client;
            if (Client != null)
            {
                Name.Content = Client.Person.name;
                Address.Content = Client.Person.city + " " + Client.Person.street + " " + Client.Person.housenumber;
                Phone.Content = Client.Person.phone.ToString();
                ClientId.Content = Client.clientID.ToString();
                //if (Objects.Any())
                //{
                //    foreach (var o in Objects)
                //    {
                //        //wypisac ladnie objects jakos
                //       // ObjectInfo.Content = 
                //    }
                //}
            }
        }

        private void ObjectInfoButton_Click(object sender, RoutedEventArgs e)
        {
            //show objects details
        }
    }
}
