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
    public partial class PromoForm : Form
    {
        DataBaseDataContext db = new DataBaseDataContext();
        string id = "";
        public PromoForm()
        {
            InitializeComponent();
        }

        private void PromoForm_Load(object sender, EventArgs e)
        {
          
        }

      

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["PromoId"].Value);
                var query = db.Promos.FirstOrDefault(x => x.PromoId == id);
                if (query != null)
                {
                    this.id = query.PromoId.ToString();
                    tbProductID.Text = query.ProdukId;
                    tbBuy.Text = query.BuyQty.ToString();
                    cbPromo.Text = query.Type;
                    tbReward.Text = query.Reward.ToString();

                    dtStart.Value = query.StartDate ?? DateTime.Now;
                    dtEnd.Value = query.EndDate ?? DateTime.Now;
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
          
        }


        private void btnTitik_Click(object sender, EventArgs e)
        {
            ProductForm f = new ProductForm();
            ProductForm.ProductID = "";
            f.ShowDialog();

            if (ProductForm.ProductID != "")
            {

                tbProductID.Text = ProductForm.ProductID;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var f = new MainForm();
            f.Show();
            this.Hide();
        }

        private void cbPromo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
