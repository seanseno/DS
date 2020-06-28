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

namespace IS.Admin.Trasactions
{
    public partial class FrmReceivedItems : Form
    {
        public FrmReceivedItems()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddReceivedItem frm = new FrmAddReceivedItem();
            frm.ShowDialog();
            this.LoadItems();

        }

        private void FrmReceivedItems_Load(object sender, EventArgs e)
        {
            this.LoadItems();
            this.reloadCboRequestOrderList();
        }
        private void reloadCboRequestOrderList()
        {
            RequestOrderItemsModel RModel = new RequestOrderItemsModel();

            cboRequestOrderList.DataSource = null;

            var response1 = RModel.ItemList();
            var comboSource = new Dictionary<int, string>();
            comboSource.Add(0, "-Select-");
            foreach (var item in response1)
            {
                comboSource.Add(item.Id, item.RequestOrderName);
            }

            cboRequestOrderList.DataSource = new BindingSource(comboSource, null);
            cboRequestOrderList.DisplayMember = "Value";
            cboRequestOrderList.ValueMember = "Key";
        }
        private void LoadItems()
        {
            if(cboRequestOrderList.Items != null)
            {
                if(cboRequestOrderList.Items.Count > 0 )
                {
                    ReceivedOrdersModel model = new ReceivedOrdersModel();
                    int Id = ((KeyValuePair<int, string>)cboRequestOrderList.SelectedItem).Key;
                    var response = model.OrderReceivedList(txtSearch.Text.ToUpper(), Id);

                    dgvSearch.AutoGenerateColumns = false;
                    dgvSearch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgvSearch.DataSource = response;
                }

            }
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
            Item.Quantity = (int)dgvSearch.CurrentRow.Cells[6].Value;
            Item.DateReceived = (DateTime)dgvSearch.CurrentRow.Cells[7].Value;
            Item.DateManufactured = (DateTime)dgvSearch.CurrentRow.Cells[8].Value;
            Item.ExpirationDate = (DateTime)dgvSearch.CurrentRow.Cells[9].Value;
            Item.SupplierPrice = (decimal)dgvSearch.CurrentRow.Cells[10]?.Value;
            Item.SellingPricePerPiece = (decimal)dgvSearch.CurrentRow.Cells[11]?.Value;

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
            if (e.ColumnIndex == 12)
            {
                FrmEditReceivedItem frm = new FrmEditReceivedItem(Item.Id);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadItems();
                };
            }
            if (e.ColumnIndex == 13)
            {
                var model = new ReceivedOrdersModel();
                if (MessageBox.Show("Are you sure do want to delete " + string.Join(" ", Params) + ".", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    model.Delete(Item.Id);
                    this.LoadItems();
                    MessageBox.Show(Item.Description + " deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboRequestOrderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRequestOrderList.Items.Count > 1 && cboRequestOrderList.SelectedIndex != 0)
            {
                this.LoadItems();
            }
            else
            {
                dgvSearch.DataSource = null;
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
