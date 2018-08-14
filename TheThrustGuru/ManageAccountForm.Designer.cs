namespace TheThrustGuru
{
    partial class ManageAccountForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.salesButton = new System.Windows.Forms.Button();
            this.userAccountButton = new System.Windows.Forms.Button();
            this.suppliersButton = new System.Windows.Forms.Button();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.buttonsPanel.Controls.Add(this.label4);
            this.buttonsPanel.Controls.Add(this.label1);
            this.buttonsPanel.Controls.Add(this.label5);
            this.buttonsPanel.Controls.Add(this.label2);
            this.buttonsPanel.Controls.Add(this.salesButton);
            this.buttonsPanel.Controls.Add(this.userAccountButton);
            this.buttonsPanel.Controls.Add(this.suppliersButton);
            this.buttonsPanel.Location = new System.Drawing.Point(3, 1);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(154, 519);
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
            this.label1.Location = new System.Drawing.Point(0, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 1);
            this.label1.TabIndex = 4;
            this.label1.Visible = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(-2, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 1);
            this.label5.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-2, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 1);
            this.label2.TabIndex = 4;
            // 
            // salesButton
            // 
            this.salesButton.FlatAppearance.BorderSize = 0;
            this.salesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.salesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salesButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesButton.ForeColor = System.Drawing.Color.White;
            this.salesButton.Location = new System.Drawing.Point(2, 183);
            this.salesButton.Name = "salesButton";
            this.salesButton.Size = new System.Drawing.Size(151, 49);
            this.salesButton.TabIndex = 3;
            this.salesButton.Text = "Sales";
            this.salesButton.UseVisualStyleBackColor = true;
            this.salesButton.Visible = false;
            // 
            // userAccountButton
            // 
            this.userAccountButton.FlatAppearance.BorderSize = 0;
            this.userAccountButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.userAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userAccountButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAccountButton.ForeColor = System.Drawing.Color.White;
            this.userAccountButton.Location = new System.Drawing.Point(0, 130);
            this.userAccountButton.Name = "userAccountButton";
            this.userAccountButton.Size = new System.Drawing.Size(152, 49);
            this.userAccountButton.TabIndex = 3;
            this.userAccountButton.Text = "User Account";
            this.userAccountButton.UseVisualStyleBackColor = true;
            // 
            // suppliersButton
            // 
            this.suppliersButton.FlatAppearance.BorderSize = 0;
            this.suppliersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.suppliersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suppliersButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppliersButton.ForeColor = System.Drawing.Color.White;
            this.suppliersButton.Location = new System.Drawing.Point(0, 75);
            this.suppliersButton.Name = "suppliersButton";
            this.suppliersButton.Size = new System.Drawing.Size(153, 49);
            this.suppliersButton.TabIndex = 3;
            this.suppliersButton.Text = "Suppliers";
            this.suppliersButton.UseVisualStyleBackColor = true;
            this.suppliersButton.Click += new System.EventHandler(this.allItemsButton_Click);
            // 
            // ManageAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 523);
            this.Controls.Add(this.buttonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IsMdiContainer = true;
            this.Name = "ManageAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageAccountForm";
            this.Load += new System.EventHandler(this.ManageAccountForm_Load);
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button salesButton;
        private System.Windows.Forms.Button userAccountButton;
        private System.Windows.Forms.Button suppliersButton;
    }
}