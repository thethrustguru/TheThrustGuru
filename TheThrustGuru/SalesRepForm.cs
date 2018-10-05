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
    public partial class SalesRepForm : Form
    {
        private List<SalesRepDataModel> salesRepModel;
        public SalesRepForm()
        {
            InitializeComponent();

            contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
        }

        private void manageItemButton_Click(object sender, EventArgs e)
        {
            new AddSalesRepForm().ShowDialog();

            loadDataFromDb();
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            if (item.Text.ToLower() == "edit")
            {
                if (dataGridView1.CurrentCell != null)
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                    if (salesRepModel != null && salesRepModel.Any())
                    {
                        var data = salesRepModel.ElementAt(index);
                        new AddSalesRepForm(data).ShowDialog();

                        loadDataFromDb();
                    }
                }
            }
        }

        private void SalesRepForm_Load(object sender, EventArgs e)
        {
            loadDataFromDb();
        }

        private void loadDataFromDb()
        {
            dataGridView1.Rows.Clear();
            salesRepModel = DatabaseOperations.getSalesReps().ToList();
            if (salesRepModel != null && salesRepModel.Any())
            {
                new UpdateDataGridView().addSalesRepToDataGridView(salesRepModel, dataGridView1);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            loadDataFromDb();
        }
    }
}
