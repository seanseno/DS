using IS.Admin.Model;
using IS.Database.Entities;
using IS.Library.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Admin.Setup
{
    public partial class FrmUpdateCashierDenomination : Form
    {
        public FrmUpdateCashierDenomination(Cashiers Cashier)
        {
            InitializeComponent();

        }

        private void FrmUpdateCashierDenomination_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtThousand;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void txtThousand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            
        }

        private void txt5Hundred_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            lblTotal.Text = SumTotal().ToString();
        }

        private void txt1Hundred_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            lblTotal.Text = SumTotal().ToString();
        }

        private void txtFifty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            lblTotal.Text = SumTotal().ToString();
        }

        private void txtTwenty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            lblTotal.Text = SumTotal().ToString();
        }

        private void txtCoins_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            lblTotal.Text = SumTotal().ToString();
        }

        private void txtCents_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            lblTotal.Text = SumTotal().ToString();
        }

        private string SumTotal()
        {
            decimal Thousand = 0;
            decimal FiveHundred = 0;
            decimal OnHundred = 0;
            decimal Fifty = 0;
            decimal Twenty = 0;
            decimal Coins = 0;
            decimal Cents = 0;

            if (!string.IsNullOrEmpty(txtThousand.Text))
            {
                Thousand = decimal.Parse(txtThousand.Text);
            }
            if (!string.IsNullOrEmpty(txt5Hundred.Text))
            {
                FiveHundred = decimal.Parse(txt5Hundred.Text);
            }
            if (!string.IsNullOrEmpty(txt1Hundred.Text))
            {
                 OnHundred = decimal.Parse(txt1Hundred.Text);
            }
            if (!string.IsNullOrEmpty(txtFifty.Text))
            {
                Fifty = decimal.Parse(txtFifty.Text);
            }
            if (!string.IsNullOrEmpty(txtTwenty.Text))
            {
                 Twenty = decimal.Parse(txtTwenty.Text);
            }
            if (!string.IsNullOrEmpty(txtCoins.Text))
            {
                Coins = decimal.Parse(txtCoins.Text);
            }
            if (!string.IsNullOrEmpty(txtCents.Text))
            {
                Cents = decimal.Parse("." + txtCents.Text);
            }

            var Total = (Thousand + FiveHundred + OnHundred + Fifty + Twenty + Coins + Cents);
            return string.Format("{0:n}", Total);
        }

        private void txtThousand_KeyUp(object sender, KeyEventArgs e)
        {
            lblTotal.Text = SumTotal().ToString();
        }

        private void txt5Hundred_KeyUp(object sender, KeyEventArgs e)
        {
            lblTotal.Text = SumTotal().ToString();
        }

        private void txt1Hundred_KeyUp(object sender, KeyEventArgs e)
        {
            lblTotal.Text = SumTotal().ToString();
        }

        private void txtFifty_KeyUp(object sender, KeyEventArgs e)
        {
            lblTotal.Text = SumTotal().ToString();
        }

        private void txtTwenty_KeyUp(object sender, KeyEventArgs e)
        {
            lblTotal.Text = SumTotal().ToString();
        }

        private void txtCoins_KeyUp(object sender, KeyEventArgs e)
        {
            lblTotal.Text = SumTotal().ToString();
        }

        private void txtCents_KeyUp(object sender, KeyEventArgs e)
        {
            lblTotal.Text = SumTotal().ToString();
        }
    }
}
