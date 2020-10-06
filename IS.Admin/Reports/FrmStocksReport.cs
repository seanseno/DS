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
    public partial class FrmStocksReport : Form
    {
        ISFactory factory = new ISFactory();
        IList<StocksDataViewReport> _list = new List<StocksDataViewReport>();
        public FrmStocksReport()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var response = factory.StocksDataRepository.GetListStocksDataReport();

            response = response.Where(x => DateTimeConvertion.ConvertDateFrom(dtpFrom.Value) <= x.DeliveryDate && x.DeliveryDate <= DateTimeConvertion.ConvertDateTo(dtpTo.Value)).ToList();

            response = response.Where(x => x.CategoryName.Contains(txtSearch.Text.Trim().ToUpper()) ||
                x.ProductName.Contains(txtSearch.Text.Trim().ToUpper())).ToList();

            _list = response;
            dgvSales.AutoGenerateColumns = false;
            dgvSales.DataSource = _list;
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
                            var SalesList = new List<StocksCSV>();
                            foreach (var sale in this._list)
                            {
                                var item = new StocksCSV();
                                item.PrincipalName = sale.PrincipalName;
                                item.ProductName = sale.ProductName;
                                item.CategoryName = sale.CategoryName;
                                item.Quantity = sale.Quantity.ToString("N0");
                                item.SupplierPrice = sale.SupplierPrice.ToString("N2");
                                item.TotalAmount = sale.TotalAmount.ToString("N2");
                                item.UnitPriceWithAddedFormula = sale.UnitPriceWithAddedFormula.ToString("N2");
                                item.UnitSold = sale.UnitSold.ToString("N0");
                                item.RemainingQuantity = sale.RemainingQuantity.ToString("N0");
                                item.RemainingAmount = sale.RemainingAmount.ToString("N2");
                                item.Remarks = sale.Remarks;
                                SalesList.Add(item);
                            }

                            CSV model = new CSV();

                            var factory = new ISFactory();
                            var fullname = factory.AdministratorsRepository.FindAdministratorWithLoginname(Globals.LoginName).Fullname;
                            var filename = model.WriteStocksCSV(
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
