using IS.Database;
using IS.Database.Entities;
using IS.Database.Enums;
using IS.KIOSK.Model;
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
    public partial class FrmLoadSaveOrders : Form
    {
        LoadSaveOrdersModel loadSaveOrdersModel = new LoadSaveOrdersModel();
        FrmMain _FrmMain = new FrmMain();
        ISFactory factory = new ISFactory();
        public FrmLoadSaveOrders(FrmMain frmMain)
        {
            InitializeComponent();
            this._FrmMain = frmMain;
        }

        private void FrmLoadSaveOrders_Load(object sender, EventArgs e)
        {
            dgvTempLedger.AutoGenerateColumns = false;
            var listLoaded = loadSaveOrdersModel.LoadSaveOrderList(_FrmMain);
            dgvTempLedger.DataSource = listLoaded;
            dgvTempLedger.StandardTab = true;

            if (listLoaded.Count <= 0)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void dgvTempLedger_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (dgvTempLedger.Rows.Count != 0)
                {
                    this.DialogResult = DialogResult.OK;
                    var id = dgvTempLedger.CurrentRow.Cells[0].Value;
                    loadSaveOrdersModel.Select(_FrmMain, Convert.ToInt32(id));
                }
            }
            if (e.KeyValue == 27)
            {
                this.Close();
            }
        }
    }
}
