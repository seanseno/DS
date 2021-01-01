using IS.Admin.Model;
using IS.Admin.Setup;
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

namespace IS.Admin.Transactions
{
    public partial class FrmAddStockData : BaseForm
    {
        public Categories _Categories = new Categories();
        private Products _Product = new Products();
        ISFactory factory = new ISFactory();
        public FrmAddStockData()
        {
            InitializeComponent();
            this.ActiveControl = btnSearchProduct;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Product is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSearchProduct.Focus();
                return true;
            }
            else if (cboPrincipals.SelectedValue == null)
            {
                MessageBox.Show("Principal is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboPrincipals.Focus();
                return true;
            }
            else if (cboCategories.SelectedValue == null)
            {
                MessageBox.Show("Categories is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboCategories.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(txtQuantity.Text))
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
            else if (string.IsNullOrEmpty(txtSellingPrice.Text))
            {
                MessageBox.Show("Suggested Price is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSellingPrice.Focus();
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


        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            FrmModalSearchProducts frm = new FrmModalSearchProducts();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtProductId.Text = frm._ProductId;
                txtProductName.Text = frm._ProductName;
                txtSellingPrice.Text  = frm._Price.ToString("N2");
                lblCategory.Text = frm._CategoryName;
                cboCategories.SelectedIndex = cboCategories.FindStringExact(frm._CategoryName);
                cboPrincipals.Focus();
            }
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

        }
        private void txtRealUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtTotalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
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
            GetSuggestedPrice();
            GetTotalAmount();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            GetTotalAmount();
            txtRemainingQty.Text = txtQuantity.Text;
        }
        private void GetTotalAmount()
        {
            if (!string.IsNullOrEmpty(txtSupplierPrice.Text) && !string.IsNullOrEmpty(txtQuantity.Text))
            {
                txtTotalAmount.Text = Math.Round(Convert.ToInt32(txtQuantity.Text) * Convert.ToDecimal(txtSupplierPrice.Text), 2).ToString("N2");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                StocksDataModel StocksData = new StocksDataModel();
                if (StocksData.CheckOngoingStockData(txtProductId.Text))
                {
                    MessageBox.Show("Ongoing Stock detected!" + "\n" + "Product Id: " + txtProductId.Text + "." + "\n" + "Please validate first before you can procced in this transaction!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure do you want to save this record?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        StocksData stocksData = new StocksData();
                        stocksData.Loginname = Globals.LoginName;
                        stocksData.ProductId = txtProductId.Text;
                        stocksData.PrincipalId = cboPrincipals.SelectedValue.ToString();
                        stocksData.CategoryId = cboCategories.SelectedValue.ToString();
                        stocksData.Quantity = Convert.ToInt32(txtQuantity.Text);
                        stocksData.SupplierPrice = Convert.ToDecimal(txtSupplierPrice.Text);
                        stocksData.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                        stocksData.RemainingQuantity = Convert.ToInt32(txtRemainingQty.Text);
                        stocksData.DeliveryDate = dtpDeliveryDate.Value;
                        stocksData.ExpirationDate = dtpExpirationDate.Value;
                        stocksData.Remarks = txtRemarks.Text;
                        var StocksDataModel = new StocksDataModel();
                        StocksDataModel.InsertStockData(stocksData);

                        this.DialogResult = DialogResult.OK;
                    }
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSuggestedPrice();
        }

        private void GetSuggestedPrice()
        {
            if (this._Product != null)
            {
                if (!string.IsNullOrEmpty(txtSupplierPrice.Text))
                {
                    txtSuggestedPrice.Text = factory.CategoriesRepository.CategoriesStrategy.GetPercentSuggestedPrice(cboCategories.SelectedValue.ToString(), Convert.ToDecimal(txtSupplierPrice.Text))?.ToString("N2");
                }
            }
        }


    }
}
