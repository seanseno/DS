using IS.Admin.Model;
using IS.Database.Entities;
using IS.Database.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Admin.Setup
{
    public partial class FrmEditStock : Form
    {
        private Items _Item { get;set;}
        private EnumStock _EnumStock { get; set; }
        private int? CurrentStock { get; set; }
        public FrmEditStock(Items item, EnumStock enumstock)
        {
            InitializeComponent();
            this._Item = item;
            this._EnumStock = enumstock;
        }

        private void FrmEditStock_Load(object sender, EventArgs e)
        {
            StocksModel stocks = new StocksModel();
            var response = stocks.LoadEdit(_Item.Id);
            //lblName.Text = response.Name;
            lblDescription.Text = response.Description;
            
            CurrentStock = response.Stock;
            lblCurrentStock.Text = CurrentStock.ToString();
            lblNewStock.Text = CurrentStock.ToString();

            txtStock.Text = "0";

            if(this._EnumStock == EnumStock.Credit)
            {
                Color color = Color.FromArgb(128, 255, 255);
                txtStock.BackColor = color;
                lblStock.Text = "Credit stock :";
                
            }
            else
            {
                Color color = Color.FromArgb(255, 192, 192);
                txtStock.BackColor = color;
                lblStock.Text = "Debit stock :";
            }
     

            this.ActiveControl = txtStock;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var newStock = Convert.ToInt32(lblNewStock.Text);
            if(newStock < 0 )
            {
                MessageBox.Show("Invalid Stock.", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStock.Focus();
            }
            else
            {
                StocksModel stocks = new StocksModel();
                stocks.UpdateStock(this._Item, Convert.ToInt32(txtStock.Text), _EnumStock);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtStock_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty((txtStock.Text)))
            {
                if(int.TryParse(txtStock.Text,out int stock))
                {
                    if (_EnumStock == EnumStock.Credit)
                    {
                        lblNewStock.Text = Convert.ToString(CurrentStock + stock);
                    }
                    else
                    {
                        lblNewStock.Text = Convert.ToString(CurrentStock - stock);
                    }
                }
                else
                {
                    lblNewStock.Text = lblCurrentStock.Text;
                }
            }
            else
            {
                lblNewStock.Text = lblCurrentStock.Text;
            }
        }
    }
}
