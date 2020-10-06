using IS.Common.Utilities;
using IS.Database;
using IS.Database.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Admin.Reports
{
    public partial class FrmStocksReport : Form
    {
        ISFactory factory = new ISFactory();
        IList<StocksDataViewReport> _list = new List<StocksDataViewReport>();
        public FrmStocksReport()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var response = factory.StocksDataRepository.GetListStocksDataReport();

            response = response.Where(x => DateTimeConvertion.ConvertDateFrom(dtpFrom.Value) <= x.DeliveryDate && x.DeliveryDate <= DateTimeConvertion.ConvertDateTo(dtpTo.Value)).ToList();

            response = response.Where(x => x.CategoryName.Contains(txtSearch.Text.Trim().ToUpper()) ||
                x.ProductName.Contains(txtSearch.Text.Trim().ToUpper())).ToList();

            _list = response;
            dgvSales.AutoGenerateColumns = false;
            dgvSales.DataSource = _list;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
