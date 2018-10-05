namespace TheThrustGuru
{
    partial class SetStockUnitPriceForm
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
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.highestCostPriceTextBox = new System.Windows.Forms.TextBox();
            this.stockComboBox = new System.Windows.Forms.ComboBox();
            this.lowestCostPriceTextBox = new System.Windows.Forms.TextBox();
            this.lastCostPriceTextBox = new System.Windows.Forms.TextBox();
            this.lastUnitPriceTextBox = new System.Windows.Forms.TextBox();
            this.newUnitPriceTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(12, 57);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(324, 21);
            this.categoryComboBox.TabIndex = 0;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Category";
            // 
            // saveButton
            // 
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(310, 291);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(108, 44);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // highestCostPriceTextBox
            // 
            this.highestCostPriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highestCostPriceTextBox.Location = new System.Drawing.Point(12, 169);
            this.highestCostPriceTextBox.Name = "highestCostPriceTextBox";
            this.highestCostPriceTextBox.ReadOnly = true;
            this.highestCostPriceTextBox.Size = new System.Drawing.Size(159, 20);
            this.highestCostPriceTextBox.TabIndex = 4;
            // 
            // stockComboBox
            // 
            this.stockComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockComboBox.FormattingEnabled = true;
            this.stockComboBox.Location = new System.Drawing.Point(12, 115);
            this.stockComboBox.Name = "stockComboBox";
            this.stockComboBox.Size = new System.Drawing.Size(324, 21);
            this.stockComboBox.TabIndex = 0;
            this.stockComboBox.SelectedIndexChanged += new System.EventHandler(this.stockComboBox_SelectedIndexChanged);
            // 
            // lowestCostPriceTextBox
            // 
            this.lowestCostPriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowestCostPriceTextBox.Location = new System.Drawing.Point(177, 169);
            this.lowestCostPriceTextBox.Name = "lowestCostPriceTextBox";
            this.lowestCostPriceTextBox.ReadOnly = true;
            this.lowestCostPriceTextBox.Size = new System.Drawing.Size(159, 20);
            this.lowestCostPriceTextBox.TabIndex = 4;
            // 
            // lastCostPriceTextBox
            // 
            this.lastCostPriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastCostPriceTextBox.Location = new System.Drawing.Point(12, 224);
            this.lastCostPriceTextBox.Name = "lastCostPriceTextBox";
            this.lastCostPriceTextBox.ReadOnly = true;
            this.lastCostPriceTextBox.Size = new System.Drawing.Size(159, 20);
            this.lastCostPriceTextBox.TabIndex = 4;
            // 
            // lastUnitPriceTextBox
            // 
            this.lastUnitPriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastUnitPriceTextBox.Location = new System.Drawing.Point(177, 224);
            this.lastUnitPriceTextBox.Name = "lastUnitPriceTextBox";
            this.lastUnitPriceTextBox.ReadOnly = true;
            this.lastUnitPriceTextBox.Size = new System.Drawing.Size(159, 20);
            this.lastUnitPriceTextBox.TabIndex = 4;
            // 
            // newUnitPriceTextBox
            // 
            this.newUnitPriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUnitPriceTextBox.Location = new System.Drawing.Point(359, 145);
            this.newUnitPriceTextBox.Name = "newUnitPriceTextBox";
            this.newUnitPriceTextBox.Size = new System.Drawing.Size(109, 20);
            this.newUnitPriceTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select stock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Highest Cost Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Lowest Cost Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Last Cost Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Last Unit Price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(360, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "New Unit Price";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(359, 192);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(109, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SetStockUnitPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 347);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.newUnitPriceTextBox);
            this.Controls.Add(this.lastUnitPriceTextBox);
            this.Controls.Add(this.lastCostPriceTextBox);
            this.Controls.Add(this.lowestCostPriceTextBox);
            this.Controls.Add(this.highestCostPriceTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stockComboBox);
            this.Controls.Add(this.categoryComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SetStockUnitPriceForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Stock Unit Price";
            this.Load += new System.EventHandler(this.SetStockUnitPriceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox highestCostPriceTextBox;
        private System.Windows.Forms.ComboBox stockComboBox;
        private System.Windows.Forms.TextBox lowestCostPriceTextBox;
        private System.Windows.Forms.TextBox lastCostPriceTextBox;
        private System.Windows.Forms.TextBox lastUnitPriceTextBox;
        private System.Windows.Forms.TextBox newUnitPriceTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}