namespace IS.ServerInfo
{
    partial class btnCopyPass
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
            this.btnLoadServer = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtEncPass = new System.Windows.Forms.TextBox();
            this.txtEncId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadServer
            // 
            this.btnLoadServer.Location = new System.Drawing.Point(28, 82);
            this.btnLoadServer.Name = "btnLoadServer";
            this.btnLoadServer.Size = new System.Drawing.Size(324, 35);
            this.btnLoadServer.TabIndex = 2;
            this.btnLoadServer.Text = "Generate Encrypt";
            this.btnLoadServer.UseVisualStyleBackColor = true;
            this.btnLoadServer.Click += new System.EventHandler(this.btnLoadServer_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(90, 15);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(262, 20);
            this.txtId.TabIndex = 0;
            this.txtId.Text = "admin";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(90, 44);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(262, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "Cloud@14";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Id :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password :";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(277, 129);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtEncPass
            // 
            this.txtEncPass.Location = new System.Drawing.Point(90, 161);
            this.txtEncPass.Name = "txtEncPass";
            this.txtEncPass.Size = new System.Drawing.Size(181, 20);
            this.txtEncPass.TabIndex = 4;
            // 
            // txtEncId
            // 
            this.txtEncId.Location = new System.Drawing.Point(90, 132);
            this.txtEncId.Name = "txtEncId";
            this.txtEncId.Size = new System.Drawing.Size(181, 20);
            this.txtEncId.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Password :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Id :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Copy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCopyPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 201);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEncPass);
            this.Controls.Add(this.txtEncId);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnLoadServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "btnCopyPass";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encryption ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadServer;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox txtEncPass;
        private System.Windows.Forms.TextBox txtEncId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}

