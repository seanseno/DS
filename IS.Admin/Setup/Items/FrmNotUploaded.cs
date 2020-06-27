﻿using IS.Admin.Model;
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
    public partial class FrmNotUploaded : Form
    {
        IList<Items> ItemList = new List<Items>();
        public FrmNotUploaded(IList<Items> ItmList)
        {
            InitializeComponent();
            ItemList = ItmList;
            this.ActiveControl = txtSearch;
        }


        private void LoadItems()
        {
            ItemsModel model = new ItemsModel();
            //var response = model.ItemList(txtSearch.Text);

            var searchList = ItemList.Where(x => x.CategoryName.Contains(txtSearch.Text.ToUpper()) ||
                x.CategoryName.Contains(txtSearch.Text.ToUpper()) ||
                x.GenericName.Contains(txtSearch.Text.ToUpper()) ||
                x.BrandName.Contains(txtSearch.Text.ToUpper()) ||
                x.Description.Contains(txtSearch.Text.ToUpper())).ToList();

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

        private void FrmNotUploaded_Shown(object sender, EventArgs e)
        {
            grpLoading.Visible = true;
            grpLoading.Refresh();

            this.LoadItems();

            grpLoading.Visible = false;
            grpLoading.Refresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void FrmNotUploaded_Load(object sender, EventArgs e)
        {

        }
    }
}