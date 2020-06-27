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
    public partial class FrmItems : Form
    {
        public FrmItems()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddItem frm = new FrmAddItem();
            frm.ShowDialog();
            this.LoadItems();

        }

        private void FrmItems_Load(object sender, EventArgs e)
        {
            this.LoadItems();
        }

        private void LoadItems()
        {
            ItemsModel model = new ItemsModel();
            var response = model.ItemList(txtSearch.Text);
            dgvSearch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = response;
            txtSearch.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Item = new Items();
            Item.Id = (int)dgvSearch.CurrentRow.Cells[0].Value;
            Item.CategoryName = dgvSearch.CurrentRow.Cells[1].Value?.ToString();
            Item.CompanyName = dgvSearch.CurrentRow.Cells[2].Value?.ToString();
            Item.GenericName = dgvSearch.CurrentRow.Cells[3].Value?.ToString();
            Item.BrandName = dgvSearch.CurrentRow.Cells[4].Value?.ToString();
            Item.Description = dgvSearch.CurrentRow.Cells[5].Value.ToString();
            Item.Price = Convert.ToDecimal(dgvSearch.CurrentRow.Cells[6].Value);
            Item.Stock = (int)dgvSearch.CurrentRow.Cells[7].Value;

            Item.ItemReceivedOrdersId = (int)dgvSearch.CurrentRow.Cells[12].Value;

            var Params = new List<string>();
            if (!string.IsNullOrEmpty(Item.CategoryName))
            {
                Params.Add(Item.CategoryName);
            }
            if (!string.IsNullOrEmpty(Item.CompanyName))
            {
                Params.Add(Item.CompanyName);
            }
            if (!string.IsNullOrEmpty(Item.GenericName))
            {
                Params.Add(Item.GenericName);
            }
            if (!string.IsNullOrEmpty(Item.BrandName))
            {
                Params.Add(Item.BrandName);
            }
            if (!string.IsNullOrEmpty(Item.Description))
            {
                Params.Add(Item.Description);
            }
            if (e.ColumnIndex == 10)
            {
                FrmEditItem frm = new FrmEditItem(Item);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadItems();
                };
            }
            if (e.ColumnIndex == 11)
            {
                var model = new ItemsModel();
                if (model.CheckItemIfAlreadyInUse(Item.Id))
                {
                    MessageBox.Show("You can not delete " + string.Join(" ", Params) + " because this item is already used!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure do want to delete " + string.Join(" ", Params) + ".", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        model.DeleteItem(Item);
                        this.LoadItems();
                        MessageBox.Show(Item.Description + " deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            FrmUploadExcel frm = new FrmUploadExcel();
            var response = frm.ShowDialog();
            if(response == DialogResult.OK)
            {
                this.LoadItems();
            }
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
        //        var model = new ItemsModel();
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
