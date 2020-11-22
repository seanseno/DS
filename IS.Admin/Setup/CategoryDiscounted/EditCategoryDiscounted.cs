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
    public partial class EditCategoryDiscounted : BaseForm
    {
        ISFactory factory = new ISFactory();
        String _CategoryId { get; set; }
        public EditCategoryDiscounted(string CategoryId)
        {
            InitializeComponent();
            _CategoryId = CategoryId;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (chkPWD.Checked == false && chkSenior.Checked == false)
            {
                MessageBox.Show("Please Select discounted type", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var obj = new CategoryDiscounted();
                obj.CategoryId = cboCategories.SelectedValue.ToString();
                obj.IsPWD = chkPWD.Checked == true ? 1 : 0;
                obj.IsSenior = chkSenior.Checked == true ? 1 : 0;
                factory.CategoryDiscountedRepository.Update(obj);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void EditCategoryDiscounted_Load(object sender, EventArgs e)
        {
            var obj = factory.CategoryDiscountedRepository.GetList().Where(x => x.CategoryId == _CategoryId).FirstOrDefault();
            if (obj != null)
            {
                var categoryList = factory.CategoriesRepository.FindWithSelect();
                cboCategories.DataSource = categoryList;
                cboCategories.DisplayMember = "CategoryName";
                cboCategories.ValueMember = "CategoryId";

                chkSenior.Checked = obj.IsSenior == 1 ? true : false;
                chkPWD.Checked = obj.IsPWD == 1 ? true : false;
                cboCategories.SelectedIndex = cboCategories.FindStringExact(obj.CategoryName);

                chkSenior.Focus();
            }
        }
    }
}
