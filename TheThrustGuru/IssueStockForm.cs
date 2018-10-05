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
    public partial class IssueStockForm : Form
    {
        List<StoreLocationDataModel> stores;
        List<StockDataModel> availableStocks;
        List<StockTransferRecordDataModel.StockItems> transferStockItems = new List<StockTransferRecordDataModel.StockItems>();
        
        public IssueStockForm()
        {
            InitializeComponent();
        }

        private void IssueStockForm_Load(object sender, EventArgs e)
        {
            transferIdTextBox.Text = GenerateIDs.transferId();
            loadStoreFromDB();
            loadAvailableStocks();
        }

        private void loadStoreFromDB()
        {
            stores = DatabaseOperations.getStores().ToList();
            foreach(var items in stores)
            {
                storeFromComboBox.Items.Add(items.name);
                storeToComboBox.Items.Add(items.name);
            }
        }

        private async void loadAvailableStocks()
        {
            availableStocks = await DatabaseOperations.getAvailableStocks();
            if(availableStocks != null && availableStocks.Any())
            {
                foreach(var data in availableStocks)
                {
                    stocksComboBox.Items.Add(data.name);
                }
            }
        }

        private void validateControl()
        {
            if(!string.IsNullOrWhiteSpace(quantityTextBox.Text) && !string.IsNullOrEmpty(quantityTextBox.Text))
            {
                try
                {
                    int qty = int.Parse(quantityTextBox.Text);
                    var stock = availableStocks.ElementAt(stocksComboBox.SelectedIndex);
                    if(qty > stock.quantity)
                    {
                        MessageBox.Show("Selected stock is not up to the quantity entered. Remaining quantity of selected stock is " +
                            stock.quantity, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    errorProvider1.Clear();
                }catch(Exception ex)
                {
                    errorProvider1.SetError(quantityTextBox, "Quantity not valid");
                    return;
                }
            }else
            {
                errorProvider1.SetError(quantityTextBox, "Quantity not valid");
                return;
            }

            if (string.IsNullOrEmpty(stocksComboBox.Text))
            {
                errorProvider1.SetError(stocksComboBox, "Please select a valid item");
                return;
            }
            else errorProvider1.Clear();
            

            addToDataGrid();
        }

        private void addToDataGrid()
        {
            int index = stocksComboBox.SelectedIndex;
            if(index < availableStocks.Count())
            {
                var data = availableStocks.ElementAt(index);               
                int qty = int.Parse(quantityTextBox.Text);

                new UpdateDataGridView().addIssuedStockToDataGridView(data,qty,dataGridView1);

                transferStockItems.Add(new StockTransferRecordDataModel.StockItems
                {
                    stockId = data.id,
                    quantity = qty
                });
            }
        }

        private async void SaveData()
        {
            if (string.IsNullOrEmpty(storeFromComboBox.Text))
            {
                errorProvider1.SetError(storeFromComboBox, "Please select a valid store from");
                return;
            }
            else errorProvider1.Clear();

            if (string.IsNullOrEmpty(storeToComboBox.Text))
            {
                errorProvider1.SetError(storeToComboBox, "Please select a valid store to");
                return;
            }
            else errorProvider1.Clear();

            if (dataGridView1.RowCount > 0)
                errorProvider1.Clear();
            else
            {
                MessageBox.Show("No valid stock selected","Error issueing stock",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            var toStore = stores.ElementAt(storeToComboBox.SelectedIndex);
            var fromStore = stores.ElementAt(storeFromComboBox.SelectedIndex);

            await DatabaseOperations.addTransferRecord(new StockTransferRecordDataModel
            {
                transferId = transferIdTextBox.Text,
                toStoreId = toStore.id,
                toStoreName = toStore.name,
                fromStoreId = fromStore.id,
                fromStoreName = fromStore.name,
                dateCreated = DateTime.Now,
                stockItems = transferStockItems
            });

            dataGridView1.Rows.Clear();
            transferStockItems.Clear();
            quantityTextBox.Clear();

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            transferStockItems.Clear();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            validateControl();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
