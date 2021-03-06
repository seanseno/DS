﻿using IS.Admin.Model;
using IS.Common.Utilities;
using IS.Database;
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

namespace IS.Admin
{
    public partial class FrmLogin : Form
    {
        ISFactory factory = new ISFactory();
        int CountErrorlabel = 0;
        public string LoginName { get; set; }
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                try
                {
                    var response = factory.AdministratorsRepository.AdministratorsStrategy.CheckAdministratorLogin(txtLoginame.Text, txtPassword.Text);
                    if (response != null)
                    {
                        Globals.SetLoginId(response.Loginname, response.AdminId);

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        timer1.Start();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!lblerror.Visible)
            {
                lblerror.Visible = true;
            }
            else
            {
                lblerror.Visible = false;
            }
            CountErrorlabel++;
            if (CountErrorlabel >= 10)
            {
                timer1.Stop();
                lblerror.Visible = false;
                CountErrorlabel = 0;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtLoginame_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 13)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnLogin_Click(sender, e);
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtLoginame.Text))
            {
                MessageBox.Show("Login Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLoginame.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Password is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return true;
            }
            return false;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            BackColor = ThemesUtility.BackColor();
        }
    }
}
