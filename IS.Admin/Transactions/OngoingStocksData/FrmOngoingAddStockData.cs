using IS.Admin.Model;
using IS.Admin.Setup;
using IS.Common.Utilities;
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

namespace IS.Admin.Transactions
{
    public partial class FrmOngoingAddStockData : Form
    {
        public Categories _Categories = new Categories();
        private Products _Product = new Products();
        public FrmOngoingAddStockData()
        {
            InitializeComponent();
            this.ActiveControl = btnSearchProduct;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    if (!CheckInput())
        //    {
        //        var StocksDataModel = new StocksDataModel();
        //        _Categories.StockDataId = txtStockDataId.Text.ToUpper();
        //        _Categories.StockDataName = txtStockDataName.Text.ToUpper();
        //        StocksDataModel.StockDat
        //        if (CategoriesModel.CheckDup(this))
        //        {
        //            MessageBox.Show(_Categories.StockDataName + " already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            txtStockDataName.Focus();
        //            return;
        //        }
        //        if (MessageBox.Show("Continue saving " + txtStockDataName.Text + ".", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
        //        {
        //            CategoriesModel.AddStockData(this);
        //            MessageBox.Show(txtStockDataName.Text + " Added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            this.DialogResult = DialogResult.OK;
        //        }
        //        //}
        //    }
        //}
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Product is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSearchProduct.Focus();
                return true;
            }
            else if (Convert.ToInt32(txtQuantity.Text) <= 0)
            {
                MessageBox.Show("Invalid Quantity, Can not accept 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return true;
            }

            else if (Convert.ToInt32(txtDuration.Text) <= 0)
            {
                MessageBox.Show("Invalid Duration, Can not accept 0 or less than 0!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpExpirationDate.Focus();
                return true;
            }
            return false;
        }


        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            FrmModalSearchProducts frm = new FrmModalSearchProducts();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtProductId.Text = frm._ProductId;
                txtProductName.Text = frm._ProductName;
                txtQuantity.Focus();
            }
        }


        private void dtpExpirationDate_ValueChanged(object sender, EventArgs e)
        {
            txtDuration.Text = String.Format("{0,10:N0}", (dtpExpirationDate.Value - DateTime.Now).TotalDays);
        }

        private void txtDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void FrmAddStockData_Load(object sender, EventArgs e)
        {
            dtpDeliveryDate.Value = DateTime.Now;
            dtpExpirationDate.Value = DateTime.Now;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                if (MessageBox.Show("Are you sure do you want to save this record?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    StocksData stocksData = new StocksData();
                    stocksData.Loginname = Globals.LoginName;
                    stocksData.ProductId = txtProductId.Text;
                    stocksData.Quantity = Convert.ToInt32(txtQuantity.Text);
                    stocksData.SupplierPrice = 0;
                    stocksData.TotalAmount = 0;
                    stocksData.RealUnitPrice = 0;
                    stocksData.RemainingQuantity = Convert.ToInt32(txtQuantity.Text);
                    stocksData.DeliveryDate = dtpDeliveryDate.Value;
                    stocksData.ExpirationDate = dtpExpirationDate.Value;
                    stocksData.Duration = Convert.ToInt32(txtDuration.Text);
                    stocksData.Remarks = txtRemarks.Text;
                    var StocksDataModel = new StocksDataModel();
                    StocksDataModel.InsertStockData(stocksData);

                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {
            ProductsModel modelProd = new ProductsModel();
            this._Product = modelProd.FindWithProductId(txtProductId.Text);
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
