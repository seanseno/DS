using IS.Admin.Model;
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
        public FrmCategories()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddCategory frm = new FrmAddCategory();
            frm.ShowDialog();
            this.LoadCategory();
            DisplayTotal();
        }

        private void LoadCategory()
        {
            grpLoading.Visible = true;
            grpLoading.Refresh();

            CategoriesModel Categories = new CategoriesModel();
            _list = Categories.CategoryList(this, txtSearch.Text);
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = _list;
            txtSearch.Focus();

            grpLoading.Visible = false;
            grpLoading.Refresh();
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Category = new Categories
            {
                CategoryId = dgvSearch.CurrentRow.Cells[0].Value.ToString(),
                CategoryName = dgvSearch.CurrentRow.Cells[1].Value.ToString(),
            };

            if (e.ColumnIndex == 3)
            {
                FrmEditCategory frm = new FrmEditCategory(Category);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadCategory();
                };

                //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
            }
            if (e.ColumnIndex == 4)
            {
                var model = new CategoriesModel();
                if (model.CheckCategoryIfAlreadyInUse(Category.CategoryId))
                {
                    MessageBox.Show("You can not delete " + Category  + " because this Category already in use", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure do want to delete " + Category.CategoryName + ".", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        model.DeleteCategory(Category);
                        this.LoadCategory();
                        DisplayTotal();
                        MessageBox.Show(Category.CategoryName + " deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DisplayTotal();
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
            DisplayTotal();
        }
    }
}
