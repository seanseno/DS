
using ExcelDataReader;
using IS.Admin.Model;
using IS.Common.Reader;
using IS.Database.Entities;
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
using System.Windows.Forms.VisualStyles;
using ZXing;

namespace IS.Admin.Setup
{
    public partial class FrmCategoriesUploadExcel : Form
    {
        DataTableCollection tableCollection;
        DataTable dt;
        public FrmCategoriesUploadExcel()
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
                        CategoriesModel request = new CategoriesModel();
                        progressBar1.Maximum = dt.Rows.Count;
                        progressBar1.Minimum = 0;

                        progressBar1.Value = 0;
                        int progressCount = 0;

                        IList<Categories> list = new List<Categories>();

                        int rowIndex = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            rowIndex++;
                            var category = new Categories();
                            category.CategoryId = row[0].ToString().ToUpper();
                            category.CategoryName = row[1].ToString().ToUpper();

                            if (string.IsNullOrEmpty(row[2].ToString().ToUpper()))
                            {
                                category.PercentSuggestedPrice = 0;
                            }
                            else
                            {
                                category.PercentSuggestedPrice = Convert.ToDecimal(row[2].ToString().ToUpper());
                            }
                            lblpbar.Text = "Checking...\\category id:" + category.CategoryId + "\\category name:" + category.CategoryName;
                            lblpbar.Refresh();
                            if (string.IsNullOrEmpty(category.CategoryId) ||
                                string.IsNullOrEmpty(category.CategoryName))
                            {
                                MessageBox.Show(string.Format("Row {0} has null value or empty, please check the row columns information!", rowIndex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dgvExcel.Rows[rowIndex - 1].Selected = true;
                                progressBar1.Value = 0;
                                lblpbar.Text = "";
                                lblpbar.Refresh();
                                return;
                            }
                            else if (request.CheckDup(category))
                            {
                                MessageBox.Show(string.Format("Row {0}, Principal Id :{1} or Principal Name :{2} already exist!", rowIndex, category.CategoryId.ToUpper(), category.CategoryName.ToUpper()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dgvExcel.Rows[rowIndex - 1].Selected = true;
                                progressBar1.Value = 0;
                                lblpbar.Text = "";
                                lblpbar.Refresh();
                                return;
                            }
                            list.Add(category);
                        }

                        if (list.GroupBy(x => x.CategoryId).Any(g => g.Count() > 1)
                            ||
                            list.GroupBy(x => x.CategoryName).Any(g => g.Count() > 1))
                        {
                            MessageBox.Show("Duplicate Category Id or Category Name found in your data excel!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            progressBar1.Value = 0;
                            lblpbar.Text = "";
                            return;
                        }

                        foreach (var row in list)
                        {

                            lblpbar.Text = "Inserting...\\category id:" + row.CategoryId + "\\category name:" + row.CategoryName;
                            lblpbar.Refresh();
                            request.InsertCategory(row);

                            progressCount++;
                            progressBar1.Value = progressCount;

                        }
                        lblpbar.Text = "";
                        lblpbar.Refresh();
                        MessageBox.Show("Categories Uploaded!", "Information.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
