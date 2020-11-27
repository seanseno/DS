using IS.Admin.Model;
using IS.Common.Utilities;
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
    public partial class FrmAdministrators : BaseForm
    {
        ISFactory factory = new ISFactory();
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

            var response = factory.AdministratorsRepository.GetList()
                .Where(x => x.AdminId.ToUpper().Contains(txtSearch.Text.ToUpper()) ||
                    x.Loginname.ToUpper().Contains(txtSearch.Text.ToUpper()) ||
                    x.Fullname.ToUpper().Contains(txtSearch.Text.ToUpper())).OrderBy(x => x.Fullname).ToList();

            if (Globals.LoginName.ToUpper() != "ADMIN")
            {
                response = response.Where(x => x.Loginname.ToUpper() != "ADMIN").ToList();
            }

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

            if (e.ColumnIndex == 6) //edit
            {
                FrmEditAdministrator frm = new FrmEditAdministrator(Administrator);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.LoadAdministrator();
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
            }
            if (e.ColumnIndex == 7)
            {
                if (MessageBox.Show("Are you sure do you want to delete this record?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    factory.AdministratorsRepository.Delete(Administrator);
                    this.LoadAdministrator();
                    MessageBox.Show("Row deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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


        private void FrmAdministrators_Load(object sender, EventArgs e)
        {
            LoadAdministrator();
        }

        private void dgvSearch_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.Value.ToString() == "1")
                {
                    e.Value = "Yes";
                }
                else
                {
                    e.Value = "No";
                }
            }
        }
    }
}
