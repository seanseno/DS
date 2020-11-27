using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.KIOSKBARCODE
{
    public partial class FrmSeniorCitizen : BaseForm
    {
        public FrmSeniorCitizen()
        {
            InitializeComponent();
            this.ActiveControl = txtCustomerName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (string.IsNullOrEmpty(txtCustomerName.Text))
                {
                    MessageBox.Show("Customer Name is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCustomerName.Focus();
                }
                else
                {
                    txtAdditionalInfo.Focus();
                }
            }
            if (e.KeyValue == 27)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Proceed();
        }
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                MessageBox.Show("Customer Name is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(txtAdditionalInfo.Text))
            {
                MessageBox.Show("Addtional Information is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAdditionalInfo.Focus();
                return true;
            }
            return false;
        }
        private void Proceed()
        {
            if (!CheckInput())
            {
                this.DialogResult = DialogResult.OK;

            }
        }

        private void txtAdditionalInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                Proceed();
            }
            if (e.KeyValue == 27)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
