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
    public partial class femalekost2 : Form
    {
        public femalekost2()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            homepagefemale hpf = new homepagefemale();
            hpf.Show();
            this.Hide();
        }
    }
}
