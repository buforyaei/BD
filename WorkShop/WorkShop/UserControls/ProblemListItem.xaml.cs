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
            ResultDescription.Content += Problem.resultDesc;
            var obj = BizLayer.Query.ObjectQuery.GetObject(Problem.objectID.Value);
            Obj = obj.First();
            ObjectInfo.Content += " Name:" + Obj.name + " Model:" + Obj.model + " Id:" + Obj.objectID + " Client Name:" + Obj.Client;
            if (problem.endDate.Value.Year ==DateTime.MaxValue.Year)
            {
                Date.Content = "Start date: " + Problem.beginDate.Value.ToString("yy-MM-dd") + " Not closed";
                Date.Foreground = Brushes.DarkRed;
            }
            else
            {
                Date.Content = "Start date: " + Problem.beginDate.Value.ToString("yy-MM-dd") + " End Date: " + Problem.endDate.Value.ToString("yy-MM-dd");
                Date.Foreground = Brushes.DarkGreen;
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
