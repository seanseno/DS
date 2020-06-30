
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
    public partial class FrmPrincipalsUploadExcel : Form
    {
        DataTableCollection tableCollection;
        DataTable dt;
        public FrmPrincipalsUploadExcel()
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
            {

                if (MessageBox.Show("Are you sure do want to continue?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    PrincipalsModel request = new PrincipalsModel();
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Minimum = 0;

                    progressBar1.Value = 0;
                    int progressCount = 0;

                    var ErrorList = new List<Principals>();

                    IList<Principals> list = new List<Principals>();
                    foreach (DataRow row in dt.Rows)
                    {

                        var Principal = new Principals();
                        Principal.PrincipalId = row[0].ToString().ToUpper();
                        Principal.PrincipalName = row[1].ToString().ToUpper();
                        if (!request.CheckDup(Principal))
                        {
                            list.Add(Principal);
                        }
                        else
                        {
                            ErrorList.Add(Principal);
                        }
                    }

                    foreach (var row in list)
                    {
                        try
                        {
                            request.InsertPrincipal(row);
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
                        MessageBox.Show("Principals uploaded! but some rows does not uploaded, Please check the Item information.", "Information.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmPrincipalsNotUploaded frm = new FrmPrincipalsNotUploaded(ErrorList);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Principals Uploaded!", "Information.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }
    }
}
