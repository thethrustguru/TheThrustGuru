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
    public partial class StockAdjustment : Form
    {
        private List<StockAdjustmentDataModel> adjustments;
        public StockAdjustment()
        {
            InitializeComponent();
            contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
        }

        private void StockAdjustment_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            if (item.Text.ToLower() == "edit")
            {
                if (dataGridView1.CurrentCell != null)
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                    if (adjustments != null && adjustments.Any())
                    {
                        var data = adjustments.ElementAt(index);
                        new AddStockAdjustment(data).ShowDialog();

                        loadData();
                    }
                }
            }
        }

        private async void loadData()
        {
            dataGridView1.Rows.Clear();
            adjustments = await DatabaseOperations.getAdjustments();
            if(adjustments != null && adjustments.Any())
            {
                new UpdateDataGridView().addStockAdjustmentToDataGridView(adjustments, dataGridView1);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            new AddStockAdjustment().Show();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
