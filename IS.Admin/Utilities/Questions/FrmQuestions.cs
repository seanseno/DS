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

namespace IS.Admin.Utilities
{
    public partial class FrmQuestions : Form
    {
        ISFactory factory = new ISFactory();
        public FrmQuestions()
        {
            InitializeComponent();
        }

        private void FrmReturnItemSettings_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void LoadData()
        {
            var response = factory.QuestionsRepository.GetList().OrderBy(x=>x.Id).ToList();
            response = response.Where(x => x.Question.ToUpper().Contains(txtSearch.Text.ToUpper())).ToList();
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = response;
            lblTotal.Text = "Total Record(s) : " + response.Count().ToString("N0");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddQuestions frm = new FrmAddQuestions();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Id = Convert.ToInt32(dgvSearch.CurrentRow.Cells[0].Value.ToString());
            string Question = dgvSearch.CurrentRow.Cells[1].Value.ToString();
            string Answer = dgvSearch.CurrentRow.Cells[2].Value.ToString();
            if (e.ColumnIndex == 3) //edit
            {
                FrmEditQuestions frm = new FrmEditQuestions(Id, Question, Answer);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    MessageBox.Show("Question updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
            }
            if (e.ColumnIndex == 4) //Delete
            {
                {
                    if (MessageBox.Show("Are you sure do you want to delete this record?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        factory.QuestionsRepository.Delete(Id);
                        LoadData();
                        MessageBox.Show("Row deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
