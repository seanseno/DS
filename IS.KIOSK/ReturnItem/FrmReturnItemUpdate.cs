using IS.Common.Utilities;
using IS.Database;
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
    public partial class FrmReturnItemUpdate : Form
    {
        int _StockDataId { get; set; }
        int _SalesId { get; set; }
        string _ProductName { get; set; }
        ISFactory factory = new ISFactory();
        int _Qty { get; set; }
        public FrmReturnItemUpdate(int StockDataId, int SalesId, string ProductName)
        {
            InitializeComponent();
            _StockDataId = StockDataId;
            _ProductName = ProductName;
            _SalesId = SalesId;
            this.ActiveControl = txtQty;
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                if (MessageBox.Show("Are you sure?", "Information!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        int quantity = _Qty - Convert.ToInt32(txtQty.Text);
                        factory.LedgerSalesRepository.ReturnItem(_StockDataId, _SalesId, quantity, Convert.ToInt32(txtQty.Text), "Returned Quantity:" + Convert.ToInt32(txtQty.Text),Globals.LoginName);
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool checkInput()
        {
            bool isOk = true;
            _Qty = factory.SalesRepository.GetList().Where(x => x.Id == _SalesId).FirstOrDefault().Qty;
            if (string.IsNullOrEmpty(txtQty.Text))
            {
                MessageBox.Show("Quantity is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQty.Focus();
                isOk = false;
            }
            else if (Convert.ToInt32(txtQty.Text) <= 0)
            {
                MessageBox.Show("Quantity is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQty.Focus();
                btnSave.Focus();
                isOk = false;
            }
            else if (_Qty < Convert.ToInt32(txtQty.Text))
            {
                MessageBox.Show("Invalid Quantity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQty.Focus();
                isOk = false;
            }
            return isOk;
        }

        private void FrmReturnItemUpdate_Load(object sender, EventArgs e)
        {
            lblProduct.Text = _ProductName;
        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 13)
            //{
            //    btnSave_Click(sender, e);
            //}
           
        }
    }
}
