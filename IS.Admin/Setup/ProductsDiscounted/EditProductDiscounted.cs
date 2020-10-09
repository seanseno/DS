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
    public partial class EditProductDiscounted : Form
    {
        ISFactory factgory = new ISFactory();
        String _ProductId { get; set; }
        public EditProductDiscounted(string ProductId)
        {
            InitializeComponent();
            _ProductId = ProductId;
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
                var obj = new ProductsDiscounted();
                obj.ProductId = txtProductId.Text;

                obj.IsPWD = chkPWD.Checked == true ? 1 : 0;
                obj.IsSenior = chkSenior.Checked == true ? 1 : 0;
                factgory.ProductsDiscountedRepository.Update(obj);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void EditProductDiscounted_Load(object sender, EventArgs e)
        {
            var response = factgory.ProductsDiscountedRepository.GetList();
            if (response != null)
            {
                var obj = response.Where(x => x.ProductId == _ProductId).FirstOrDefault();
                var product = factgory.ProductsRepository.GetList().Where(x => x.ProductId == _ProductId).FirstOrDefault();

                txtProductId.Text = _ProductId;
                txtProductName.Text = product.ProductName;

                chkSenior.Checked = obj.IsSenior == 1 ? true :false;
                chkPWD.Checked  = obj.IsPWD == 1 ? true : false;
                chkSenior.Focus();
            }
        }
    }
}
