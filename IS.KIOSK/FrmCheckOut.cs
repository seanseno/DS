using IS.Common.Utilities;
using IS.Database;
using IS.KIOSK.Model;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace IS.KIOSK
{
    public partial class FrmCheckOut : Form
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
                            var frmCheckOutModel = new FrmCheckOutModel();
                            var orNumber = frmCheckOutModel.ExecutePayment(this, this._FrmMain);
                            LoadOrders(orNumber);
                            PrintReceipt();

                            MessageBox.Show("Orders complete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            FrmChange frmchAnge = new FrmChange(changeAmount.ToString("N2"));
                            frmchAnge.ShowDialog();
                            //if (frmchAnge.ShowDialog() == DialogResult.OK)
                            //{
                            //    return;
                            //}
                            this.DialogResult = DialogResult.OK;
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

        private void LoadOrders(int? OrNumber)
        {
            decimal total = _FrmMain._TempOrderList.Sum(x => x.TotalPrice);
            rtxtOrders.Clear();
            rtxtOrders.Text += "*******************************************************************\n";
            rtxtOrders.Text += "                         Fees Receipt System\n";
            rtxtOrders.Text += "*******************************************************************\n";
            rtxtOrders.Text += "Date : " + DateTime.Now + " \n";
            rtxtOrders.Text += "OR NO : " + string.Format("{0:00000000}", OrNumber) + "\n";
            rtxtOrders.Text += "\n";
            rtxtOrders.Text += "\n";
            foreach (var itm in _FrmMain._TempOrderList)
            {
                 var descList = WordWrap.Wrap(itm.ProductName + " " + itm.Qty + " " + itm.TotalPrice, 50);
                int Count = 0;
                foreach(var desc in descList)
                {
                    if(Count == 0)
                    {
                        rtxtOrders.Text += desc + "\n";
                    }
                    else
                    {
                        rtxtOrders.Text += "--" + desc + "\n";
                    }
                    
                    Count++;
                }

            }
            rtxtOrders.Text += "\n";
            rtxtOrders.Text += "\n";
            rtxtOrders.Text += "Total Amount: " + total;
        }
        //private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        //{
        //    int H = 50;
        //    e.Graphics.DrawString("Print from my list", new System.Drawing.Font("Times New Roman", 10), Brushes.Black, 50, H);
        //    H += 50;
        //    foreach (var itm in _FrmMain._TempOrderList)
        //    {
        //        e.Graphics.DrawString(itm.Name, new System.Drawing.Font("Times New Roman", 10), Brushes.Black, 50, H);
        //    }
        //}

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(rtxtOrders.Text, new Font("Microsoft San Serif", 8, FontStyle.Regular), Brushes.Black, new Point(10, 10));
        }

        private void FrmCheckOut_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtAmount;
        }

        public void PrintReceipt()
        {
            PrintDialog pd = new PrintDialog();
            PaperSize psize = new PaperSize();
            printDocument1.DefaultPageSettings.Landscape = false;
            
            pd.Document = printDocument1;
            pd.Document.DefaultPageSettings.PaperSize = psize;

            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            DialogResult result = pd.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
            else
            {
                
            }
            //show print priview
            //PrintPreviewDialog ppd = new PrintPreviewDialog();
            //ppd.Document = printDocument1;
            ///*This dialog result is the important one :)*/
            //DialogResult ppdResult = ppd.ShowDialog();

            //if (ppdResult == DialogResult.OK)
            //{
            //    printDocument1.Print();
            //}

        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnPrint_Click(sender, e);
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
    }
}