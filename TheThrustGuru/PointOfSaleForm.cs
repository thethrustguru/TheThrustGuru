using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
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
    public partial class PointOfSaleForm : Form
    {
        private string searchByName = "Search by name...";
        private string searchByCategory = "Search by category...";
        private string selectSalesType = "Select sales type";
        private string selectServiceCharge = "Select service charge";
        private string selectSalesRep = "Select sales rep.";        

        private IEnumerable<ServiceChargeDataModel> serviceChargeData;
        private IEnumerable<ServiceChargeDataModel> salesTypeData;
        private IEnumerable<SalesRepDataModel> salesRepData;
        private IEnumerable<StockDataModel> stocksData;
        private IEnumerable<CategoryDataModel> categoryData;
        private List<CustomerDataModel> customers;
        private List<StockDataModel> selectedStocks = new List<StockDataModel>();
        private List<RecipesDataModel> selectedRecipes = new List<RecipesDataModel>();
        private string storeLocation = "";  

        private decimal totalPrice;
        private decimal amountPayable;
        private int totalQuantity;
        private decimal discount;
        private decimal _serviceCharge;        

        public PointOfSaleForm(string store)
        {
            InitializeComponent();
            storeLocation = store;
        }

        private void PointOfSaleForm_Load(object sender, EventArgs e)
        {
            this.dateLabel.Text = DateTime.Now.ToLongDateString();
            waterMarkOnTextBoxLeave(searchNametextBox,searchByName);                      

            if(!SelectSellercomboBox.Items.Contains(selectSalesRep))
            {
                SelectSellercomboBox.Items.Add(selectSalesRep);
            }
            SelectSellercomboBox.Text = selectSalesRep;

            if (!searchCategorycomboBox.Items.Contains(searchByCategory))
                searchCategorycomboBox.Items.Add(searchByCategory);
            searchCategorycomboBox.Text = searchByCategory;

            if (!salesTypeComboBox.Items.Contains(selectSalesType))
                salesTypeComboBox.Items.Add(selectSalesType);
            salesTypeComboBox.Text = selectSalesType;


            if (!serviceChargeComboBox.Items.Contains(selectServiceCharge))
                serviceChargeComboBox.Items.Add(selectServiceCharge);
            serviceChargeComboBox.Text = selectServiceCharge;


            loadSellers();
            loadServiceCharge();
            loadCategories();
            loadSalesType();
            loadCustomers();
            InvoicetextBox.Text = GenerateIDs.invoiceId();
        }

        private void loadServiceCharge()
        {
            serviceChargeComboBox.Items.Clear();
            serviceChargeData = DatabaseOperations.getServiceCharge();
            if(serviceChargeData != null && serviceChargeData.Any())
            {
                foreach(var data in serviceChargeData)
                {
                    serviceChargeComboBox.Items.Add(data.title);
                }
            }
        }

        private void loadCategories()
        {            
            categoryData = DatabaseOperations.getCategory();
            if(categoryData != null && categoryData.Any())
            {
                foreach(var data in categoryData)
                {
                    searchCategorycomboBox.Items.Add(data.name);
                }
            }
        }

        private void loadSalesType()
        {
            salesTypeData = DatabaseOperations.getSalesType();
            if(salesTypeData != null && salesTypeData.Any())
            {
                foreach(var data in salesTypeData)
                {
                    salesTypeComboBox.Items.Add(data.title);
                }
            }

        }

        private void loadSellers()
        {
            salesRepData = DatabaseOperations.getSalesReps();
            if(salesRepData != null && salesRepData.Any())
            {
                foreach(var data in salesRepData)
                {
                    SelectSellercomboBox.Items.Add(data.name);
                }
            }
        }

        private void loadCustomers()
        {
            customerComboBox.Items.Clear();
            customers = DatabaseOperations.getCustomers().ToList();
            if(customers != null && customers.Any())
            {
                foreach(var dt in customers)
                {
                    customerComboBox.Items.Add(dt.customerName);
                }
            }
        }

        private async void loadStocksById(string id)
        {
            progressBar1.Visible = true;
            dataGridView1.Rows.Clear();
            if (storeLocation.ToLower() == "admin")
                stocksData = await DatabaseOperations.getStocksByCategoryId(id);
            else 
                stocksData = await DatabaseOperations.getStocksByCategoryAndStore(id,storeLocation);

            if(stocksData != null && stocksData.Any())
            {
                var categoryName = new List<string>();
                var storeName = new List<string>();
                foreach(var data in stocksData)
                {
                    var store = await DatabaseOperations.getStoreById(data.storeId);
                    storeName.Add(store.name);
                    foreach(var datum in categoryData)
                    {
                        if(datum.id == data.categoryId)
                        {
                            categoryName.Add(datum.name);
                            break;
                        }

                    }
                }
                new UpdateDataGridView().addStocksToPOSDataGridView(stocksData, categoryName, storeName, dataGridView1);
            }
            progressBar1.Visible = false;

        }       

        private void waterMarkOnTextBoxLeave(TextBox textbox, string placeHolder)
        {
            if (String.IsNullOrEmpty(textbox.Text) || textbox.Text == placeHolder)
            {
                textbox.ForeColor = Color.Gray;
                textbox.Text = placeHolder;
            }
            else
            {
                textbox.ForeColor = Color.Black;
            }
        }

        private void waterMarkOnTextBoxEnter(TextBox textbox)
        {
            textbox.Text = String.Empty;
            textbox.ForeColor = Color.Black;
        }

        private void serachNametextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(searchNametextBox, searchByName);
        }

        private void searchNametextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(searchNametextBox);
        }

        private void SelectSellercomboBox_DropDown(object sender, EventArgs e)
        {
            if (SelectSellercomboBox.Items.Contains(selectSalesRep))
                SelectSellercomboBox.Items.Remove(selectSalesRep);
        }

        private void searchCategorycomboBox_DropDown(object sender, EventArgs e)
        {
            if (searchCategorycomboBox.Items.Contains(searchByCategory))
                searchCategorycomboBox.Items.Remove(searchByCategory);
        }

        private void searchCategorycomboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (searchCategorycomboBox.SelectedIndex == -1)
            {
                if (!searchCategorycomboBox.Items.Contains(searchByCategory))
                    searchCategorycomboBox.Items.Add(searchByCategory);
                searchCategorycomboBox.Text = searchByCategory;
            }
        }

        private void SelectSellercomboBox_DropDownClosed(object sender, EventArgs e)
        {
            if(SelectSellercomboBox.SelectedIndex == -1)
            {
                if (!SelectSellercomboBox.Items.Contains(selectSalesRep))
                    SelectSellercomboBox.Items.Add(selectSalesRep);
                SelectSellercomboBox.Text = selectSalesRep;
            }
                
        }

        private void salesTypeComboBox_DropDown(object sender, EventArgs e)
        {
            if (salesTypeComboBox.Items.Contains(selectSalesType))
                salesTypeComboBox.Items.Remove(selectSalesType);
        }

        private void salesTypeComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if(salesTypeComboBox.SelectedIndex == -1)
            {
                if (!salesTypeComboBox.Items.Contains(selectSalesType))
                    salesTypeComboBox.Items.Add(selectSalesType);
                salesTypeComboBox.Text = selectSalesType;
            }
        }

        private void serviceChargecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (serviceChargecheckBox.Checked)
            {
                serviceChargeComboBox.Enabled = true;
                if (!serviceChargeComboBox.Items.Contains(selectServiceCharge))
                    serviceChargeComboBox.Items.Add(selectServiceCharge);
                serviceChargeComboBox.Text = selectServiceCharge;
            }                
            else serviceChargeComboBox.Enabled = false;

            calcAmtPayable(this.totalPrice);
        }

        private void serviceChargeComboBox_DropDown(object sender, EventArgs e)
        {
            if (serviceChargeComboBox.Items.Contains(selectServiceCharge))
                serviceChargeComboBox.Items.Remove(selectServiceCharge);
        }

        private void serviceChargeComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if(serviceChargeComboBox.SelectedIndex == -1)
            {
                if (!serviceChargeComboBox.Items.Contains(selectServiceCharge))
                    serviceChargeComboBox.Items.Add(selectServiceCharge);
                serviceChargeComboBox.Text = selectServiceCharge;
            }
        }

        private void searchCategorycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = searchCategorycomboBox.SelectedIndex;
            string value = searchCategorycomboBox.Text;            
           if(index != -1 && value != searchByCategory && value.ToLower() != "recipes")
            {              
                var data = categoryData.ElementAt(index);
                loadStocksById(data.id);
            }
        }       

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView2.CurrentCell != null)
            {
                int index = dataGridView2.CurrentCell.RowIndex;
                if (dataGridView2.CurrentCell == dataGridView2[6, index])
                {                   
                    var stock = selectedStocks.ElementAt(index);

                    totalQuantity -= 1;
                    totalQuantitytextbox.Text = totalQuantity.ToString();
                    totalPrice -= stock.unitPrice;
                    calcAmtPayable(totalPrice);
                    totalpricetextBox.Text = FormatPrice.format(totalPrice);
                    selectedStocks.RemoveAt(index);
                    new UpdateDataGridView().removeStockFromDataGridView(selectedStocks, dataGridView2);                        
                }
            }           
           
        }

        private void calcAmtPayable(decimal _amt)
        {
            var value = calcDiscount(calcSCharge(_amt));
            amountPayable = value;
            amountPayableTextbox.Text = FormatPrice.format(value);
        }

        private decimal calcSCharge(decimal totalAmount)
        {
            decimal value = 0;
            if (serviceChargecheckBox.Checked)
            {
                int index = serviceChargeComboBox.SelectedIndex;
                if(index != -1)
                {
                    if(serviceChargeData.Count() > index)
                    {
                        var serviceCharge = serviceChargeData.ElementAt(index);
                        if (serviceCharge.isPercent)
                        {
                            var data = (serviceCharge.percent / 100) * totalAmount;
                            _serviceCharge = data;
                            value = data + totalAmount;
                            return value;
                        }
                        else
                        {
                            value = totalAmount + serviceCharge.discount;
                            _serviceCharge = serviceCharge.discount;
                            return value;
                        }
                    }                                          
                }
            }
            _serviceCharge = 0;
            return totalAmount;
        }

        private decimal calcDiscount(decimal totalAmount)
        {
            try
            {
                decimal value = decimal.Parse(discountTextbox.Text);
                decimal data = (value / 100) * totalAmount;
                discount = data;
                return totalAmount - data;
            }catch(Exception ex)
            {
                if (!string.IsNullOrEmpty(discountTextbox.Text) && !string.IsNullOrWhiteSpace(discountTextbox.Text))
                {
                    MessageBox.Show("Discount value not valid");
                    discount = 0;
                    return totalAmount;
                }
                else
                {
                    discount = 0;
                    return totalAmount;
                }
            }
        }

        private void validateControls()
        {
            if(dataGridView2.RowCount == 0)
            {
                MessageBox.Show("No valid item selected", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (salesRepData == null || !salesRepData.Any() || SelectSellercomboBox.Text == selectSalesRep ||
                SelectSellercomboBox.SelectedIndex == -1)
            {
                errorProvider1.SetError(SelectSellercomboBox, "Please select a valid salesRep");
                return;
            }
            else errorProvider1.Clear();
            if (salesTypeData == null || !salesTypeData.Any() || salesTypeComboBox.Text == selectSalesType ||
                salesTypeComboBox.SelectedIndex == -1)
            {
                errorProvider1.SetError(salesTypeComboBox, "Please provide a valid sales type");
                return;
            }
            else errorProvider1.Clear();
            if(!string.IsNullOrEmpty(amoutPaidTextBox.Text) && !string.IsNullOrWhiteSpace(amoutPaidTextBox.Text))
            {
                try
                {
                    decimal q = decimal.Parse(amoutPaidTextBox.Text);
                    errorProvider1.Clear();
                }catch(Exception ex)
                {
                    errorProvider1.SetError(amoutPaidTextBox, "Invalid amount entered");
                    return;
                }
            }else
            {
                errorProvider1.SetError(amoutPaidTextBox, "Invalid amount entered");
                return;
            }

            processData();
        }

        private async void processData()
        {
            var sales = new List<SalesDataModel>();
            var saleRep = salesRepData.ElementAt(SelectSellercomboBox.SelectedIndex);
            var saleType = salesTypeData.ElementAt(salesTypeComboBox.SelectedIndex);
            decimal amtPaid = decimal.Parse(amoutPaidTextBox.Text);

            if (string.IsNullOrEmpty(customerComboBox.Text))
                if (MessageBox.Show("No valid customer selected. Do you wish to continue?", "Warning", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;


            int index = customerComboBox.SelectedIndex;
            string custId = "";
            if (index != -1)
                custId = customers.ElementAt(index).id;

            if (!MessagePrompt.displayPrompt("Process Payment", "process payment of the selected stocks"))
                return;

            foreach (var data in selectedStocks)
            {
                sales.Add(new SalesDataModel
                {
                    stockId = data.id,
                    lastCostPrice = data.lastCostPrice,
                    soldPrice = data.unitPrice,
                    date = DateTime.Now
                });
            }

            var receipt = new ReceiptDataModel
            {
                invoiceNo = InvoicetextBox.Text,
                totalPrice = totalPrice,
                discount = discount,
                amountPayable = amountPayable,
                serviceCharge = _serviceCharge,
                date = DateTime.Now,
                soldItems = sales,
                salesRep = saleRep.name,
                repId = saleRep.repId,
                salesRepId = saleRep.id,
                salesType = saleType.title,
                salesTypeId = saleType.id,
                customerId = custId,
                totalAmtPaid = amtPaid
               
            };

            await DatabaseOperations.addReceipt(receipt);          

            Ticket ticket = new Ticket
            {
                receiptDate = DateTime.Now,
                receiptNo = InvoicetextBox.Text,
                stocks = selectedStocks,
                amountPayable = amountPayable,
                serviceCharge = _serviceCharge,
                discount = discount,
                totalQuantity = selectedStocks.Count,
                totalPrice = totalPrice
            };
            try
            {
                await ticket.print();                
            }
            catch(Exception e)
            {
                MessageBox.Show("Receipt could not be printed. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            clear();
            InvoicetextBox.Text = GenerateIDs.invoiceId();
        }

        private void clear()
        {
            dataGridView2.Rows.Clear();
            totalPrice = 0;
            totalQuantity = 0;
            totalQuantitytextbox.Clear();
            amountPayableTextbox.Clear();
            amoutPaidTextBox.Clear();
            balTextBox.Clear();
            totalpricetextBox.Clear();
            calcAmtPayable(this.totalPrice);
        }

        private void openCashDrawer()
        {
            try
            {
                SerialPort port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
                byte[] buffer = new byte[5]
                {
                    27,
                    112,
                     0,
                     25,
                     250
                 };
                //port is an instance of a Serial Port
                port.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentCell != null)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                var stock = stocksData.ElementAt(index);
                selectedStocks.Add(stock);
                new UpdateDataGridView().addSelectedStockToDataGridView(stock, dataGridView2);

                totalQuantity += 1;
                totalPrice += stock.unitPrice;
                calcAmtPayable(totalPrice);
                totalpricetextBox.Text = FormatPrice.format(totalPrice);
                totalQuantitytextbox.Text = totalQuantity.ToString();
            }           
        }

        private void generateReceiptButton_Click(object sender, EventArgs e)
        {
            validateControls();            
        }

        private void discountTextbox_TextChanged(object sender, EventArgs e)
        {
            calcAmtPayable(this.totalPrice);
        }

        private void serviceChargeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcAmtPayable(this.totalPrice);
        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void cashDrawerButton_Click(object sender, EventArgs e)
        {
            openCashDrawer();
        }

        private void resButton_Click(object sender, EventArgs e)
        {
            new Recipes().Show();
        }

        private void computeBal()
        {
            if (!string.IsNullOrEmpty(amoutPaidTextBox.Text) && !string.IsNullOrWhiteSpace(amoutPaidTextBox.Text))
            {
                try
                {
                    decimal paid = decimal.Parse(amoutPaidTextBox.Text);
                    balTextBox.Text = FormatPrice.format(amountPayable - paid);
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(amoutPaidTextBox, "Invalid amount");
                }
            }
        }

        private void amoutPaidTextBox_TextChanged(object sender, EventArgs e)
        {
            computeBal();
        }

        private void amountPayableTextbox_TextChanged(object sender, EventArgs e)
        {
            computeBal();
        }

        private void postbutton_Click(object sender, EventArgs e)
        {
            DummyClass c = new DummyClass();
            c.print();
        }
    }
}
