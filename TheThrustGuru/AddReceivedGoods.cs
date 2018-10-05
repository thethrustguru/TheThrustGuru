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
    public partial class AddReceivedGoods : Form
    {
        PurchaseOrderDataModel purchaseOrder;
        List<StockDataModel> selectedStocks = new List<StockDataModel>();
        List<int> selectedQuantity = new List<int>();
        List<StockDataModel> stocksOnPurchaseOrder = new List<StockDataModel>();
        List<int> quantityOnPurchaseOrder = new List<int>();
        UpdateDataGridView updateDataGrid = new UpdateDataGridView();
        private ReceivedNotesDataModel receivedNotes;
        public AddReceivedGoods()
        {
            InitializeComponent();
        }

        public AddReceivedGoods(ReceivedNotesDataModel receivedNotes)
        {
            InitializeComponent();

            populateEditData(receivedNotes);
        }

        private async void populateEditData(ReceivedNotesDataModel receivedNotes)
        {
            this.receivedNotes = receivedNotes;
            
            if (receivedNotes.goodsReceived != null)
            {
                foreach (var dt in receivedNotes.goodsReceived)
                {
                    selectedStocks.Add(await DatabaseOperations.getStockById(dt.stockId));
                    selectedQuantity.Add(dt.quantity);
                }
            }

            getEditData(receivedNotes.orderId);

            editButton.Enabled = true;
            deleteButton.Enabled = true;
            saveButton.Enabled = false;
            addAllButton.Enabled = false;
            
        }


        private void searchButton_Click(object sender, EventArgs e)
        {
            getData(orderIdTextBox.Text);
        }

        private async void getEditData(string _orderId)
        {
            progressBar1.Visible = true;
            string orderId = _orderId;

            if (!_orderId.Contains("PO-"))
                orderId = "PO-" + _orderId;

            purchaseOrder = await DatabaseOperations.getPurchaseOderByOrderId(orderId);
            if (purchaseOrder != null)
            {
                supplierNameTextBox.Text = purchaseOrder.supplierName;
                statusTextBox.Text = purchaseOrder.status;
                dateCreatedTextBox.Text = purchaseOrder.dateCreated.ToString();
                deliveryDateTextBox.Text = purchaseOrder.deliveryDate.ToString();
                grandTotalPriceTextBox.Text = FormatPrice.format(purchaseOrder.grandTotalPrice);
                grandTotalQuantityTextBox.Text = purchaseOrder.grandTotalQuantity.ToString();

                if (purchaseOrder.productsList != null && purchaseOrder.productsList.Any())
                {
                    var purchaseStocks = purchaseOrder.productsList;
                    var purchasedStockList = new List<string>();
                    var receivedStockList = new List<string>();
                    var purchaseQuantityList = new List<int>();
                    foreach(var ds in purchaseStocks)
                    {
                        purchasedStockList.Add(ds.stockId);
                        purchaseQuantityList.Add(ds.quantityToSupply);
                    }
                    
                    if (receivedNotes != null && receivedNotes.goodsReceived != null && receivedNotes.goodsReceived.Any())
                    {
                        var receivedStocks = receivedNotes.goodsReceived;
                        foreach(var dr in receivedStocks)
                        {
                            receivedStockList.Add(dr.stockId);
                        }

                        for(int i = 0; i < receivedStockList.Count(); i++)
                        {
                            if (purchasedStockList.Contains(receivedStockList.ElementAt(i)))
                            {
                                purchaseQuantityList.RemoveAt(purchasedStockList.IndexOf(receivedStockList.ElementAt(i)));
                                purchasedStockList.Remove(receivedStockList.ElementAt(i));                                
                            }                                
                        }
                    }

                    quantityOnPurchaseOrder.AddRange(purchaseQuantityList);
                    foreach (var stockId in purchasedStockList)
                    {
                        stocksOnPurchaseOrder.Add(await DatabaseOperations.getStockById(stockId));
                    }                  

                    updateDataGrid.addPurchaseToDataGrid(stocksOnPurchaseOrder, quantityOnPurchaseOrder, dataGridView1);
                    updateDataGrid.addSelectedNoteToDataGridView(selectedStocks, selectedQuantity, dataGridView2);
                }
            }
            else
            {
                MessageBox.Show("The order ref does not exist. You can check Purchases page for the correct purchase orderId");
            }
            progressBar1.Visible = false;
        }

        private async void getData(string _orderId)
        {
            progressBar1.Visible = true;
            string orderId = _orderId;

            if (!_orderId.Contains("PO-"))
                orderId = "PO-" + _orderId;

            purchaseOrder = await DatabaseOperations.getPurchaseOderByOrderId(orderId);
            if(purchaseOrder != null)
            {
                supplierNameTextBox.Text = purchaseOrder.supplierName;
                statusTextBox.Text = purchaseOrder.status;
                dateCreatedTextBox.Text = purchaseOrder.dateCreated.ToString();
                deliveryDateTextBox.Text = purchaseOrder.deliveryDate.ToString();
                grandTotalPriceTextBox.Text = FormatPrice.format(purchaseOrder.grandTotalPrice);
                grandTotalQuantityTextBox.Text = purchaseOrder.grandTotalQuantity.ToString();

                if(purchaseOrder.productsList != null && purchaseOrder.productsList.Any())
                {                    
                    foreach(var data in purchaseOrder.productsList)
                    {
                        quantityOnPurchaseOrder.Add(data.quantityToSupply);
                        stocksOnPurchaseOrder.Add(await DatabaseOperations.getStockById(data.stockId));
                    }

                    updateDataGrid.addPurchaseToDataGrid(stocksOnPurchaseOrder, quantityOnPurchaseOrder, dataGridView1);
                }

                saveButton.Enabled = true;
                addAllButton.Enabled = true;              
            }else
            {
                MessageBox.Show("The order ref does not exist. You can check Purchases page for the correct purchase orderId");
            }
            progressBar1.Visible = false;
        }

        private void addSelectedToDataGridView(int index)
        {
            //get data out
            var stock = stocksOnPurchaseOrder.ElementAt(index);
            int quantity = quantityOnPurchaseOrder.ElementAt(index);

            //add data to new list
            selectedStocks.Add(stock);
            selectedQuantity.Add(quantity); 

            //remove data from old list
            stocksOnPurchaseOrder.RemoveAt(index);
            quantityOnPurchaseOrder.RemoveAt(index);

            //update datagridview
            updateDataGrid.addSelectedNoteToDataGridView(stock, quantity, dataGridView2);

            dataGridView1.Rows.Clear();
            updateDataGrid.addPurchaseToDataGrid(stocksOnPurchaseOrder, quantityOnPurchaseOrder, dataGridView1);

        }

        private void edit(int index)
        {
            if(new PasscodeForm().ShowDialog() == DialogResult.OK)
            {
                EditForm eform = new EditForm();
                DialogResult result = eform.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedQuantity[index] = eform.quantity;
                    updateDataGrid.addSelectedNoteToDataGridView(selectedStocks, selectedQuantity, dataGridView2);
                }
            }                   
        }

        private void delete(int index)
        {
            //get data out
            var stock = selectedStocks.ElementAt(index);
            int quantity = selectedQuantity.ElementAt(index);

            //remove data from list
            selectedStocks.RemoveAt(index);
            selectedQuantity.RemoveAt(index);

            //add data to old list
            stocksOnPurchaseOrder.Add(stock);
            quantityOnPurchaseOrder.Add(quantity);

            //clear lists
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            //update 2 datagridviews
            updateDataGrid.addSelectedNoteToDataGridView(selectedStocks, selectedQuantity, dataGridView2);
            updateDataGrid.addPurchaseToDataGrid(stocksOnPurchaseOrder, quantityOnPurchaseOrder, dataGridView1);

        }

        private void validateControl(bool isEdit)
        {
            if(dataGridView1.Rows.Count <= 0 || selectedStocks.Count() <= 0)
            {
                MessageBox.Show("Please select goods to receive.");
                return;
            }
            processData(isEdit);
        }

        private async void processData(bool isEdit)
        {
            var goodsreceived = new List<ReceivedNotesDataModel.GoodsReceived>();
            for (int i = 0; i < selectedStocks.Count(); i++)
            {
                goodsreceived.Add(new ReceivedNotesDataModel.GoodsReceived
                {
                    stockId = selectedStocks.ElementAt(i).id,
                    quantity = selectedQuantity.ElementAt(i)
                });
            }


            if (isEdit)
            {
                if (!MessagePrompt.displayPrompt("Edit", "edit this note"))
                    return;
                receivedNotes.goodsReceived = goodsreceived;
                bool success = await DatabaseOperations.editReceivedNotes(receivedNotes);

                MessageBox.Show(success ? "Data deleted successfully" : "Data deletion failed");
            }
            else
            {               

                if (!MessagePrompt.displayPrompt("Add New", "add new Received Notes"))
                    return;

                await DatabaseOperations.addReceivedNotes(new ReceivedNotesDataModel
                {
                    purchaseId = purchaseOrder != null ? purchaseOrder.id : "",
                    grnId = grnIdTextBox.Text,
                    orderId = "PO-" + orderIdTextBox.Text,
                    amount = purchaseOrder != null ? purchaseOrder.grandTotalPrice : 0,
                    dateReceived = DateTime.Now,
                    goodsReceived = goodsreceived

                });

                MessageBox.Show("Data created successfully");

                addAllButton.Enabled = false;
                saveButton.Enabled = false;
                selectedQuantity.Clear();
                selectedStocks.Clear();
                stocksOnPurchaseOrder.Clear();
                quantityOnPurchaseOrder.Clear();
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                supplierNameTextBox.Clear();
                statusTextBox.Clear();
                dateCreatedTextBox.Clear();
                deliveryDateTextBox.Clear();
                grandTotalPriceTextBox.Clear();
                grandTotalQuantityTextBox.Clear();
                orderIdTextBox.Clear();
                orderIdTextBox.Focus();
                grnIdTextBox.Text = GenerateIDs.receivedNoteId();
            }
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex != -1)
                addSelectedToDataGridView(dataGridView1.CurrentCell.RowIndex);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView2.CurrentCell != null && dataGridView2.CurrentCell.RowIndex != -1)
            {
                int index = dataGridView2.CurrentCell.RowIndex;
                if(dataGridView2.CurrentCell == dataGridView2[5, index])
                {
                    edit(index);
                }else if(dataGridView2.CurrentCell == dataGridView2[6, index])
                {
                    delete(index);
                }
            }
        }

        private void addAllButton_Click(object sender, EventArgs e)
        {
            //add all item to new list
            selectedStocks.AddRange(stocksOnPurchaseOrder);
            selectedQuantity.AddRange(quantityOnPurchaseOrder);

            //clear old list
            stocksOnPurchaseOrder.Clear();
            quantityOnPurchaseOrder.Clear();

            //clear 1st datagrid 2nd is cleared in the medthod call to update.
            dataGridView1.Rows.Clear();
            updateDataGrid.addSelectedNoteToDataGridView(selectedStocks, selectedQuantity, dataGridView2);

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (selectedStocks.Any())
            {
                stocksOnPurchaseOrder.AddRange(selectedStocks);
                selectedStocks.Clear();
            }
            if (selectedQuantity.Any())
            {
                quantityOnPurchaseOrder.AddRange(selectedQuantity);
                selectedQuantity.Clear();
            }

            dataGridView1.Rows.Clear();
            updateDataGrid.addPurchaseToDataGrid(stocksOnPurchaseOrder, quantityOnPurchaseOrder, dataGridView1);
            dataGridView2.Rows.Clear();
        }

        private void AddReceivedGoods_Load(object sender, EventArgs e)
        {
            grnIdTextBox.Text = GenerateIDs.receivedNoteId();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            validateControl(false);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            validateControl(true);
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (!MessagePrompt.displayPrompt("Delete", "delete this data"))
                return;
            bool success = await DatabaseOperations.deleteReceivedNotes(receivedNotes.id);
            if (success)
            {
                MessageBox.Show("Received note deleted successfully");
                Close();
            }
            else MessageBox.Show("Data deletion failed");
        }
    }
}
