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
    public partial class FrmEditProductPrice : BaseForm
    {
        public string _ProductId { get; set; }
        public Products _Products { get; set; }
        ISFactory factory = new ISFactory();
        public FrmEditProductPrice(string ProductId)
        {
            InitializeComponent();
            this.ActiveControl = txtPrice;
            this._ProductId = ProductId;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmEditProduct_Load(object sender, EventArgs e)
        {

            ProductsModel ProductsModel = new ProductsModel();
            _Products = ProductsModel.LoadEdit(_ProductId);
            lblItemId.Text = _Products.ProductId;

            lblProductName.Text = _Products.ProductName;
            txtPrice.Text = _Products.Price.ToString("N2");
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

            if (string.IsNullOrEmpty(txtRemarks.Text))
            {
                MessageBox.Show("Remarks is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRemarks.Focus();
                return true;
            }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckRequiredInput())
            {
                if (MessageBox.Show("Are you sure do want to update " + lblProductName.Text + "?", "Information!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _Products.Price = Convert.ToDecimal(txtPrice.Text);
                    factory.ProductsRepository.Update(_Products,txtRemarks.Text);

                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
