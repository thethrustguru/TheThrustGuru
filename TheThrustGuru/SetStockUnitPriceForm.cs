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
    public partial class SetStockUnitPriceForm : Form
    {
        private IEnumerable<CategoryDataModel> categories;
        private IEnumerable<StockDataModel> stocks;
        //private StockDataModel stockModel;
        public SetStockUnitPriceForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(newUnitPriceTextBox.Text) && !string.IsNullOrEmpty(newUnitPriceTextBox.Text))
            {
                try
                {
                    decimal price = decimal.Parse(newUnitPriceTextBox.Text);
                    errorProvider1.Clear();
                }catch(Exception ex)
                {
                    errorProvider1.SetError(newUnitPriceTextBox, "Please provide a valid new unit price");
                    return;
                }
            }else
            {
                errorProvider1.SetError(newUnitPriceTextBox, "Please provide a valid new unit price");
                return;
            }

            processData();
        }

        private void processData()
        {
            decimal newUnitPrice = decimal.Parse(newUnitPriceTextBox.Text);
            int index = stockComboBox.SelectedIndex;
            if(index != -1)
            {
                var stock = stocks.ElementAt(index);
                stock.unitPrice = newUnitPrice;
                DatabaseOperations.updateStock(stock);
                MessageBox.Show("Unit Price set successfully");
                newUnitPriceTextBox.Clear();
                newUnitPriceTextBox.Focus();
            }else
            {
                MessageBox.Show("Please select an item to update");
            }

        }

        private void SetStockUnitPriceForm_Load(object sender, EventArgs e)
        {
            loadCategories();
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
        

        private async void getDataByCategoryId(string categoryId)
        {
            stockComboBox.Items.Clear();           
            stocks = await DatabaseOperations.getStocksByCategoryId(categoryId);
            if(stocks != null && stocks.Any())
            {
                foreach (var data in stocks)
                {
                    stockComboBox.Items.Add(data.name);
                }
            }
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = categoryComboBox.SelectedIndex;
            if(index != -1)
            {
                var category = categories.ElementAt(index);
                getDataByCategoryId(category.id);
            }
        }

        private void stockComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = stockComboBox.SelectedIndex;
            if (index != -1)
            {
                var stock = stocks.ElementAt(index);
                lastCostPriceTextBox.Text = FormatPrice.format(stock.lastCostPrice);
                highestCostPriceTextBox.Text = FormatPrice.format(stock.highestCostPrice);
                lowestCostPriceTextBox.Text = FormatPrice.format(stock.lowestCostPrice);
                lastUnitPriceTextBox.Text = FormatPrice.format(stock.unitPrice);
            }
        }
    }
}
