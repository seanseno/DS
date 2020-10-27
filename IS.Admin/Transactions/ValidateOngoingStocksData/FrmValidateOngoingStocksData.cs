using IS.Admin;
using IS.Admin.Model;
using IS.Admin.Transactions;
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

            StocksDataModel StocksData = new StocksDataModel();
            var response = StocksData.FindWithRemainingQTY(txtSearch.Text);
            _list = response.Where(x => x.SupplierPrice <= 0).ToList();
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = _list;
            txtSearch.Focus();

            grpLoading.Visible = false;
            grpLoading.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddStockData frm = new FrmAddStockData();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.LoadStockData();
                DisplayTotal();

            }
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
