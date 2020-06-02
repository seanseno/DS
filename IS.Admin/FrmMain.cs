using IS.Admin.Setup;
using IS.Admin.Setup.Cashier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Admin
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmItems frm = new FrmItems();
            frm.ShowDialog();
        }
        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSales frm = new FrmSales();
            frm.ShowDialog();
        }

        private void companiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompanies frm = new FrmCompanies();
            frm.ShowDialog();
        }

        private void stocksToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmStocks frm = new FrmStocks();
            frm.ShowDialog();
        }

        private void logOfffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            var response = frm.ShowDialog();
            if (response == DialogResult.OK)
            {

            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            var response = frm.ShowDialog();
            if (response == DialogResult.OK)
            {
                
            }
        }

        private void administratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdministrators frm = new FrmAdministrators();
            var response = frm.ShowDialog();
            if (response == DialogResult.OK)
            {

            }
        }

        private void addUpdateCashierInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCashiers frm = new FrmCashiers();
            frm.ShowDialog();
        }

        private void cashOnHandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCashierOnhand frm = new FrmCashierOnhand();
            frm.ShowDialog();
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories();
            frm.ShowDialog();
        }
    }
}
