namespace TheThrustGuru
{
    partial class Home
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
            this.cartDataGridView = new System.Windows.Forms.DataGridView();
            this.seriaNoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ExportRButton = new System.Windows.Forms.Button();
            this.searchRButton = new System.Windows.Forms.Button();
            this.AddRButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.recipesTextBox = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.checkoutButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cartDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cartDataGridView
            // 
            this.cartDataGridView.AllowUserToAddRows = false;
            this.cartDataGridView.AllowUserToDeleteRows = false;
            this.cartDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cartDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cartDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seriaNoColumn,
            this.nameColumn,
            this.priceColumn,
            this.quantityColumn});
            this.cartDataGridView.Location = new System.Drawing.Point(579, 143);
            this.cartDataGridView.MultiSelect = false;
            this.cartDataGridView.Name = "cartDataGridView";
            this.cartDataGridView.ReadOnly = true;
            this.cartDataGridView.RowHeadersVisible = false;
            this.cartDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cartDataGridView.Size = new System.Drawing.Size(272, 427);
            this.cartDataGridView.TabIndex = 78;
            // 
            // seriaNoColumn
            // 
            this.seriaNoColumn.HeaderText = "S/N";
            this.seriaNoColumn.Name = "seriaNoColumn";
            this.seriaNoColumn.ReadOnly = true;
            this.seriaNoColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.seriaNoColumn.Width = 40;
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nameColumn.Width = 107;
            // 
            // priceColumn
            // 
            this.priceColumn.HeaderText = "Price";
            this.priceColumn.Name = "priceColumn";
            this.priceColumn.ReadOnly = true;
            this.priceColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.priceColumn.Width = 63;
            // 
            // quantityColumn
            // 
            this.quantityColumn.HeaderText = "Quantity";
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.ReadOnly = true;
            this.quantityColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quantityColumn.Width = 60;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(35, 143);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(528, 490);
            this.flowLayoutPanel1.TabIndex = 77;
            // 
            // ExportRButton
            // 
            this.ExportRButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.ExportRButton.FlatAppearance.BorderSize = 0;
            this.ExportRButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportRButton.Location = new System.Drawing.Point(726, 78);
            this.ExportRButton.Name = "ExportRButton";
            this.ExportRButton.Size = new System.Drawing.Size(126, 48);
            this.ExportRButton.TabIndex = 74;
            this.ExportRButton.Text = "&Export Data";
            this.ExportRButton.UseVisualStyleBackColor = false;
            // 
            // searchRButton
            // 
            this.searchRButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.searchRButton.FlatAppearance.BorderSize = 0;
            this.searchRButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchRButton.Location = new System.Drawing.Point(323, 90);
            this.searchRButton.Name = "searchRButton";
            this.searchRButton.Size = new System.Drawing.Size(75, 23);
            this.searchRButton.TabIndex = 71;
            this.searchRButton.Text = "&Search";
            this.searchRButton.UseVisualStyleBackColor = false;
            // 
            // AddRButton
            // 
            this.AddRButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.AddRButton.FlatAppearance.BorderSize = 0;
            this.AddRButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddRButton.Location = new System.Drawing.Point(580, 77);
            this.AddRButton.Name = "AddRButton";
            this.AddRButton.Size = new System.Drawing.Size(126, 48);
            this.AddRButton.TabIndex = 72;
            this.AddRButton.Text = "&Add Food";
            this.AddRButton.UseVisualStyleBackColor = false;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(35, 92);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(258, 20);
            this.searchTextBox.TabIndex = 76;
            this.searchTextBox.Enter += new System.EventHandler(this.searchTextBox_Enter);
            this.searchTextBox.Leave += new System.EventHandler(this.searchTextBox_Leave);
            // 
            // recipesTextBox
            // 
            this.recipesTextBox.AutoSize = true;
            this.recipesTextBox.Location = new System.Drawing.Point(32, 40);
            this.recipesTextBox.Name = "recipesTextBox";
            this.recipesTextBox.Size = new System.Drawing.Size(36, 13);
            this.recipesTextBox.TabIndex = 70;
            this.recipesTextBox.Text = "Foods";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.label1.Location = new System.Drawing.Point(35, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(816, 2);
            this.label1.TabIndex = 69;
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.clearButton.FlatAppearance.BorderSize = 0;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Location = new System.Drawing.Point(725, 585);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(126, 48);
            this.clearButton.TabIndex = 75;
            this.clearButton.Text = "&Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            // 
            // checkoutButton
            // 
            this.checkoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.checkoutButton.FlatAppearance.BorderSize = 0;
            this.checkoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkoutButton.Location = new System.Drawing.Point(579, 584);
            this.checkoutButton.Name = "checkoutButton";
            this.checkoutButton.Size = new System.Drawing.Size(126, 48);
            this.checkoutButton.TabIndex = 73;
            this.checkoutButton.Text = "Check &Out";
            this.checkoutButton.UseVisualStyleBackColor = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1000, 651);
            this.Controls.Add(this.cartDataGridView);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ExportRButton);
            this.Controls.Add(this.searchRButton);
            this.Controls.Add(this.AddRButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.recipesTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.checkoutButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(170, 0);
            this.Name = "Home";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Home";
            ((System.ComponentModel.ISupportInitialize)(this.cartDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView cartDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn seriaNoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityColumn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button ExportRButton;
        private System.Windows.Forms.Button searchRButton;
        private System.Windows.Forms.Button AddRButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label recipesTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button checkoutButton;
    }
}