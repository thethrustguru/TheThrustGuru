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
    public partial class AddSalesRepForm : Form
    {        
        private string oldText = string.Empty;
        private SalesRepDataModel salesRepModel;
        public AddSalesRepForm()
        {
            InitializeComponent();

            repIdTextBox.Text = GenerateIDs.salesRepId();
            passwordTextBox.Text = GenerateIDs.password();
        }

        public AddSalesRepForm(SalesRepDataModel salesRep)
        {
            InitializeComponent();

            nametextBox.Text = salesRep.name;
            phoneMaskedTextBox.Text = salesRep.phone;
            repIdTextBox.Text = salesRep.repId;
            addresstextBox.Text = salesRep.address;
            othertextBox.Text = salesRep.other;
            usernameTextBox.Text = salesRep.username;
            passwordTextBox.Text = salesRep.password;

            editButton.Visible = true;
            deleteButton.Visible = true;
            addButton.Enabled = false;

            salesRepModel = salesRep;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            validateControls(false);
        }

        private void validateControls(bool isEdit)
        {
            if (string.IsNullOrWhiteSpace(nametextBox.Text) || string.IsNullOrEmpty(nametextBox.Text))
            {
                errorProvider1.SetError(nametextBox, "Please enter a valid name");
                return;
            }
            else errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text) || string.IsNullOrEmpty(usernameTextBox.Text) ||
                usernameTextBox.Text.Length < 5)
            {
                errorProvider1.SetError(usernameTextBox, "Please enter a valid username. Username must be more than 4 characters");
                return;
            }
            else errorProvider1.Clear();

            processData(isEdit);
        }

        private async void processData(bool isEdit)
        {
            errorProvider1.Clear();
            string name = nametextBox.Text;
            string phone = phoneMaskedTextBox.Text;
            string repId = repIdTextBox.Text;
            string address = addresstextBox.Text;
            string other = othertextBox.Text;
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            if (isEdit)
            {
                salesRepModel.name = name;
                salesRepModel.phone = phone;
                salesRepModel.address = address;
                salesRepModel.other = other;
                salesRepModel.username = username;
                salesRepModel.password = password;
                salesRepModel.repId = repId;

                if (!MessagePrompt.displayPrompt("Edit", "edit this salesRep"))
                    return;

                MessageBox.Show(await DatabaseOperations.editSalesRep(salesRepModel) ? "Data updated successfully" : "Data updating failed");
            }else
            {
                SalesRepDataModel salesRep = new SalesRepDataModel
                {
                    name = name,
                    phone = phone,
                    repId = repId,
                    address = address,
                    other = other,
                    username = username,
                    password = password
                };

                if (!MessagePrompt.displayPrompt("Create New", "create new salesRep"))
                    return;

                DatabaseOperations.addSalesRep(salesRep);

                MessageBox.Show("Sales Rep created successfully");

                nametextBox.Clear();
                phoneMaskedTextBox.Clear();
                addresstextBox.Clear();
                othertextBox.Clear();
                usernameTextBox.Clear();

                repIdTextBox.Text = GenerateIDs.salesRepId();
                passwordTextBox.Text = GenerateIDs.password();
            }

           
        }

        private void AddSalesRepForm_Load(object sender, EventArgs e)
        {
            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nametextBox_TextChanged(object sender, EventArgs e)
        {
            if (nametextBox.Text.All(chr => char.IsLetter(chr) || char.IsWhiteSpace(chr) || char.IsPunctuation(chr)))
            {
                oldText = nametextBox.Text;
                nametextBox.Text = oldText;                
            }
            else
            {
                nametextBox.Text = oldText;                
            }
            nametextBox.SelectionStart = nametextBox.Text.Length;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            validateControls(true);
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (!MessagePrompt.displayPrompt("Delete", "delete this salesRep"))
                return;
            MessageBox.Show(await DatabaseOperations.deleteSalesRep(salesRepModel.id) ? "Data deleted successfully" : 
                "Data deletion failed");
            Close();
        }
    }
}
