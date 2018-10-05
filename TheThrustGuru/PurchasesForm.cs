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
    public partial class PurchasesForm : Form
    {
        

        public PurchasesForm()
        {
            InitializeComponent();
        }
        
        private void PurchasesForm_Load(object sender, EventArgs e)
        {          
            ///loadDataFromDb();
        }

        private async void loadDataFromDb()
        {
            DateTime dateFrom = dateTimePicker1.Value;
            DateTime dateTo = dateTimePicker2.Value;

            if(dateFrom > dateTo)
            {
                MessageBox.Show("Invalid dates selected. ");
                return;
            }

            progressBar1.Visible = true;
            noDataLabel.Visible = false;
            var data = await DatabaseOperations.getPurchasedStocksByDate(dateFrom, dateTo);
            decimal total_price = 0;
            if (data != null && data.Any())
            {
                
                List<StockDataModel> stocksList = new List<StockDataModel>();
                List<int> quantityList = new List<int>();
                foreach (var datum in data)
                {                    
                    var stocks = await DatabaseOperations.getStockById(datum.stockId);
                    total_price = datum.quantityToSupply * stocks.lastCostPrice;
                    stocksList.Add(stocks);
                    quantityList.Add(datum.quantityToSupply);

                }
                progressBar1.Visible = false;
                new UpdateDataGridView().addPurchaseToDataGrid(stocksList,quantityList, this.dataGridView1);
            }
            else noDataLabel.Visible = true;      
                 
            totalPricetextBox.Text = FormatPrice.format(total_price);
        }

        private void purchaseButton_Click(object sender, EventArgs e)
        {
            if(new PasscodeForm().ShowDialog() == DialogResult.OK)
            {
                new AddPurchasesForm().ShowDialog();

                dataGridView1.Rows.Clear();
                loadDataFromDb();
            }
           
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
    }
}
