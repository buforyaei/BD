using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for TaskListViewItem.xaml
    /// </summary>
    public partial class TaskListItem : UserControl
    {
        public DataLayer.Task ThisTask { get; set; }
        public TaskListItem(DataLayer.Task task)
        {
            InitializeComponent();
            ThisTask = task;
            Assigned.Content += ThisTask.Employee.Person.name;
            if(task.endDate.HasValue) Date.Content += task.endDate.Value.ToString(CultureInfo.InvariantCulture);
            Description.Content += ThisTask.taskDesc;
            Comment.Content += ThisTask.resultDesc;
            if (ThisTask.endDate.Value.Year == DateTime.MaxValue.Year)
            {
                Date.Content = "Start date: " + ThisTask.beginDate.Value.ToString("yy-MM-dd") + " Not closed";
                Date.Foreground = Brushes.DarkRed;
            }
            else
            {
                Date.Content = "Start date: " + task.beginDate.Value.ToString("yy-MM-dd") + "\nEnd Date: " + ThisTask.endDate.Value.ToString("yy-MM-dd");
                Date.Foreground = Brushes.DarkGreen;
            }
        }
    }
}
