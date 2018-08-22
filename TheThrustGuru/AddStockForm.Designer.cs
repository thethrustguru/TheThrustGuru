namespace TheThrustGuru
{
    partial class AddStock
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.descTextBox = new System.Windows.Forms.TextBox();
            this.costPriceTextBox = new System.Windows.Forms.TextBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.svaeButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.sellingPriceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.storeLocationTextBox = new System.Windows.Forms.TextBox();
            this.unitTextBox = new System.Windows.Forms.TextBox();
            this.vendorComboBox = new System.Windows.Forms.ComboBox();
            this.skuTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(557, 475);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(126, 48);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(50, 108);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(242, 20);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            this.nameTextBox.Enter += new System.EventHandler(this.nameTextBox_Enter);
            this.nameTextBox.Leave += new System.EventHandler(this.nameTextBox_Leave);
            // 
            // descTextBox
            // 
            this.descTextBox.Location = new System.Drawing.Point(50, 218);
            this.descTextBox.Multiline = true;
            this.descTextBox.Name = "descTextBox";
            this.descTextBox.Size = new System.Drawing.Size(242, 67);
            this.descTextBox.TabIndex = 1;
            this.descTextBox.Enter += new System.EventHandler(this.descTextBox_Enter);
            this.descTextBox.Leave += new System.EventHandler(this.descTextBox_Leave);
            // 
            // costPriceTextBox
            // 
            this.costPriceTextBox.Location = new System.Drawing.Point(50, 305);
            this.costPriceTextBox.Name = "costPriceTextBox";
            this.costPriceTextBox.Size = new System.Drawing.Size(242, 20);
            this.costPriceTextBox.TabIndex = 1;
            this.costPriceTextBox.Enter += new System.EventHandler(this.priceTextBox_Enter);
            this.costPriceTextBox.Leave += new System.EventHandler(this.priceTextBox_Leave);
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(50, 384);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(242, 20);
            this.quantityTextBox.TabIndex = 1;
            this.quantityTextBox.Enter += new System.EventHandler(this.quantityTextBox_Enter);
            this.quantityTextBox.Leave += new System.EventHandler(this.quantityTextBox_Leave);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(50, 482);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(242, 21);
            this.categoryComboBox.TabIndex = 2;
            this.categoryComboBox.DropDown += new System.EventHandler(this.categoryComboBox_DropDown);
            this.categoryComboBox.DropDownClosed += new System.EventHandler(this.categoryComboBox_DropDownClosed);
            // 
            // svaeButton
            // 
            this.svaeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.svaeButton.FlatAppearance.BorderSize = 0;
            this.svaeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.svaeButton.Location = new System.Drawing.Point(394, 475);
            this.svaeButton.Name = "svaeButton";
            this.svaeButton.Size = new System.Drawing.Size(126, 48);
            this.svaeButton.TabIndex = 0;
            this.svaeButton.Text = "&Save";
            this.svaeButton.UseVisualStyleBackColor = false;
            this.svaeButton.Click += new System.EventHandler(this.Okbutton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // sellingPriceTextBox
            // 
            this.sellingPriceTextBox.Location = new System.Drawing.Point(50, 343);
            this.sellingPriceTextBox.Name = "sellingPriceTextBox";
            this.sellingPriceTextBox.Size = new System.Drawing.Size(242, 20);
            this.sellingPriceTextBox.TabIndex = 1;
            this.sellingPriceTextBox.Enter += new System.EventHandler(this.sellingPriceTextBox_Enter);
            this.sellingPriceTextBox.Leave += new System.EventHandler(this.sellingPriceTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Store location";
            // 
            // storeLocationTextBox
            // 
            this.storeLocationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeLocationTextBox.Location = new System.Drawing.Point(50, 64);
            this.storeLocationTextBox.Multiline = true;
            this.storeLocationTextBox.Name = "storeLocationTextBox";
            this.storeLocationTextBox.ReadOnly = true;
            this.storeLocationTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.storeLocationTextBox.Size = new System.Drawing.Size(242, 27);
            this.storeLocationTextBox.TabIndex = 1;
            this.storeLocationTextBox.Text = "Main Store";
            this.storeLocationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.storeLocationTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            this.storeLocationTextBox.Enter += new System.EventHandler(this.nameTextBox_Enter);
            this.storeLocationTextBox.Leave += new System.EventHandler(this.nameTextBox_Leave);
            // 
            // unitTextBox
            // 
            this.unitTextBox.Location = new System.Drawing.Point(50, 146);
            this.unitTextBox.Name = "unitTextBox";
            this.unitTextBox.Size = new System.Drawing.Size(242, 20);
            this.unitTextBox.TabIndex = 1;
            this.unitTextBox.Enter += new System.EventHandler(this.unitTextBox_Enter);
            this.unitTextBox.Leave += new System.EventHandler(this.unitTextBox_Leave);
            // 
            // vendorComboBox
            // 
            this.vendorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vendorComboBox.FormattingEnabled = true;
            this.vendorComboBox.Location = new System.Drawing.Point(50, 431);
            this.vendorComboBox.Name = "vendorComboBox";
            this.vendorComboBox.Size = new System.Drawing.Size(242, 21);
            this.vendorComboBox.TabIndex = 2;
            this.vendorComboBox.DropDown += new System.EventHandler(this.vendorComboBox_DropDown);
            this.vendorComboBox.DropDownClosed += new System.EventHandler(this.vendorComboBox_DropDownClosed);
            // 
            // skuTextBox
            // 
            this.skuTextBox.Location = new System.Drawing.Point(50, 182);
            this.skuTextBox.Name = "skuTextBox";
            this.skuTextBox.Size = new System.Drawing.Size(242, 20);
            this.skuTextBox.TabIndex = 1;
            this.skuTextBox.Enter += new System.EventHandler(this.skuTextBox_Enter);
            this.skuTextBox.Leave += new System.EventHandler(this.skuTextBox_Leave);
            // 
            // AddStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 544);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vendorComboBox);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.descTextBox);
            this.Controls.Add(this.sellingPriceTextBox);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.skuTextBox);
            this.Controls.Add(this.unitTextBox);
            this.Controls.Add(this.costPriceTextBox);
            this.Controls.Add(this.storeLocationTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.svaeButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddStock";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Stock";
            this.Load += new System.EventHandler(this.AddFoodItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox descTextBox;
        private System.Windows.Forms.TextBox costPriceTextBox;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Button svaeButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox sellingPriceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox storeLocationTextBox;
        private System.Windows.Forms.ComboBox vendorComboBox;
        private System.Windows.Forms.TextBox unitTextBox;
        private System.Windows.Forms.TextBox skuTextBox;
    }
}