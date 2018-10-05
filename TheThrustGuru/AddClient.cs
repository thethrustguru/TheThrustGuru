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
    public partial class AddClient : Form
    {
        private string oldText = string.Empty;
        private ClientDataModel clientModel;

        public AddClient()
        {
            InitializeComponent();
            passwordTextBox.Text = GenerateIDs.password();
            loadCombos();
        }

        public AddClient(ClientDataModel client)
        {
            InitializeComponent();
            this.clientModel = client;
            loadCombos();
            nametextBox.Text = client.name;
            phoneMaskedTextBox.Text = client.phone;
            addresstextBox.Text = client.address;
            othertextBox.Text = client.other;
            usernameTextBox.Text = client.username;
            passwordTextBox.Text = client.password;
            rolesComboBox.Text = clientModel.role;
            storeLocationComboBox.Text = clientModel.storeLocation;
            
        }

        private void AddClient_Load(object sender, EventArgs e)
        {
            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadCombos()
        {
            string[] roles = Constants.ROLES;
            var data = DatabaseOperations.getStores();
            if(data != null && data.Any())
                storeLocationComboBox.Items.AddRange(data.ToArray());
            rolesComboBox.Items.AddRange(roles);
            
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
            if (string.IsNullOrEmpty(rolesComboBox.Text))
            {
                errorProvider1.SetError(rolesComboBox, "Please select a valid role for this client");
                return;
            }
            else errorProvider1.Clear();
            if (string.IsNullOrEmpty(storeLocationComboBox.Text))
            {
                errorProvider1.SetError(storeLocationComboBox, "Please select a valid store location for this client");
            }

            processData(isEdit);
        }

        private async void processData(bool isEdit)
        {
            errorProvider1.Clear();
            string name = nametextBox.Text;
            string phone = phoneMaskedTextBox.Text;            
            string address = addresstextBox.Text;
            string other = othertextBox.Text;
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string role = rolesComboBox.Text;
            string storelocation = storeLocationComboBox.Text;

            if (isEdit)
            {
                clientModel.name = name;
                clientModel.phone = phone;
                clientModel.address = address;
                clientModel.other = other;
                clientModel.username = username;
                clientModel.password = password;
                clientModel.role = role;
                clientModel.storeLocation = storelocation;

                if (!MessagePrompt.displayPrompt("Edit", "edit this client"))
                    return;

                MessageBox.Show(await DatabaseOperations.editClient(clientModel) ? "Client edited successfully" : "client editing failed");

            }
            else
            {
                if (!MessagePrompt.displayPrompt("Create New", "create new client"))
                    return;

                ClientDataModel clientModel = new ClientDataModel();
                clientModel.name = name;
                clientModel.phone = phone;
                clientModel.address = address;
                clientModel.other = other;
                clientModel.username = username;
                clientModel.password = password;
                clientModel.role = role;
                clientModel.storeLocation = storelocation;

                bool success = await DatabaseOperations.addClient(clientModel);

                if (success)
                {
                    MessageBox.Show("Client created successfully");
                    nametextBox.Clear();
                    phoneMaskedTextBox.Clear();
                    addresstextBox.Clear();
                    othertextBox.Clear();
                    usernameTextBox.Clear();


                    passwordTextBox.Text = GenerateIDs.password();
                }else
                {
                    MessageBox.Show("Client creation failed.");
                }
            }
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

        private void addButton_Click(object sender, EventArgs e)
        {
            validateControls(false);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            validateControls(true);
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (!MessagePrompt.displayPrompt("Delete", "delete this client"))
                return;
            MessageBox.Show(await DatabaseOperations.deleteSalesRep(clientModel.id) ? "Data deleted successfully" :
                "Data deletion failed");
            Close();
        }
    }
}
