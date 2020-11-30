
using ExcelDataReader;
using IS.Admin.Model;
using IS.Common.Reader;
using IS.Database;
using IS.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ZXing;

namespace IS.Admin.Setup
{
    public partial class FrmUploadExcel : BaseForm
    {
        DataTableCollection tableCollection;
        DataTable dt;
        ISFactory factory = new ISFactory();
        public FrmUploadExcel()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx;*.xls", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        tableCollection = ReadExcel.Read(ofd.FileName);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        return;
                    }
                    txtFileName.Text = ofd.FileName;
                    cboSheet.Items.Clear();
                    foreach (DataTable dt in tableCollection)
                    {
                        cboSheet.Items.Add(dt.TableName);
                    }
                }
            }
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = tableCollection[cboSheet.SelectedIndex];
            dgvExcel.DataSource = dt;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("Excel file is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cboSheet.SelectedIndex < 0)
            {
                MessageBox.Show("Please select sheet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try
                {
                    if (MessageBox.Show("Are you sure do want to continue?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        ProductsModel request = new ProductsModel();

                        progressBar1.Maximum = dt.Rows.Count;
                        progressBar1.Minimum = 0;

                        progressBar1.Value = 0;
                        int progressCount = 0;

                        IList<Products> list = new List<Products>();


                        int rowIndex = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            var Products = new Products
                            {
                                ProductId = row[0].ToString().ToUpper(),
                                ProductName = row[1].ToString(),
                                Price = Convert.ToDecimal(row[2].ToString().ToUpper()),
                                BarCode = row[3].ToString().ToUpper()
                            };

                            rowIndex++;

                            lblpbar.Text = "Checking...\\product id:" + Products.ProductId + "\\product name:" + Products.ProductName;
                            lblpbar.Refresh();

                            if (string.IsNullOrEmpty(row[0].ToString().ToUpper()) |
                                string.IsNullOrEmpty(row[1].ToString().ToUpper()) ||
                                string.IsNullOrEmpty(row[2].ToString().ToUpper()))
                            {
                                MessageBox.Show(string.Format("Row {0} has null value or empty, please check the row columns information!", rowIndex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dgvExcel.Rows[rowIndex - 1].Selected = true;
                                lblpbar.Text = "";
                                lblpbar.Refresh();
                                return;
                            }
                            else if (factory.ProductsRepository.ProductsStrategy.CheckIfProductExist(row[0].ToString().ToUpper()))
                            {
                                MessageBox.Show(string.Format("Row {0}, Product Id :{1} already exist!", rowIndex, row[0].ToString().ToUpper()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dgvExcel.Rows[rowIndex - 1].Selected = true;
                                lblpbar.Text = "";
                                lblpbar.Refresh();
                                return;
                            }
                            else if (!decimal.TryParse(row[2].ToString().ToUpper(), out decimal price))
                            {
                                MessageBox.Show(string.Format("Row {0}, Price :{1} is not valid!", rowIndex, row[1].ToString().ToUpper()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dgvExcel.Rows[rowIndex - 1].Selected = true;
                                lblpbar.Text = "";
                                lblpbar.Refresh();
                                return;
                            }
                            list.Add(Products);
                        }


                        if (list.GroupBy(x => x.ProductId).Any(g => g.Count() > 1)
                            ||
                            list.GroupBy(x => x.ProductName).Any(g => g.Count() > 1))
                        {
                            MessageBox.Show("Duplicate Product Id or Product Name found in your data excel!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lblpbar.Text = "";
                            lblpbar.Refresh();
                            return;
                        }


                        foreach (var row in list)
                        {
                            lblpbar.Text = "Inserting...\\product id:" + row.ProductId + "\\product name:" + row.ProductName;
                            lblpbar.Refresh();
                            factory.ProductsRepository.Insert(row);

                            progressCount++;
                            progressBar1.Value = progressCount;
                        }

                        lblpbar.Text = "";
                        lblpbar.Refresh();
                        MessageBox.Show("Products Uploaded!", "Information.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       

        private void FrmUploadExcel_Load(object sender, EventArgs e)
        {

        }

    }
}
