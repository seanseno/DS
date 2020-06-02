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
            var response = Categories.LoadEdit(_Category.Id);
            txtName.Text = response.CategoryName;
            txtDescription.Text = response.Description;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CategoriesModel Categories = new CategoriesModel();
            _Category.CategoryName = txtName.Text;
            _Category.Description = txtDescription.Text;
            if (Categories.CheckEditDup(_Category.CategoryName, _Category.Id))
            {
                MessageBox.Show(_Category.CategoryName + " already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
            }
            else
            {
                Categories.UpdateCategory(_Category);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
