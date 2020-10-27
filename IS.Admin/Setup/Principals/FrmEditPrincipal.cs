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
    public partial class FrmEditPrincipal : BaseForm
    {
        private Principals _Principal { get;set;}
        public FrmEditPrincipal(Principals Principal)
        {
            InitializeComponent();
            this._Principal = Principal;
        }

        private void FrmEditPrincipal_Load(object sender, EventArgs e)
        {
            PrincipalsModel Principals = new PrincipalsModel();
            var response = Principals.LoadEdit(_Principal.PrincipalId);
            txtPrincipalName.Text = response.PrincipalName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PrincipalsModel Principals = new PrincipalsModel();
            _Principal.PrincipalName = txtPrincipalName.Text;
            if (Principals.CheckEditDup(_Principal.PrincipalName, _Principal.Id))
            {
                MessageBox.Show(_Principal.PrincipalName + " already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrincipalName.Focus();
            }
            else
            {
                Principals.UpdatePrincipal(_Principal);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
