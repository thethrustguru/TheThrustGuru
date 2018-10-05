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
using TheThrustGuru.Utils;

namespace TheThrustGuru
{
    public partial class AddStockAdjustment : Form
    {
        private List<StockDataModel> stocks;
        private List<CategoryDataModel> categories;
        private List<StoreLocationDataModel> stores;
        private StockAdjustmentDataModel adjustment;
        public AddStockAdjustment()
        {
            InitializeComponent();
            loadCategory();
            loadStores();
        }

        public AddStockAdjustment(StockAdjustmentDataModel adjustment)
        {
            InitializeComponent();
            loadCategory();
            loadStocks(adjustment.categoryId);
            loadStores();

            dateTimePicker1.Value = adjustment.date;
            categoryComboBox.Text = adjustment.categoryName;
            stockComboBox.Text = adjustment.stockName;
            storeComboBox.Text = adjustment.storeName;
            initialQtyTextBox.Text = adjustment.initialQuantity.ToString();
            newQtyTextBox.Text = adjustment.newQuantity.ToString();
            adjustedQtyTextBox.Text = adjustment.adjustedQuantity.ToString();
            descTextBox.Text = adjustment.description;

            if (stockComboBox.Items.Contains(adjustment.stockName))
            {
                int index = stockComboBox.Items.IndexOf(adjustment.stockName);
                var data = stocks.ElementAt(index);
                highestPriceTextBox.Text = FormatPrice.format(data.highestCostPrice);
                lowestPriceTextBox.Text = FormatPrice.format(data.lowestCostPrice);
                lastPriceTextBox.Text = FormatPrice.format(data.lastCostPrice);
                sellingPriceTextBox.Text = FormatPrice.format(data.unitPrice);
            }           

            this.adjustment = adjustment;
            editButton.Enabled = true;
            deleteButton.Enabled = true;
            saveButton.Enabled = false;
        }

        private void loadCategory()
        {
            categoryComboBox.Items.Clear();
            categories = DatabaseOperations.getCategory().ToList();
            if(categories != null && categories.Any())
            {
                foreach(var data in categories)
                {
                    categoryComboBox.Items.Add(data.name);
                }
            }
        }

        private async void loadStocks(string categoryId)
        {
            stockComboBox.Items.Clear();
            stocks = (await DatabaseOperations.getStocksByCategoryId(categoryId)).ToList();
            if(stocks != null && stocks.Any())
            {
                foreach(var data in stocks)
                {
                    stockComboBox.Items.Add(data.name);
                }
            }
        }

        private void loadStores()
        {
            storeComboBox.Items.Clear();
            stores = DatabaseOperations.getStores().ToList();
            if(stores != null && stores.Any())
            {
                foreach(var dt in stores)
                {
                    storeComboBox.Items.Add(dt.name);
                }
            }
        }

        private void newQtyTextBox_TextChanged(object sender, EventArgs e)
        {
            computeQty();
        }

        private void computeQty()
        {
            try
            {
                int q = int.Parse(newQtyTextBox.Text);
                int r = int.Parse(initialQtyTextBox.Text);
                if (stocks != null && stockComboBox.Items != null && !string.IsNullOrEmpty(stockComboBox.Text))
                {
                    errorProvider1.Clear();
                    //var data = stocks.ElementAt(stockComboBox.SelectedIndex);
                    int adjustedQty = q - r;
                    adjustedQtyTextBox.Text = adjustedQty.ToString();
                }
                else errorProvider1.SetError(stockComboBox, "No stock selected");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(newQtyTextBox, "Invalid quantity entered");
                adjustedQtyTextBox.Text = 0.ToString();
            }
        }

        private void stockComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = stockComboBox.SelectedIndex;
            if(stocks != null && index != -1)
            {
                var data = stocks.ElementAt(index);
                initialQtyTextBox.Text = data.quantity.ToString();
                highestPriceTextBox.Text = FormatPrice.format(data.highestCostPrice);
                lowestPriceTextBox.Text = FormatPrice.format(data.lowestCostPrice);
                lastPriceTextBox.Text = FormatPrice.format(data.lastCostPrice);
                sellingPriceTextBox.Text = FormatPrice.format(data.unitPrice);
                computeQty();
            }
        }

        private void validateControl(bool isEdit)
        {
            if (string.IsNullOrEmpty(categoryComboBox.Text))
            {
                errorProvider1.SetError(categoryComboBox, "Please select a vaid category");
                return;
            }
            else errorProvider1.Clear();
            if (string.IsNullOrEmpty(stockComboBox.Text))
            {
                errorProvider1.SetError(stockComboBox, "Please select a valid stock");
                return;
            }
            else errorProvider1.Clear();
            if (string.IsNullOrEmpty(storeComboBox.Text))
            {
                errorProvider1.SetError(storeComboBox, "Please select a valid store");
                return;
            }
            else errorProvider1.Clear();
            if(!string.IsNullOrEmpty(newQtyTextBox.Text) && !string.IsNullOrWhiteSpace(newQtyTextBox.Text))
            {
                try
                {
                    int q = int.Parse(newQtyTextBox.Text);
                    errorProvider1.Clear();
                }catch(Exception ex)
                {
                    errorProvider1.SetError(newQtyTextBox, "New quantity is invalid");
                    return;
                }
            }else
            {
                errorProvider1.SetError(newQtyTextBox, "New quantity is required");
                return;
            }

            processData(isEdit);
        }

        private async void processData(bool isEdit)
        {
            var category = categories.ElementAt(categoryComboBox.SelectedIndex);
            var stock = stocks.ElementAt(stockComboBox.SelectedIndex);
            var store = stores.ElementAt(storeComboBox.SelectedIndex);
            int newQty = int.Parse(newQtyTextBox.Text);
            DateTime date = dateTimePicker1.Value;
            string desc = descTextBox.Text;
            int initialQty = int.Parse(initialQtyTextBox.Text);

            if (isEdit)
            {
                if (!MessagePrompt.displayPrompt("Edit", "edit this stock adjustment"))
                    return;

                adjustment.stockName = stock.name;
                adjustment.stockId = stock.id;
                adjustment.initialQuantity = initialQty;
                adjustment.newQuantity = newQty;
                adjustment.adjustedQuantity = (newQty - stock.quantity);
                adjustment.description = desc;
                adjustment.categoryName = category.name;
                adjustment.categoryId = category.id;
                adjustment.storeName = store.name;
                adjustment.storeId = store.id;
                adjustment.date = date;

                bool success = await DatabaseOperations.editAdjustment(adjustment);

                MessageBox.Show( success ? "Adjustment updated successfully" :
                    "Adjustment updating failed");                            
            }else
            {
                if (!MessagePrompt.displayPrompt("Create New", "add new stock adjustment"))
                    return;

                bool success = await DatabaseOperations.addAdjustments(new StockAdjustmentDataModel
                {
                    stockName = stock.name,
                    stockId = stock.id,
                    initialQuantity = stock.quantity,
                    newQuantity = newQty,
                    adjustedQuantity = (newQty - stock.quantity),
                    description = desc,
                    categoryName = category.name,
                    categoryId = category.id,
                    storeName = store.name,
                    storeId = store.id,
                    date = date
                });

                if (success)
                {
                    MessageBox.Show("Adjustment added successfully");
                    newQtyTextBox.Clear();
                    newQtyTextBox.Focus();
                }else
                {
                    MessageBox.Show("Adding adjustment failed");
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            validateControl(true);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            validateControl(false);
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (!MessagePrompt.displayPrompt("Delete", "delete this stock adjustment"))
                return;

            bool success = await DatabaseOperations.deleteAdjustment(adjustment.id);
            if (success)
            {
                MessageBox.Show("Stock adjustment deleted successfully");
                Close();
            }
            else MessageBox.Show("Stock adjustment deletion failed");
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = categoryComboBox.SelectedIndex;
            if(index != -1)
            {
                var dt = categories.ElementAt(index);
                loadStocks(dt.id);
            }
        }
    }
}
