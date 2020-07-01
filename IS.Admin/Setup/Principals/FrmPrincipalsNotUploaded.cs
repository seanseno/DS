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

namespace IS.Admin.Setup
{
    public partial class FrmPrincipalsNotUploaded : Form
    {
        IList<Principals> ErrorList = new List<Principals>();
        public FrmPrincipalsNotUploaded(IList<Principals> errorList)
        {
            InitializeComponent();
            ErrorList = errorList;
            this.ActiveControl = txtSearch;
        }


        private void LoadProducts()
        {
            PrincipalsModel model = new PrincipalsModel();

            var searchList = ErrorList.Where(x => x.PrincipalName.Contains(txtSearch.Text.ToUpper()) ||
                x.PrincipalId.Contains(txtSearch.Text.ToUpper())).ToList();

            dgvSearch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvSearch.DataSource = null;
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = searchList;

            lblTotalCount.Text = "Total Count: " + searchList.Count().ToString("N0");
            lblTotalCount.Refresh();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmPrincipalsNotUploaded_Shown(object sender, EventArgs e)
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

        private void FrmPrincipalsNotUploaded_Load(object sender, EventArgs e)
        {

        }
    }
}
