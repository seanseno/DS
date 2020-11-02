using IS.Common.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.ServerInfo
{
    public partial class btnCopyPass : Form
    {
        public btnCopyPass()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLoadServer_Click(object sender, EventArgs e)
        {
            txtEncId.Text = Encryption.EncryptString(txtId.Text);
            txtEncPass.Text = Encryption.EncryptString(txtPassword.Text); 

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtEncId.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtEncPass.Text);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
