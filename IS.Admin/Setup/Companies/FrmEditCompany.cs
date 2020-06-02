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
    public partial class FrmEditCompany : Form
    {
        private Companies _Company { get;set;}
        public FrmEditCompany(Companies company)
        {
            InitializeComponent();
            this._Company = company;
        }

        private void FrmEditCompany_Load(object sender, EventArgs e)
        {
            CompaniesModel companies = new CompaniesModel();
            var response = companies.LoadEdit(_Company.Id);
            txtName.Text = response.CompanyName;
            txtDescription.Text = response.Description;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CompaniesModel companies = new CompaniesModel();
            _Company.CompanyName = txtName.Text;
            _Company.Description = txtDescription.Text;
            if (companies.CheckEditDup(_Company.CompanyName, _Company.Id))
            {
                MessageBox.Show(_Company.CompanyName + " already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
            }
            else
            {
                companies.UpdateCompany(_Company);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
