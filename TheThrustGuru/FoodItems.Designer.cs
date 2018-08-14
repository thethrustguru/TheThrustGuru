using System.Windows.Forms;

namespace TheThrustGuru
{
    partial class FoodItems
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.serialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellingPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_modified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Food Items";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.label2.Location = new System.Drawing.Point(34, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(846, 2);
            this.label2.TabIndex = 1;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Location = new System.Drawing.Point(276, 82);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "&Search";
            this.searchButton.UseVisualStyleBackColor = false;
            // 
            // searchTextBox
            // 
            this.searchTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.searchTextBox.Location = new System.Drawing.Point(37, 84);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(226, 20);
            this.searchTextBox.TabIndex = 66;
            this.searchTextBox.Enter += new System.EventHandler(this.searchTextBox_Enter);
            this.searchTextBox.Leave += new System.EventHandler(this.searchTextBox_Leave);
            // 
            // refreshButton
            // 
            this.refreshButton.AutoSize = true;
            this.refreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.refreshButton.CausesValidation = false;
            this.refreshButton.FlatAppearance.BorderSize = 0;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Location = new System.Drawing.Point(754, 69);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(126, 48);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "&Refresh";
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serialNo,
            this.name,
            this.price,
            this.sellingPriceColumn,
            this.count,
            this.category,
            this.created,
            this.last_modified});
            this.dataGridView1.Location = new System.Drawing.Point(35, 140);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(845, 479);
            this.dataGridView1.TabIndex = 5;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.progressBar.Location = new System.Drawing.Point(368, 82);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(126, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 68;
            this.progressBar.Visible = false;
            // 
            // serialNo
            // 
            this.serialNo.HeaderText = "S/N";
            this.serialNo.Name = "serialNo";
            this.serialNo.ReadOnly = true;
            this.serialNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.serialNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.serialNo.Width = 70;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.name.Width = 170;
            // 
            // price
            // 
            this.price.HeaderText = "Cost Price";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sellingPriceColumn
            // 
            this.sellingPriceColumn.HeaderText = "Selling Price";
            this.sellingPriceColumn.Name = "sellingPriceColumn";
            this.sellingPriceColumn.ReadOnly = true;
            // 
            // count
            // 
            this.count.HeaderText = "Count";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            this.count.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // category
            // 
            this.category.HeaderText = "Total Price";
            this.category.Name = "category";
            this.category.ReadOnly = true;
            this.category.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // created
            // 
            this.created.HeaderText = "Date Created";
            this.created.Name = "created";
            this.created.ReadOnly = true;
            this.created.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // last_modified
            // 
            this.last_modified.HeaderText = "Last Modified";
            this.last_modified.Name = "last_modified";
            this.last_modified.ReadOnly = true;
            this.last_modified.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FoodItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1000, 651);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(170, 0);
            this.Name = "FoodItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FoodItems";
            this.Load += new System.EventHandler(this.FoodItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button searchButton;        
        private Button refreshButton;
        private DataGridView dataGridView1;
        private System.Windows.Forms.TextBox searchTextBox;
        private ProgressBar progressBar;
        private DataGridViewTextBoxColumn serialNo;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn price;
        private DataGridViewTextBoxColumn sellingPriceColumn;
        private DataGridViewTextBoxColumn count;
        private DataGridViewTextBoxColumn category;
        private DataGridViewTextBoxColumn created;
        private DataGridViewTextBoxColumn last_modified;
    }
}