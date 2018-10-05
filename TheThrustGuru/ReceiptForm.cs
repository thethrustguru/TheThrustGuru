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
    public partial class ReceiptForm : Form
    {
        private string searchText = "Search...";
        private string searchParam = "Select search parameter";
        private IEnumerable<ReceiptDataModel> receipts;
        private decimal totalPrice;
        public ReceiptForm()
        {
            InitializeComponent();
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(searchTextBox, searchText);

            if (!searchParamComboBox.Items.Contains(searchParam))
                searchParamComboBox.Items.Add(searchParam);
            searchParamComboBox.Text = searchParam;

            loadDataFromDb();
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
            textbox.Text = string.Empty;
            textbox.ForeColor = Color.Black;
        }

        private void loadDataFromDb()
        {
            receipts = DatabaseOperations.getReceipts().ToList();
            if(receipts != null && receipts.Any())
            {
                foreach(var data in receipts)
                {
                    totalPrice += data.amountPayable;
                }
                totalPriceTextBox.Text = FormatPrice.format(totalPrice);
                new UpdateDataGridView().addReceiptsToDataGridView(receipts, dataGridView1);
            }
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(searchTextBox, searchText);
        }

        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(searchTextBox);
        }

        private void searchParamComboBox_DropDown(object sender, EventArgs e)
        {
            if (searchParamComboBox.Items.Contains(searchParam))
                searchParamComboBox.Items.Remove(searchParam);
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

        private async void getDataAndDisplay(int index)
        {
            if (receipts != null && receipts.Any())
            {
                var data = receipts.ElementAt(index);
                if(data != null)
                {
                    var soldItems = data.soldItems;
                    if(soldItems != null && soldItems.Any())
                    {
                        progressBar1.Visible = true;
                        List<string> categoryName = new List<string>();
                        List<StockDataModel> soldStocks = new List<StockDataModel>();
                        foreach(var datum in soldItems)
                        {
                            var st = await DatabaseOperations.getStockById(datum.stockId);                                 
                            soldStocks.Add(st);
                            categoryName.Add(DatabaseOperations.getCategoryName(st.categoryId));                            
                        }
                        progressBar1.Visible = false;
                        new UpdateDataGridView().addReceiptSoldItemsToDataGridView(soldStocks,soldItems, categoryName, dataGridView2);
                    }
                }
            }
            else
            {
                noDataLabel.Visible = true;
                progressBar1.Visible = false;
            }
        }
               
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataAndDisplay(dataGridView1.CurrentCell.RowIndex);
            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

        }
    }
}
