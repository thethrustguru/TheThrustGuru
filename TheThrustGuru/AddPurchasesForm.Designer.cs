namespace TheThrustGuru
{
    partial class AddPurchasesForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.snColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.addbutton = new System.Windows.Forms.Button();
            this.grandTotalQuantitytextBox = new System.Windows.Forms.TextBox();
            this.totalPriceTextBox = new System.Windows.Forms.TextBox();
            this.grandTotalPricetextBox = new System.Windows.Forms.TextBox();
            this.quantityRemainingtextBox = new System.Windows.Forms.TextBox();
            this.invoicetextBox = new System.Windows.Forms.TextBox();
            this.quantityToSupplytextBox = new System.Windows.Forms.TextBox();
            this.pricetextBox = new System.Windows.Forms.TextBox();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.supplierNameComboBox = new System.Windows.Forms.ComboBox();
            this.productcomboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.saveButton);
            this.panel2.Controls.Add(this.clearButton);
            this.panel2.Controls.Add(this.addbutton);
            this.panel2.Controls.Add(this.grandTotalQuantitytextBox);
            this.panel2.Controls.Add(this.totalPriceTextBox);
            this.panel2.Controls.Add(this.grandTotalPricetextBox);
            this.panel2.Controls.Add(this.quantityRemainingtextBox);
            this.panel2.Controls.Add(this.invoicetextBox);
            this.panel2.Controls.Add(this.quantityToSupplytextBox);
            this.panel2.Controls.Add(this.pricetextBox);
            this.panel2.Controls.Add(this.statusComboBox);
            this.panel2.Controls.Add(this.supplierNameComboBox);
            this.panel2.Controls.Add(this.productcomboBox);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(20, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1048, 476);
            this.panel2.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.snColumn,
            this.productColumn,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(488, 26);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(543, 410);
            this.dataGridView1.TabIndex = 4;
            // 
            // snColumn
            // 
            this.snColumn.HeaderText = "S/N";
            this.snColumn.Name = "snColumn";
            this.snColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.snColumn.Width = 40;
            // 
            // productColumn
            // 
            this.productColumn.HeaderText = "Product ";
            this.productColumn.Name = "productColumn";
            this.productColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Price";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Quantity to supply";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Total Price";
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Quantity remaining";
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(236, 433);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 32);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(354, 433);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(100, 32);
            this.clearButton.TabIndex = 0;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // addbutton
            // 
            this.addbutton.Location = new System.Drawing.Point(166, 328);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(100, 32);
            this.addbutton.TabIndex = 0;
            this.addbutton.Text = "Add";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // grandTotalQuantitytextBox
            // 
            this.grandTotalQuantitytextBox.Location = new System.Drawing.Point(127, 414);
            this.grandTotalQuantitytextBox.Name = "grandTotalQuantitytextBox";
            this.grandTotalQuantitytextBox.ReadOnly = true;
            this.grandTotalQuantitytextBox.Size = new System.Drawing.Size(92, 20);
            this.grandTotalQuantitytextBox.TabIndex = 3;
            // 
            // totalPriceTextBox
            // 
            this.totalPriceTextBox.Location = new System.Drawing.Point(91, 372);
            this.totalPriceTextBox.Name = "totalPriceTextBox";
            this.totalPriceTextBox.ReadOnly = true;
            this.totalPriceTextBox.Size = new System.Drawing.Size(92, 20);
            this.totalPriceTextBox.TabIndex = 3;
            // 
            // grandTotalPricetextBox
            // 
            this.grandTotalPricetextBox.Location = new System.Drawing.Point(322, 375);
            this.grandTotalPricetextBox.Name = "grandTotalPricetextBox";
            this.grandTotalPricetextBox.ReadOnly = true;
            this.grandTotalPricetextBox.Size = new System.Drawing.Size(92, 20);
            this.grandTotalPricetextBox.TabIndex = 3;
            // 
            // quantityRemainingtextBox
            // 
            this.quantityRemainingtextBox.Location = new System.Drawing.Point(272, 283);
            this.quantityRemainingtextBox.Name = "quantityRemainingtextBox";
            this.quantityRemainingtextBox.ReadOnly = true;
            this.quantityRemainingtextBox.Size = new System.Drawing.Size(142, 20);
            this.quantityRemainingtextBox.TabIndex = 3;
            // 
            // invoicetextBox
            // 
            this.invoicetextBox.Location = new System.Drawing.Point(324, 85);
            this.invoicetextBox.Name = "invoicetextBox";
            this.invoicetextBox.ReadOnly = true;
            this.invoicetextBox.Size = new System.Drawing.Size(158, 20);
            this.invoicetextBox.TabIndex = 3;
            // 
            // quantityToSupplytextBox
            // 
            this.quantityToSupplytextBox.Location = new System.Drawing.Point(50, 283);
            this.quantityToSupplytextBox.Name = "quantityToSupplytextBox";
            this.quantityToSupplytextBox.Size = new System.Drawing.Size(99, 20);
            this.quantityToSupplytextBox.TabIndex = 3;
            this.quantityToSupplytextBox.TextChanged += new System.EventHandler(this.quantityToSupplytextBox_TextChanged);
            // 
            // pricetextBox
            // 
            this.pricetextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pricetextBox.Location = new System.Drawing.Point(272, 211);
            this.pricetextBox.Name = "pricetextBox";
            this.pricetextBox.ReadOnly = true;
            this.pricetextBox.Size = new System.Drawing.Size(142, 20);
            this.pricetextBox.TabIndex = 3;
            // 
            // statusComboBox
            // 
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] {
            "Pending Confirmation",
            "Confirmed",
            "Delivered"});
            this.statusComboBox.Location = new System.Drawing.Point(324, 27);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(158, 21);
            this.statusComboBox.TabIndex = 2;
            // 
            // supplierNameComboBox
            // 
            this.supplierNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supplierNameComboBox.FormattingEnabled = true;
            this.supplierNameComboBox.Location = new System.Drawing.Point(68, 26);
            this.supplierNameComboBox.Name = "supplierNameComboBox";
            this.supplierNameComboBox.Size = new System.Drawing.Size(185, 21);
            this.supplierNameComboBox.TabIndex = 2;
            this.supplierNameComboBox.SelectedIndexChanged += new System.EventHandler(this.supplierNameComboBox_SelectedIndexChanged);
            // 
            // productcomboBox
            // 
            this.productcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productcomboBox.FormattingEnabled = true;
            this.productcomboBox.Location = new System.Drawing.Point(50, 211);
            this.productcomboBox.Name = "productcomboBox";
            this.productcomboBox.Size = new System.Drawing.Size(185, 21);
            this.productcomboBox.TabIndex = 2;
            this.productcomboBox.SelectedIndexChanged += new System.EventHandler(this.productcomboBox_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.label13.Location = new System.Drawing.Point(1, 140);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(487, 1);
            this.label13.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.label12.Location = new System.Drawing.Point(2, 363);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(486, 1);
            this.label12.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 417);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Grand Total Quantity";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(68, 82);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(185, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(27, 375);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Total Price";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(226, 378);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Grand Total Price";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(269, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Quantity remaining";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Quantity to supply";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(269, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Product";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Invoice no";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Supplier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Add Purchase";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddPurchasesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 536);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddPurchasesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Purchases";
            this.Load += new System.EventHandler(this.AddPurchasesForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.TextBox grandTotalPricetextBox;
        private System.Windows.Forms.TextBox quantityRemainingtextBox;
        private System.Windows.Forms.TextBox invoicetextBox;
        private System.Windows.Forms.TextBox quantityToSupplytextBox;
        private System.Windows.Forms.TextBox pricetextBox;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.ComboBox supplierNameComboBox;
        private System.Windows.Forms.ComboBox productcomboBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox grandTotalQuantitytextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn snColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox totalPriceTextBox;
        private System.Windows.Forms.Label label14;
    }
}