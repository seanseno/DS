using IS.Admin.Model;
using IS.Common.Helper.Extensions;
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

namespace IS.Admin.Transactions
{
    public partial class FrmOingingEditStockData : Form
    {
        private StocksData _StockData { get;set;}
        private Products _Product = new Products();
        ISFactory factory = new ISFactory();
        public FrmOingingEditStockData(StocksData StockData)
        {
            InitializeComponent();
            this._StockData = StockData;
        }

        private void FrmEditStockData_Load(object sender, EventArgs e)
        {
            StocksDataModel StocksData = new StocksDataModel();
            _StockData = StocksData.LoadEdit(_StockData.Id);

            txtProductId.Text = _StockData.ProductId;
            txtProductName.Text = _StockData.ProductName;
            txtQuantity.Text = _StockData.Quantity.ToString("N0");
            dtpDeliveryDate.Value = _StockData.DeliveryDate;
            dtpExpirationDate.Value = _StockData.ExpirationDate;
            txtRemarks.Text = _StockData.Remarks;

            CategoriesModel categoriesModel = new CategoriesModel();
            var categoryList = categoriesModel.CategoryListWithSelect();
            cboCategories.DataSource = categoryList;
            cboCategories.DisplayMember = "CategoryName";
            cboCategories.ValueMember = "CategoryId";

            PrincipalsModel principalsModel = new PrincipalsModel();
            var principalList = principalsModel.PrincipalListWithSelect();
            cboPrincipals.DataSource = principalList;
            cboPrincipals.DisplayMember = "PrincipalName";
            cboPrincipals.ValueMember = "PrincipalId";

            cboCategories.SelectedIndex = cboCategories.FindStringExact(_StockData.CategoryName);
            cboPrincipals.SelectedIndex = cboPrincipals.FindStringExact(_StockData.PrincipalName);

            //if (factory.StocksDataRepository.StocksDataStrategy.StockDataAlreadyInUse(_StockData.Id))
            //{
            //    cboPrincipals.Enabled = false;
            //    cboCategories.Enabled = false;
            //    txtQuantity.Enabled = false;
            //    dtpDeliveryDate.Enabled = false;
            //    dtpExpirationDate.Enabled = false;
            //    ActiveControl = txtRemarks;
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                if (MessageBox.Show("Are you sure do you want to save this record?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (Convert.ToInt32(txtQuantity.Text) > _StockData.Quantity )
                    {
                        var AddQty = Convert.ToInt32(txtQuantity.Text) - _StockData.Quantity ;
                        _StockData.RemainingQuantity = _StockData.RemainingQuantity + AddQty;
                    }
                    else if (Convert.ToInt32(txtQuantity.Text) < _StockData.Quantity)
                    {
                        var MinuQty =  _StockData.Quantity - Convert.ToInt32(txtQuantity.Text);
                        _StockData.RemainingQuantity = _StockData.RemainingQuantity - MinuQty;
                    }
                    _StockData.Quantity = Convert.ToInt32(txtQuantity.Text);
                    _StockData.DeliveryDate = dtpDeliveryDate.Value;
                    _StockData.ExpirationDate = dtpExpirationDate.Value;
                    _StockData.Remarks = txtRemarks.Text;
                    _StockData.PrincipalId = cboPrincipals.SelectedValue.ToString();
                    _StockData.CategoryId = cboCategories.SelectedValue.ToString();

                    var StocksDataModel = new StocksDataModel();
                    StocksDataModel.UpdateStockData(_StockData);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Quantity is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return true;
            }
            else if (Convert.ToInt32(txtQuantity.Text) <= 0)
            {
                MessageBox.Show("Invalid Quantity, Can not accept 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return true;
            }
            else if (Convert.ToDateTime(dtpExpirationDate.Value.ToShortDateString()) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
            {
                MessageBox.Show("Invalid Expiration date, date now is greather than expiration date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpExpirationDate.Focus();
                return true;
            }
            return false;
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtRealUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {
            ProductsModel modelProd = new ProductsModel();
            this._Product = modelProd.FindWithProductId(txtProductId.Text);
        }
    }
}
