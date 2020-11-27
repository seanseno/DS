using IS.Admin.Model;
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
    public partial class FrmCashiers : BaseForm
    {
        ISFactory factory = new ISFactory();
        public FrmCashiers()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddCashier frm = new FrmAddCashier();
            frm.ShowDialog();
            this.LoadCashier();

        }


        private void LoadCashier()
        {
            grpLoading.Visible = true;
            grpLoading.Refresh();

            CashiersModel Cashiers = new CashiersModel();
            var response = factory.CashiersRepository.GetList()
                            .Where(x => x.CashierId.ToUpper().Contains(txtSearch.Text.ToUpper()) ||
                                x.Fullname.ToUpper().Contains(txtSearch.Text.ToUpper()))
                            .OrderBy(y => y.Fullname)
                            .ToList();
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = response;
            txtSearch.Focus();

            grpLoading.Visible = false;
            grpLoading.Refresh();
        }
        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Cashier = new Cashiers();

            Cashier.CashierId = dgvSearch.CurrentRow.Cells[0].Value.ToString();
            Cashier.Loginname = dgvSearch.CurrentRow.Cells[1].Value.ToString();
            Cashier.Fullname = dgvSearch.CurrentRow.Cells[2].Value.ToString();

            if (e.ColumnIndex == 6) //edit
            {
                FrmEditCashier frm = new FrmEditCashier(Cashier);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.LoadCashier();
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
               
            }
            if (e.ColumnIndex == 7)
            {
                if (MessageBox.Show("Are you sure do you want to delete this record?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    factory.CashiersRepository.Delete(Cashier);
                    this.LoadCashier();
                    MessageBox.Show("Row deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void FrmCashiers_Load(object sender, EventArgs e)
        {
            this.LoadCashier();

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCashier();
        }
    }
}
