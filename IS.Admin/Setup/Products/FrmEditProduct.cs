using IS.Admin.Model;
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
using ZXing;

namespace IS.Admin.Setup
{
    public partial class FrmEditProduct : Form
    {
        public Products _Products = new Products();
        public FrmEditProduct(Products Products)
        {
            InitializeComponent();
            this.ActiveControl = cboCategories;
            this._Products = Products;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmEditProduct_Load(object sender, EventArgs e)
        {

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

            ProductsModel ProductsModel = new ProductsModel();
            var response = ProductsModel.LoadEdit(_Products.ProductId);
            lblItemId.Text = response.ProductId;
            cboCategories.SelectedIndex = cboCategories.FindStringExact(response.CategoryName);
            cboPrincipals.SelectedIndex = cboPrincipals.FindStringExact(response.PrincipalName);
            txtProductName.Text = response.ProductName;
            txtPrice.Text = Math.Round(response.Price,2).ToString();
            txtBarcode.Text = response.BarCode;
            chkActive.Checked = response.Active == 1 ? true : false;

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private bool CheckRequiredInput()
        {
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Product Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductName.Focus();
                return true;
            }

            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Price is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return true;
            }
            else if (decimal.TryParse(txtPrice.Text, out decimal price))
            {
                if (price <= 0)
                {
                    MessageBox.Show("Price is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrice.Focus();
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Invalid Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return true;
            }

            return false;
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text))
            {
                BarcodeWriter writer = new BarcodeWriter()
                {
                    Format = BarcodeFormat.CODE_128
                };
                pictureBox1.Image = writer.Write(txtBarcode.Text);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckRequiredInput())
            {
                if (MessageBox.Show("Are you sure do want to update " + txtProductName.Text + "?", "Information!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _Products.CategoryId = cboCategories.SelectedValue.ToString();
                    _Products.PrincipalId = cboPrincipals.SelectedValue.ToString();

                    _Products.ProductName = txtProductName.Text;
                    _Products.Price = Convert.ToDecimal(txtPrice.Text);
                    _Products.BarCode = txtBarcode.Text;
                    _Products.Active = chkActive.Checked == true ? 1 : 0;

                    var model = new ProductsModel();

                    model.UpdateItem(_Products);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
