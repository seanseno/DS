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
    public partial class FrmEditQuestions : BaseForm
    {
        ISFactory factory = new ISFactory();
        int _Id { get; set; }
        public FrmEditQuestions(int Id, string question, string answer)
        {
            InitializeComponent();
            this.ActiveControl = txtQuestion;
            _Id = Id;
            txtQuestion.Text = question;
            txtAnswer.Text = answer;
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
                var Questions = new Questions
                {
                    Id = _Id,
                    Question = txtQuestion.Text,
                    Answer = txtAnswer.Text
                };

                if (MessageBox.Show("Continue saving?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    factory.QuestionsRepository.Update(Questions);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
