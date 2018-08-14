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
    public partial class SuppliersForm : Form
    {
        public SuppliersForm()
        {
            InitializeComponent();
        }

        private void manageItemButton_Click(object sender, EventArgs e)
        {
            AddSuppliers aForm = new AddSuppliers();
            DialogResult result = aForm.ShowDialog();
        }
    }
}
