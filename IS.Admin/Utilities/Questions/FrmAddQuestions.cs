using IS.Admin.Model;
using IS.Database;
using IS.Database.Entities;
using IS.Library.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Admin.Utilities
{
    public partial class FrmAddQuestions : BaseForm
    {
        public Cashiers _Cashiers = new Cashiers();
        public string CopyPath { get; set; }
        ISFactory factory = new ISFactory();
        public FrmAddQuestions()
        {
            InitializeComponent();
            this.ActiveControl = txtQuestion;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void FrmAddCashier_Load(object sender, EventArgs e)
        {

        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtQuestion.Text))
            {
                MessageBox.Show("Question Id is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuestion.Focus();
                return true;
            }
            if (string.IsNullOrEmpty(txtAnswer.Text))
            {
                MessageBox.Show("Answer is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAnswer.Focus();
                return true;
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                var Questions = new Questions();
                Questions.Question = txtQuestion.Text;
                Questions.Answer = txtAnswer.Text;

                if (MessageBox.Show("Continue saving?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    factory.QuestionsRepository.Insert(Questions);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
