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
    public partial class StoreLocationForm : Form
    {
        private IEnumerable<StoreLocationDataModel> stores;
        public StoreLocationForm()
        {
            InitializeComponent();
        }

        private void loadStores()
        {
            stores = DatabaseOperations.getStores();
            if (stores != null && stores.Any())
            {
                dataGridView1.Rows.Clear();
                new UpdateDataGridView().addStoresToDataGrid(stores, dataGridView1);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            processData(false);
        }

        private async void processData(bool isEdit)
        {
            if (string.IsNullOrWhiteSpace(storeNametextBox.Text) || string.IsNullOrEmpty(storeNametextBox.Text))
            {
                errorProvider1.SetError(storeNametextBox, "Please provide a valid name");
                return;
            }
            else
            {
                errorProvider1.Clear();
                string name = storeNametextBox.Text;
                bool isChecked = posCheckBox.Checked;

                if (isEdit)
                {
                    if(dataGridView1.CurrentCell != null)
                    {
                        var data = stores.ElementAt(dataGridView1.CurrentCell.RowIndex);
                        data.name = name;
                        data.show = isChecked;

                        if (!MessagePrompt.displayPrompt("Edit", "edit this location"))
                            return;

                        bool success = await DatabaseOperations.editStoreLocation(data);
                        if (!success)
                        {
                            MessageBox.Show("Data updating failed");
                            return;
                        }
                        MessageBox.Show("Data updated successfully");
                        loadStores();
                    }
                }
                else
                {
                    if (!MessagePrompt.displayPrompt("Create New", "create new location"))
                        return;

                    DatabaseOperations.addStoreLocation(new StoreLocationDataModel
                    {
                        name = name,
                        show = isChecked
                    });

                    MessageBox.Show("Data created successfully");

                    storeNametextBox.Clear();
                    storeNametextBox.Focus();

                    loadStores();
                }
                
                
                
            }
        }

        private void StoreLocationForm_Load(object sender, EventArgs e)
        {
            loadStores();
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentCell != null)
            {
                if (!MessagePrompt.displayPrompt("Delete", "delete this location"))
                    return;

                bool success = await DatabaseOperations.deleteStoreLocation(stores.ElementAt(dataGridView1.CurrentCell.RowIndex).id);
                if (!success)
                {
                    MessageBox.Show("Data deletion failed");
                    return;
                }
                MessageBox.Show("Data deleted successfully");
                loadStores();
                clear();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            processData(true);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentCell != null)
            {
                var data = stores.ElementAt(dataGridView1.CurrentCell.RowIndex);
                storeNametextBox.Text = data.name;
                posCheckBox.Checked = data.show;
                editButton.Enabled = true;
                deleteButton.Enabled = true;
                addButton.Enabled = false;
            }
        }

        private void clear()
        {
            editButton.Enabled = false;
            deleteButton.Enabled = false;
            storeNametextBox.Clear();
            posCheckBox.Checked = false;
            addButton.Enabled = true;
            storeNametextBox.Focus();

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
