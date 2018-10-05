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
    public partial class EditForm : Form
    {
        public int quantity { get; private set; }
        public EditForm()
        {
            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }

        private void validate()
        {
            try
            {
                int qty = int.Parse(quantityTextBox.Text);
                this.quantity = qty;
                errorProvider1.Clear();

                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch(Exception ex)
            {
                errorProvider1.SetError(quantityTextBox, "Quantity not valid");                
            }            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            validate();
        }
    }
}
