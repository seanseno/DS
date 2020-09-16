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
    public partial class FrmValidateOngoingEditStockData : Form
    {
        private StocksData _StockData { get;set;}
        private Products _Product = new Products();
        public FrmValidateOngoingEditStockData(StocksData StockData)
        {
            InitializeComponent();
            this._StockData = StockData;
            this.ActiveControl = txtSupplierPrice;
        }

        private void FrmEditStockData_Load(object sender, EventArgs e)
        {
            StocksDataModel StocksData = new StocksDataModel();
            var response = StocksData.LoadEdit(_StockData.Id);

            txtProductId.Text = response.ProductId;
            txtProductName.Text = response.ProductName;
            txtQuantity.Text = response.Quantity.ToString("N0");
            txtSupplierPrice.Text = response.SupplierPrice.ToString("N2");
            txtTotalAmount.Text = response.TotalAmount.ToString("N2");
            txtRealUnitPrice.Text = response.RealUnitPrice.ToString("N2");
            txtRemainingQty.Text = response.RemainingQuantity.ToString("N0");
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
                if (MessageBox.Show("Are you sure do you want to validate this record?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    StocksData StocksData = new StocksData();

                    StocksData.Id = _StockData.Id;
                    StocksData.Quantity = Convert.ToInt32(txtQuantity.Text);
                    StocksData.SupplierPrice = Convert.ToDecimal(txtSupplierPrice.Text);
                    StocksData.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                    StocksData.RealUnitPrice = Convert.ToDecimal(txtRealUnitPrice.Text);
                    StocksData.RemainingQuantity= Convert.ToInt32(txtRemainingQty.Text);
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
            else if (string.IsNullOrEmpty(txtSupplierPrice.Text))
            {
                MessageBox.Show("Supplier Price is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSupplierPrice.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(txtRealUnitPrice.Text))
            {
                MessageBox.Show("Suggested Price is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRealUnitPrice.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(txtRemainingQty.Text))
            {
                MessageBox.Show("Remaining Quantity is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRemainingQty.Focus();
                return true;
            }
            else if (Convert.ToDecimal(txtSupplierPrice.Text) <= 0)
            {
                MessageBox.Show("Invalid SupplierPrice, Can not accept 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpExpirationDate.Focus();
                return true;
            }
            else if (Convert.ToInt32(txtDuration.Text) <= 0)
            {
                MessageBox.Show("Invalid Duration, Can not accept 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            GetTotalAmount();
            txtRemainingQty.Text = txtQuantity.Text;
        }

        private void txtSupplierPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtSupplierPrice_TextChanged(object sender, EventArgs e)
        {
            GetTotalAmount();
            CategoriesModel model = new CategoriesModel();
            if (this._Product != null)
            {
                var percent = model.GetPercentSuggestedPrice(_Product.CategoryId);
                if (percent != "0")
                {
                    if (string.IsNullOrEmpty(txtSupplierPrice.Text))
                    {
                        txtRealUnitPrice.Text = "0.00";
                    }
                    else
                    {
                        var supplierPrice = Convert.ToDecimal(txtSupplierPrice.Text);
                        //= (F6 * 0.2) + F6
                        var sellingPrice = ((supplierPrice * (Convert.ToDecimal(percent) / 100)) + supplierPrice);
                        txtRealUnitPrice.Text = Math.Round(sellingPrice, 2).ToString();
                    }
                }
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

        private void GetTotalAmount()
        {
            if (!string.IsNullOrEmpty(txtSupplierPrice.Text) && !string.IsNullOrEmpty(txtQuantity.Text))
            {
                txtTotalAmount.Text = Math.Round(Convert.ToInt32(txtQuantity.Text) * Convert.ToDecimal(txtSupplierPrice.Text), 2).ToString("N0");
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
