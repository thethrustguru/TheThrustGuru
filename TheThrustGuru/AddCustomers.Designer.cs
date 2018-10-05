namespace TheThrustGuru
{
    partial class AddCustomers
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
            this.closeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.othertextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.balTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addresstextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nametextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.voucherCodeTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.voucherCodeCheckBox = new System.Windows.Forms.CheckBox();
            this.regenerateVoucherbutton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.phoneMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(448, 441);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(118, 39);
            this.closeButton.TabIndex = 20;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // addButton
            // 
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Location = new System.Drawing.Point(310, 441);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(118, 39);
            this.addButton.TabIndex = 19;
            this.addButton.Text = "&Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // othertextBox
            // 
            this.othertextBox.Location = new System.Drawing.Point(22, 419);
            this.othertextBox.Multiline = true;
            this.othertextBox.Name = "othertextBox";
            this.othertextBox.Size = new System.Drawing.Size(217, 69);
            this.othertextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 398);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Other";
            // 
            // balTextBox
            // 
            this.balTextBox.Location = new System.Drawing.Point(22, 186);
            this.balTextBox.Name = "balTextBox";
            this.balTextBox.Size = new System.Drawing.Size(217, 20);
            this.balTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Contact Phone";
            // 
            // addresstextBox
            // 
            this.addresstextBox.Location = new System.Drawing.Point(22, 338);
            this.addresstextBox.Multiline = true;
            this.addresstextBox.Name = "addresstextBox";
            this.addresstextBox.Size = new System.Drawing.Size(217, 46);
            this.addresstextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Address";
            // 
            // nametextBox
            // 
            this.nametextBox.Location = new System.Drawing.Point(22, 63);
            this.nametextBox.Name = "nametextBox";
            this.nametextBox.Size = new System.Drawing.Size(217, 20);
            this.nametextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Customer Name";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // voucherCodeTextBox
            // 
            this.voucherCodeTextBox.Location = new System.Drawing.Point(22, 279);
            this.voucherCodeTextBox.Name = "voucherCodeTextBox";
            this.voucherCodeTextBox.ReadOnly = true;
            this.voucherCodeTextBox.Size = new System.Drawing.Size(217, 20);
            this.voucherCodeTextBox.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Voucher code";
            // 
            // voucherCodeCheckBox
            // 
            this.voucherCodeCheckBox.AutoSize = true;
            this.voucherCodeCheckBox.Location = new System.Drawing.Point(22, 223);
            this.voucherCodeCheckBox.Name = "voucherCodeCheckBox";
            this.voucherCodeCheckBox.Size = new System.Drawing.Size(139, 17);
            this.voucherCodeCheckBox.TabIndex = 3;
            this.voucherCodeCheckBox.Text = "Generate voucher code";
            this.voucherCodeCheckBox.UseVisualStyleBackColor = true;
            this.voucherCodeCheckBox.CheckedChanged += new System.EventHandler(this.voucherCodeCheckBox_CheckedChanged);
            // 
            // regenerateVoucherbutton
            // 
            this.regenerateVoucherbutton.Enabled = false;
            this.regenerateVoucherbutton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.regenerateVoucherbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.regenerateVoucherbutton.Image = global::TheThrustGuru.Properties.Resources.refresh_arrow;
            this.regenerateVoucherbutton.Location = new System.Drawing.Point(245, 272);
            this.regenerateVoucherbutton.Name = "regenerateVoucherbutton";
            this.regenerateVoucherbutton.Size = new System.Drawing.Size(30, 30);
            this.regenerateVoucherbutton.TabIndex = 20;
            this.regenerateVoucherbutton.UseVisualStyleBackColor = true;
            this.regenerateVoucherbutton.Click += new System.EventHandler(this.regenerateVoucherbutton_Click);
            // 
            // editButton
            // 
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Location = new System.Drawing.Point(310, 390);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(118, 39);
            this.editButton.TabIndex = 19;
            this.editButton.Text = "&Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Visible = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Location = new System.Drawing.Point(448, 390);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(118, 39);
            this.deleteButton.TabIndex = 20;
            this.deleteButton.Text = "&Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Visible = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // phoneMaskedTextBox
            // 
            this.phoneMaskedTextBox.Location = new System.Drawing.Point(22, 120);
            this.phoneMaskedTextBox.Mask = "000-0000-0000";
            this.phoneMaskedTextBox.Name = "phoneMaskedTextBox";
            this.phoneMaskedTextBox.Size = new System.Drawing.Size(217, 20);
            this.phoneMaskedTextBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Balance(₦)";
            // 
            // AddCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 508);
            this.Controls.Add(this.phoneMaskedTextBox);
            this.Controls.Add(this.voucherCodeCheckBox);
            this.Controls.Add(this.regenerateVoucherbutton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.othertextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.balTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addresstextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nametextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.voucherCodeTextBox);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddCustomers";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Customer";
            this.Load += new System.EventHandler(this.AddCustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox othertextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox balTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox addresstextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nametextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox voucherCodeCheckBox;
        private System.Windows.Forms.TextBox voucherCodeTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button regenerateVoucherbutton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.MaskedTextBox phoneMaskedTextBox;
        private System.Windows.Forms.Label label5;
    }
}