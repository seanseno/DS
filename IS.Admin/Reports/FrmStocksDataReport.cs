using IS.Admin.Model;
using IS.Common.Helper.Extensions;
using IS.Database;
using IS.Database.CSV;
using IS.Database.Entities;
using IS.Database.Entities.Criteria;
using IS.Library.CSV;
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

namespace IS.Admin.Reports
{
    public partial class FrmStocksDataReport : Form
    {
        IList<StocksData> _list = new List<StocksData>();
        public FrmStocksDataReport()
        {
            InitializeComponent();
        }

        private void LoadStockData()
        {
           
            grpLoading.Visible = true;
            grpLoading.Refresh();

            StocksDataModel StocksData = new StocksDataModel();
            _list = StocksDataCriteria.MeetCriteria(StocksData.StockDataListReport().ToList(), dtpFrom.Value,dtpTo.Value, txtSearch.Text.ToUpper().Trim());

            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = _list;
            txtSearch.Focus();

            grpLoading.Visible = false;
            grpLoading.Refresh();

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
       
            lblTotalProfit.Text = _list.Sum(x => x.Profit).ToString("N2");
            lblTotalQty.Text = _list.Sum(x => x.Quantity).ToString("N0");
            lblTotalRemaining.Text = _list.Sum(x => x.RemainingQuantity).ToString("N0");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStockData();
            DisplayTotal();
        }

 
        private void dgvSearch_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Helper hp = new Helper();
            foreach (DataGridViewRow row in dgvSearch.Rows)
            {
                var days = DateConvertion.DaysBetween(Convert.ToDateTime(row.Cells[10].Value), DateTime.Now);

                var remaining = Convert.ToInt32(row.Cells[6].Value);

                if (remaining <= 0)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(174, 240, 170);
                }
                else if (days <= hp.ExpirationAlert)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(237, 114, 116);
                }
                
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (_list == null || _list.Count == 0)
            {
                MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Download this records?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var SalesList = new List<StocksDataReportCSV>();
                    foreach (var stockdata in this._list)
                    {

                        var item = new StocksDataReportCSV();
                        item.Overwrite(stockdata);

                        SalesList.Add(item);
                    }
                    CSV model = new CSV();
                    try
                    {
                        var filename = model.WriteStocksDataCSV(lblDownloadPath.Text, SalesList);
                        MessageBox.Show("Download Completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Process.Start(filename);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void btnDirectory_Click(object sender, EventArgs e)
        {

        }

        private void FrmStocksDataReport_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
        }
    }
}
