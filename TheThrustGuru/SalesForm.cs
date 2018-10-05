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
    public partial class SalesForm : Form
    {
        private string searchParam = "Select search parameter...";
        private string search = "search...";
        private decimal totalPrice;
        public SalesForm()
        {
            InitializeComponent();
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

        private void searchParamComboBox_DropDown(object sender, EventArgs e)
        {
            if (searchParamComboBox.Items.Contains(searchParam))
                searchParamComboBox.Items.Remove(searchParam);
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(searchTextBox, search);

            if (!searchParamComboBox.Items.Contains(searchParam))
                searchParamComboBox.Items.Add(searchParam);
            searchParamComboBox.Text = searchParam;

            loadDataFromDB();
        }

        private void searchParamComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if(searchParamComboBox.SelectedIndex == -1)
            {
                if (!searchParamComboBox.Items.Contains(searchParam))
                    searchParamComboBox.Items.Add(searchParam);
                searchParamComboBox.Text = searchParam;
            }
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(searchTextBox, search);
        }

        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(searchTextBox);
        }

        private async void loadDataFromDB()
        {
            progressBar1.Visible = true;
            var soldStocks = DatabaseOperations.getSoldStocks();
            var stockList = new List<StockDataModel>();
            var categoryNames = new List<string>();
            var storeNames = new List<string>();
            var dates = new List<DateTime>();
            StockDataModel stock;
            StoreLocationDataModel store;
            if (soldStocks != null && soldStocks.Any())
            {
                foreach (var data in soldStocks)
                {
                    dates.Add(data.date);
                    stock = await DatabaseOperations.getStockById(data.stockId);
                    stockList.Add(stock);
                    categoryNames.Add(DatabaseOperations.getCategoryName(stock.categoryId));
                    store = await DatabaseOperations.getStoreById(stock.storeId);
                    storeNames.Add(store.name);
                    totalPrice += stock.unitPrice;
                }
                totalPricetextBox.Text = FormatPrice.format(totalPrice);
                new UpdateDataGridView().addSoldItemsToDataGridView(stockList, categoryNames, storeNames, dates, dataGridView1);
            }
            progressBar1.Visible = false;
        }
    }
}
