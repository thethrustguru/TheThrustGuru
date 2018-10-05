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
    public partial class PurchaseOrderForm : Form
    {
        private IEnumerable<PurchaseOrderDataModel> purchases;
        public PurchaseOrderForm()
        {
            InitializeComponent();
            this.contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
        }

        private void PurchaseOrderForm_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            dataGridView1.Rows.Clear();
            purchases = DatabaseOperations.getPurchases();
            new UpdateDataGridView().addPurcharseOrderToDataGridView(purchases, dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(new PasscodeForm().ShowDialog() == DialogResult.OK)
            {
                new AddPurchasesForm().ShowDialog();

                dataGridView1.Rows.Clear();
                loadData();
            }           
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            if (item.Text.ToLower() == "edit")
            {
                if (dataGridView1.CurrentCell != null)
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                    if (purchases != null && purchases.Any())
                    {
                        var data = purchases.ElementAt(index);
                        if (new PasscodeForm().ShowDialog() == DialogResult.OK)
                        {
                            new AddPurchasesForm(data).ShowDialog();

                            loadData();
                        }                       
                    }
                }
            }
        }
    }
}
