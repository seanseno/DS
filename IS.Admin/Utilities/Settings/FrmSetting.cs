﻿using IS.Common.Utilities;
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
    public partial class FrmReturnItemSettings : BaseForm
    {
        ISFactory factory = new ISFactory();
        public FrmReturnItemSettings()
        {
            InitializeComponent();
        }

        private void FrmReturnItemSettings_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            var response = factory.SettingsRepository.GetList();
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = response;
        }
        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 5) //edit
            {
                FrmEditSettings frm = new FrmEditSettings();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    MessageBox.Show("Settings updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
            }
        }

        private void dgvSearch_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (e.Value.ToString() == "1")
                {
                    e.Value = "Yes";
                }
                else
                {
                    e.Value = "No";
                }
            }
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                e.Value = PercentConvertion.PercentWithSymbol(Convert.ToDecimal(e.Value));
            }
        }
    }
}
