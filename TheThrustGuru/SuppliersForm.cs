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
    public partial class SuppliersForm : Form
    {
        public SuppliersForm()
        {
            InitializeComponent();
        }

        private void manageItemButton_Click(object sender, EventArgs e)
        {
            AddSuppliers aForm = new AddSuppliers();
            DialogResult result = aForm.ShowDialog();
            this.dataGridView1.Rows.Clear();
            new UpdateDataGridView().addSuppliersToDataGrid(DatabaseOperations.getSuppliers(), this.dataGridView1);
        }

        private void SuppliersForm_Load(object sender, EventArgs e)
        {
            new UpdateDataGridView().addSuppliersToDataGrid(DatabaseOperations.getSuppliers(), this.dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            Console.WriteLine(index);
        }
    }
}
