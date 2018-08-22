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

namespace TheThrustGuru
{
    public partial class AddSuppliers : Form
    {
        public AddSuppliers()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            validateControls();
        }

        private void validateControls()
        {
            if (string.IsNullOrWhiteSpace(nametextBox.Text))
            {
                errorProvider1.SetError(nametextBox, "Please enter a valid name");
                return;
            }
            else errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(phonetextBox.Text))
            {
                errorProvider1.SetError(phonetextBox, "Please provide a valid contact phone");
                return;
            }
            else errorProvider1.Clear();

            processData();
        }

        private void processData()
        {
            string name = nametextBox.Text;
            string phone = phonetextBox.Text;
            string category = categorycomboBox.Text;
            string address = addresstextBox.Text;
            string company = companytextBox.Text;
            string other = othertextBox.Text;

            SupplierDataModel su = new SupplierDataModel
            {
                name = name,
                phone = phone,
                category = category,
                address = address,
                company = company,
                other = other
            };

            DatabaseOperations.addSuppliers(new SupplierDataModel
            {
                name = name,
                phone = phone,
                category = category,
                address = address,
                company = company,
                other = other
            });
            MessageBox.Show("Supplier saved successfully");
            nametextBox.Clear();
            phonetextBox.Clear();
            addresstextBox.Clear();
            companytextBox.Clear();
            othertextBox.Clear();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddSuppliers_Load(object sender, EventArgs e)
        {

        }
        
    }
}
