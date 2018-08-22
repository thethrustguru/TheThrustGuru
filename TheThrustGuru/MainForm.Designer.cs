namespace TheThrustGuru
{
    partial class MainForm
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
            this.networkLabel = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerCompanyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectCompanyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vouchersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupStoreLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setUpSalesTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupServiceChargeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stocksToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.allStocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setStockPricingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockTransferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recipesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.financialAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.setUnitPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setLocationPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.passwordButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profitLossAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalBalanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.balanceSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // networkLabel
            // 
            this.networkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.networkLabel.AutoSize = true;
            this.networkLabel.BackColor = System.Drawing.SystemColors.Control;
            this.networkLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.networkLabel.Location = new System.Drawing.Point(1021, 590);
            this.networkLabel.Name = "networkLabel";
            this.networkLabel.Size = new System.Drawing.Size(15, 13);
            this.networkLabel.TabIndex = 3;
            this.networkLabel.Text = "m";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardToolStripMenuItem,
            this.transactionToolStripMenuItem,
            this.inventoryToolStripMenuItem1,
            this.stocksToolStripMenuItem1,
            this.analysisToolStripMenuItem,
            this.manageAccountToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1152, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerCompanyToolStripMenuItem,
            this.selectCompanyToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.dashboardToolStripMenuItem.Text = "&File";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.restuarantToolStripMenuItem_Click);
            // 
            // registerCompanyToolStripMenuItem
            // 
            this.registerCompanyToolStripMenuItem.Name = "registerCompanyToolStripMenuItem";
            this.registerCompanyToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.registerCompanyToolStripMenuItem.Text = "&Register Company";
            // 
            // selectCompanyToolStripMenuItem
            // 
            this.selectCompanyToolStripMenuItem.Name = "selectCompanyToolStripMenuItem";
            this.selectCompanyToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.selectCompanyToolStripMenuItem.Text = "Select &Company";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // transactionToolStripMenuItem
            // 
            this.transactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quotationToolStripMenuItem,
            this.receiptsToolStripMenuItem,
            this.expensesToolStripMenuItem,
            this.vouchersToolStripMenuItem});
            this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
            this.transactionToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.transactionToolStripMenuItem.Text = "&Transaction";
            // 
            // quotationToolStripMenuItem
            // 
            this.quotationToolStripMenuItem.Name = "quotationToolStripMenuItem";
            this.quotationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quotationToolStripMenuItem.Text = "Quotation";
            // 
            // receiptsToolStripMenuItem
            // 
            this.receiptsToolStripMenuItem.Name = "receiptsToolStripMenuItem";
            this.receiptsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.receiptsToolStripMenuItem.Text = "Receipts";
            this.receiptsToolStripMenuItem.Click += new System.EventHandler(this.receiptsToolStripMenuItem_Click);
            // 
            // expensesToolStripMenuItem
            // 
            this.expensesToolStripMenuItem.Name = "expensesToolStripMenuItem";
            this.expensesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.expensesToolStripMenuItem.Text = "Expenses";
            this.expensesToolStripMenuItem.Click += new System.EventHandler(this.expensesToolStripMenuItem_Click);
            // 
            // vouchersToolStripMenuItem
            // 
            this.vouchersToolStripMenuItem.Name = "vouchersToolStripMenuItem";
            this.vouchersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.vouchersToolStripMenuItem.Text = "Vouchers";
            this.vouchersToolStripMenuItem.Click += new System.EventHandler(this.vouchersToolStripMenuItem_Click);
            // 
            // inventoryToolStripMenuItem1
            // 
            this.inventoryToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseInventoryToolStripMenuItem,
            this.salesInventoryToolStripMenuItem,
            this.productionToolStripMenuItem,
            this.setupStoreLocationToolStripMenuItem,
            this.setUpSalesTypeToolStripMenuItem,
            this.setupServiceChargeToolStripMenuItem});
            this.inventoryToolStripMenuItem1.Name = "inventoryToolStripMenuItem1";
            this.inventoryToolStripMenuItem1.Size = new System.Drawing.Size(69, 20);
            this.inventoryToolStripMenuItem1.Text = "&Inventory";
            // 
            // purchaseInventoryToolStripMenuItem
            // 
            this.purchaseInventoryToolStripMenuItem.Name = "purchaseInventoryToolStripMenuItem";
            this.purchaseInventoryToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.purchaseInventoryToolStripMenuItem.Text = "Purchase Inventory";
            this.purchaseInventoryToolStripMenuItem.Click += new System.EventHandler(this.purchaseInventoryToolStripMenuItem_Click);
            // 
            // salesInventoryToolStripMenuItem
            // 
            this.salesInventoryToolStripMenuItem.Name = "salesInventoryToolStripMenuItem";
            this.salesInventoryToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.salesInventoryToolStripMenuItem.Text = "Sales Inventory";
            this.salesInventoryToolStripMenuItem.Click += new System.EventHandler(this.salesInventoryToolStripMenuItem_Click);
            // 
            // productionToolStripMenuItem
            // 
            this.productionToolStripMenuItem.Name = "productionToolStripMenuItem";
            this.productionToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.productionToolStripMenuItem.Text = "Production";
            // 
            // setupStoreLocationToolStripMenuItem
            // 
            this.setupStoreLocationToolStripMenuItem.Name = "setupStoreLocationToolStripMenuItem";
            this.setupStoreLocationToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.setupStoreLocationToolStripMenuItem.Text = "Setup store location";
            this.setupStoreLocationToolStripMenuItem.Click += new System.EventHandler(this.setupStoreLocationToolStripMenuItem_Click);
            // 
            // setUpSalesTypeToolStripMenuItem
            // 
            this.setUpSalesTypeToolStripMenuItem.Name = "setUpSalesTypeToolStripMenuItem";
            this.setUpSalesTypeToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.setUpSalesTypeToolStripMenuItem.Text = "Setup sales type";
            this.setUpSalesTypeToolStripMenuItem.Click += new System.EventHandler(this.setUpSalesTypeToolStripMenuItem_Click);
            // 
            // setupServiceChargeToolStripMenuItem
            // 
            this.setupServiceChargeToolStripMenuItem.Name = "setupServiceChargeToolStripMenuItem";
            this.setupServiceChargeToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.setupServiceChargeToolStripMenuItem.Text = "Setup service charge";
            this.setupServiceChargeToolStripMenuItem.Click += new System.EventHandler(this.setupServiceChargeToolStripMenuItem_Click);
            // 
            // stocksToolStripMenuItem1
            // 
            this.stocksToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allStocksToolStripMenuItem,
            this.setStockPricingToolStripMenuItem,
            this.stockTransferToolStripMenuItem,
            this.recipesToolStripMenuItem});
            this.stocksToolStripMenuItem1.Name = "stocksToolStripMenuItem1";
            this.stocksToolStripMenuItem1.Size = new System.Drawing.Size(53, 20);
            this.stocksToolStripMenuItem1.Text = "&Stocks";
            this.stocksToolStripMenuItem1.Click += new System.EventHandler(this.stocksToolStripMenuItem1_Click);
            // 
            // allStocksToolStripMenuItem
            // 
            this.allStocksToolStripMenuItem.Name = "allStocksToolStripMenuItem";
            this.allStocksToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.allStocksToolStripMenuItem.Text = "Stock Records";
            this.allStocksToolStripMenuItem.Click += new System.EventHandler(this.allStocksToolStripMenuItem_Click);
            // 
            // setStockPricingToolStripMenuItem
            // 
            this.setStockPricingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setUnitPriceToolStripMenuItem,
            this.setLocationPriceToolStripMenuItem});
            this.setStockPricingToolStripMenuItem.Name = "setStockPricingToolStripMenuItem";
            this.setStockPricingToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.setStockPricingToolStripMenuItem.Text = "Set Stock Pricing";
            // 
            // stockTransferToolStripMenuItem
            // 
            this.stockTransferToolStripMenuItem.Name = "stockTransferToolStripMenuItem";
            this.stockTransferToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.stockTransferToolStripMenuItem.Text = "Stock Transfer";
            this.stockTransferToolStripMenuItem.Click += new System.EventHandler(this.stockTransferToolStripMenuItem_Click);
            // 
            // recipesToolStripMenuItem
            // 
            this.recipesToolStripMenuItem.Name = "recipesToolStripMenuItem";
            this.recipesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.recipesToolStripMenuItem.Text = "Recipes";
            this.recipesToolStripMenuItem.Click += new System.EventHandler(this.recipesToolStripMenuItem_Click);
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesAnalysisToolStripMenuItem,
            this.purchaseAnalysisToolStripMenuItem,
            this.financialAnalysisToolStripMenuItem});
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.analysisToolStripMenuItem.Text = "&Analysis";
            // 
            // salesAnalysisToolStripMenuItem
            // 
            this.salesAnalysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesToolStripMenuItem,
            this.receiptReportToolStripMenuItem});
            this.salesAnalysisToolStripMenuItem.Name = "salesAnalysisToolStripMenuItem";
            this.salesAnalysisToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.salesAnalysisToolStripMenuItem.Text = "Sales Analysis";
            // 
            // purchaseAnalysisToolStripMenuItem
            // 
            this.purchaseAnalysisToolStripMenuItem.Name = "purchaseAnalysisToolStripMenuItem";
            this.purchaseAnalysisToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.purchaseAnalysisToolStripMenuItem.Text = "Purchase Analysis";
            // 
            // financialAnalysisToolStripMenuItem
            // 
            this.financialAnalysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profitLossAnalysisToolStripMenuItem,
            this.totalBalanceToolStripMenuItem,
            this.balanceSheetToolStripMenuItem});
            this.financialAnalysisToolStripMenuItem.Name = "financialAnalysisToolStripMenuItem";
            this.financialAnalysisToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.financialAnalysisToolStripMenuItem.Text = "Financial Analysis";
            // 
            // manageAccountToolStripMenuItem
            // 
            this.manageAccountToolStripMenuItem.Name = "manageAccountToolStripMenuItem";
            this.manageAccountToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.manageAccountToolStripMenuItem.Text = "&Manage Account";
            this.manageAccountToolStripMenuItem.Click += new System.EventHandler(this.manageAccountToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.logOutToolStripMenuItem.Text = "S&ettings ";
            // 
            // logOutToolStripMenuItem1
            // 
            this.logOutToolStripMenuItem1.Name = "logOutToolStripMenuItem1";
            this.logOutToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.logOutToolStripMenuItem1.Text = "&Log Out";
            this.logOutToolStripMenuItem1.Click += new System.EventHandler(this.logOutToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.aboutToolStripMenuItem.Text = "A&bout";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.passwordButton);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(2, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1148, 47);
            this.panel1.TabIndex = 7;
            // 
            // setUnitPriceToolStripMenuItem
            // 
            this.setUnitPriceToolStripMenuItem.Name = "setUnitPriceToolStripMenuItem";
            this.setUnitPriceToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.setUnitPriceToolStripMenuItem.Text = "Set unit price";
            // 
            // setLocationPriceToolStripMenuItem
            // 
            this.setLocationPriceToolStripMenuItem.Name = "setLocationPriceToolStripMenuItem";
            this.setLocationPriceToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.setLocationPriceToolStripMenuItem.Text = "Set location price";
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::TheThrustGuru.Properties.Resources.location;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(332, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(52, 47);
            this.button7.TabIndex = 9;
            this.toolTip1.SetToolTip(this.button7, "Switch Location");
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::TheThrustGuru.Properties.Resources.edit_pos;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(277, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(52, 47);
            this.button6.TabIndex = 9;
            this.toolTip1.SetToolTip(this.button6, "Edit point of sale");
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::TheThrustGuru.Properties.Resources.pos;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(222, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(52, 47);
            this.button5.TabIndex = 9;
            this.toolTip1.SetToolTip(this.button5, "Point of Sale");
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::TheThrustGuru.Properties.Resources.settings;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(167, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(52, 47);
            this.button4.TabIndex = 9;
            this.toolTip1.SetToolTip(this.button4, "Convert DB to readable format");
            this.button4.UseVisualStyleBackColor = true;
            // 
            // passwordButton
            // 
            this.passwordButton.BackgroundImage = global::TheThrustGuru.Properties.Resources.password;
            this.passwordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.passwordButton.FlatAppearance.BorderSize = 0;
            this.passwordButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.passwordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.passwordButton.Location = new System.Drawing.Point(112, 0);
            this.passwordButton.Name = "passwordButton";
            this.passwordButton.Size = new System.Drawing.Size(52, 47);
            this.passwordButton.TabIndex = 9;
            this.toolTip1.SetToolTip(this.passwordButton, "Change Password");
            this.passwordButton.UseVisualStyleBackColor = true;
            this.passwordButton.Click += new System.EventHandler(this.passwordButton_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::TheThrustGuru.Properties.Resources.import;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(57, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 47);
            this.button2.TabIndex = 9;
            this.toolTip1.SetToolTip(this.button2, "Restore Database");
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::TheThrustGuru.Properties.Resources.storing;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 47);
            this.button1.TabIndex = 9;
            this.toolTip1.SetToolTip(this.button1, "Backup Database");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salesToolStripMenuItem.Text = "Sales Report";
            // 
            // receiptReportToolStripMenuItem
            // 
            this.receiptReportToolStripMenuItem.Name = "receiptReportToolStripMenuItem";
            this.receiptReportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.receiptReportToolStripMenuItem.Text = "Receipt Report";
            // 
            // profitLossAnalysisToolStripMenuItem
            // 
            this.profitLossAnalysisToolStripMenuItem.Name = "profitLossAnalysisToolStripMenuItem";
            this.profitLossAnalysisToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.profitLossAnalysisToolStripMenuItem.Text = "Profit/Loss Analysis";
            // 
            // totalBalanceToolStripMenuItem
            // 
            this.totalBalanceToolStripMenuItem.Name = "totalBalanceToolStripMenuItem";
            this.totalBalanceToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.totalBalanceToolStripMenuItem.Text = "Total Balance";
            // 
            // balanceSheetToolStripMenuItem
            // 
            this.balanceSheetToolStripMenuItem.Name = "balanceSheetToolStripMenuItem";
            this.balanceSheetToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.balanceSheetToolStripMenuItem.Text = "Balance Sheet";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1152, 612);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.networkLabel);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "The Thrust Guru";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label networkLabel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manageAccountToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button passwordButton;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem setupStoreLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseInventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesInventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stocksToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem allStocksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setStockPricingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerCompanyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectCompanyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vouchersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockTransferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem financialAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recipesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setUpSalesTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupServiceChargeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setUnitPriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setLocationPriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiptReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profitLossAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalBalanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem balanceSheetToolStripMenuItem;
    }
}

