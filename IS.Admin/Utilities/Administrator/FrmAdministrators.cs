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
            grpLoading.Visible = true;
            grpLoading.Refresh();

            AdministratorsModel Administrators = new AdministratorsModel();
            var response = Administrators.AdministratorList(this, txtSearch.Text);
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = response;
            txtSearch.Focus();

            grpLoading.Visible = false;
            grpLoading.Refresh();
        }
        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Administrator = new Administrators();

            Administrator.AdminId = dgvSearch.CurrentRow.Cells[0].Value.ToString();
            Administrator.Loginname = dgvSearch.CurrentRow.Cells[1].Value.ToString();
            Administrator.Fullname = dgvSearch.CurrentRow.Cells[2].Value.ToString();

            if (e.ColumnIndex == 7) //edit
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAdministrator();
        }

        private void FrmAdministrators_Shown(object sender, EventArgs e)
        {
            LoadAdministrator();
        }
    }
}
