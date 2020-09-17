using IS.Admin.Model;
using IS.Admin.Printer;
using IS.Admin.Properties;
using IS.Common.Utilities;
using IS.Database;
using IS.Database.CSV;
using IS.Database.Entities;
using IS.Library.CSV;
using IS.Library.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Admin.Setup
{
    public partial class FrmSalesProfit : Form
    {
        Helper helper = new Helper();
        public int? _SearchCashierId { get; set; }
        public DateTime? _SearchDateFrom { get; set; }
        public DateTime? _SearchDateTo { get; set; }
        public IList<SalesProfit> SaleList = new List<SalesProfit>();
        ISFactory factory = new ISFactory();

        public FrmSalesProfit()
        {
            InitializeComponent();
            this.ActiveControl = cboCashier;
        }

        private void FrmSales_Load(object sender, EventArgs e)
        {
            this.LoadCashier();
        }

        private void LoadCashier()
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
            SalesModel model = new SalesModel();
            var response = model.CashierList(null);
            
            cboCashier.DataSource = response;
            cboCashier.DisplayMember = "Fullname";
            cboCashier.ValueMember = "Id";

            this._SearchDateFrom = DateConvertion.ConvertDateFromTime(dtpFrom.Value);
            this._SearchDateTo = DateConvertion.ConvertDateToTime(dtpTo.Value);
            LoadSales();
        }
        private void LoadSales()
        {
            SalesModel sModel = new SalesModel();

            var response = factory.SalesRepository.FindSalesProfit(this._SearchCashierId, this._SearchDateFrom, this._SearchDateTo);

            dgvSales.AutoGenerateColumns = false;
            dgvSales.DataSource = response;

            lblTotalAmount.Text = "Total Sales : 0.00";
            lblTotalProfit.Text = "Total Profit : .00";
            if (response != null)
            {
                lblTotalAmount.Text = "Total Sales : " + String.Format("{0:n}", response.Sum(x => x.TotalSales));
                lblTotalProfit.Text = "Total Profit : " + String.Format("{0:n}", response.Sum(x => x.Profit));
            }
           
           

            SaleList = response;
        }

        private void LoadSearchValue()
        {
            if (cboCashier.SelectedValue != null)
            {
                try
                {
                    this._SearchCashierId = (int)cboCashier.SelectedValue;
                }
                catch (Exception ex)
                {

                }
            }
            this._SearchDateFrom = DateConvertion.ConvertDateFromTime(dtpFrom.Value);
            this._SearchDateTo = DateConvertion.ConvertDateToTime(dtpTo.Value);
            this.LoadSales();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaleList == null || SaleList.Count == 0)
                {
                    MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            var SalesList = new List<SalesProfitCSV>();
                            foreach (var sale in this.SaleList)
                            {
                                var item = new SalesProfitCSV();
                                item.Fullname = sale.Fullname;
                                item.PrincipalName = sale.PrincipalName;
                                item.CategoryName = sale.CategoryName;
                                item.ProductId = sale.ProductId;
                                item.ProductName = sale.ProductName;
                                item.SoldQuantity = sale.SoldQuantity.ToString("N0");
                                item.SupplierPrice = sale.SupplierPrice.ToString("N2");
                                item.TotalAmount = sale.TotalAmount.ToString("N2");
                                item.TotalSales = sale.TotalSales.ToString("N2");
                                item.Profit = sale.Profit.ToString("N2");
                                item.InsertTime = sale.InsertTime.ToString();
                                SalesList.Add(item);
                            }
                            CSV model = new CSV();

                            var factory = new ISFactory();
                            var fullname = factory.AdministratorsRepository.FindAdministratorWithLoginname(Globals.LoginName).Fullname;
                            var filename = model.WriteSalesProfitCSV(
                                sfd.FileName,
                                SalesList,
                                dtpFrom.Value,
                                dtpTo.Value,
                                fullname,
                                SaleList.Sum(x => x.TotalSales).ToString("N2"),
                                SaleList.Sum(x => x.Profit).ToString("N2"));
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

        private void cboCashier_TextChanged(object sender, EventArgs e)
        {
            LoadSearchValue();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadSearchValue();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadSearchValue();
        }
    }
}
