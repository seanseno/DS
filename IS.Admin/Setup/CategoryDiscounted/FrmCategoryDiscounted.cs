using IS.Database;
using IS.Database.Entities;
using IS.Database.Views;
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
    public partial class FrmCategoryDiscounted : BaseForm
    {
        ISFactory factory = new ISFactory();
        IList<CategoryDiscounted> _list = new List<CategoryDiscounted>();
        public FrmCategoryDiscounted()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            var response = factory.CategoryDiscountedRepository.GetList();
            if (response != null)
            {
                response = response.OrderBy(x => x.CategoryName).ToList();
            }
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                response = response.Where(x => x.CategoryId.ToUpper().Contains(txtSearch.Text.ToUpper()) ||
                                         x.CategoryName.ToUpper().Contains(txtSearch.Text.ToUpper())).ToList();
            }
            _list = response;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = _list;

            lblTotal.Text = "Total Record(s): " + _list.Count.ToString("N0");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCategoryDiscounted frm = new AddCategoryDiscounted();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadData();
                MessageBox.Show("Category discounted added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string CategoryId = dgv.CurrentRow.Cells[0].Value.ToString();
            if (e.ColumnIndex == 4)
            {
                EditCategoryDiscounted frm = new EditCategoryDiscounted(CategoryId);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    loadData();
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
            }
            if (e.ColumnIndex == 5)
            {
                if (MessageBox.Show("Are you sure do want to delete?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    factory.CategoryDiscountedRepository.Delete(CategoryId);
                    loadData();
                    MessageBox.Show("deleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (e.Value.ToString() == "1")
                {
                    e.Value = "True";
                }
                else
                {
                    e.Value = "False";
                }
            }
            if (e.ColumnIndex == 3)
            {
                if (e.Value.ToString() == "1")
                {
                    e.Value = "True";
                }
                else
                {
                    e.Value = "False";
                }
            }
        }

        private void FrmCategoryDiscounted_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
