namespace IS.Admin.Utilities
{
    partial class FrmReturnItemSettings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.ExpirationAlert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeniorDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PWDDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ink Free", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 34);
            this.label2.TabIndex = 18;
            this.label2.Text = "Settings";
            // 
            // dgvSearch
            // 
            this.dgvSearch.AllowUserToAddRows = false;
            this.dgvSearch.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(235)))), ((int)(((byte)(249)))));
            this.dgvSearch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExpirationAlert,
            this.SeniorDiscount,
            this.PWDDiscount,
            this.ReturnItem,
            this.Edit});
            this.dgvSearch.Location = new System.Drawing.Point(15, 19);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.ReadOnly = true;
            this.dgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearch.Size = new System.Drawing.Size(966, 271);
            this.dgvSearch.TabIndex = 1;
            this.dgvSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearch_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.dgvSearch);
            this.groupBox1.Location = new System.Drawing.Point(18, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1000, 366);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::IS.Admin.Properties.Resources.Cancel;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.Location = new System.Drawing.Point(915, 305);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 55);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ExpirationAlert
            // 
            this.ExpirationAlert.DataPropertyName = "ExpirationAlert";
            this.ExpirationAlert.HeaderText = "Expiration Alert Days";
            this.ExpirationAlert.Name = "ExpirationAlert";
            this.ExpirationAlert.ReadOnly = true;
            // 
            // SeniorDiscount
            // 
            this.SeniorDiscount.DataPropertyName = "SeniorDiscount";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.SeniorDiscount.DefaultCellStyle = dataGridViewCellStyle2;
            this.SeniorDiscount.HeaderText = "Senior Discount";
            this.SeniorDiscount.Name = "SeniorDiscount";
            this.SeniorDiscount.ReadOnly = true;
            // 
            // PWDDiscount
            // 
            this.PWDDiscount.DataPropertyName = "PWDDiscount";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.PWDDiscount.DefaultCellStyle = dataGridViewCellStyle3;
            this.PWDDiscount.HeaderText = "PWD Discount";
            this.PWDDiscount.Name = "PWDDiscount";
            this.PWDDiscount.ReadOnly = true;
            // 
            // ReturnItem
            // 
            this.ReturnItem.DataPropertyName = "ReturnItem";
            this.ReturnItem.HeaderText = "Return Item Days";
            this.ReturnItem.Name = "ReturnItem";
            this.ReturnItem.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 60;
            // 
            // FrmReturnItemSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(1030, 440);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReturnItemSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FrmReturnItemSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpirationAlert;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeniorDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PWDDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnItem;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
    }
}