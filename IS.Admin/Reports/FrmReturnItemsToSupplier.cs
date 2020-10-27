using IS.Common.Utilities;
using IS.Database;
using IS.Database.CSV;
using IS.Database.Views;
using IS.Library.CSV;
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
    public partial class FrmReturnItemsToSupplier : BaseForm
    {
        ISFactory factory = new ISFactory();
        IList<ReturnItemsToSupplierView> _list = new List<ReturnItemsToSupplierView>();
        public FrmReturnItemsToSupplier()
        {
            InitializeComponent();
        }

        private void FrmReturnItems_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
            _list = factory.ReturnStocksDataRepository.GetList();
            _list = _list.OrderByDescending(x => x.InsertTime).ToList();

            var response =  new List<ReturnItemsToSupplierView>();
            response = _list.ToList();

            AddedFoorter(response, dgvReturnItems);
        }

        private void AddedFoorter(List<ReturnItemsToSupplierView> response, DataGridView dgv)
        {
            if (response.Count == 0)
            {
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = response;
                return;
            }
            response.Add(new ReturnItemsToSupplierView
            {
                Fullname = ""
            });

            dgv.AutoGenerateColumns = false;
            dgv.DataSource = response;

            dgv[4, dgvReturnItems.Rows.Count - 1].Value = "TOTAL";
            dgv.Rows[dgvReturnItems.Rows.Count - 1].Cells[4].Style.Font = new Font("Arial", 16, FontStyle.Bold);
            dgv.Rows[dgvReturnItems.Rows.Count - 1].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Rows[dgvReturnItems.Rows.Count - 1].Cells[5].Style.BackColor = Color.Green;
            dgv.Rows[dgvReturnItems.Rows.Count - 1].Cells[5].Style.ForeColor = Color.White;
            dgv.Rows[dgvReturnItems.Rows.Count - 1].Cells[5].Value = response.Sum(x => x.ReturnQty);
        }

        private void LoadData()
        {
            _list = factory.ReturnStocksDataRepository.GetList();
            _list = _list.OrderByDescending(x => x.InsertTime).ToList();
            _list = _list.Where(x => DateTimeConvertion.ConvertDateFrom(dtpFrom.Value) <= x.InsertTime && x.InsertTime <= DateTimeConvertion.ConvertDateTo(dtpTo.Value)).ToList();
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                _list = _list.Where(x => x.ProductName.Contains(txtSearch.Text.ToUpper()) ||
                            x.Fullname.Contains(txtSearch.Text.ToUpper())).ToList();

            }
            var response = new List<ReturnItemsToSupplierView>();
            response = _list.ToList();
            AddedFoorter(response, dgvReturnItems);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (_list == null || _list.Count == 0)
                {
                    MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            var csv = new List<ReturnItemsToSupplierCSV>();
                            foreach (var sale in this._list)
                            {
                                var item = new ReturnItemsToSupplierCSV();
                                item.Fullname = sale.Fullname;
                                item.PrincipalName = sale.PrincipalName;
                                item.CategoryName = sale.CategoryName;
                                item.ProductId = sale.ProductId;
                                item.ProductName = sale.ProductName;
                                item.ReturnQty = sale.ReturnQty.ToString("N0");
                                item.Remarks = sale.Remarks;
                                item.InsertTime = sale.InsertTime.ToString();
                                csv.Add(item);
                            }

                            CSV model = new CSV();

                            var factory = new ISFactory();
                            var fullname = factory.AdministratorsRepository.FindAdministratorWithLoginname(Globals.LoginName).Fullname;
                            var filename = model.WriteReturnStocksToSupplierCSV(
                                sfd.FileName,
                                csv,
                                _list,
                                dtpFrom.Value,
                                dtpTo.Value,
                                fullname);
                            System.Diagnostics.Process.Start(filename);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
