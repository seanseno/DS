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
    public partial class AddCategoryDiscounted : BaseForm
    {
        ISFactory factory = new ISFactory();
        public AddCategoryDiscounted()
        {
            InitializeComponent();
            this.ActiveControl = cboCategories;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboCategories.SelectedValue == null)
            {
                MessageBox.Show("Categories is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboCategories.Focus();
            }
            else if (chkPWD.Checked == false && chkSenior.Checked == false)
            {
                MessageBox.Show("Please Select discounted type", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure save this record?", "Information.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var obj = new CategoryDiscounted();
                    obj.CategoryId =  cboCategories.SelectedValue.ToString();
                    obj.IsPWD = chkPWD.Checked == true ? 1 : 0;
                    obj.IsSenior = chkSenior.Checked == true ? 1 : 0;
                    factory.CategoryDiscountedRepository.Insert(obj);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void AddCategoryDiscounted_Load(object sender, EventArgs e)
        {
            var categoryList = factory.CategoriesRepository.FindWithSelect();
            cboCategories.DataSource = categoryList;
            cboCategories.DisplayMember = "CategoryName";
            cboCategories.ValueMember = "CategoryId";
        }
    }
}

