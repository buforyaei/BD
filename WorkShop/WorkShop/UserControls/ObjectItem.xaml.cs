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
    public partial class ObjectItem : UserControl
    {
        public DataLayer.Object Obj { get; set; }
        public DataLayer.Client Client { get; set; }
        public List<DataLayer.Problem> Problems { get; set; }

        public ObjectItem(DataLayer.Object obj, DataLayer.Client client, List<DataLayer.Problem> problems)
        {
            InitializeComponent();
            if (obj != null)
            {
                Obj = obj;
                Client = client;
                Problems = problems;
                Name.Content = obj.name;
                Model.Content = obj.model;

                ObjId.Content = obj.objectID.ToString();
                if (Client != null)
                {
                    ClientInfo.Content += "\nid: " + Client.clientID + " Name: " + Client.Person.name + "Phone: " + Client.Person.phone + "\n" +
                        "Address: " + Client.Person.city + " "+ Client.Person.street +" "+ Client.Person.housenumber;
                    foreach (var p in Problems)
                    {
                        if (p.endDate < DateTime.Now)
                            ProblemInfo.Content += "id:" + p.problemID + " Description: " + p.problemDesc + " \nResult:" +
                                                   p.resultDesc + " Problem started at " + p.beginDate +
                                                   " is closed at " + p.endDate + "\n";
                        else
                            ProblemInfo.Content += "id:" + p.problemID + " Description: " + p.problemDesc + " \nResult:" +
                                                   p.resultDesc + " Problem started at " + p.beginDate +
                                                   " is notclosed\n";
                    }

                }
            }
            
        }

        private void ClientInfoButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void ProblemInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
