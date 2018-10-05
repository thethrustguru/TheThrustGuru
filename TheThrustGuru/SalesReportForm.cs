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
    public partial class SalesReportForm : Form
    {
        public SalesReportForm()
        {
            InitializeComponent();
        }

        private void dateToDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (dateToDateTimePicker.Value < dateFromDateTimePicker.Value)
            {
                MessageBox.Show("Invalid dates selected.");
                return;
            } else processData(dateFromDateTimePicker.Value, dateToDateTimePicker.Value);
        }

        private async void processData(DateTime dateFrom, DateTime dateTo)
        {
            progressBar1.Visible = true;
            noDataLabel.Visible = false;
            var availableStocks = await DatabaseOperations.getStocksAvailableByDateCreated(dateTo);
            
            if(availableStocks != null && availableStocks.Any())
            {
                var soldStocks = await DatabaseOperations.getSoldStocksByDate(dateFrom, dateTo);
                if(soldStocks != null && soldStocks.Any())
                {
                    var stocks = new List<StockDataModel>();
                    foreach(var datum in soldStocks)
                    {
                        stocks.Add(await DatabaseOperations.getStockById(datum.stockId));
                    }
                    new UpdateDataGridView().salesReportAddItemToDataGridView(availableStocks, stocks, soldStocks.ToList(),
                        dataGridView1, dataGridView2);
                }
            }else
            {
                progressBar1.Visible = false;
                noDataLabel.Visible = true;
            }
        }

        private void SalesReportForm_Load(object sender, EventArgs e)
        {

        }
    }
}
