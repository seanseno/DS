using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.KIOSK
{
    public partial class FrmEntryQty : BaseForm
    {
        public string _Qty { get; set; }
        string _Product { get; set; }
        public FrmEntryQty(string product,string qty)
        {
            InitializeComponent();
            _Qty = qty;
            _Product = product;
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FrmEntryQty_Load(object sender, EventArgs e)
        {
            txtQty.Text = _Qty;
            lblProductName.Text = _Product;
        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else 
            if (e.KeyValue == 13)
            {
                this._Qty = txtQty.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
