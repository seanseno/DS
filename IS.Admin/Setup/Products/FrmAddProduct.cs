using IS.Admin.Model;
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
using ZXing;

namespace IS.Admin.Setup
{
    public partial class FrmAddProduct : BaseForm
    {
        public Products _Products = new Products();
        ISFactory factory = new ISFactory();
        public FrmAddProduct()
        {
            InitializeComponent();
            this.ActiveControl = txtProductName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckRequiredInput())
            {
                if (CheckAlreadyExist())
                {
                    MessageBox.Show("Product ID already exist!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblProductId.Focus();
                }
                else
                {
                    if (MessageBox.Show("Are you sure do want to add " + txtProductName.Text + "?", "Information!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        _Products.ProductId = lblProductId.Text;

                        _Products.ProductName = txtProductName.Text;
                        _Products.Price = Convert.ToDecimal(txtPrice.Text);
                        _Products.BarCode = txtBarcode.Text;
                        _Products.CategoryId = cboCategories.SelectedValue.ToString();
                        var model = new ProductsModel();

                        model.AddItem(this);
                        MessageBox.Show(txtProductName.Text + " Added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void FrmAddProduct_Load(object sender, EventArgs e)
        {
            ProductsModel productsModel = new ProductsModel();
            lblProductId.Text = productsModel.GetNextId();

            var categoryList = factory.CategoriesRepository.GetList().OrderBy(x => x.CategoryName).ToList();
            cboCategories.DataSource = categoryList;
            cboCategories.DisplayMember = "CategoryName";
            cboCategories.ValueMember = "CategoryId";
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private bool CheckAlreadyExist()
        {
            return factory.ProductsRepository.ProductsStrategy.CheckDuplicate(lblProductId.Text);
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

            if (cboCategories.SelectedValue == null)
            {
                MessageBox.Show("Categories is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboCategories.Focus();
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
    }
}
