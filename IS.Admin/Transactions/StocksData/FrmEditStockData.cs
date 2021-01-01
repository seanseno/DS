using IS.Admin.Model;
using IS.Common.Helper.Extensions;
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

namespace IS.Admin.Transactions
{
    public partial class FrmEditStockData : BaseForm
    {
        private StocksData _StockData { get;set;}
        private Products _Product = new Products();
        ISFactory factory = new ISFactory();
        public FrmEditStockData(StocksData StockData)
        {
            InitializeComponent();
            this._StockData = StockData;
        }

        private void FrmEditStockData_Load(object sender, EventArgs e)
        {
            StocksDataModel StocksData = new StocksDataModel();
            _StockData = StocksData.LoadEdit(_StockData.Id);

            txtProductId.Text = _StockData.ProductId;
            txtProductName.Text = _StockData.ProductName;
            txtQuantity.Text = _StockData.Quantity.ToString("N0");
            txtSupplierPrice.Text = _StockData.SupplierPrice.ToString("N2");
            txtTotalAmount.Text = _StockData.TotalAmount.ToString("N2");
            dtpDeliveryDate.Value = _StockData.DeliveryDate;
            dtpExpirationDate.Value = _StockData.ExpirationDate;
            txtRemarks.Text = _StockData.Remarks;
            txtSellingPrice.Text = _StockData.SellingPrice.ToString("N2");
            lblCategory.Text = _StockData.CategoryName;

            CategoriesModel categoriesModel = new CategoriesModel();
            var categoryList = categoriesModel.CategoryListWithSelect();
            cboCategories.DataSource = categoryList;
            cboCategories.DisplayMember = "CategoryName";
            cboCategories.ValueMember = "CategoryId";

            PrincipalsModel principalsModel = new PrincipalsModel();
            var principalList = principalsModel.PrincipalListWithSelect();
            cboPrincipals.DataSource = principalList;
            cboPrincipals.DisplayMember = "PrincipalName";
            cboPrincipals.ValueMember = "PrincipalId";

            cboCategories.SelectedIndex = cboCategories.FindStringExact(_StockData.CategoryName);
            cboPrincipals.SelectedIndex = cboPrincipals.FindStringExact(_StockData.PrincipalName);


            if (StocksData.CheckStockDataIfAlreadyInUse(_StockData.Id))
            {
                //txtQuantity.Enabled = false;
                //txtSupplierPrice.Enabled = false;
                //txtRealUnitPrice.Enabled = false;
                txtRemainingQty.Enabled = false;
                //dtpDeliveryDate.Enabled = false;
                //dtpExpirationDate.Enabled = false;
                //this.ActiveControl = txtRemarks;
            }
            this.ActiveControl = cboCategories;
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
                    StocksData.ProductId = txtProductId.Text;
                    StocksData.PrincipalId = cboPrincipals.SelectedValue.ToString();
                    StocksData.CategoryId = cboCategories.SelectedValue.ToString();
                    StocksData.Quantity = Convert.ToInt32(txtQuantity.Text);
                    StocksData.SupplierPrice = Convert.ToDecimal(txtSupplierPrice.Text);
                    StocksData.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                    StocksData.RemainingQuantity= Convert.ToInt32(txtRemainingQty.Text);
                    StocksData.DeliveryDate = dtpDeliveryDate.Value;
                    StocksData.ExpirationDate = dtpExpirationDate.Value;
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
            else if (string.IsNullOrEmpty(txtRemainingQty.Text))
            {
                MessageBox.Show("Remaining Quantity is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRemainingQty.Focus();
                return true;
            }
            else if (Convert.ToInt32(txtQuantity.Text) <= 0)
            {
                MessageBox.Show("Invalid Quantity, Can not accept 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return true;
            }
            else if (Convert.ToDecimal(txtSupplierPrice.Text) <= 0)
            {
                MessageBox.Show("Invalid Supplier price, Can not accept 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSupplierPrice.Focus();
                return true;
            }
            else if (Convert.ToDateTime(dtpExpirationDate.Value.ToShortDateString()) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
            {
                MessageBox.Show("Invalid Expiration date, date now is greather than expiration date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            StocksDataModel StocksData = new StocksDataModel();

            if (!string.IsNullOrEmpty(txtQuantity.Text))
            {
                if (StocksData.CheckStockDataIfAlreadyInUse(_StockData.Id))
                {
                    if (Convert.ToInt32(txtQuantity.Text) > _StockData.Quantity)
                    {
                        var AddQty = Convert.ToInt32(txtQuantity.Text) - _StockData.Quantity;
                        txtRemainingQty.Text = (_StockData.RemainingQuantity + AddQty).ToString("N0");
                    }
                    else if (Convert.ToInt32(txtQuantity.Text) < _StockData.Quantity)
                    {
                        var MinuQty = _StockData.Quantity - Convert.ToInt32(txtQuantity.Text);
                        txtRemainingQty.Text = (_StockData.RemainingQuantity - MinuQty).ToString("N0");
                    }
                    else
                    {
                        txtRemainingQty.Text = _StockData.RemainingQuantity.ToString("N0");
                    }

                }
                else
                {
                    txtRemainingQty.Text = txtQuantity.Text;
                }
            }
            else
            {
                txtRemainingQty.Text = txtQuantity.Text;
            }

        }

        private void txtSupplierPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void GetTotalAmount()
        {
            if (!string.IsNullOrEmpty(txtSupplierPrice.Text) && !string.IsNullOrEmpty(txtQuantity.Text))
            {
                txtTotalAmount.Text = Math.Round(Convert.ToInt32(txtQuantity.Text) * Convert.ToDecimal(txtSupplierPrice.Text), 2).ToString("N0");
            }
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {
            ProductsModel modelProd = new ProductsModel();
            this._Product = modelProd.FindWithProductId(txtProductId.Text);
        }

        private void GetSuggestedPrice()
        {
            if (this._Product != null)
            {
                if (!string.IsNullOrEmpty(txtSupplierPrice.Text) )
                {
                    if (cboCategories.SelectedValue != null)
                    {
                        txtSuggestedPrice.Text = factory.CategoriesRepository.CategoriesStrategy.GetPercentSuggestedPrice(cboCategories.SelectedValue.ToString(), Convert.ToDecimal(txtSupplierPrice.Text))?.ToString("N2");
                    }
                }
            }
        }

        private void cboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSuggestedPrice();
        }

        private void txtSupplierPrice_TextChanged(object sender, EventArgs e)
        {
            GetSuggestedPrice();
        }
    }
}
