using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheThrustGuru
{
    public partial class GenSalesReport : Form
    {
        private string storeLocation = "";
        public GenSalesReport(string storeLocation)
        {
            InitializeComponent();
            this.storeLocation = storeLocation;
        }

        private void GenSalesReport_Load(object sender, EventArgs e)
        {

        }
    }
}
