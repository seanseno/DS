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
    public partial class FrmEditAdministrator : BaseForm
    {
        private Administrators _Administrator { get;set;}
        public FrmEditAdministrator(Administrators Administrator)
        {
            InitializeComponent();
            this._Administrator = Administrator;
        }

        private void FrmEditAdministrator_Load(object sender, EventArgs e)
        {
            AdministratorsModel Administrators = new AdministratorsModel();
            var response = Administrators.LoadEdit(_Administrator.AdminId);
            txtLogiName.Text = response.Loginname;
            txtFullName.Text = response.Fullname;
            lblId.Text = response.AdminId;
            chkActive.Checked = Convert.ToBoolean(response.Active);
            this.ActiveControl = txtFullName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!CheckInput())
            {
                AdministratorsModel Administrators = new AdministratorsModel();
                _Administrator.Fullname = txtFullName.Text;
                _Administrator.Password = txtPassword.Text;
                _Administrator.Active = Convert.ToInt32(chkActive.Checked);
                Administrators.UpdateAdministrator(_Administrator);
                this.DialogResult = DialogResult.OK;
            }

        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Full Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Full Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Focus();
                return true;
            }
            else if (txtLogiName.Text.Length < 4)
            {
                MessageBox.Show("Password must be at least 6 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return true;
            }

            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                if (string.IsNullOrEmpty(txtConfirmPassword.Text))
                {
                    MessageBox.Show("Confirm password is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtConfirmPassword.Focus();
                    return true;
                }
                else if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Password does not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                    return true;
                }
                else if (txtPassword.Text.Length < 6)
                {
                    MessageBox.Show("Login Name must be at least 4 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLogiName.Focus();
                    return true;
                }
            }
  
            return false;
        }
    }
}
