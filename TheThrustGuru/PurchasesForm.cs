using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheThrustGuru.Database;
using TheThrustGuru.Logics;

namespace TheThrustGuru
{
    public partial class PurchasesForm : Form
    {
        private string search = "search...";
        private string searchParam = "Select search parameter...";

        public PurchasesForm()
        {
            InitializeComponent();
        }
        
        private void PurchasesForm_Load(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(searchTextBox, search);

            if (!searchParamComboBox.Items.Contains(searchParam))
                searchParamComboBox.Items.Add(searchParam);
            searchParamComboBox.Text = searchParam;

            var data = DatabaseOperations.getPurchases();
            decimal total_price = 0;
            if(data != null && data.Any())
            {
                foreach (var datum in data)
                {
                    total_price += datum.grandTotalPrice;

                }                
                new UpdateDataGridView().addPurchaseToDataGrid(data, this.dataGridView1);
            }
            totalPricetextBox.Text = total_price.ToString("C3");
        }

        private void purchaseButton_Click(object sender, EventArgs e)
        {
            new AddPurchasesForm().ShowDialog();
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

        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(searchTextBox);
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(searchTextBox, search);
        }

        private void searchParamComboBox_DropDown(object sender, EventArgs e)
        {
            if (searchParamComboBox.Items.Contains(searchParam))
                searchParamComboBox.Items.Remove(searchParam);
        }

        private void searchParamComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (searchParamComboBox.SelectedIndex == -1)
            {
                if (!searchParamComboBox.Items.Contains(searchParam))
                    searchParamComboBox.Items.Add(searchParam);
                searchParamComboBox.Text = searchParam;
            }
        }
    }
}
