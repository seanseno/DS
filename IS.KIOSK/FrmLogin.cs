﻿using IS.Common.Utilities;
using IS.Database;
using IS.Database.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.KIOSK
{
    public partial class frmLogin : BaseForm
    {
        private readonly ISFactory factory = new ISFactory();
        readonly FrmMain kiosk = new FrmMain();
        int CountErrorlabel = 0;
        public frmLogin(FrmMain model)
        {
            InitializeComponent();
            kiosk = model;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var response = factory.CashiersRepository.CashiersStrategy.CheckCashierLogin(txtLoginame.Text, txtPassword.Text);
                if (response != null)
                {
                    Globals.SetLoginId(response.Loginname, response.CashierId);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //var (cashierId,response, message) = factory.CashiersRepository.CashiersStrategy.CheckCashierLogin(txtLoginame.Text, txtPassword.Text);
            //if (response)
            //{
            //    kiosk._Cashier = factory.CashiersRepository.FindCashierWithCashierId(cashierId);
            //    Globals.SetLoginId(kiosk._Cashier.Id, txtLoginame.Text, kiosk._Cashier.CashierId);
            //    this.DialogResult = DialogResult.OK;
            //}
            //else if (!string.IsNullOrEmpty(message))
            //{
            //    MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    timer1.Start();
            //}
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

        private void txtLoginame_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 13)
            {
                btnLogin_Click(sender, e);
            }
            else if (e.KeyValue == 27)
            {
                btnCancel_Click(sender, e);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnLogin_Click(sender, e);
            }
            else if (e.KeyValue == 27)
            {
                btnCancel_Click(sender, e);
            }
        }
    }
}
