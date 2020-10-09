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

namespace IS.Admin.Utilities
{
    public partial class FrmEditSettings : Form
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
                txtEpiration.Text = response.ExpirationAlert.ToString("N0");
                txtReturnItem.Text = response.ReturnItem.ToString("N0");
                txtSenior.Text = response.ExpirationAlert.ToString("N2");
                txtPwd.Text = response.ExpirationAlert.ToString("N2");
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
            var setting = factory.SettingsRepository.GetList().FirstOrDefault(); 
            setting.ExpirationAlert = Convert.ToInt32(txtEpiration.Text);
            setting.ExpirationAlert = Convert.ToInt32(txtEpiration.Text);
            setting.ExpirationAlert = Convert.ToInt32(txtEpiration.Text);
            setting.ExpirationAlert = Convert.ToInt32(txtEpiration.Text);

            factory.SettingsRepository.Update(setting);
            this.DialogResult = DialogResult.OK;
        }
    }
}
