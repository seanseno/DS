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

namespace IS.KIOSK
{
    public partial class FrmEditQtyItem : BaseForm
    {
        public IList<TempSales> _TempOrderList { get; set; }
        public FrmEditQtyItem(IList<TempSales> tempsales)
        {
            InitializeComponent();
            _TempOrderList = tempsales;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmEditQtyItem_Load(object sender, EventArgs e)
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = _TempOrderList;
            dgvList.StandardTab = true;
        }

        private void dgvList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 45)
            {
                var product = dgvList.CurrentRow.Cells[2].Value.ToString();
                var qty = dgvList.CurrentRow.Cells[3].Value.ToString();
                FrmEntryQty frm = new FrmEntryQty(product,qty);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {

        }
    }
}
