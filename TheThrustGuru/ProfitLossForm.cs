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
using TheThrustGuru.Logics;
using TheThrustGuru.Utils;

namespace TheThrustGuru
{
    public partial class ProfitLossForm : Form
    {
        public ProfitLossForm()
        {
            InitializeComponent();
        }

        private async void processData(DateTime dateFrom, DateTime dateTo)
        {
            var data = DatabaseOperations.getSoldStocksByDate(dateFrom, dateTo);
            progressBar1.Visible = true;
            noDataLabel1.Visible = false;

            var value = await data;
            if(value != null && value.Any())
            {
                decimal totalSales = 0, totalCost = 0;
                foreach(var datum in value)
                {
                    totalCost += datum.lastCostPrice;
                    totalSales += datum.soldPrice;
                }
                qtyPurchaseTextBox.Text = value.Count().ToString();
                qtySalesTextBox.Text = value.Count().ToString();
                decimal gross = totalSales - totalCost;
                grossTextBox.Text = FormatPrice.format(gross);

                //Calc net profit/loss with expenses
                var expenses = await DatabaseOperations.getExpensesByDate(dateFrom, dateTo);
                if(expenses != null && expenses.Any())
                {
                    decimal totalAmt = 0;
                    foreach(var dt in expenses)
                    {
                        totalAmt += dt.amount;
                    }
                    new UpdateDataGridView().addExpensesToDataGridView(expenses, dataGridView1);
                    decimal net = gross - totalAmt;
                    netTextBox.Text = FormatPrice.format(net);
                }
                progressBar1.Visible = false;
            }else
            {
                progressBar1.Visible = false;
                noDataLabel1.Visible = true;
            }

        }

        private void toDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if(toDateTimePicker.Value < fromDateTimePicker.Value)
            {
                MessageBox.Show("Selected dates not valid");
                return;
            }

            processData(fromDateTimePicker.Value,toDateTimePicker.Value);
        }

        private void ProfitLossForm_Load(object sender, EventArgs e)
        {

        }
    }
}
