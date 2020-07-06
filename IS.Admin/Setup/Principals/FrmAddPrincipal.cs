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
    public partial class FrmAddPrincipal : Form
    {
        public Principals _Principals = new Principals();
        public FrmAddPrincipal()
        {
            InitializeComponent();
            this.ActiveControl = txtPrincipalId;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!CheckInput())
            {
                var PrincipalsModel = new PrincipalsModel();
                _Principals.PrincipalId = txtPrincipalId.Text.ToUpper();
                _Principals.PrincipalName = txtPrincipalName.Text.ToUpper();

                if (PrincipalsModel.CheckDup(this))
                {
                    MessageBox.Show(_Principals.PrincipalName + " already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrincipalName.Focus();
                    return;
                }
                if (MessageBox.Show("Continue saving " + txtPrincipalName.Text + ".", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    PrincipalsModel.AddPrincipal(this);
                    MessageBox.Show(txtPrincipalName.Text + " Added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private bool CheckInput()
        {
            if(string.IsNullOrEmpty(txtPrincipalName.Text) || string.IsNullOrEmpty(txtPrincipalId.Text))
            {
                MessageBox.Show("Incomplete Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrincipalName.Focus();
                return true;
            }
            return false;
        }

        private void FrmAddPrincipal_Load(object sender, EventArgs e)
        {
            PrincipalsModel principalsModel = new PrincipalsModel();
            txtPrincipalId.Text = principalsModel.GetNextId();
        }
    }
}
