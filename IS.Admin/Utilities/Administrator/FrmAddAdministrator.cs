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
    public partial class FrmAddAdministrator : BaseForm
    {
        public Administrators _Administrators = new Administrators();
        ISFactory factory = new ISFactory();
        public FrmAddAdministrator()
        {
            InitializeComponent();
            this.ActiveControl = txtItemId;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                var AdministratorsModel = new AdministratorsModel();
                _Administrators.AdminId = txtItemId.Text;
                _Administrators.Loginname = txtLogiName.Text;
                _Administrators.Fullname = txtFullName.Text;
                _Administrators.Password = txtPassword.Text;
                _Administrators.Active = chkActive.Checked == true ? 1 : 0;
           
                if (factory.AdministratorsRepository.AdministratorsStrategy.CheckDuplicate(_Administrators.Loginname))
                {
                    MessageBox.Show(_Administrators.Loginname + " already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLogiName.Focus();
                }
                if (MessageBox.Show("Continue saving " + txtLogiName.Text + ".", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    factory.AdministratorsRepository.Insert(_Administrators);
                    MessageBox.Show(txtLogiName.Text + " Added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtItemId.Text))
            {
                MessageBox.Show("Item Id is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemId.Focus();
                return true;
            }
            if (string.IsNullOrEmpty(txtLogiName.Text))
            {
                MessageBox.Show("Login Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogiName.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Full Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Focus();
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
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password does not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return true;
            }
            else if (txtLogiName.Text.Length  < 4)
            {
                MessageBox.Show("Login Name must be at least 4 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogiName.Focus();
                return true;
            }
            else if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return true;
            }
            return false;
        }

        private void FrmAddAdministrator_Load(object sender, EventArgs e)
        {
            AdministratorsModel administratorsModel = new AdministratorsModel();
            txtItemId.Text = administratorsModel.GetNextId();
        }


    }
}
