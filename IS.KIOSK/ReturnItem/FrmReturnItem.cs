using IS.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.KIOSK
{
    public partial class FrmReturnItem : BaseForm
    {
        ISFactory factory = new ISFactory();
        public FrmReturnItem()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void FrmReturnItem_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var response = factory.ProductsRepository.GetListSoldProduct().OrderByDescending(x => x.InsertTime).ToList();
            var date = new DateTime();
            date = Convert.ToDateTime(DateTime.Now.AddDays(-factory.SettingsRepository.GetList().FirstOrDefault().ReturnItem).ToShortDateString());
            response = response.Where(x => x.InsertTime >= date).ToList();

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                response = response.Where(x => x.ProductName.Contains(txtSearch.Text.ToUpper()) ||
                    x.Fullname.Contains(txtSearch.Text.ToUpper()) ||
                    x.CustomerName.Contains(txtSearch.Text.ToUpper()) ||
                    x.TransactionNo.Contains(txtSearch.Text.ToUpper())).ToList();
            }

            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = response;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        //private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == 0) //sellect
        //    {
        //        var StockDataId = Convert.ToInt32(dgvSearch.CurrentRow.Cells[7].Value.ToString());
        //        var Qty = Convert.ToInt32(dgvSearch.CurrentRow.Cells[5].Value.ToString());
        //        if (Qty > 0)
        //        {
        //            var SalesId = Convert.ToInt32(dgvSearch.CurrentRow.Cells[8].Value.ToString());
        //            var ProductName = dgvSearch.CurrentRow.Cells[3].Value.ToString();
        //            FrmReturnItemUpdate frm = new FrmReturnItemUpdate(StockDataId, SalesId, ProductName);
        //            if (frm.ShowDialog() == DialogResult.OK)
        //            {
        //                LoadData();
        //                MessageBox.Show("Settings updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            };
        //        }
        //        else
        //        {
        //            MessageBox.Show("Not enough quanity", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        private void dgvSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) 
            {
                btnSelect_Click(sender, e);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void FrmReturnItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27) // Exit
            {
                this.btnClose_Click(sender, e);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var StockDataId = Convert.ToInt32(dgvSearch.CurrentRow.Cells[7].Value.ToString());
            var Qty = Convert.ToInt32(dgvSearch.CurrentRow.Cells[5].Value.ToString());
            if (Qty > 0)
            {
                var SalesId = Convert.ToInt32(dgvSearch.CurrentRow.Cells[8].Value.ToString());
                var ProductName = dgvSearch.CurrentRow.Cells[3].Value.ToString();
                FrmReturnItemUpdate frm = new FrmReturnItemUpdate(StockDataId, SalesId, ProductName);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    MessageBox.Show("Item returned.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
            }
            else
            {
                MessageBox.Show("Not enough quanity", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
