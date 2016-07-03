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
        public int Counter { get; set; }

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
                Counter = 0;
                ObjId.Content = obj.objectID.ToString();
                if (Problems.Any())
                {
                    problems.Sort((x, y) => DateTime.Compare(x.beginDate.Value, y.beginDate.Value));
                    FillProblemGrid(Counter);
                }
                else
                {
                    ProblemInfoButton.Visibility = Visibility.Collapsed;
                }
                   
                if (Client != null)
                {
                    ClientInfo.Content += "\nId: " + Client.clientID + " Name: " + Client.Person.name + "Phone: " + Client.Person.phone + "\n" +
                        "Address: " + Client.Person.city + " "+ Client.Person.street +" "+ Client.Person.housenumber; 
                }

            }
            
        }
        private void  FillProblemGrid(int counter)
        {
            var problems = Problems.ToArray();
            if (problems[counter].endDate < DateTime.Now)
            {
                ProblemDates.Content = "Problem id: " + problems[counter].problemID + " Problem started at " +
                                       problems[counter].beginDate.Value.ToString("dd-mm-yy") +
                                       "\nis closed at " + problems[counter].endDate.Value.ToString("dd-mm-yy");
                ResultDesc.Content = "Result: " + problems[counter].resultDesc;
                Description.Content = "Description: " + problems[counter].problemDesc;
                ProblemDates.Foreground = Brushes.MidnightBlue;

            }
            else
            {
                var tasks = BizLayer.Query.TaskQuery.GetTasks();
                int tasksNumberForCurrentProblem = 0;
                foreach (var t in tasks)
                {
                    if (t.problemID == problems[counter].problemID)
                    {
                        if (t.endDate.Value.Year == DateTime.MaxValue.Year)
                            tasksNumberForCurrentProblem++;
                    }
                }
                ProblemDates.Content = "Problem id: " + problems[counter].problemID + " Problem started at " + problems[counter].beginDate.Value.ToString("dd-MM-yy") +
                                       "\nNot closed with " + tasksNumberForCurrentProblem + " open tasks";
                ProblemDates.Foreground = Brushes.DarkRed;
                Description.Content = "Description: " + problems[counter].problemDesc;
                ResultDesc.Content = ""; 
            }
               


        }
        private void ClientInfoButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void ProblemInfo_Click(object sender, RoutedEventArgs e)
        {
            Counter++;
            if (Counter == Problems.Count)
            {
                Counter = 0;
            }
            FillProblemGrid(Counter);
        }
    }
}
