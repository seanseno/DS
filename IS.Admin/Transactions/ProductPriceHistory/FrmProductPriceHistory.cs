using IS.Admin.Model;
using IS.Common.Utilities;
using IS.Database;
using IS.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Admin.Setup
{
    public partial class FrmProductPriceHistory : BaseForm
    {
        ISFactory factory = new ISFactory();
        public FrmProductPriceHistory()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var response = factory.StocksDataRepository.GetOngoingStockDataProductId().Where(x=>x.SupplierPrice <= 0).ToList();
            response = response.Where(x => x.LoginName == Globals.LoginName).OrderByDescending(y => y.ProductName).ToList();
            response = response.Where(x => x.ProductId.Contains(txtSearch.Text) || x.ProductName.Contains(txtSearch.Text)).ToList();
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = response;
            txtSearch.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void FrmProductPriceHistory_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {        
            string ProductId = dgvProducts.CurrentRow.Cells[0].Value?.ToString();
            if (e.ColumnIndex == 3)
            {
                FrmEditProductPrice frm = new FrmEditProductPrice(ProductId);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //this.LoadProducts();
                    MessageBox.Show("Price updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                };
            }
        }
    }
}
