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
    public partial class FrmCompanies : Form
    {
        public FrmCompanies()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddCompany frm = new FrmAddCompany();
            frm.ShowDialog();
            this.LoadCompany();

        }

        private void FrmCompanies_Load(object sender, EventArgs e)
        {
            this.LoadCompany();
        }

        private void LoadCompany()
        {
            CompaniesModel companies = new CompaniesModel();
            var response = companies.CompanyList(this, txtSearch.Text);
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = response;
            txtSearch.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCompany();
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Company = new Companies
            {
                Id = (int)dgvSearch.CurrentRow.Cells[0].Value,
                CompanyName = dgvSearch.CurrentRow.Cells[1].Value.ToString(),
                Description = dgvSearch.CurrentRow.Cells[2].ToString()
            };

            if (e.ColumnIndex == 3)
            {
                FrmEditCompany frm = new FrmEditCompany(Company);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadCompany();
                };

                //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
            }
            if (e.ColumnIndex == 4)
            {
                var model = new CompaniesModel();
                if (model.CheckCompanyIfAlreadyInUse(Company.Id))
                {
                    MessageBox.Show("You can not delete " + Company.CompanyName  + " because this Company already in use", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure do want to delete " + Company.CompanyName + ".", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        model.DeleteCompany(Company);
                        this.LoadCompany();
                        MessageBox.Show(Company.CompanyName + " deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
