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
    public partial class SetupSalesTypeForm : Form
    {

        private IEnumerable<ServiceChargeDataModel> salesType;
        public SetupSalesTypeForm()
        {
            InitializeComponent();
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

        private void SetupSalesTypeForm_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            salesType = DatabaseOperations.getSalesType();
            if (salesType != null && salesType.Any())
            {
                dataGridView1.Rows.Clear();
                new UpdateDataGridView().addServiceChargeToDataGridView(salesType, dataGridView1);
            }
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
                if(!string.IsNullOrEmpty(discountTextBox.Text) && !string.IsNullOrWhiteSpace(discountTextBox.Text))
                {
                    try
                    {
                        decimal value = decimal.Parse(discountTextBox.Text);
                        discount = value; percent = 0; isPercent = false;
                        errorProvider1.Clear();
                    }catch(Exception ex)
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
                        percent = value; discount = 0;isPercent = true;
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

            processData(discount, percent,isPercent,isEdit);
        }

        private async void processData(decimal discount,decimal percent,bool isPercent, bool isEdit)
        {
            string name = nameTextBox.Text;

            if (isEdit)
            {               
                if(dataGridView1.CurrentCell != null)
                {
                    if (!MessagePrompt.displayPrompt("Edit", "edit this sales type"))
                        return;

                    var data = salesType.ElementAt(dataGridView1.CurrentCell.RowIndex);
                    data.title = name;
                    data.discount = discount;
                    data.percent = percent;
                    data.isPercent = isPercent;


                    bool success = await DatabaseOperations.editSalesType(data);

                    if (!success)
                    {
                        MessageBox.Show("Data updating failed");
                        return;
                    }
                    MessageBox.Show("Data updated successfully");
                    loadData();
                }
                

            }else
            {
                if (!MessagePrompt.displayPrompt("Create New", "create new sales type"))
                    return;

                DatabaseOperations.addSalesType(new ServiceChargeDataModel
                {
                    title = name,
                    discount = discount,
                    percent = percent,
                    isPercent = isPercent
                });

                MessageBox.Show("New sales type created successfully");

                nameTextBox.Clear();
                discountTextBox.Clear();
                serviceChargetextBox.Clear();
            }           

            loadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if(dataGridView1.CurrentCell != null)
            {
                var data = salesType.ElementAt(dataGridView1.CurrentCell.RowIndex);
                discountTextBox.Text = data.discount.ToString();
                nameTextBox.Text = data.title;
                if (data.isPercent)
                {
                    serviceChargecheckBox.Checked = true;
                    serviceChargetextBox.Text = data.percent.ToString();
                    discountTextBox.Enabled = false;
                }else
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

        private void editButton_Click(object sender, EventArgs e)
        {
            validateControls(true);
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

        private void clearButton_Click(object sender, EventArgs e)
        {
            clear();
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentCell != null)
            {
                if (!MessagePrompt.displayPrompt("Delete", "delete this sales type"))
                    return;

                bool success = await DatabaseOperations.deleteSalesType(salesType.ElementAt(dataGridView1.CurrentCell.RowIndex).id);

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
