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
    public partial class FrmSalesReport : Form
    {
        ISFactory factory = new ISFactory();
        IList<SalesViewReport> _list = new List<SalesViewReport>();
        public FrmSalesReport()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var response = factory.SalesRepository.GetSalesListReport();
            //response = response.Where(x => DateTimeConvertion.ConvertDateFrom(dtpFrom.Value) <= x.InsertTime && x.InsertTime <= DateTimeConvertion.ConvertDateTo(dtpTo.Value)).ToList();
            if (response != null)
            {
                response = response.Where(x =>
                     DateTimeConvertion.ConvertDateFrom(dtpFrom.Value) <= x.InsertTime && x.InsertTime <= DateTimeConvertion.ConvertDateTo(dtpTo.Value) &&
                    (x.CategoryName.Contains(txtSearch.Text.Trim().ToUpper()) ||
                    x.ProductName.Contains(txtSearch.Text.Trim().ToUpper()) ||
                    x.Fullname.Contains(txtSearch.Text.Trim().ToUpper()))).ToList();

                _list = response;
                dgvSales.AutoGenerateColumns = false;
                dgvSales.DataSource = _list;
            }
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
                                item.Date = sale.InsertTime.ToString("MM/dd/yyyy");
                                item.Time = sale.InsertTime.ToString("hh:mm tt");
                                item.Fullname = sale.Fullname;
                                item.Date = sale.InsertTime.ToString("MM/dd/yyyy");
                                item.Id = sale.Id.ToString("N0");
                                item.Month = sale.InsertTime.ToString("MMMM");
                                item.CategoryName = sale.CategoryName;
                                item.ProductName = sale.ProductName;
                                item.SoldQuantity = sale.SoldQuantity.ToString("N0");
                                item.SellingPrice = sale.SellingPrice.ToString("N2");
                                item.TotalAmount = sale.TotalAmount.ToString("N2");
                                item.SupplierPrice = sale.SupplierPrice.ToString("N2");
                                item.Profit = sale.Profit.ToString("N2");
                                item.Remarks = sale.Remarks;
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
    }
}
