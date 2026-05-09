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
    public partial class TransactionForm : Form
    {
        DataBaseDataContext db = new DataBaseDataContext();
        
        public TransactionForm()
        {
            InitializeComponent();
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {
          
        }

     
        void showPromo()
        {
            
        }


        private void btnTitik_Click(object sender, EventArgs e)
        {
            ProductForm f =
              new ProductForm();

            if (f.ShowDialog() == DialogResult.OK)
            {
                tbProductID.Text = f.ProductName;

                tbName.Text = f.ProductName;

                tbPrice.Text =
                    f.productPrice.ToString();

                showPromo();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
        }


        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = dgvData.Rows[e.RowIndex].Cells["ProdukId"].Value.ToString();
                var query = db.Produks.FirstOrDefault(x => x.ProdukId == id);

                if (query != null)
                {
                    tbProductID.Text = query.ProdukId;
                    tbName.Text = query.Name;
                    tbPrice.Text = query.SellPrice.ToString();
                    tbQyt.Text = query.BuyPrice.ToString();

                }

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        { 
        
        }
    }
}
