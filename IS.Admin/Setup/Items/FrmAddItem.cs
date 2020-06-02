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
    public partial class FrmAddItem : Form
    {
        public Items _Items = new Items();
        public FrmAddItem()
        {
            InitializeComponent();
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
                if (MessageBox.Show("Are you sure do want to add " + txtBrandName.Text + "?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var CompId = Convert.ToInt32(cboCompanies.SelectedValue.ToString());
                    if(CompId!=0)
                    {
                        _Items.CompanyId = CompId;
                    }
                    var CatId = Convert.ToInt32(cboCategories.SelectedValue.ToString());
                    if (CatId != 0)
                    {
                        _Items.CategoryId = CatId;
                    }

                    _Items.GenericName = txtGenericname.Text;
                    _Items.BrandName = txtBrandName.Text;
                    _Items.Description = txtDescription.Text;
                    _Items.Price = Convert.ToDecimal(txtPrice.Text);
                    _Items.Stock = Convert.ToInt32(txtStock.Value);
                    _Items.BarCode = txtBarcode.Text;
                    var model = new ItemsModel();

                    model.AddItem(this);
                    MessageBox.Show(txtBrandName.Text + " Added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void FrmAddItem_Load(object sender, EventArgs e)
        {
            this.ActiveControl = cboCategories;

            CategoriesModel model1 = new CategoriesModel();
            var Categories = model1.CategoryListWithSelect();
            cboCategories.DataSource = Categories;
            cboCategories.DisplayMember = "CategoryName";
            cboCategories.ValueMember = "Id";

            CompaniesModel model = new CompaniesModel();
            var Companies = model.CompanyListWithSelect();
            cboCompanies.DataSource = Companies;
            cboCompanies.DisplayMember = "CompanyName";
            cboCompanies.ValueMember = "Id";

            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
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
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Description is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescription.Focus();
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

            if (txtStock.Value < 0)
            {
                MessageBox.Show("Invalid Stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStock.Focus();
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
