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

namespace IS.KIOSK
{
    public partial class frmMultiplier : Form
    {
        ISFactory factory = new ISFactory();
        Products product = new Products();
        FrmMain _FrmMain = new FrmMain();
        public int? Qty { get; set; }
        private string _ProductId { get; set; }
        int CountErrorlabel = 0;
        public frmMultiplier(FrmMain model, string ProductId)
        {
            InitializeComponent();
            this._ProductId = ProductId;
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
            this.product = factory.ProductsRepository.FindWithProductId(_ProductId);
            var itemName = new List<string>();
            if (!string.IsNullOrEmpty(this.product.CategoryName))
            {
                itemName.Add(this.product.CategoryName);
            }
            if (!string.IsNullOrEmpty(this.product.ProductName))
            {
                itemName.Add(this.product.ProductName);
            }

            richTextBox1.Text = string.Join(" ", itemName);
            lblTotal.Text = Math.Round((this.product.Price * Convert.ToDecimal(txtQty.Text)), 2).ToString();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((txtQty.Text)))
            {
                lblTotal.Text = String.Format("{0:N}", Math.Round((this.product.Price * Convert.ToDecimal(txtQty.Text)), 2));
            }
            else
            {
                lblTotal.Text = "0.00";
            }
            lblError.Visible = false;
        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 13) // Enter
            {
                if (!string.IsNullOrEmpty((txtQty.Text)))
                {
                    if (int.TryParse(txtQty.Text, out int Qty))
                    {
                        if (Qty == 0)
                        {
                            lblError.Text = "Invalid Quantity Input.";
                            timer1.Start();
                            txtQty.Focus();
                        }
                        else
                        {
                            if (!factory.StocksRepository.StocksStrategy.CheckStock(this.product.ProductId, Qty))
                            {
                                lblError.Text = "Not enough stock.";
                                timer1.Start();
                                txtQty.Text = Qty.ToString();
                                txtQty.Focus();
                            }
                            else
                            {
                                factory.TempSalesRepository.Insert(product.ProductId, Qty, (int)_FrmMain._TempLedgerSales.Id);
                                // _frmKiosk.AddTempOrder();
                                this.Qty = Qty;
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                    }
                }
                else
                {
                    lblError.Text = "Invalid Quantity Input.";
                    timer1.Start();
                    txtQty.Focus();
                }

            }
            else if (e.KeyValue == 27)  //escape
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
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
    }
}
