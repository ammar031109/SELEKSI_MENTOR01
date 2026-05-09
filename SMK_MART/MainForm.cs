using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SELEKSI_MENTOR01
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var f = new LoginForm();
            f.Show();
            this.Hide();
        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new MemberForm();
            f.Show();
            this.Hide();
        }

        private void promoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new PromoForm();
            f.Show();
            this.Hide();
        }

        private void transactionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var f = new TransactionForm();
            f.Show();
            this.Hide();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
