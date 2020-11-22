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
    public partial class FrmStocksDataReport : BaseForm
    {
        ISFactory factory = new ISFactory();
        IList<StocksDataViewReport> _list = new List<StocksDataViewReport>();
        public FrmStocksDataReport()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            _list = factory.StocksDataRepository.GetListStocksDataReport().OrderBy(x => x.DeliveryDate).ToList();

            _list = _list.Where(x => DateTimeConvertion.ConvertDateFrom(dtpFrom.Value) <= x.DeliveryDate && x.DeliveryDate <= DateTimeConvertion.ConvertDateTo(dtpTo.Value)).ToList();

            _list = _list.Where(x => x.CategoryName.Contains(txtSearch.Text.Trim().ToUpper()) ||
                x.ProductName.Contains(txtSearch.Text.Trim().ToUpper())).ToList();

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
                                item.SellingPrice = sale.SellingPrice.ToString("N2");
                                //item.UnitPriceWithAddedFormula = sale.UnitPriceWithAddedFormula.ToString("N2");
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

        private void FrmStocksReport_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateConvertion.GetFistDay(DateTime.Now);
            dtpTo.Value = DateConvertion.GetLastDay(DateTime.Now);
            //_list = factory.StocksDataRepository.GetListStocksDataReport().OrderBy(x=>x.DeliveryDate).ToList();
            //AddedFoorter(_list.ToList(), dgvSales);
        }
        private void AddedFoorter(List<StocksDataViewReport> _list, DataGridView dgv)
        {
            List<StocksDataViewReport> response = new List<StocksDataViewReport>();
            response = _list;
            if (response.Count == 0)
            {
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = response;
                return;
            }
            response.Add(new StocksDataViewReport
            {
                ProductName = ""
            });

            dgv.AutoGenerateColumns = false;
            dgv.DataSource = response;

            dgv[3, dgvSales.Rows.Count - 1].Value = "TOTAL";
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[3].Style.Font = new Font("Arial", 16, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleRight;


            dgv.Rows[dgvSales.Rows.Count - 1].Cells[4].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[4].Style.BackColor = Color.Green;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[4].Style.ForeColor = Color.White;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[4].Value = response.Sum(x => x.Quantity);

            dgv.Rows[dgvSales.Rows.Count - 1].Cells[5].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[5].Style.BackColor = Color.Green;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[5].Style.ForeColor = Color.White;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[5].Value = response.Sum(x => x.SupplierPrice);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[5].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Rows[dgvSales.Rows.Count - 1].Cells[6].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[6].Style.BackColor = Color.Green;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[6].Style.ForeColor = Color.White;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[6].Value = response.Sum(x => x.TotalAmount); ;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[6].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Rows[dgvSales.Rows.Count - 1].Cells[7].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[7].Style.BackColor = Color.Green;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[7].Style.ForeColor = Color.White;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[7].Value = response.Sum(x => x.SellingPrice);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[7].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Rows[dgvSales.Rows.Count - 1].Cells[8].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[8].Style.BackColor = Color.Green;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[8].Style.ForeColor = Color.White;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[8].Value = response.Sum(x => x.UnitSold);

            dgv.Rows[dgvSales.Rows.Count - 1].Cells[9].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[9].Style.BackColor = Color.Green;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[9].Style.ForeColor = Color.White;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[9].Value = response.Sum(x => x.RemainingQuantity);

            dgv.Rows[dgvSales.Rows.Count - 1].Cells[10].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[10].Style.BackColor = Color.Green;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[10].Style.ForeColor = Color.White;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[10].Value = response.Sum(x => x.RemainingAmount);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[10].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

        }
    }
}
