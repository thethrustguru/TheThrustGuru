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
    public partial class AddFood : Form
    {
        public List<FoodsDataModel> foods { get; set; }
        public AddFood()
        {
            InitializeComponent();
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            validateControl();
        }

        private void validateControl()
        {
            if (string.IsNullOrWhiteSpace(nametextBox.Text))
            {
                errorProvider1.SetError(this.nametextBox, "Please enter a valid name");
                return;
            }
            else errorProvider1.Clear();

            if (!string.IsNullOrWhiteSpace(pricetextBox.Text))
            {
                try
                {
                    decimal n = decimal.Parse(pricetextBox.Text);
                    errorProvider1.Clear();
                }
                catch (Exception e)
                {
                    errorProvider1.SetError(this.pricetextBox, "Please enter a valid price ");
                    return;
                }
            }
            else
            {
                errorProvider1.SetError(this.pricetextBox, "Please enter a valid price ");
                return;
            }

            processData();
        }

        private void processData()
        {
            //this.DialogResult = DialogResult.OK;
            string name = nametextBox.Text;
            decimal price = decimal.Parse(pricetextBox.Text);

            //TODO add data to db 
            DatabaseOperations.AddFood(new FoodsDataModel { name = name, price = price });
            MessageBox.Show("Food created successfully");
            this.nametextBox.Clear();
            this.pricetextBox.Clear();
            this.nametextBox.Focus();
            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddFood_Load(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
        }
    }
}
