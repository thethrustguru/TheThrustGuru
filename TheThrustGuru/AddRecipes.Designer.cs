namespace TheThrustGuru
{
    partial class AddRecipes
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
            this.descTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.itemsDataGridView = new System.Windows.Forms.DataGridView();
            this.serialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foodItemsComboBox = new System.Windows.Forms.ComboBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.itemsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // descTextBox
            // 
            this.descTextBox.Location = new System.Drawing.Point(50, 94);
            this.descTextBox.Multiline = true;
            this.descTextBox.Name = "descTextBox";
            this.descTextBox.Size = new System.Drawing.Size(332, 86);
            this.descTextBox.TabIndex = 2;
            this.descTextBox.Enter += new System.EventHandler(this.descTextBox_Enter);
            this.descTextBox.Leave += new System.EventHandler(this.descTextBox_Leave);
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(50, 200);
            this.priceTextBox.Multiline = true;
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(332, 31);
            this.priceTextBox.TabIndex = 3;
            this.priceTextBox.Visible = false;
            this.priceTextBox.Enter += new System.EventHandler(this.priceTextBox_Enter);
            this.priceTextBox.Leave += new System.EventHandler(this.priceTextBox_Leave);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(50, 45);
            this.nameTextBox.Multiline = true;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(332, 27);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.Enter += new System.EventHandler(this.nameTextBox_Enter);
            this.nameTextBox.Leave += new System.EventHandler(this.nameTextBox_Leave);
            // 
            // itemsDataGridView
            // 
            this.itemsDataGridView.AllowUserToAddRows = false;
            this.itemsDataGridView.AllowUserToDeleteRows = false;
            this.itemsDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.itemsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serialNo,
            this.nameColumn,
            this.totalPriceColumn,
            this.quantityColumn});
            this.itemsDataGridView.Location = new System.Drawing.Point(50, 252);
            this.itemsDataGridView.Name = "itemsDataGridView";
            this.itemsDataGridView.RowHeadersVisible = false;
            this.itemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemsDataGridView.Size = new System.Drawing.Size(332, 269);
            this.itemsDataGridView.TabIndex = 0;
            // 
            // serialNo
            // 
            this.serialNo.HeaderText = "S/N";
            this.serialNo.Name = "serialNo";
            this.serialNo.ReadOnly = true;
            this.serialNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.serialNo.Width = 50;
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nameColumn.Width = 120;
            // 
            // totalPriceColumn
            // 
            this.totalPriceColumn.HeaderText = "Total Price";
            this.totalPriceColumn.Name = "totalPriceColumn";
            this.totalPriceColumn.ReadOnly = true;
            this.totalPriceColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // quantityColumn
            // 
            this.quantityColumn.HeaderText = "Quantity";
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.ReadOnly = true;
            this.quantityColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quantityColumn.Width = 60;
            // 
            // foodItemsComboBox
            // 
            this.foodItemsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.foodItemsComboBox.FormattingEnabled = true;
            this.foodItemsComboBox.Location = new System.Drawing.Point(399, 45);
            this.foodItemsComboBox.Name = "foodItemsComboBox";
            this.foodItemsComboBox.Size = new System.Drawing.Size(222, 21);
            this.foodItemsComboBox.TabIndex = 4;
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(627, 45);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(59, 20);
            this.quantityTextBox.TabIndex = 5;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Location = new System.Drawing.Point(495, 79);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(126, 48);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "&Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(560, 455);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(126, 48);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.okButton.FlatAppearance.BorderSize = 0;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(428, 455);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(126, 48);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // AddRecipes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 544);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.foodItemsComboBox);
            this.Controls.Add(this.itemsDataGridView);
            this.Controls.Add(this.descTextBox);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.nameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddRecipes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddRecipes";
            this.Load += new System.EventHandler(this.AddRecipes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descTextBox;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.DataGridView itemsDataGridView;
        private System.Windows.Forms.ComboBox foodItemsComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityColumn;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button okButton;
    }
}