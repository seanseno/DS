using IS.Common.Utilities;
using IS.Database;
using IS.Database.Entities;
using IS.KIOSK.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public decimal TotalPrice { get; set; }
        public bool isKeyPressEnter { get; set; }

        int CountErrorlabel = 0;
        public FrmMain()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin(this);
            var response = frm.ShowDialog();
            if (response == DialogResult.OK)
            {
                panel1.Visible = true;
                timer2.Start();
                lblLogin.Text = "Current Login: " + Globals.LoginName;
                this.ActiveControl = txtCustomerName;
            }
            
        }
        private void load()
        {
            _TempLedgerSales = factory.TempLedgerSalesRepository.FindDefault(this._Cashier.CashierId);
            _TempOrderList = mainModel.LoadTempOders(this).Item1;
            TotalPrice = mainModel.LoadTempOders(this).Item2;


            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.DataSource = _TempOrderList;
            dgvOrders.StandardTab = true;

            txtTotal.Text = String.Format("{0:n}", TotalPrice);

        }


        private void CallKeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 112) //help
            {
               // this.btnHelp_Click(sender, e);
            }
            if (e.KeyValue == 113) //load
            {
                this.btnSearch_Click(sender, e);
            }
            if (e.KeyValue == 114) //load
            {
                this.btnLoad_Click(sender, e);
            }

            if (e.KeyValue == 115) //check out
            {
                this.btnCheckOut_Click(sender, e);;
            }
            if (e.KeyValue == 116) // Remove all
            {
                this.btnRemoveAll_Click(sender, e);
            }
            if (e.KeyValue == 117) // Save 
            {
                this.btnSave_Click(sender, e);;
            }
            if (e.KeyValue == 123) // Exit
            {
                this.btnExit_Click(sender, e);
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

                var GenericName = dgvOrders.CurrentRow.Cells[1].Value?.ToString();
                var BranName = dgvOrders.CurrentRow.Cells[2].Value?.ToString();
                var Description = dgvOrders.CurrentRow.Cells[3].Value?.ToString();
                var Params = new List<string>();
                if (this._TempOrderList != null)
                {
                    if (!string.IsNullOrEmpty(GenericName))
                    {
                        Params.Add(GenericName);
                    }
                    if (!string.IsNullOrEmpty(BranName))
                    {
                        Params.Add(BranName);
                    }
                    if (!string.IsNullOrEmpty(Description))
                    {
                        Params.Add(Description);
                    }

                    if (MessageBox.Show("Removing " + string.Join(" ", Params) + ".", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        MainModel mainModel = new MainModel();
                        mainModel.DeleteTempOrder(this, (int)dgvOrders.CurrentRow.Cells[0].Value);
                        load();
                    }
                }
                //txtSearch.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to exit.", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
                    FrmCheckOut frm = new FrmCheckOut(this);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        load();
                        //MessageBox.Show("Orders complete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            //MessageBox.Show("No orders detected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //txtSearch.Focus();
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
                    //txtSearch.Focus();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this._TempOrderList != null)
            {
                if (this._TempOrderList.Count() > 0)
                {
                    if (MessageBox.Show("Are you sure do want to save orders.", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        mainModel.SaveOrders(this);
                        load();
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
                    if (MessageBox.Show("Are you sure do want to delete all order", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        MainModel mainModel = new MainModel();
                        mainModel.DeleteAllTempOrder(this);
                        load();
                        MessageBox.Show("Orders deleted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    frmMultiplier frmMultiplier = new frmMultiplier(this, frm._ProductId);
                    if (frmMultiplier.ShowDialog() == DialogResult.OK)
                    {
                        load();
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
    }
}
