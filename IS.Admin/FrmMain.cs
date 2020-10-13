using IIS.Admin.Transactions;
using IS.Admin.Model;
using IS.Admin.Reports;
using IS.Admin.Setup;
using IS.Admin.Transactions;
using IS.Admin.Utilities;
using IS.Common.Utilities;
using IS.Database;
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

namespace IS.Admin
{
    public partial class FrmMain : Form
    {
        ISFactory factory = new ISFactory();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            var response = frm.ShowDialog();
            if (response == DialogResult.OK)
            {
                timer1.Start();
                panel1.Visible = true;
                lblLogin.Text = "Current Login: " + Globals.LoginName;
                MenuEnable();
            }
        }

        private void MenuEnable()
        {
            if (Globals.LoginName == "ADMIN")
            {
                DisableAllMenu(true);
            }
            else
            {
                var admin = factory.AdministratorsRepository.FindAdministratorWithLoginname(Globals.LoginName);
                var MenuAccess = factory.MenuAccessRepository.GetListWithAdminId(admin.AdminId);

                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    if (MenuAccess.Where(x => x.MenuText == item.Text).Count() > 0)
                    {
                        item.Visible = true;
                    }
                    foreach (ToolStripMenuItem sub in item.DropDownItems)
                    {
                        if (MenuAccess.Where(x => x.MenuText == sub.Text).Count() > 0)
                        {
                            sub.Visible = true;
                        }
                        foreach (ToolStripItem sub1 in sub.DropDownItems)
                        {
                            if (MenuAccess.Where(x => x.MenuText == sub1.Text).Count() > 0)
                            {
                                sub1.Visible = true;
                            }
                        }

                    }

                }
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




        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy - dddd");
        }

        private void ongoingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void allStocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStocks frm = new FrmStocks();
            frm.ShowDialog();
        }

        private void ongoingStocksDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOngoingStocksData frm = new FrmOngoingStocksData();
            frm.ShowDialog();
        }

        private void verifyingStocksDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmValidateOngoingStocksData frm = new FrmValidateOngoingStocksData();
            frm.ShowDialog();

        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableAllMenu(false);
            panel1.Visible = false;
            FrmLogin frm = new FrmLogin();
            var response = frm.ShowDialog();
            if (response == DialogResult.OK)
            {
                timer1.Start();
                panel1.Visible = true;
                lblLogin.Text = "Current Login: " + Globals.LoginName;
                MenuEnable();
            }
        }
        private void DisableAllMenu(bool value)
        {
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                if (item != null)
                {
                    item.Visible = value;
                    try
                    {
                        foreach (ToolStripMenuItem sub in item.DropDownItems)
                        {
                            sub.Visible = value;
                            foreach (ToolStripItem sub1 in sub.DropDownItems)
                            {
                                sub1.Visible = value;
                            }

                        }
                    }
                    catch
                    {
                        item.Visible = value;
                    }
                }

            }

            ////MENU
            //menuToolStripMenuItem.Visible = value;
            //logOffToolStripMenuItem.Visible = value;
            //exitToolStripMenuItem.Visible = value;

            ////Transactions
            //transactionsToolStripMenuItem.Visible = value;
            //stocksToolStripMenuItem.Visible = value;
            //stocksDataToolStripMenuItem.Visible = value;
            //ongoingStocksDataToolStripMenuItem.Visible = value;
            //verifyingStocksDataToolStripMenuItem.Visible = value;
            //allStocksToolStripMenuItem.Visible = value;

            //productPriceHistoryToolStripMenuItem.Visible = value;

            ////setup
            //setupToolStripMenuItem.Visible = value;
            //categoriesToolStripMenuItem.Visible = value;
            //principalsToolStripMenuItem.Visible = value;
            //productsToolStripMenuItem.Visible = value;

            ////Utilities
            //utilitiesToolStripMenuItem.Visible = value;
            //administratorToolStripMenuItem.Visible = value;
            //cashiersToolStripMenuItem.Visible = value;

            ////reports
            //reportToolStripMenuItem.Visible = value;
            //salesToolStripMenuItem.Visible = value;

            //sockDataProfitToolStripMenuItem.Visible = value;
        }
        private void stocksDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStocksData frm = new FrmStocksData();
            frm.ShowDialog();
        }

        private void salesProfitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmSalesProfit frm = new FrmSalesProfit();
            //frm.ShowDialog();
        }

        private void accessMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMenuAccess frm = new FrmMenuAccess(this.menuStrip1);
            frm.ShowDialog();
        }


        private void totalSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSalesReport frm = new FrmSalesReport();
            frm.ShowDialog();
        }

        private void changeProductPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductPriceHistory frm = new FrmProductPriceHistory();
            frm.ShowDialog();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSalesReport frm = new FrmSalesReport();
            frm.ShowDialog();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStocksReport frm = new FrmStocksReport();
            frm.ShowDialog();
        }

        private void stockExpiredNearlyExpiredReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStockExpireReport frm = new FrmStockExpireReport();
            frm.ShowDialog();
        }

        private void discountedProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductsDiscounted frm = new FrmProductsDiscounted();
            frm.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReturnItemSettings frm = new FrmReturnItemSettings();
            frm.ShowDialog();
        }

        private void returnedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReturnItems frm = new FrmReturnItems();
            frm.Show();
        }
    }
}
