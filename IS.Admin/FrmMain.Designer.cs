namespace IS.Admin
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOfffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.requestOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receivedOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.principalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUpdateCashierInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashOnHandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashierTotalCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.transactionsToolStripMenuItem,
            this.setupToolStripMenuItem,
            this.utilitiesToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOfffToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // logOfffToolStripMenuItem
            // 
            this.logOfffToolStripMenuItem.Name = "logOfffToolStripMenuItem";
            this.logOfffToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.logOfffToolStripMenuItem.Text = "Log Off";
            this.logOfffToolStripMenuItem.Click += new System.EventHandler(this.logOfffToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordersToolStripMenuItem1,
            this.stocksToolStripMenuItem});
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            // 
            // ordersToolStripMenuItem1
            // 
            this.ordersToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.requestOrdersToolStripMenuItem,
            this.receivedOrdersToolStripMenuItem});
            this.ordersToolStripMenuItem1.Name = "ordersToolStripMenuItem1";
            this.ordersToolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.ordersToolStripMenuItem1.Text = "Orders";
            // 
            // requestOrdersToolStripMenuItem
            // 
            this.requestOrdersToolStripMenuItem.Name = "requestOrdersToolStripMenuItem";
            this.requestOrdersToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.requestOrdersToolStripMenuItem.Text = "Request Orders";
            this.requestOrdersToolStripMenuItem.Click += new System.EventHandler(this.requestOrdersToolStripMenuItem_Click);
            // 
            // receivedOrdersToolStripMenuItem
            // 
            this.receivedOrdersToolStripMenuItem.Name = "receivedOrdersToolStripMenuItem";
            this.receivedOrdersToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.receivedOrdersToolStripMenuItem.Text = "Received Orders";
            this.receivedOrdersToolStripMenuItem.Click += new System.EventHandler(this.receivedOrdersToolStripMenuItem_Click);
            // 
            // stocksToolStripMenuItem
            // 
            this.stocksToolStripMenuItem.Name = "stocksToolStripMenuItem";
            this.stocksToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.stocksToolStripMenuItem.Text = "Stocks";
            this.stocksToolStripMenuItem.Click += new System.EventHandler(this.stocksToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Checked = true;
            this.setupToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriesToolStripMenuItem,
            this.principalsToolStripMenuItem,
            this.productsToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.categoriesToolStripMenuItem.Text = "Categories";
            this.categoriesToolStripMenuItem.Click += new System.EventHandler(this.categoriesToolStripMenuItem_Click);
            // 
            // principalsToolStripMenuItem
            // 
            this.principalsToolStripMenuItem.Name = "principalsToolStripMenuItem";
            this.principalsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.principalsToolStripMenuItem.Text = "Principals";
            this.principalsToolStripMenuItem.Click += new System.EventHandler(this.principalsToolStripMenuItem_Click);
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administratorToolStripMenuItem,
            this.cashiersToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // administratorToolStripMenuItem
            // 
            this.administratorToolStripMenuItem.Name = "administratorToolStripMenuItem";
            this.administratorToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.administratorToolStripMenuItem.Text = "Administrator";
            this.administratorToolStripMenuItem.Click += new System.EventHandler(this.administratorToolStripMenuItem_Click);
            // 
            // cashiersToolStripMenuItem
            // 
            this.cashiersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUpdateCashierInfoToolStripMenuItem,
            this.cashOnHandToolStripMenuItem});
            this.cashiersToolStripMenuItem.Name = "cashiersToolStripMenuItem";
            this.cashiersToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.cashiersToolStripMenuItem.Text = "Cashiers";
            // 
            // addUpdateCashierInfoToolStripMenuItem
            // 
            this.addUpdateCashierInfoToolStripMenuItem.Name = "addUpdateCashierInfoToolStripMenuItem";
            this.addUpdateCashierInfoToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.addUpdateCashierInfoToolStripMenuItem.Text = "Add/Update Cashier info";
            this.addUpdateCashierInfoToolStripMenuItem.Click += new System.EventHandler(this.addUpdateCashierInfoToolStripMenuItem_Click);
            // 
            // cashOnHandToolStripMenuItem
            // 
            this.cashOnHandToolStripMenuItem.Name = "cashOnHandToolStripMenuItem";
            this.cashOnHandToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.cashOnHandToolStripMenuItem.Text = "Cash On-hand";
            this.cashOnHandToolStripMenuItem.Click += new System.EventHandler(this.cashOnHandToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesToolStripMenuItem,
            this.cashierTotalCollectionToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportToolStripMenuItem.Text = "Reports";
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.salesToolStripMenuItem.Text = "Sales";
            this.salesToolStripMenuItem.Click += new System.EventHandler(this.salesToolStripMenuItem_Click);
            // 
            // cashierTotalCollectionToolStripMenuItem
            // 
            this.cashierTotalCollectionToolStripMenuItem.Name = "cashierTotalCollectionToolStripMenuItem";
            this.cashierTotalCollectionToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.cashierTotalCollectionToolStripMenuItem.Text = "Cashier total collection";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 350);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 1;
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productsToolStripMenuItem1,
            this.uploadProductsToolStripMenuItem});
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.productsToolStripMenuItem.Text = "Products";
            // 
            // productsToolStripMenuItem1
            // 
            this.productsToolStripMenuItem1.Name = "productsToolStripMenuItem1";
            this.productsToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.productsToolStripMenuItem1.Text = "Products";
            this.productsToolStripMenuItem1.Click += new System.EventHandler(this.productsToolStripMenuItem1_Click);
            // 
            // uploadProductsToolStripMenuItem
            // 
            this.uploadProductsToolStripMenuItem.Name = "uploadProductsToolStripMenuItem";
            this.uploadProductsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uploadProductsToolStripMenuItem.Text = "Upload Products";
            this.uploadProductsToolStripMenuItem.Click += new System.EventHandler(this.uploadProductsToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem administratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cashiersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOfffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUpdateCashierInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cashOnHandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cashierTotalCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem requestOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receivedOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stocksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem principalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem uploadProductsToolStripMenuItem;
    }
}

