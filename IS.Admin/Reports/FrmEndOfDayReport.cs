using IS.Common.Utilities;
using IS.Database;
using IS.Database.CSV;
using IS.Database.Views;
using IS.Library.CSV;
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
    public partial class FrmEndOfDayReport : BaseForm
    {
        ISFactory factory = new ISFactory();
        IList<EndOfDayReportView> _list = new List<EndOfDayReportView>();
        public FrmEndOfDayReport()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            _list = factory.SalesRepository.GetSalesDetailListReport().OrderBy(x => x.InsertTime).ToList();

            _list = _list.Where(x =>
                    DateTimeConvertion.ConvertDateFrom(dtpFrom.Value) <= x.InsertTime && x.InsertTime <= DateTimeConvertion.ConvertDateTo(dtpTo.Value) &&
                (x.Id.ToString() == txtSearch.Text ||
                x.CategoryName.ToUpper().ToUpper().Contains(txtSearch.Text.Trim().ToUpper()) ||
                x.ProductId.ToUpper().Contains(txtSearch.Text.Trim().ToUpper()) ||
                x.ProductName.ToUpper().Contains(txtSearch.Text.Trim().ToUpper()) ||
                x.Fullname.ToUpper().Contains(txtSearch.Text.Trim().ToUpper()) ||
                x.AdditionalInfo.ToUpper().Contains(txtSearch.Text.Trim().ToUpper()) ||
                x.CustomerName.ToUpper().Contains(txtSearch.Text.Trim().ToUpper()))).ToList();

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
                            var SalesList = new List<SalesDetailCSV>();
                            foreach (var sale in this._list)
                            {
                                var item = new SalesDetailCSV();

                                item.Id = sale.Id?.ToString("N0");
                                item.Fullname = sale.Fullname;
                                item.CustomerName = sale.CustomerName;
                                item.CategoryName = sale.CategoryName;
                                item.AdditionalInfo = sale.AdditionalInfo;
                                item.ProductId = sale.ProductId;
                                item.ProductName = sale.ProductName;
                                item.Qty = sale.Qty?.ToString("N0");
                                item.Price = sale.Price?.ToString("N2");
                                item.TotalPrice = sale.TotalPrice?.ToString("N2");
                                item.InsertTime = sale.InsertTime?.ToString("MM/dd/yyyy hh:mm");
                                SalesList.Add(item);
                            }

                            CSV model = new CSV();

                            var factory = new ISFactory();
                            var fullname = factory.AdministratorsRepository.FindAdministratorWithLoginname(Globals.LoginName).Fullname;
                            var filename = model.WriteSalesDetailCSV(
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

        private void AddedFoorter(List<EndOfDayReportView> _list, DataGridView dgv)
        {
            List<EndOfDayReportView> response = new List<EndOfDayReportView>() ;
            response = _list.ToList();
            if (response.Count == 0)
            {
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = response;
                return;
            }
            response.Add(new EndOfDayReportView
            {
                ProductName = ""
            });

            dgv.AutoGenerateColumns = false;
            dgv.DataSource = response;

            dgv[6, dgvSales.Rows.Count - 1].Value = "TOTAL";
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[6].Style.Font = new Font("Arial", 16, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[6].Style.Alignment = DataGridViewContentAlignment.MiddleRight;


            dgv.Rows[dgvSales.Rows.Count - 1].Cells[7].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[7].Style.BackColor = Color.Green;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[7].Style.ForeColor = Color.White;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[7].Value = response.Sum(x => x.Qty);

            dgv.Rows[dgvSales.Rows.Count - 1].Cells[8].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[8].Style.BackColor = Color.Green;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[8].Style.ForeColor = Color.White;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[8].Value = response.Sum(x => x.Price);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[8].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Rows[dgvSales.Rows.Count - 1].Cells[9].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[9].Style.BackColor = Color.Green;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[9].Style.ForeColor = Color.White;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[9].Value = response.Sum(x => x.TotalPrice);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[9].Style.Alignment = DataGridViewContentAlignment.MiddleRight;


        }

        private void FrmEndOfDayReport_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
            //_list = factory.SalesRepository.GetSalesDetailListReport();

            //_list = _list.OrderByDescending(x => x.InsertTime).ToList();
            //AddedFoorter(_list.ToList(), dgvSales);
        }
    }
}
