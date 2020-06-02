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
    public partial class FrmItemRequestOrderList : Form
    {
        public FrmItemRequestOrderList()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void FrmItemRequestOrderList_Load(object sender, EventArgs e)
        {
            this.LoadItems();
        }

        private void LoadItems()
        {
            ItemsModel model = new ItemsModel();
            var response = model.ItemList(txtSearch.Text);
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
            //var Item = new Items();
            //Item.Id = (int)dgvSearch.CurrentRow.Cells[0].Value;
            //Item.CategoryName = dgvSearch.CurrentRow.Cells[1].Value?.ToString();
            //Item.CompanyName = dgvSearch.CurrentRow.Cells[2].Value?.ToString();
            //Item.GenericName = dgvSearch.CurrentRow.Cells[3].Value?.ToString();
            //Item.BrandName = dgvSearch.CurrentRow.Cells[4].Value?.ToString();
            //Item.Description = dgvSearch.CurrentRow.Cells[5].Value.ToString();
            //Item.Price = Convert.ToDecimal(dgvSearch.CurrentRow.Cells[6].Value);
            //Item.Stock = (int)dgvSearch.CurrentRow.Cells[7].Value;

            //var Params = new List<string>();
            //if (!string.IsNullOrEmpty(Item.CategoryName))
            //{
            //    Params.Add(Item.CategoryName);
            //}
            //if (!string.IsNullOrEmpty(Item.CompanyName))
            //{
            //    Params.Add(Item.CompanyName);
            //}
            //if (!string.IsNullOrEmpty(Item.GenericName))
            //{
            //    Params.Add(Item.GenericName);
            //}
            //if (!string.IsNullOrEmpty(Item.BrandName))
            //{
            //    Params.Add(Item.BrandName);
            //}
            //if (!string.IsNullOrEmpty(Item.Description))
            //{
            //    Params.Add(Item.Description);
            //}

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmItemRequestOrderList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 113)
            {
                this.DialogResult = DialogResult.OK;

            }
        }
    }
}
