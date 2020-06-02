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
    public partial class FrmCashiers : Form
    {
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
            CashiersModel Cashiers = new CashiersModel();
            var response = Cashiers.CashierList(this, txtSearch.Text);
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = response;
            txtSearch.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCashier();
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Cashier = new Cashiers();

            Cashier.Id = (int)dgvSearch.CurrentRow.Cells[0].Value;
            Cashier.Loginname = dgvSearch.CurrentRow.Cells[1].Value.ToString();
            Cashier.Fullname = dgvSearch.CurrentRow.Cells[2].Value.ToString();

            if (e.ColumnIndex == 6) //edit
            {
                FrmEditCashier frm = new FrmEditCashier(Cashier);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadCashier();
                };
               
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
    }
}
