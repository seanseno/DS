﻿using IS.Admin.Model;
using IS.Common.Helper.Extensions;
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
    public partial class FrmEditStockData : Form
    {
        private StocksData _StockData { get;set;}
        public FrmEditStockData(StocksData StockData)
        {
            InitializeComponent();
            this._StockData = StockData;
        }

        private void FrmEditStockData_Load(object sender, EventArgs e)
        {
            StocksDataModel StocksData = new StocksDataModel();
            var response = StocksData.LoadEdit(_StockData.Id);

            txtProductId.Text = response.ProductId;
            txtProductName.Text = response.ProductName;
            txtQuantity.Text = response.Quantity.ToString("N0");
            txtSupplierPrice.Text = Math.Round(response.SupplierPrice, 2).ToString("N2");
            txtTotalAmount.Text = Math.Round(response.TotalAmount, 2).ToString("N2");
            txtRealUnitPrice.Text = Math.Round(response.RealUnitPrice, 2).ToString("N2");

            dtpDeliveryDate.Value = response.DeliveryDate;
            dtpExpirationDate.Value = response.ExpirationDate;
            txtDuration.Text = response.Duration.ToString("N0");
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
                    StocksData StocksData = new StocksData();

                    StocksData.Id = _StockData.Id;
                    StocksData.Quantity = Convert.ToInt32(txtQuantity.Text);
                    StocksData.SupplierPrice = Convert.ToDecimal(txtSupplierPrice.Text);
                    StocksData.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                    StocksData.RealUnitPrice = Convert.ToDecimal(txtRealUnitPrice.Text);
                    StocksData.DeliveryDate = dtpDeliveryDate.Value;
                    StocksData.ExpirationDate = dtpExpirationDate.Value;
                    StocksData.Duration = Convert.ToInt32(txtDuration.Text);

                    var StocksDataModel = new StocksDataModel();
                    StocksDataModel.UpdateStockData(StocksData);
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
            else if (string.IsNullOrEmpty(txtSupplierPrice.Text))
            {
                MessageBox.Show("Supplier Price is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSupplierPrice.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(txtRealUnitPrice.Text))
            {
                MessageBox.Show("Real Unit Price is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRealUnitPrice.Focus();
                return true;
            }
            else if (Convert.ToInt32(txtDuration.Text) <= 0)
            {
                MessageBox.Show("Invalid Duration, Can not accept 0 or less than 0!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            GetTotalAmount();
        }

        private void txtSupplierPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtSupplierPrice_TextChanged(object sender, EventArgs e)
        {
            GetTotalAmount();
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

        private void GetTotalAmount()
        {
            if (!string.IsNullOrEmpty(txtSupplierPrice.Text) && !string.IsNullOrEmpty(txtQuantity.Text))
            {
                txtTotalAmount.Text = Math.Round(Convert.ToInt32(txtQuantity.Text) * Convert.ToDecimal(txtSupplierPrice.Text), 2).ToString("N0");
            }
        }

        private void dtpExpirationDate_ValueChanged(object sender, EventArgs e)
        {
            txtDuration.Text = String.Format("{0,10:N0}", (dtpExpirationDate.Value - DateTime.Now).TotalDays);
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    //StocksDataModel StocksData = new StocksDataModel();
        //    //_StockData.StockDataName = txtStockDataName.Text;
        //    //if (StocksData.CheckEditDup(_StockData.StockDataName, _StockData.Id))
        //    //{
        //    //    MessageBox.Show(_StockData.StockDataName + " already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //    txtStockDataName.Focus();
        //    //}
        //    //else
        //    //{
        //    //    StocksData.UpdateStockData(_StockData);
        //    //    this.DialogResult = DialogResult.OK;
        //    //}
        //}
    }
}
