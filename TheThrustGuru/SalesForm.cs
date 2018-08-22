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
    public partial class SalesForm : Form
    {
        private string searchParam = "Select search parameter...";
        private string search = "search...";
        public SalesForm()
        {
            InitializeComponent();
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

        private void searchParamComboBox_DropDown(object sender, EventArgs e)
        {
            if (searchParamComboBox.Items.Contains(searchParam))
                searchParamComboBox.Items.Remove(searchParam);
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(searchTextBox, search);

            if (!searchParamComboBox.Items.Contains(searchParam))
                searchParamComboBox.Items.Add(searchParam);
            searchParamComboBox.Text = searchParam;
        }

        private void searchParamComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if(searchParamComboBox.SelectedIndex == -1)
            {
                if (!searchParamComboBox.Items.Contains(searchParam))
                    searchParamComboBox.Items.Add(searchParam);
                searchParamComboBox.Text = searchParam;
            }
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(searchTextBox, search);
        }

        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(searchTextBox);
        }
    }
}
