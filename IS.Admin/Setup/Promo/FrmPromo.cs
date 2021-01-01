using IS.Common.Utilities;
using IS.Database;
using IS.Database.Entities;
using IS.Database.Enums;
using IS.Database.Views;
using IS.Library.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Admin.Setup
{
    public partial class FrmPromo : BaseForm
    {
        ISFactory factory = new ISFactory();
        IList<Promo> _list = new List<Promo>();
        public FrmPromo()
        {
            InitializeComponent();
            dtpFrom.Value = DateConvertion.GetFistDay(DateTime.Now);
            dtpTo.Value = DateConvertion.GetLastDay(DateTime.Now);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void FrmProductsDiscounted_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            var response = factory.PromoRepository.GetList();
            if (response != null)
            {
                response = response.OrderByDescending(x => x.Id).ToList();
            }
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                int active = chkActive.Checked == true ? 1 : 0;
                response = response.Where(x => DateTimeConvertion.ConvertDateFrom(dtpFrom.Value) <= x.DateFrom && x.DateTo <= DateTimeConvertion.ConvertDateTo(dtpTo.Value) &&
                                        (x.PromoName.Contains(txtSearch.Text.ToUpper())) || x.Active == active).ToList();
            }
            _list = response;
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = _list;
            lblTotal.Text = "Total Record(s): " + _list.Count.ToString("N0");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //int PromoId = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value.ToString());
            FrmPromoAddProduct frm = new FrmPromoAddProduct();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadData();
                MessageBox.Show("Promo added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            
            //AddProductDiscounted frm = new AddProductDiscounted();
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    loadData();
            //    MessageBox.Show("Product discounted added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int PromoId = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value.ToString());
            if (e.ColumnIndex == 7)
            {
                FrmPromoEditProduct frm = new FrmPromoEditProduct(PromoId);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    loadData();
                    MessageBox.Show("Promo updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
            }
            //if (e.ColumnIndex == 4)
            //{
            //    EditProductDiscounted frm = new EditProductDiscounted(productId);
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        loadData();
            //        MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    };
            //}
            //if (e.ColumnIndex == 5)
            //{
            //    if (MessageBox.Show("Are you sure do want to delete?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //    {
            //        factory.ProductsDiscountedRepository.Delete(productId);
            //        loadData();
            //        MessageBox.Show("deleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (e.Value.ToString() == "1")
                {
                    e.Value = "Active";
                }
                else
                {
                    e.Value = "Not Active";
                }
            }
           
        }
    }
}
