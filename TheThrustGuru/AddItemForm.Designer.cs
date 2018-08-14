namespace TheThrustGuru
{
    partial class AddItem
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
            this.Okbutton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.sellingPriceTextBox = new System.Windows.Forms.TextBox();
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
            this.nameTextBox.Location = new System.Drawing.Point(50, 45);
            this.nameTextBox.Multiline = true;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(242, 27);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            this.nameTextBox.Enter += new System.EventHandler(this.nameTextBox_Enter);
            this.nameTextBox.Leave += new System.EventHandler(this.nameTextBox_Leave);
            // 
            // descTextBox
            // 
            this.descTextBox.Location = new System.Drawing.Point(50, 92);
            this.descTextBox.Multiline = true;
            this.descTextBox.Name = "descTextBox";
            this.descTextBox.Size = new System.Drawing.Size(242, 145);
            this.descTextBox.TabIndex = 1;
            this.descTextBox.Enter += new System.EventHandler(this.descTextBox_Enter);
            this.descTextBox.Leave += new System.EventHandler(this.descTextBox_Leave);
            // 
            // costPriceTextBox
            // 
            this.costPriceTextBox.Location = new System.Drawing.Point(50, 272);
            this.costPriceTextBox.Multiline = true;
            this.costPriceTextBox.Name = "costPriceTextBox";
            this.costPriceTextBox.Size = new System.Drawing.Size(242, 31);
            this.costPriceTextBox.TabIndex = 1;
            this.costPriceTextBox.Enter += new System.EventHandler(this.priceTextBox_Enter);
            this.costPriceTextBox.Leave += new System.EventHandler(this.priceTextBox_Leave);
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(50, 392);
            this.quantityTextBox.Multiline = true;
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(242, 28);
            this.quantityTextBox.TabIndex = 1;
            this.quantityTextBox.Enter += new System.EventHandler(this.quantityTextBox_Enter);
            this.quantityTextBox.Leave += new System.EventHandler(this.quantityTextBox_Leave);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Items.AddRange(new object[] {
            "Restuarant",
            "Bar"});
            this.categoryComboBox.Location = new System.Drawing.Point(50, 449);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(242, 21);
            this.categoryComboBox.TabIndex = 2;
            // 
            // Okbutton
            // 
            this.Okbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.Okbutton.FlatAppearance.BorderSize = 0;
            this.Okbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Okbutton.Location = new System.Drawing.Point(394, 475);
            this.Okbutton.Name = "Okbutton";
            this.Okbutton.Size = new System.Drawing.Size(126, 48);
            this.Okbutton.TabIndex = 0;
            this.Okbutton.Text = "&Ok";
            this.Okbutton.UseVisualStyleBackColor = false;
            this.Okbutton.Click += new System.EventHandler(this.Okbutton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // sellingPriceTextBox
            // 
            this.sellingPriceTextBox.Location = new System.Drawing.Point(50, 335);
            this.sellingPriceTextBox.Multiline = true;
            this.sellingPriceTextBox.Name = "sellingPriceTextBox";
            this.sellingPriceTextBox.Size = new System.Drawing.Size(242, 28);
            this.sellingPriceTextBox.TabIndex = 1;
            this.sellingPriceTextBox.Enter += new System.EventHandler(this.sellingPriceTextBox_Enter);
            this.sellingPriceTextBox.Leave += new System.EventHandler(this.sellingPriceTextBox_Leave);
            // 
            // AddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 544);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.descTextBox);
            this.Controls.Add(this.sellingPriceTextBox);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.costPriceTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.Okbutton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddItem";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Item";
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
        private System.Windows.Forms.Button Okbutton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox sellingPriceTextBox;
    }
}