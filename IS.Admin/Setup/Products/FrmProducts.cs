using IS.Admin.Model;
using IS.Admin.Transactions;
using IS.Common.Reader;
using IS.Common.Utilities;
using IS.Database;
using IS.Database.CSV;
using IS.Database.Entities;
using IS.Database.Entities.Criteria;
using IS.Database.Enums;
using IS.Library.CSV;
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
    public partial class FrmProducts : BaseForm
    {
        IList<Products> _ProductList = new List<Products>();
        ISFactory factory = new ISFactory();
        Criteria cri = new Criteria();
        public FrmProducts()
        {
            InitializeComponent();
            //this.Shown += new System.EventHandler(this.FrmProducts_Shown);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddProduct frm = new FrmAddProduct();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.LoadProducts();
                DisplayTotal();
            }
            
        }

        private void ProductSearch()
        {
            LoadMemoryProducts();
        }
        private void LoadProducts()
        {
            SetLoading(true);
            Thread.Sleep(1);
            ProductsModel model = new ProductsModel();
            var response = factory.ProductsRepository.GetList().OrderBy(x => x.ProductName).ToList();
            this._ProductList = response;
            Thread.Sleep(1);
            SetLoading(false);
        }

        private void LoadMemoryProducts()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = cri.ProductCriteria.MeetCriteria(this._ProductList.ToList(), txtSearch.Text);  
            dgvProducts.StandardTab = true;
        }

        private void DeleteMemoryProducts(string ProductId)
        {
            SetLoading(true);
            var prod = this._ProductList.FirstOrDefault(x=>x.ProductId == ProductId);
            _ProductList.Remove(prod);
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = cri.ProductCriteria.MeetCriteria(this._ProductList.ToList(), txtSearch.Text);
            dgvProducts.StandardTab = true;

            SetLoading(false);
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Item = new Products();
            Item.ProductId = dgvProducts.CurrentRow.Cells[1].Value?.ToString();
            Item.ProductName = dgvProducts.CurrentRow.Cells[2].Value?.ToString();

            if (e.ColumnIndex == 0)
            {
                FrmProdutcsHistory frm = new FrmProdutcsHistory(Item.ProductId);
                frm.ShowDialog();
            }

            if (e.ColumnIndex == 6)
            {
                FrmEditProduct frm = new FrmEditProduct(Item);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.LoadProducts();
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
            }
            if (e.ColumnIndex == 7)
            {
                var model = new ProductsModel();
                if (model.CheckItemIfAlreadyInUse(Item.ProductId))
                {
                    MessageBox.Show("You can not delete " + Item.ProductName + " because this item is already used!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure do want to delete " + Item.ProductName + ".", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        model.DeleteItem(Item);
                        this.DeleteMemoryProducts(Item.ProductId);
                        DisplayTotal();
                        MessageBox.Show(Item.ProductName + " deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            this.ProductSearch();

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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadMemoryProducts();
        }

        private void grpProduct_EnabledChanged(object sender, EventArgs e)
        {
            LoadMemoryProducts();
        }

        private void FrmProducts_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
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

        private void btnUpload_Click(object sender, EventArgs e)
        {
            FrmUploadExcel frm = new FrmUploadExcel();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.FrmProducts_Load(sender,e);
                DisplayTotal();
            }
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

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ProductList == null || _ProductList.Count == 0)
                {
                    MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            var list = new List<ProductsCSV>();
                            foreach (var obj in this._ProductList)
                            {
                                var item = new ProductsCSV();
                                item.ProductId = obj.ProductId;
                                item.ProductName = obj.ProductName;
                                item.Price = obj.Price.ToString("N2");
                                item.InserTime = obj.InsertTime.ToString("hh:mm tt");
                                item.UpdateTime = obj.UpdateTime.ToString("hh:mm tt");
                                item.Active = ((EnumActive)obj.Active).ToString() ;
                                item.Barcode = obj.BarCode;
                                list.Add(item);
                            }

                            CSV model = new CSV();

                            var factory = new ISFactory();
                            var fullname = factory.AdministratorsRepository.FindAdministratorWithLoginname(Globals.LoginName).Fullname;
                            var filename = model.WriteProductsCSV(
                                sfd.FileName,
                                list,
                                fullname);
                            System.Diagnostics.Process.Start(filename);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
