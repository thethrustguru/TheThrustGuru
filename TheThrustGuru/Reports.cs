using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheThrustGuru.DataModels;

namespace TheThrustGuru
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }
        public Reports(PurchaseOrderDataModel purchases, List<StockDataModel> stocks, SupplierDataModel suppliers, ClientDataModel clients)
        {
            InitializeComponent();

            ClientDataModelBindingSource.DataSource = clients;
            SupplierDataModelBindingSource.DataSource = suppliers;
            PurchaseOrderDataModelBindingSource.DataSource = purchases;
            StockDataModelBindingSource.DataSource = stocks;
        }

        private void Reports_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();            
        }
    }
}
