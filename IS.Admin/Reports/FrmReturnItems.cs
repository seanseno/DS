using IS.Common.Utilities;
using IS.Database;
using IS.Database.CSV;
using IS.Database.Views;
using IS.Library.CSV;
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

namespace IS.Admin.Reports
{
    public partial class FrmReturnItems : BaseForm
    {
        ISFactory factory = new ISFactory();
        IList<ReturnIemsView> _list = new List<ReturnIemsView>();
        public FrmReturnItems()
        {
            InitializeComponent();
        }

        private void FrmReturnItems_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateConvertion.GetFistDay(DateTime.Now);
            dtpTo.Value = DateConvertion.GetLastDay(DateTime.Now);
            //_list = factory.ReturnItemsRepository.GetList();
            //_list = _list.OrderByDescending(x => x.InsertTime).ToList();

            //var response =  new List<ReturnIemsView>();
            //response = _list.ToList();

            //AddedFoorter(response, dgvReturnItems);
        }

        private void AddedFoorter(List<ReturnIemsView> response, DataGridView dgv)
        {
            if (response.Count == 0)
            {
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = response;
                return;
            }
            response.Add(new ReturnIemsView
            {
                Fullname = ""
            });

            dgv.AutoGenerateColumns = false;
            dgv.DataSource = response;

            dgv[1, dgvReturnItems.Rows.Count - 1].Value = "TOTAL";
            dgv.Rows[dgvReturnItems.Rows.Count - 1].Cells[1].Style.Font = new Font("Arial", 16, FontStyle.Bold);
            dgv.Rows[dgvReturnItems.Rows.Count - 1].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Rows[dgvReturnItems.Rows.Count - 1].Cells[2].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvReturnItems.Rows.Count - 1].Cells[3].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.Rows[dgvReturnItems.Rows.Count - 1].Cells[3].Style.BackColor = Color.Green;
            dgv.Rows[dgvReturnItems.Rows.Count - 1].Cells[3].Style.ForeColor = Color.White;
            dgv.Rows[dgvReturnItems.Rows.Count - 1].Cells[3].Value = response.Sum(x => x.Price);
            dgv.Rows[dgvReturnItems.Rows.Count - 1].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Rows[dgvReturnItems.Rows.Count - 1].Cells[2].Style.BackColor = Color.Green;
            dgv.Rows[dgvReturnItems.Rows.Count - 1].Cells[2].Style.ForeColor = Color.White;
            dgv.Rows[dgvReturnItems.Rows.Count - 1].Cells[2].Value = response.Sum(x => x.Qty);
        }

        private void LoadData()
        {
            _list = factory.ReturnItemsRepository.GetList();
            _list = _list.OrderByDescending(x => x.InsertTime).ToList();
            _list = _list.Where(x => DateTimeConvertion.ConvertDateFrom(dtpFrom.Value) <= x.InsertTime && x.InsertTime <= DateTimeConvertion.ConvertDateTo(dtpTo.Value)).ToList();
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                _list = _list.Where(x => x.ProductName.Contains(txtSearch.Text.ToUpper()) ||
                            x.Fullname.Contains(txtSearch.Text.ToUpper())).ToList();

            }
            var response = new List<ReturnIemsView>();
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
                            var SalesList = new List<ReturnItemsCSV>();
                            foreach (var sale in this._list)
                            {
                                var item = new ReturnItemsCSV();
                                item.Fullname = sale.Fullname;
                                item.ProductName = sale.ProductName;
                                item.Qty = sale.Qty.ToString("N0");
                                item.Price = sale.Price.ToString("N2");
                                item.InsertTime = sale.InsertTime.ToString();
                                SalesList.Add(item);
                            }

                            CSV model = new CSV();

                            var factory = new ISFactory();
                            var fullname = factory.AdministratorsRepository.FindAdministratorWithLoginname(Globals.LoginName).Fullname;
                            var filename = model.WriteReturnItemsCSV(
                                sfd.FileName,
                                SalesList,
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
