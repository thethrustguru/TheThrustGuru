namespace TheThrustGuru
{
    partial class MainForm
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
            this.networkLabel = new System.Windows.Forms.Label();
            this.homeButton = new System.Windows.Forms.Button();
            this.foodItemsButton = new System.Windows.Forms.Button();
            this.transactionButton = new System.Windows.Forms.Button();
            this.recipesButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // networkLabel
            // 
            this.networkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.networkLabel.AutoSize = true;
            this.networkLabel.BackColor = System.Drawing.SystemColors.Control;
            this.networkLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.networkLabel.Location = new System.Drawing.Point(1021, 590);
            this.networkLabel.Name = "networkLabel";
            this.networkLabel.Size = new System.Drawing.Size(15, 13);
            this.networkLabel.TabIndex = 3;
            this.networkLabel.Text = "m";
            // 
            // homeButton
            // 
            this.homeButton.FlatAppearance.BorderSize = 0;
            this.homeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeButton.ForeColor = System.Drawing.Color.White;
            this.homeButton.Location = new System.Drawing.Point(0, 131);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(164, 49);
            this.homeButton.TabIndex = 0;
            this.homeButton.Text = "Home";
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // foodItemsButton
            // 
            this.foodItemsButton.FlatAppearance.BorderSize = 0;
            this.foodItemsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.foodItemsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.foodItemsButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodItemsButton.ForeColor = System.Drawing.Color.White;
            this.foodItemsButton.Location = new System.Drawing.Point(-1, 185);
            this.foodItemsButton.Name = "foodItemsButton";
            this.foodItemsButton.Size = new System.Drawing.Size(165, 49);
            this.foodItemsButton.TabIndex = 0;
            this.foodItemsButton.Text = "Food Items";
            this.foodItemsButton.UseVisualStyleBackColor = true;
            this.foodItemsButton.Click += new System.EventHandler(this.foodItemsButton_Click);
            // 
            // transactionButton
            // 
            this.transactionButton.FlatAppearance.BorderSize = 0;
            this.transactionButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.transactionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transactionButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionButton.ForeColor = System.Drawing.Color.White;
            this.transactionButton.Location = new System.Drawing.Point(0, 295);
            this.transactionButton.Name = "transactionButton";
            this.transactionButton.Size = new System.Drawing.Size(164, 50);
            this.transactionButton.TabIndex = 0;
            this.transactionButton.Text = "Transaction";
            this.transactionButton.UseVisualStyleBackColor = true;
            // 
            // recipesButton
            // 
            this.recipesButton.FlatAppearance.BorderSize = 0;
            this.recipesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.recipesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recipesButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipesButton.ForeColor = System.Drawing.Color.White;
            this.recipesButton.Location = new System.Drawing.Point(0, 239);
            this.recipesButton.Name = "recipesButton";
            this.recipesButton.Size = new System.Drawing.Size(164, 51);
            this.recipesButton.TabIndex = 0;
            this.recipesButton.Text = "Recipes";
            this.recipesButton.UseVisualStyleBackColor = true;
            this.recipesButton.Click += new System.EventHandler(this.recipesButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(0, 352);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(163, 49);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 1);
            this.label1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-1, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 1);
            this.label2.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 1);
            this.label5.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(-4, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 1);
            this.label4.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-3, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 1);
            this.label3.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(-3, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 1);
            this.label6.TabIndex = 2;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.buttonsPanel.Controls.Add(this.label6);
            this.buttonsPanel.Controls.Add(this.label3);
            this.buttonsPanel.Controls.Add(this.label4);
            this.buttonsPanel.Controls.Add(this.label5);
            this.buttonsPanel.Controls.Add(this.label2);
            this.buttonsPanel.Controls.Add(this.label1);
            this.buttonsPanel.Controls.Add(this.exitButton);
            this.buttonsPanel.Controls.Add(this.recipesButton);
            this.buttonsPanel.Controls.Add(this.transactionButton);
            this.buttonsPanel.Controls.Add(this.foodItemsButton);
            this.buttonsPanel.Controls.Add(this.homeButton);
            this.buttonsPanel.Location = new System.Drawing.Point(2, 1);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(165, 602);
            this.buttonsPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1152, 612);
            this.Controls.Add(this.networkLabel);
            this.Controls.Add(this.buttonsPanel);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "The Thrust Guru";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label networkLabel;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Button foodItemsButton;
        private System.Windows.Forms.Button transactionButton;
        private System.Windows.Forms.Button recipesButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel buttonsPanel;
    }
}

