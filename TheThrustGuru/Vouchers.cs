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
        public Vouchers()
        {
            InitializeComponent();
        }

        private void regenerateCodeButton_Click(object sender, EventArgs e)
        {
            voucherCode = RandomIDGenerator.randomInt(Constants.VOUCHER_CODE_LENGTH);
            voucherCodeTextBox.Text = voucherCode;
        }

        private void loadItemsIntoDataGrid()
        {
            var data = DatabaseOperations.getVouchers();
            if (data != null && data.Any())
            {
                List<VoucherDataGridModel> dgVouchersList = new List<VoucherDataGridModel>();
                foreach (var datum in data)
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

        private void processData()
        {
            if (string.IsNullOrWhiteSpace(selectCustomerComboBox.Text))
            {
                if(customers == null || !customers.Any())
                {
                    MessageBox.Show("You can't create this voucher because there is no customer without a voucher. \n" +
                        "To create a voucher you have to create a customer without voucher then add the customer here.");
                    return;
                }
                errorProvider1.SetError(selectCustomerComboBox, "Please select a valid customer");
                return;
            }
            else
            {
                errorProvider1.Clear();
                try
                {
                    string custId = customers.ElementAt(selectCustomerComboBox.SelectedIndex).id;
                    VoucherDataModel voucher = new VoucherDataModel()
                    {
                        code = voucherCode,
                        customerId = custId,
                        usedCount = 0
                    };

                    DatabaseOperations.addVoucher(voucher);                   

                    loadItems();
                    selectCustomerComboBox.Text = "";

                    dataGridView1.Rows.Clear();
                    loadItemsIntoDataGrid();            

                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            processData();
        }
    }
}
