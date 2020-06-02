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
    public partial class FrmBrands : Form
    {
        public FrmBrands()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddBrand frm = new FrmAddBrand();
            frm.ShowDialog();
            this.LoadBrand();

        }

        private void FrmBrands_Load(object sender, EventArgs e)
        {
            this.LoadBrand();
        }

        private void LoadBrand()
        {
            BrandsModel brands = new BrandsModel();
            var response = brands.BrandList(this, txtSearch.Text);
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = response;
            txtSearch.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBrand();
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var brand = new Brands
            {
                Id = (int)dgvSearch.CurrentRow.Cells[0].Value,
                Name = dgvSearch.CurrentRow.Cells[1].Value.ToString(),
                Description = dgvSearch.CurrentRow.Cells[2].ToString()
            };

            if (e.ColumnIndex == 3)
            {
                FrmEditBrand frm = new FrmEditBrand(brand);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadBrand();
                };

                //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
            }
            if (e.ColumnIndex == 4)
            {
                var model = new BrandsModel();
                if (model.CheckBrandIfAlreadyInUse(brand.Id))
                {
                    MessageBox.Show("You can not delete " + brand.Name  + " because this brand already in use", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure do want to delete " + brand.Name + ".", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        model.DeleteBrand(brand);
                        MessageBox.Show(brand.Name + " deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LoadBrand();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
