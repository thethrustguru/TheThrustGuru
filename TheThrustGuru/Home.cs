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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            // set search texbox to gray state
            searchTextBox.ForeColor = Color.Gray;
            searchTextBox.Text = "Search...";
        }

        private void waterMarkOnTextBoxLeave(TextBox textbox, string placeHolder)
        {
            if (String.IsNullOrEmpty(textbox.Text) || textbox.Text == placeHolder)
            {
                textbox.ForeColor = Color.Gray;
                textbox.Text = placeHolder;
            }
            else
            {
                textbox.ForeColor = Color.Black;
            }
        }
        private void waterMarkOnTextBoxEnter(TextBox textbox)
        {
            textbox.Text = String.Empty;
            textbox.ForeColor = Color.Black;
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(this.searchTextBox, "Search...");
        }

        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(this.searchTextBox);
        }
    }
}
