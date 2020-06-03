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

namespace IS.Admin.Trasactions
{
    public partial class FrmAddInputReceivedItem : Form
    {
        private FrmAddReceivedItem _FrmAddReceivedItem { get; set; }
        public FrmAddInputReceivedItem(FrmAddReceivedItem model)
        {
            InitializeComponent();
            this._FrmAddReceivedItem = model;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQty.Text))
            {
                MessageBox.Show("Quantity is Required!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQty.Focus();
            }
            else if (string.IsNullOrEmpty(txtOrderPrice.Text))
            {
                MessageBox.Show("Order Price is Required!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOrderPrice.Focus();
            }
            else if (string.IsNullOrEmpty(txtSellingPrice.Text))
            {
                MessageBox.Show("Selling Price Per Piece is Required!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSellingPrice.Focus();
            }
            else
            {
                int Quantity;
                DateTime DateReceived;
                DateTime DateManufactured;
                DateTime ExpirationDate;
                decimal OrderPrice = 0;
                decimal SellingPrice = 0;

                if (int.TryParse(txtQty.Text, out Quantity))
                {
                    if (Quantity <= 0)
                    {
                        MessageBox.Show("Invalid Quantity Input!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtQty.Focus();
                        return;
                    }
                }
                if (DateTime.TryParse(dtpDateReceived.Text, out DateReceived))
                {
                    if (DateReceived >= DateTime.Now)
                    {
                        MessageBox.Show("Invalid Date Received!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dtpDateReceived.Focus();
                        return;
                    }
                }
                if (DateTime.TryParse(dtpDateManufactured.Text, out DateManufactured))
                {
                    if (DateManufactured >= DateTime.Now)
                    {
                        MessageBox.Show("Invalid Date Manufactured!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dtpDateManufactured.Focus();
                        return;
                    }
                }
                if (DateTime.TryParse(dtpExpirationDate.Text, out ExpirationDate))
                {
                    if (ExpirationDate <= DateTime.Now)
                    {
                        MessageBox.Show("Invalid Expiration Date!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dtpExpirationDate.Focus();
                        return;
                    }
                }
                if (Decimal.TryParse(txtOrderPrice.Text, out OrderPrice))
                {
                    if (OrderPrice <= 0)
                    {
                        MessageBox.Show("Invalid Order Price!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtOrderPrice.Focus();
                        return;
                    }
                }
                if (Decimal.TryParse(txtSellingPrice.Text, out SellingPrice))
                {
                    if (SellingPrice <= 0)
                    {
                        MessageBox.Show("Invalid Selling Price Per Piece!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSellingPrice.Focus();
                        return;
                    }
                }
                _FrmAddReceivedItem.InputQuantity =Quantity;
                _FrmAddReceivedItem.InputDateReceived = DateReceived;
                _FrmAddReceivedItem.InputDateManufactured = DateManufactured;
                _FrmAddReceivedItem.InputExpirationDate = ExpirationDate;
                _FrmAddReceivedItem.InputOrderPrice = OrderPrice;
                _FrmAddReceivedItem.InputSellingPrice = SellingPrice;
                this.DialogResult = DialogResult.OK;
            }
            

        }

        private void FrmAddInputReceivedItem_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtQty;
         
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtOrderPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtSellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
