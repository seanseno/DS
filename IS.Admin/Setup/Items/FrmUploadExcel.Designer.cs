namespace IS.Admin.Setup
{
    partial class FrmUploadExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUploadExcel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbo9 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbo8 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbo7 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbo6 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbo5 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbo4 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo1 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSheet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvExcel = new System.Windows.Forms.DataGridView();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
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
            this.btnClose.Location = new System.Drawing.Point(1316, 730);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
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
            this.btnUpload.Location = new System.Drawing.Point(1191, 730);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(100, 68);
            this.btnUpload.TabIndex = 11;
            this.btnUpload.Text = "Upload";
            this.btnUpload.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbo9);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cbo8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbo7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbo6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbo5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbo4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbo3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbo2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbo1);
            this.groupBox1.Location = new System.Drawing.Point(11, 112);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(264, 602);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Column";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 302);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 17);
            this.label10.TabIndex = 35;
            this.label10.Text = "Expiration date";
            // 
            // cbo9
            // 
            this.cbo9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo9.FormattingEnabled = true;
            this.cbo9.Location = new System.Drawing.Point(119, 298);
            this.cbo9.Margin = new System.Windows.Forms.Padding(4);
            this.cbo9.Name = "cbo9";
            this.cbo9.Size = new System.Drawing.Size(136, 25);
            this.cbo9.TabIndex = 34;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 268);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 17);
            this.label11.TabIndex = 33;
            this.label11.Text = "Date Manufac..";
            // 
            // cbo8
            // 
            this.cbo8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo8.FormattingEnabled = true;
            this.cbo8.Location = new System.Drawing.Point(119, 265);
            this.cbo8.Margin = new System.Windows.Forms.Padding(4);
            this.cbo8.Name = "cbo8";
            this.cbo8.Size = new System.Drawing.Size(136, 25);
            this.cbo8.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 235);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "Stocks";
            // 
            // cbo7
            // 
            this.cbo7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo7.FormattingEnabled = true;
            this.cbo7.Location = new System.Drawing.Point(119, 231);
            this.cbo7.Margin = new System.Windows.Forms.Padding(4);
            this.cbo7.Name = "cbo7";
            this.cbo7.Size = new System.Drawing.Size(136, 25);
            this.cbo7.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 202);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 17);
            this.label8.TabIndex = 29;
            this.label8.Text = "Price";
            // 
            // cbo6
            // 
            this.cbo6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo6.FormattingEnabled = true;
            this.cbo6.Location = new System.Drawing.Point(119, 198);
            this.cbo6.Margin = new System.Windows.Forms.Padding(4);
            this.cbo6.Name = "cbo6";
            this.cbo6.Size = new System.Drawing.Size(136, 25);
            this.cbo6.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 169);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 17);
            this.label7.TabIndex = 27;
            this.label7.Text = "Descriptions";
            // 
            // cbo5
            // 
            this.cbo5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo5.FormattingEnabled = true;
            this.cbo5.Location = new System.Drawing.Point(119, 165);
            this.cbo5.Margin = new System.Windows.Forms.Padding(4);
            this.cbo5.Name = "cbo5";
            this.cbo5.Size = new System.Drawing.Size(136, 25);
            this.cbo5.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 135);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "Brand Name";
            // 
            // cbo4
            // 
            this.cbo4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo4.FormattingEnabled = true;
            this.cbo4.Location = new System.Drawing.Point(119, 132);
            this.cbo4.Margin = new System.Windows.Forms.Padding(4);
            this.cbo4.Name = "cbo4";
            this.cbo4.Size = new System.Drawing.Size(136, 25);
            this.cbo4.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 103);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Generic Name";
            // 
            // cbo3
            // 
            this.cbo3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo3.FormattingEnabled = true;
            this.cbo3.Location = new System.Drawing.Point(119, 98);
            this.cbo3.Margin = new System.Windows.Forms.Padding(4);
            this.cbo3.Name = "cbo3";
            this.cbo3.Size = new System.Drawing.Size(136, 25);
            this.cbo3.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Companies";
            // 
            // cbo2
            // 
            this.cbo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo2.FormattingEnabled = true;
            this.cbo2.Location = new System.Drawing.Point(119, 65);
            this.cbo2.Margin = new System.Windows.Forms.Padding(4);
            this.cbo2.Name = "cbo2";
            this.cbo2.Size = new System.Drawing.Size(136, 25);
            this.cbo2.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Categories";
            // 
            // cbo1
            // 
            this.cbo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo1.FormattingEnabled = true;
            this.cbo1.Location = new System.Drawing.Point(119, 32);
            this.cbo1.Margin = new System.Windows.Forms.Padding(4);
            this.cbo1.Name = "cbo1";
            this.cbo1.Size = new System.Drawing.Size(136, 25);
            this.cbo1.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
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
            this.groupBox2.Location = new System.Drawing.Point(283, 17);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1136, 697);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Excel Details";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(920, 30);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
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
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4);
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
            this.cboSheet.Margin = new System.Windows.Forms.Padding(4);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(235)))), ((int)(((byte)(249)))));
            this.dgvExcel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcel.Location = new System.Drawing.Point(23, 95);
            this.dgvExcel.Margin = new System.Windows.Forms.Padding(4);
            this.dgvExcel.Name = "dgvExcel";
            this.dgvExcel.ReadOnly = true;
            this.dgvExcel.RowHeadersWidth = 51;
            this.dgvExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExcel.Size = new System.Drawing.Size(1087, 570);
            this.dgvExcel.TabIndex = 12;
            // 
            // grpBox
            // 
            this.grpBox.BackColor = System.Drawing.Color.White;
            this.grpBox.Controls.Add(this.progressBar1);
            this.grpBox.Controls.Add(this.groupBox2);
            this.grpBox.Controls.Add(this.pictureBox1);
            this.grpBox.Controls.Add(this.groupBox1);
            this.grpBox.Controls.Add(this.btnUpload);
            this.grpBox.Controls.Add(this.btnClose);
            this.grpBox.Location = new System.Drawing.Point(17, 15);
            this.grpBox.Margin = new System.Windows.Forms.Padding(4);
            this.grpBox.Name = "grpBox";
            this.grpBox.Padding = new System.Windows.Forms.Padding(4);
            this.grpBox.Size = new System.Drawing.Size(1427, 809);
            this.grpBox.TabIndex = 3;
            this.grpBox.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(283, 721);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(883, 28);
            this.progressBar1.TabIndex = 23;
            // 
            // FrmUploadExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1460, 838);
            this.ControlBox = false;
            this.Controls.Add(this.grpBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmUploadExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.FrmUploadExcel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).EndInit();
            this.grpBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbo5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbo4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo1;
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbo9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbo8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbo7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbo6;
    }
}