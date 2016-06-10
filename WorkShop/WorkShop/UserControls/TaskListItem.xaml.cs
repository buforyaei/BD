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
    /// Interaction logic for TaskListViewItem.xaml
    /// </summary>
    public partial class TaskListItem : UserControl
    {
        public TaskListItem(string topic, string assigned, string deadline, string description, string comment)
        {
            InitializeComponent();
            Topic.Content += topic;
            Assigned.Content += assigned;
            Deadline.Content += deadline;
            Description.Content += description;
            Comment.Content += comment;
        }
    }
}
