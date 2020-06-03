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

namespace IS.Admin.Trasactions
{
    public partial class FrmInputRequestOrdersName : Form
    {
        ISFactory factory = new ISFactory();
        FrmItemRequestOrderList _FrmMain = new FrmItemRequestOrderList();
        RequestOrderItemsModel requestOrderItemsModel = new RequestOrderItemsModel();
        public FrmInputRequestOrdersName(FrmItemRequestOrderList model)
        {
            InitializeComponent();
            this._FrmMain = model;
            this.ActiveControl = txtOrdersName;
        }


        private void btnAccept_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtOrdersName.Text))
            {
                MessageBox.Show("Request Orders Name is Required!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOrdersName.Focus();
            }
            else
            {
                if(requestOrderItemsModel.CheckDupRequestName(txtOrdersName.Text))
                {
                    MessageBox.Show("Request orders name already exist!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOrdersName.Focus();
                }
                else
                {
                    _FrmMain.OdersName = txtOrdersName.Text;
                    this.DialogResult = DialogResult.OK;
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
