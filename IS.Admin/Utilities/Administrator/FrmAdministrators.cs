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
    public partial class FrmAdministrators : Form
    {
        public FrmAdministrators()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddAdministrator frm = new FrmAddAdministrator();
            frm.ShowDialog();
            this.LoadAdministrator();

        }


        private void LoadAdministrator()
        {
            AdministratorsModel Administrators = new AdministratorsModel();
            var response = Administrators.AdministratorList(this, txtSearch.Text);
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = response;
            txtSearch.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadAdministrator();
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Administrator = new Administrators();

            Administrator.Id = (int)dgvSearch.CurrentRow.Cells[0].Value;
            Administrator.Loginname = dgvSearch.CurrentRow.Cells[1].Value.ToString();
            Administrator.Fullname = dgvSearch.CurrentRow.Cells[2].Value.ToString();

            if (e.ColumnIndex == 6) //edit
            {
                FrmEditAdministrator frm = new FrmEditAdministrator(Administrator);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadAdministrator();
                };
               
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAdministrators_Load(object sender, EventArgs e)
        {
            this.LoadAdministrator();
        }
    }
}
