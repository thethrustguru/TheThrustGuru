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
    public partial class Clients : Form
    {
        private List<ClientDataModel> clientModels;
        public Clients()
        {
            InitializeComponent();
            contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
        }

        private void Clients_Load(object sender, EventArgs e)
        {
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
                    if (clientModels != null && clientModels.Any())
                    {
                        var data = clientModels.ElementAt(index);
                        new AddClient(data).ShowDialog();

                        
                    }
                }
            }
        }

        private async void loadDataFromDb()
        {
            clientModels = await DatabaseOperations.getClients();
            if(clientModels != null && clientModels.Any())
            {
                dataGridView1.Rows.Clear();
                new UpdateDataGridView().addClientsToDataGrid(clientModels, dataGridView1);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            new AddClient().Show();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            loadDataFromDb(); 
        }
    }
}
