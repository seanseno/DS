using IS.Common.Utilities;
using IS.Database;
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
    public partial class FrmHelpView : Form
    {

        ISFactory factory = new ISFactory();
        int _Qty { get; set; }
        public FrmHelpView(string question,string answer)
        {
            InitializeComponent();
            txtQuestion.Text = question;
            txtAnswer.Text = answer;
            this.ActiveControl = txtAnswer;
            this.KeyPreview = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmHelpView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27) // Exit
            {
                this.btnCancel_Click(sender, e);
            }
        }
    }
}
