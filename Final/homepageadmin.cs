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
    public partial class homepageadmin : Form

    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;
        public homepageadmin()
        {
            alamat = "server=localhost; database=db_final; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                query = string.Format("DELETE FROM `tbl_user` where no_regis = '{0}'", txtRegis.Text);
                ds.Clear();
                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                adapter.Fill(ds);
                koneksi.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                
                query = string.Format("UPDATE `tbl_user` SET `nama`='{0}',`fakultas`='{1}',`username`='{2}',`password`='{3}',`gender`='{4}',`kost`='{5}' where no_regis ='{6}'", txtNama.Text, txtFakultas.Text, txtUsername.Text, txtPassword.Text, cbGender.Text, cbKost.Text, txtRegis.Text);
                ds.Clear();
                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                adapter.Fill(ds);
                koneksi.Close();

                homepageadmin_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void homepageadmin_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = string.Format("select * from tbl_user");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Width = 70;
                dataGridView1.Columns[0].HeaderText = "No_Regis";
                dataGridView1.Columns[1].Width = 70;
                dataGridView1.Columns[1].HeaderText = "Nama";
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[2].HeaderText = "Fakultas";
                dataGridView1.Columns[3].Width = 70;
                dataGridView1.Columns[3].HeaderText = "Username";
                dataGridView1.Columns[4].Width = 65;
                dataGridView1.Columns[4].HeaderText = "Password";
                dataGridView1.Columns[5].Width = 60;
                dataGridView1.Columns[5].HeaderText = "Gender";
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[6].HeaderText = "Kost";

                txtRegis.Clear();
                txtNama.Clear();
                txtFakultas.Clear();
                txtUsername.Clear();
                txtPassword.Clear();


                txtRegis.Focus();

                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnRead.Enabled = false;
                btnSave.Enabled = true;
                btnRead.Enabled = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRegis.Text != "")
                {
                    query = string.Format("select * from tbl_user where no_regis = '{0}'", txtRegis.Text);
                    ds.Clear();
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    perintah.ExecuteNonQuery();
                    adapter.Fill(ds);
                    koneksi.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow kolom in ds.Tables[0].Rows)
                        {
                            txtRegis.Text = kolom["no_regis"].ToString();
                            txtUsername.Text = kolom["username"].ToString();
                            txtPassword.Text = kolom["password"].ToString();
                            txtNama.Text = kolom["nama"].ToString();
                            txtFakultas.Text = kolom["fakultas"].ToString();
                            cbKost.Text = kolom["kost"].ToString();

                            if (kolom["gender"].ToString() == "Male")
                            {
                                cbGender.Text = "Male";
                            }
                            else
                            {
                                cbGender.Text = "Female";
                            }


                            cbGender.Enabled = true;

                            btnSave.Enabled = false;
                            btnDelete.Enabled = true;
                            btnUpdate.Enabled = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nomor Registrasi masih kosong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbGender.Text == "Male")
                {
                    cbGender.Text = "Male";
                }
                else
                {
                    cbGender.Text = "Female";
                }
                query = string.Format("insert into `tbl_user` (`no_regis`, `nama`, `fakultas`, `username`, `password`, `gender`, `kost`) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", txtRegis.Text, txtNama.Text, txtFakultas.Text, txtUsername.Text, txtPassword.Text, cbGender.Text, cbKost.Text);

                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                int res = perintah.ExecuteNonQuery();

                koneksi.Close();
                if (res == 1)
                {
                    MessageBox.Show("Insert data success, Silahkan kembali ke menu utama untuk Login");
                    homepageadmin_Load(null, null);
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 logout = new Form1();
            logout.Show();
            this.Hide();
        }
    }
}
