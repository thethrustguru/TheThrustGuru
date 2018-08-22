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
            this.customersButton = new System.Windows.Forms.Button();
            this.vendorButton = new System.Windows.Forms.Button();
            this.suppliersButton = new System.Windows.Forms.Button();
            this.salesRepbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.buttonsPanel.Controls.Add(this.label4);
            this.buttonsPanel.Controls.Add(this.label3);
            this.buttonsPanel.Controls.Add(this.label1);
            this.buttonsPanel.Controls.Add(this.label5);
            this.buttonsPanel.Controls.Add(this.label2);
            this.buttonsPanel.Controls.Add(this.salesRepbutton);
            this.buttonsPanel.Controls.Add(this.customersButton);
            this.buttonsPanel.Controls.Add(this.vendorButton);
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
            // customersButton
            // 
            this.customersButton.FlatAppearance.BorderSize = 0;
            this.customersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.customersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customersButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customersButton.ForeColor = System.Drawing.Color.White;
            this.customersButton.Location = new System.Drawing.Point(2, 183);
            this.customersButton.Name = "customersButton";
            this.customersButton.Size = new System.Drawing.Size(151, 49);
            this.customersButton.TabIndex = 3;
            this.customersButton.Text = "Customers";
            this.customersButton.UseVisualStyleBackColor = true;
            this.customersButton.Click += new System.EventHandler(this.customersButton_Click);
            // 
            // vendorButton
            // 
            this.vendorButton.FlatAppearance.BorderSize = 0;
            this.vendorButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.vendorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vendorButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendorButton.ForeColor = System.Drawing.Color.White;
            this.vendorButton.Location = new System.Drawing.Point(0, 130);
            this.vendorButton.Name = "vendorButton";
            this.vendorButton.Size = new System.Drawing.Size(152, 49);
            this.vendorButton.TabIndex = 3;
            this.vendorButton.Text = "Vendors";
            this.vendorButton.UseVisualStyleBackColor = true;
            this.vendorButton.Click += new System.EventHandler(this.vendorButton_Click);
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
            // salesRepbutton
            // 
            this.salesRepbutton.FlatAppearance.BorderSize = 0;
            this.salesRepbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.salesRepbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salesRepbutton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesRepbutton.ForeColor = System.Drawing.Color.White;
            this.salesRepbutton.Location = new System.Drawing.Point(3, 234);
            this.salesRepbutton.Name = "salesRepbutton";
            this.salesRepbutton.Size = new System.Drawing.Size(151, 49);
            this.salesRepbutton.TabIndex = 3;
            this.salesRepbutton.Text = "Sales Reps";
            this.salesRepbutton.UseVisualStyleBackColor = true;
            this.salesRepbutton.Click += new System.EventHandler(this.salesRepbutton_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 1);
            this.label3.TabIndex = 4;
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
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Account";
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
        private System.Windows.Forms.Button customersButton;
        private System.Windows.Forms.Button vendorButton;
        private System.Windows.Forms.Button suppliersButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button salesRepbutton;
    }
}