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


        private void FrmStocks_Load(object sender, EventArgs e)
        {
            this.LoadStocks();
        }

        private void LoadStocks()
        {
            StocksModel stocks = new StocksModel();
            var response = stocks.StockList(txtSearch.Text);
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = response;
            txtSearch.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadStocks();
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //var item = new Items();
            //item.Id = (int)dgvSearch.CurrentRow.Cells[0].Value;
            //item.GenericName = dgvSearch.CurrentRow.Cells[1].Value?.ToString();
            //item.BrandName = dgvSearch.CurrentRow.Cells[2].Value?.ToString();
            //item.Description = dgvSearch.CurrentRow.Cells[3].Value?.ToString();
            //item.Stock = (int)dgvSearch.CurrentRow.Cells[4].Value;

            //if (e.ColumnIndex == 5) //add
            //{
            //    FrmEditStock frm = new FrmEditStock(item, EnumStock.Credit);
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        this.LoadStocks();
            //    };
            //}
            //if (e.ColumnIndex == 6) //Subract
            //{
            //    FrmEditStock frm = new FrmEditStock(item, EnumStock.Debit);
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        this.LoadStocks();
            //    };
            //}

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
