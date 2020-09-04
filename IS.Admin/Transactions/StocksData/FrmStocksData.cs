using IS.Admin.Model;
using IS.Database;
using IS.Database.Entities;
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

namespace IS.Admin.Transactions
{
    public partial class FrmStocksData : Form
    {
        IList<StocksData> _list = new List<StocksData>();
        public FrmStocksData()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddStockData frm = new FrmAddStockData();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.LoadStockData();
                DisplayTotal();

            }
        }

        private void LoadStockData()
        {
            grpLoading.Visible = true;
            grpLoading.Refresh();

            StocksDataModel StocksData = new StocksDataModel();
            _list = StocksData.FindWithRemainingQTY(txtSearch.Text);
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = _list;
            txtSearch.Focus();

            grpLoading.Visible = false;
            grpLoading.Refresh();
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var stockData = new StocksData
            {
                Id = Convert.ToInt32(dgvSearch.CurrentRow.Cells[0].Value.ToString())
            };


            if (e.ColumnIndex == 12)
            {
                FrmEditStockData frm = new FrmEditStockData(stockData);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.LoadStockData();
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

            }
            if (e.ColumnIndex == 13)
            {
                if (MessageBox.Show("Are you sure do you want to delete this record?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    StocksDataModel StocksData = new StocksDataModel();
                    StocksData.DeleteStockData(Convert.ToInt32(dgvSearch.CurrentRow.Cells[0].Value.ToString()));
                    this.LoadStockData();
                    DisplayTotal();
                    MessageBox.Show("Row deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }

            //var StockData = new StocksData
            //{
            //    StockDataId = dgvSearch.CurrentRow.Cells[0].Value.ToString(),
            //    StockDataName = dgvSearch.CurrentRow.Cells[1].Value.ToString(),
            //};

            //if (e.ColumnIndex == 2)
            //{
            //    FrmEditStockData frm = new FrmEditStockData(StockData);
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        this.LoadStockData();
            //    };

            //    //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
            //}
            //if (e.ColumnIndex == 3)
            //{
            //    var model = new StocksDataModel();
            //    if (model.CheckStockDataIfAlreadyInUse(StockData.StockDataId))
            //    {
            //        MessageBox.Show("You can not delete " + StockData  + " because this StockData already in use", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        if (MessageBox.Show("Are you sure do want to delete " + StockData.StockDataName + ".", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //        {

            //            model.DeleteStockData(StockData);
            //            this.LoadStockData();
            //            DisplayTotal();
            //            MessageBox.Show(StockData.StockDataName + " deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmStocksData_Shown(object sender, EventArgs e)
        {
            this.LoadStockData();
            DisplayTotal();
        }

        private void DisplayTotal()
        {
            string TotalStr = "Total Record 0";
            if (_list.Count() > 1)
            {
                TotalStr = "Total Record(s) " + _list.Count().ToString("N0");
            }
            else if (_list.Count() == 1)
            {
                TotalStr = "Total Record " + _list.Count().ToString("N0");
            }
            lblTotal.Text = TotalStr;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            FrmStocksDataUploadExcel frm = new FrmStocksDataUploadExcel();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.LoadStockData();
                DisplayTotal();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStockData();
        }

 
        private void dgvSearch_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Helper hp = new Helper();
            foreach (DataGridViewRow row in dgvSearch.Rows)
            {
                var days = DateConvertion.DaysBetween(Convert.ToDateTime(row.Cells[11].Value), DateTime.Now);

                if (days <= hp.ExpirationAlert)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(237, 114, 116);
                }
            }
        }
    }
}
