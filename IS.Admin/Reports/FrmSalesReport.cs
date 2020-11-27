using IS.Common.Utilities;
using IS.Database;
using IS.Database.CSV;
using IS.Database.Views;
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
    public partial class FrmSalesReport : BaseForm
    {
        ISFactory factory = new ISFactory();
        IList<SalesViewReport> _list = new List<SalesViewReport>();
        public FrmSalesReport()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            _list = factory.SalesRepository.GetSalesListReport().OrderBy(x => x.InsertTime).ToList();

            _list = _list.Where(x =>
                    DateTimeConvertion.ConvertDateFrom(dtpFrom.Value) <= x.InsertTime && x.InsertTime <= DateTimeConvertion.ConvertDateTo(dtpTo.Value) &&
                (x.CategoryName.Contains(txtSearch.Text.Trim().ToUpper()) ||
                x.ProductName.Contains(txtSearch.Text.Trim().ToUpper()) ||
                x.Fullname.Contains(txtSearch.Text.Trim().ToUpper()) ||
                x.CustomerName.Contains(txtSearch.Text.Trim().ToUpper()) )).ToList();

        AddedFoorter(_list.ToList(), dgvSales);
            
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
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
                            var SalesList = new List<SalesCSV>();
                            foreach (var sale in this._list)
                            {
                                var item = new SalesCSV();
                                item.Date = sale.InsertTime?.ToString("MM/dd/yyyy");
                                item.Time = sale.InsertTime?.ToString("hh:mm tt");
                                item.Fullname = sale.Fullname;
                                item.CustomerName = sale.CustomerName;
                                item.AdditionalInfo = sale.AdditionalInfo;
                                item.Date = sale.InsertTime?.ToString("MM/dd/yyyy");
                                item.Id = sale.Id?.ToString("N0");
                                item.Month = sale.InsertTime?.ToString("MMMM");
                                item.CategoryName = sale.CategoryName;
                                item.ProductName = sale.ProductName;
                                item.SoldQuantity = sale.SoldQuantity?.ToString("N0");
                                item.SellingPrice = sale.SellingPrice?.ToString("N2");
                                item.TotalAmount = sale.TotalAmount?.ToString("N2");
                                item.SupplierPrice = sale.SupplierPrice?.ToString("N2");
                                item.Profit = sale.Profit?.ToString("N2");
                                //item.Remarks = sale.Remarks;
                                SalesList.Add(item);
                            }

                            CSV model = new CSV();

                            var factory = new ISFactory();
                            var fullname = factory.AdministratorsRepository.FindAdministratorWithLoginname(Globals.LoginName).Fullname;
                            var filename = model.WriteSalesCSV(
                                sfd.FileName,
                                SalesList,
                                _list,
                                dtpFrom.Value,
                                dtpTo.Value,
                                fullname);
                            System.Diagnostics.Process.Start(filename);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSalesReport_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateConvertion.GetFistDay(DateTime.Now);
            dtpTo.Value = DateConvertion.GetLastDay(DateTime.Now);
            //_list = factory.SalesRepository.GetSalesListReport();

            //_list = _list.OrderByDescending(x => x.InsertTime).ToList();
            //AddedFoorter(_list.ToList(), dgvSales);

        }
        private void AddedFoorter(List<SalesViewReport> _list, DataGridView dgv)
        {
            List<SalesViewReport> response = new List<SalesViewReport>() ;
            response = _list.ToList();
            if (response.Count == 0)
            {
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = response;
                return;
            }
            response.Add(new SalesViewReport
            {
                ProductName = ""
            });

            dgv.AutoGenerateColumns = false;
            dgv.DataSource = response;

            dgv[8, dgvSales.Rows.Count - 1].Value = "TOTAL";
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[8].Style.Font = new Font("Arial", 16, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[8].Style.Alignment = DataGridViewContentAlignment.MiddleRight;


            dgv.Rows[dgvSales.Rows.Count - 1].Cells[9].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[9].Style.BackColor = Color.Green;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[9].Style.ForeColor = Color.White;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[9].Value = response.Sum(x => x.SoldQuantity);

            dgv.Rows[dgvSales.Rows.Count - 1].Cells[10].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[10].Style.BackColor = Color.Green;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[10].Style.ForeColor = Color.White;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[10].Value = response.Sum(x => x.SellingPrice);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[10].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            //var xx = response.Sum(x => x.TotalAmount)?.ToString("N2");

            dgv.Rows[dgvSales.Rows.Count - 1].Cells[11].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[11].Style.BackColor = Color.Green;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[11].Style.ForeColor = Color.White;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[11].Value = response.Sum(x => x.TotalAmount);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[11].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Rows[dgvSales.Rows.Count - 1].Cells[12].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[12].Style.BackColor = Color.Green;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[12].Style.ForeColor = Color.White;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[12].Value = response.Sum(x => x.SupplierPrice);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[12].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Rows[dgvSales.Rows.Count - 1].Cells[13].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[13].Style.BackColor = Color.Green;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[13].Style.ForeColor = Color.White;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[13].Value = response.Sum(x => x.Profit);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[13].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

    }
}
