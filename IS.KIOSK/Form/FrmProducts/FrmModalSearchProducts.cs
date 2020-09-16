using IS.KIOSK.Model;
using IS.Common.Reader;
using IS.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.KIOSK
{
    public partial class
        FrmModalSearchProducts : Form
    {
        IList<Products> _ProductList = new List<Products>();
        public string _ProductId {get;set;}
        public string _ProductName { get; set; }
        public FrmModalSearchProducts()
        {
            InitializeComponent();
            this.ActiveControl = txtSearch;
            //this.Shown += new System.EventHandler(this.FrmModalSearchProducts_Shown);
        }

        private void ProductSearch()
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                ProductsModel model = new ProductsModel();
                dgvProducts.AutoGenerateColumns = false;
                dgvProducts.DataSource = model.FindListActive(txtSearch.Text);
                dgvProducts.StandardTab = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            this.ProductSearch();

        }

        private void SetLoading(bool displayLoader)
        {
            this.Invoke((MethodInvoker)delegate
            {
                grpProduct.Enabled = !displayLoader;
                grpLoading.Visible = displayLoader;
                grpLoading.Refresh();
            });
        }

        private void FrmModalSearchProducts_Load(object sender, EventArgs e)
        {
            SetLoading(false);
        }

        //private void btnSelect_Click(object sender, EventArgs e)
        //{
        //    if (dgvProducts.Rows.Count > 0)
        //    {
        //        this._ProductId = dgvProducts.CurrentRow.Cells[0].Value?.ToString();
        //        this._ProductName = dgvProducts.CurrentRow.Cells[3].Value?.ToString();

        //        if (Convert.ToInt32(dgvProducts.CurrentRow.Cells[5].Value) <= 0)
        //        {
        //            this.DialogResult = DialogResult.Abort;

        //        }
        //        else
        //        {
        //            this.DialogResult = DialogResult.OK;
        //        }
        //    }
        //}

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == 13)
            {
                ProductSearch();
            }
            else if (e.KeyValue == 27)
            {
                btnClose_Click(sender, e);
            }
        }

        private void dgvProducts_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnSelect_Click(sender, e);
            }
            else if (e.KeyValue == 27)
            {
                btnClose_Click(sender, e);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvProducts.Rows.Count > 0)
            {
                this._ProductId = dgvProducts.CurrentRow.Cells[0].Value?.ToString();
                this._ProductName = dgvProducts.CurrentRow.Cells[3].Value?.ToString();
                this.DialogResult = DialogResult.OK;
                //if (Convert.ToInt32(dgvProducts.CurrentRow.Cells[5].Value) <= 0)
                //{
                //    this.DialogResult = DialogResult.Abort;

                //}
                //else
                //{
                //    this.DialogResult = DialogResult.OK;
                //}
            }
        }
    }
}
