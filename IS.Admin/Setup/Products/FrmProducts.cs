using IS.Admin.Model;
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

namespace IS.Admin.Setup
{
    public partial class FrmProducts : Form
    {
        IList<Products> _ProductList = new List<Products>();
        public FrmProducts()
        {
            InitializeComponent();
            //this.Shown += new System.EventHandler(this.FrmProducts_Shown);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddProduct frm = new FrmAddProduct();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.LoadProducts();
            }
            
        }

        private void ProductSearch()
        {
            LoadMemoryProducts();
        }
        private void LoadProducts()
        {
            SetLoading(true);
            Thread.Sleep(1);
            ProductsModel model = new ProductsModel();
            this._ProductList = model.ItemList(txtSearch.Text);
            Thread.Sleep(1);
            SetLoading(false);
        }

        private void LoadMemoryProducts()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = this._ProductList.Where(x => x.CategoryName.Contains(txtSearch.Text.ToUpper()) || x.ProductName.Contains(txtSearch.Text.ToUpper())).OrderBy(v=>v.ProductName).ToList();
            dgvProducts.StandardTab = true;
        }

        private void DeleteMemoryProducts(string ProductId)
        {
            SetLoading(true);
            var prod = this._ProductList.FirstOrDefault(x=>x.ProductId == ProductId);
            _ProductList.Remove(prod);
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = this._ProductList.Where(x => x.CategoryName.Contains(txtSearch.Text.ToUpper()) || x.ProductName.Contains(txtSearch.Text.ToUpper())).ToList();
            dgvProducts.StandardTab = true;

            SetLoading(false);
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Item = new Products();
            Item.ProductId = dgvProducts.CurrentRow.Cells[0].Value?.ToString();
            Item.CategoryName = dgvProducts.CurrentRow.Cells[1].Value?.ToString();
            Item.PrincipalName = dgvProducts.CurrentRow.Cells[2].Value?.ToString();
            Item.ProductName = dgvProducts.CurrentRow.Cells[3].Value?.ToString();
            Item.Price = Convert.ToDecimal(dgvProducts.CurrentRow.Cells[4].Value);
            Item.Stock = (int)dgvProducts.CurrentRow.Cells[5].Value;
            Item.BarCode= dgvProducts.CurrentRow.Cells[6].Value?.ToString();
            
            if (e.ColumnIndex == 8)
            {
                FrmEditProduct frm = new FrmEditProduct(Item);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadProducts();
                };
            }
            if (e.ColumnIndex == 9)
            {
                var model = new ProductsModel();
                if (model.CheckItemIfAlreadyInUse(Item.ProductId))
                {
                    MessageBox.Show("You can not delete " + Item.ProductName + " because this item is already used!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure do want to delete " + Item.ProductName + ".", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        model.DeleteItem(Item);
                        this.DeleteMemoryProducts(Item.ProductId);
                        MessageBox.Show(Item.ProductName + " deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadMemoryProducts();
        }

        private void grpProduct_EnabledChanged(object sender, EventArgs e)
        {
            LoadMemoryProducts();
        }

        private void FrmProducts_Load(object sender, EventArgs e)
        {
            try
            {
                Thread threadInput = new Thread(LoadProducts);
                threadInput.Start();
                var xx = "x";
            }
            catch (Exception ex)
            {


            }
        }
    }
}
