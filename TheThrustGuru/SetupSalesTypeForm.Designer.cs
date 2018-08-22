namespace TheThrustGuru
{
    partial class SetupSalesTypeForm
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
            this.amountLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.discountTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.serviceChagePanel = new System.Windows.Forms.Panel();
            this.serviceChargecheckBox = new System.Windows.Forms.CheckBox();
            this.serviceChargetextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.serviceChagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(12, 47);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(66, 13);
            this.amountLabel.TabIndex = 0;
            this.amountLabel.Text = "Discount (%)";
            // 
            // saveButton
            // 
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(210, 197);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(88, 41);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // discountTextBox
            // 
            this.discountTextBox.Location = new System.Drawing.Point(12, 71);
            this.discountTextBox.Name = "discountTextBox";
            this.discountTextBox.Size = new System.Drawing.Size(114, 20);
            this.discountTextBox.TabIndex = 2;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(15, 110);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(85, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Sales type name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 135);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(286, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // serviceChagePanel
            // 
            this.serviceChagePanel.Controls.Add(this.serviceChargecheckBox);
            this.serviceChagePanel.Controls.Add(this.serviceChargetextBox);
            this.serviceChagePanel.Controls.Add(this.label3);
            this.serviceChagePanel.Location = new System.Drawing.Point(157, 38);
            this.serviceChagePanel.Name = "serviceChagePanel";
            this.serviceChagePanel.Size = new System.Drawing.Size(161, 85);
            this.serviceChagePanel.TabIndex = 3;
            this.serviceChagePanel.Visible = false;
            // 
            // serviceChargecheckBox
            // 
            this.serviceChargecheckBox.AutoSize = true;
            this.serviceChargecheckBox.Location = new System.Drawing.Point(3, 8);
            this.serviceChargecheckBox.Name = "serviceChargecheckBox";
            this.serviceChargecheckBox.Size = new System.Drawing.Size(141, 17);
            this.serviceChargecheckBox.TabIndex = 0;
            this.serviceChargecheckBox.Text = "Calculate by percentage";
            this.serviceChargecheckBox.UseVisualStyleBackColor = true;
            this.serviceChargecheckBox.CheckedChanged += new System.EventHandler(this.serviceChargecheckBox_CheckedChanged);
            // 
            // serviceChargetextBox
            // 
            this.serviceChargetextBox.Enabled = false;
            this.serviceChargetextBox.Location = new System.Drawing.Point(3, 32);
            this.serviceChargetextBox.Name = "serviceChargetextBox";
            this.serviceChargetextBox.Size = new System.Drawing.Size(114, 20);
            this.serviceChargetextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "% increase";
            // 
            // SetupSalesTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 261);
            this.Controls.Add(this.serviceChagePanel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.discountTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.amountLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SetupSalesTypeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SetupSalesTypeForm_Load);
            this.serviceChagePanel.ResumeLayout(false);
            this.serviceChagePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox discountTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Panel serviceChagePanel;
        private System.Windows.Forms.CheckBox serviceChargecheckBox;
        private System.Windows.Forms.TextBox serviceChargetextBox;
        private System.Windows.Forms.Label label3;
    }
}