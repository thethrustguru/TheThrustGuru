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
    public partial class StockTransferForm : Form
    {
        private List<StockTransferRecordDataModel> transferRecord;
        UpdateDataGridView updateDataGrid = new UpdateDataGridView();
        public StockTransferForm()
        {
            InitializeComponent();
        }

        private void receiveStockButton_Click(object sender, EventArgs e)
        {
                   
        }

        private void issueStockButton_Click(object sender, EventArgs e)
        {
            new IssueStockForm().ShowDialog();
        }

        private void StockTransferForm_Load(object sender, EventArgs e)
        {
            loadDataFromDB();
        }

        private async void loadDataFromDB()
        {
            transferRecord = (await DatabaseOperations.getStockTransfer()).ToList();
            updateDataGrid.addTransferRecordToDataGridView(transferRecord, dataGridView1);
        }

        private async void getDataAndDisplay(int index)
        {
            if(transferRecord != null && transferRecord.Any())
            {
                var data = transferRecord.ElementAt(index);
                var stocks = new List<StockDataModel>();
                var quantity = new List<int>();
                if(data != null && data.stockItems != null && data.stockItems.Any())
                {
                    progressBar1.Visible = true;
                    foreach(var datum in data.stockItems)
                    {
                        stocks.Add(await DatabaseOperations.getStockById(datum.stockId));
                        quantity.Add(datum.quantity);
                    }
                    updateDataGrid.addTransferedItemsToDataGridView(stocks, quantity, dataGridView2);
                    progressBar1.Visible = false;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentCell != null)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                getDataAndDisplay(index);
            }
        }
    }
}
