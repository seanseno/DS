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
    public partial class FrmPrincipals : BaseForm
    {
        IList<Principals> _list = new List<Principals>();
        public FrmPrincipals()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddPrincipal frm = new FrmAddPrincipal();
            frm.ShowDialog();
            this.LoadPrincipal();
            DisplayTotal();

        }

        private void LoadPrincipal()
        {
            grpLoading.Visible = true;
            grpLoading.Refresh();

            PrincipalsModel Principals = new PrincipalsModel();
             _list = Principals.PrincipalList(this, txtSearch.Text);
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = _list;
            txtSearch.Focus();

            grpLoading.Visible = false;
            grpLoading.Refresh();
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Principal = new Principals
            {
                PrincipalId = dgvSearch.CurrentRow.Cells[0].Value.ToString(),
                PrincipalName = dgvSearch.CurrentRow.Cells[1].Value.ToString(),
            };

            if (e.ColumnIndex == 2)
            {
                FrmEditPrincipal frm = new FrmEditPrincipal(Principal);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Record updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadPrincipal();
                };

                //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
            }
            if (e.ColumnIndex == 3)
            {
                var model = new PrincipalsModel();
                if (model.CheckPrincipalIfAlreadyInUse(Principal.PrincipalId))
                {
                    MessageBox.Show("You can not delete " + Principal  + " because this Principal already in use", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure do want to delete " + Principal.PrincipalName + ".", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        model.DeletePrincipal(Principal);
                        this.LoadPrincipal();
                        DisplayTotal();
                        MessageBox.Show(Principal.PrincipalName + " deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void DisplayTotal()
        {
            string TotalStr = "Total Record 0";
            if (_list.Count() > 1)
            {
                TotalStr = "Total Record(s) " + _list.Count().ToString("N0");
            }
            else if (_list.Count() == 1)
            {
                TotalStr = "Total Record " + _list.Count().ToString("N0");
            }
            lblTotal.Text = TotalStr;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            FrmPrincipalsUploadExcel frm = new FrmPrincipalsUploadExcel();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.LoadPrincipal();
                DisplayTotal();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPrincipal();
        }

        private void FrmPrincipals_Load(object sender, EventArgs e)
        {
            this.LoadPrincipal();
            DisplayTotal();
        }
    }
}
