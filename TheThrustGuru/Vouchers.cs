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
    public partial class Vouchers : Form
    {
        private string voucherCode;
        private IEnumerable<CustomerDataModel> customers;
        private List<VoucherDataGridModel> dgVouchersList;
        private List<VoucherDataModel> vouchers;

        public Vouchers()
        {
            InitializeComponent();
            //contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
        }

        private void regenerateCodeButton_Click(object sender, EventArgs e)
        {
            voucherCode = RandomIDGenerator.randomInt(Constants.VOUCHER_CODE_LENGTH);
            voucherCodeTextBox.Text = voucherCode;
        }

        private void loadItemsIntoDataGrid()
        {
            vouchers = DatabaseOperations.getVouchers().ToList();
            if (vouchers != null && vouchers.Any())
            {
                dgVouchersList = new List<VoucherDataGridModel>();
                foreach (var datum in vouchers)
                {
                    dgVouchersList.Add(new VoucherDataGridModel
                    {
                        code = datum.code,
                        count = datum.usedCount.ToString(),
                        name = DatabaseOperations.getCustomerName(datum.id)
                    });

                }
                new UpdateDataGridView().addVouchers(dgVouchersList, dataGridView1);
            }
        }

        //private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{
        //    ToolStripItem item = e.ClickedItem;
        //    if (item.Text.ToLower() == "edit")
        //    {
        //        if (dataGridView1.CurrentCell != null)
        //        {
        //            int index = dataGridView1.CurrentCell.RowIndex;
        //            if (dgVouchersList != null && dgVouchersList.Any())
        //            {
        //                var data = dgVouchersList.ElementAt(index);
        //                voucherCodeTextBox.Text = data.code;
        //                selectCustomerComboBox.Text = data.name;
        //            }
        //        }
        //    }
        //}

        private void Vouchers_Load(object sender, EventArgs e)
        {
            loadItems();

            loadItemsIntoDataGrid();
        }

        private void loadItems()
        {
            voucherCode = RandomIDGenerator.randomInt(Constants.VOUCHER_CODE_LENGTH);
            voucherCodeTextBox.Text = voucherCode;

            customers = DatabaseOperations.getCustomers(false);
            if (customers != null && customers.Any())
            {
                selectCustomerComboBox.Items.Clear();
                foreach (var data in customers)
                {                    
                    selectCustomerComboBox.Items.Add(data.customerName);
                }

            }
        }

        private void validateControl(bool isEdit)
        {
            if (string.IsNullOrWhiteSpace(selectCustomerComboBox.Text))
            {
                if (customers == null || !customers.Any())
                {
                    MessageBox.Show("You can't create this voucher because there is no customer without a voucher. \n" +
                        "To create a voucher you have to create a customer without voucher then add the customer here.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                errorProvider1.SetError(selectCustomerComboBox, "Please select a valid customer");
                return;
            }
            if(!string.IsNullOrEmpty(usedCountTextBox.Text) && !string.IsNullOrWhiteSpace(usedCountTextBox.Text))
            {
                try
                {
                    int q = int.Parse(usedCountTextBox.Text);
                    errorProvider1.Clear();
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(usedCountTextBox, "Used Count not valid");
                    return;
                }
            }else
            {               
                usedCountTextBox.Text = 0.ToString();
            }

            errorProvider1.Clear();
            processData(isEdit);
        }

        private async void processData(bool isEdit)
        {
            string custId = customers.ElementAt(selectCustomerComboBox.SelectedIndex).id;

            if (isEdit)
            {
                if (dataGridView1.CurrentCell != null)
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                    var data = vouchers.ElementAt(index);
                    data.code = voucherCode;
                    data.customerId = custId;
                    data.usedCount = int.Parse(usedCountTextBox.Text);

                    if (!MessagePrompt.displayPrompt("Edit", "edit this voucher"))
                        return;
                    bool success = await DatabaseOperations.editVoucher(data);
                    if (success)
                    {
                        MessageBox.Show("Data updated successfully");
                        loadItems();
                        dataGridView1.Rows.Clear();
                        loadItemsIntoDataGrid();
                        selectCustomerComboBox.Text = dgVouchersList.ElementAt(index).name;
                    }
                }
            }
            else
            {
                VoucherDataModel voucher = new VoucherDataModel()
                {
                    code = voucherCode,
                    customerId = custId,
                    usedCount = int.Parse(usedCountTextBox.Text)
                };

                if (!MessagePrompt.displayPrompt("Create New", "create new voucher"))
                    return;

                DatabaseOperations.addVoucher(voucher);

                MessageBox.Show("Vouchers created successfully");

                loadItems();
                selectCustomerComboBox.Text = "";

                dataGridView1.Rows.Clear();
                loadItemsIntoDataGrid();
            }
            
            
        }   

        private void saveButton_Click(object sender, EventArgs e)
        {
            validateControl(false);
        }

        private void clear()
        {
            loadItems();
            selectCustomerComboBox.Text = "";
            saveButton.Enabled = true;
            deleteButton.Enabled = false;
            editButton.Enabled = false;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentCell != null)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                var data = dgVouchersList.ElementAt(index);
                voucherCodeTextBox.Text = data.code;
                selectCustomerComboBox.Text = data.name;
                saveButton.Enabled = false;
                editButton.Enabled = true;
                deleteButton.Enabled = true;
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            validateControl(true);
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentCell != null)
            {
                if (MessagePrompt.displayPrompt("Delete", "delete this voucher"))
                    return;

                bool success = await DatabaseOperations.deleteVoucher(vouchers.ElementAt(dataGridView1.CurrentCell.RowIndex).id);
                if (!success)
                {
                    MessageBox.Show("Data deletion failed");
                    return;
                }
                MessageBox.Show("Data deleted successfully");
                clear();
            }
        }
    }
}
