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
    public partial class FrmEditCategory : BaseForm
    {
        ISFactory factory = new ISFactory();
        string _CategoryId { get; set; }
        Categories _Category { get; set; }
        public FrmEditCategory(string CategoryId)
        {
            InitializeComponent();
            _CategoryId = CategoryId;
        }

        private void FrmEditCategory_Load(object sender, EventArgs e)
        {
            _Category = factory.CategoriesRepository.GetList().Where(x => x.CategoryId == _CategoryId).FirstOrDefault();
            txtCategoryName.Text = _Category.CategoryName;

            if (_Category.PercentSuggestedPrice != null)
            {
                var val = _Category.PercentSuggestedPrice?.ToString("N2");
                var res = val.Substring(val.Length - 3, 3);

                if (res == ".00")
                {
                    txtPercent.Text = val.Replace(".00", "");
                }
                else
                {
                    txtPercent.Text = val;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPercent.Text))
            {
                MessageBox.Show("Percent for Suggested Price is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPercent.Focus();
            }
            else

            {
                CategoriesModel Categories = new CategoriesModel();

                if (txtCategoryName.Text != _Category.CategoryName)
                {
                    if (Categories.CheckEditDup(txtCategoryName.Text, _Category.Id))
                    {
                        MessageBox.Show(txtCategoryName.Text + " already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCategoryName.Focus();
                    }
                    else
                    {
                        _Category.CategoryName = txtCategoryName.Text;
                        _Category.PercentSuggestedPrice = Convert.ToDecimal(txtPercent.Text);
                        factory.CategoriesRepository.Update(_Category);

                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (txtCategoryName.Text == _Category.CategoryName)
                {
                    _Category.PercentSuggestedPrice = Convert.ToDecimal(txtPercent.Text);
                    factory.CategoriesRepository.Update(_Category);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void txtPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
