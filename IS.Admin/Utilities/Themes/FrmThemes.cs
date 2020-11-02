using IS.Database;
using IS.Database.Entities;
using IS.Library.Utility;
using Microsoft.Win32;
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

namespace IS.Admin.Utilities
{
    public partial class FrmThemes : Form
    {
        ISFactory factory = new ISFactory();
        public string LogoPath { get; set; }
        public string WallPaperPath { get; set; }
        FrmMain _FrmMain = new FrmMain();
        public FrmThemes(FrmMain frm)
        {
            InitializeComponent();
            ActiveControl = txtCompanyName;
            _FrmMain = frm;
        }

        private void FrmReturnItemSettings_Load(object sender, EventArgs e)
        {
            LoadLogo();
        }

        private void LoadLogo()
        {
            string LogoPath = ThemesUtility.Logo();
            if (!String.IsNullOrEmpty(LogoPath))
            {
                if (File.Exists(LogoPath))
                {
                    pbLogo.BackgroundImage = Image.FromFile(LogoPath);
                }
            }

            string WallpaperPath = ThemesUtility.WallPaper();
            if (!String.IsNullOrEmpty(WallpaperPath))
            {
                if (File.Exists(WallpaperPath))
                {
                    pbWallPaper.BackgroundImage = Image.FromFile(WallpaperPath);
                }
            }
            txtCompanyName.Text = ThemesUtility.CompanyName();
            btnColor.BackColor = ThemesUtility.BackColor();
            this.BackColor = btnColor.BackColor;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog1.Color;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want change?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Themes themes = new Themes();
                themes.Id = ThemesUtility.Id();
                themes.Red = btnColor.BackColor.R;
                themes.Green = btnColor.BackColor.G;
                themes.Blue = btnColor.BackColor.B;
                themes.CompanyName = txtCompanyName.Text;
                this.BackColor = btnColor.BackColor;
                if (!string.IsNullOrEmpty(LogoPath))
                {
                    themes.Logo = LogoPath;
                }
                else
                {
                    themes.Logo = string.IsNullOrEmpty(ThemesUtility.Logo()) ? "": ThemesUtility.Logo();
                }
                if (!string.IsNullOrEmpty(WallPaperPath))
                {
                    themes.WallPaper = WallPaperPath;
                }
                else
                {
                    themes.WallPaper = string.IsNullOrEmpty(ThemesUtility.WallPaper()) ? "" : ThemesUtility.WallPaper();
                }
                factory.ThemesRepository.Update(themes);
                _FrmMain.LoadWallPaper(themes.WallPaper);
            }
        }


        private void pbWallPaper_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbWallPaper.BackgroundImage = Image.FromStream(new MemoryStream(File.ReadAllBytes(open.FileName)));
                WallPaperPath = open.FileName;
            }
            open.Dispose();
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbLogo.BackgroundImage = Image.FromStream(new MemoryStream(File.ReadAllBytes(open.FileName)));
                LogoPath = open.FileName;
            }
            open.Dispose();
        }
    }
}
