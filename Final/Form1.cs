using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login Login = new login();
            Login.Show();
            this.Hide();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            signup Signup = new signup();
            Signup.Show(); 
            this.Hide();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            info Info = new info();
            Info.Show();
            this.Hide();
        }
    }
}
