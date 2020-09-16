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
    public partial class FrmProductPriceHistory : Form
    {
        ISFactory factory = new ISFactory();
        public FrmProductPriceHistory()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var productIdList = factory.StocksDataRepository.GetOngoingStockDataProductId(Globals.LoginName);
            if (productIdList.Count <= 0)
            {
                MessageBox.Show("No reason for changing product price!", "Information.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmModalSearchProducts frm = new FrmModalSearchProducts(productIdList);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var product = factory.ProductsRepository.FindWithProductId(frm._ProductId);
                    FrmEditProductPrice frmEditProductPrice = new FrmEditProductPrice(product);
                    if (frmEditProductPrice.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Product price updated!", "Information.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
        }


        private void LoadData()
        {
            var response = factory.ProductPriceHistoryRepository.GetList(txtSearch.Text);
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = response;
            txtSearch.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FrmProductPriceHistory_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
