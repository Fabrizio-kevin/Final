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
    public partial class homepagemale : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;
        public homepagemale()
        {
            alamat = "server=localhost; database=db_final; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnKost1_Click(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void cbKost_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnKost1_Click_1(object sender, EventArgs e)
        {
            malekost1 mk1 = new malekost1();
            mk1.Show();
            this.Hide();
        }

        private void btnKost2_Click(object sender, EventArgs e)
        {
            malekost2 mk2 = new malekost2();
            mk2.Show();
            this.Hide();
        }

        private void btnKost3_Click(object sender, EventArgs e)
        {
            malekost3 mk3 = new malekost3();
            mk3.Show();
            this.Hide();
        }

        private void btnPilih_Click(object sender, EventArgs e)
        {
            
        }
    }
}
