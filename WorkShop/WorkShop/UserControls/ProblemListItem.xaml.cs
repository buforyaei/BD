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
    public partial class ProblemListItem : UserControl
    {
        public bool IsSelected { get; set; }
        public DataLayer.Problem Problem { get; set; }
        public DataLayer.Object Obj { get; set; }
        public ProblemListItem(DataLayer.Problem problem)
        {
            InitializeComponent();
            Problem = problem;
            Description.Content += Problem.problemDesc;
            var obj = BizLayer.Query.ObjectQuery.GetObject(Problem.objectID.Value);
            Obj = obj.First();
            ObjectInfo.Content += " Name: " + Obj.name + " Model: " + Obj.model + " Id: " + Obj.objectID + "\nClient " + Obj.Client;
            if (problem.endDate.Value.Year ==DateTime.MaxValue.Year)
            {
                Date.Content = "Start date: " + Problem.beginDate.Value.ToString("yy-MM-dd") + " Not closed";
                Date.Foreground = Brushes.DarkRed;
                ResultDescription.Content += "";
                int taskNumber = 0;
                int openTaskNumber = 0;
                var tasks = BizLayer.Query.TaskQuery.GetTasks();
                foreach (var t in tasks)
                {
                    if (t.problemID == Problem.problemID)
                    {
                        taskNumber++;
                        if (t.endDate.Value.Year == DateTime.MaxValue.Year)
                            openTaskNumber++;
                    }
                }
                ResultDescription.Content = "Task number: " + taskNumber + "  Not closed: " + openTaskNumber;

            }
            else
            {
                Date.Content = "Start date: " + Problem.beginDate.Value.ToString("yy-MM-dd") + " End Date: " + Problem.endDate.Value.ToString("yy-MM-dd");
                Date.Foreground = Brushes.DarkGreen;
                ResultDescription.Content += Problem.resultDesc;
            }
            
        }

        public ProblemListItem()
        {
            InitializeComponent();
        }


        private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
        {

            IsSelected = !IsSelected;
            if (IsSelected) TextBox.Background = Brushes.LightGreen;
            else TextBox.Background = Brushes.Gray;
        }
    }
}
