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
    public partial class MemberForm : Form
    {
        DataBaseDataContext db = new DataBaseDataContext();
        string id = "";
        public MemberForm()
        {
            InitializeComponent();
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            tbMember.Enabled = false;
            showData();
          
            
        }
        void showData()
        {
            dgvData.Columns.Clear();

            var query = db.Members.Where(x => x.MemberId.Contains(tbMember.Text) ||x.Name.Contains(tbMember.Text) || x.Email.Contains(tbMember.Text) || x.Handphone.Contains(tbMember.Text))
                .Select(x => new
                {
                    MemberID = 
                    x.MemberId,
                    x.Name,
                    x.Email,
                    x.Handphone,
                    x.Expired  
                })  .ToList();

            dgvData.DataSource = query;
        }

       
          

        private void btnInsert_Click(object sender, EventArgs e)
        {
            id = "";
            enableFieldAndButton(true);
            clearField();
            generateId();
        }

        void generateId()
        {
            var query = db.Members.OrderByDescending(x => x.MemberId).FirstOrDefault()?.MemberId;
            var substring = query != null ? (Convert.ToInt32(query.Substring(5)) + 1) : 1;
            var id = $"M{DateTime.Now.Year}{substring.ToString().PadLeft(5, '0')}";

            tbMember.Text = id;

        }

        void enableField(bool x)
        {
            tbMember.Enabled = !x;
            tbEmail.Enabled = !x;
            tbHp.Enabled = !x;
            tbName.Enabled = !x;
            dtpExp.Enabled = !x;
        }

        void enableButton(bool x)
        {
            btnInsert.Enabled = x;
            btnSave.Enabled = !x;
            btnUpdate.Enabled = x;
            btnCancel.Enabled = !x;
        }

        void enableFieldAndButton(bool x)
        {
            enableField(!x);
            enableButton(!x);
        }
        void clearField()
        {
            tbName.Clear();
            tbEmail.Clear();
            tbHp.Clear();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = dgvData.Rows[e.RowIndex].Cells["MemberID"].Value.ToString();
                var query = db.Members.FirstOrDefault(x => x.MemberId == id);

                if (query != null)
                {
                    tbMember.Text = query.MemberId;
                    tbName.Text = query.Name;
                    tbEmail.Text = query.Email;
                    tbHp.Text = query.Handphone;
                    dtpExp.Value = query.Expired ?? DateTime.Now;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
         
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var f = new MainForm();
            f.Show();
            this.Hide();
        }
    }
}
