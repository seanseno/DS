namespace IS.Admin.Setup
{
    partial class FrmPrincipalsUploadExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipalsUploadExcel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSheet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvExcel = new System.Windows.Forms.DataGridView();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.lblProgressbar = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblpbar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).BeginInit();
            this.grpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Image = global::IS.Admin.Properties.Resources.Exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.Location = new System.Drawing.Point(1197, 641);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 68);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Image = global::IS.Admin.Properties.Resources.Upload;
            this.btnUpload.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpload.Location = new System.Drawing.Point(1089, 641);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(100, 68);
            this.btnUpload.TabIndex = 11;
            this.btnUpload.Text = "Upload";
            this.btnUpload.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.txtFileName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboSheet);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dgvExcel);
            this.groupBox2.Location = new System.Drawing.Point(149, 17);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1136, 617);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Excel Details";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(920, 30);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(55, 28);
            this.btnBrowse.TabIndex = 22;
            this.btnBrowse.Text = "......";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(117, 30);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(780, 22);
            this.txtFileName.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "File Name:";
            // 
            // cboSheet
            // 
            this.cboSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSheet.FormattingEnabled = true;
            this.cboSheet.Location = new System.Drawing.Point(117, 62);
            this.cboSheet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Size = new System.Drawing.Size(216, 25);
            this.cboSheet.TabIndex = 19;
            this.cboSheet.SelectedIndexChanged += new System.EventHandler(this.cboSheet_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Sheet :";
            // 
            // dgvExcel
            // 
            this.dgvExcel.AllowUserToAddRows = false;
            this.dgvExcel.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(235)))), ((int)(((byte)(249)))));
            this.dgvExcel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcel.Location = new System.Drawing.Point(23, 95);
            this.dgvExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvExcel.Name = "dgvExcel";
            this.dgvExcel.ReadOnly = true;
            this.dgvExcel.RowHeadersWidth = 51;
            this.dgvExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExcel.Size = new System.Drawing.Size(1087, 487);
            this.dgvExcel.TabIndex = 12;
            // 
            // grpBox
            // 
            this.grpBox.BackColor = System.Drawing.Color.White;
            this.grpBox.Controls.Add(this.lblProgressbar);
            this.grpBox.Controls.Add(this.progressBar1);
            this.grpBox.Controls.Add(this.groupBox2);
            this.grpBox.Controls.Add(this.pictureBox1);
            this.grpBox.Controls.Add(this.btnUpload);
            this.grpBox.Controls.Add(this.btnClose);
            this.grpBox.Controls.Add(this.lblpbar);
            this.grpBox.Location = new System.Drawing.Point(16, 68);
            this.grpBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpBox.Name = "grpBox";
            this.grpBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpBox.Size = new System.Drawing.Size(1313, 720);
            this.grpBox.TabIndex = 3;
            this.grpBox.TabStop = false;
            // 
            // lblProgressbar
            // 
            this.lblProgressbar.AutoSize = true;
            this.lblProgressbar.Location = new System.Drawing.Point(145, 759);
            this.lblProgressbar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProgressbar.Name = "lblProgressbar";
            this.lblProgressbar.Size = new System.Drawing.Size(0, 17);
            this.lblProgressbar.TabIndex = 24;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(149, 647);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(883, 28);
            this.progressBar1.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ink Free", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 42);
            this.label3.TabIndex = 18;
            this.label3.Text = "Upload Principals";
            // 
            // lblpbar
            // 
            this.lblpbar.AutoSize = true;
            this.lblpbar.Location = new System.Drawing.Point(145, 679);
            this.lblpbar.Name = "lblpbar";
            this.lblpbar.Size = new System.Drawing.Size(0, 17);
            this.lblpbar.TabIndex = 26;
            // 
            // FrmPrincipalsUploadExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1347, 799);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmPrincipalsUploadExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).EndInit();
            this.grpBox.ResumeLayout(false);
            this.grpBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSheet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvExcel;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgressbar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblpbar;
    }
}