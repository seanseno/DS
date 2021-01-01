using IS.Admin;
using IS.Admin.Model;
using IS.Admin.Transactions;
using IS.Database;
using IS.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IIS.Admin.Transactions
{
    public partial class FrmValidateOngoingStocksData : BaseForm
    {
        IList<StocksData> _list = new List<StocksData>();
        ISFactory factory = new ISFactory();
        public FrmValidateOngoingStocksData()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStockData();
        }
        private void LoadStockData()
        {
            grpLoading.Visible = true;
            grpLoading.Refresh();

            var response = factory.StocksDataRepository.GetList().ToList();
            response = response
                        .Where(x => x.ProductName.Contains(txtSearch.Text) ||
                            x.ProductId.Contains(txtSearch.Text) ||
                            x.CategoryName.Contains(txtSearch.Text) ||
                            x.ProductName.Contains(txtSearch.Text)).ToList();

             _list = response.Where(x => x.SupplierPrice <= 0).ToList();
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = _list;
            txtSearch.Focus();

            grpLoading.Visible = false;
            grpLoading.Refresh();
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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var stockData = new StocksData
            {
                Id = Convert.ToInt32(dgvSearch.CurrentRow.Cells[0].Value.ToString())
            };


            if (e.ColumnIndex == 12)
            {
                FrmValidateOngoingEditStockData frm = new FrmValidateOngoingEditStockData(stockData);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.LoadStockData();
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

            }
        }

        private void FrmValidateOngoingStocksData_Load(object sender, EventArgs e)
        {
            this.LoadStockData();
            DisplayTotal();
        }
    }
}
