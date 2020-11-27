using IS.Admin.Model;
using IS.Common.Utilities;
using IS.Database;
using IS.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Admin.Setup
{
    public partial class FrmChangePassword : BaseForm
    {
        ISFactory factory = new ISFactory();
        Administrators _Administrators = new Administrators();
        FrmMain _FrmMain = new FrmMain();
        public FrmChangePassword(FrmMain frmMain)
        {
            InitializeComponent();
            _FrmMain = frmMain;
        }

        private void FrmEditAdministrator_Load(object sender, EventArgs e)
        {
            _Administrators = factory.AdministratorsRepository.GetList().Where(x => x.Loginname == Globals.LoginName).FirstOrDefault();
            lblId.Text = _Administrators.AdminId;
            txtLogiName.Text = _Administrators.Loginname;
            txtFullName.Text = _Administrators.Fullname;
            this.ActiveControl = txtOldPassword;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                _Administrators.AdminId = lblId.Text;
                _Administrators.Loginname = txtLogiName.Text;
                _Administrators.Fullname = txtFullName.Text;
                _Administrators.Password = txtPassword.Text;
                factory.AdministratorsRepository.Update(_Administrators);
                MessageBox.Show("Password Changed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }

        }

        private bool CheckInput()
        {
            var IsEncrypt = Convert.ToBoolean(ConfigurationManager.AppSettings["Encrypt"]);
            if (string.IsNullOrEmpty(txtOldPassword.Text))
            {
                MessageBox.Show("Old password is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOldPassword.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Password is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                MessageBox.Show("Confirm password is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPassword.Focus();
                return true;
            }
            else if (txtOldPassword.Text != Encryption.Decrypt(_Administrators.Password, IsEncrypt))
            {
                MessageBox.Show("Incorrect Old Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOldPassword.Focus();
                return true;
            } 
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password does not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return true;
            }
            else if (txtOldPassword.Text == txtPassword.Text)
            {
                MessageBox.Show("New password is your current password!, please enter a new password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return true;
            }
            return false;
        }
    }
}
