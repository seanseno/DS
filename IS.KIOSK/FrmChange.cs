using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.KIOSK
{
    public partial class FrmChange : BaseForm
    {
        public FrmChange(string Change)
        {
            InitializeComponent();
            lblChange.Text = Change;
        }

        private void frmChange_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void frmChange_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27) //escape
            {
                timer1.Stop();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lblChange.ForeColor == Color.FromArgb(237, 114, 116))
            {
                lblChange.ForeColor = Color.FromArgb(9, 130, 78);
            }
            else
            {
                lblChange.ForeColor = Color.FromArgb(237, 114, 116);
            }
        }
    }
}
