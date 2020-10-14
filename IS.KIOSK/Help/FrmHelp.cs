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
    public partial class FrmHelp : Form
    {
        ISFactory factory = new ISFactory();
        public FrmHelp()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }


        private void LoadData()
        {
            var response = factory.QuestionsRepository.GetList().OrderByDescending(x => x.InsertTime).ToList();
            
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                response = response.Where(x => x.Question.ToUpper().Contains(txtSearch.Text.ToUpper()) ||
                    x.Answer.ToUpper().Contains(txtSearch.Text.ToUpper())).ToList();
            }

            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = response;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        //private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == 0) //sellect
        //    {
        //        var StockDataId = Convert.ToInt32(dgvSearch.CurrentRow.Cells[7].Value.ToString());
        //        var Qty = Convert.ToInt32(dgvSearch.CurrentRow.Cells[5].Value.ToString());
        //        if (Qty > 0)
        //        {
        //            var SalesId = Convert.ToInt32(dgvSearch.CurrentRow.Cells[8].Value.ToString());
        //            var ProductName = dgvSearch.CurrentRow.Cells[3].Value.ToString();
        //            FrmReturnItemUpdate frm = new FrmReturnItemUpdate(StockDataId, SalesId, ProductName);
        //            if (frm.ShowDialog() == DialogResult.OK)
        //            {
        //                LoadData();
        //                MessageBox.Show("Settings updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            };
        //        }
        //        else
        //        {
        //            MessageBox.Show("Not enough quanity", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        private void dgvSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) 
            {
                btnSelect_Click(sender, e);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void FrmReturnItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27) // Exit
            {
                this.btnClose_Click(sender, e);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
           
            var Question = dgvSearch.CurrentRow.Cells[1].Value.ToString();
            var Answer = dgvSearch.CurrentRow.Cells[2].Value.ToString();

            FrmHelpView frm = new FrmHelpView(Question, Answer);
            frm.ShowDialog();
 
        }

        private void FrmHelp_Load(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}
