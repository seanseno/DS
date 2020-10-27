namespace IS.KIOSK
{
    partial class frmMultiplier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProductName = new System.Windows.Forms.Label();
            this.pnlDiscount = new System.Windows.Forms.Panel();
            this.rbPwd = new System.Windows.Forms.RadioButton();
            this.rbSenior = new System.Windows.Forms.RadioButton();
            this.lblError = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlDiscount.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblProductName);
            this.panel1.Controls.Add(this.pnlDiscount);
            this.panel1.Controls.Add(this.lblError);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.txtQty);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 153);
            this.panel1.TabIndex = 9;
            // 
            // lblProductName
            // 
            this.lblProductName.BackColor = System.Drawing.Color.White;
            this.lblProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProductName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(16, 8);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(369, 59);
            this.lblProductName.TabIndex = 13;
            // 
            // pnlDiscount
            // 
            this.pnlDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlDiscount.Controls.Add(this.rbPwd);
            this.pnlDiscount.Controls.Add(this.rbSenior);
            this.pnlDiscount.Location = new System.Drawing.Point(185, 70);
            this.pnlDiscount.Name = "pnlDiscount";
            this.pnlDiscount.Size = new System.Drawing.Size(200, 27);
            this.pnlDiscount.TabIndex = 12;
            this.pnlDiscount.Visible = false;
            // 
            // rbPwd
            // 
            this.rbPwd.AutoSize = true;
            this.rbPwd.Location = new System.Drawing.Point(110, 6);
            this.rbPwd.Name = "rbPwd";
            this.rbPwd.Size = new System.Drawing.Size(51, 17);
            this.rbPwd.TabIndex = 2;
            this.rbPwd.TabStop = true;
            this.rbPwd.Text = "PWD";
            this.rbPwd.UseVisualStyleBackColor = true;
            this.rbPwd.Visible = false;
            this.rbPwd.CheckedChanged += new System.EventHandler(this.rbPwd_CheckedChanged);
            this.rbPwd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rbPwd_KeyUp);
            // 
            // rbSenior
            // 
            this.rbSenior.AutoSize = true;
            this.rbSenior.Location = new System.Drawing.Point(15, 6);
            this.rbSenior.Name = "rbSenior";
            this.rbSenior.Size = new System.Drawing.Size(89, 17);
            this.rbSenior.TabIndex = 1;
            this.rbSenior.TabStop = true;
            this.rbSenior.Text = "Senior Citizen";
            this.rbSenior.UseVisualStyleBackColor = true;
            this.rbSenior.Visible = false;
            this.rbSenior.CheckedChanged += new System.EventHandler(this.rbSenior_CheckedChanged);
            this.rbSenior.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rbSenior_KeyUp);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(19, 132);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(47, 16);
            this.lblError.TabIndex = 10;
            this.lblError.Text = "lblEror";
            this.lblError.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(121, 108);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 24);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "0.00";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(118, 70);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(52, 26);
            this.txtQty.TabIndex = 0;
            this.txtQty.Text = "1";
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQty.TextChanged += new System.EventHandler(this.txtQty_TextChanged);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            this.txtQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total Price : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quantity :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "2. Press Escape to close";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "1. Press Enter to accept";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Shorcut Key";
            // 
            // frmMultiplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(432, 234);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMultiplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmMultiplier_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlDiscount.ResumeLayout(false);
            this.pnlDiscount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbPwd;
        private System.Windows.Forms.RadioButton rbSenior;
        private System.Windows.Forms.Panel pnlDiscount;
        private System.Windows.Forms.Label lblProductName;
    }
}