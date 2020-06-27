using IS.Admin.Model;
using IS.Database.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode.Internal;

namespace IS.Admin.Trasactions
{
    public partial class FrmEditReceivedItem : Form
    {
        int Id {get;set;}
        public FrmEditReceivedItem(int ReceivedId)
        {
            InitializeComponent();
            this.Id = ReceivedId;
           
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
                decimal SellingPrice;
                if (Decimal.TryParse(txtSellingPrice.Text, out SellingPrice))
                {
                    if (SellingPrice <= 0)
                    {
                        MessageBox.Show("Invalid Selling Price Per Piece!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSellingPrice.Focus();
                        return;
                    }
                }

                ReceivedOrdersModel model = new ReceivedOrdersModel();
                ItemReceivedOrders itm = new ItemReceivedOrders();
                itm.Id = this.Id;
                itm.Quantity = Quantity;
                itm.DateReceived = DateReceived;
                itm.DateManufactured = DateManufactured;
                itm.ExpirationDate = ExpirationDate;
                itm.SupplierPrice = OrderPrice;
                itm.SellingPricePerPiece = SellingPrice;

                model.Update(itm);


                this.DialogResult = DialogResult.OK;
            }
            

        }

        private void FrmEditReceivedItem_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtQty;
            LoadItm();
        }

        private void LoadItm()
        {
            ItemsModel model = new ItemsModel();
            var response = model.LoadEdit(this.Id);
            if(response != null)
            {
                var Params = new List<string>();
                if (!string.IsNullOrEmpty(response.CategoryName))
                {
                    Params.Add(response.CategoryName);
                }
                if (!string.IsNullOrEmpty(response.CompanyName))
                {
                    Params.Add(response.CompanyName);
                }
                if (!string.IsNullOrEmpty(response.GenericName))
                {
                    Params.Add(response.GenericName);
                }
                if (!string.IsNullOrEmpty(response.BrandName))
                {
                    Params.Add(response.BrandName);
                }
                if (!string.IsNullOrEmpty(response.Description))
                {
                    Params.Add(response.Description);
                }
                rtbDescription.Text = string.Join(" ", Params);

                txtQty.Text = response.Quantity.ToString();
                dtpDateReceived.Value = response.DateReceived;
                dtpDateManufactured.Value = response.DateManufactured;
                dtpExpirationDate.Value = response.ExpirationDate;

                txtOrderPrice.Text = Math.Round(response.SupplierPrice, 2).ToString();
                txtSellingPrice.Text = Math.Round(response.SellingPricePerPiece).ToString();

            }
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
