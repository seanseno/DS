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
        Items item = new Items();
        FrmItemRequestOrderList _FrmMain = new FrmItemRequestOrderList();
        public int? Qty { get; set; }
        private int? _ItemId { get; set; }
        int CountErrorlabel = 0;
        public frmMultiplier(FrmItemRequestOrderList model, int? ItemId)
        {
            InitializeComponent();
            this._ItemId = ItemId;
            this._FrmMain = model;
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void frmMultiplier_Load(object sender, EventArgs e)
        {
            item = factory.ItemsRepository.FindWithId(this._ItemId);
            var itemName = new List<string>();
            if(!string.IsNullOrEmpty(item.GenericName))
            {
                itemName.Add(item.GenericName);
            }
            if (!string.IsNullOrEmpty(item.BrandName))
            {
                itemName.Add(item.BrandName);
            }
            if (!string.IsNullOrEmpty(item.Description))
            {
                itemName.Add(item.Description);
            }
            richTextBox1.Text = string.Join(" ", itemName);
          
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!lblError.Visible)
            {
                lblError.Visible = true;
            }
            else
            {
                lblError.Visible = false;
            }
            CountErrorlabel++;
            if (CountErrorlabel >= 10)
            {
                timer1.Stop();
                lblError.Visible = true;
                CountErrorlabel = 0;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Price is Required!", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txtQty.Text))
            {
                MessageBox.Show("Quantity is Required!", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                _FrmMain.InputQty = Convert.ToInt32(txtQty.Text);
                _FrmMain.InputPrice = Math.Round(Convert.ToDecimal(txtPrice.Text),2);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
