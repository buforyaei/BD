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
        public string Address { get; set; }

        public ProblemListItem(string name, string id, string phone, string description, string result, string obj, string tasks, DateTime endTime, string address)
        {
            InitializeComponent();
            Description.Content += description;
            ResultDescription.Content += result;
            Object.Content += obj;
            Tasks.Content += tasks;
            ClientName.Content += name;
            Id.Content += id;
            Phone.Content += phone;
            IsSelected = false;
            Address = address;
            if (endTime == DateTime.MaxValue)
                IsOpenBox.IsChecked = true;
            else IsOpenBox.IsChecked = false;
        }

   
        private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
        {

            IsSelected = !IsSelected;
            if (IsSelected) TextBox.Background = Brushes.LightGreen;
            else TextBox.Background = Brushes.Gray;
        }
    }
}
