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
    public partial class FrmAddCashier : Form
    {
        public Cashiers _Cashiers = new Cashiers();
        public string CopyPath { get; set; }
        public FrmAddCashier()
        {
            InitializeComponent();
            this.ActiveControl = txtCashierId;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                var CashiersModel = new CashiersModel();
                _Cashiers.CashierId = txtCashierId.Text;
                _Cashiers.Loginname = txtLogiName.Text;
                _Cashiers.Fullname = txtFullName.Text;
                _Cashiers.Password = txtPassword.Text;

                if (CashiersModel.CheckDup(this))
                {
                    MessageBox.Show(_Cashiers.Loginname + " already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLogiName.Focus();
                }
                if (MessageBox.Show("Continue saving " + txtLogiName.Text + ".", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var response = CashiersModel.AddCashier(this);
                    if (!string.IsNullOrEmpty(CopyPath) || response != null)
                    {
                        ImagesUtility.SaveCashierPhoto(response.Id, CopyPath);
                    }
                    MessageBox.Show(txtLogiName.Text + " Added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        //private  void SavePhoto()
        //{
        //    if (System.IO.Directory.Exists(path))
        //    {
        //        OpenFileDialog ofd = new OpenFileDialog();  //make ofd local
        //        ofd.InitialDirectory = path;
        //        DialogResult dr = new DialogResult();
        //        if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            Image img = new Bitmap(ofd.FileName);
        //            imageFileinfo = new FileInfo(ofd.FileName);  // save the file name
        //            string imgName = ofd.SafeFileName;
        //            txtImageName.Text = imgName;
        //            pictureBox1.Image = img.GetThumbnailImage(350, 350, null, new IntPtr());
        //            ofd.RestoreDirectory = true;
        //            img.Dispose();
        //        }
        //        ofd.Dispose();  //don't forget to dispose it!
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}
        private void FrmAddCashier_Load(object sender, EventArgs e)
        {
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            CashiersModel cashiersModel = new CashiersModel();
            txtCashierId.Text = cashiersModel.GetNextId();
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtCashierId.Text))
            {
                MessageBox.Show("Cashier Id is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCashierId.Focus();
                return true;
            }
            if (string.IsNullOrEmpty(txtLogiName.Text))
            {
                MessageBox.Show("Login Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogiName.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Full Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Password is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(txtConfirmPassword.Text))
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
            else if (txtLogiName.Text.Length  < 4)
            {
                MessageBox.Show("Login Name must be at least 4 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogiName.Focus();
                return true;
            }
            else if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return true;
            }
            return false;
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                PictureBox.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(open.FileName)));
                CopyPath = open.FileName;
            }
            open.Dispose();
        }
    }
}
