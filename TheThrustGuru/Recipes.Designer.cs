namespace TheThrustGuru
{
    partial class Recipes
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
            this.label1 = new System.Windows.Forms.Label();
            this.recipesTextBox = new System.Windows.Forms.Label();
            this.searchRTextBox = new System.Windows.Forms.TextBox();
            this.AddRButton = new System.Windows.Forms.Button();
            this.ExportRButton = new System.Windows.Forms.Button();
            this.searchRButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cartDataGridView = new System.Windows.Forms.DataGridView();
            this.seriaNoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirmButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.cartDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.label1.Location = new System.Drawing.Point(35, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(816, 2);
            this.label1.TabIndex = 0;
            // 
            // recipesTextBox
            // 
            this.recipesTextBox.AutoSize = true;
            this.recipesTextBox.Location = new System.Drawing.Point(32, 40);
            this.recipesTextBox.Name = "recipesTextBox";
            this.recipesTextBox.Size = new System.Drawing.Size(46, 13);
            this.recipesTextBox.TabIndex = 1;
            this.recipesTextBox.Text = "Recipes";
            // 
            // searchRTextBox
            // 
            this.searchRTextBox.Location = new System.Drawing.Point(35, 84);
            this.searchRTextBox.Name = "searchRTextBox";
            this.searchRTextBox.Size = new System.Drawing.Size(258, 20);
            this.searchRTextBox.TabIndex = 66;
            this.searchRTextBox.Enter += new System.EventHandler(this.searchRTextBox_Enter);
            this.searchRTextBox.Leave += new System.EventHandler(this.searchRTextBox_Leave);
            // 
            // AddRButton
            // 
            this.AddRButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.AddRButton.FlatAppearance.BorderSize = 0;
            this.AddRButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddRButton.Location = new System.Drawing.Point(579, 69);
            this.AddRButton.Name = "AddRButton";
            this.AddRButton.Size = new System.Drawing.Size(126, 48);
            this.AddRButton.TabIndex = 3;
            this.AddRButton.Text = "&Add Recipe";
            this.AddRButton.UseVisualStyleBackColor = false;
            this.AddRButton.Click += new System.EventHandler(this.AddRButton_Click);
            // 
            // ExportRButton
            // 
            this.ExportRButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.ExportRButton.FlatAppearance.BorderSize = 0;
            this.ExportRButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportRButton.Location = new System.Drawing.Point(725, 70);
            this.ExportRButton.Name = "ExportRButton";
            this.ExportRButton.Size = new System.Drawing.Size(126, 48);
            this.ExportRButton.TabIndex = 4;
            this.ExportRButton.Text = "&Export Data";
            this.ExportRButton.UseVisualStyleBackColor = false;
            // 
            // searchRButton
            // 
            this.searchRButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.searchRButton.ContextMenuStrip = this.contextMenuStrip;
            this.searchRButton.FlatAppearance.BorderSize = 0;
            this.searchRButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchRButton.Location = new System.Drawing.Point(322, 82);
            this.searchRButton.Name = "searchRButton";
            this.searchRButton.Size = new System.Drawing.Size(75, 23);
            this.searchRButton.TabIndex = 2;
            this.searchRButton.Text = "&Search";
            this.searchRButton.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(35, 132);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(528, 490);
            this.flowLayoutPanel1.TabIndex = 67;
            // 
            // cartDataGridView
            // 
            this.cartDataGridView.AllowUserToAddRows = false;
            this.cartDataGridView.AllowUserToDeleteRows = false;
            this.cartDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cartDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cartDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seriaNoColumn,
            this.nameColumn});
            this.cartDataGridView.Location = new System.Drawing.Point(579, 132);
            this.cartDataGridView.MultiSelect = false;
            this.cartDataGridView.Name = "cartDataGridView";
            this.cartDataGridView.ReadOnly = true;
            this.cartDataGridView.RowHeadersVisible = false;
            this.cartDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cartDataGridView.Size = new System.Drawing.Size(272, 427);
            this.cartDataGridView.TabIndex = 68;
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
            this.nameColumn.Width = 230;
            // 
            // confirmButton
            // 
            this.confirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.confirmButton.FlatAppearance.BorderSize = 0;
            this.confirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmButton.Location = new System.Drawing.Point(579, 573);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(126, 48);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = false;
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.clearButton.FlatAppearance.BorderSize = 0;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Location = new System.Drawing.Point(725, 574);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(126, 48);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "&Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 76);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Egusi Recipe";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(832, 219);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 105);
            this.panel1.TabIndex = 69;
            this.panel1.Visible = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(135, 48);
            this.contextMenuStrip.Text = "Edit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.editToolStripMenuItem.Text = "Edit item";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.deleteToolStripMenuItem.Text = "Delete item";
            // 
            // Recipes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1000, 651);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cartDataGridView);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.ExportRButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.searchRButton);
            this.Controls.Add(this.AddRButton);
            this.Controls.Add(this.searchRTextBox);
            this.Controls.Add(this.recipesTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(170, 0);
            this.Name = "Recipes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Recipes";
            this.Load += new System.EventHandler(this.Recipes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cartDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label recipesTextBox;
        private System.Windows.Forms.TextBox searchRTextBox;
        private System.Windows.Forms.Button AddRButton;
        private System.Windows.Forms.Button ExportRButton;
        private System.Windows.Forms.Button searchRButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView cartDataGridView;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn seriaNoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}