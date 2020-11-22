using IS.Common.Utilities;
using IS.Database;
using IS.Database.Enums;
using IS.KIOSK.Model;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace IS.KIOSK
{
    public partial class FrmCheckOut : BaseForm
    {
        FrmMain _FrmMain = new FrmMain();
        public decimal payAmount { get; set; }
        public decimal changeAmount { get; set; }
        int CountErrorlabel = 0;
        ISFactory factory = new ISFactory();
        public FrmCheckOut(FrmMain frm)
        {
            InitializeComponent();
            _FrmMain = frm;
            lblTotalPrice.Text = "Total Price : " + Math.Round(_FrmMain._TotalPrice, 2).ToString("N2");
        }


        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAmount.Text))
            {
                if (decimal.TryParse(txtAmount.Text, out decimal amount))
                {
                    this.payAmount = amount;
                    this.changeAmount = amount - _FrmMain._TotalPrice;
                    lblChange.Text = "Change :  " + String.Format("{0:n}", this.changeAmount);
                }
                else
                {
                    lblChange.Text = "Change : 0.00";
                }
            }
            else
            {
                lblChange.Text = "Change : 0.00";
            }
            lblError.Visible = false;
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           Proceed(_FrmMain._WithPrinter);
        }

        private void Proceed(bool withPrinter)
        {
            if (CheckIsStock())
            {

                if (decimal.TryParse(txtAmount.Text, out decimal Amount))
                {
                    if (Amount > 0)
                    {
                        if (changeAmount < 0)
                        {
                            lblError.Text = "Negative payment detected!";
                            timer1.Start();
                        }
                        else
                        {
                            try
                            {
                                var frmCheckOutModel = new FrmCheckOutModel();
                                var orNumber = frmCheckOutModel.ExecutePayment(this, this._FrmMain);

                                if (withPrinter)
                                {
                                    _FrmMain.PrintReceipt(orNumber);
                                }

                                MessageBox.Show("Orders complete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                FrmChange frmchAnge = new FrmChange(changeAmount.ToString("N2"));
                                frmchAnge.ShowDialog();

                                this.DialogResult = DialogResult.OK;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        lblError.Text = "Payment not detected!";
                        timer1.Start();
                        txtAmount.Focus();
                    }
                }
                else
                {
                    lblError.Text = "Payment not detected!";
                    timer1.Start();
                    txtAmount.Focus();
                }
            }
        }
        private bool CheckIsStock()
        {
            var response = factory.TempSalesRepository.GetList();
            var list = response.Where(x => x.TempLedgerId == _FrmMain._TempLedgerSales.Id).ToList();
            foreach (var item in list)
            {
                if (!factory.StocksRepository.StocksStrategy.HaveStock(item.ProductId))
                {
                    MessageBox.Show("Not enough stock! " + item.ProductName, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(rtxtOrders.Text, new Font("Microsoft San Serif", 8, FontStyle.Regular), Brushes.Black, new Point(10, 10));
        }

        private void FrmCheckOut_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtAmount;
            if (!_FrmMain._WithPrinter)
            {
                btnPrint.Visible = false;
                btnOk.Location = new Point(215, 138);
            }
            else
            {
                btnOk.Visible = false;
            }
        }

        //public void PrintReceipt(int LedgerId)
        //{
        //    PrintDocument p = new PrintDocument();
        //    p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
        //    {
        //        var Date = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "Date").FirstOrDefault();
        //        e1.Graphics.DrawString(DateTime.Now.ToString("MMMM dd, yyyy"), new Font("Times New Roman", Date.Size), Brushes.Black, new RectangleF(Date.X, Date.Y, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

        //        var ReceiptNo = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "ReceiptNo").FirstOrDefault();
        //        e1.Graphics.DrawString(string.Format("{0:000000000000}", LedgerId), new Font("Times New Roman", ReceiptNo.Size), Brushes.Black, new RectangleF(ReceiptNo.X, ReceiptNo.Y, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

        //        var SoldTo = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "SoldTo").FirstOrDefault();
        //        e1.Graphics.DrawString(_FrmMain._CustomerName, new Font("Times New Roman", SoldTo.Size), Brushes.Black, new RectangleF(SoldTo.X, SoldTo.Y, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

        //        var Total = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "Total").FirstOrDefault();
        //        e1.Graphics.DrawString(_FrmMain._TempOrderList.Sum(x => x.TotalPrice).ToString("N2"), new Font("Times New Roman", Total.Size), Brushes.Black, new RectangleF(Total.X, Total.Y, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

        //        var Products = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "Products").FirstOrDefault();

        //        var Items = factory.SalesRepository.GetSalesDetailListReport().Where(x=>x.LedgerId == LedgerId).OrderBy(y=>y.Id);

        //        foreach (var itm in Items)
        //        {
        //            string product = string.Empty;
        //            decimal TotalPrice = Convert.ToDecimal(Convert.ToDecimal(itm?.Qty) * itm?.price);

        //            var descList = WordWrap.Wrap(itm.ProductName + " " + itm.Qty?.ToString("N0") + " " + TotalPrice.ToString("N2"), 50);
        //            int Count = 0;
        //            foreach (var desc in descList)
        //            {
        //                if (Count == 0)
        //                {
        //                    product += desc + "\n";
        //                }
        //                else
        //                {
        //                    product += "--" + desc + "\n";
        //                }

        //                Count++;
        //            }

        //            e1.Graphics.DrawString(product, new Font("Times New Roman", Products.Size), Brushes.Black, new RectangleF(Products.X, Products.Y, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
        //            Products.Y += 12;
        //        }
        //    };
        //    try
        //    {
        //        p.Print();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                Proceed(_FrmMain._WithPrinter);
            }
            if (e.KeyValue == 27)
            {
                btnCancel_Click(sender, e);
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            Proceed(_FrmMain._WithPrinter);
        }
    }
}