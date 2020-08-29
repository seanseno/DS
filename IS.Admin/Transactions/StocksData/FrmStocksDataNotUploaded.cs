using IS.Admin.Model;
using IS.Common.Reader;
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

namespace IS.Admin.Transactions
{
    public partial class FrmStocksDataNotUploaded : Form
    {
        IList<StocksData> ErrorList = new List<StocksData>();
        public FrmStocksDataNotUploaded(IList<StocksData> errorList)
        {
            InitializeComponent();
            ErrorList = errorList;
            this.ActiveControl = txtSearch;
        }


        private void LoadProducts()
        {
            //StocksDataModel model = new StocksDataModel();

            //var searchList = ErrorList.Where(x => x.CategoryName.Contains(txtSearch.Text.ToUpper()) ||
            //    x.CategoryId.Contains(txtSearch.Text.ToUpper())).ToList();

            //dgvSearch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //dgvSearch.DataSource = null;
            //dgvSearch.AutoGenerateColumns = false;
            //dgvSearch.DataSource = searchList;

            //lblTotalCount.Text = "Total Count: " + searchList.Count().ToString("N0");
            //lblTotalCount.Refresh();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void FrmStocksDataNotUploaded_Shown(object sender, EventArgs e)
        {
            grpLoading.Visible = true;
            grpLoading.Refresh();

            this.LoadProducts();

            grpLoading.Visible = false;
            grpLoading.Refresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void FrmStocksDataNotUploaded_Load(object sender, EventArgs e)
        {

        }
    }
}
