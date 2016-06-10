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
        public ProblemListItem(string name, string id, string phone, string description)
        {
            InitializeComponent();
            Description.Content += description;
            ClientName.Content += name;
            Id.Content += id;
            Phone.Content += phone;
        }
    }
}
