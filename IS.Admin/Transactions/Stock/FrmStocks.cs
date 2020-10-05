using IS.Admin.Model;
using IS.Database;
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

namespace IS.Admin.Transactions
{
    public partial class FrmStocks : Form
    {
        ISFactory factory = new ISFactory();

        public FrmStocks()
        {
            InitializeComponent();
        }

        private void LoadStocks()
        {
            grpLoading.Visible = true;
            grpLoading.Refresh();

            var response = factory.StocksRepository.Find(txtSearch.Text);
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = response;
            txtSearch.Focus();

            grpLoading.Visible = false;
            grpLoading.Refresh();
            if (response == null)
            {
                lblTotalStocks.Text = "Total Stock(s): 0";
            }
            else
            {
                lblTotalStocks.Text = "Total Stock(s): " + response.Sum(x => x.Stock)?.ToString("N0");
            }
            
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

        private void FrmStocks_Load(object sender, EventArgs e)
        {

        }
    }
}
