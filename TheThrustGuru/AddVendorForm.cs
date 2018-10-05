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
    public partial class AddVendorForm : Form
    {
        private VendorDataModel vendorModel;
        public AddVendorForm()
        {
            InitializeComponent();
        }

        public AddVendorForm(VendorDataModel vendor)
        {
            InitializeComponent();

            nametextBox.Text = vendor.name;
            phoneMaskedTextBox.Text = vendor.phone;
            addresstextBox.Text = vendor.address;
            othertextBox.Text = vendor.other;

            editButton.Visible = true;
            deleteButton.Visible = true;
            addButton.Enabled = false;

            vendorModel = vendor;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            processData(false);
        }

        private async void processData(bool isEdit)
        {
            if(string.IsNullOrWhiteSpace(nametextBox.Text) && string.IsNullOrEmpty(nametextBox.Text))
            {
                errorProvider1.SetError(nametextBox, "Please enter a valid name for vendor");
                return;
            }
            else
            {
                string name = nametextBox.Text;
                string phone = phoneMaskedTextBox.Text;
                string address = addresstextBox.Text;
                string other = othertextBox.Text;

                if (isEdit)
                {
                    vendorModel.name = name;
                    vendorModel.phone = phone;
                    vendorModel.address = address;
                    vendorModel.other = other;

                    if (!MessagePrompt.displayPrompt("Edit", "edit this vendor"))
                        return;


                    MessageBox.Show(await DatabaseOperations.editVendors(vendorModel) ? 
                        "Data updated successfully" : "Data updating failed");
                }else
                {
                    VendorDataModel vendor = new VendorDataModel
                    {
                        name = name,
                        phone = phone,
                        address = address,
                        other = other
                    };

                    if (!MessagePrompt.displayPrompt("Create", "create new vendor"))
                        return;

                    DatabaseOperations.addVendors(vendor);

                    MessageBox.Show("New Vendor created successfully");

                    nametextBox.Clear();
                    phoneMaskedTextBox.Clear();
                    addresstextBox.Clear();
                    othertextBox.Clear();
                }                
            }
        }

        private void AddVendorForm_Load(object sender, EventArgs e)
        {

        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (!MessagePrompt.displayPrompt("Delete", "delete this vendor"))
                return;

            MessageBox.Show(await DatabaseOperations.deleteVendor(vendorModel.id) ? 
                "Data deleted successfully" : "Data deletion failed");
            Close();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            processData(true);
        }
    }
}
