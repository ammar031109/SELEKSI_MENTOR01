using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SELEKSI_MENTOR01
{
    public partial class LoginForm : Form
    {
        DataBaseDataContext db = new DataBaseDataContext();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbEmail.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("All fields must be filled");
                return;

            }

            var db = new DataBaseDataContext();
            var email = db.Employees 
                .Where(x => x.Email == tbEmail.Text && x.Password == tbPassword.Text).FirstOrDefault();

            if (email != null)
            {
                new MemberForm().Show();
                this.Hide();
            }

            else 
            {
                MessageBox.Show("Your data is not valid!!");
                tbEmail.Text = "";
                tbPassword.Text = "";
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            tbEmail.Text = "mariz@gmail.com";
            tbPassword.Text = "mariz123";
        }
    }
}
