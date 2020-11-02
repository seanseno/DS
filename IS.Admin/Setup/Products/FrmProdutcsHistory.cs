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
    public partial class FrmProdutcsHistory : BaseForm
    {
        ISFactory factory = new ISFactory();
        string _ProductId { get; set; }
        public FrmProdutcsHistory(string ProductId)
        {
            InitializeComponent();
            this._ProductId = ProductId;
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
            var response = factory.ProductsHistoryRepository.GetList();
            var list = response.Where(x=>x.ProductId == _ProductId).OrderByDescending(x => x.InsertTime).ToList();
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = list;
            lblTotal.Text = "Total Record(s) :" + list.Count();
        }

        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (e.Value.ToString() == "1")
                {
                    e.Value = "Active";
                }
                else
                {
                    e.Value = "In Active";
                }
            }
        }
    }
}
