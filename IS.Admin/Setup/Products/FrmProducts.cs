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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Admin.Setup
{
    public partial class FrmProducts : Form
    {
        public FrmProducts()
        {
            InitializeComponent();
            this.Shown += new System.EventHandler(this.FrmProducts_Shown);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddProduct frm = new FrmAddProduct();
            frm.ShowDialog();
            this.LoadProducts();

        }

        private void FrmProducts_Load(object sender, EventArgs e)
        {
          //  this.LoadProducts();
        }

        private void LoadProducts()
        {
            grpLoading.Visible = true;
            grpLoading.Refresh();

            ProductsModel model = new ProductsModel();
            var response = model.ItemList(txtSearch.Text);
            dgvSearch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = response;
            txtSearch.Focus();

            grpLoading.Visible = false;
            grpLoading.Refresh();
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Item = new Products();
            Item.ProductId = dgvSearch.CurrentRow.Cells[0].Value?.ToString();
            Item.CategoryName = dgvSearch.CurrentRow.Cells[1].Value?.ToString();
            Item.PrincipalName = dgvSearch.CurrentRow.Cells[2].Value?.ToString();
            Item.ProductName = dgvSearch.CurrentRow.Cells[3].Value?.ToString();
            Item.Price = Convert.ToDecimal(dgvSearch.CurrentRow.Cells[4].Value);
            Item.Stock = (int)dgvSearch.CurrentRow.Cells[5].Value;
            Item.BarCode= dgvSearch.CurrentRow.Cells[6].Value?.ToString();
            
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
                        this.LoadProducts();
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

            this.LoadProducts();

        }

        private void FrmProducts_Shown(object sender, EventArgs e)
        {
            this.LoadProducts();
        }


        //private void dgvSearch_CellClick_1(object sender, DataGridViewCellEventArgs e)
        //{
        //    var Item = new Items
        //    {
        //        Id = (int)dgvSearch.CurrentRow.Cells[0].Value,
        //        Name = dgvSearch.CurrentRow.Cells[1].Value.ToString(),
        //        Description = dgvSearch.CurrentRow.Cells[2].ToString(),
        //        Price = Convert.ToDecimal(dgvSearch.CurrentRow.Cells[3].ToString()),
        //        Stock = Convert.ToInt32( dgvSearch.CurrentRow.Cells[4].ToString())
        //    };

        //    if (e.ColumnIndex == 3)
        //    {

        //    }
        //    if (e.ColumnIndex == 6)
        //    {
        //        var model = new ProductsModel();
        //        if (model.CheckItemIfAlreadyInUse(Item.Id))
        //        {
        //            MessageBox.Show("You can not delete " + Item.Name + " because this brand already in use", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        else
        //        {
        //            if (MessageBox.Show("Are you sure do want to delete " + Item.Name + ".", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
        //            {

        //                //model.DeleteBrand(brand);
        //                //MessageBox.Show(brand.Name + " deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                //this.LoadBrand();
        //            }
        //        }
        //    }
        //}
    }
}
