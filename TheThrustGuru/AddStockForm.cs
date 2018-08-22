using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TheThrustGuru.Database;
using TheThrustGuru.DataModels;
using TheThrustGuru.Utils;

namespace TheThrustGuru
{
    public partial class AddStock : Form
    {
        private string name = "Stock name";
        private string desc = "Description";
        private string costprice = "Cost Price";
        private string sellingPrice = "Unit Price";
        private string quantity = "Quantity";
        private string selectCategory = "Select Category";
        private string unit = "Unit";
        private string sku = "Sku";
        private string vendor = "Select Preffered vendor";
        private IEnumerable<VendorDataModel> vendorsInfo;
        private IEnumerable<CategoryDataModel> categories;

        public ItemsDataModel items { get; set; }
        public AddStock()
        {
            InitializeComponent();
            waterMarkOnTextBoxLeave(this.nameTextBox,name);
            waterMarkOnTextBoxLeave(this.descTextBox, desc);
            waterMarkOnTextBoxLeave(this.costPriceTextBox, costprice);
            waterMarkOnTextBoxLeave(this.quantityTextBox, quantity);
            waterMarkOnTextBoxLeave(this.sellingPriceTextBox, sellingPrice);
            waterMarkOnTextBoxLeave(unitTextBox, unit);
            waterMarkOnTextBoxLeave(skuTextBox, sku);
                      
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
            if (!categoryComboBox.Items.Contains(selectCategory))
                categoryComboBox.Items.Add(selectCategory);
            categoryComboBox.Text = selectCategory;

            if (!vendorComboBox.Items.Contains(vendor))
                vendorComboBox.Items.Add(vendor);
            vendorComboBox.Text = vendor;

            loadVendors();
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
            string sku = skuTextBox.Text;
            string unit = unitTextBox.Text;
            string vendorId = "", categoryId = "";
            if (vendorComboBox.SelectedIndex != -1)
                vendorId = vendorsInfo.ElementAt(vendorComboBox.SelectedIndex).id;            
            if (categoryComboBox.SelectedIndex != -1)
                categoryId = categories.ElementAt(categoryComboBox.SelectedIndex).id;
            decimal  cost_price = 0;
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

            DatabaseOperations.addStocks(new StockDataModel
            {
                name = _name,
                desc = _desc,
                sku = sku,
                unit = unit,
                costPrice = cost_price,
                unitPrice = selling_price,
                quantity = quantity,
                vendorId = vendorId,
                categoryId = categoryId

            });

            nameTextBox.Clear();
            descTextBox.Clear();
            skuTextBox.Clear();
            unitTextBox.Clear();
            costPriceTextBox.Clear();
            sellingPriceTextBox.Clear();          
        }

       private void loadVendors()
        {
            vendorsInfo = DatabaseOperations.getVendors();            
            if(vendorsInfo != null && vendorsInfo.Any())
            {
                foreach(var data in vendorsInfo)
                {
                    vendorComboBox.Items.Add(data.name);
                }
            }
        }

        private void loadCategories()
        {
            categories = DatabaseOperations.getCategory();
            if(categories != null && categories.Any())
            {
                foreach(var data in categories)
                {
                    categoryComboBox.Items.Add(data.name);
                }
            }
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

        private void categoryComboBox_DropDown(object sender, EventArgs e)
        {
            if (categoryComboBox.Items.Contains(selectCategory))
                categoryComboBox.Items.Remove(selectCategory);        
        }

        private void categoryComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if(categoryComboBox.SelectedIndex == -1)
            {
                if (!categoryComboBox.Items.Contains(selectCategory))
                    categoryComboBox.Items.Add(selectCategory);
                categoryComboBox.Text = selectCategory;
            }
        }

        private void unitTextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(unitTextBox, unit);
        }

        private void unitTextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(unitTextBox, unit);
        }

        private void skuTextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(skuTextBox, sku);
        }

        private void skuTextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(skuTextBox, sku);
        }

        private void vendorComboBox_DropDown(object sender, EventArgs e)
        {
            if (vendorComboBox.Items.Contains(vendor))
                vendorComboBox.Items.Remove(vendor);
        }

        private void vendorComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if(vendorComboBox.SelectedIndex == -1)
            {
                if (!vendorComboBox.Items.Contains(vendor))
                    vendorComboBox.Items.Add(vendor);
                vendorComboBox.Text = vendor;
            }
        }
    }
}
