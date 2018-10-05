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
    public partial class GoodRecievedNotes : Form
    {
        List<ReceivedNotesDataModel> receivedNotes = new List<ReceivedNotesDataModel>();
        public GoodRecievedNotes()
        {
            InitializeComponent();
            contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
        }

        private void GoodRecievedNotes_Load(object sender, EventArgs e)
        {
            loadDataFromDb();
        }

        private async void loadDataFromDb()
        {
            progressBar1.Visible = true;
            receivedNotes = (await DatabaseOperations.getReceivedNotes()).ToList();
            if(receivedNotes != null && receivedNotes.Any())
            {
                new UpdateDataGridView().addReceivedNotesToDataGridView(receivedNotes, dataGridView1);
            }
            progressBar1.Visible = false;
        }

        private async void getDataAndDisplay(int index)
        {
            progressBar2.Visible = true;
            progressBar3.Visible = true;
            var notes = receivedNotes.ElementAt(index);
            var stocks = new List<StockDataModel>();
            if(notes.goodsReceived != null && notes.goodsReceived.Any())
            {
                foreach (var data in notes.goodsReceived)
                {
                    stocks.Add(await DatabaseOperations.getStockById(data.stockId));
                }
                new UpdateDataGridView().addReceivedNotesItemsToDataGridView(stocks, notes.goodsReceived, dataGridView3);
                
            }
            progressBar3.Visible = false;


            var purchases = await DatabaseOperations.getPurchaseOrderById(notes.purchaseId);
            var pstocks = new List<StockDataModel>();
            var quantityList = new List<int>();

            if(purchases != null && purchases.productsList != null && purchases.productsList.Any())
            {
                foreach (var datum in purchases.productsList)
                {
                    quantityList.Add(datum.quantityToSupply);
                    pstocks.Add(await DatabaseOperations.getStockById(datum.stockId));                    
                }

                new UpdateDataGridView().addPurchaseToDataGrid(pstocks, quantityList, dataGridView2);
                
            }
            progressBar2.Visible = false;


        }
        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            if (item.Text.ToLower() == "edit")
            {
                if (dataGridView1.CurrentCell != null)
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                    if (receivedNotes != null && receivedNotes.Any())
                    {
                        var data = receivedNotes.ElementAt(index);
                        new AddReceivedGoods(data).Show();

                        //loadDataFromDb();
                    }
                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView3.CurrentCell != null && dataGridView3.CurrentCell.RowIndex != -1)               
            //{
            //    int index = dataGridView3.CurrentCell.RowIndex;
            //    if(dataGridView3.CurrentCell == dataGridView3[5, index])
            //    {

            //    }
            //}
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex != -1)
            {
                getDataAndDisplay(dataGridView1.CurrentCell.RowIndex);
            }
        }
    }
}
