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
using TheThrustGuru.DataModels;
using TheThrustGuru.Utils;

namespace TheThrustGuru
{
    public partial class AddCustomers : Form
    {
        private CustomerDataModel customerModel;
        private string _voucherCode = "";
        public AddCustomers()
        {
            InitializeComponent();
        }

        public AddCustomers(CustomerDataModel customer)
        {
            InitializeComponent();

            nametextBox.Text = customer.customerName;
            phoneMaskedTextBox.Text = customer.phone;
            balTextBox.Text = customer.balance.ToString();
            voucherCodeCheckBox.Checked = customer.isVoucherAvailable;
            if (customer.isVoucherAvailable)
                voucherCodeTextBox.Text = customer.voucherCode;
            addresstextBox.Text = customer.address;
            othertextBox.Text = customer.other;

            editButton.Visible = true;
            deleteButton.Visible = true;
            addButton.Enabled = false;

            customerModel = customer;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            validateControls(false);
        }

        private void AddCustomers_Load(object sender, EventArgs e)
        {
            //voucherCode = RandomIDGenerator.randomInt(Constants.VOUCHER_CODE_LENGTH);

        }

        private void voucherCodeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (voucherCodeCheckBox.Checked)
            {
                _voucherCode = GenerateIDs.voucherCode();
                voucherCodeTextBox.Text = _voucherCode;
                regenerateVoucherbutton.Enabled = true;
            }
            else
            {
                regenerateVoucherbutton.Enabled = false;
                voucherCodeTextBox.Text = "";
                _voucherCode = "";
            }
            
        }

        private void regenerateVoucherbutton_Click(object sender, EventArgs e)
        {
            _voucherCode = GenerateIDs.voucherCode();
            voucherCodeTextBox.Text = _voucherCode;            
        }

        private void validateControls(bool isEdit)
        {
            if (string.IsNullOrWhiteSpace(nametextBox.Text) && string.IsNullOrEmpty(nametextBox.Text))
            {
                errorProvider1.SetError(nametextBox, "Customer name must not be empty");
                return;
            }
            else errorProvider1.Clear();
            if (!string.IsNullOrEmpty(balTextBox.Text) && !string.IsNullOrWhiteSpace(balTextBox.Text))
            {
                try
                {
                    decimal bal = decimal.Parse(balTextBox.Text);
                    errorProvider1.Clear();
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(balTextBox, "Invalid balance.");
                    return;
                }
            }
            else balTextBox.Text = 0.0.ToString();

            processData(isEdit);
        }

        private async void processData(bool isEdit)
        {
            string name = nametextBox.Text;
            string phone = phoneMaskedTextBox.Text;
            bool isVoucher = voucherCodeCheckBox.Checked;
            string address = addresstextBox.Text;
            string other = othertextBox.Text;
            decimal bal = decimal.Parse(balTextBox.Text);

            if (isEdit)
            {
                customerModel.customerName = name;
                customerModel.phone = phone;
                customerModel.balance = bal;
                customerModel.isVoucherAvailable = isVoucher;
                customerModel.address = address;
                customerModel.voucherCode = _voucherCode;
                customerModel.other = other;

                if (!MessagePrompt.displayPrompt("Edit", "edit this Customer"))
                    return;

                MessageBox.Show(await DatabaseOperations.editCustomers(customerModel) ? "Data updated successfully" : "Data updating failed");

            }
            else
            {
                CustomerDataModel customers = new CustomerDataModel()
                {
                    customerName = name,
                    phone = phone,
                    isVoucherAvailable = isVoucher,
                    voucherCode = _voucherCode,
                    address = address,
                    other = other,
                    balance = bal
                };

                if (!MessagePrompt.displayPrompt("Create New", "create new customer"))
                    return;

                bool success = await DatabaseOperations.addCustomers(customers);
                if (success)
                {
                    MessageBox.Show("Customer Created successfully");

                    nametextBox.Clear();
                    balTextBox.Clear();
                    phoneMaskedTextBox.Clear();
                    addresstextBox.Clear();
                    othertextBox.Clear();
                    voucherCodeCheckBox.Checked = false;
                }
                
            }
            //if (voucherCodeCheckBox.Checked)
            //{
            //    _voucherCode = RandomIDGenerator.randomInt(Constants.VOUCHER_CODE_LENGTH);
            //    voucherCodeTextBox.Text = _voucherCode;
            //    regenerateVoucherbutton.Enabled = true;
            //}                


        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (!MessagePrompt.displayPrompt("Delete", "delete this customer"))
                return;

            MessageBox.Show(await DatabaseOperations.deleteCustomers(customerModel) ? "Data deleted successfully" : "Data deletion failed");
            Close();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            validateControls(true);
        }
    }
}
