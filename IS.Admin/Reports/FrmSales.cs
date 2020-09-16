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
    public partial class FrmSales : Form
    {
        Helper helper = new Helper();
        public int? _SearchCashierId { get; set; }
        public DateTime? _SearchDateFrom { get; set; }
        public DateTime? _SearchDateTo { get; set; }
        public IList<Sales> SaleList = new List<Sales>();
        public FrmSales()
        {
            InitializeComponent();
            this.ActiveControl = cboCashier;
        }

        private void FrmSales_Load(object sender, EventArgs e)
        {
            this.LoadCashier();
            lblDownloadPath.Text = helper.DownloadPath;
            //this._SearchCashierId = (int)cboCashier.SelectedValue;
            // this.LoadSales();
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
            var (sResponse,totalAmount) = sModel.SaleList(this._SearchCashierId,this._SearchDateFrom,this._SearchDateTo);
            dgvSales.AutoGenerateColumns = false;
            dgvSales.DataSource = sResponse;
            lblTotalAmount.Text = "Total Sales : " + String.Format("{0:n}", totalAmount);
            SaleList = sResponse;
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
                            var SalesList = new List<SalesCSV>();
                            foreach (var sale in this.SaleList)
                            {
                                var item = new SalesCSV();
                                item.CashierName = sale.CashierName;
                                item.ProductName = sale.ProductName;
                                item.Qty = sale.Qty.ToString("N2");
                                item.Amount = sale.AmountString;
                                SalesList.Add(item);
                            }
                            CSV model = new CSV();

                            var factory = new ISFactory();
                            var fullname = factory.AdministratorsRepository.FindAdministratorWithLoginname(Globals.LoginName).Fullname;
                            var filename = model.WriteSalesCSV(sfd.FileName,
                                SalesList,dtpFrom.Value, 
                                dtpTo.Value, 
                                fullname,
                                SaleList.Sum(x=>x.Amount).ToString("N2"),
                                SaleList.Sum(x => x.Qty).ToString("N0"));
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

        private void btnDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                lblDownloadPath.Text = folderBrowserDialog1.SelectedPath;
                helper.OverwriteValue("DownLoadPath", lblDownloadPath.Text);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Sales Report";
            printer.SubTitle = string.Format("Date : {0} - {1}", _SearchDateFrom.Value.ToString("MM/dd/yyyy"),_SearchDateTo.Value.ToString("MM/dd/yyyy"));
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total Collections: " + String.Format("{0:n}", SaleList.Sum(x => x.Amount))  + " Total Quantity: " + SaleList.Sum(x => x.Qty);
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(dgvSales);
            
        }
    }
}
