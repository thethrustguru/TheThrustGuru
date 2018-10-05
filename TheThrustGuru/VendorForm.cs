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
    public partial class VendorForm : Form
    {
        private List<VendorDataModel> vendors;
        public VendorForm()
        {
            InitializeComponent();

            this.contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
        }

        private void manageItemButton_Click(object sender, EventArgs e)
        {
            new AddVendorForm().ShowDialog();

            dataGridView1.Rows.Clear();
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
                    if (vendors != null && vendors.Any())
                    {
                        var data = vendors.ElementAt(index);
                        new AddVendorForm(data).ShowDialog();

                        loadDataFromDb();
                    }
                }
            }
        }

        private void VendorForm_Load(object sender, EventArgs e)
        {
            loadDataFromDb();
        }

        private void loadDataFromDb()
        {
            this.dataGridView1.Rows.Clear();
            vendors = DatabaseOperations.getVendors().ToList();
            if(vendors != null && vendors.Any())
            {               
                new UpdateDataGridView().addVendorsToDatagridView(vendors, dataGridView1);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            loadDataFromDb();
        }
    }
}
