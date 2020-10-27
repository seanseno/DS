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
    public partial class AddProductDiscounted : BaseForm
    {
        ISFactory factgory = new ISFactory();
        public AddProductDiscounted()
        {
            InitializeComponent();
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            FrmModalSearchProducts frm = new FrmModalSearchProducts();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtProductId.Text = frm._ProductId;
                txtProductName.Text = frm._ProductName;
                chkSenior.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductId.Text))
            {
                MessageBox.Show("Product is required", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (chkPWD.Checked == false && chkSenior.Checked == false)
            {
                MessageBox.Show("Please Select discounted type", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure save this record?", "Information.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var obj = new ProductsDiscounted();
                    obj.ProductId = txtProductId.Text;

                    obj.IsPWD = chkPWD.Checked == true ? 1 : 0;
                    obj.IsSenior = chkSenior.Checked == true ? 1 : 0;
                    factgory.ProductsDiscountedRepository.Insert(obj);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
