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
    public partial class SuppliersForm : Form
    {
        private List<SupplierDataModel> suppliers; 
        public SuppliersForm()
        {
            InitializeComponent();
            this.contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
        }

        private void manageItemButton_Click(object sender, EventArgs e)
        {
            new AddSuppliers().ShowDialog();

            loadFromDb();
        }

        private void SuppliersForm_Load(object sender, EventArgs e)
        {
            loadFromDb();
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            if(item.Text.ToLower() == "edit")
            {
                if(dataGridView1.CurrentCell != null)
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                    if(suppliers != null && suppliers.Any())
                    {
                        var data = suppliers.ElementAt(index);
                        new AddSuppliers(data).ShowDialog();

                        loadFromDb();
                    }
                }
            }
        }       

        private void loadFromDb()
        {
            dataGridView1.Rows.Clear();
            suppliers = DatabaseOperations.getSuppliers().ToList();
            new UpdateDataGridView().addSuppliersToDataGrid(suppliers, dataGridView1);
        }

        private void refereshButton_Click(object sender, EventArgs e)
        {
            loadFromDb();
        }
    }
}
