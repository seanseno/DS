
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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ZXing;

namespace IS.Admin.Setup
{
    public partial class FrmUploadExcel : Form
    {
        DataTableCollection tableCollection;
        DataTable dt;
        public FrmUploadExcel()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private IList<string> GetColumnList()
        {
            IList<string> list = new List<string>();

            list.Add("--Select--");
            foreach (DataColumn c in dt.Columns)
            {
                list.Add(c.ColumnName);
            }
            return list;
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
                if (MessageBox.Show("Are you sure do want to continue?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ItemsModel request = new ItemsModel();

                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Minimum = 0;

                    progressBar1.Value = 0;
                    int progressCount = 0;

                    var ErrorList = new List<Items>();

                    IList<Items> list = new List<Items>();

                    foreach (DataRow row in dt.Rows)
                    {
                        var item = new Items();
                        item.ItemId = row[0].ToString().ToUpper();
                        item.CategoryId = row[1].ToString().ToUpper();
                        item.CategoryName = row[2].ToString().ToUpper();
                        item.PrincipalId = row[3].ToString().ToUpper();
                        item.PrincipalName = row[4].ToString().ToUpper();
                        item.ProductName = row[5].ToString().ToUpper();
                        if (decimal.TryParse(row[6].ToString(), out decimal Price))
                        {
                            item.Price = Price;
                        }
                        else
                        {
                            item.Price = 0;
                        }
                        list.Add(item);

                        if (string.IsNullOrEmpty(row[7].ToString().ToUpper()))
                        {
                            item.BarCode = "";
                        }
                        else
                        {
                            item.BarCode = row[7].ToString().ToUpper();
                        }
                    }

                    foreach (var row in list)
                    {
                        try
                        {
                            request.InsertItem(row);
                        }
                        catch (Exception ex)
                        {
                            ErrorList.Add(row);
                        }
                        finally
                        {
                            progressCount++;
                            progressBar1.Value = progressCount;
                        }

                    }

                    if (ErrorList.Count > 0)
                    {
                        MessageBox.Show("Categories uploaded! but some rows does not uploaded, Please check the Item information.", "Information.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmNotUploaded frm = new FrmNotUploaded(ErrorList);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Categories Uploaded!", "Information.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }
       

        private void FrmUploadExcel_Load(object sender, EventArgs e)
        {

        }

    }
}
