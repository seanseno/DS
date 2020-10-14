using IS.Admin.Model;
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

namespace IS.Admin.Setup
{
    public partial class FrmEditCashier : Form
    {
        private Cashiers _Cashier { get;set;}
        public string CopyPath { get; set; }
        public FrmEditCashier(Cashiers Cashier)
        {
            InitializeComponent();
            this._Cashier = Cashier;
        }

        private void FrmEditCashier_Load(object sender, EventArgs e)
        {
            CashiersModel Cashiers = new CashiersModel();
            var response = Cashiers.LoadEdit(_Cashier.CashierId);
            txtLogiName.Text = response.Loginname;
            txtFullName.Text = response.Fullname;
            chkActive.Checked = Convert.ToBoolean(response.Active);
            if (ImagesUtility.PhotoIsExist(response.CashierId))
            {
                PictureBox.Image = PictureBox.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(ImagesUtility.LoadCashierPhoto(response.CashierId))));
            }

            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.ActiveControl = txtFullName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!CheckInput())
            {
                CashiersModel Cashiers = new CashiersModel();
                _Cashier.Fullname = txtFullName.Text;
                _Cashier.Password = txtPassword.Text;
                _Cashier.Active = Convert.ToInt32(chkActive.Checked);
                Cashiers.UpdateCashier(_Cashier);
                this.DialogResult = DialogResult.OK;

                if (!string.IsNullOrEmpty(CopyPath))
                {
                    PictureBox.InitialImage = null;
                    ImagesUtility.SaveCashierPhoto(_Cashier.CashierId, CopyPath);
                }
            }

        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Full Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Full Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Focus();
                return true;
            }
            else if (txtLogiName.Text.Length < 4)
            {
                MessageBox.Show("Password must be at least 6 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return true;
            }

            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                if (string.IsNullOrEmpty(txtConfirmPassword.Text))
                {
                    MessageBox.Show("Confirm password is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtConfirmPassword.Focus();
                    return true;
                }
                else if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Password does not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                    return true;
                }
                else if (txtPassword.Text.Length < 6)
                {
                    MessageBox.Show("Login Name must be at least 4 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLogiName.Focus();
                    return true;
                }
            }
  
            return false;
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                PictureBox.Image = new Bitmap(open.FileName);
                txtLogiName.Focus();
                // image file path  
                CopyPath = open.FileName;
            }
            open.Dispose();
        }
    }
}
