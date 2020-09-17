using IS.Admin.Model;
using IS.Common.Helper.Extensions;
using IS.Common.Utilities;
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
                var days = DateConvertion.DaysBetween(Convert.ToDateTime(row.Cells[13].Value), DateTime.Now);

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
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        var SalesList = new List<StocksDataReportCSV>();
                        foreach (var i in this._list)
                        {
                            var item = new StocksDataReportCSV();
                            item.PrincipalName = i.PrincipalName;
                            item.ProductName = i.ProductName;
                            item.CategoryName = i.CategoryName;
                            item.Quantity = i.Quantity.ToString("N0");
                            item.SupplierPrice = i.SupplierPrice.ToString("N2");
                            item.TotalAmount = i.TotalAmount.ToString("N0");
                            item.RemainingQuanity = i.RemainingQuantity.ToString("N0");
                            item.UnitSold = i.UnitSold.ToString("N0");
                            item.ProductSellingPrice = i.ProductSellingPrice.ToString("N2");
                            item.TotalSales = i.TotalSales.ToString("N2");
                            item.Profit = i.Profit.ToString("N2");
                            item.DeliveryDate = i.DeliveryDate.ToString();
                            item.ExpirationDate = i.ExpirationDate.ToShortDateString();
                            item.Remarks = i.Remarks;
                            SalesList.Add(item);
                        }
                        CSV model = new CSV();
                        try
                        {
                            var factory = new ISFactory();
                            var fullname = factory.AdministratorsRepository.FindAdministratorWithLoginname(Globals.LoginName).Fullname;
                            var filename = model.WriteStocksDataCSV(
                                sfd.FileName,
                                SalesList,
                                dtpFrom.Value,
                                dtpTo.Value,
                                fullname,
                                _list.Sum(x => x.RemainingQuantity).ToString("N0"),
                                _list.Sum(x => x.TotalSales).ToString("N2"),
                                _list.Sum(x => x.Profit).ToString("N2")
                                ); 
                            System.Diagnostics.Process.Start(filename);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        private void FrmStocksDataReport_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
        }
    }
}
