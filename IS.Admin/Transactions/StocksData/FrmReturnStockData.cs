using IS.Admin.Model;
using IS.Common.Helper.Extensions;
using IS.Common.Utilities;
using IS.Database;
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

namespace IS.Admin.Transactions
{
    public partial class FrmReturnStockData : BaseForm
    {
        private StocksData _StockData { get;set;}
        private Products _Product = new Products();
        ISFactory factoy = new ISFactory();
        public FrmReturnStockData(StocksData StockData)
        {
            InitializeComponent();
            this._StockData = StockData;
            this.ActiveControl = txtReturnQty;
        }

        private void FrmEditStockData_Load(object sender, EventArgs e)
        {
            StocksDataModel StocksData = new StocksDataModel();
            _StockData = StocksData.LoadEdit(_StockData.Id);
            lblPrincipal.Text = _StockData.PrincipalName;
            lblCategory.Text = _StockData.CategoryName;
            lblProductId.Text = _StockData.ProductId;
            lblProductName.Text = _StockData.ProductName;
            lblQty.Text = _StockData.Quantity.ToString("N0");
            lblSupplier.Text = _StockData.SupplierPrice.ToString("N2");
            lblTotalAmount.Text = _StockData.TotalAmount.ToString("N2");
            lblRemainingQty.Text = _StockData.RemainingQuantity.ToString("N0");
            lblDeliveryDate.Text = _StockData.DeliveryDate.ToString();
            lblExpirationDate.Text = _StockData.ExpirationDate.ToString();
            lblRemarks.Text = _StockData.Remarks;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                if (MessageBox.Show("Are you sure do you want to return this product?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var returnStockData = new ReturnStocksData();
                    returnStockData.StockDataId = _StockData.Id;
                    returnStockData.ReturnQty = Convert.ToInt32(txtReturnQty.Text);
                    returnStockData.Remarks = txtReason.Text.ToUpper();
                    returnStockData.LoginName = Globals.LoginName;
                    factoy.ReturnStocksDataRepository.Insert(returnStockData);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtReturnQty.Text))
            {
                MessageBox.Show("Return Quantity is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReturnQty.Focus();
                return true;
            }
            else if (Convert.ToInt32(txtReturnQty.Text) <= 0)
            {
                MessageBox.Show("Zero Quantity is not allowed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReturnQty.Focus();
                return true;
            }
            else if (Convert.ToInt32(txtReturnQty.Text) > _StockData.RemainingQuantity)
            {
                MessageBox.Show("Invalid Quantity, Not enough stock!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReturnQty.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(txtReason.Text))
            {
                MessageBox.Show("Reason is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReason.Focus();
                return true;
            }

            return false;
        }

        private void txtReturnQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
