namespace IS.KIOSK
{
    partial class FrmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtAdditionalInfo = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.IdOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discounted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btnSenior = new System.Windows.Forms.Button();
            this.btnPWD = new System.Windows.Forms.Button();
            this.btnReprint = new System.Windows.Forms.Button();
            this.btnReturnItem = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.txtCustomerName);
            this.groupBox2.Controls.Add(this.txtAdditionalInfo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.lblCompanyName);
            this.groupBox2.Controls.Add(this.lblError);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dgvList);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.pnlLogo);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(13, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1784, 775);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Order List";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(189, 174);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(627, 26);
            this.txtCustomerName.TabIndex = 0;
            // 
            // txtAdditionalInfo
            // 
            this.txtAdditionalInfo.Location = new System.Drawing.Point(171, 662);
            this.txtAdditionalInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtAdditionalInfo.MaxLength = 1000;
            this.txtAdditionalInfo.Name = "txtAdditionalInfo";
            this.txtAdditionalInfo.Size = new System.Drawing.Size(632, 86);
            this.txtAdditionalInfo.TabIndex = 1;
            this.txtAdditionalInfo.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 174);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Customer Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(683, 754);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "(1000 Characters)";
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Black;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTotal.Location = new System.Drawing.Point(1244, 33);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(519, 89);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Segoe Script", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.Navy;
            this.lblCompanyName.Location = new System.Drawing.Point(195, 33);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(613, 80);
            this.lblCompanyName.TabIndex = 12;
            this.lblCompanyName.Text = "Pharmachic Drugstore";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(17, 198);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(112, 20);
            this.lblError.TabIndex = 10;
            this.lblError.Text = "Total Count:";
            this.lblError.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 663);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Additional Info:";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdOrder,
            this.ProductId,
            this.ProductName,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn3,
            this.Discounted,
            this.TotalPrice});
            this.dgvList.GridColor = System.Drawing.Color.White;
            this.dgvList.Location = new System.Drawing.Point(19, 222);
            this.dgvList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 51;
            this.dgvList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.ShowCellErrors = false;
            this.dgvList.Size = new System.Drawing.Size(1743, 413);
            this.dgvList.TabIndex = 1;
            this.dgvList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvOrders_KeyDown);
            // 
            // IdOrder
            // 
            this.IdOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IdOrder.DataPropertyName = "Id";
            this.IdOrder.HeaderText = "Id";
            this.IdOrder.MinimumWidth = 6;
            this.IdOrder.Name = "IdOrder";
            this.IdOrder.ReadOnly = true;
            this.IdOrder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IdOrder.Visible = false;
            this.IdOrder.Width = 50;
            // 
            // ProductId
            // 
            this.ProductId.DataPropertyName = "ProductId";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductId.DefaultCellStyle = dataGridViewCellStyle1;
            this.ProductId.HeaderText = "Product ID";
            this.ProductId.MinimumWidth = 6;
            this.ProductId.Name = "ProductId";
            this.ProductId.ReadOnly = true;
            this.ProductId.Width = 125;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductName.DataPropertyName = "ProductName";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ProductName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 810;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Qty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn4.FillWeight = 101.5228F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Price";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0.00";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn3.FillWeight = 106.5126F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Price";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // Discounted
            // 
            this.Discounted.DataPropertyName = "Discounted";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0.00";
            this.Discounted.DefaultCellStyle = dataGridViewCellStyle5;
            this.Discounted.HeaderText = "Discounted";
            this.Discounted.MinimumWidth = 6;
            this.Discounted.Name = "Discounted";
            this.Discounted.ReadOnly = true;
            this.Discounted.Width = 80;
            // 
            // TotalPrice
            // 
            this.TotalPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TotalPrice.DataPropertyName = "TotalPrice";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0.00";
            this.TotalPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.TotalPrice.HeaderText = "TotalPrice";
            this.TotalPrice.MinimumWidth = 6;
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            this.TotalPrice.Width = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1013, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 46);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total Due:";
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackgroundImage = global::IS.KIOSK.Properties.Resources._480px_No_image_available_svg;
            this.pnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlLogo.Location = new System.Drawing.Point(20, 14);
            this.pnlLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(169, 130);
            this.pnlLogo.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblLogin);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Location = new System.Drawing.Point(1471, 805);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 109);
            this.panel1.TabIndex = 12;
            this.panel1.Visible = false;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblLogin.Location = new System.Drawing.Point(4, 78);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(106, 17);
            this.lblLogin.TabIndex = 12;
            this.lblLogin.Text = "Current Login : ";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDate.Location = new System.Drawing.Point(4, 7);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(145, 25);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "JUNE 25, 2020";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTime.Location = new System.Drawing.Point(4, 32);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(230, 39);
            this.lblTime.TabIndex = 13;
            this.lblTime.Text = "22: 22:24 PM";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // btnSenior
            // 
            this.btnSenior.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSenior.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSenior.Image = ((System.Drawing.Image)(resources.GetObject("btnSenior.Image")));
            this.btnSenior.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSenior.Location = new System.Drawing.Point(879, 802);
            this.btnSenior.Margin = new System.Windows.Forms.Padding(4);
            this.btnSenior.Name = "btnSenior";
            this.btnSenior.Size = new System.Drawing.Size(207, 58);
            this.btnSenior.TabIndex = 17;
            this.btnSenior.Text = "F5 / Senior Citizen";
            this.btnSenior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSenior.UseVisualStyleBackColor = false;
            this.btnSenior.Click += new System.EventHandler(this.btnSenior_Click);
            // 
            // btnPWD
            // 
            this.btnPWD.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnPWD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPWD.Image = ((System.Drawing.Image)(resources.GetObject("btnPWD.Image")));
            this.btnPWD.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPWD.Location = new System.Drawing.Point(1093, 802);
            this.btnPWD.Margin = new System.Windows.Forms.Padding(4);
            this.btnPWD.Name = "btnPWD";
            this.btnPWD.Size = new System.Drawing.Size(207, 58);
            this.btnPWD.TabIndex = 16;
            this.btnPWD.Text = "F6 / PWD";
            this.btnPWD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPWD.UseVisualStyleBackColor = false;
            this.btnPWD.Click += new System.EventHandler(this.btnPWD_Click);
            // 
            // btnReprint
            // 
            this.btnReprint.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnReprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReprint.Image = ((System.Drawing.Image)(resources.GetObject("btnReprint.Image")));
            this.btnReprint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReprint.Location = new System.Drawing.Point(1093, 864);
            this.btnReprint.Margin = new System.Windows.Forms.Padding(4);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(207, 58);
            this.btnReprint.TabIndex = 15;
            this.btnReprint.Text = "F11 / Reprint";
            this.btnReprint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReprint.UseVisualStyleBackColor = false;
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // btnReturnItem
            // 
            this.btnReturnItem.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnReturnItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnItem.Image = ((System.Drawing.Image)(resources.GetObject("btnReturnItem.Image")));
            this.btnReturnItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReturnItem.Location = new System.Drawing.Point(664, 863);
            this.btnReturnItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnReturnItem.Name = "btnReturnItem";
            this.btnReturnItem.Size = new System.Drawing.Size(207, 58);
            this.btnReturnItem.TabIndex = 7;
            this.btnReturnItem.Text = "F9 / Return Item";
            this.btnReturnItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturnItem.UseVisualStyleBackColor = false;
            this.btnReturnItem.Click += new System.EventHandler(this.btnReturnItem_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(235, 802);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(207, 58);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "F2 / Searh Product";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnRemoveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveAll.Image")));
            this.btnRemoveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveAll.Location = new System.Drawing.Point(235, 864);
            this.btnRemoveAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(207, 58);
            this.btnRemoveAll.TabIndex = 5;
            this.btnRemoveAll.Text = "F7 / Remove All";
            this.btnRemoveAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(449, 863);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(207, 58);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "F8 / Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.Location = new System.Drawing.Point(879, 864);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(207, 58);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "F10 / Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckOut.Image")));
            this.btnCheckOut.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheckOut.Location = new System.Drawing.Point(664, 802);
            this.btnCheckOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(207, 58);
            this.btnCheckOut.TabIndex = 4;
            this.btnCheckOut.Text = "F4 / Check Out";
            this.btnCheckOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHelp.Location = new System.Drawing.Point(20, 802);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(207, 58);
            this.btnHelp.TabIndex = 1;
            this.btnHelp.Text = "F1 / Help";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoad.Location = new System.Drawing.Point(449, 802);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(207, 58);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "F3 / Load";
            this.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1808, 929);
            this.ControlBox = false;
            this.Controls.Add(this.btnSenior);
            this.Controls.Add(this.btnPWD);
            this.Controls.Add(this.btnReprint);
            this.Controls.Add(this.btnReturnItem);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Button btnReturnItem;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnReprint;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discounted;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.Button btnPWD;
        private System.Windows.Forms.Button btnSenior;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.RichTextBox txtAdditionalInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}