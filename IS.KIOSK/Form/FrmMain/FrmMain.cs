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
              
            }
            //this.ActiveControl = txtSearch;
        }
        private void load()
        {
            _TempLedgerSales = factory.TempLedgerSalesRepository.FindDefault(this._Cashier.CashierId);
            _TempOrderList = mainModel.LoadTempOders(this).Item1;
            TotalPrice = mainModel.LoadTempOders(this).Item2;

            loadProduct();
      

           // dgvSearch.Sort(dgvSearch.Columns[0], ListSortDirection.Ascending);

            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.DataSource = _TempOrderList;
            dgvOrders.StandardTab = true;

            txtTotal.Text = String.Format("{0:n}", TotalPrice);

            txtSearch.Focus();
        }

        private void loadProduct()
        {
            this._ItemList = mainModel.LoadItems(this, txtSearch.Text);
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = _ItemList;
            dgvSearch.StandardTab = true;
        }
        private void CallKeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 112) //help
            {
               // this.btnHelp_Click(sender, e);
            }
            if (e.KeyValue == 113) //load
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


        #region Items
        private void dgvSearch_KeyUp(object sender, KeyEventArgs e)
        {
            ItemSelected( sender,  e);
        }

        private void ItemSelected(object sender, KeyEventArgs e)
        {
            //CallKeyPress(sender, e);
            if (e.KeyValue == 27)
            {
                txtSearch.Focus();
            }
            if (e.KeyValue == 13)
            {
                var ProductId = dgvSearch.CurrentRow.Cells[0].Value?.ToString();
                var GenericName = dgvSearch.CurrentRow.Cells[1].Value?.ToString();
                var BranName = dgvSearch.CurrentRow.Cells[2].Value?.ToString();
                var Description = dgvSearch.CurrentRow.Cells[3].Value?.ToString();
                var Params = new List<string>();
                if(!string.IsNullOrEmpty(GenericName))
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

                if ( (decimal)dgvSearch.CurrentRow.Cells[3].Value <= 0)
                {
                    lblError.Text = "Invalid price " + string.Join( " ",Params);
                    timer1.Start();
                    return;
                }
                if ((int)dgvSearch.CurrentRow.Cells[4].Value < 1)
                {
                    lblError.Text = "Not enough stock for " + string.Join(" ", Params);
                    timer1.Start();
                    return;
                }
                if (factory.TempSalesRepository.TempSalesStrategy.CheckIfOrderExist(this._TempLedgerSales, ProductId))
                {
                    lblError.Text = string.Join(" ", Params) + " already added!";
                    timer1.Start();
                    // MessageBox.Show(description + " already added!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmMultiplier frm = new frmMultiplier(this, ProductId);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtSearch.Focus();
                    load();
                }
                else
                {
                    txtSearch.Focus();
                }
            }
        }

        #endregion

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
            lblError.Visible = false;
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //CallKeyPress(sender, e);
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 18)
            {
                txtSearch.Focus();

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
                txtSearch.Focus();
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
                FrmCheckOut frm = new FrmCheckOut(this);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    load();
                    MessageBox.Show("Orders complete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No orders detected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtSearch.Focus();
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
                    txtSearch.Focus();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this._TempOrderList != null)
            {
                if (MessageBox.Show("Are you sure do want to save orders.", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    mainModel.SaveOrders(this);
                    load();
                }
            }
            else
            {
                MessageBox.Show("No orders detected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtSearch.Focus();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (this._TempOrderList != null)
            {
                if (MessageBox.Show("Are you sure do want to delete all order", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    MainModel mainModel = new MainModel();
                    mainModel.DeleteAllTempOrder(this);
                    load();
                    MessageBox.Show("Orders deleted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No orders detected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtSearch.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            grpLoading.Visible = true;
            grpLoading.Refresh();

            this.loadProduct();


            grpLoading.Visible = false;
            grpLoading.Refresh();
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            load();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = this._ItemList.Where(x => x.CategoryName.Contains(txtSearch.Text.ToUpper()) || x.ProductName.Contains(txtSearch.Text.ToUpper())).ToList(); 
            dgvSearch.StandardTab = true;
        }

        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
