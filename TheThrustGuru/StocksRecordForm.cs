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

namespace TheThrustGuru
{
    public partial class StocksRecordForm : Form
    {
        IEnumerable<StockDataModel> stocks;        

        public StocksRecordForm()
        {
            InitializeComponent();
            
            contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            if (item.Text.ToLower() == "edit")
            {
                if (dataGridView1.CurrentCell != null)
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                    if (stocks != null && stocks.Any())
                    {
                        var data = stocks.ElementAt(index);
                        if(new PasscodeForm().ShowDialog() == DialogResult.OK)
                        {
                            new AddStock(data).ShowDialog();
                            loadStocks();
                        }
                    }
                }
            }
        }

        private void StocksRecordForm_Load(object sender, EventArgs e)
        {
            loadStocks();
        }

        private async void loadStocks()
        {
            progressBar1.Visible = true;
            dataGridView1.Rows.Clear();
            stocks = DatabaseOperations.getStocks();
            if (stocks != null && stocks.Any())
            {
                var categoryName = new List<string>();
                var storeName = new List<string>();
                foreach (var data in stocks)
                {
                    categoryName.Add(DatabaseOperations.getCategoryName(data.categoryId));
                    var store = await DatabaseOperations.getStoreById(data.storeId);
                    storeName.Add(store.name);
                }

                new UpdateDataGridView().addStocksToDataGridView(stocks, categoryName, storeName, dataGridView1);
            }
            progressBar1.Visible = false;
        }        

        private void addButton_Click(object sender, EventArgs e)
        {            
            new AddStock().ShowDialog();

            dataGridView1.Rows.Clear();
            loadStocks();               
        }

        private void processAdjust(int index)
        {
            var data = stocks.ElementAt(index);
            new AddStock(data).ShowDialog();

            loadStocks();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (isAdjust)
            //{
            //    if(dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex != -1)
            //    {
            //        processAdjust(dataGridView1.CurrentCell.RowIndex);
            //    }
            //}
        }
    }
}
