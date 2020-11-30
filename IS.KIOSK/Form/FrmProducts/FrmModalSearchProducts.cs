
using IS.Common.Reader;
using IS.Database;
using IS.Database.Entities;
using IS.Database.Entities.Criteria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.KIOSK
{
    public partial class
        FrmModalSearchProducts : BaseForm
    {
        IList<ProductsKiosk> _ProductList = new List<ProductsKiosk>();
        public string _CategoryId { get; set; }
        public string _ProductId {get;set;}
        public string _ProductName { get; set; }
        public IList<string> _Query { get; set; }
        Criteria criteria = new Criteria();
        ISFactory factory = new ISFactory();
        public FrmModalSearchProducts(List<string> fixedquery = null)
        {
            InitializeComponent();
            this.KeyPreview = true;
            _Query = fixedquery;
            ActiveControl = txtSearch;
            //this.Shown += new System.EventHandler(this.FrmModalSearchProducts_Shown);
        }

        private void LoadProducts()
        {
            SetLoading(true);
            Thread.Sleep(1);

            this._ProductList = factory.ProductsRepository.GetListFromKiosk();

            Thread.Sleep(1);
            SetLoading(false);
        }

        private void LoadMemoryProducts()
        {
            dgvProducts.DataSource = null;
            dgvProducts.AutoGenerateColumns = false;
            var response = this._ProductList
                                    .Where(x => x.CategoryName.ToUpper().Contains(txtSearch.Text.ToUpper()) ||
                                        x.ProductId.ToUpper().Contains(txtSearch.Text.ToUpper()) ||
                                        x.ProductName.ToUpper().Contains(txtSearch.Text.ToUpper()) ||
                                        x.BarCode.Contains(txtSearch.Text))
                                    .OrderBy(y => y.ProductName).ToList();

            dgvProducts.DataSource = response;
            dgvProducts.StandardTab = true;
            dgvProducts.Refresh();

            DisplayTotal(response.Count());
        }

  
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetLoading(bool displayLoader)
        {
            this.Invoke((MethodInvoker)delegate
            {
                grpProduct.Enabled = !displayLoader;
                grpLoading.Visible = displayLoader;
                grpLoading.Refresh();
                txtSearch.Focus();
            });
        }


        private void grpProduct_EnabledChanged(object sender, EventArgs e)
        {
            LoadMemoryProducts();
        }

        private void FrmModalSearchProducts_Load(object sender, EventArgs e)
        {
            try
            {
                Thread threadInput = new Thread(LoadProducts);
                threadInput.Start();
            }
            catch (Exception ex)
            {


            }
        }

        private void DisplayTotal(int TotalCount)
        {
            string TotalStr = "Total Record 0";
            if (TotalCount > 1)
            {
                TotalStr = "Total Record(s) " + TotalCount.ToString("N0");
            }
            else if (TotalCount == 1)
            {
                TotalStr = "Total Record " + TotalCount.ToString("N0");
            }
            lblTotal.Text = TotalStr;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvProducts.Rows.Count > 0)
            {
                this._CategoryId = dgvProducts.CurrentRow.Cells[0].Value?.ToString();
                this._ProductId = dgvProducts.CurrentRow.Cells[2].Value?.ToString();
                this._ProductName = dgvProducts.CurrentRow.Cells[3].Value?.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadMemoryProducts();
        }

        private void dgvProducts_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnSelect_Click(sender, e);
            }
        }

        private void FrmModalSearchProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue ==27)
            {
                btnClose_Click(sender, e);
            }
        }
    }
}
