using System;
using System.Drawing;
using System.Windows.Forms;
using TheThrustGuru.DataModels;
using TheThrustGuru.Utils;

namespace TheThrustGuru
{
    public partial class AddItem : Form
    {
        private string name = "Item name";
        private string desc = "Description";
        private string costprice = "Cost Price";
        private string sellingPrice = "Selling Price";
        private string quantity = "Quantity";
        public ItemsDataModel items { get; set; }
        public AddItem()
        {
            InitializeComponent();
            waterMarkOnTextBoxLeave(this.nameTextBox,name);
            waterMarkOnTextBoxLeave(this.descTextBox, desc);
            waterMarkOnTextBoxLeave(this.costPriceTextBox, costprice);
            waterMarkOnTextBoxLeave(this.quantityTextBox, quantity);
            waterMarkOnTextBoxLeave(this.sellingPriceTextBox, sellingPrice);

            //this.nameTextBox.Validating += new CancelEventHandler(this.nameTextBox_Validating);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void waterMarkOnTextBoxLeave(TextBox textbox, string placeHolder)
        {
            if (String.IsNullOrEmpty(textbox.Text) || textbox.Text == placeHolder)
            {
                textbox.ForeColor = Color.Gray;
                textbox.Text = placeHolder;
            }
            else
            {
                textbox.ForeColor = Color.Black;
            }
        }
        private void waterMarkOnTextBoxEnter(TextBox textbox,String placeholder)
        {
            if(textbox.Text == placeholder)
            {
                textbox.Text = String.Empty;
                textbox.ForeColor = Color.Black;
            }
           
        }       
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(this.nameTextBox, name);
        }

        private void nameTextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(this.nameTextBox,name);
        }

        private void descTextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(this.descTextBox, desc);
        }

        private void descTextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(this.descTextBox,desc);
        }

        private void priceTextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(this.costPriceTextBox, costprice);
        }

        private void priceTextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(this.costPriceTextBox, costprice);
        }

        private void quantityTextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(this.quantityTextBox, quantity);
        }

        private void quantityTextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(this.quantityTextBox,quantity);
        }

        private void AddFoodItems_Load(object sender, EventArgs e)
        {
            this.categoryComboBox.Items.Add("Select Category");
            this.categoryComboBox.SelectedIndex = 0;

        }

        private void validateControls()
        {
            if (notValid(this.nameTextBox, name))
            {
                errorProvider.SetError(this.nameTextBox, "Please provide a valid name");
                return;
            }
            else errorProvider.Clear();

            if (notValidPrice(this.costPriceTextBox, costprice))
            {
                errorProvider.SetError(this.costPriceTextBox, "Please provide a valid price. Price must be numeric");
                return;
            }
            else errorProvider.Clear();
            if (notValidPrice(this.sellingPriceTextBox, sellingPrice))
            {
                errorProvider.SetError(this.sellingPriceTextBox, "Please provide a valid price. Price must be numeric");
                return;
            }
            else errorProvider.Clear();
            if (notValidPrice(this.quantityTextBox, quantity))
            {
                errorProvider.SetError(this.quantityTextBox, "Please provide a valid quantity. Quantity must be numeric");
                return;
            }
            else errorProvider.Clear();
            if (String.IsNullOrEmpty(categoryComboBox.Text) || String.IsNullOrWhiteSpace(categoryComboBox.Text) || categoryComboBox.Text.ToLower() == "select category")
            {
                errorProvider.SetError(this.categoryComboBox, "Please provide a valid category");
                return;
            }
            else errorProvider.Clear();

            processData();
        }

        private void processData()
        {
            string _name = nameTextBox.Text;
            string _desc = descTextBox.Text;
            string category = categoryComboBox.Text;
            decimal cost_price = 0;
            decimal selling_price = 0;
            int quantity = 0;            
                       
            try
            {
                cost_price = decimal.Parse(costPriceTextBox.Text);
                selling_price = decimal.Parse(sellingPriceTextBox.Text);
                quantity= int.Parse(quantityTextBox.Text);
            }catch(Exception ex)
            {

            }

            //foodItems = new FoodItemsDataModel.FoodItemModel
            //{
            //   _id = RandomIDGenerator.randomString(8),
            //    name = _name,
            //    count = _total,
            //    price = _price,
            //    total_price = (_price * _total),
            //    date_added = DateTime.Now.ToString(),
            //    date_lastmodified = DateTime.Now.ToString()
            //};
            items = new ItemsDataModel
            {
                itemName = name,
                itemCostPrice = cost_price,
                itemQuantity = quantity,
                itemSellingPrice = selling_price,
                itemCategory = category,
                dateCreated = DateTime.Today.ToString()
        };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool notValid(TextBox textbox, string value)
        {
            return (String.IsNullOrEmpty(textbox.Text) || String.IsNullOrWhiteSpace(textbox.Text) || textbox.Text == value);
        }     
        private bool notValidPrice(TextBox textbox, string value)
        {            
            if (String.IsNullOrEmpty(textbox.Text) || String.IsNullOrWhiteSpace(textbox.Text) || textbox.Text == value)
                return true;
            else            
                try
                {
                    decimal price = decimal.Parse(textbox.Text);
                    return false;
                }catch(Exception ex)
                {
                    return true;
                }
            
        }

        private void Okbutton_Click(object sender, EventArgs e)
        {
            validateControls();
        }

        private void sellingPriceTextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(this.sellingPriceTextBox, sellingPrice);
        }

        private void sellingPriceTextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(this.sellingPriceTextBox, sellingPrice);
        }
    }
}
