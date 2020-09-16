using IS.Admin.Model;
using IS.Common.Helper.Extensions;
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
    public partial class FrmOingingEditStockData : Form
    {
        private StocksData _StockData { get;set;}
        private Products _Product = new Products();
        public FrmOingingEditStockData(StocksData StockData)
        {
            InitializeComponent();
            this._StockData = StockData;
        }

        private void FrmEditStockData_Load(object sender, EventArgs e)
        {
            StocksDataModel StocksData = new StocksDataModel();
            var response = StocksData.LoadEdit(_StockData.Id);

            txtProductId.Text = response.ProductId;
            txtProductName.Text = response.ProductName;
            txtQuantity.Text = response.Quantity.ToString("N0");
            dtpDeliveryDate.Value = response.DeliveryDate;
            dtpExpirationDate.Value = response.ExpirationDate;
            txtDuration.Text = response.Duration.ToString("N0");
            txtRemarks.Text = response.Remarks;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                if (MessageBox.Show("Are you sure do you want to save this record?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    StocksData StocksData = new StocksData();

                    StocksData.Id = _StockData.Id;
                    StocksData.Quantity = Convert.ToInt32(txtQuantity.Text);
                    StocksData.DeliveryDate = dtpDeliveryDate.Value;
                    StocksData.ExpirationDate = dtpExpirationDate.Value;
                    StocksData.Duration = Convert.ToInt32(txtDuration.Text);
                    StocksData.Remarks = txtRemarks.Text;

                    var StocksDataModel = new StocksDataModel();
                    StocksDataModel.UpdateStockData(StocksData);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Quantity is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
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

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtRealUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


        private void dtpExpirationDate_ValueChanged(object sender, EventArgs e)
        {
            txtDuration.Text = String.Format("{0,10:N0}", (dtpExpirationDate.Value - DateTime.Now).TotalDays);
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {
            ProductsModel modelProd = new ProductsModel();
            this._Product = modelProd.FindWithProductId(txtProductId.Text);
        }
    }
}
