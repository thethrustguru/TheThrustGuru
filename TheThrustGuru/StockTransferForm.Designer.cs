namespace TheThrustGuru
{
    partial class StockTransferForm
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
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.receiveStockButton = new System.Windows.Forms.Button();
            this.issueStockButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.buttonsPanel.Controls.Add(this.label4);
            this.buttonsPanel.Controls.Add(this.label1);
            this.buttonsPanel.Controls.Add(this.label3);
            this.buttonsPanel.Controls.Add(this.label2);
            this.buttonsPanel.Controls.Add(this.receiveStockButton);
            this.buttonsPanel.Controls.Add(this.issueStockButton);
            this.buttonsPanel.Controls.Add(this.recordButton);
            this.buttonsPanel.Location = new System.Drawing.Point(1, 0);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(154, 464);
            this.buttonsPanel.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(-3, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 1);
            this.label4.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-2, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 1);
            this.label1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-2, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 1);
            this.label3.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-2, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 1);
            this.label2.TabIndex = 4;
            // 
            // receiveStockButton
            // 
            this.receiveStockButton.FlatAppearance.BorderSize = 0;
            this.receiveStockButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.receiveStockButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.receiveStockButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receiveStockButton.ForeColor = System.Drawing.Color.White;
            this.receiveStockButton.Location = new System.Drawing.Point(0, 181);
            this.receiveStockButton.Name = "receiveStockButton";
            this.receiveStockButton.Size = new System.Drawing.Size(151, 51);
            this.receiveStockButton.TabIndex = 3;
            this.receiveStockButton.Text = "Receive stock";
            this.receiveStockButton.UseVisualStyleBackColor = true;
            this.receiveStockButton.Click += new System.EventHandler(this.receiveStockButton_Click);
            // 
            // issueStockButton
            // 
            this.issueStockButton.FlatAppearance.BorderSize = 0;
            this.issueStockButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.issueStockButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.issueStockButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issueStockButton.ForeColor = System.Drawing.Color.White;
            this.issueStockButton.Location = new System.Drawing.Point(0, 127);
            this.issueStockButton.Name = "issueStockButton";
            this.issueStockButton.Size = new System.Drawing.Size(151, 51);
            this.issueStockButton.TabIndex = 3;
            this.issueStockButton.Text = "Issue stock";
            this.issueStockButton.UseVisualStyleBackColor = true;
            this.issueStockButton.Click += new System.EventHandler(this.issueStockButton_Click);
            // 
            // recordButton
            // 
            this.recordButton.FlatAppearance.BorderSize = 0;
            this.recordButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.recordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recordButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordButton.ForeColor = System.Drawing.Color.White;
            this.recordButton.Location = new System.Drawing.Point(0, 75);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(153, 49);
            this.recordButton.TabIndex = 3;
            this.recordButton.Text = "Transfer record";
            this.recordButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(161, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(634, 441);
            this.dataGridView1.TabIndex = 2;
            // 
            // StockTransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(800, 465);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StockTransferForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Transfer";
            this.buttonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button receiveStockButton;
        private System.Windows.Forms.Button issueStockButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}