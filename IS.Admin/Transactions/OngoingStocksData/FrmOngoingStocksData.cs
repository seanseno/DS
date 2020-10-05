using IS.Admin.Model;
using IS.Database;
using IS.Database.Entities;
using IS.Database.Entities.Criteria;
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

namespace IS.Admin.Transactions
{
    public partial class FrmOngoingStocksData : Form
    {
        IList<StocksData> _list = new List<StocksData>();
        ISFactory factory = new ISFactory();
        //Criteria criteria = new Criteria();
        public FrmOngoingStocksData()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmOngoingAddStockData frm = new FrmOngoingAddStockData();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.LoadStockData();
                DisplayTotal();

            }
        }

        private void LoadStockData()
        {
            grpLoading.Visible = true;
            grpLoading.Refresh();


            var response = factory.StocksDataRepository.GetList();
            _list = response.Where(
                    x => x.SupplierPrice <= 0 &&
                    (
                        x.CategoryName.Contains(txtSearch.Text.ToUpper()) ||
                        x.PrincipalName.Contains(txtSearch.Text.ToUpper()) ||
                        x.ProductName.Contains(txtSearch.Text.ToUpper())
                    )
                ).ToList();
            //_list = criteria.StocksDataCriteria.

            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = _list;
            txtSearch.Focus();

            grpLoading.Visible = false;
            grpLoading.Refresh();
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var stockData = new StocksData
            {
                Id = Convert.ToInt32(dgvSearch.CurrentRow.Cells[1].Value.ToString())
            };

            if (e.ColumnIndex == 0)
            {
                FrmOngoingStocksDataHistory frm = new FrmOngoingStocksDataHistory(stockData.Id);
                frm.Show();
            }

            if (e.ColumnIndex == 11)
            {
                FrmOingingEditStockData frm = new FrmOingingEditStockData(stockData);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.LoadStockData();
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
            }
            if (e.ColumnIndex == 12)
            {
            
                StocksDataModel StocksData = new StocksDataModel();
                if (StocksData.CheckStockDataIfAlreadyInUse(stockData.Id))
                {
                    MessageBox.Show("This data already in used", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure do you want to delete this record?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        StocksData.DeleteStockData(stockData.Id);
                        this.LoadStockData();
                        DisplayTotal();
                        MessageBox.Show("Row deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmStocksData_Shown(object sender, EventArgs e)
        {
            this.LoadStockData();
            DisplayTotal();
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



        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStockData();
        }

 
        private void dgvSearch_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Helper hp = new Helper();
            foreach (DataGridViewRow row in dgvSearch.Rows)
            {
                var days = DateConvertion.DaysBetween(Convert.ToDateTime(row.Cells[8].Value), DateTime.Now);

                if (days <= hp.ExpirationAlert)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(237, 114, 116);
                }
            }
        }


    }
}
