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
    public partial class FrmStockExpireReport : Form
    {
        ISFactory factory = new ISFactory();
        IList<StocksDataExpireViewReport> _list = new List<StocksDataExpireViewReport>();
        public FrmStockExpireReport()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            _list = factory.StocksDataRepository.GetListStocksDataExpireReport().OrderByDescending(x => x.ExpirationDate).ToList();
            var days = factory.SettingsRepository.GetList()[0].ExpirationAlert;
            DateTime date = DateTimeConvertion.ConvertDateTo(DateTime.Now.AddDays(days));
            _list = _list.Where(x => x.ExpirationDate <= date).ToList();
            _list = _list.Where(x => x.CategoryName.Contains(txtSearch.Text.Trim().ToUpper()) ||
                        x.PrincipalName.Contains(txtSearch.Text.Trim().ToUpper()) ||
                        x.ProductName.Contains(txtSearch.Text.Trim().ToUpper())).ToList();
            AddedFoorter(_list.ToList(), dgvSales);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                            var SalesList = new List<ExpiredNearlyCSV>();
                            foreach (var sale in this._list)
                            {
                                var item = new ExpiredNearlyCSV();
                                item.PrincipalName = sale.PrincipalName;
                                item.ProductName = sale.ProductName;
                                item.CategoryName = sale.CategoryName;
                                item.RemainingQuantity = sale.RemainingQuantity.ToString("N0");
                                item.RemainingAmount = sale.RemainingAmount.ToString("N2");
                                item.DeliveryDate = sale.DeliveryDate.ToShortDateString();
                                item.ExpirationDate = sale.ExpirationDate.ToShortDateString();
                                item.Remarks = sale.Remarks;
                                SalesList.Add(item);
                            }

                            CSV model = new CSV();

                            var factory = new ISFactory();
                            var fullname = factory.AdministratorsRepository.FindAdministratorWithLoginname(Globals.LoginName).Fullname;
                            var filename = model.WriteExpiredNearlyCSV(
                                sfd.FileName,
                                SalesList,
                                _list,
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

        private void FrmStockExpireReport_Load(object sender, EventArgs e)
        {
            var response = factory.StocksDataRepository.GetListStocksDataExpireReport().OrderByDescending(x => x.ExpirationDate).ToList() ;
            _list = response;
            AddedFoorter(_list.ToList(), dgvSales);
        }

        private void AddedFoorter(List<StocksDataExpireViewReport> _list, DataGridView dgv)
        {
            List<StocksDataExpireViewReport> response = new List<StocksDataExpireViewReport>();
            response = _list;
            if (response.Count == 0)
            {
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = response;
                return;
            }
            response.Add(new StocksDataExpireViewReport
            {
                ProductName = ""
            });

            dgv.AutoGenerateColumns = false;
            dgv.DataSource = response;

            dgv[2, dgvSales.Rows.Count - 1].Value = "TOTAL";
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[2].Style.Font = new Font("Arial", 16, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleRight;


            dgv.Rows[dgvSales.Rows.Count - 1].Cells[3].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[3].Style.BackColor = Color.Green;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[3].Style.ForeColor = Color.White;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[3].Value = response.Sum(x => x.RemainingQuantity);

            dgv.Rows[dgvSales.Rows.Count - 1].Cells[4].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[4].Style.BackColor = Color.Green;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[4].Style.ForeColor = Color.White;
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[4].Value = response.Sum(x => x.RemainingAmount);
            dgv.Rows[dgvSales.Rows.Count - 1].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
}
