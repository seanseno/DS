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
    public partial class FrmItemRequestOrderList : Form
    {
        readonly RequestOrderItemsModel RModel = new RequestOrderItemsModel();
        IList<Items> OrderItemDetailList = new List<Items>();
        public decimal InputPrice { get; set; }
        public int InputQty { get; set; }

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
            dgvSearch.StandardTab = true;

            var response1 = RModel.ItemList();

            var comboSource = new Dictionary<int, string>();

            comboSource.Add(0,"-Select-");
            foreach (var item in response1)
            {
                comboSource.Add(item.Id, item.RequestOrderName);
            }

            cboRequestOrderList.DataSource = new BindingSource(comboSource, null);
            cboRequestOrderList.DisplayMember = "Value";
            cboRequestOrderList.ValueMember = "Key";

            txtSearch.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadItems();
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

        private void cboRequestOrderList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboRequestOrderList.Items.Count > 1 && cboRequestOrderList.SelectedIndex != 0)
            {
                int Id = ((KeyValuePair<int, string>)cboRequestOrderList.SelectedItem).Key;
                OrderItemDetailList = RModel.RequestOrderItemDetailsList(Id);

                //Items item = new Items();
                //item.CategoryName = "TEST";
                //item.CompanyName = "TEST";
                //item.GenericName = "TEST";
                //item.BrandName = "TEST";
                //item.Description = "TEST";
                //item.Price = 1;
                //item.Stock = 2;
                //OrderItemDetailList.Add(item);

                dgvDetails.AutoGenerateColumns = false;
                dgvDetails.DataSource = OrderItemDetailList;

                lblOrderInfo.Text = RModel.OrderInfo(Id);

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void dgvSearch_KeyUp(object sender, KeyEventArgs e)
        {
            ItemSelected(sender, e);
        }

        private void ItemSelected(object sender, KeyEventArgs e)
        {
            //CallKeyPress(sender, e);
            if (e.KeyValue == 27)
            {
                txtSearch.Focus();
            }
            if (e.KeyValue == 13)
            {
                int Id =(int)dgvSearch.CurrentRow.Cells[0].Value;
                frmMultiplier frm = new frmMultiplier(this, Id);
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    Items item = new Items();
                    item.CategoryName = dgvSearch.CurrentRow.Cells[1].Value?.ToString();
                    item.CompanyName = dgvSearch.CurrentRow.Cells[2].Value?.ToString();
                    item.GenericName = dgvSearch.CurrentRow.Cells[3].Value?.ToString();
                    item.BrandName = dgvSearch.CurrentRow.Cells[3].Value?.ToString();
                    item.Description = dgvSearch.CurrentRow.Cells[3].Value?.ToString();
                    item.Price = this.InputPrice;
                    item.Stock = this.InputQty;
                    OrderItemDetailList.Add(item);

                    dgvDetails.DataSource = null;

                    dgvDetails.DataSource = OrderItemDetailList;
                }
                else
                {

                }
            }
        }
    }
}
