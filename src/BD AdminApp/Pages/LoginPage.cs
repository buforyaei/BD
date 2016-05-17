using System;
using System.Windows.Forms;

namespace BD_AdminApp.Pages
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var adminMainPage = new AdminMainPage();
            adminMainPage.Show();
            Hide();
        }
    }
}
