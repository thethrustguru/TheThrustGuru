namespace TheThrustGuru
{
    partial class Reports
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PurchaseOrderDataModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StockDataModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SupplierDataModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClientDataModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDataModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockDataModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDataModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientDataModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetPurchasedStocks";
            reportDataSource1.Value = this.PurchaseOrderDataModelBindingSource;
            reportDataSource2.Name = "DataSetPurchaseOrder";
            reportDataSource2.Value = this.PurchaseOrderDataModelBindingSource;
            reportDataSource3.Name = "DataSetStocks";
            reportDataSource3.Value = this.StockDataModelBindingSource;
            reportDataSource4.Name = "DataSetSupplier";
            reportDataSource4.Value = this.SupplierDataModelBindingSource;
            reportDataSource5.Name = "DataSetClient";
            reportDataSource5.Value = this.ClientDataModelBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TheThrustGuru.Reports.PurchaseReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(794, 593);
            this.reportViewer1.TabIndex = 0;
            // 
            // PurchaseOrderDataModelBindingSource
            // 
            this.PurchaseOrderDataModelBindingSource.DataMember = "productsList";
            this.PurchaseOrderDataModelBindingSource.DataSource = typeof(TheThrustGuru.DataModels.PurchaseOrderDataModel);
            // 
            // StockDataModelBindingSource
            // 
            this.StockDataModelBindingSource.DataSource = typeof(TheThrustGuru.DataModels.StockDataModel);
            // 
            // SupplierDataModelBindingSource
            // 
            this.SupplierDataModelBindingSource.DataSource = typeof(TheThrustGuru.DataModels.SupplierDataModel);
            // 
            // ClientDataModelBindingSource
            // 
            this.ClientDataModelBindingSource.DataSource = typeof(TheThrustGuru.DataModels.ClientDataModel);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 605);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Reports";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.Reports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrderDataModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockDataModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDataModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientDataModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PurchaseOrderDataModelBindingSource;
        private System.Windows.Forms.BindingSource StockDataModelBindingSource;
        private System.Windows.Forms.BindingSource SupplierDataModelBindingSource;
        private System.Windows.Forms.BindingSource ClientDataModelBindingSource;
    }
}