using IS.Admin.Model;
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

namespace IS.Admin.Setup
{
    public partial class
        FrmModalSearchProducts : BaseForm
    {
        IList<Products> _ProductList = new List<Products>();
        public string _ProductId {get;set;}
        public string _ProductName { get; set; }
        public decimal _Price { get; set; }
        public IList<string> _Query { get; set; }
        Criteria criteria = new Criteria();
        ISFactory factory = new ISFactory();
        public FrmModalSearchProducts(List<string> fixedquery = null)
        {
            InitializeComponent();
            _Query = fixedquery;
            //this.Shown += new System.EventHandler(this.FrmModalSearchProducts_Shown);
        }

        private void LoadProducts()
        {
            SetLoading(true);
            Thread.Sleep(1);

            var response = factory.ProductsRepository.GetList();

            List<Products> listProduct = new List<Products>();

            if (_Query != null)
            {
                foreach (var productId in _Query)
                {
                    var prod = new Products();
                    prod =  response.Where(x => x.ProductId == productId).FirstOrDefault();
                    listProduct.Add(prod);
                }
                this._ProductList = listProduct;
            }
            else
            {
                this._ProductList = response;
            }
           

            Thread.Sleep(1);
            SetLoading(false);
        }

        private void LoadMemoryProducts()
        {
            dgvProducts.DataSource = null;
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = criteria.ProductCriteria.MeetCriteria(this._ProductList.ToList(), txtSearch.Text.ToUpper()).OrderBy(x=> x.ProductName).ToList();
            dgvProducts.StandardTab = true;
            dgvProducts.Refresh();
        }

  
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            LoadMemoryProducts();

        }

        private void SetLoading(bool displayLoader)
        {
            this.Invoke((MethodInvoker)delegate
            {
                grpProduct.Enabled = !displayLoader;
                grpLoading.Visible = displayLoader;
                grpLoading.Refresh();
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
            DisplayTotal();

        }

        private void DisplayTotal()
        {
            ProductsModel model = new ProductsModel();
            int TotalCount = model.GetTotalCount();

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
                this._ProductId = dgvProducts.CurrentRow.Cells[0].Value?.ToString();
                this._ProductName = dgvProducts.CurrentRow.Cells[1].Value?.ToString();
                this._Price =Convert.ToDecimal(dgvProducts.CurrentRow.Cells[2].Value);
                this.DialogResult = DialogResult.OK;
            }
        }


    }
}
