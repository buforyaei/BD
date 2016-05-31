using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using BizLayer;

namespace BD_Forms
{
    public partial class EmployMenu : Form
    {
        private bool IfMenager;
        public EmployMenu(bool ifMenager)
        {
            InitializeComponent();
            IfMenager = ifMenager;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();  
            Application.Exit();
        }

        private void EmployMenu_Load(object sender, EventArgs e)
        {
            NewOrderPanel.Hide();
            OrdersPanel.Hide();
            SearchPanel.Hide();
            TasksPanel.Hide();
            checkBox1.Enabled = false;
            if (IfMenager == false)
            {
                InitializeTasksButton.Enabled = false;
                RegisterOrderButton.Enabled = false;
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }

        }

        private void RegisterOrderButton_Click(object sender, EventArgs e)
        {
            NewOrderPanel.Show();
            OrdersPanel.Hide();
            SearchPanel.Hide();
            TasksPanel.Hide();
            NewOrderPanel.Location = new Point(165,12);
            //156,12
            MyTasksButton.Enabled = false;
            SearchButton.Enabled = false;
            RegisterOrderButton.Enabled = false;
            OrdersButton.Enabled = false;


        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            NewOrderPanel.Hide();
            OrdersPanel.Hide();
            TasksPanel.Hide();
            SearchPanel.Hide();
            MyTasksButton.Enabled = true;
            SearchButton.Enabled = true;
            RegisterOrderButton.Enabled = true;
            OrdersButton.Enabled = true;


        }

        private void PalceOrderButton_Click(object sender, EventArgs e)
        {
            //zapisz zlecenie
        }

        private void OrdersButton_Click(object sender, EventArgs e)
        {
            OrdersPanel.Show();
            NewOrderPanel.Hide();
            SearchPanel.Hide();
            TasksPanel.Hide();
            OrdersPanel.Location = new Point(165, 12);
            //readfrom data base orders
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewOrderPanel.Hide();
            OrdersPanel.Hide();
            TasksPanel.Hide();
            SearchPanel.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            NewOrderPanel.Hide();
            OrdersPanel.Hide();
            TasksPanel.Hide();
            SearchPanel.Hide();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            NewOrderPanel.Hide();
            OrdersPanel.Hide();
            TasksPanel.Hide();
            SearchPanel.Show();
            SearchPanel.Location = new Point(165, 12);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewOrderPanel.Hide();
            OrdersPanel.Hide();
            TasksPanel.Hide();
            SearchPanel.Hide();
        }

        private void MyTasksButton_Click(object sender, EventArgs e)
        {
            NewOrderPanel.Hide();
            OrdersPanel.Hide();
            TasksPanel.Show();
            SearchPanel.Hide();
            TasksPanel.Location = new Point(165, 12);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var singleTaskView = new SingleTaskView();
            singleTaskView.Show();
            
        }

        private void InitializeTasksButton_Click(object sender, EventArgs e)
        {
            InitialTasksForm initialTasksForm = new InitialTasksForm();
            initialTasksForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BizLayer.BizService.GetProblem(1);
        }
    }
}
