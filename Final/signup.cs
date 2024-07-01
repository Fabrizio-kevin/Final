using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    public partial class signup : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;
        public signup()
        {
            alamat = "server=localhost; database=db_final; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                
                query = string.Format("insert into `tbl_user` (`no_regis`, `nama`, `fakultas`, `username`, `password`, `gender`) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')", txtRegis.Text, txtNama.Text, txtFakultas.Text, txtUsername.Text, txtPassword.Text, cbGender.Text);

                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                int res = perintah.ExecuteNonQuery();

                koneksi.Close();
                if (res == 1)
                {
                    MessageBox.Show("Insert data success, Silahkan kembali ke menu utama untuk Login");
                    signup_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Insert data Error");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRegis.Clear();
            txtNama.Clear();
            txtFakultas.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtRegis.Focus();
        }

        private void signup_Load(object sender, EventArgs e)
        {

        }
    }
}
