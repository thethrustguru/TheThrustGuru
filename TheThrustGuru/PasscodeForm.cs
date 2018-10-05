using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheThrustGuru.Utils;

namespace TheThrustGuru
{
    public partial class PasscodeForm : Form
    {
        public PasscodeForm()
        {
            InitializeComponent();
        }

        private void passcodeTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (passcodeTextBox.Text != Constants.PASSCODE)
            {
                MessageBox.Show("Invalid passcode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                passcodeTextBox.Focus();
                passcodeTextBox.SelectAll();                
            }
            else e.Cancel = false;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
