using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TheThrustGuru.Database;
using TheThrustGuru.DataModels;
using TheThrustGuru.Utils;

namespace TheThrustGuru
{
    public partial class AddStock : Form
    {        
        private IEnumerable<VendorDataModel> vendorsInfo;
        private IEnumerable<CategoryDataModel> categories;
        private IEnumerable<StoreLocationDataModel> storesData;
        //private bool isEdit;
        private StockDataModel stockToEdit;

        public AddStock()
        {
            InitializeComponent();                                
        }

        public AddStock(StockDataModel stock)
        {
            InitializeComponent();

            setDataToEdit(stock);

            saveButton.Enabled = false;
            editButton.Visible = true;
            deleteButton.Visible = true;
            this.stockToEdit = stock;

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        private void AddFoodItems_Load(object sender, EventArgs e)
        {           
            loadVendors();

            loadCategories();

            loadStores();
            
        }

        private void setDataToEdit(StockDataModel stock)
        {
            nameTextBox.Text = stock.name;
            descTextBox.Text = stock.desc;
            skuTextBox.Text = stock.sku;
            unitTextBox.Text = stock.unit;
            highestCostPriceTextBox.Text = stock.highestCostPrice.ToString();
            lowestCostPricetextBox.Text = stock.lowestCostPrice.ToString();
            lastCostPricetextBox.Text = stock.lastCostPrice.ToString();
            quantityTextBox.Text = stock.quantity.ToString();
            sellingPriceTextBox.Text = stock.unitPrice.ToString();            

            if (!string.IsNullOrEmpty(stock.vendorId) && vendorsInfo != null && vendorsInfo.Any())
            {
                foreach(var data in vendorsInfo)
                {
                    if(data.id == stock.vendorId)
                    {
                        vendorComboBox.Text = data.name;
                        break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(stock.storeId) && storesData != null && storesData.Any())
            {
                foreach (var data in storesData)
                {
                    if (data.id == stock.storeId)
                    {
                        storeComboBox.Text = data.name;
                        break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(stock.categoryId) && categories != null && categories.Any())
            {
                foreach (var data in categories)
                {
                    if (data.id == stock.categoryId)
                    {
                        categoryComboBox.Text = data.name;
                        break;
                    }
                }
            }
        }

        private void validateControls(bool isEdit)
        {

            if (notValid(this.nameTextBox))
            {
                errorProvider.SetError(this.nameTextBox, "Please provide a valid name");
                return;
            }
            else errorProvider.Clear();

            if (notValidPrice(this.highestCostPriceTextBox))
            {
                errorProvider.SetError(this.highestCostPriceTextBox, "Please provide a valid price. Price must be numeric");
                return;
            }
            else errorProvider.Clear();
            if (notValidPrice(this.sellingPriceTextBox))
            {
                errorProvider.SetError(this.sellingPriceTextBox, "Please provide a valid price. Price must be numeric");
                return;
            }
            else errorProvider.Clear();
            if (notValidPrice(lowestCostPricetextBox))
            {
                errorProvider.SetError(lowestCostPricetextBox, "Please provide a valid price. Price must be numeric");
                return;
            }
            else errorProvider.Clear();
            if (notValidPrice(lastCostPricetextBox))
            {
                errorProvider.SetError(lastCostPricetextBox, "Please provide a valid price. Price must be numeric");
                return;
            }
            else errorProvider.Clear();
            if (notValidQty(this.quantityTextBox))
            {
                errorProvider.SetError(this.quantityTextBox, "Please provide a valid quantity. Quantity must be numeric");
                return;
            }
            else errorProvider.Clear();
            if (String.IsNullOrEmpty(categoryComboBox.Text) || String.IsNullOrWhiteSpace(categoryComboBox.Text) || categoryComboBox.Text.ToLower() == "select category")
            {
                errorProvider.SetError(this.categoryComboBox, "Please select a valid category");
                return;
            }
            else errorProvider.Clear();
            if (String.IsNullOrEmpty(storeComboBox.Text) || String.IsNullOrWhiteSpace(storeComboBox.Text))
            {
                errorProvider.SetError(this.storeComboBox, "Please select a valid store location");
                return;
            }
            else errorProvider.Clear();

            processData(isEdit);
        }

        private void processData(bool isEdit)
        {
            string _name = nameTextBox.Text;
            string _desc = descTextBox.Text;
            string category = categoryComboBox.Text;
            string sku = skuTextBox.Text;
            string unit = unitTextBox.Text;            
            string vendorId = "", categoryId = "",storeId = "";
            int vIndex = vendorComboBox.SelectedIndex;
            int cIndex = categoryComboBox.SelectedIndex;
            int sIndex = storeComboBox.SelectedIndex;
            if ( vIndex != -1)
            {
                if(vendorsInfo.Any() && vIndex <= vendorsInfo.Count())
                vendorId = vendorsInfo.ElementAt(vIndex).id;
            }                         
            if (cIndex != -1)
            {
                if(categories.Any() && cIndex <= categories.Count())
                    categoryId = categories.ElementAt(cIndex).id;
            }
            if (sIndex != -1)
            {
                if (storesData.Any() && sIndex <= storesData.Count())
                    storeId = storesData.ElementAt(sIndex).id;
            }
            decimal  highestCostPrice = 0,lowestCostPrice = 0,lastCostPrice = 0;
            decimal selling_price = 0;
            int quantity = 0;                        
                       
            try
            {
                highestCostPrice = decimal.Parse(highestCostPriceTextBox.Text);
                lowestCostPrice = decimal.Parse(lowestCostPricetextBox.Text);
                lastCostPrice = decimal.Parse(lastCostPricetextBox.Text);
                selling_price = decimal.Parse(sellingPriceTextBox.Text);
                quantity = int.Parse(quantityTextBox.Text);
            }catch(Exception ex)
            {
                MessageBox.Show("Invalid Data");
                return;
            }

            var stock = new StockDataModel
            {
                name = _name,
                desc = _desc,
                sku = sku,
                unit = unit,
                highestCostPrice = highestCostPrice,
                lowestCostPrice = lowestCostPrice,
                lastCostPrice = lastCostPrice,
                unitPrice = selling_price,
                quantity = quantity,
                vendorId = vendorId,
                categoryId = categoryId,
                storeId = storeId,
                storeLocation = storeComboBox.Text,
                date = DateTime.Now

            };

            if (isEdit)
            {
                if (!MessagePrompt.displayPrompt("Edit", "edit this stock"))
                    return;

                stock.id = stockToEdit.id;
                DatabaseOperations.updateStock(stock);
                MessageBox.Show("Stock Updated successfully");
                
            }else
            {
                if (!MessagePrompt.displayPrompt("Create New", "create new stock"))
                    return;

                DatabaseOperations.addStocks(stock);
                MessageBox.Show("Stocks added successfully");

                nameTextBox.Clear();
                descTextBox.Clear();
                skuTextBox.Clear();
                unitTextBox.Clear();
                highestCostPriceTextBox.Clear();
                lowestCostPricetextBox.Clear();
                lastCostPricetextBox.Clear();
                sellingPriceTextBox.Clear();
                quantityTextBox.Clear();
                nameTextBox.Focus();
            }                      
        }

        private void loadVendors()
        {
            vendorsInfo = DatabaseOperations.getVendors();            
            if(vendorsInfo != null && vendorsInfo.Any())
            {
                foreach(var data in vendorsInfo)
                {
                    vendorComboBox.Items.Add(data.name);
                }
            }
        }

        private void loadCategories()
        {
            categories = DatabaseOperations.getCategory();
            if(categories != null && categories.Any())
            {
                foreach(var data in categories)
                {
                    categoryComboBox.Items.Add(data.name);
                }
            }
        }

        private void loadStores()
        {
            storesData = DatabaseOperations.getStores();
            if(storesData != null && storesData.Any())
            {
                foreach(var data in storesData)
                {
                    storeComboBox.Items.Add(data.name);
                }
            }
        }

        private bool notValid(TextBox textbox)
        {
            return (String.IsNullOrEmpty(textbox.Text) || String.IsNullOrWhiteSpace(textbox.Text));
        }

        private bool notValidQty(TextBox textbox)
        {
            if (String.IsNullOrEmpty(textbox.Text) || String.IsNullOrWhiteSpace(textbox.Text))
                return true;
            else
                try
                {
                    int price = int.Parse(textbox.Text);
                    return false;
                }
                catch (Exception ex)
                {
                    return true;
                }
        }    

        private bool notValidPrice(TextBox textbox)
        {            
            if (String.IsNullOrEmpty(textbox.Text) || String.IsNullOrWhiteSpace(textbox.Text))
                return true;
            else            
                try
                {
                    decimal price = decimal.Parse(textbox.Text);
                    return false;
                }catch(Exception ex)
                {
                    return true;
                }
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            validateControls(false);
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (!MessagePrompt.displayPrompt("Delete", "delete this stock"))
                return;

            MessageBox.Show(await DatabaseOperations.deleteStock(stockToEdit.id) ? "Stock deleted successfully" : 
                "Stock deletion failed");
            Close();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            validateControls(true);
        }
    }
}
