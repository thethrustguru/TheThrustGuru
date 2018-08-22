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

namespace TheThrustGuru
{
    public partial class StocksRecordForm : Form
    {
        public StocksRecordForm()
        {
            InitializeComponent();
        }

        private void StocksRecordForm_Load(object sender, EventArgs e)
        {
            new UpdateDataGridView().addItemsToDataGrid(DatabaseOperations.getItems(), this.dataGridView1);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddStock addItem = new AddStock();
            DialogResult result = addItem.ShowDialog();
        }
    }
}
