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
    public partial class FrmAddCategory : Form
    {
        public Categories _Categories = new Categories();
        public FrmAddCategory()
        {
            InitializeComponent();
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
                var CategoriesModel = new CategoriesModel();
                _Categories.CategoryName = txtName.Text.ToUpper();
                _Categories.Description = txtDescription.Text.ToUpper();

                if (CategoriesModel.CheckDup(this))
                {
                    MessageBox.Show(_Categories.CategoryName + " already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Focus();
                    return;
                }
                if (MessageBox.Show("Continue saving " + txtName.Text + ".", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    CategoriesModel.AddCategory(this);
                    MessageBox.Show(txtName.Text + " Added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void FrmAddCategory_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtName;
        }

        private bool CheckInput()
        {
            if(string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Incomplete Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return true;
            }
            return false;
        }

    }
}
