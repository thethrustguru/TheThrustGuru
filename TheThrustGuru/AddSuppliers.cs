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
    public partial class AddSuppliers : Form
    {
        private SupplierDataModel supplierModel;        

        public AddSuppliers()
        {
            InitializeComponent();            
        }

        public AddSuppliers(SupplierDataModel supplier)
        {
            InitializeComponent();                   

            nametextBox.Text = supplier.name;
            phoneMaskedTextBox.Text = supplier.phone;
            addresstextBox.Text = supplier.address;
            companytextBox.Text = supplier.company;
            emailTextBox.Text = supplier.email;
            othertextBox.Text = supplier.other;            

            editButton.Visible = true;
            deleteButton.Visible = true;
            addButton.Enabled = false;

            supplierModel = supplier;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            validateControls(false);
        }

        private void validateControls(bool isEdit)
        {
            if (string.IsNullOrWhiteSpace(nametextBox.Text))
            {
                errorProvider1.SetError(nametextBox, "Please enter a valid name");
                return;
            }
            else errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(phoneMaskedTextBox.Text) || string.IsNullOrEmpty(phoneMaskedTextBox.Text))
            {
                errorProvider1.SetError(phoneMaskedTextBox, "Please provide a valid contact phone");
                return;
            }
            else errorProvider1.Clear();

            processData(isEdit);
        }

        private async void processData(bool isEdit)
        {
            string name = nametextBox.Text;
            string phone = phoneMaskedTextBox.Text;            
            string address = addresstextBox.Text;
            string email = emailTextBox.Text;
            string company = companytextBox.Text;
            string other = othertextBox.Text;

            if (isEdit)
            {
                supplierModel.name = name;
                supplierModel.phone = phone;                
                supplierModel.address = address;
                supplierModel.company = company;
                supplierModel.email = email;
                supplierModel.other = other;

                if (!MessagePrompt.displayPrompt("Edit", "edit this supplier"))
                    return;

                MessageBox.Show(await DatabaseOperations.editSupplier(supplierModel) ? "Data updated successfully" : "Data updating failed");

            }else
            {
               
                DatabaseOperations.addSuppliers(new SupplierDataModel
                {
                    name = name,
                    phone = phone,                    
                    address = address,
                    company = company,
                    email = email,
                    other = other
                });

                if (!MessagePrompt.displayPrompt("Create New", "create a new supplier"))
                    return;

                MessageBox.Show("Supplier saved successfully");
                nametextBox.Clear();
                phoneMaskedTextBox.Clear();
                addresstextBox.Clear();
                emailTextBox.Clear();
                companytextBox.Clear();
                othertextBox.Clear();
            }                                 
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void AddSuppliers_Load(object sender, EventArgs e)
        {
            
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            validateControls(true);
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (!MessagePrompt.displayPrompt("Delete", "delete this supplier"))
                return;

            MessageBox.Show(await DatabaseOperations.deleteSupplier(supplierModel.id) ? "Data deleted successfully" : "Data deletion failed");
            Close();
        }
    }
}
