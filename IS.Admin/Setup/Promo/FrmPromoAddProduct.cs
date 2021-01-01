using IS.Common.Utilities;
using IS.Database;
using IS.Database.Entities;
using IS.Database.Enums;
using IS.Database.Views;
using IS.Library.Utility;
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
    public partial class FrmPromoAddProduct : BaseForm
    {
        ISFactory factory = new ISFactory();
        IList<TempPromoDetails> _list = new List<TempPromoDetails>();
        public FrmPromoAddProduct()
        {
            InitializeComponent();
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
            this.ActiveControl = txtPromoName;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = _list.ToList();
            lblTotal.Text = "Total Record(s): " + _list.Count.ToString("N0");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            FrmModalSearchProducts frm = new FrmModalSearchProducts();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtProductId.Text = frm._ProductId;
                txtProductName.Text = frm._ProductName;
                txtPrice.Text = frm._Price.ToString("N2");
                txtPrice.Focus();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckInputAdd())
            {
                var obj = new TempPromoDetails();
                obj.ProductId = txtProductId.Text;
                obj.Price = Convert.ToDecimal(txtPrice.Text);
                _list.Add(obj);
                loadData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                factory.TempPromoDetailsRepository.Delete();
                foreach (var item in _list)
                {
                    factory.TempPromoDetailsRepository.Insert(item);
                }

                Promo promo = new Promo();
                promo.PromoName = txtPromoName.Text;
                promo.DateFrom = dtpFrom.Value.Date;
                promo.DateTo = dtpTo.Value.Date;
                factory.PromoRepository.Insert(promo);
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool CheckInputAdd()
        {
            if (CheckDup())
            {
                return true;
            }
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Product is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSearchProduct.Focus();
                return true;
            }

            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Price is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return true;
            }

            else if (Convert.ToDecimal(txtPrice.Text) <= 0)
            {
                MessageBox.Show("Invalid price, Can not accept 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return true;
            }

            return false;
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtPromoName.Text))
            {
                MessageBox.Show("Promo Name is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPromoName.Focus();
                return true;
            }
            else if (factory.PromoRepository.GetList().Where(x=>x.PromoName.ToUpper()==txtPromoName.Text.ToUpper()).Count() > 0)
            {
                MessageBox.Show("Promo name already exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPromoName.Focus();
                return true;
            }
            else if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("Invalid Promo Start From!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFrom.Focus();
                return true;
            }
            else if (_list.Count < 0)
            {
                MessageBox.Show("Please add at least 1 product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAdd.Focus();
                return true;
            }
            return false;
        }

        private bool CheckDup()
        {
            if (_list.Where(x=>x.ProductId == txtProductId.Text).Count() > 0)
            {
                MessageBox.Show("Product already exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSearchProduct.Focus();
                return true;
            }
            return false;
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string ProductId = dgvProducts.CurrentRow.Cells[0].Value.ToString();
            if (e.ColumnIndex == 3)
            {
                if (MessageBox.Show("Are you sure do want to remove?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _list.Remove(_list.Where(x => x.ProductId == ProductId).FirstOrDefault());
                    loadData();
                }
            }
        }

        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                e.Value = factory.ProductsRepository.GetList().Where(x => x.ProductId == e.Value.ToString()).FirstOrDefault().ProductName;
               
            }
        }
    }
}
