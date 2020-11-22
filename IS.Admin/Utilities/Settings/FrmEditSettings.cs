using IS.Database;
using IS.Database.Entities;
using IS.Database.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Admin.Utilities
{
    public partial class FrmEditSettings : BaseForm
    {
        ISFactory factory = new ISFactory();
        public FrmEditSettings()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEditSettings_Load(object sender, EventArgs e)
        {
            var response = factory.SettingsRepository.GetList().FirstOrDefault();
            if (response != null)
            {
                txtExpiration.Text = response.ExpirationAlert.ToString("N0");
                txtReturnItem.Text = response.ReturnItem.ToString("N0");
                txtSenior.Text = response.ExpirationAlert.ToString("N2");
                txtPwd.Text = response.ExpirationAlert.ToString("N2");
                chkPrinter.Checked = response.WithPrinter == (int)EnumActive.Active ;
            }
        }

        private void txtEpiration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtReturnItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSenior_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                if (MessageBox.Show("Are you sure do want to update this setting?", "information.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var setting = factory.SettingsRepository.GetList().FirstOrDefault();
                    setting.ExpirationAlert = Convert.ToInt32(txtExpiration.Text);
                    setting.ReturnItem = Convert.ToInt32(txtReturnItem.Text);
                    setting.SeniorDiscount = Convert.ToDecimal(txtSenior.Text);
                    setting.PWDDiscount = Convert.ToDecimal(txtPwd.Text);
                    setting.WithPrinter = Convert.ToInt32(chkPrinter.Checked);
                    factory.SettingsRepository.Update(setting);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private bool checkInput()
        {
            bool IsOk = true;
            if (string.IsNullOrEmpty(txtExpiration.Text))
            {
                MessageBox.Show("Expiration alert is required.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExpiration.Focus();
                IsOk = false;
            }
            else if (string.IsNullOrEmpty(txtReturnItem.Text))
            {
                MessageBox.Show("Return item is required.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReturnItem.Focus();
                IsOk = false;
            }
            else if (string.IsNullOrEmpty(txtSenior.Text))
            {
                MessageBox.Show("Senior discount is required.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenior.Focus();
                IsOk = false;
            }
            else if (string.IsNullOrEmpty(txtPwd.Text))
            {
                MessageBox.Show("PWD discount is required.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPwd.Focus();
                IsOk = false;
            }
            return IsOk;
        }
    }
}
