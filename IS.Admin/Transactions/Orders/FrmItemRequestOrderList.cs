using IS.Admin.Model;
using IS.Admin.Printer;
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
        public string OdersName { get; set; }
        int? tempId = 8000;
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

            this.reloadCboRequestOrderList();
            txtSearch.Focus();
        }

        private void reloadCboRequestOrderList()
        {
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboRequestOrderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboRequestOrderList.SelectedItem != null)
            {
                if (cboRequestOrderList.Items.Count > 1 && cboRequestOrderList.SelectedIndex != 0)
                {
                    int Id = ((KeyValuePair<int, string>)cboRequestOrderList.SelectedItem).Key;
                    ReloadOrderItems(Id);

                }
                else
                {
                    btnPrint.Enabled = false;
                }
                if(cboRequestOrderList.SelectedIndex <= 0)
                {
                    dgvDetails.DataSource = null;
                    lblOrderInfo.Text = null;
                    btnPrint.Enabled = false;
                }
                else
                {
                    btnPrint.Enabled = true;
                }
                btnSave.Enabled = false;
            }
            else
            {
                btnPrint.Enabled = false;
            }
        }

        private void ReloadOrderItems(int Id)
        {
            OrderItemDetailList = RModel.RequestOrderItemDetailsList(Id);
            dgvDetails.DataSource = null;
            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.DataSource = OrderItemDetailList;
            lblOrderInfo.Text = RModel.OrderInfo(Id);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboRequestOrderList.SelectedIndex <= 0)
            {
                FrmInputRequestOrdersName frm = new FrmInputRequestOrdersName(this);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (MessageBox.Show("Are you sure do want to save this records?", "Information.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        RModel.Insert(OdersName, OrderItemDetailList);
                        reloadCboRequestOrderList();
                        dgvDetails.DataSource = null;
                        btnSave.Enabled = false;
                        MessageBox.Show("Orders save.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure do want to to update this records?", "Information.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    int Id = ((KeyValuePair<int, string>)cboRequestOrderList.SelectedItem).Key;
                    RModel.Update(Id, OrderItemDetailList);
                    btnSave.Enabled = false;
                    ReloadOrderItems(Id);
                    MessageBox.Show("Orders save.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnPrint.Enabled = true;
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
         
            int Id = (int)dgvSearch.CurrentRow.Cells[0].Value;
            string Desc = dgvSearch.CurrentRow.Cells[5].Value.ToString();

            if (OrderItemDetailList.Where(x => x.Description == Desc).Count() > 0)
            {
                MessageBox.Show("You selected a existing record!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmMultiplier frm = new frmMultiplier(this, Id);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    tempId++;
                    Items item = new Items();
                    item.Id = (int)tempId;
                    item.CategoryName = dgvSearch.CurrentRow.Cells[1].Value?.ToString();
                    item.CompanyName = dgvSearch.CurrentRow.Cells[2].Value?.ToString();
                    item.GenericName = dgvSearch.CurrentRow.Cells[3].Value?.ToString();
                    item.BrandName = dgvSearch.CurrentRow.Cells[4].Value?.ToString();
                    item.Description = dgvSearch.CurrentRow.Cells[5].Value?.ToString();
                    item.Price = this.InputPrice;
                    item.Stock = this.InputQty;
                 
                    item.TempItemId = Convert.ToInt32(dgvSearch.CurrentRow.Cells[0].Value);
                    OrderItemDetailList.Add(item);

                    dgvDetails.DataSource = null;

                    dgvDetails.AutoGenerateColumns = false;
                    dgvDetails.DataSource = OrderItemDetailList;
                    btnSave.Enabled = true;
                    btnPrint.Enabled = false;
                }
                else
                {

                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cboRequestOrderList.SelectedIndex > 0)
            {
                dgvPrint.DataSource = null;
                dgvPrint.AutoGenerateColumns = false;
                dgvPrint.DataSource = OrderItemDetailList;

                int Id = ((KeyValuePair<int, string>)cboRequestOrderList.SelectedItem).Key;

                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Request Orders";
                printer.SubTitle = RModel.OrderDate(Id);
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = true;
                printer.PrintDataGridView(dgvPrint);
            }
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9) //Delete
            {
                int Id = (int)dgvDetails.CurrentRow.Cells[0].Value;
                int ItemId = (int)dgvDetails.CurrentRow.Cells[11].Value;

                decimal Price = Math.Round((decimal)dgvDetails.CurrentRow.Cells[6].Value,2);
                int Qty = (int)dgvDetails.CurrentRow.Cells[7].Value;
                if (MessageBox.Show("Edit this record?", "Information.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    frmMultiplier frm = new frmMultiplier(this, ItemId,Qty, Price);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        foreach(var itm in OrderItemDetailList)
                        {
                            if(itm.Id == Id)
                            {
                                itm.Stock = this.InputQty;
                                itm.Price = this.InputPrice;
                            }
                        }
                       
                        dgvDetails.DataSource = null;
                        dgvDetails.AutoGenerateColumns = false;
                        dgvDetails.DataSource = OrderItemDetailList;
                        btnSave.Enabled = true;
                        btnPrint.Enabled = false;
                    }
                }
            }
            if (e.ColumnIndex == 10) //Delete
            {
                int Id = (int)dgvDetails.CurrentRow.Cells[0].Value;
                if (MessageBox.Show("Remove this record?", "Information.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var itm = OrderItemDetailList.Where(x => x.Id == Id).FirstOrDefault();
                    OrderItemDetailList.Remove(itm);

                    dgvDetails.DataSource = null;
                    dgvDetails.AutoGenerateColumns = false;
                    dgvDetails.DataSource = OrderItemDetailList;
                    btnSave.Enabled = true;
                }
            }
        }
    }
}
