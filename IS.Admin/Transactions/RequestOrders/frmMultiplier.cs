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

namespace IS.Admin.Trasactions
{
    public partial class frmMultiplier : Form
    {
        ISFactory factory = new ISFactory();
        Products item = new Products();
        FrmItemRequestOrderList _FrmMain = new FrmItemRequestOrderList();
        public int? Qty { get; set; }
        private int? _ItemId { get; set; }

        public frmMultiplier(FrmItemRequestOrderList model, int? ItemId, int? Qty = null, decimal Price  =0)
        {
            InitializeComponent();
            this._ItemId = ItemId;
            this._FrmMain = model;
            this.ActiveControl = txtQty;
            txtPrice.Text = Price.ToString();
            txtQty.Text = Qty.ToString();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void frmMultiplier_Load(object sender, EventArgs e)
        {
            //item = factory.ProductsRepository.FindWithId(this._ItemId);
            //var itemName = new List<string>();
            //if(!string.IsNullOrEmpty(item.GenericName))
            //{
            //    itemName.Add(item.GenericName);
            //}
            //if (!string.IsNullOrEmpty(item.BrandName))
            //{
            //    itemName.Add(item.BrandName);
            //}
            //if (!string.IsNullOrEmpty(item.Description))
            //{
            //    itemName.Add(item.Description);
            //}
            //richTextBox1.Text = string.Join(" ", itemName);
          
        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Enter
            {
                btnAccept_Click(sender, e);

            }
        }


        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Enter
            {
                btnAccept_Click(sender, e);
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtQty.Text))
            {
                MessageBox.Show("Quantity is Required!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQty.Focus();
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Price is Required!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
            }
            else
            {
                int Quantity;
                decimal Price =0;
                if (int.TryParse(txtQty.Text, out Quantity))
                {
                    if (Qty <= 0)
                    {
                        MessageBox.Show("Invalid Quantity Input!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtQty.Focus();
                        return;
                    }
                }

                if (decimal.TryParse(txtPrice.Text, out Price))
                {
                    if (Price <= 0)
                    {
                        MessageBox.Show("Invalid Price Input!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPrice.Focus();
                        return;
                    }
                }

                _FrmMain.InputQty = Quantity;
                _FrmMain.InputPrice = Math.Round(Price, 2);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
