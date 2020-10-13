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
