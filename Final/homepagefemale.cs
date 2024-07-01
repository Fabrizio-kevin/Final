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
    public partial class homepagefemale : Form
    {
        public homepagefemale()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnKost1_Click(object sender, EventArgs e)
        {
            femalekost1 fk1 = new femalekost1();
            fk1.Show();
            this.Hide();
        }

        private void btnKost2_Click(object sender, EventArgs e)
        {
            femalekost2 fk2 = new femalekost2();
            fk2.Show();
            this.Hide();
        }

        private void btnKost3_Click(object sender, EventArgs e)
        {
            femalekost3 fk3 = new femalekost3();
            fk3.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
