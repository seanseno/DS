using IS.Common.Utilities;
using IS.Database;
using IS.Database.Entities;
using IS.Database.Enums;
using IS.Database.Models;
using IS.KIOSK.Model;
using IS.Library.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.KIOSK
{
    public partial class FrmMain : Form
    {
        public TempLedgerSales _TempLedgerSales { get; set; }
        public IList<TempSales> _TempOrderList { get; set; }
        public IList<Products> _ItemList { get; set; }

        public Cashiers _Cashier { get; set; }
        ISFactory factory = new ISFactory();
        MainModel mainModel = new MainModel();
        public decimal _TotalPrice { get; set; }
        int CountErrorlabel = 0;
        public string _CustomerName { get; set; }
        public string _AdditionalInfo { get; set; }
        public bool _IsDicounted { get; set; }
        public bool _WithPrinter { get; set; }
        bool IsPwd { get; set; }
        bool IsSenior { get; set; }
        public FrmMain()
        {
            InitializeComponent();
            this.KeyPreview = true;
            if (factory.SettingsRepository.GetList().FirstOrDefault().WithPrinter == (int)EnumActive.Active)
            {
                this._WithPrinter = true;
            }
            else
            {
                this._WithPrinter = false;
            }
            this.ActiveControl = txtCustomerName;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (!_WithPrinter)
            {
                pnlReprint.Visible = false;
            }

            _IsDicounted = false;
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

            frmLogin frm = new frmLogin(this);
            var response = frm.ShowDialog();
            if (response == DialogResult.OK)
            {
                lblLogin.Text = "Current Login: " + Globals.LoginName;
            }
            
        }
        private void load()
        {
            _Cashier = factory.CashiersRepository.GetList().Where(x => x.CashierId == Globals.LoginId).FirstOrDefault();
            _TempLedgerSales = factory.TempLedgerSalesRepository.FindDefault(Globals.LoginId);
            _TempOrderList = mainModel.LoadTempOders().Item1;
            _TotalPrice = mainModel.LoadTempOders().Item2;

            if (_TempOrderList.Where(x => x.IsPWD == 1 || x.IsSenior == 1).Count() > 0)
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


        private void CallKeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 112) //help
            {
               this.btnHelp_Click(sender, e);
            }
            if (e.KeyValue == 113) //search
            {
                this.btnSearch_Click(sender, e);
            }
            if (e.KeyValue == 114) //load
            {
                this.btnLoad_Click(sender, e);
            }
            if (e.KeyValue == 115) //Checkout
            {
                this.btnCheckOut_Click(sender, e); ;
            }

            if (e.KeyValue == 116) //Senior
            {
                 btnSenior_Click(sender, e); ;
            }
            if (e.KeyValue == 117) // PWD
            {
                btnPWD_Click(sender, e); 
            }

            if (e.KeyValue == 118) // Remove all
            {
                this.btnRemoveAll_Click(sender, e);
            }

            if (e.KeyValue == 119) // Save 
            {
                this.btnSave_Click(sender, e); ;
            }
            if (e.KeyValue == 120) // Return Item
            {
                this.btnReturnItem_Click(sender, e);
            }
            if (e.KeyValue == 121) // Exit
            {
                this.btnExit_Click(sender, e);
            }
            if (e.KeyValue == 122) // Re-print
            {
                this.btnReprint_Click(sender, e);
            }
            if (e.KeyValue == 123) // edit qty
            {
                this.btnEditQty_Click(sender, e);
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

        private void dgvSearch_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //lblError.Visible = false;
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //CallKeyPress(sender, e);
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 18)
            {
                //txtSearch.Focus();

            }
            CallKeyPress(sender, e);
            e.Handled = false;
        }

        private void dgvOrders_KeyDown(object sender, KeyEventArgs e)
        {
            //CallKeyPress(sender, e);
            if (e.KeyValue == 46)
            {

                var ProductId = dgvList.CurrentRow.Cells[1].Value?.ToString();
                var BranName = dgvList.CurrentRow.Cells[2].Value?.ToString();
                var Description = dgvList.CurrentRow.Cells[3].Value?.ToString();
                var Params = new List<string>();
                if (this._TempOrderList != null)
                {
                    if (!string.IsNullOrEmpty(ProductId))
                    {
                        Params.Add(ProductId);
                    }
                    if (!string.IsNullOrEmpty(BranName))
                    {
                        Params.Add(BranName);
                    }
                    if (!string.IsNullOrEmpty(Description))
                    {
                        Params.Add(Description);
                    }

                    string message;
                    if (checkIfPromo(ProductId))
                    {
                        message = "This product already apply as promo " + Environment.NewLine + "" +
                            "if you continue to remove this product " + Environment.NewLine + "" +
                            "the promo pack will return to default price " + Environment.NewLine + "" +
                            "Are you sure do you want to conitnue?";
                    }
                    else
                    {
                        message = "Removing " + string.Join(" ", Params) + ".";
                    }
                    if (MessageBox.Show(message, "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int Id = (int)dgvList.CurrentRow.Cells[0].Value;
                        var tmp = _TempOrderList.Where(x => x.Id == Id).FirstOrDefault();
                        var Promo = _TempOrderList.Where(x => tmp.Id == Id && x.IsPromo == (int)EnumActive.Active && x.PromoId == tmp.PromoId).FirstOrDefault();
                   
                        MainModel mainModel = new MainModel();
                        mainModel.DeleteTempOrder(this, Id);
                        load();
                        if (Promo != null)
                        {
                            var tmpList = _TempOrderList.Where(x => x.PromoId == Promo.PromoId).ToList();
                            foreach (var itm in tmpList)
                            {
                                itm.PriceDiscounted = 0;
                                itm.Discounted = 0;
                                itm.TotalPrice = itm.Price * itm.Qty;
                                itm.IsPromo = (int)EnumActive.NonActive;
                                factory.TempSalesRepository.RemoveKioskPromoProduct(itm);
                            }
                        }
                        load();
                    }
                }

                //txtSearch.Focus();
            }
        }

        private bool checkIfPromo(string ProductId)
        {
            if (_TempOrderList.Where(x => x.ProductId == ProductId && x.IsPromo == (int)EnumActive.Active).Count() > 0)
            {
                return true;
            }
            return false;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do you want to exit.", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (this._TempOrderList != null)
            {
                if (this._TempOrderList.Count() > 0)
                {
                    if (_IsDicounted == true && string.IsNullOrEmpty(txtCustomerName.Text))
                    {
                        MessageBox.Show("Product discounted Detected!, Customer Information is required!", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCustomerName.Focus();
                    }
                    else if (_IsDicounted == true && string.IsNullOrEmpty(txtAdditionalInfo.Text))
                    {
                        MessageBox.Show("Product discounted Detected!, Customer Information is required!", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAdditionalInfo.Focus();
                    }
                    else
                    {
                        this._CustomerName = txtCustomerName.Text;
                        this._AdditionalInfo = txtAdditionalInfo.Text;
                        FrmCheckOut frm = new FrmCheckOut(this);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            load();
                            txtCustomerName.Text = "";
                            txtAdditionalInfo.Text = "";
                        }
                    }
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (factory.TempLedgerSalesRepository.TempLedgerSalesStrategy.CheckTempLedgerHasSales(this._TempLedgerSales))
            {
                MessageBox.Show("Ongoing sales detected, please save first.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                FrmLoadSaveOrders frm = new FrmLoadSaveOrders(this);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    load();
                    txtCustomerName.Text = "";
                    txtAdditionalInfo.Text = "";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this._TempOrderList != null)
            {
                if (this._TempOrderList.Count() > 0)
                {
                    if (MessageBox.Show("Are you sure do you want to save orders.", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        mainModel.SaveOrders(this);
                        load();
                        txtCustomerName.Text = "";
                        txtAdditionalInfo.Text = "";
                        return;
                    }
                }
            }
            MessageBox.Show("No orders detected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //txtSearch.Focus();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (this._TempOrderList != null)
            {
                if (this._TempOrderList.Count() > 0)
                {
                    if (MessageBox.Show("Are you sure do you want to delete all order", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        MainModel mainModel = new MainModel();
                        mainModel.DeleteAllTempOrder(this);
                        txtAdditionalInfo.Text = "";
                        txtCustomerName.Text = "";
                        IsPwd = false;
                        load();
                        MessageBox.Show("Orders deleted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblError.Visible = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("No orders detected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //txtSearch.Focus();
        }


        private void FrmMain_Shown(object sender, EventArgs e)
        {
            load();
        }

        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FrmModalSearchProducts frm = new FrmModalSearchProducts();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lblError.Visible = false;
                if (factory.TempSalesRepository.TempSalesStrategy.CheckIfOrderExist(this._TempLedgerSales, frm._ProductId))
                {
                    lblError.Text = string.Format("{0} already added! ", frm._ProductName);
                    timer1.Start();
                }
                else if (!factory.StocksDataRepository.StocksDataStrategy.CheckStock(frm._ProductId))
                {
                    lblError.Text = string.Format("{0} is out of stock!", frm._ProductName);
                    timer1.Start();
                }
                else
                {
                    frmMultiplier frmMultiplier = new frmMultiplier(this, frm._ProductId,frm._CategoryId);
                    if (frmMultiplier.ShowDialog() == DialogResult.OK)
                    {

                        load();
                        var promoName = factory.PromoRepository.PromoStrategy.CheckPromo(_TempOrderList.Where(x=>x.IsPromo != (int)EnumActive.Active).Select(x => x.ProductId).ToList());
                        if (!string.IsNullOrEmpty(promoName))
                        {
                            var promo = factory.PromoRepository.GetList().Where(x => x.PromoName == promoName).FirstOrDefault();
                            var promoDetails = factory.PromoDetailsRepository.GetList().Where(x => x.PromoId == promo.Id).ToList();


                            string promoProdc = "";

                            foreach (var itm in promoDetails)
                            {
                                
                                promoProdc += factory.ProductsRepository.GetList().Where(x => x.ProductId == itm.ProductId).FirstOrDefault().ProductName + " Price: " + itm.Price.ToString("N2") + Environment.NewLine;
                            }

                            if (MessageBox.Show("Promo detected!," + Environment.NewLine + "" +
                                "Promo Name: " + promoName + "" + Environment.NewLine + "" + Environment.NewLine + "" +
                                "Product(s) : " + Environment.NewLine + "" +
                                "" + promoProdc + "" + "" + Environment.NewLine + "" +
                                "Do you want to apply this promo?", "information!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                this.ApplyPromo(promoDetails);
                            }
                        }
                    }
                }
            }
            else
            {
                lblError.Visible = false;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToString("MMMM ddd yyyy - dddd");
        }

        private void btnReturnItem_Click(object sender, EventArgs e)
        {
            FrmReturnItem frm = new FrmReturnItem();
            frm.ShowDialog();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            FrmHelp frm = new FrmHelp();
            frm.ShowDialog();
        }


        private void btnReprint_Click(object sender, EventArgs e)
        {
            if (pnlReprint.Visible)
            {
                if (MessageBox.Show("Are you sure do you want to re-print your last transaction?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var xx = factory.CashiersRepository.GetList();
                    var user = factory.CashiersRepository.GetList().Where(x => x.Loginname.ToUpper().Trim() == Globals.LoginName.ToUpper().Trim()).FirstOrDefault();
                    var response = factory.LedgerSalesRepository.GetList().Where(x => x.CashierId == user.CashierId).OrderByDescending(y => y.Id).FirstOrDefault();
                    PrintReceipt(response.Id);
                }
            }
        }

        public void PrintReceipt(int LedgerId)
        {
            PrintDocument p = new PrintDocument();
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                var Items = factory.SalesRepository.GetList().Where(x => x.LedgerId == LedgerId).OrderBy(y => y.Id);
                var LedgerSales = factory.LedgerSalesRepository.GetList().Where(x => x.Id == LedgerId).FirstOrDefault();

                var Date = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "Date").FirstOrDefault();
                e1.Graphics.DrawString(DateTime.Now.ToString("MMMM dd, yyyy"), new Font("Times New Roman", Date.Size), Brushes.Black, new RectangleF(Date.X, Date.Y, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

                var ReceiptNo = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "ReceiptNo").FirstOrDefault();
                e1.Graphics.DrawString(string.Format("{0:000000000000}", LedgerId), new Font("Times New Roman", ReceiptNo.Size), Brushes.Black, new RectangleF(ReceiptNo.X, ReceiptNo.Y, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

                var SoldTo = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "SoldTo").FirstOrDefault();
                
                
                e1.Graphics.DrawString(LedgerSales.CustomerName, new Font("Times New Roman", SoldTo.Size), Brushes.Black, new RectangleF(SoldTo.X, SoldTo.Y, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));


                var Products = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "Products").FirstOrDefault();
                var ProductsQty = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "ProductsQty").FirstOrDefault();
                var ProductsPrice = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "ProductsPrice").FirstOrDefault();

                decimal TotalAmountPrice = 0;
                foreach (var itm in Items)
                {
                    string product = string.Empty;
                    decimal TotalPrice = Convert.ToDecimal(Convert.ToDecimal(itm?.Qty) * itm?.Price);
                    TotalAmountPrice += TotalPrice;
                    var descList = WordWrap.Wrap(factory.ProductsRepository.GetList().Where(x=>x.ProductId == itm.ProductId).FirstOrDefault().ProductName, 50);
                    e1.Graphics.DrawString(itm.Qty.ToString("N0"), new Font("Times New Roman", ProductsQty.Size), Brushes.Black, new RectangleF(ProductsQty.X, Products.Y, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
                    e1.Graphics.DrawString(TotalPrice.ToString("N2"), new Font("Times New Roman", ProductsPrice.Size), Brushes.Black, new RectangleF(ProductsPrice.X, Products.Y, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
                    foreach (string desc in descList)
                    {
                        e1.Graphics.DrawString(desc, new Font("Times New Roman", Products.Size), Brushes.Black, new RectangleF(Products.X, Products.Y, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
                        Products.Y += 12;
                    }
                   
                }

                var Total = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "Total").FirstOrDefault();
                e1.Graphics.DrawString(TotalAmountPrice.ToString("N2"), new Font("Times New Roman", Total.Size), Brushes.Black, new RectangleF(Total.X, Total.Y, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

            };
            try
            {
                //p.Print();
                PrintDialog printDialog1 = new PrintDialog();
                printDialog1.Document = p;
                DialogResult result = printDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    p.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CheckItemListIfDiscounted()
        {
            IsPwd = false;
            IsSenior = false;
            foreach (var item in _TempOrderList)
            {
                var sd = factory.StocksDataRepository.GetList().Where(x => x.ProductId == item.ProductId).FirstOrDefault();
                var ProdDis = factory.ProductsDiscountedRepository.GetList().Where(x => x.ProductId == sd.ProductId).FirstOrDefault();
                if (ProdDis != null)
                {
                    if (!IsPwd)
                    {
                        IsPwd = ProdDis.IsPWD == 1;
                    }
                    if (!IsSenior)
                    {
                        IsSenior = ProdDis.IsSenior == 1;
                    }
                }
                else
                {
                    if (factory.CategoryDiscountedRepository.GetList().Where(x => x.CategoryId == sd.CategoryId).Count() > 0)
                    {
                        var Cat = factory.CategoryDiscountedRepository.GetList().Where(x => x.CategoryId == sd.CategoryId).FirstOrDefault();
                        if (!IsPwd)
                        {
                            IsPwd = Cat.IsPWD == 1;
                        }
                        if (!IsSenior)
                        {
                            IsSenior = Cat.IsSenior == 1;
                        }
                    }
                }
            }
        }
        private void RecomputeDiscount(bool IsSelectedSenior)
        {
            foreach (var item in _TempOrderList)
            {
                var sd = factory.StocksDataRepository.GetList().Where(x => x.ProductId == item.ProductId).FirstOrDefault();
                if (IsSelectedSenior)
                {
                    var ProdDis = factory.ProductsDiscountedRepository.GetList()
                                .Where(x => x.ProductId == sd.ProductId &&
                                x.IsSenior == Convert.ToInt32(IsSenior) ).FirstOrDefault();

                    if (ProdDis != null)
                    {
                        var PD = factory.ProductsRepository.ProductsStrategy.GetDiscountInfo(item.ProductId, item.Qty, Convert.ToBoolean(EnumSenior.True));
                        item.PriceDiscounted = PD.PriceDiscounted;
                        item.TotalPrice = PD.TotalPrice;
                        item.Discounted = PD.Discounted;
                        item.IsPWD = 0;
                        item.IsSenior = 1;
                        factory.TempSalesRepository.Update(item);
                    }
                    else
                    {
                        if (factory.CategoryDiscountedRepository.GetList()
                            .Where(x => x.CategoryId == sd.CategoryId &&
                            x.IsSenior == Convert.ToInt32(IsSenior)).Count() > 0)
                        {
                            var PD = factory.ProductsRepository.ProductsStrategy.GetDiscountInfo(item.ProductId, item.Qty, Convert.ToBoolean(EnumSenior.True));
                            item.PriceDiscounted = PD.PriceDiscounted;
                            item.TotalPrice = PD.TotalPrice;
                            item.Discounted = PD.Discounted;
                            item.IsPWD = 0;
                            item.IsSenior = 1;
                            factory.TempSalesRepository.Update(item);
                        }
                        else
                        {
                            ResetDiscount(item);
                        }
                    }
                }
                else
                {
                    var ProdDis = factory.ProductsDiscountedRepository.GetList()
                    .Where(x => x.ProductId == sd.ProductId &&
                    x.IsPWD == Convert.ToInt32(IsPwd)).FirstOrDefault();

                    if (ProdDis != null)
                    {
                        var PD = factory.ProductsRepository.ProductsStrategy.GetDiscountInfo(item.ProductId, item.Qty, Convert.ToBoolean(EnumSenior.False));
                        item.PriceDiscounted = PD.PriceDiscounted;
                        item.TotalPrice = PD.TotalPrice;
                        item.Discounted = PD.Discounted;
                        item.IsPWD = 1;
                        item.IsSenior = 0;
                        factory.TempSalesRepository.Update(item);
                    }
                    else
                    {
                        if (factory.CategoryDiscountedRepository.GetList()
                            .Where(x => x.CategoryId == sd.CategoryId &&
                            x.IsPWD == Convert.ToInt32(IsPwd)).Count() > 0)
                        {
                            var PD = factory.ProductsRepository.ProductsStrategy.GetDiscountInfo(item.ProductId, item.Qty, Convert.ToBoolean(EnumSenior.False));
                            item.PriceDiscounted = PD.PriceDiscounted;
                            item.TotalPrice = PD.TotalPrice;
                            item.Discounted = PD.Discounted;
                            item.IsPWD = 1;
                            item.IsSenior = 0;
                            factory.TempSalesRepository.Update(item);
                        }
                        else
                        {
                            ResetDiscount(item);
                        }
                    }
                }
            }
            load();
        }

        private void ResetDiscount(TempSales item)
        {
            var sd = factory.StocksDataRepository.GetList().Where(x => x.ProductId == item.ProductId).FirstOrDefault();
            var product = factory.ProductsRepository.GetListFromKiosk().Where(x => x.ProductId == item.ProductId).FirstOrDefault();
            item.PriceDiscounted = product.Price;
            item.TotalPrice = item.Qty * product.Price;
            item.Discounted = 0;
            item.IsPWD = 0;
            item.IsSenior = 0;
            factory.TempSalesRepository.Update(item);
        }
        private void btnSenior_Click(object sender, EventArgs e)
        {
            if (this._TempOrderList.Count() > 0)
            {
                CheckItemListIfDiscounted();
                if (!IsSenior)
                {
                    lblError.Text = string.Format("Senior discount is not applicable!");
                    timer1.Start();
                }
                else
                {
                    FrmSeniorCitizen frm = new FrmSeniorCitizen();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        txtCustomerName.Text = frm.CustomerName;
                        txtAdditionalInfo.Text = frm.AdditionalInfo;
                        IsPwd = false;
                        RecomputeDiscount(Convert.ToBoolean(EnumSenior.True));
                    }
                }
            }
        }

        private void btnPWD_Click(object sender, EventArgs e)
        {
            if (this._TempOrderList.Count() > 0)
            {
                CheckItemListIfDiscounted();
                if (!IsPwd)
                {
                    lblError.Text = string.Format("PWD discount is not applicable!");
                    timer1.Start();
                }
                else
                {
                    FrmPWD frm = new FrmPWD();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        txtCustomerName.Text = frm.CustomerName;
                        txtAdditionalInfo.Text = frm.AdditionalInfo;
                        IsPwd = true;
                        RecomputeDiscount(Convert.ToBoolean(EnumSenior.False));
                    }
                }
            }
        }

        private void btnEditQty_Click(object sender, EventArgs e)
        {
            if (this._TempOrderList.Count() > 0)
            {
                var Id = dgvList.CurrentRow.Cells[0].Value?.ToString();
                var tmp = _TempOrderList.Where(x => x.Id == Convert.ToInt32(Id)).FirstOrDefault();
                var ProductName = dgvList.CurrentRow.Cells[2].Value?.ToString();
                var Qty = dgvList.CurrentRow.Cells[3].Value?.ToString();
                FrmEntryQty frm = new FrmEntryQty(ProductName, Qty);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    tmp.Qty = Convert.ToInt32(frm._Qty);
                    var PD = new ProductDiscounted();
                    if (tmp.IsPWD == (int)EnumSenior.True)
                    {
                        PD = factory.ProductsRepository.ProductsStrategy.GetDiscountInfo(tmp.ProductId, tmp.Qty, false);
                    }
                    if (tmp.IsSenior == (int)EnumSenior.True)
                    {
                        PD = factory.ProductsRepository.ProductsStrategy.GetDiscountInfo(tmp.ProductId, tmp.Qty, true);
                    }

                    if (!string.IsNullOrEmpty(PD.ProductId))
                    {
                        tmp.PriceDiscounted = PD.PriceDiscounted;
                        tmp.Discounted = PD.Discounted;
                        tmp.TotalPrice = PD.TotalPrice;
                    }
                    else if(tmp.PriceDiscounted > 0 )
                    {
                        decimal price = tmp.PriceDiscounted <= 0 ? tmp.Price : tmp.PriceDiscounted;
                        tmp.Discounted =  ((tmp.Price - tmp.PriceDiscounted) * tmp.Qty);
                        tmp.TotalPrice = tmp.Qty * price;
                    }
                    else 
                    {
                        tmp.TotalPrice = tmp.Qty * tmp.Price;
                    }
                    factory.TempSalesRepository.UpdateQty(tmp);
                    load();
                }
            }
        }

        private void ApplyPromo(List<PromoDetails> listDetails)
        {
            if (this._TempOrderList.Count() > 0)
            {
                foreach (var itm in listDetails)
                {
                    var PD = new ProductDiscounted();
                    var tmp = factory.TempSalesRepository.GetList().Where(x => x.TempLedgerId == _TempLedgerSales.Id && x.ProductId == itm.ProductId).FirstOrDefault();
                    if (tmp != null)
                    {
                        PD = factory.ProductsRepository.ProductsStrategy.GetPromoProduct(tmp.ProductId, itm.PromoId, tmp.Qty);

                        if (!string.IsNullOrEmpty(PD.ProductId))
                        {
                            tmp.PriceDiscounted = PD.PriceDiscounted;
                            tmp.Discounted = PD.Discounted;
                            tmp.TotalPrice = PD.PriceDiscounted * tmp.Qty;
                            tmp.IsPromo = (int)EnumActive.Active;
                            tmp.PromoId = itm.PromoId;
                            factory.TempSalesRepository.UpdatePromo(tmp);
                        }
                    }
                }
                load();
            }
        }

        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                var val = Convert.ToDecimal(e.Value);
                e.Value = "-" + val.ToString("N2");
            }
        }
    }
}
