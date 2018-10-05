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

namespace TheThrustGuru
{
    public partial class CustomersForm : Form
    {
        private List<CustomerDataModel> customers;
        public CustomersForm()
        {
            InitializeComponent();
            contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
        }

        private void manageItemButton_Click(object sender, EventArgs e)
        {
            new AddCustomers().ShowDialog();

            dataGridView1.Rows.Clear();
            loadDataFromDb();
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            if (item.Text.ToLower() == "edit")
            {
                if (dataGridView1.CurrentCell != null)
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                    if (customers != null && customers.Any())
                    {
                        var data = customers.ElementAt(index);
                        new AddCustomers(data).ShowDialog();

                        loadDataFromDb();
                    }
                }
            }
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            loadDataFromDb();
        }

        private void loadDataFromDb()
        {
            dataGridView1.Rows.Clear();
            customers = DatabaseOperations.getCustomers().ToList();
            if (customers != null && customers.Any())
            {
                new UpdateDataGridView().addCustomerToDataGridView(customers, dataGridView1);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            loadDataFromDb();
        }
    }
}
