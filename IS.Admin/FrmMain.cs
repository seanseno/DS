using IS.Admin.Setup;
using IS.Admin.Setup.Cashier;
using IS.Admin.Trasactions;
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

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSales frm = new FrmSales();
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

        private void cashiersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCashiers frm = new FrmCashiers();
            frm.ShowDialog();
        }

        private void stocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStocks frm = new FrmStocks();
            frm.ShowDialog();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProducts frm = new FrmProducts();
            frm.ShowDialog();
        }

        private void principalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPrincipals frm = new FrmPrincipals();
            frm.ShowDialog();
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories();
            frm.ShowDialog();
        }
    }
}
