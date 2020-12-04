using IS.Common.Utilities;
using IS.Database;
using IS.Database.Entities;
using IS.Database.Enums;
using IS.KIOSKBARCODE.Model;
using IS.Library.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.KIOSKBARCODE
{
    public partial class FrmMain : Form
    {
        public TempLedgerSales _TempLedgerSales { get; set; }
        public IList<TempSales> _TempOrderList { get; set; }
        public bool _IsDicounted { get; set; }
        public bool _WithPrinter { get; set; }
        ISFactory factory = new ISFactory();
        MainModel mainModel = new MainModel();
        public decimal _TotalPrice { get; set; }
        int CountErrorlabel = 0;
        int Multiplier { get; set; } = 1; 
        string Barcode { get; set; }
        bool IsPwd { get; set; }
        public FrmMain()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.ActiveControl = dgvList;
        }

        private void load()
        {
           // _Cashier = factory.CashiersRepository.GetList().Where(x => x.CashierId == Globals.LoginId).FirstOrDefault();
            _TempLedgerSales = factory.TempLedgerSalesRepository.FindDefault(Globals.LoginId);
            _TempOrderList = mainModel.LoadTempOders("").Item1;
            _TotalPrice = mainModel.LoadTempOders("").Item2;
            if (_TempOrderList.Where(x => x.Discounted > 0).Count() > 0)
            {
                _IsDicounted = true;
            }
            else
            {
                _IsDicounted = false;
            }
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = _TempOrderList;
            dgvList.StandardTab = true;

            lblTotal.Text = String.Format("{0:n}", _TotalPrice);
        }


        private void FrmMain_Load(object sender, EventArgs e)
        {
            //if (!_WithPrinter)
            //{
            //    btnReprint.Visible = false;
            //    btnExit.Location = new Point(861, 652);
            //}

            //_IsDicounted = false;
            panel1.Visible = true;
            timer2.Start();

            string LogoPath = ThemesUtility.Logo();
            if (!string.IsNullOrEmpty(LogoPath))
            {
                if (File.Exists(LogoPath))
                {
                    pnlLogo.BackgroundImage = Image.FromFile(ThemesUtility.Logo());
                }
            }
            lblCompanyName.Text = ThemesUtility.CompanyName();
            BackColor = ThemesUtility.BackColor();

            frmLogin frm = new frmLogin();
            var response = frm.ShowDialog();
            if (response == DialogResult.OK)
            {
                //lblLogin.Text = "Current Login: " + Globals.LoginName;
                //this.ActiveControl = txtCustomerName;
            }
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 123)
            {
                if (MessageBox.Show("Are you sure do you want to exit.", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }

            //Barcode
            if (e.KeyValue == 113)
            {
                pnlBarcode.Visible = true;
                pnlMultiplier.Visible = false;
                txtBarcode.Text = string.Empty;
                txtBarcode.Focus();
                dgvList.Enabled = false;
            }

            if (e.KeyValue == 115)
            {
                pnlBarcode.Visible = false;
                pnlMultiplier.Location = pnlBarcode.Location;
                pnlMultiplier.Visible = true;
                lblMultiplier.Text = "";
                Multiplier = 1;
                txtMultiplier.Text = "2";
                txtMultiplier.SelectAll();
                txtMultiplier.Focus();
                dgvList.Enabled = false;
            }

            //Senior
            if (e.KeyValue == 116)
            {
                FrmSeniorCitizen frm = new FrmSeniorCitizen();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    IsPwd = false;
                    RecomputeDiscount();
                }
            }

            //PWD
            if (e.KeyValue == 117)
            {
                FrmPWD frm = new FrmPWD();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    IsPwd = true;
                    RecomputeDiscount();
                }
            }
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            load();
        }

        private void AddItem()
        {
            if (string.IsNullOrEmpty(Barcode))
            {
                lblError.Text = string.Format("Barcode not found!");
                timer1.Start();
            }
            else
            {
                var bcode = Regex.Replace(Barcode, @"\t|\n|\r", string.Empty);
                var item = factory.ProductsRepository.GetListFromKiosk().Where(x => x.BarCode == bcode).FirstOrDefault();
                if (item != null)
                {
                    TempSales ts = new TempSales();
                    ts.ProductId = item.ProductId;
                    ts.Qty = Multiplier;
                    ts.TempLedgerId = (int)_TempLedgerSales.Id;
                    ts.IsSenior = 0;
                    ts.IsPWD = 0;
                    ts.Price = factory.ProductsRepository.GetList().Where(x => x.ProductId == item.ProductId).FirstOrDefault().Price;
                    ts.TotalPrice = ts.Price * ts.Qty;
                    factory.TempSalesRepository.Insert(ts);
                    Barcode = string.Empty;
                    lblError.Text = string.Empty;
                    lblMultiplier.Visible = false;
                    lblMultiplier.Text = "";
                    Multiplier = 1;
                    load();
                    // txtBarcode.Focus();
                }
                else
                {
                    lblError.Text = string.Format("Barcode not found!");
                    timer1.Start();
                    Barcode = string.Empty;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!lblError.Visible)
            {
                lblError.Visible = true;
            }
            else
            {
                lblError.Visible = false;
            }
            CountErrorlabel++;
            if (CountErrorlabel >= 6)
            {
                lblError.Visible = true;
                timer1.Stop();
                CountErrorlabel = 0;
            }
        }

        private void pnlHelp_MouseHover(object sender, EventArgs e)
        {
            lblHelp.ForeColor = Color.White;
            lblHelp.Refresh();
        }

        private void pnlHelp_MouseLeave(object sender, EventArgs e)
        {
            lblHelp.ForeColor = Color.Lime;
            lblHelp.Refresh();
        }

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                Barcode = txtBarcode.Text;
                AddItem();
                pnlBarcode.Visible = false;
                dgvList.Enabled = true;
                dgvList.Focus();
            }
            else if (e.KeyValue == 27)
            {
                pnlBarcode.Visible = false;
                dgvList.Enabled = true;
                dgvList.Focus();
            }
        }

        private void txtMultiplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMultiplier_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMultiplier.Text))
            {
                if (e.KeyValue == 13)
                {
                    Multiplier = Convert.ToInt32(txtMultiplier.Text);
                    pnlMultiplier.Visible = false;
                    txtBarcode.Focus();
                    lblMultiplier.Text = "Multiplier by " + Multiplier;
                    lblMultiplier.Visible = true;
                    dgvList.Enabled = true;
                    dgvList.Focus();
                }
            }
            else
            {
                txtMultiplier.Text = "2";
                txtMultiplier.SelectAll();
            }
        }

        private void dgvList_KeyPress(object sender, KeyPressEventArgs e)
        {
            Barcode += e.KeyChar.ToString();
        }

        private void dgvList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 38 || e.KeyValue != 40)
            {
                txtMultiplier.Focus();
            }

            if (e.KeyValue == 13)
            {
                AddItem();
            }
        }
        private void RecomputeDiscount()
        {
            //var tempLedger = factory.TempLedgerSalesRepository.FindDefault(Globals.LoginId);
            //if (tempLedger != null)
            //{
                //var tempOders = factory.TempSalesRepository.FindWithLedger(Globals.LoginId, tempLedger.Id, EnumActive.Active);
               
            foreach (var item in _TempOrderList)
            {
                var sd = factory.StocksDataRepository.GetList().Where(x => x.ProductId == item.ProductId).FirstOrDefault();
                //var cat = factory.CategoriesRepository.GetList().Where(x => x.CategoryId == sd.CategoryId).FirstOrDefault();
                var ProdDis = factory.ProductsDiscountedRepository.GetList().Where(x => x.ProductId == sd.ProductId).FirstOrDefault();
                if (ProdDis != null)
                {
                    var PD = factory.ProductsRepository.ProductsStrategy.GetDiscountInfo(item.ProductId, item.Qty, false, IsPwd);
                    item.PriceDiscounted = PD.PriceDiscounted;
                    item.TotalPrice = PD.TotalPrice;
                    item.Discounted = PD.Discounted;
                    item.IsPWD = IsPwd == true ? 1 : 0;
                    item.IsSenior = IsPwd == true ? 0 :1;
                    factory.TempSalesRepository.Update(item);
                    load();
                }
                else
                {
                    if (factory.CategoryDiscountedRepository.GetList().Where(x => x.CategoryId == sd.CategoryId).Count() > 0)
                    {
                        var PD = factory.ProductsRepository.ProductsStrategy.GetDiscountInfo(item.ProductId, item.Qty, false, IsPwd);
                        item.PriceDiscounted = PD.PriceDiscounted;
                        item.TotalPrice = PD.TotalPrice;
                        item.Discounted = PD.Discounted;
                        item.IsPWD = IsPwd == true ? 1 : 0;
                        item.IsSenior = IsPwd == true ? 0 : 1;
                        factory.TempSalesRepository.Update(item);
                        load();
                    }
                }        
            }
            //}
        }
    }
}
