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
    public partial class ProductForm : Form
    {
        DataBaseDataContext db = new DataBaseDataContext();
        public static string ProductID;
        public string ProductName;
        public int productPrice;

        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            showData();
        }

        void showData()
        {
            dgvData.Columns.Clear();
            dgvData.DataSource = db.Produks.Select(x => new
            {
                x.ProdukId,
                x.Name,
                x.Specification,
                x.SellPrice
            }).ToList();

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            showData();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {

                ProductID = dgvData.CurrentRow.Cells["ProdukId"].Value.ToString();


                this.Close();
            }
            else
            {
                MessageBox.Show("please choose the product");
            }
        }
    }
}
