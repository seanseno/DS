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
    public partial class FrmEditBrand : Form
    {
        private Brands _Brand { get;set;}
        public FrmEditBrand(Brands brand)
        {
            InitializeComponent();
            this._Brand = brand;
        }

        private void FrmEditBrand_Load(object sender, EventArgs e)
        {
            BrandsModel brands = new BrandsModel();
            var response = brands.LoadEdit(_Brand.Id);
            txtName.Text = response.Name;
            txtDescription.Text = response.Description;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BrandsModel brands = new BrandsModel();
            _Brand.Name = txtName.Text;
            _Brand.Description = txtDescription.Text;
            if (brands.CheckEditDup(_Brand.Name, _Brand.Id))
            {
                MessageBox.Show(_Brand.Name + " already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
            }
            else
            {
                brands.UpdateBrand(_Brand);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
