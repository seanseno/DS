using IS.Admin.Model;
using IS.Database.Entities;
using IS.Database.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Admin.Setup
{
    public partial class FrmStocks : Form
    {
        public FrmStocks()
        {
            InitializeComponent();
        }

        private void LoadStocks()
        {
            grpLoading.Visible = true;
            grpLoading.Refresh();

            StocksModel stocks = new StocksModel();
            var response = stocks.StockList(txtSearch.Text);
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = response;
            txtSearch.Focus();

            grpLoading.Visible = false;
            grpLoading.Refresh();


        }


        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var ProductId = dgvSearch.CurrentRow.Cells[0].Value?.ToString();
            if (e.ColumnIndex == 4) //add
            {
                FrmEditStock frm = new FrmEditStock(ProductId, EnumStock.Credit);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.LoadStocks();
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
            }
            if (e.ColumnIndex == 5) //Subract
            {
                FrmEditStock frm = new FrmEditStock(ProductId, EnumStock.Debit);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadStocks();
                };
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmStocks_Shown(object sender, EventArgs e)
        {
            this.LoadStocks();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadStocks();
        }
    }
}
