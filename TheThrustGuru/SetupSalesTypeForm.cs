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
    public partial class SetupSalesTypeForm : Form
    {
        public SetupSalesTypeForm()
        {
            InitializeComponent();
        }

        public SetupSalesTypeForm(bool value)
        {
            InitializeComponent();

            amountLabel.Text = "Service charge amount";
            nameLabel.Text = "Service charge name";
            serviceChagePanel.Visible = value;

        }

        private void serviceChargecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (serviceChargecheckBox.Checked)
            {
                serviceChargetextBox.Enabled = true;
                discountTextBox.Enabled = false;
            }
            else
            {
                serviceChargetextBox.Enabled = false;
                discountTextBox.Enabled = true;
            }
        }

        private void SetupSalesTypeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
