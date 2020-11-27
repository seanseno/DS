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
    public partial class FrmAddCategory : BaseForm
    {
        public Categories _Categories = new Categories();
        ISFactory factory = new ISFactory();
        public FrmAddCategory()
        {
            InitializeComponent();
            this.ActiveControl = txtCategoryId;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!CheckInput())
            {
                _Categories.CategoryId = txtCategoryId.Text;
                _Categories.CategoryName = txtCategoryName.Text;

                if (!string.IsNullOrEmpty(txtPercent.Text))
                {
                    _Categories.PercentSuggestedPrice = Convert.ToDecimal(txtPercent.Text);
                }
  
                if (factory.CategoriesRepository.CategoriesStrategy.CheckDuplicate(txtCategoryId.Text.ToUpper(), txtCategoryName.Text.ToUpper()))
                {
                    MessageBox.Show(_Categories.CategoryName + " already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCategoryName.Focus();
                    return;
                }
                if (MessageBox.Show("Continue saving " + txtCategoryName.Text + ".", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    factory.CategoriesRepository.Insert(_Categories);
                    MessageBox.Show(txtCategoryName.Text + " Added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private bool CheckInput()
        {
            if(string.IsNullOrEmpty(txtCategoryName.Text) || string.IsNullOrEmpty(txtCategoryId.Text))
            {
                MessageBox.Show("Incomplete Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCategoryName.Focus();
                return true;
            }
            return false;
        }

        private void FrmAddCategory_Load(object sender, EventArgs e)
        {
            CategoriesModel categoriesModel = new CategoriesModel();
            txtCategoryId.Text = categoriesModel.GetNextId();
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
