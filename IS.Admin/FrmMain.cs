using IIS.Admin.Transactions;
using IS.Admin.Model;
using IS.Admin.Reports;
using IS.Admin.Setup;
using IS.Admin.Transactions;
using IS.Admin.Utilities;
using IS.Common.Utilities;
using IS.Database;
using IS.Database.Enums;
using IS.Library.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            LoadWallPaper(ThemesUtility.WallPaper());
    
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
            if (Globals.LoginName.ToUpper() == "ADMIN")
            {
                DisableAllMenu(true);
            }
            else
            {
                var admin = factory.AdministratorsRepository.FindAdministratorWithLoginname(Globals.LoginName);
                var MenuAccess = factory.MenuAccessRepository.GetListWithAdminId(admin.AdminId);

                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    if (MenuAccess.Where(x => x.MenuName == item.Name).Count() > 0)
                    {
                        item.Visible = true;
                    }
                    foreach (ToolStripItem sub in item.DropDownItems)
                    {
                        if (MenuAccess.Where(x => x.MenuName == sub.Name).Count() > 0)
                        {
                            sub.Visible = true;
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


        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOff();
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
                        foreach (ToolStripItem sub in item.DropDownItems)
                        {
                            sub.Visible = value;
                            //foreach (ToolStripItem sub1 in sub.DropDownItems)
                            //{
                            //    sub1.Visible = value;
                            //}

                        }
                    }
                    catch
                    {
                        item.Visible = value;
                    }
                }

            }
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

        private void questionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQuestions frm = new FrmQuestions();
            frm.ShowDialog();
        }

        private void returnedStocksToSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReturnItemsToSupplier frm = new FrmReturnItemsToSupplier();
            frm.ShowDialog();
        }

        private void stocksDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStocksData frm = new FrmStocksData();
            frm.ShowDialog();
        }

        private void ongoingStocksDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOngoingStocksData frm = new FrmOngoingStocksData();
            frm.ShowDialog();
        }

        private void validateOngoingStocksDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmValidateOngoingStocksData frm = new FrmValidateOngoingStocksData();
            frm.ShowDialog();
        }

        private void allStocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStocks frm = new FrmStocks();
            frm.ShowDialog();
        }

        private void themesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmThemes frm = new FrmThemes(this);
            frm.ShowDialog();
        }

        public void LoadWallPaper(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                if (File.Exists(filePath))
                {
                    this.BackgroundImage = Image.FromFile(filePath);
                }
            }
        }

        public void LogOff()
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

        private void endOfDayReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEndOfDayReport frm = new FrmEndOfDayReport();
            frm.ShowDialog();
        }

        private void printerKioskCoordinatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPrinterKioskCoordinates frm = new FrmPrinterKioskCoordinates();
            frm.ShowDialog();
        }

        private void discountedCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategoryDiscounted frm = new FrmCategoryDiscounted();
            frm.ShowDialog();
        }

        private void stocksDataReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStocksDataReport frm = new FrmStocksDataReport();
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword frm = new FrmChangePassword(this);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LogOff();
            }
        }

        private void promoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPromo frm = new FrmPromo();
            if (frm.ShowDialog() == DialogResult.OK)
            {
             
            }
        }
    }
}
