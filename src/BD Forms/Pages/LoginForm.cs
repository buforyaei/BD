﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
           
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            bool IfMenager = false;
            MessageBox.Show("Login as  {0}","Loggin");
            if (checkBox1.Checked.Equals(true))
                IfMenager = true;
            else
                IfMenager = false;
           
            var empl = new EmployMenu(IfMenager);
            Hide();
            empl.Show();

        }
    }
}
