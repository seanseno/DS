using IS.Admin.Model;
using IS.Database;
using IS.Database.Entities;
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
    public partial class FrmCategories : BaseForm
    {
        IList<Categories> _list = new List<Categories>();
        ISFactory factory = new ISFactory();
        public FrmCategories()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddCategory frm = new FrmAddCategory();
            frm.ShowDialog();
            this.LoadCategory();
        }

        private void LoadCategory()
        {
            grpLoading.Visible = true;
            grpLoading.Refresh();
            _list = factory.CategoriesRepository.GetList()
                    .Where(x => x.CategoryId.ToUpper().Contains(txtSearch.Text.ToUpper()) 
                        || x.CategoryName.ToUpper().Contains(txtSearch.Text.ToUpper())).OrderBy(y => y.CategoryName)
                    .ToList();

            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = _list;
            txtSearch.Focus();

            grpLoading.Visible = false;
            grpLoading.Refresh();

            DisplayTotal();
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var CategoryId = dgvSearch.CurrentRow.Cells[0].Value.ToString();
            var CategoryName = dgvSearch.CurrentRow.Cells[1].Value.ToString();
            if (e.ColumnIndex == 3)
            {
                FrmEditCategory frm = new FrmEditCategory(CategoryId);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadCategory();
                };
            }
            if (e.ColumnIndex == 4)
            {
               
                if (factory.CategoriesRepository.CategoriesStrategy.CategoryAlreadyInUse(CategoryId))
                {
                    MessageBox.Show("You can not delete " + CategoryName + " because this Category already in use", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure do want to delete " + CategoryName + ".", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        factory.CategoriesRepository.Delete(CategoryId);
                        this.LoadCategory();
                        MessageBox.Show(CategoryName + " deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayTotal()
        {
            string TotalStr = "Total Record 0";
            if (_list.Count() > 1)
            {
                TotalStr = "Total Record(s) " + _list.Count().ToString("N0");
            }
            else if (_list.Count() == 1)
            {
                TotalStr = "Total Record " + _list.Count().ToString("N0");
            }
            lblTotal.Text = TotalStr;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            FrmCategoriesUploadExcel frm = new FrmCategoriesUploadExcel();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.LoadCategory();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCategory();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //LoadMemoryProducts();
        }
        private void LoadMemoryProducts()
        {
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = this._list.Where(x => x.CategoryName.Contains(txtSearch.Text.ToUpper()) || x.CategoryId.Contains(txtSearch.Text.ToUpper())).OrderBy(v => v.CategoryName).ToList();
            dgvSearch.StandardTab = true;
        }

        private void FrmCategories_Load(object sender, EventArgs e)
        {
            this.LoadCategory();
           
        }

        private void dgvSearch_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (e.Value != null)
                {
                    var val = Convert.ToDecimal(e.Value).ToString("N2");
                    var res = val.Substring(val.Length - 3, 3);

                    if (res == ".00")
                    {
                        e.Value = val.Replace(".00", "") + " %";
                    }
                    else
                    {
                        e.Value = Convert.ToDecimal(e.Value).ToString("N2") + " %";
                    }
                }
            }
        }
    }
}
