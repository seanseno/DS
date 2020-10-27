using IS.Admin.Model;
using IS.Database;
using IS.Database.Entities;
using IS.Library.Utility;
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
    public partial class FrmStocksDataHistory : BaseForm
    {
        ISFactory factory = new ISFactory();
        int Id { get; set; }
        public FrmStocksDataHistory(int id)
        {
            InitializeComponent();
            this.Id = id;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
          
        }

        private void FrmStocksDataHistory_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            var response = factory.StocksDataHistoryRepository.GetList();
            var list = response.Where(v => v.StocksDataId == Id).OrderByDescending(x => x.InsertTime).ToList();
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = list;
            lblTotal.Text = "Total Record(s) :" + list.Count();
        }
    }
}
