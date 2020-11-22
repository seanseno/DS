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
            txtPercent.Text = _Category.PercentSuggestedPrice?.ToString("N2");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
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
            //else if (txtCategoryName.Text == _Category.CategoryName && _Category.PercentSuggestedPrice != Convert.ToDecimal(txtPercent.Text))
            //{
            //    _Category.CategoryName = txtCategoryName.Text;
            //    _Category.PercentSuggestedPrice = Convert.ToDecimal(txtPercent.Text);
            //    factory.CategoriesRepository.Update(_Category);
            //    this.DialogResult = DialogResult.OK;
            //}
        }
    }
}
