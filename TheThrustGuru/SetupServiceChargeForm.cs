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
using TheThrustGuru.Logics;
using TheThrustGuru.Utils;

namespace TheThrustGuru
{
    public partial class SetupServiceChargeForm : Form
    {
        private IEnumerable<ServiceChargeDataModel> serviceCharges;
        public SetupServiceChargeForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            validateControls(false);
        }

        private void validateControls(bool isEdit)
        {
            decimal discount = 0, percent = 0; bool isPercent;
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) || string.IsNullOrEmpty(nameTextBox.Text))
            {
                errorProvider1.SetError(nameTextBox, "Please enter a valid name for service charge");
                return;
            }
            else errorProvider1.Clear();
            if (!serviceChargecheckBox.Checked)
            {
                if (!string.IsNullOrEmpty(discountTextBox.Text) && !string.IsNullOrWhiteSpace(discountTextBox.Text))
                {
                    try
                    {
                        decimal value = decimal.Parse(discountTextBox.Text);
                        discount = value; percent = 0; isPercent = false;
                        errorProvider1.Clear();
                    }
                    catch (Exception ex)
                    {
                        errorProvider1.SetError(discountTextBox, "Please enter a valid amount. Amount must be numeric");
                        return;
                    }
                }
                else
                {
                    errorProvider1.SetError(discountTextBox, "Please enter a valid amount. Amount must be numeric");
                    return;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(serviceChargetextBox.Text) && !string.IsNullOrWhiteSpace(serviceChargetextBox.Text))
                {
                    try
                    {
                        decimal value = decimal.Parse(serviceChargetextBox.Text);
                        percent = value; discount = 0; isPercent = true;
                        errorProvider1.Clear();
                    }
                    catch (Exception ex)
                    {
                        errorProvider1.SetError(serviceChargetextBox, "Please enter a valid value. Value must be numeric");
                        return;
                    }
                }
                else
                {
                    errorProvider1.SetError(serviceChargetextBox, "Please enter a valid value. Value must be numeric");
                    return;
                }
            }

            processData(discount, percent, isPercent, isEdit);
        }

        private async void processData(decimal discount, decimal percent, bool isPercent, bool isEdit)
        {
            string name = nameTextBox.Text;

            if (isEdit)
            {
                if(dataGridView.CurrentCell != null)
                {
                    if (!MessagePrompt.displayPrompt("Edit", "edit this service charge"))
                        return;

                    var data = serviceCharges.ElementAt(dataGridView.CurrentCell.RowIndex);
                    data.title = name;
                    data.discount = discount;
                    data.percent = percent;
                    data.isPercent = isPercent;

                    bool success = await DatabaseOperations.editServiceCharge(data);

                    if (!success)
                    {
                        MessageBox.Show("Data updating failed");
                        return;
                    }
                    MessageBox.Show("Data updated successfully");
                    loadData();
                }

            }
            else
            {
                if (!MessagePrompt.displayPrompt("Create New", "create new service Charge"))
                    return;

                DatabaseOperations.addServiceCharge(new ServiceChargeDataModel
                {
                    title = name,
                    discount = discount,
                    percent = percent,
                    isPercent = isPercent
                });

                MessageBox.Show("New Service Charge created successfully");

                nameTextBox.Clear();
                discountTextBox.Clear();
                serviceChargetextBox.Clear();
            }          

            loadData();
        }

        private void loadData()
        {
            serviceCharges = DatabaseOperations.getServiceCharge();
            if(serviceCharges != null && serviceCharges.Any())
            {
                dataGridView.Rows.Clear();
                new UpdateDataGridView().addServiceChargeToDataGridView(serviceCharges, dataGridView);
            }
        }

        private void SetupServiceChargeForm_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void serviceChargecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (serviceChargecheckBox.Checked)
            {
                serviceChargetextBox.Enabled = true;
                discountTextBox.Enabled = false;
            }
            else
            {
                serviceChargetextBox.Enabled = false;
                discountTextBox.Enabled = true;
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.CurrentCell != null)
            {
                var data = serviceCharges.ElementAt(dataGridView.CurrentCell.RowIndex);
                discountTextBox.Text = data.discount.ToString();
                nameTextBox.Text = data.title;
                if (data.isPercent)
                {
                    serviceChargecheckBox.Checked = true;
                    serviceChargetextBox.Text = data.percent.ToString();
                    discountTextBox.Enabled = false;
                }
                else
                {
                    discountTextBox.Text = data.discount.ToString();
                    discountTextBox.Enabled = true;
                    serviceChargecheckBox.Checked = false;
                }
                editButton.Enabled = true;
                deleteButton.Enabled = true;
                saveButton.Enabled = false;
            }
        }

        private void clear()
        {
            serviceChargecheckBox.Checked = false;
            editButton.Enabled = false;
            deleteButton.Enabled = false;
            saveButton.Enabled = true;
            discountTextBox.Clear();
            nameTextBox.Clear();
            serviceChargetextBox.Clear();
            nameTextBox.Focus();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            validateControls(true);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clear();
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null)
            {
                if (!MessagePrompt.displayPrompt("Delete", "delete this service charge"))
                    return;

                bool success = await DatabaseOperations.deleteSalesType(serviceCharges.ElementAt(dataGridView.CurrentCell.RowIndex).id);

                if (!success)
                {
                    MessageBox.Show("Data deletion failed");
                    return;
                }
                MessageBox.Show("Data deleted successfully");
                loadData();
                clear();
            }
        }
    }
}
