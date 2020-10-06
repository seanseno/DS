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
    public partial class FrmStockExpireReport : Form
    {
        ISFactory factory = new ISFactory();
        IList<StocksDataExpireViewReport> _list = new List<StocksDataExpireViewReport>();
        public FrmStockExpireReport()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var response = factory.StocksDataRepository.GetListStocksDataExpireReport();
            var days = factory.SettingsRepository.GetList()[0].ExpirationAlert;
            DateTime date = DateTimeConvertion.ConvertDateTo(DateTime.Now.AddDays(days));
            response = response.Where(x => x.ExpirationDate <= date).ToList();
            response = response.Where(x => x.CategoryName.Contains(txtSearch.Text.Trim().ToUpper()) ||
                        x.PrincipalName.Contains(txtSearch.Text.Trim().ToUpper()) ||
                        x.ProductName.Contains(txtSearch.Text.Trim().ToUpper())).ToList();
            dgvSales.AutoGenerateColumns = false;
            dgvSales.DataSource = response;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
