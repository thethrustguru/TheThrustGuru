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
    public partial class AllItemsForm : Form
    {
        public AllItemsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddItem addItem = new AddItem();
            DialogResult result = addItem.ShowDialog();
            if(result == DialogResult.OK && addItem.items != null)
            {
                DatabaseOperations.saveItems(addItem.items);
                new UpdateDataGridView().addItemsToDataGrid(addItem.items, this.dataGridView1);
            }
        }

        private void AllItemsForm_Load(object sender, EventArgs e)
        {
            new UpdateDataGridView().addItemsToDataGrid(DatabaseOperations.getItems(),this.dataGridView1);
        }
    }
}
