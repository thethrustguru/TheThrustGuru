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
    public partial class AddPurchasesForm : Form
    {
        
        private int mQuantityRemaining;
        private decimal mProductPrice;
        private decimal grandTotalPrice = 0;
        private int grandTotalQuantity = 0;        
        private IEnumerable<SupplierDataModel> supplierData;
        private List<ClientDataModel> clientModel;
        private IEnumerable<SalesRepDataModel> salesRep;
        private IEnumerable<StockDataModel> stocks;
        private List<PurchaseOrderDataModel.PurchasedStock> purchasedStocks = new List<PurchaseOrderDataModel.PurchasedStock>();
        private PurchaseOrderDataModel purchases;

        public AddPurchasesForm()
        {
            InitializeComponent();
            init();
            this.orderRefTextBox.Text = GenerateIDs.purchaseOrderId();
        }

        public AddPurchasesForm(PurchaseOrderDataModel purchase)
        {
            InitializeComponent();

            init();
            supplierNameComboBox.Text = purchase.supplierName;
            statusComboBox.Text = purchase.status;
            dateCreatedDateTimePicker.Value = purchase.dateCreated;
            expectedDateofDeliveryDateTimePicker.Value = purchase.deliveryDate;
            orderRefTextBox.Text = purchase.orderNo;
            
            grandTotalPricetextBox.Text = FormatPrice.format(purchase.grandTotalPrice);
            grandTotalQuantitytextBox.Text = purchase.grandTotalQuantity.ToString();
            grandTotalQuantity = purchase.grandTotalQuantity;
            grandTotalPrice = purchase.grandTotalPrice;
            

            addProductToDatagridView(purchase.productsList);
            saveButton.Enabled = false;
            deleteButton.Enabled = true;
            editbutton.Enabled = true;

            purchasedStocks = purchase.productsList;
            this.purchases = purchase;
        }

        private void AddPurchasesForm_Load(object sender, EventArgs e)
        {
            
            
        }       

        private async void init()
        {
            supplierData = DatabaseOperations.getSuppliers();
            if (supplierData != null && supplierData.Any())
            {
                foreach (var datum in supplierData)
                {
                    this.supplierNameComboBox.Items.Add(datum.name);
                }
            }

            clientModel = await DatabaseOperations.getClients();
            if(clientModel != null && clientModel.Any())
            {
                foreach(var data in clientModel)
                {
                    clientComboBox.Items.Add(data.name);
                }
            }

            stocks = DatabaseOperations.getStocks();
            if (stocks != null && stocks.Any())
            {
                foreach (var data in stocks)
                {
                    stockscomboBox.Items.Add(data.name);
                }
            }


            
        }

        private string getTotalQuantity(string text)
        {
            try
            {
                int quantity = int.Parse(text);
                return (grandTotalQuantity + quantity).ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        private decimal getTotalPrice(string text)
        {
            try
            {
                int quantity = int.Parse(text);
                return (quantity * mProductPrice);
            }
            catch (Exception ex)
            {
                return mProductPrice;
            }
        }

        private void validateControl()
        {
            if (string.IsNullOrWhiteSpace(stockscomboBox.Text))
            {
                errorProvider1.SetError(this.stockscomboBox, "Please select a valid product");
                return;
            }
            else errorProvider1.Clear();
            if (!string.IsNullOrWhiteSpace(quantityToSupplytextBox.Text))
            {
                try
                {
                    int q = int.Parse(quantityToSupplytextBox.Text);
                    errorProvider1.Clear();
                }catch(Exception ex)
                {
                    errorProvider1.SetError(quantityToSupplytextBox, "Please enter a valid quantity to supply. Quantity must be numeric");
                    return;
                }
            }else
            {
                errorProvider1.SetError(quantityToSupplytextBox, "Please enter a valid quantity to supply. Quantity must be numeric");
                return;
            }

            addproductToDatagridView();
        }

        private void validateAllControls(bool isEdit)
        {
            if (string.IsNullOrWhiteSpace(supplierNameComboBox.Text))
            {
                errorProvider1.SetError(supplierNameComboBox, "Please select a valid supplier");
                return;
            }
            else errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(statusComboBox.Text))
            {
                errorProvider1.SetError(statusComboBox, "Please select a valid status");
                return;
            }
            else errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(clientComboBox.Text))
            {
                errorProvider1.SetError(clientComboBox, "Please select a valid client");
                return;
            }
            else errorProvider1.Clear();
            if (dataGridView1.RowCount == 0)
            {
                errorProvider1.SetError(dataGridView1, "Please add items to supply");
                return;
            }
            else errorProvider1.Clear();

            processData(isEdit);
        }

        private SupplierDataModel getSupplier()
        {
            if(supplierData != null && supplierData.Any() && supplierNameComboBox.SelectedIndex != -1)
            {
                var data = supplierData.ElementAt(supplierNameComboBox.SelectedIndex);
                return data;
            }return null;
        }
        private ClientDataModel getClient()
        {
            if(clientModel != null && clientModel.Any() && clientComboBox.SelectedIndex != -1)
            {
                var data = clientModel.ElementAt(clientComboBox.SelectedIndex);
                return data;
            }return null;
        }

        private async void processData(bool isEdit)
        {
            string supplierName = getSupplier().name;
            string status = statusComboBox.Text;
            DateTime dateCreated = dateCreatedDateTimePicker.Value;
            DateTime deliveryDate = expectedDateofDeliveryDateTimePicker.Value;
            string order = orderRefTextBox.Text;
            string clientId = getClient().id;
            string supplierId = getSupplier().id;            
            string staffName = clientComboBox.Text;           

            if (isEdit)
            {
                if (!MessagePrompt.displayPrompt("Edit", "edit this purchase order"))
                    return;
                               
                purchases.productsList = purchasedStocks;
                purchases.supplierName = supplierName;
                purchases.supplierId = supplierId;
                purchases.status = status;
                purchases.dateCreated = dateCreated;
                purchases.deliveryDate = deliveryDate;
                purchases.orderNo = order;
                purchases.staffName = staffName;
                purchases.staffId = clientId;                
                purchases.grandTotalPrice = grandTotalPrice;
                purchases.grandTotalQuantity = grandTotalQuantity;


                MessageBox.Show(await DatabaseOperations.editpurchases(this.purchases) ? "Data updated successfully" :
                    "Data updating failed");

                if (MessagePrompt.printPrompt("purchase order"))
                    print(purchases);                
            }
            else
            {
                if (!MessagePrompt.displayPrompt("Create New", "Create new purchase order"))
                    return;

                var purchaseOrder = new PurchaseOrderDataModel();

                purchaseOrder.supplierName = supplierName;
                purchaseOrder.staffName = staffName;
                purchaseOrder.status = status;
                purchaseOrder.dateCreated = dateCreated;
                purchaseOrder.deliveryDate = deliveryDate;
                purchaseOrder.orderNo = order;
                purchaseOrder.staffId = clientId;
                purchaseOrder.supplierId = supplierId;
                purchaseOrder.grandTotalPrice = grandTotalPrice;
                purchaseOrder.grandTotalQuantity = grandTotalQuantity;
                purchaseOrder.productsList = purchasedStocks;

                DatabaseOperations.addPurchases(purchaseOrder);               

                MessageBox.Show("Purchase saved successfull");

                if (MessagePrompt.printPrompt("purchase order"))
                    print(purchaseOrder);

                this.orderRefTextBox.Text = GenerateIDs.purchaseOrderId();
                this.dataGridView1.Rows.Clear();
                grandTotalPrice = 0;
                grandTotalQuantity = 0;
                totalPriceTextBox.Text = FormatPrice.format(getTotalPrice(quantityToSupplytextBox.Text));
                grandTotalQuantitytextBox.Text = getTotalQuantity(quantityToSupplytextBox.Text);
                grandTotalPricetextBox.Text = FormatPrice.format(getTotalPrice(quantityToSupplytextBox.Text));
            }         


        }

        private async void print(PurchaseOrderDataModel order)
        {
            var supplier = getSupplier();
            var client = getClient();
            var stocks = await getStocks(purchasedStocks);
            Reports rv = new Reports(order,stocks,supplier,client);
            rv.Show();
            //new Reports().Show();
        }

        private async Task<List<StockDataModel>> getStocks(List<PurchaseOrderDataModel.PurchasedStock> stockList)
        {
            var stocks = new List<StockDataModel>();            
            foreach (var data in stockList)
            {               
                stocks.Add(await DatabaseOperations.getStockById(data.stockId));
            }
            return stocks;
        }

        private async void addProductToDatagridView(List<PurchaseOrderDataModel.PurchasedStock> stockList)
        {
            var stocks = new List<StockDataModel>();
            var quantity = new List<int>();
            foreach(var data in stockList)
            {
                quantity.Add(data.quantityToSupply);
                stocks.Add(await DatabaseOperations.getStockById(data.stockId));
            }
            new UpdateDataGridView().addProductsToDataGridView(stocks, quantity, dataGridView1);
        }
        private void addproductToDatagridView()
        {
            //string productName = stockscomboBox.Text;            
            int quantityToSupply = int.Parse(quantityToSupplytextBox.Text);
            var stock = stocks.ElementAt(stockscomboBox.SelectedIndex);

            
            new UpdateDataGridView().addProductsToDataGridView(stock,quantityToSupply, this.dataGridView1);
            purchasedStocks.Add(new PurchaseOrderDataModel.PurchasedStock
            {
                stockId = stock.id,
                quantityToSupply = quantityToSupply
            });


            grandTotalPrice += getTotalPrice(quantityToSupplytextBox.Text);
            grandTotalQuantity += quantityToSupply;

            grandTotalPricetextBox.Text = FormatPrice.format(grandTotalPrice + getTotalPrice(quantityToSupplytextBox.Text));
            grandTotalQuantitytextBox.Text = getTotalQuantity(quantityToSupplytextBox.Text);
            totalPriceTextBox.Text = FormatPrice.format(getTotalPrice(quantityToSupplytextBox.Text));
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            validateControl();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            grandTotalPrice = 0;
            grandTotalQuantity = 0;
            grandTotalQuantitytextBox.Text = getTotalQuantity(quantityToSupplytextBox.Text);
            totalPriceTextBox.Text = FormatPrice.format(getTotalPrice(quantityToSupplytextBox.Text));
            grandTotalPricetextBox.Text = FormatPrice.format(getTotalPrice(quantityToSupplytextBox.Text));
        }

        private void quantityToSupplytextBox_TextChanged(object sender, EventArgs e)
        {
            grandTotalQuantitytextBox.Text = getTotalQuantity(quantityToSupplytextBox.Text);
            totalPriceTextBox.Text = FormatPrice.format(getTotalPrice(quantityToSupplytextBox.Text));
            grandTotalPricetextBox.Text = FormatPrice.format(grandTotalPrice + getTotalPrice(quantityToSupplytextBox.Text));
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            validateAllControls(false);
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
       
        private void stockscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.stockscomboBox.SelectedIndex;
            var data = stocks.ElementAt(index);
            lastCostPriceTextBox.Text = FormatPrice.format(data.lastCostPrice);
            highestCostPriceTextBox.Text = FormatPrice.format(data.highestCostPrice);
            lowestCostPriceTextBox.Text = FormatPrice.format(data.lowestCostPrice);
            this.quantityRemainingtextBox.Text = data.quantity.ToString();
            mQuantityRemaining = data.quantity;
            mProductPrice = data.lastCostPrice;

            grandTotalPricetextBox.Text = FormatPrice.format(grandTotalPrice + getTotalPrice(quantityToSupplytextBox.Text));
            grandTotalQuantitytextBox.Text = getTotalQuantity(quantityToSupplytextBox.Text);
            totalPriceTextBox.Text = FormatPrice.format(getTotalPrice(quantityToSupplytextBox.Text));
        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            validateAllControls(true);
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (!MessagePrompt.displayPrompt("Delete", "delete this purchase order"))
                    return;
            bool success = await DatabaseOperations.deletePurchase(purchases.id);
            if (!success)
            {
                MessageBox.Show("Data deletion failed");
                return;
            }

            MessageBox.Show("Data deleted successfully");
            Close();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            //ReportViewer rv = new ReportViewer();           
            var supplier = getSupplier();
            var client = getClient();

        }
    }
}
