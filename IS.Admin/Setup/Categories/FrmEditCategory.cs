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
    public partial class FrmEditCategory : Form
    {
        private Categories _Category { get;set;}
        public FrmEditCategory(Categories Category)
        {
            InitializeComponent();
            this._Category = Category;
        }

        private void FrmEditCategory_Load(object sender, EventArgs e)
        {
            CategoriesModel Categories = new CategoriesModel();
            var response = Categories.LoadEdit(_Category.CategoryId);
            txtCategoryName.Text = response.CategoryName;
            txtPercent.Text = response.PercentSuggestedPrice.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CategoriesModel Categories = new CategoriesModel();

            if (txtCategoryName.Text == _Category.CategoryName && _Category.PercentSuggestedPrice != Convert.ToDecimal(txtPercent.Text))
            {
                _Category.CategoryName = txtCategoryName.Text;
                _Category.PercentSuggestedPrice = Convert.ToDecimal(txtPercent.Text);
                Categories.UpdateCategory(_Category);
                this.DialogResult = DialogResult.OK;
            }
            else if (txtCategoryName.Text != _Category.CategoryName)
            {
                _Category.CategoryName = txtCategoryName.Text;
                _Category.PercentSuggestedPrice = Convert.ToDecimal(txtPercent.Text);
                if (Categories.CheckEditDup(_Category.CategoryName, _Category.Id))
                {
                    MessageBox.Show(_Category.CategoryName + " already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCategoryName.Focus();
                }
                else
                {
                    Categories.UpdateCategory(_Category);

                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
